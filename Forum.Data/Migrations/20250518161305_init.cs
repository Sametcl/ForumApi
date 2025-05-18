using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("549af326-eab0-4e1b-9422-b399cc24a53d"), new DateTime(2025, 5, 18, 19, 13, 4, 72, DateTimeKind.Local).AddTicks(610), "Oyun" },
                    { new Guid("e653dd5a-265b-495f-84d9-5955bb0a7a7d"), new DateTime(2025, 5, 18, 19, 13, 4, 72, DateTimeKind.Local).AddTicks(600), "Bilgisayar" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("188e009b-6406-4142-9928-037701d1c287"), new Guid("e653dd5a-265b-495f-84d9-5955bb0a7a7d"), "Etiam id velit feugiat, scelerisque velit a, scelerisque nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer dignissim risus non nibh scelerisque, sit amet tincidunt sapien rutrum.Integer a ipsum vitae urna varius egestas. Integer laoreet, sapien eget vehicula vehicula, odio lorem scelerisque magna, nec gravida libero nulla eget risus. Nulla facilisi. Donec at magna ut nulla pharetra cursus. Curabitur auctor, tellus in congue vestibulum, lacus lacus convallis justo, at fermentum libero felis nec ligula.Phasellus ac eros at urna condimentum lacinia. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed bibendum, sapien a venenatis fermentum, mauris augue cursus turpis, vitae elementum massa orci sit amet massa. In hac habitasse platea dictumst.", new DateTime(2025, 5, 18, 19, 13, 4, 72, DateTimeKind.Local).AddTicks(5844), "Amd Ryzen 4 vs Intel i5 11000h karsilastirmasi" },
                    { new Guid("810710c9-d2a7-418e-a4a5-48effc80c4df"), new Guid("549af326-eab0-4e1b-9422-b399cc24a53d"), "Etiam id velit feugiat, scelerisque velit a, scelerisque nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer dignissim risus non nibh scelerisque, sit amet tincidunt sapien rutrum.Integer a ipsum vitae urna varius egestas. Integer laoreet, sapien eget vehicula vehicula, odio lorem scelerisque magna, nec gravida libero nulla eget risus. Nulla facilisi. Donec at magna ut nulla pharetra cursus. Curabitur auctor, tellus in congue vestibulum, lacus lacus convallis justo, at fermentum libero felis nec ligula.Phasellus ac eros at urna condimentum lacinia. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed bibendum, sapien a venenatis fermentum, mauris augue cursus turpis, vitae elementum massa orci sit amet massa. In hac habitasse platea dictumst.", new DateTime(2025, 5, 18, 19, 13, 4, 72, DateTimeKind.Local).AddTicks(5854), "RDR2 vs GOW" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "PostId" },
                values: new object[,]
                {
                    { new Guid("63e0c121-6ea1-42b1-a6d2-a13a0b698d80"), "Hikaye bakimindan GOW acik dunya bakimindan RDR2 daha iyi bence", new DateTime(2025, 5, 18, 16, 13, 4, 72, DateTimeKind.Utc).AddTicks(3298), new Guid("810710c9-d2a7-418e-a4a5-48effc80c4df") },
                    { new Guid("787de76b-a155-4759-9cbd-a630bb7a19dd"), "Ryzen benchmark testlerinde daha ustun gozukuyor", new DateTime(2025, 5, 18, 16, 13, 4, 72, DateTimeKind.Utc).AddTicks(3296), new Guid("188e009b-6406-4142-9928-037701d1c287") },
                    { new Guid("e020343d-b540-46da-8e65-22c7c01bdf46"), "Ryzen performans acisindan daha iyi diye biliyorum", new DateTime(2025, 5, 18, 16, 13, 4, 72, DateTimeKind.Utc).AddTicks(3292), new Guid("188e009b-6406-4142-9928-037701d1c287") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
