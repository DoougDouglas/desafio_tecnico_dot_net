using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EclipseWorks.DesafioTecnico.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("013adb5c-e166-4e82-8ab9-971c0496fef0"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("2ab664ec-7e0c-48b0-b6f0-fa241cb377d1"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("5802d09b-8be5-4283-9b07-21b77547666f"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("b0a78f71-3d48-4cb0-8ad4-6eab17445928"), new DateTime(2024, 12, 18, 20, 29, 43, 670, DateTimeKind.Local).AddTicks(7188), "user01@teste.com.br", "User 01" },
                    { new Guid("b789be54-56d9-411e-927e-3431a10ef9fd"), new DateTime(2024, 12, 18, 20, 29, 43, 673, DateTimeKind.Local).AddTicks(6865), "user02@teste.com.br", "User 02" },
                    { new Guid("fe630df3-197b-4aa5-b6fd-55e34cb20d54"), new DateTime(2024, 12, 18, 20, 29, 43, 673, DateTimeKind.Local).AddTicks(6886), "user03@teste.com.br", "User 03" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("b0a78f71-3d48-4cb0-8ad4-6eab17445928"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("b789be54-56d9-411e-927e-3431a10ef9fd"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("fe630df3-197b-4aa5-b6fd-55e34cb20d54"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("013adb5c-e166-4e82-8ab9-971c0496fef0"), new DateTime(2024, 12, 18, 20, 2, 12, 302, DateTimeKind.Local).AddTicks(1218), "user02@teste.com.br", "User 02" },
                    { new Guid("2ab664ec-7e0c-48b0-b6f0-fa241cb377d1"), new DateTime(2024, 12, 18, 20, 2, 12, 299, DateTimeKind.Local).AddTicks(3367), "user01@teste.com.br", "User 01" },
                    { new Guid("5802d09b-8be5-4283-9b07-21b77547666f"), new DateTime(2024, 12, 18, 20, 2, 12, 302, DateTimeKind.Local).AddTicks(1238), "user03@teste.com.br", "User 03" }
                });
        }
    }
}
