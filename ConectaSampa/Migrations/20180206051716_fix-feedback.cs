using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnet.Migrations
{
    public partial class fixfeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "feedbackId",
                table: "usuario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_feedbackId",
                table: "usuario",
                column: "feedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_feedbacks_feedbackId",
                table: "usuario",
                column: "feedbackId",
                principalTable: "feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_feedbacks_feedbackId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_feedbackId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "feedbackId",
                table: "usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "feedbacks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
