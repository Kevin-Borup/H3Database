using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class Grade
{
    public Guid GradeId { get; set; }

    public string Subject { get; set; } = null!;

    public float Value { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
