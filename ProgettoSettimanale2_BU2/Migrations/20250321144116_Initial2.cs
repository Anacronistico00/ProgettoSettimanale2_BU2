using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgettoSettimanale2_BU2.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("0653da65-0ef4-4fc0-8e53-f37f46f45c9b"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("070691bd-aa76-48e3-a7e9-f7df09816da2"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("1042ff70-86f4-4934-98bd-a3d9b91baa11"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("2ae45393-2cb0-4959-9708-851dfb067be0"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("48be4bb4-4b98-46e1-8ccd-72e6919fb8d9"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("6072ac5f-22b3-49ad-9b44-b2c89b385a8a"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("80610273-6624-4654-b436-50e42784a5d7"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("86ef79ff-48cf-4bd0-932c-867df9fd14b3"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("aac6e187-4ec9-4071-8a30-718d47c1433c"));

            migrationBuilder.DeleteData(
                table: "Camere",
                keyColumn: "CameraId",
                keyValue: new Guid("f091f315-0408-4994-91b0-762e36f610a1"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_Email",
                table: "Clienti",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clienti_Email",
                table: "Clienti");

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

            migrationBuilder.InsertData(
                table: "Camere",
                columns: new[] { "CameraId", "Disponibile", "Numero", "Prezzo", "TipoId" },
                values: new object[,]
                {
                    { new Guid("0653da65-0ef4-4fc0-8e53-f37f46f45c9b"), true, 101, 80.00m, 1 },
                    { new Guid("070691bd-aa76-48e3-a7e9-f7df09816da2"), true, 104, 180.00m, 4 },
                    { new Guid("1042ff70-86f4-4934-98bd-a3d9b91baa11"), true, 202, 130.00m, 2 },
                    { new Guid("2ae45393-2cb0-4959-9708-851dfb067be0"), true, 102, 120.00m, 2 },
                    { new Guid("48be4bb4-4b98-46e1-8ccd-72e6919fb8d9"), true, 103, 150.00m, 3 },
                    { new Guid("6072ac5f-22b3-49ad-9b44-b2c89b385a8a"), true, 204, 200.00m, 4 },
                    { new Guid("80610273-6624-4654-b436-50e42784a5d7"), true, 201, 85.00m, 1 },
                    { new Guid("86ef79ff-48cf-4bd0-932c-867df9fd14b3"), true, 110, 250.00m, 5 },
                    { new Guid("aac6e187-4ec9-4071-8a30-718d47c1433c"), true, 210, 270.00m, 5 },
                    { new Guid("f091f315-0408-4994-91b0-762e36f610a1"), true, 203, 160.00m, 3 }
                });
        }
    }
}
