using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DBFirstDemo.Models;

public partial class Student
{
    [DisplayName("Roll Number")]
    public int Roll { get; set; }

    [DisplayName("Name")]
    public string? StuName { get; set; }
    [DisplayName("Gender")]
    public string? StuGender { get; set; }
    [DisplayName("Date Of Birth")]
    public DateOnly? StuDob { get; set; }
    [DisplayName("Phone Number")]
    public string? StuPhone { get; set; }
}
