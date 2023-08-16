using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class Person
{
    public Guid ID { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public Guid? AddressID { get; set; }

    public virtual Address? Address { get; set; }

    public virtual LibraryCard? LibraryCard { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
