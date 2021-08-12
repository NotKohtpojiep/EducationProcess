using System;
using System.Threading;

namespace EducationProcess.HandyDesktop.UserControl
{
    public partial class ConfirmLessonView
    {
        public ConfirmLessonView()
        {
            InitializeComponent();

            //CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            //if (customPrincipal == null)
            //    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
            //int employeeId = customPrincipal.Identity.EmployeeId;

            //Employee currentEmployee = new EducationProcessContext().Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }
    }
}
