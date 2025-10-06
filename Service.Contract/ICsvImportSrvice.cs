using Entity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICsvImportSrvice
    {
        Task<ImportResult> ImportAsync(IFormFile file);
    }
}
