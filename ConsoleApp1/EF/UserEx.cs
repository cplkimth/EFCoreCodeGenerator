﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class UserEx
    {
        public int UserId { get; set; }
        public string IP { get; set; }
        public string MacAddress { get; set; }
        public string OS { get; set; }
        public string RunningProcesses { get; set; }
        /// <summary>
        /// HopeCore 업그레이드 가능
        /// </summary>
        public DateTime? UpgradableChecketAt { get; set; }

        public virtual User User { get; set; }
    }
}