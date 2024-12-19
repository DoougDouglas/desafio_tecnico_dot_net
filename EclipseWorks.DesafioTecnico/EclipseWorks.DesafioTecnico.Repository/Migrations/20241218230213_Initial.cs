using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EclipseWorks.DesafioTecnico.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isExcluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isExcluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComentarioTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTarefa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioTarefa_Tarefas_IdTarefa",
                        column: x => x.IdTarefa,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioTarefa_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAlteracaoTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTarefa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DadosAlterados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlteracaoTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracaoTarefa_Tarefas_IdTarefa",
                        column: x => x.IdTarefa,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracaoTarefa_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("013adb5c-e166-4e82-8ab9-971c0496fef0"), new DateTime(2024, 12, 18, 20, 2, 12, 302, DateTimeKind.Local).AddTicks(1218), "user02@teste.com.br", "User 02" },
                    { new Guid("2ab664ec-7e0c-48b0-b6f0-fa241cb377d1"), new DateTime(2024, 12, 18, 20, 2, 12, 299, DateTimeKind.Local).AddTicks(3367), "user01@teste.com.br", "User 01" },
                    { new Guid("5802d09b-8be5-4283-9b07-21b77547666f"), new DateTime(2024, 12, 18, 20, 2, 12, 302, DateTimeKind.Local).AddTicks(1238), "user03@teste.com.br", "User 03" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioTarefa_IdTarefa",
                table: "ComentarioTarefa",
                column: "IdTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioTarefa_IdUsuario",
                table: "ComentarioTarefa",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracaoTarefa_IdTarefa",
                table: "HistoricoAlteracaoTarefa",
                column: "IdTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracaoTarefa_IdUsuario",
                table: "HistoricoAlteracaoTarefa",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdUsuario",
                table: "Projetos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_IdProjeto",
                table: "Tarefas",
                column: "IdProjeto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioTarefa");

            migrationBuilder.DropTable(
                name: "HistoricoAlteracaoTarefa");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
