using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnet.Migrations
{
    public partial class eraseendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_endereco_enderecoId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_feedbacks_feedbackId",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropIndex(
                name: "IX_usuario_enderecoId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_feedbackId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "enderecoId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "feedbackId",
                table: "usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "enderecoId",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "feedbackId",
                table: "usuario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<int>(nullable: false),
                    rua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_enderecoId",
                table: "usuario",
                column: "enderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_feedbackId",
                table: "usuario",
                column: "feedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_endereco_enderecoId",
                table: "usuario",
                column: "enderecoId",
                principalTable: "endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_feedbacks_feedbackId",
                table: "usuario",
                column: "feedbackId",
                principalTable: "feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
