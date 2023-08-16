using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class Student
{
    public Guid PersonID { get; set; }

    public int StudentID { get; set; }

    public float? AverageMark { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
