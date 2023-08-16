using System;
using System.Collections.Generic;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class LibraryCard
{
    public Guid UserId { get; set; }

    public int RentedBooks { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Person User { get; set; } = null!;
}
