﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class UserRole
    {
        /// <summary>
        /// 역할 아이디
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 사용자 아이디
        /// </summary>
        public int UserId { get; set; }
        public bool? Dummy { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}