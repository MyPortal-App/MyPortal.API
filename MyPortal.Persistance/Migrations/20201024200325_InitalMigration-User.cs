using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortal.Persistance.Migrations
{
    public partial class InitalMigrationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    SalaryLevel = table.Column<int>(nullable: false),
                    ChiefDirectorate = table.Column<string>(nullable: true),
                    Directorate = table.Column<string>(nullable: true),
                    SubDirectorate = table.Column<string>(nullable: true),
                    OfficeLocation = table.Column<string>(nullable: true),
                    ContactNumberOffice = table.Column<string>(nullable: true),
                    ContactCell = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<string>(nullable: true),
                    ProbationPeriodstatus = table.Column<string>(nullable: true),
                    InductionStatus = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    Highestqualification = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    Maritalstatus = table.Column<string>(nullable: true),
                    SpouseName = table.Column<string>(nullable: true),
                    SpouseMaidenName = table.Column<string>(nullable: true),
                    NextofKinName = table.Column<string>(nullable: true),
                    NextofKinSurname = table.Column<string>(nullable: true),
                    NextofKinRelation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
