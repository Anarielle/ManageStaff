using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageStaff.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Status { get; set; }
    [NotMapped]
    public string StatusView { get; set; }
}
