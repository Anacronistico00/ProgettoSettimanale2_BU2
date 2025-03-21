using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgettoSettimanale2_BU2.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeletingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clienti_AspNetUsers_UserId",
                table: "Clienti");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_CameraId",
                table: "Prenotazioni");

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("11062b08-b3b2-4499-8137-c27ed65008b2"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("34f9af4e-1fd5-49b0-974c-d7020f10348d"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("3942467f-4ca6-4495-8478-ab5a0e9ec5f0"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("48ac8568-b949-4811-a031-370b4aedab43"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("4d54c58b-19aa-4785-8e16-ffa2b4b2663d"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("6486ac09-88e2-46c2-a203-85b6526622a1"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("862882f3-cec8-4adb-822b-a65ff7c746cf"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("b679bd23-454c-4f11-af89-b283d1f4bd5f"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("bf18341d-4270-418b-8fb2-7adb52b9719c"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("ca5c05f8-9f18-4f4c-a1d0-75edb4e56d59"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Camere",
                columns: new[] { "CameraId", "Disponibile", "Numero", "Prezzo", "TipoId" },
                values: new object[,]
                {
                    { new Guid("377b5333-be79-4d52-a598-f4ed34c10199"), true, 210, 270.00m, 5 },
                    { new Guid("3daff5a6-f522-4178-a4dd-472a059cdb88"), true, 102, 120.00m, 2 },
                    { new Guid("3eb1188b-5d29-465d-9f04-05d8f4d2522c"), true, 203, 160.00m, 3 },
                    { new Guid("4e57b07b-0ec7-4a2b-b891-712b9a80aa0d"), true, 204, 200.00m, 4 },
                    { new Guid("701177d0-11ba-47b3-a694-b178da434313"), true, 103, 150.00m, 3 },
                    { new Guid("840a0b41-450d-472b-b05b-8c54b518556e"), true, 202, 130.00m, 2 },
                    { new Guid("87668d7d-ffc9-477e-afdd-47f97d5933df"), true, 110, 250.00m, 5 },
                    { new Guid("99b63e82-0fe9-4ad1-9e03-0b7eaba0f83f"), true, 104, 180.00m, 4 },
                    { new Guid("9e311e9e-fc5b-4ba1-bb8b-97c6418ea66c"), true, 101, 80.00m, 1 },
                    { new Guid("f38628f3-6483-41ac-b62f-ba78ba3a03ba"), true, 201, 85.00m, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clienti_AspNetUsers_UserId",
                table: "Clienti",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_CameraId",
                table: "Prenotazioni",
                column: "CameraId",
                principalTable: "Camere",
                principalColumn: "CameraId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clienti_AspNetUsers_UserId",
                table: "Clienti");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_CameraId",
                table: "Prenotazioni");

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("377b5333-be79-4d52-a598-f4ed34c10199"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("3daff5a6-f522-4178-a4dd-472a059cdb88"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("3eb1188b-5d29-465d-9f04-05d8f4d2522c"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("4e57b07b-0ec7-4a2b-b891-712b9a80aa0d"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("701177d0-11ba-47b3-a694-b178da434313"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("840a0b41-450d-472b-b05b-8c54b518556e"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("87668d7d-ffc9-477e-afdd-47f97d5933df"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("99b63e82-0fe9-4ad1-9e03-0b7eaba0f83f"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("9e311e9e-fc5b-4ba1-bb8b-97c6418ea66c"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("f38628f3-6483-41ac-b62f-ba78ba3a03ba"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Camere",
                columns: new[] { "CameraId", "Disponibile", "Numero", "Prezzo", "TipoId" },
                values: new object[,]
                {
                    { new Guid("11062b08-b3b2-4499-8137-c27ed65008b2"), true, 201, 85.00m, 1 },
                    { new Guid("34f9af4e-1fd5-49b0-974c-d7020f10348d"), true, 202, 130.00m, 2 },
                    { new Guid("3942467f-4ca6-4495-8478-ab5a0e9ec5f0"), true, 204, 200.00m, 4 },
                    { new Guid("48ac8568-b949-4811-a031-370b4aedab43"), true, 103, 150.00m, 3 },
                    { new Guid("4d54c58b-19aa-4785-8e16-ffa2b4b2663d"), true, 203, 160.00m, 3 },
                    { new Guid("6486ac09-88e2-46c2-a203-85b6526622a1"), true, 102, 120.00m, 2 },
                    { new Guid("862882f3-cec8-4adb-822b-a65ff7c746cf"), true, 110, 250.00m, 5 },
                    { new Guid("b679bd23-454c-4f11-af89-b283d1f4bd5f"), true, 104, 180.00m, 4 },
                    { new Guid("bf18341d-4270-418b-8fb2-7adb52b9719c"), true, 101, 80.00m, 1 },
                    { new Guid("ca5c05f8-9f18-4f4c-a1d0-75edb4e56d59"), true, 210, 270.00m, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clienti_AspNetUsers_UserId",
                table: "Clienti",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_CameraId",
                table: "Prenotazioni",
                column: "CameraId",
                principalTable: "Camere",
                principalColumn: "CameraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
