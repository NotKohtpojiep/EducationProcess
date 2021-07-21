using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class Post
    {

        public int PostId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
