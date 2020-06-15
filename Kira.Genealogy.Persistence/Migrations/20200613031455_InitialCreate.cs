using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kira.Genealogy.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FirstFamilyName = table.Column<string>(maxLength: 100, nullable: false),
                    SecondFamilyName = table.Column<string>(maxLength: 100, nullable: true),
                    UserOwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FirstFamilyName = table.Column<string>(maxLength: 100, nullable: false),
                    SecondFamilyName = table.Column<string>(maxLength: 100, nullable: true),
                    TreeId = table.Column<Guid>(nullable: false),
                    ParentBranchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    FirstFamilyName = table.Column<string>(maxLength: 100, nullable: false),
                    SecondFamilyName = table.Column<string>(maxLength: 100, nullable: true),
                    BornDate = table.Column<DateTime>(nullable: true),
                    IsBornDateExactly = table.Column<bool>(nullable: true),
                    IsAlive = table.Column<bool>(nullable: false),
                    DeathDate = table.Column<DateTime>(nullable: true),
                    IsDeathDateExactly = table.Column<bool>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SharePhone = table.Column<bool>(nullable: false),
                    MailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    ShareMailAddress = table.Column<bool>(nullable: false),
                    BornCity = table.Column<string>(maxLength: 200, nullable: false),
                    IsBornCityExactly = table.Column<bool>(nullable: false),
                    TreeId = table.Column<Guid>(nullable: false),
                    PersonalImage = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    NodeType = table.Column<int>(nullable: false),
                    NodeParentId = table.Column<int>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true),
                    MatePersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_People_MatePersonId",
                        column: x => x.MatePersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_NodeParentId",
                        column: x => x.NodeParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_TreeId",
                table: "Branches",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_MatePersonId",
                table: "Nodes",
                column: "MatePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeParentId",
                table: "Nodes",
                column: "NodeParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_PersonId",
                table: "Nodes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_TreeId",
                table: "People",
                column: "TreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Trees");
        }
    }
}
