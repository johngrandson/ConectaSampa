using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnet.Migrations
{
    public partial class usuarioclass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_Endereco_enderecoId",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "endereco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_endereco",
                table: "endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_endereco_enderecoId",
                table: "usuario",
                column: "enderecoId",
                principalTable: "endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_endereco_enderecoId",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_endereco",
                table: "endereco");

            migrationBuilder.RenameTable(
                name: "endereco",
                newName: "Endereco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_Endereco_enderecoId",
                table: "usuario",
                column: "enderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
