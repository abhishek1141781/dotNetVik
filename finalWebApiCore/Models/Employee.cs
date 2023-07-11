using System;
using System.Collections.Generic;
using finalWebApiCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace finalWebApiCore.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public string Name { get; set; } = null!;

    public decimal Basic { get; set; }

    public int? DeptNo { get; set; }

    public virtual Department? DeptNoNavigation { get; set; }
}


