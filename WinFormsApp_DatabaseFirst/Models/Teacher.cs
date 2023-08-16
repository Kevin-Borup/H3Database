using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class Teacher
{
    public Guid PersonID { get; set; }

    public int TeacherID { get; set; }

    public float? Salary { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
