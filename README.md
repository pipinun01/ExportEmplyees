# ExportEmplyees
## Description

**ExportEmployees** is a web application that allows you to **import employee data from an Excel file** into a SQL Server database.
It displays the imported data in a table and provides validation for dates and other fields.

## ⚙️ Features

* Import employees from `.xlsx` or `.xls` files
* Automatically parse and validate data (including date formats)
* Display imported data in a web interface
* Prevent duplicate imports after page reload
* Support for both `nvarchar` and `datetime` SQL data types

## 🧩 Technologies Used

* **ASP.NET Core MVC**
* **Entity Framework Core**
* **SQL Server**
* **EPPlus** (for reading Excel files)
* **Bootstrap** (for UI styling)

## 🚀 How to Run

1. Clone the repository

   ```bash
   git clone https://github.com/your-username/ExportEmployees.git
   ```
2. Open the project in **Visual Studio**
3. Update the connection string in `appsettings.json`
   
## 📁 Folder Structure

```
ExportEmployees/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── Data/
├── Services/
└── Program.cs
```

## 📦 Example Excel File

| PayrollNumber | Forenames | Surname | DateOfBirth | Telephone | Mobile | Address | EmailHome | Start_Date |
| ------------- | --------- | ------- | ----------- | --------- | ------ | ------- | --------- | ---------- |

## 🧠 Notes

* After a successful import, the data is saved to the database and won’t be re-imported on page reload
