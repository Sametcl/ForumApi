using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class token : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResfreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "ResfreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "934f86a2-1dba-44d4-9312-be16c6b12bed", "AQAAAAIAAYagAAAAEHrnZ/RVIygslcioJobfIyMId3BPyQ2VDpN0o3vlSXdbm2tP8xGCt/SG/XJc7APd9A==", null, null, "c02cac49-f86c-4f97-ba5c-288327991d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "ResfreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "76f12706-9875-46c3-b4bb-06735f422de8", "AQAAAAIAAYagAAAAEF/fczCUQlALomAPucVf3kQ4IP7VZ5RiD8vT7s2EERKuIUKQ1B3VvK2yOx0SVbby1w==", null, null, "fc51c5c5-3a6f-46ab-9afd-8acf18a722f1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("549af326-eab0-4e1b-9422-b399cc24a53d"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 6, 504, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e653dd5a-265b-495f-84d9-5955bb0a7a7d"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 6, 504, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("63e0c121-6ea1-42b1-a6d2-a13a0b698d80"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 10, 14, 6, 505, DateTimeKind.Utc).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("787de76b-a155-4759-9cbd-a630bb7a19dd"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 10, 14, 6, 505, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e020343d-b540-46da-8e65-22c7c01bdf46"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 10, 14, 6, 505, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("188e009b-6406-4142-9928-037701d1c287"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 6, 506, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("810710c9-d2a7-418e-a4a5-48effc80c4df"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 6, 506, DateTimeKind.Local).AddTicks(1379));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResfreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dbbdd60-e5c8-4285-b4ff-76a7a935fcb7", "AQAAAAIAAYagAAAAEO7rbhjPZimZdWq8adPR1DaZimCrR4kIc5nB3VNlZ3RI1hAsWJYxlPqmwRboXM9TXA==", "9196c248-8551-4060-ab2c-1e52ba3e7e33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de7da92-a1a6-4731-834c-4cc9309ff74e", "AQAAAAIAAYagAAAAEFT+y9h+ShRYtCqZbFcjdMbUQ7KV0agxZ5PPTE0Zjl6KCR2FoQVqvVWLDFEE8dANNg==", "2660fd2c-4f14-4b4a-a2d2-3286323625c6" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("549af326-eab0-4e1b-9422-b399cc24a53d"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 19, 48, 24, 567, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e653dd5a-265b-495f-84d9-5955bb0a7a7d"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 19, 48, 24, 567, DateTimeKind.Local).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("63e0c121-6ea1-42b1-a6d2-a13a0b698d80"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 16, 48, 24, 568, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("787de76b-a155-4759-9cbd-a630bb7a19dd"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 16, 48, 24, 568, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e020343d-b540-46da-8e65-22c7c01bdf46"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 16, 48, 24, 568, DateTimeKind.Utc).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("188e009b-6406-4142-9928-037701d1c287"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 19, 48, 24, 568, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("810710c9-d2a7-418e-a4a5-48effc80c4df"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 1, 19, 48, 24, 568, DateTimeKind.Local).AddTicks(5540));
        }
    }
}
