using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentSystem.Data.Migrations
{
    public partial class AddedUniqueOnAgentPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b62f7cb-301e-4349-a912-3b600bcc1429", "AQAAAAEAACcQAAAAEHpTqdAUSV2xvH6YzNKKde0XD4cdIbhTDLYzMDTHUR9icCGBr5ZKq7nvYagK8EKBog==", "2cbb2bb6-f193-443a-9ef6-5932df1601ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14adb5c4-d59f-4bcf-82b2-6f5fbff6d376", "AQAAAAEAACcQAAAAEKswSNGhDPVZ+nypTVL1dz41iUZpkuX4mA+EOPtKseOO/CIHYl03Fronyp2B3f8uCw==", "61a185bf-6689-4919-b3e3-78a43606fa5c" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

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
        }
    }
}
