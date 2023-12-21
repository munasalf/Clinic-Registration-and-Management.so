using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Registration_and_Management.Migrations
{
    public partial class a_medical_specialization1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Idcard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Idcard);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Detiles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializations", x => x.SpecializationID);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appointment_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idcard = table.Column<int>(type: "int", nullable: false),
                    PatientIdcard = table.Column<int>(type: "int", nullable: false),
                    SpecializationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_appointments_Patient_PatientIdcard",
                        column: x => x.PatientIdcard,
                        principalTable: "Patient",
                        principalColumn: "Idcard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_specializations_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "specializations",
                        principalColumn: "SpecializationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientIdcard",
                table: "appointments",
                column: "PatientIdcard");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_SpecializationID",
                table: "appointments",
                column: "SpecializationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "specializations");
        }
    }
}
