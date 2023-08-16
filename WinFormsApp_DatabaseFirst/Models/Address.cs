using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? PostalCode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
