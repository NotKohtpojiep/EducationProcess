using System;
using EducationProcess.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EducationProcess.DataAccess
{
    public partial class EducationProcessContext : DbContext
    {
        public EducationProcessContext()
        {
        }

        public EducationProcessContext(DbContextOptions<EducationProcessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Audience> Audiences { get; set; }
        public virtual DbSet<AudienceType> AudienceTypes { get; set; }
        public virtual DbSet<Cathedra> Cathedras { get; set; }
        public virtual DbSet<CathedraSpecialty> CathedraSpecialties { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ConductedPair> ConductedPairs { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<EducationCyclesAndModule> EducationCyclesAndModules { get; set; }
        public virtual DbSet<EducationForm> EducationForms { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        public virtual DbSet<EducationPlan> EducationPlans { get; set; }
        public virtual DbSet<EducationPlanSemesterDiscipline> EducationPlanSemesterDisciplines { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeCathedra> EmployeeCathedras { get; set; }
        public virtual DbSet<FederalStateEducationalStandard> FederalStateEducationalStandards { get; set; }
        public virtual DbSet<FixedDiscipline> FixedDisciplines { get; set; }
        public virtual DbSet<FsesCategory> FsesCategories { get; set; }
        public virtual DbSet<FsesCategoryPartition> FsesCategoryPartitions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<IntermediateCertificationForm> IntermediateCertificationForms { get; set; }
        public virtual DbSet<LessonType> LessonTypes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ReceivedEducation> ReceivedEducations { get; set; }
        public virtual DbSet<ReceivedEducationForm> ReceivedEducationForms { get; set; }
        public virtual DbSet<ReceivedSpecialty> ReceivedSpecialties { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<ScheduleDiscipline> ScheduleDisciplines { get; set; }
        public virtual DbSet<ScheduleDisciplineReplacement> ScheduleDisciplineReplacements { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterDiscipline> SemesterDisciplines { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Utf8_General_Ci");

            modelBuilder.Entity<AcademicYear>(entity =>
            {
                entity.ToTable("Academic_years");

                entity.Property(e => e.AcademicYearId).HasColumnName("Academic_year_id");

                entity.Property(e => e.BeginingYear).HasColumnName("Begining_year");

                entity.Property(e => e.EndingYear).HasColumnName("Ending_year");
            });

            modelBuilder.Entity<Audience>(entity =>
            {
                entity.HasIndex(e => e.AudienceTypeId, "IX_Audiences_Audience_type_id");

                entity.HasIndex(e => e.EmployeeHeadId, "IX_Audiences_Employee_head_id");

                entity.Property(e => e.AudienceId).HasColumnName("Audience_id");

                entity.Property(e => e.AudienceTypeId).HasColumnName("Audience_type_id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.EmployeeHeadId).HasColumnName("Employee_head_id");

                entity.Property(e => e.Name).HasMaxLength(65);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.SeatsCount).HasColumnName("Seats_count");

                entity.HasOne(d => d.AudienceType)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.AudienceTypeId)
                    .HasConstraintName("FK_Audiences_Audience_types");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audiences_Departments");

                entity.HasOne(d => d.EmployeeHead)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.EmployeeHeadId)
                    .HasConstraintName("FK_Audiences_Employees");
            });

            modelBuilder.Entity<AudienceType>(entity =>
            {
                entity.ToTable("Audience_types");

                entity.Property(e => e.AudienceTypeId).HasColumnName("Audience_type_id");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cathedra>(entity =>
            {
                entity.Property(e => e.CathedraId).HasColumnName("Cathedra_id");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.NameAbbreviation)
                    .HasMaxLength(10)
                    .HasColumnName("Name_abbreviation");
            });

            modelBuilder.Entity<CathedraSpecialty>(entity =>
            {
                entity.HasKey(e => new { e.CathedraId, e.FsesCategoryPartitionId });

                entity.ToTable("Cathedra_specialties");

                entity.HasIndex(e => e.FsesCategoryPartitionId, "IX_Cathedra_specialties_Specialtie_id");

                entity.Property(e => e.CathedraId).HasColumnName("Cathedra_id");

                entity.Property(e => e.FsesCategoryPartitionId).HasColumnName("Fses_category_partition_id");

                entity.HasOne(d => d.Cathedra)
                    .WithMany(p => p.CathedraSpecialties)
                    .HasForeignKey(d => d.CathedraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cathedra_specialties_Cathedras");

                entity.HasOne(d => d.FsesCategoryPatition)
                    .WithMany(p => p.CathedraSpecialties)
                    .HasForeignKey(d => d.FsesCategoryPartitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cathedra_specialties_Fses_category_partitions");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.RegionId).HasColumnName("Region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Cities_Regions");
            });

            modelBuilder.Entity<ConductedPair>(entity =>
            {
                entity.ToTable("Conducted_pairs");

                entity.HasIndex(e => e.LessonTypeId, "IX_Conducted_pairs_Lesson_type_id");

                entity.HasIndex(e => e.ScheduleDisciplineId, "IX_Conducted_pairs_Schedule_discipline_id");

                entity.HasIndex(e => e.ScheduleDisciplineReplacementId, "IX_Conducted_pairs_Schedule_discipline_replacement_id");

                entity.Property(e => e.ConductedPairId).HasColumnName("Conducted_pair_id");

                entity.Property(e => e.LessonTypeId).HasColumnName("Lesson_type_id");

                entity.Property(e => e.ScheduleDisciplineId).HasColumnName("Schedule_discipline_id");

                entity.Property(e => e.ScheduleDisciplineReplacementId).HasColumnName("Schedule_discipline_replacement_id");

                entity.HasOne(d => d.LessonType)
                    .WithMany(p => p.ConductedPairs)
                    .HasForeignKey(d => d.LessonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conducted_pairs_Lesson_types");

                entity.HasOne(d => d.ScheduleDiscipline)
                    .WithMany(p => p.ConductedPairs)
                    .HasForeignKey(d => d.ScheduleDisciplineId)
                    .HasConstraintName("FK_Conducted_pairs_Schedule_disciplines1");

                entity.HasOne(d => d.ScheduleDisciplineReplacement)
                    .WithMany(p => p.ConductedPairs)
                    .HasForeignKey(d => d.ScheduleDisciplineReplacementId)
                    .HasConstraintName("FK_Conducted_pairs_Schedule_discipline_replacement");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.BuildingNumber).HasColumnName("Building_number");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("House_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.PostalCode).HasColumnName("Postal_code");

                entity.Property(e => e.StreetId).HasColumnName("Street_id");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Streets");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasIndex(e => e.CathedraId, "IX_Disciplines_Cathedra_id");

                entity.HasIndex(e => e.EducationCycleId, "IX_Disciplines_Education_cycle_id");

                entity.Property(e => e.DisciplineId).HasColumnName("Discipline_id");

                entity.Property(e => e.CathedraId).HasColumnName("Cathedra_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DisciplineIndex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Discipline_index");

                entity.Property(e => e.EducationCycleId).HasColumnName("Education_cycle_id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.HasOne(d => d.Cathedra)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.CathedraId)
                    .HasConstraintName("FK_Disciplines_Cathedras");

                entity.HasOne(d => d.EducationCycle)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.EducationCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disciplines_Education_cycles_and_modules");
            });

            modelBuilder.Entity<EducationCyclesAndModule>(entity =>
            {
                entity.HasKey(e => e.EducationCycleId);

                entity.ToTable("Education_cycles_and_modules");

                entity.HasIndex(e => e.EducationCycleParentId, "IX_Education_cycles_and_modules_Education_cycle_parent_id");

                entity.Property(e => e.EducationCycleId).HasColumnName("Education_cycle_id");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EducationCycleIndex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Education_cycle_index");

                entity.Property(e => e.EducationCycleParentId).HasColumnName("Education_cycle_parent_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.HasOne(d => d.EducationCycleParent)
                    .WithMany(p => p.InverseEducationCycleParent)
                    .HasForeignKey(d => d.EducationCycleParentId)
                    .HasConstraintName("FK_Education_cycles_and_modules_Education_cycles_and_modules");
            });

            modelBuilder.Entity<EducationForm>(entity =>
            {
                entity.ToTable("Education_forms");

                entity.Property(e => e.EducationFormId).HasColumnName("Education_form_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EducationLevel>(entity =>
            {
                entity.ToTable("Education_levels");

                entity.Property(e => e.EducationLevelId).HasColumnName("Education_level_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EducationPlan>(entity =>
            {
                entity.ToTable("Education_plans");

                entity.HasIndex(e => e.AcademicYearId, "IX_Education_plans_Academic_year_id");

                entity.HasIndex(e => e.FsesCategoryPartitionId, "IX_Education_plans_Specialtie_id");

                entity.Property(e => e.EducationPlanId).HasColumnName("Education_plan_id");

                entity.Property(e => e.AcademicYearId).HasColumnName("Academic_year_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.FsesCategoryPartitionId).HasColumnName("Fses_category_partition_id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.HasOne(d => d.AcademicYear)
                    .WithMany(p => p.EducationPlans)
                    .HasForeignKey(d => d.AcademicYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Education_plans_Academic_years");

                entity.HasOne(d => d.FsesCategoryPatition)
                    .WithMany(p => p.EducationPlans)
                    .HasForeignKey(d => d.FsesCategoryPartitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Education_plans_Fses_category_partitions");
            });

            modelBuilder.Entity<EducationPlanSemesterDiscipline>(entity =>
            {
                entity.HasKey(e => new { e.EducationPlanId, e.SemesterDisciplineId });

                entity.ToTable("Education_plan_semester_disciplines");

                entity.HasIndex(e => e.SemesterDisciplineId, "IX_Education_plan_semester_disciplines_Semester_discipline_id");

                entity.Property(e => e.EducationPlanId).HasColumnName("Education_plan_id");

                entity.Property(e => e.SemesterDisciplineId).HasColumnName("Semester_discipline_id");

                entity.HasOne(d => d.EducationPlan)
                    .WithMany(p => p.EducationPlanSemesterDisciplines)
                    .HasForeignKey(d => d.EducationPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Education_plan_semester_disciplines_Education_plans");

                entity.HasOne(d => d.SemesterDiscipline)
                    .WithMany(p => p.EducationPlanSemesterDisciplines)
                    .HasForeignKey(d => d.SemesterDisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Education_plan_semester_disciplines_Semester_disciplines");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PostId, "IX_Employees_Post_id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Middlename).HasMaxLength(100);

                entity.Property(e => e.PostId).HasColumnName("Post_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Posts");
            });

            modelBuilder.Entity<EmployeeCathedra>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.CathedraId });

                entity.ToTable("Employee_cathedras");

                entity.HasIndex(e => e.CathedraId, "IX_Employee_cathedras_Cathedra_id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.CathedraId).HasColumnName("Cathedra_id");

                entity.HasOne(d => d.Cathedra)
                    .WithMany(p => p.EmployeeCathedras)
                    .HasForeignKey(d => d.CathedraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_cathedras_Cathedras");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeCathedras)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_cathedras_Employees");
            });

            modelBuilder.Entity<FederalStateEducationalStandard>(entity =>
            {
                entity.HasKey(e => e.FsesId);

                entity.ToTable("Federal_state_educational_standards");

                entity.Property(e => e.FsesId).HasColumnName("Fses_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<FixedDiscipline>(entity =>
            {
                entity.ToTable("Fixed_disciplines");

                entity.HasIndex(e => e.FixingEmployeeId, "IX_Fixed_disciplines_Employee_id");

                entity.HasIndex(e => e.FixerEmployeeId, "IX_Fixed_disciplines_Fixer_employee_id");

                entity.HasIndex(e => e.GroupId, "IX_Fixed_disciplines_Group_id");

                entity.HasIndex(e => e.SemesterDisciplineId, "IX_Fixed_disciplines_Semester_discipline_id");

                entity.Property(e => e.FixedDisciplineId).HasColumnName("Fixed_discipline_id");

                entity.Property(e => e.CommentByFixerEmployee)
                    .HasMaxLength(600)
                    .HasColumnName("Comment_by_fixer_employee");

                entity.Property(e => e.CommentByFixingEmployee)
                    .HasMaxLength(600)
                    .HasColumnName("Comment_by_fixing_employee");

                entity.Property(e => e.CoordinatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Coordinated_at")
                    .HasDefaultValueSql("('2021-07-29T21:04:33.948')");

                entity.Property(e => e.FixerEmployeeId).HasColumnName("Fixer_employee_id");

                entity.Property(e => e.FixingEmployeeId).HasColumnName("Fixing_employee_id");

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.Property(e => e.IsAgreed).HasColumnName("Is_agreed");

                entity.Property(e => e.IsWatched)
                    .IsRequired()
                    .HasColumnName("Is_watched");
                    //.HasDefaultValueSql("(CONVERT([bit],(0)))");  TODO:fix default value (mysql server doesn't working with it)

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Published_at");

                entity.Property(e => e.SemesterDisciplineId).HasColumnName("Semester_discipline_id");

                entity.HasOne(d => d.FixerEmployee)
                    .WithMany(p => p.FixedDisciplineFixerEmployees)
                    .HasForeignKey(d => d.FixerEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixed_disciplines_Employees1");

                entity.HasOne(d => d.FixingEmployee)
                    .WithMany(p => p.FixedDisciplineFixingEmployees)
                    .HasForeignKey(d => d.FixingEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixed_disciplines_Employees");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.FixedDisciplines)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixed_disciplines_Groups");

                entity.HasOne(d => d.SemesterDiscipline)
                    .WithMany(p => p.FixedDisciplines)
                    .HasForeignKey(d => d.SemesterDisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixed_disciplines_Semester_disciplines");
            });

            modelBuilder.Entity<FsesCategory>(entity =>
            {
                entity.ToTable("Fses_categories");

                entity.HasIndex(e => e.FsesId, "IX_Fses_categories_Fses_id");

                entity.Property(e => e.FsesCategoryId).HasColumnName("Fses_category_id");

                entity.Property(e => e.FsesId).HasColumnName("Fses_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Fses)
                    .WithMany(p => p.FsesCategories)
                    .HasForeignKey(d => d.FsesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fses_categories_Federal_state_educational_standards");
            });

            modelBuilder.Entity<FsesCategoryPartition>(entity =>
            {
                entity.HasKey(e => e.FsesCategoryPartitionId);

                entity.ToTable("Fses_category_partitions");

                entity.HasIndex(e => e.FsesCategoryId, "IX_Fses_category_partitions_Fses_category_id");

                entity.Property(e => e.FsesCategoryPartitionId).HasColumnName("Fses_category_partition_id");

                entity.Property(e => e.FirstPartNumber).HasColumnName("First_part_number");

                entity.Property(e => e.FsesCategoryId).HasColumnName("Fses_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NameAbbreviation)
                    .HasMaxLength(10)
                    .HasColumnName("Name_abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.SecondPartNumber).HasColumnName("Second_part_number");

                entity.Property(e => e.ThirdPathNumber).HasColumnName("Third_path_number");

                entity.HasOne(d => d.FsesCategory)
                    .WithMany(p => p.FsesCategoryPartitions)
                    .HasForeignKey(d => d.FsesCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fses_category_partitions_Fses_categories");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.CuratorId, "IX_Groups_Curator_id");

                entity.HasIndex(e => e.EducationPlanId, "IX_Groups_Education_plan_id");

                entity.HasIndex(e => e.ReceivedEducationId, "IX_Groups_Received_education_id");

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.Property(e => e.CourseNumber).HasColumnName("Course_number");

                entity.Property(e => e.CuratorId).HasColumnName("Curator_id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.EducationPlanId).HasColumnName("Education_plan_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ReceiptYear).HasColumnName("Receipt_year");

                entity.Property(e => e.ReceivedEducationId).HasColumnName("Received_education_id");

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CuratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Employees");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Departments");

                entity.HasOne(d => d.EducationPlan)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.EducationPlanId)
                    .HasConstraintName("FK_Groups_Education_plans");

                entity.HasOne(d => d.ReceivedEducation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.ReceivedEducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Received_educations");
            });

            modelBuilder.Entity<IntermediateCertificationForm>(entity =>
            {
                entity.HasKey(e => e.CertificationFormId);

                entity.ToTable("Intermediate_certification_forms");

                entity.Property(e => e.CertificationFormId).HasColumnName("Certification_form_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LessonType>(entity =>
            {
                entity.ToTable("Lesson_types");

                entity.Property(e => e.LessonTypeId).HasColumnName("Lesson_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(65);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("Post_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<ReceivedEducation>(entity =>
            {
                entity.ToTable("Received_educations");

                entity.HasIndex(e => e.EducationLevelId, "IX_Received_educations_Education_level_id");

                entity.HasIndex(e => e.ReceivedEducationFormId, "IX_Received_educations_Received_education_form_id");

                entity.HasIndex(e => e.ReceivedSpecialtyId, "IX_Received_educations_Received_specialty_id");

                entity.Property(e => e.ReceivedEducationId).HasColumnName("Received_education_id");

                entity.Property(e => e.EducationLevelId).HasColumnName("Education_level_id");

                entity.Property(e => e.IsBudget).HasColumnName("Is_budget");

                entity.Property(e => e.ReceivedEducationFormId).HasColumnName("Received_education_form_id");

                entity.Property(e => e.ReceivedSpecialtyId).HasColumnName("Received_specialty_id");

                entity.Property(e => e.StudyPeriodMonths).HasColumnName("Study_period_months");

                entity.HasOne(d => d.EducationLevel)
                    .WithMany(p => p.ReceivedEducations)
                    .HasForeignKey(d => d.EducationLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Received_educations_Education_levels");

                entity.HasOne(d => d.ReceivedEducationForm)
                    .WithMany(p => p.ReceivedEducations)
                    .HasForeignKey(d => d.ReceivedEducationFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Received_educations_Received_education_forms");

                entity.HasOne(d => d.ReceivedSpecialty)
                    .WithMany(p => p.ReceivedEducations)
                    .HasForeignKey(d => d.ReceivedSpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Received_educations_Received_specialties");
            });

            modelBuilder.Entity<ReceivedEducationForm>(entity =>
            {
                entity.ToTable("Received_education_forms");

                entity.HasIndex(e => e.EducationFormId, "IX_Received_education_forms_Education_form_id");

                entity.Property(e => e.ReceivedEducationFormId).HasColumnName("Received_education_form_id");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(65)
                    .HasColumnName("Additional_info");

                entity.Property(e => e.EducationFormId).HasColumnName("Education_form_id");

                entity.HasOne(d => d.EducationForm)
                    .WithMany(p => p.ReceivedEducationForms)
                    .HasForeignKey(d => d.EducationFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Received_education_forms_Education_forms");
            });

            modelBuilder.Entity<ReceivedSpecialty>(entity =>
            {
                entity.ToTable("Received_specialties");

                entity.HasIndex(e => e.FsesCategoryPartitionId, "IX_Received_specialties_Specialtie_id");

                entity.Property(e => e.ReceivedSpecialtyId).HasColumnName("Received_specialty_id");

                entity.Property(e => e.FsesCategoryPartitionId).HasColumnName("Fses_category_partition_id");

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FsesCategoryPatition)
                    .WithMany(p => p.ReceivedSpecialties)
                    .HasForeignKey(d => d.FsesCategoryPartitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Received_specialties_Fses_category_partitions");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId).HasColumnName("Region_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<ScheduleDiscipline>(entity =>
            {
                entity.ToTable("Schedule_disciplines");

                entity.HasIndex(e => e.AudienceId, "IX_Schedule_disciplines_Audience_id");

                entity.HasIndex(e => e.CreatedByEmployeeId, "IX_Schedule_disciplines_Created_by_employee_id");

                entity.HasIndex(e => e.FixedDisciplineId, "IX_Schedule_disciplines_Fixed_discipline_id");

                entity.HasIndex(e => e.ModifiedByEmployeeId, "IX_Schedule_disciplines_Modified_by_employee_id");

                entity.Property(e => e.ScheduleDisciplineId).HasColumnName("Schedule_discipline_id");

                entity.Property(e => e.AudienceId).HasColumnName("Audience_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedByEmployeeId).HasColumnName("Created_by_employee_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FixedDisciplineId).HasColumnName("Fixed_discipline_id");

                entity.Property(e => e.IsEvenPair).HasColumnName("Is_even_pair");

                entity.Property(e => e.IsFirstSubgroup).HasColumnName("Is_first_subgroup");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_at");

                entity.Property(e => e.ModifiedByEmployeeId).HasColumnName("Modified_by_employee_id");

                entity.Property(e => e.PairNumber).HasColumnName("Pair_number");

                entity.HasOne(d => d.Audience)
                    .WithMany(p => p.ScheduleDisciplines)
                    .HasForeignKey(d => d.AudienceId)
                    .HasConstraintName("FK_Schedule_disciplines_Audiences");

                entity.HasOne(d => d.CreatedByEmployee)
                    .WithMany(p => p.ScheduleDisciplineCreatedByEmployees)
                    .HasForeignKey(d => d.CreatedByEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_disciplines_Employees");

                entity.HasOne(d => d.FixedDiscipline)
                    .WithMany(p => p.ScheduleDisciplines)
                    .HasForeignKey(d => d.FixedDisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_disciplines_Fixed_disciplines");

                entity.HasOne(d => d.ModifiedByEmployee)
                    .WithMany(p => p.ScheduleDisciplineModifiedByEmployees)
                    .HasForeignKey(d => d.ModifiedByEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_disciplines_Employees1");
            });

            modelBuilder.Entity<ScheduleDisciplineReplacement>(entity =>
            {
                entity.ToTable("Schedule_discipline_replacement");

                entity.HasIndex(e => e.AudienceId, "IX_Schedule_discipline_replacement_Audience_id");

                entity.HasIndex(e => e.CreatedByEmployeeId, "IX_Schedule_discipline_replacement_Created_by_employee_id");

                entity.HasIndex(e => e.FixedDisciplineId, "IX_Schedule_discipline_replacement_Fixed_discipline_id");

                entity.HasIndex(e => e.ModifiedByEmployeeId, "IX_Schedule_discipline_replacement_Modified_by_employee_id");

                entity.HasIndex(e => e.ScheduleDisciplineId, "IX_Schedule_discipline_replacement_Schedule_discipline_id");

                entity.Property(e => e.ScheduleDisciplineReplacementId).HasColumnName("Schedule_discipline_replacement_id");

                entity.Property(e => e.AudienceId).HasColumnName("Audience_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedByEmployeeId).HasColumnName("Created_by_employee_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FixedDisciplineId).HasColumnName("Fixed_discipline_id");

                entity.Property(e => e.IsFirstSubgroup).HasColumnName("Is_first_subgroup");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_at");

                entity.Property(e => e.ModifiedByEmployeeId).HasColumnName("Modified_by_employee_id");

                entity.Property(e => e.PairNumber).HasColumnName("Pair_number");

                entity.Property(e => e.ScheduleDisciplineId).HasColumnName("Schedule_discipline_id");

                entity.HasOne(d => d.Audience)
                    .WithMany(p => p.ScheduleDisciplineReplacements)
                    .HasForeignKey(d => d.AudienceId)
                    .HasConstraintName("FK_Schedule_discipline_replacement_Audiences");

                entity.HasOne(d => d.CreatedByEmployee)
                    .WithMany(p => p.ScheduleDisciplineReplacementCreatedByEmployees)
                    .HasForeignKey(d => d.CreatedByEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_discipline_replacement_Employees");

                entity.HasOne(d => d.FixedDiscipline)
                    .WithMany(p => p.ScheduleDisciplineReplacements)
                    .HasForeignKey(d => d.FixedDisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_discipline_replacement_Fixed_disciplines");

                entity.HasOne(d => d.ModifiedByEmployee)
                    .WithMany(p => p.ScheduleDisciplineReplacementModifiedByEmployees)
                    .HasForeignKey(d => d.ModifiedByEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_discipline_replacement_Employees1");

                entity.HasOne(d => d.ScheduleDiscipline)
                    .WithMany(p => p.ScheduleDisciplineReplacements)
                    .HasForeignKey(d => d.ScheduleDisciplineId)
                    .HasConstraintName("FK_Schedule_discipline_replacement_Schedule_disciplines");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.SemesterId).HasColumnName("Semester_id");

                entity.Property(e => e.WeeksCount).HasColumnName("Weeks_count");
            });

            modelBuilder.Entity<SemesterDiscipline>(entity =>
            {
                entity.ToTable("Semester_disciplines");

                entity.HasIndex(e => e.CertificationFormId, "IX_Semester_disciplines_Certification_form_id");

                entity.HasIndex(e => e.DisciplineId, "IX_Semester_disciplines_Discipline_id");

                entity.HasIndex(e => e.SemesterId, "IX_Semester_disciplines_Semester_id");

                entity.Property(e => e.SemesterDisciplineId).HasColumnName("Semester_discipline_id");

                entity.Property(e => e.CertificationFormId).HasColumnName("Certification_form_id");

                entity.Property(e => e.ConsultationHours).HasColumnName("Consultation_hours");

                entity.Property(e => e.ControlWorkHours).HasColumnName("Control_work_hours");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.DisciplineId).HasColumnName("Discipline_id");

                entity.Property(e => e.EducationalPracticeHours).HasColumnName("Educational_practice_hours");

                entity.Property(e => e.ExamHours).HasColumnName("Exam_hours");

                entity.Property(e => e.IndependentWorkHours).HasColumnName("Independent_work_hours");

                entity.Property(e => e.LaboratoryWorkHours).HasColumnName("Laboratory_work_hours");

                entity.Property(e => e.PracticeWorkHours).HasColumnName("Practice_work_hours");

                entity.Property(e => e.ProductionPracticeHours).HasColumnName("Production_practice_hours");

                entity.Property(e => e.SemesterId).HasColumnName("Semester_id");

                entity.Property(e => e.TheoryLessonHours).HasColumnName("Theory_lesson_hours");

                entity.HasOne(d => d.CertificationForm)
                    .WithMany(p => p.SemesterDisciplines)
                    .HasForeignKey(d => d.CertificationFormId)
                    .HasConstraintName("FK_Semester_disciplines_Intermediate_certification_forms");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.SemesterDisciplines)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Semesters_Disciplines_Disciplines");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterDisciplines)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Semesters_Disciplines_Semesters");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.StreetId).HasColumnName("Street_id");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Streets_Cities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}