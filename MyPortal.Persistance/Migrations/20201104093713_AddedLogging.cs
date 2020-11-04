﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortal.Persistance.Migrations
{
    public partial class AddedLogging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    MessageTemplate = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logging", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logging");
        }
    }
}
