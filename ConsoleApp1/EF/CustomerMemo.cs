﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class CustomerMemo
    {
        public int CustomerMemoId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 특이사항
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime RegisteredAt { get; set; }
        /// <summary>
        /// [83] 고객 메모 타입
        /// </summary>
        public int TypeCode { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}