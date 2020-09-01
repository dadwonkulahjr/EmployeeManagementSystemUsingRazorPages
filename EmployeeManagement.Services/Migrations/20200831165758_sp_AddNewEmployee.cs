using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Services.Migrations
{
    public partial class sp_AddNewEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureToExecute = @"Create Procedure sp_AddNewEmployee
                                            @Name nvarchar(100),
                                            @Email nvarchar(100),
                                            @Department int,
                                            @PhotoPath nvarchar(100)
                                            as
                                            Begin
	                                            Insert Into Employees([Name], [Email], [Department],[PhotoPath])
	                                            Values(@Name, @Email, @Department, @PhotoPath)
                                            End";
            migrationBuilder.Sql(procedureToExecute);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedureToExecute = @"Drop Procedure sp_AddNewEmployee";
            migrationBuilder.Sql(procedureToExecute);
        }
    }
}
