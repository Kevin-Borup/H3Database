using System;
using System.Collections.Generic;

namespace ConsoleApp_DatabaseFirst.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public Guid? PersonId { get; set; }

    public float? Salary { get; set; }

    public virtual Person? Person { get; set; }
}
