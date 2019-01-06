﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Display(Name="姓名")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name="注册日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "全名")]
        public string FullName
        {
            get
            {
                return Name ;
            }
        }
        public string Secret { get; set; }
        [Display(Name = "选课信息")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}