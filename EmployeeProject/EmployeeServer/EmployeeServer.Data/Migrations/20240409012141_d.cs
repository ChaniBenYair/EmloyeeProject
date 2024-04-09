using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEmployee_Job_JobNameId",
                table: "JobEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeJobEmployee");

            migrationBuilder.RenameColumn(
                name: "JobNameId",
                table: "JobEmployee",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobEmployee_JobNameId",
                table: "JobEmployee",
                newName: "IX_JobEmployee_JobId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "JobEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobEmployee_EmployeeId",
                table: "JobEmployee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEmployee_Employee_EmployeeId",
                table: "JobEmployee",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEmployee_Job_JobId",
                table: "JobEmployee",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEmployee_Employee_EmployeeId",
                table: "JobEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEmployee_Job_JobId",
                table: "JobEmployee");

            migrationBuilder.DropIndex(
                name: "IX_JobEmployee_EmployeeId",
                table: "JobEmployee");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "JobEmployee");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "JobEmployee",
                newName: "JobNameId");

            migrationBuilder.RenameIndex(
                name: "IX_JobEmployee_JobId",
                table: "JobEmployee",
                newName: "IX_JobEmployee_JobNameId");

            migrationBuilder.CreateTable(
                name: "EmployeeJobEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobEmployee", x => new { x.EmployeeId, x.JobId });
                    table.ForeignKey(
                        name: "FK_EmployeeJobEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobEmployee_JobEmployee_JobId",
                        column: x => x.JobId,
                        principalTable: "JobEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobEmployee_JobId",
                table: "EmployeeJobEmployee",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEmployee_Job_JobNameId",
                table: "JobEmployee",
                column: "JobNameId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
