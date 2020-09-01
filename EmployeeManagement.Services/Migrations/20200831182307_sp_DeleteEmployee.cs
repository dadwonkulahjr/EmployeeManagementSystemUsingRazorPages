using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Services.Migrations
{
    public partial class sp_DeleteEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure sp_DeleteEmployee
                                    @Id int
                                    as
                                    Begin
	                                    Delete From Employees Where Id = @Id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Delete Procedure sp_DeleteEmployee";
            migrationBuilder.Sql(procedure);
        }
    }
}
