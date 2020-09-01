using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Services.Migrations
{
    public partial class sp_UpdateEmployeeInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure sp_UpdateEmployeeInformation
                                    @Id int,
                                    @Name nvarchar(100),
                                    @Email nvarchar(100),
                                    @Department nvarchar(100),
                                    @PhotoPath nvarchar(100)
                                    as
                                    Begin
                                        Update Employees set[Name] = @Name, [Email] = @Email,
	                                    [Department] = @Department, [PhotoPath] = @PhotoPath

                                        Where[Id] = @Id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Delete Procedure sp_UpdateEmployeeInformation";
            migrationBuilder.Sql(procedure);
        }
    }
}
