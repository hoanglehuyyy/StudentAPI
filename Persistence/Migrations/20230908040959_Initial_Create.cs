using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_class_id",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.student_id, x.subject_id });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "id", "class_name", "grade" },
                values: new object[,]
                {
                    { 1, "6A", 6 },
                    { 2, "6B", 6 },
                    { 3, "6C", 6 },
                    { 4, "6D", 6 },
                    { 5, "7A", 7 },
                    { 6, "7B", 7 },
                    { 7, "7C", 7 },
                    { 8, "7D", 7 },
                    { 9, "8A", 8 },
                    { 10, "8B", 8 },
                    { 11, "8C", 8 },
                    { 12, "8D", 8 },
                    { 13, "9A", 9 },
                    { 14, "9B", 9 },
                    { 15, "9C", 9 },
                    { 16, "9D", 9 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "id", "subject_code", "subject_name" },
                values: new object[,]
                {
                    { 1, "M001", "Math" },
                    { 2, "L001", "Literature" },
                    { 3, "E001", "English" },
                    { 4, "P001", "Physics" },
                    { 5, "C001", "Chemistry" },
                    { 6, "B001", "Biology" },
                    { 7, "H001", "History" },
                    { 8, "G001", "Geography" },
                    { 9, "CE001", "Civic Education" },
                    { 10, "PE001", "Physical Education" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "address", "birthday", "class_id", "country", "first_name", "last_name", "middle_name", "phone_number" },
                values: new object[,]
                {
                    { 1, "Hoa Lac, Thach That, Ha Noi", new DateTime(2001, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vietnam", "Hoang", "Le", "Huy", "0369473014" },
                    { 2, "Nguyen Trai, Thanh Xuan, Ha Noi", new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vietnam", "Sang", "Nguyen", "Huu", "0987654321" },
                    { 3, "Truong Chinh, Thanh Xuan, Ha Noi", new DateTime(2001, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vietnam", "Quan", "Nguyen", "Tran", "0975328374" },
                    { 4, "Linh Nam, Hoang Mai, Ha Noi", new DateTime(1999, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Vietnam", "Vinh", "Pham", "Xuan", "0982376178" },
                    { 5, "New York", new DateTime(1997, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "United State", "Thi", "Pham", "Viet", "0013829372" },
                    { 6, "California", new DateTime(1996, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "United State", "Hang", "Le", "Thi Thuy", "001984728487" },
                    { 7, "Texas", new DateTime(1995, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "United State", "Hong", "Nguyen", "Thi", "001839265221" },
                    { 8, "Paris", new DateTime(1990, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "France", "Thien", "Vu", "Van", "00339283921793" },
                    { 9, "Lyon", new DateTime(1992, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "France", "Hoc", "Pham", "Van", "00338292729282" },
                    { 10, "HongKong", new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "China", "Nam", "Vu", "Hoai", "011852892023928" },
                    { 11, "Macau", new DateTime(2001, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "China", "Ly", "Dong", "Khanh", "00868093209" },
                    { 12, "Beijing", new DateTime(1998, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "China", "Thao", "Nguyen", "Phuong", "00869382029" },
                    { 13, "Bangkok", new DateTime(1994, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Thailand", "Dao", "Vu", "Thi", "006698230923" }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "student_id", "subject_id", "Mark" },
                values: new object[,]
                {
                    { 1, 1, 9.5f },
                    { 1, 3, 8.25f },
                    { 1, 4, 8.5f },
                    { 2, 1, 9.5f },
                    { 2, 2, 7.5f },
                    { 2, 3, 9f },
                    { 3, 4, 7.5f },
                    { 3, 5, 6.75f },
                    { 4, 6, 5.25f },
                    { 5, 7, 5.75f },
                    { 6, 8, 7f },
                    { 6, 9, 8.75f },
                    { 7, 10, 9.5f },
                    { 8, 1, 10f },
                    { 9, 2, 7.5f },
                    { 10, 3, 8.5f },
                    { 11, 1, 6f },
                    { 12, 5, 7.25f },
                    { 13, 6, 8f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_class_id",
                table: "Students",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_subject_id",
                table: "StudentSubjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_subject_code",
                table: "Subjects",
                column: "subject_code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
