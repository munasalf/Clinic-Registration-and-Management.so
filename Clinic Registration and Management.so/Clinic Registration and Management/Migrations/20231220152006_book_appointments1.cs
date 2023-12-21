using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Registration_and_Management.Migrations
{
    public partial class book_appointments1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Patient_PatientIdcard",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_specializations_SpecializationID",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "book_appointments");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_SpecializationID",
                table: "book_appointments",
                newName: "IX_book_appointments_SpecializationID");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientIdcard",
                table: "book_appointments",
                newName: "IX_book_appointments_PatientIdcard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_appointments",
                table: "book_appointments",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_appointments_Patient_PatientIdcard",
                table: "book_appointments",
                column: "PatientIdcard",
                principalTable: "Patient",
                principalColumn: "Idcard",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_appointments_specializations_SpecializationID",
                table: "book_appointments",
                column: "SpecializationID",
                principalTable: "specializations",
                principalColumn: "SpecializationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_appointments_Patient_PatientIdcard",
                table: "book_appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_book_appointments_specializations_SpecializationID",
                table: "book_appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_appointments",
                table: "book_appointments");

            migrationBuilder.RenameTable(
                name: "book_appointments",
                newName: "appointments");

            migrationBuilder.RenameIndex(
                name: "IX_book_appointments_SpecializationID",
                table: "appointments",
                newName: "IX_appointments_SpecializationID");

            migrationBuilder.RenameIndex(
                name: "IX_book_appointments_PatientIdcard",
                table: "appointments",
                newName: "IX_appointments_PatientIdcard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Patient_PatientIdcard",
                table: "appointments",
                column: "PatientIdcard",
                principalTable: "Patient",
                principalColumn: "Idcard",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_specializations_SpecializationID",
                table: "appointments",
                column: "SpecializationID",
                principalTable: "specializations",
                principalColumn: "SpecializationID");
        }
    }
}
