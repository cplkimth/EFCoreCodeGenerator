﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    /// <summary>
    /// 다이렉트 콜 발신 내역
    /// </summary>
    public partial class CallHistory
    {
        public int CallHistoryId { get; set; }
        /// <summary>
        /// [68] 콜 타입
        /// </summary>
        public int TypeCode { get; set; }
        public int UserId { get; set; }
        public string SentTo { get; set; }
        public DateTime SentAt { get; set; }
        public string Memo { get; set; }

        public virtual User User { get; set; }
    }
}