using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StamotologicClinic.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    IDAdress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Locality = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    House = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.IDAdress);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IDCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IDCategory);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    IDPosition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.IDPosition);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IDPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDAdress = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Sex = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    InsuranceCompany = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MHIPolicy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IDPatient);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses",
                        column: x => x.IDAdress,
                        principalTable: "Addresses",
                        principalColumn: "IDAdress");
                });

            migrationBuilder.CreateTable(
                name: "TypeServices",
                columns: table => new
                {
                    IDService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCategory = table.Column<int>(type: "int", nullable: true),
                    DescriptionService = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServices", x => x.IDService);
                    table.ForeignKey(
                        name: "FK_TypeServices_Categories",
                        column: x => x.IDCategory,
                        principalTable: "Categories",
                        principalColumn: "IDCategory");
                });

            migrationBuilder.CreateTable(
                name: "MedicalPersonnels",
                columns: table => new
                {
                    IDMedicalPersonnel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPosition = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPersonnels", x => x.IDMedicalPersonnel);
                    table.ForeignKey(
                        name: "FK_MedicalPersonnels_Positions",
                        column: x => x.IDPosition,
                        principalTable: "Positions",
                        principalColumn: "IDPosition");
                });

            migrationBuilder.CreateTable(
                name: "PriceHistory",
                columns: table => new
                {
                    IDChanges = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDService = table.Column<int>(type: "int", nullable: true),
                    NewPrices = table.Column<decimal>(type: "money", nullable: true),
                    OldPrices = table.Column<decimal>(type: "money", nullable: true),
                    DateChange = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistory", x => x.IDChanges);
                    table.ForeignKey(
                        name: "FK_PriceHistory_TypeServices",
                        column: x => x.IDService,
                        principalTable: "TypeServices",
                        principalColumn: "IDService");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IDAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMedicalPersonnel = table.Column<int>(type: "int", nullable: true),
                    Login = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_1", x => x.IDAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_MedicalPersonnels",
                        column: x => x.IDMedicalPersonnel,
                        principalTable: "MedicalPersonnels",
                        principalColumn: "IDMedicalPersonnel");
                });

            migrationBuilder.CreateTable(
                name: "RecordHistory",
                columns: table => new
                {
                    IDRecord = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMedicalPersonal = table.Column<int>(type: "int", nullable: true),
                    IDPatient = table.Column<int>(type: "int", nullable: true),
                    IDService = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "date", nullable: true),
                    DateСompletion = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordHistory", x => x.IDRecord);
                    table.ForeignKey(
                        name: "FK_RecordHistory_MedicalPersonnels",
                        column: x => x.IDMedicalPersonal,
                        principalTable: "MedicalPersonnels",
                        principalColumn: "IDMedicalPersonnel");
                    table.ForeignKey(
                        name: "FK_RecordHistory_Patients",
                        column: x => x.IDPatient,
                        principalTable: "Patients",
                        principalColumn: "IDPatient");
                    table.ForeignKey(
                        name: "FK_RecordHistory_TypeServices",
                        column: x => x.IDService,
                        principalTable: "TypeServices",
                        principalColumn: "IDService");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts",
                table: "Accounts",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IDMedicalPersonnel",
                table: "Accounts",
                column: "IDMedicalPersonnel");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPersonnels_IDPosition",
                table: "MedicalPersonnels",
                column: "IDPosition");

            migrationBuilder.CreateIndex(
                name: "IX_Patients",
                table: "Patients",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_1",
                table: "Patients",
                column: "MHIPolicy",
                unique: true,
                filter: "[MHIPolicy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IDAdress",
                table: "Patients",
                column: "IDAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Positions",
                table: "Positions",
                column: "Position",
                unique: true,
                filter: "[Position] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistory_IDService",
                table: "PriceHistory",
                column: "IDService");

            migrationBuilder.CreateIndex(
                name: "IX_RecordHistory_IDMedicalPersonal",
                table: "RecordHistory",
                column: "IDMedicalPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_RecordHistory_IDPatient",
                table: "RecordHistory",
                column: "IDPatient");

            migrationBuilder.CreateIndex(
                name: "IX_RecordHistory_IDService",
                table: "RecordHistory",
                column: "IDService");

            migrationBuilder.CreateIndex(
                name: "IX_TypeServices_IDCategory",
                table: "TypeServices",
                column: "IDCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "PriceHistory");

            migrationBuilder.DropTable(
                name: "RecordHistory");

            migrationBuilder.DropTable(
                name: "MedicalPersonnels");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "TypeServices");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
