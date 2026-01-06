===================================
BANKING ACCOUNT MANAGEMENT SYSTEM 
===================================
Author: Abhay
Technology Stack: C#, WPF, .NET Core, Entity Framework Core, SQL Server (LocalDB)

PROJECT OVERVIEW:
-----------------
This application is a robust Account Management system designed to 
handle banking customer records with high data integrity and 
strict validation rules.

KEY FEATURES IMPLEMENTED:
-------------------------
1. FULL CRUD OPERATIONS:
   - Create: New accounts with auto-generated 4-digit Account Numbers.
   - Modify: Update existing user details via the Management interface.
   - View: A comprehensive DataGrid displaying all 11+ required fields.
   - Delete: Secure deletion with professional confirmation prompts.

2. DATA INTEGRITY & FORMATTING:
   - Automated Uppercase: All string data (Names, Address, PAN) is 
     converted to UPPERCASE before database persistence.
   - Professional Navigation: Unified UI driven by Action Buttons 
     (Create/Modify/View).

3. STRICT VALIDATION:
   - Mobile: 10-digit validation starting with 6-9.
   - PAN: Validates standard Indian PAN format (5 Letters, 4 Digits, 1 Letter).
   - Names: Minimum 3-character requirement.
   - Age: Restricted to the 5–80 years bracket.

SETUP INSTRUCTIONS 
-------------------
1. Extract the ZIP folder.
2. Open 'BankAssignment.sln' in Visual Studio 2022.
3. Open the 'Package Manager Console' (Tools > NuGet Package Manager).
4. Execute the command: Update-Database
   (This will automatically create the 'BankAssignmentDB' and table schema).
5. Press F5 to Run the application.

NOTES:
------
- The application uses Entity Framework Core Migrations to manage the schema.
- Database connection uses SQL Server LocalDB (Trusted Connection).
===========================================================