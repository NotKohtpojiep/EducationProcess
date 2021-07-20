using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EmployeeCathedra
    {
        public int EmployeeId { get; set; }
        public int CathedraId { get; set; }

        public virtual Cathedra Cathedra { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
