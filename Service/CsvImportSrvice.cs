using Contract;
using Entity;
using Microsoft.AspNetCore.Http;
using Service.Contract;
using System.Globalization;

namespace Service
{
    /// <summary>
    /// Service for import CSV file
    /// </summary>
    public class CsvImportSrvice: ICsvImportSrvice
    {
        private readonly IRepositoryManager _repositoryManager;
        public CsvImportSrvice(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        /// <summary>
        /// Method for import
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<ImportResult> ImportAsync(IFormFile formFile)
        {
            var result = new ImportResult();

            if (formFile == null || formFile.Length == 0)
            {
                result.Errors.Add("File is empty or missing.");
                return result;
            }

            using var reader = new StreamReader(formFile.OpenReadStream());
            bool isFirstLine = true;

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Пропускаем заголовок
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                result.Processed++;

                try
                {
                    var values = line.Split(',');

                    var employee = new Employee
                    {
                        PayrollNumber = values.ElementAtOrDefault(0)?.Trim(),
                        Forenames = values.ElementAtOrDefault(1)?.Trim(),
                        Surname = values.ElementAtOrDefault(2)?.Trim(),
                        DateOfBirth = TryParseDate(values.ElementAtOrDefault(3)),
                        Telephone = values.ElementAtOrDefault(4)?.Trim(),
                        Mobile = values.ElementAtOrDefault(5)?.Trim(),
                        Address = values.ElementAtOrDefault(6)?.Trim(),
                        Address_2 = values.ElementAtOrDefault(7)?.Trim(),
                        Postcode = values.ElementAtOrDefault(8)?.Trim(),
                        EmailHome = values.ElementAtOrDefault(9)?.Trim(),
                        Start_Date = TryParseDate(values.ElementAtOrDefault(10)),
                        RawCsv = line
                    };

                    _repositoryManager.EmployeeRepository.CreateEmployee(employee);
                    result.Inserted++;
                }
                catch (Exception ex)
                {
                    result.Failed++;
                    result.Errors.Add($"Line {result.Processed}: {ex.Message}");
                }
            }
            await _repositoryManager.SaveAsync();
            return result;
        }
        /// <summary>
        /// Custom Convert to datetime for SQL
        /// Return null if couldn't convert
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private DateTime? TryParseDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            input = input.Trim();
            
            if (input.Contains(" "))
                input = input.Split(' ')[0];

            string[] formats =
            {
                "dd/MM/yyyy", "d/M/yyyy",
                "dd.MM.yyyy", "d.M.yyyy",
                "dd-MM-yyyy", "d-M-yyyy",
                "yyyy-MM-dd", "yyyy/MM/dd"
            };

            if (DateTime.TryParseExact(
                input,
                formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out var date))
                return date;

            if (DateTime.TryParseExact(input, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                return date;

            return null;
        }

    }
}
