﻿using System;
using System.Collections.Generic;

namespace EmployeeProfile.Model;

public partial class Department
{
    public int DeptId { get; set; }

    public string? Department1 { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
