using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalk.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("34b56837-4104-43e4-bcb5-ab2ab5e6b424"), "Easy" },
                    { new Guid("6eba8810-fad6-48cb-831f-4b15eb8cdb01"), "Hard" },
                    { new Guid("d155aa16-86c0-4e19-b81d-c6ca6efdde5c"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3965a7a3-1cba-4458-b987-87ce6d751394"), "GIS", "Gisborne", "https://images.pexels.com/photos/21047861/pexels-photo-21047861.jpeg" },
                    { new Guid("5f2deb33-3e15-4e1c-9056-d11323c706bc"), "HB", "Hawke's Bay", null },
                    { new Guid("84a16444-bbf4-4c22-a52f-5c64db3e6281"), "BOP", "Bay of Plenty", null },
                    { new Guid("b6103648-e840-4c25-8726-03b3e1067eea"), "AKL", "Auckland", "https://images.pexels.com/photos/16575451/pexels-photo-16575451.jpeg" },
                    { new Guid("c1fc4257-1a53-4bc6-aa2b-3d3d3a7d463b"), "WKO", "Waikato", "https://images.pexels.com/photos/27105121/pexels-photo-27105121.jpeg" },
                    { new Guid("dd669a58-5c7e-4a1a-8f98-6daa9ba31eea"), "NL", "Northland", "https://images.pexels.com/photos/32947398/pexels-photo-32947398.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("34b56837-4104-43e4-bcb5-ab2ab5e6b424"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6eba8810-fad6-48cb-831f-4b15eb8cdb01"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d155aa16-86c0-4e19-b81d-c6ca6efdde5c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3965a7a3-1cba-4458-b987-87ce6d751394"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5f2deb33-3e15-4e1c-9056-d11323c706bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a16444-bbf4-4c22-a52f-5c64db3e6281"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b6103648-e840-4c25-8726-03b3e1067eea"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c1fc4257-1a53-4bc6-aa2b-3d3d3a7d463b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dd669a58-5c7e-4a1a-8f98-6daa9ba31eea"));
        }
    }
}
