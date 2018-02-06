using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnet.Migrations
{
    public partial class addingSensorAndHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sensores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<int>(nullable: false),
                    veiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sensores_veiculos_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historicoSensores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    sensorId = table.Column<int>(nullable: true),
                    valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicoSensores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historicoSensores_sensores_sensorId",
                        column: x => x.sensorId,
                        principalTable: "sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historicoSensores_sensorId",
                table: "historicoSensores",
                column: "sensorId");

            migrationBuilder.CreateIndex(
                name: "IX_sensores_veiculoId",
                table: "sensores",
                column: "veiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicoSensores");

            migrationBuilder.DropTable(
                name: "sensores");
        }
    }
}
