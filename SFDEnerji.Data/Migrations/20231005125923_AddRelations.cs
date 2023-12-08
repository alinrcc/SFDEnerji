using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SFDEnerji.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaPage",
                columns: table => new
                {
                    MetasId = table.Column<int>(type: "int", nullable: false),
                    PagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaPage", x => new { x.MetasId, x.PagesId });
                    table.ForeignKey(
                        name: "FK_MetaPage_Metas_MetasId",
                        column: x => x.MetasId,
                        principalTable: "Metas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaPage_Pages_PagesId",
                        column: x => x.PagesId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaProject",
                columns: table => new
                {
                    MetasId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaProject", x => new { x.MetasId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_MetaProject_Metas_MetasId",
                        column: x => x.MetasId,
                        principalTable: "Metas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaService",
                columns: table => new
                {
                    MetasId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaService", x => new { x.MetasId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_MetaService_Metas_MetasId",
                        column: x => x.MetasId,
                        principalTable: "Metas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaPage_PagesId",
                table: "MetaPage",
                column: "PagesId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaProject_ProjectsId",
                table: "MetaProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaService_ServicesId",
                table: "MetaService",
                column: "ServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaPage");

            migrationBuilder.DropTable(
                name: "MetaProject");

            migrationBuilder.DropTable(
                name: "MetaService");
        }
    }
}
