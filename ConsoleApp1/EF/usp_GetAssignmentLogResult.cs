﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hope.Data
{
    public partial class usp_GetAssignmentLogResult
    {
        public DateTime AssignedOn { get; set; }
        public int CustomerId { get; set; }
        public DateTime LoggedAt { get; set; }
        public string LogType { get; set; }
        public int UserId { get; set; }
        public int StatusCode { get; set; }
        public string Memo { get; set; }
        public int TypeCode { get; set; }
        public DateTime? PickedAt { get; set; }
        public string ReservationMemo { get; set; }
        public DateTime? OriginalNextContactDate { get; set; }
        public DateTime? StatusChangedAt { get; set; }
    }
}