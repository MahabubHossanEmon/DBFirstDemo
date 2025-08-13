using System;
using System.Collections.Generic;

namespace DBFirstDemo.Models;

public partial class Student
{
    public int Roll { get; set; }

    public string? StuName { get; set; }

    public string? StuGender { get; set; }

    public DateOnly? StuDob { get; set; }

    public string? StuPhone { get; set; }
}
