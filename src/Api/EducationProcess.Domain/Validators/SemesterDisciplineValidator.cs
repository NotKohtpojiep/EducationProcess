using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class SemesterDisciplineValidator : AbstractValidator<SemesterDiscipline>
	{
		public SemesterDisciplineValidator()
		{
			RuleFor(x => x.SemesterDisciplineId)
			.GreaterThan(-1)
			.WithMessage("SemesterDisciplineId should be greater than - 1");

			RuleFor(x => x.SemesterId)
			.GreaterThan(-1)
			.WithMessage("SemesterId should be greater than - 1");

			RuleFor(x => x.DisciplineId)
			.GreaterThan(-1)
			.WithMessage("DisciplineId should be greater than - 1");

			RuleFor(x => x.TheoryLessonHours)
			.LessThan((short)32000)
			.WithMessage("TheoryLessonHours should be greater than - 1");

			RuleFor(x => x.PracticeWorkHours)
			.LessThan((short)32000)
			.WithMessage("PracticeWorkHours should be greater than - 1");

			RuleFor(x => x.LaboratoryWorkHours)
			.LessThan((short)32000)
			.WithMessage("LaboratoryWorkHours should be greater than - 1");

			RuleFor(x => x.ControlWorkHours)
			.LessThan((short)32000)
			.WithMessage("ControlWorkHours should be greater than - 1");

			RuleFor(x => x.IndependentWorkHours)
			.LessThan((short)32000)
			.WithMessage("IndependentWorkHours should be greater than - 1");

			RuleFor(x => x.ConsultationHours)
			.LessThan((short)32000)
			.WithMessage("ConsultationHours should be greater than - 1");

			RuleFor(x => x.ExamHours)
			.LessThan((short)32000)
			.WithMessage("ExamHours should be greater than - 1");

			RuleFor(x => x.EducationalPracticeHours)
			.LessThan((short)32000)
			.WithMessage("EducationalPracticeHours should be greater than - 1");

			RuleFor(x => x.ProductionPracticeHours)
			.LessThan((short)32000)
			.WithMessage("ProductionPracticeHours should be greater than - 1");

			RuleFor(x => x.CertificationFormId)
			.GreaterThan(-1)
			.When(x=>x.CertificationFormId != null)
			.WithMessage("CertificationFormId should be greater than - 1");


			RuleFor(x => x.Description).Length(000,000)
			.When(x=>x.Description != null)
			.WithMessage("Description  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Description should not be empty");


		}
	}
}
