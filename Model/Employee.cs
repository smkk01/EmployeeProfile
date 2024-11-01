﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeProfile.Model;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Mobile { get; set; }

    public int? Salary { get; set; }

    public int? DeptId { get; set; }
    [NotMapped]
    public string? Department { get; set; }
    public virtual Department? Dept { get; set; }
}
