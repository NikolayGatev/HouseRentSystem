using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentSystem.Data.Migrations
{
    public partial class AddedAllSeedHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ecac055-d7d8-4df8-811b-9650ee35b361", "AQAAAAEAACcQAAAAELEkyUK7N9h8mlZQybnSq0Wb7W4Y5hQ/hj5z4BprQejjuh4cAIZWfGzXDsi4Y211Zw==", "143c231b-2bc4-4119-872e-d7f7cf6234f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96ab1595-dff4-4616-bfe9-8160c895e75a", "AQAAAAEAACcQAAAAECJ0k+D5SmJ3eVZB7W6HBwLOo/cEh7lejOSZfCfVyIHn80t14kgAPZcFKMlVDJbsTw==", "51828d14-c1a1-4605-9d6a-a4137411f3c8" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { 3, "Boyana Neighbourhood, Sofia, Bulgaria", 1, 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "499ec847-1264-4c30-8938-9492592ca79e", "AQAAAAEAACcQAAAAEPXqO41QjFp1UkakBm+MpjcFsNJyyd+qbuRjtwu47HMAdLfdK2Bu0svT44I+r1tZgA==", "a4f00dc4-3b0a-4b52-9a74-e71fb9b16fc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "887082dc-e338-41fe-954f-aede4d0a3e85", "AQAAAAEAACcQAAAAEC9K8Dw+uHqrS4mFDpQk78vv4WrAYasRKFyO1G3dq7jSSo+e8xuWMOycUslD4ZpCSQ==", "a189e91f-744c-4e18-bb12-a3c6372c0749" });
        }
    }
}
