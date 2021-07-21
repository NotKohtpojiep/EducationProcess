using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class EmployeeCathedra
    {
        public int EmployeeId { get; set; }
        public int CathedraId { get; set; }

        public  Cathedra Cathedra { get; set; }
        public  Employee Employee { get; set; }
    }
}
