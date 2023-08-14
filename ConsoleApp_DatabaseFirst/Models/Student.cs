using System;
using System.Collections.Generic;

namespace ConsoleApp_DatabaseFirst.Models;

public partial class Student
{
    public Guid? PersonId { get; set; }

    public int StudentId { get; set; }

    public float? AverageMark { get; set; }

    public virtual Person? Person { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
