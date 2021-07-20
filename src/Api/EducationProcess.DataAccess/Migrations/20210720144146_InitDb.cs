using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationProcess.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academic_years",
                columns: table => new
                {
                    Academic_year_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Begining_year = table.Column<short>(type: "smallint", nullable: false),
                    Ending_year = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academic_years", x => x.Academic_year_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Audience_types",
                columns: table => new
                {
                    Audience_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience_types", x => x.Audience_type_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Cathedras",
                columns: table => new
                {
                    Cathedra_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false, collation: "Utf8_General_Ci"),
                    Name_abbreviation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "Utf8_General_Ci"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cathedras", x => x.Cathedra_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Education_cycles_and_modules",
                columns: table => new
                {
                    Education_cycle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Education_cycle_index = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "Utf8_General_Ci"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false, collation: "Utf8_General_Ci"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "Utf8_General_Ci"),
                    Education_cycle_parent_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_cycles_and_modules", x => x.Education_cycle_id);
                    table.ForeignKey(
                        name: "FK_Education_cycles_and_modules_Education_cycles_and_modules",
                        column: x => x.Education_cycle_parent_id,
                        principalTable: "Education_cycles_and_modules",
                        principalColumn: "Education_cycle_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Education_forms",
                columns: table => new
                {
                    Education_form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_forms", x => x.Education_form_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Education_levels",
                columns: table => new
                {
                    Education_level_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_levels", x => x.Education_level_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Federal_state_educational_standards",
                columns: table => new
                {
                    Fses_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federal_state_educational_standards", x => x.Fses_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Intermediate_certification_forms",
                columns: table => new
                {
                    Certification_form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermediate_certification_forms", x => x.Certification_form_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Lesson_types",
                columns: table => new
                {
                    Lesson_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(65)", maxLength: 65, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson_types", x => x.Lesson_type_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Post_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Semester_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Weeks_count = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Semester_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Specialtie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Specialtie_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "Utf8_General_Ci"),
                    Implemented_specialty_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci"),
                    Abbreviation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Specialtie_id);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Discipline_index = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "Utf8_General_Ci"),
                    Cathedra_id = table.Column<int>(type: "int", nullable: true),
                    Education_cycle_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false, collation: "Utf8_General_Ci"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "Utf8_General_Ci"),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Discipline_id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Cathedras",
                        column: x => x.Cathedra_id,
                        principalTable: "Cathedras",
                        principalColumn: "Cathedra_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplines_Education_cycles_and_modules",
                        column: x => x.Education_cycle_id,
                        principalTable: "Education_cycles_and_modules",
                        principalColumn: "Education_cycle_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Received_education_forms",
                columns: table => new
                {
                    Received_education_form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Education_form_id = table.Column<int>(type: "int", nullable: false),
                    Additional_info = table.Column<string>(type: "varchar(65)", maxLength: 65, nullable: true, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Received_education_forms", x => x.Received_education_form_id);
                    table.ForeignKey(
                        name: "FK_Received_education_forms_Education_forms",
                        column: x => x.Education_form_id,
                        principalTable: "Education_forms",
                        principalColumn: "Education_form_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Fses_categories",
                columns: table => new
                {
                    Fses_category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "Utf8_General_Ci"),
                    Fses_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fses_categories", x => x.Fses_category_id);
                    table.ForeignKey(
                        name: "FK_Fses_categories_Federal_state_educational_standards",
                        column: x => x.Fses_id,
                        principalTable: "Federal_state_educational_standards",
                        principalColumn: "Fses_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci"),
                    Lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci"),
                    Middlename = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "Utf8_General_Ci"),
                    Post_id = table.Column<int>(type: "int", nullable: false),
                    Rowguid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Posts",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Post_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Semester_disciplines",
                columns: table => new
                {
                    Semester_discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Discipline_id = table.Column<int>(type: "int", nullable: false),
                    Theory_lesson_hours = table.Column<short>(type: "smallint", nullable: false),
                    Practice_work_hours = table.Column<short>(type: "smallint", nullable: false),
                    Laboratory_work_hours = table.Column<short>(type: "smallint", nullable: false),
                    Control_work_hours = table.Column<short>(type: "smallint", nullable: false),
                    Independent_work_hours = table.Column<short>(type: "smallint", nullable: false),
                    Consultation_hours = table.Column<short>(type: "smallint", nullable: false),
                    Exam_hours = table.Column<short>(type: "smallint", nullable: false),
                    Educational_practice_hours = table.Column<short>(type: "smallint", nullable: false),
                    Production_practice_hours = table.Column<short>(type: "smallint", nullable: false),
                    Certification_form_id = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester_disciplines", x => x.Semester_discipline_id);
                    table.ForeignKey(
                        name: "FK_Semester_disciplines_Intermediate_certification_forms",
                        column: x => x.Certification_form_id,
                        principalTable: "Intermediate_certification_forms",
                        principalColumn: "Certification_form_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Semesters_Disciplines_Disciplines",
                        column: x => x.Discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "Discipline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Semesters_Disciplines_Semesters",
                        column: x => x.Semester_id,
                        principalTable: "Semesters",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Fses_category_partitions",
                columns: table => new
                {
                    Fses_category_patition_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_part_number = table.Column<int>(type: "int", nullable: false),
                    Second_part_number = table.Column<int>(type: "int", nullable: false),
                    Third_path_number = table.Column<short>(type: "smallint", nullable: true),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "Utf8_General_Ci"),
                    Name_abbreviation = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "Utf8_General_Ci"),
                    Fses_category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fses_category_partitions", x => x.Fses_category_patition_id);
                    table.ForeignKey(
                        name: "FK_Fses_category_partitions_Fses_categories",
                        column: x => x.Fses_category_id,
                        principalTable: "Fses_categories",
                        principalColumn: "Fses_category_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Audiences",
                columns: table => new
                {
                    Audience_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(65)", maxLength: 65, nullable: true, collation: "Utf8_General_Ci"),
                    Number = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "Utf8_General_Ci"),
                    Employee_head_id = table.Column<int>(type: "int", nullable: true),
                    Audience_type_id = table.Column<int>(type: "int", nullable: true),
                    Seats_count = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiences", x => x.Audience_id);
                    table.ForeignKey(
                        name: "FK_Audiences_Audience_types",
                        column: x => x.Audience_type_id,
                        principalTable: "Audience_types",
                        principalColumn: "Audience_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audiences_Employees",
                        column: x => x.Employee_head_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Employee_cathedras",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Cathedra_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_cathedras", x => new { x.Employee_id, x.Cathedra_id });
                    table.ForeignKey(
                        name: "FK_Employee_cathedras_Cathedras",
                        column: x => x.Cathedra_id,
                        principalTable: "Cathedras",
                        principalColumn: "Cathedra_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_cathedras_Employees",
                        column: x => x.Employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Cathedra_specialties",
                columns: table => new
                {
                    Cathedra_id = table.Column<int>(type: "int", nullable: false),
                    Fses_category_patition_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cathedra_specialties", x => new { x.Cathedra_id, x.Fses_category_patition_id });
                    table.ForeignKey(
                        name: "FK_Cathedra_specialties_Cathedras",
                        column: x => x.Cathedra_id,
                        principalTable: "Cathedras",
                        principalColumn: "Cathedra_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cathedra_specialties_Fses_category_partitions",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Fses_category_partitions",
                        principalColumn: "Fses_category_patition_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cathedra_specialties_Specialties",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Specialties",
                        principalColumn: "Specialtie_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Education_plans",
                columns: table => new
                {
                    Education_plan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fses_category_patition_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(65)", maxLength: 65, nullable: false, collation: "Utf8_General_Ci"),
                    Academic_year_id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "Utf8_General_Ci"),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_plans", x => x.Education_plan_id);
                    table.ForeignKey(
                        name: "FK_Education_plans_Academic_years",
                        column: x => x.Academic_year_id,
                        principalTable: "Academic_years",
                        principalColumn: "Academic_year_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_plans_Fses_category_partitions",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Fses_category_partitions",
                        principalColumn: "Fses_category_patition_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_plans_Specialties",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Specialties",
                        principalColumn: "Specialtie_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Received_specialties",
                columns: table => new
                {
                    Received_specialty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fses_category_patition_id = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Utf8_General_Ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Received_specialties", x => x.Received_specialty_id);
                    table.ForeignKey(
                        name: "FK_Received_specialties_Fses_category_partitions",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Fses_category_partitions",
                        principalColumn: "Fses_category_patition_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Received_specialties_Specialties",
                        column: x => x.Fses_category_patition_id,
                        principalTable: "Specialties",
                        principalColumn: "Specialtie_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Education_plan_semester_disciplines",
                columns: table => new
                {
                    Education_plan_id = table.Column<int>(type: "int", nullable: false),
                    Semester_discipline_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_plan_semester_disciplines", x => new { x.Education_plan_id, x.Semester_discipline_id });
                    table.ForeignKey(
                        name: "FK_Education_plan_semester_disciplines_Education_plans",
                        column: x => x.Education_plan_id,
                        principalTable: "Education_plans",
                        principalColumn: "Education_plan_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_plan_semester_disciplines_Semester_disciplines",
                        column: x => x.Semester_discipline_id,
                        principalTable: "Semester_disciplines",
                        principalColumn: "Semester_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Received_educations",
                columns: table => new
                {
                    Received_education_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Received_specialty_id = table.Column<int>(type: "int", nullable: false),
                    Received_education_form_id = table.Column<int>(type: "int", nullable: false),
                    Education_level_id = table.Column<int>(type: "int", nullable: false),
                    Study_period_months = table.Column<short>(type: "smallint", nullable: false),
                    Is_budget = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Received_educations", x => x.Received_education_id);
                    table.ForeignKey(
                        name: "FK_Received_educations_Education_levels",
                        column: x => x.Education_level_id,
                        principalTable: "Education_levels",
                        principalColumn: "Education_level_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Received_educations_Received_education_forms",
                        column: x => x.Received_education_form_id,
                        principalTable: "Received_education_forms",
                        principalColumn: "Received_education_form_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Received_educations_Received_specialties",
                        column: x => x.Received_specialty_id,
                        principalTable: "Received_specialties",
                        principalColumn: "Received_specialty_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "Utf8_General_Ci"),
                    Course_number = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Curator_id = table.Column<int>(type: "int", nullable: false),
                    Received_education_id = table.Column<int>(type: "int", nullable: false),
                    Education_plan_id = table.Column<int>(type: "int", nullable: true),
                    Receipt_year = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Group_id);
                    table.ForeignKey(
                        name: "FK_Groups_Education_plans",
                        column: x => x.Education_plan_id,
                        principalTable: "Education_plans",
                        principalColumn: "Education_plan_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Employees",
                        column: x => x.Curator_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Received_educations",
                        column: x => x.Received_education_id,
                        principalTable: "Received_educations",
                        principalColumn: "Received_education_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Fixed_disciplines",
                columns: table => new
                {
                    Fixed_discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fixing_employee_id = table.Column<int>(type: "int", nullable: false),
                    Semester_discipline_id = table.Column<int>(type: "int", nullable: false),
                    Group_id = table.Column<int>(type: "int", nullable: false),
                    Is_agreed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Fixer_employee_id = table.Column<int>(type: "int", nullable: false),
                    Comment_by_fixing_employee = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: true, collation: "Utf8_General_Ci"),
                    Comment_by_fixer_employee = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: true, collation: "Utf8_General_Ci"),
                    Published_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    Coordinated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixed_disciplines", x => x.Fixed_discipline_id);
                    table.ForeignKey(
                        name: "FK_Fixed_disciplines_Employees",
                        column: x => x.Fixing_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixed_disciplines_Employees1",
                        column: x => x.Fixer_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixed_disciplines_Groups",
                        column: x => x.Group_id,
                        principalTable: "Groups",
                        principalColumn: "Group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixed_disciplines_Semester_disciplines",
                        column: x => x.Semester_discipline_id,
                        principalTable: "Semester_disciplines",
                        principalColumn: "Semester_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Schedule_disciplines",
                columns: table => new
                {
                    Schedule_discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fixed_discipline_id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Pair_number = table.Column<int>(type: "int", nullable: false),
                    Audience_id = table.Column<int>(type: "int", nullable: true),
                    Is_even_pair = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Is_first_subgroup = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Created_by_employee_id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified_by_employee_id = table.Column<int>(type: "int", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_disciplines", x => x.Schedule_discipline_id);
                    table.ForeignKey(
                        name: "FK_Schedule_disciplines_Audiences",
                        column: x => x.Audience_id,
                        principalTable: "Audiences",
                        principalColumn: "Audience_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_disciplines_Employees",
                        column: x => x.Created_by_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_disciplines_Employees1",
                        column: x => x.Modified_by_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_disciplines_Fixed_disciplines",
                        column: x => x.Fixed_discipline_id,
                        principalTable: "Fixed_disciplines",
                        principalColumn: "Fixed_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Schedule_discipline_replacement",
                columns: table => new
                {
                    Schedule_discipline_replacement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Schedule_discipline_id = table.Column<int>(type: "int", nullable: true),
                    Fixed_discipline_id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Pair_number = table.Column<int>(type: "int", nullable: false),
                    Audience_id = table.Column<int>(type: "int", nullable: true),
                    Is_first_subgroup = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Created_by_employee_id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified_by_employee_id = table.Column<int>(type: "int", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_discipline_replacement", x => x.Schedule_discipline_replacement_id);
                    table.ForeignKey(
                        name: "FK_Schedule_discipline_replacement_Audiences",
                        column: x => x.Audience_id,
                        principalTable: "Audiences",
                        principalColumn: "Audience_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_discipline_replacement_Employees",
                        column: x => x.Created_by_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_discipline_replacement_Employees1",
                        column: x => x.Modified_by_employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_discipline_replacement_Fixed_disciplines",
                        column: x => x.Fixed_discipline_id,
                        principalTable: "Fixed_disciplines",
                        principalColumn: "Fixed_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_discipline_replacement_Schedule_disciplines",
                        column: x => x.Schedule_discipline_id,
                        principalTable: "Schedule_disciplines",
                        principalColumn: "Schedule_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateTable(
                name: "Conducted_pairs",
                columns: table => new
                {
                    Conducted_pair_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Schedule_discipline_id = table.Column<int>(type: "int", nullable: true),
                    Schedule_discipline_replacement_id = table.Column<int>(type: "int", nullable: true),
                    Lesson_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conducted_pairs", x => x.Conducted_pair_id);
                    table.ForeignKey(
                        name: "FK_Conducted_pairs_Lesson_types",
                        column: x => x.Lesson_type_id,
                        principalTable: "Lesson_types",
                        principalColumn: "Lesson_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conducted_pairs_Schedule_discipline_replacement",
                        column: x => x.Schedule_discipline_replacement_id,
                        principalTable: "Schedule_discipline_replacement",
                        principalColumn: "Schedule_discipline_replacement_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conducted_pairs_Schedule_disciplines1",
                        column: x => x.Schedule_discipline_id,
                        principalTable: "Schedule_disciplines",
                        principalColumn: "Schedule_discipline_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Relational:Collation", "Utf8_General_Ci");

            migrationBuilder.CreateIndex(
                name: "IX_Audiences_Audience_type_id",
                table: "Audiences",
                column: "Audience_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audiences_Employee_head_id",
                table: "Audiences",
                column: "Employee_head_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cathedra_specialties_Specialtie_id",
                table: "Cathedra_specialties",
                column: "Fses_category_patition_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conducted_pairs_Lesson_type_id",
                table: "Conducted_pairs",
                column: "Lesson_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conducted_pairs_Schedule_discipline_id",
                table: "Conducted_pairs",
                column: "Schedule_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conducted_pairs_Schedule_discipline_replacement_id",
                table: "Conducted_pairs",
                column: "Schedule_discipline_replacement_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Cathedra_id",
                table: "Disciplines",
                column: "Cathedra_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Education_cycle_id",
                table: "Disciplines",
                column: "Education_cycle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Education_cycles_and_modules_Education_cycle_parent_id",
                table: "Education_cycles_and_modules",
                column: "Education_cycle_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Education_plan_semester_disciplines_Semester_discipline_id",
                table: "Education_plan_semester_disciplines",
                column: "Semester_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Education_plans_Academic_year_id",
                table: "Education_plans",
                column: "Academic_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_Education_plans_Specialtie_id",
                table: "Education_plans",
                column: "Fses_category_patition_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_cathedras_Cathedra_id",
                table: "Employee_cathedras",
                column: "Cathedra_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Post_id",
                table: "Employees",
                column: "Post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fixed_disciplines_Employee_id",
                table: "Fixed_disciplines",
                column: "Fixing_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fixed_disciplines_Fixer_employee_id",
                table: "Fixed_disciplines",
                column: "Fixer_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fixed_disciplines_Group_id",
                table: "Fixed_disciplines",
                column: "Group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fixed_disciplines_Semester_discipline_id",
                table: "Fixed_disciplines",
                column: "Semester_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fses_categories_Fses_id",
                table: "Fses_categories",
                column: "Fses_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fses_category_partitions_Fses_category_id",
                table: "Fses_category_partitions",
                column: "Fses_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Curator_id",
                table: "Groups",
                column: "Curator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Education_plan_id",
                table: "Groups",
                column: "Education_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Received_education_id",
                table: "Groups",
                column: "Received_education_id");

            migrationBuilder.CreateIndex(
                name: "IX_Received_education_forms_Education_form_id",
                table: "Received_education_forms",
                column: "Education_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_Received_educations_Education_level_id",
                table: "Received_educations",
                column: "Education_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_Received_educations_Received_education_form_id",
                table: "Received_educations",
                column: "Received_education_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_Received_educations_Received_specialty_id",
                table: "Received_educations",
                column: "Received_specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Received_specialties_Specialtie_id",
                table: "Received_specialties",
                column: "Fses_category_patition_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline_replacement_Audience_id",
                table: "Schedule_discipline_replacement",
                column: "Audience_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline_replacement_Created_by_employee_id",
                table: "Schedule_discipline_replacement",
                column: "Created_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline_replacement_Fixed_discipline_id",
                table: "Schedule_discipline_replacement",
                column: "Fixed_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline_replacement_Modified_by_employee_id",
                table: "Schedule_discipline_replacement",
                column: "Modified_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline_replacement_Schedule_discipline_id",
                table: "Schedule_discipline_replacement",
                column: "Schedule_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_disciplines_Audience_id",
                table: "Schedule_disciplines",
                column: "Audience_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_disciplines_Created_by_employee_id",
                table: "Schedule_disciplines",
                column: "Created_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_disciplines_Fixed_discipline_id",
                table: "Schedule_disciplines",
                column: "Fixed_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_disciplines_Modified_by_employee_id",
                table: "Schedule_disciplines",
                column: "Modified_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_disciplines_Certification_form_id",
                table: "Semester_disciplines",
                column: "Certification_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_disciplines_Discipline_id",
                table: "Semester_disciplines",
                column: "Discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_disciplines_Semester_id",
                table: "Semester_disciplines",
                column: "Semester_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cathedra_specialties");

            migrationBuilder.DropTable(
                name: "Conducted_pairs");

            migrationBuilder.DropTable(
                name: "Education_plan_semester_disciplines");

            migrationBuilder.DropTable(
                name: "Employee_cathedras");

            migrationBuilder.DropTable(
                name: "Lesson_types");

            migrationBuilder.DropTable(
                name: "Schedule_discipline_replacement");

            migrationBuilder.DropTable(
                name: "Schedule_disciplines");

            migrationBuilder.DropTable(
                name: "Audiences");

            migrationBuilder.DropTable(
                name: "Fixed_disciplines");

            migrationBuilder.DropTable(
                name: "Audience_types");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Semester_disciplines");

            migrationBuilder.DropTable(
                name: "Education_plans");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Received_educations");

            migrationBuilder.DropTable(
                name: "Intermediate_certification_forms");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Academic_years");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Education_levels");

            migrationBuilder.DropTable(
                name: "Received_education_forms");

            migrationBuilder.DropTable(
                name: "Received_specialties");

            migrationBuilder.DropTable(
                name: "Cathedras");

            migrationBuilder.DropTable(
                name: "Education_cycles_and_modules");

            migrationBuilder.DropTable(
                name: "Education_forms");

            migrationBuilder.DropTable(
                name: "Fses_category_partitions");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Fses_categories");

            migrationBuilder.DropTable(
                name: "Federal_state_educational_standards");
        }
    }
}
