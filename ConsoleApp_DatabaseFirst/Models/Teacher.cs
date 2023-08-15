using System;
using System.Collections.Generic;

namespace ConsoleApp_DatabaseFirst.Models;

public partial class Teacher
{
    public Guid PersonId { get; set; }

    public Guid TeacherId { get; set; }

    public float? Salary { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
