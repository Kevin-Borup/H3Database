using System;
using System.Collections.Generic;

namespace ConsoleApp_DatabaseFirst.Models;

public partial class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual LibraryCard? LibraryCard { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
