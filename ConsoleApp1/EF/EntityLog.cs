﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class EntityLog
    {
        /// <summary>
        /// PK 값 (; 으로 구분)
        /// </summary>
        public string KeyValue { get; set; }
        /// <summary>
        /// 유저 아이디
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 기록일시
        /// </summary>
        public DateTime At { get; set; }
        /// <summary>
        /// 엔터티 이름
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 작업 코드 (13)
        /// </summary>
        public int ActionCode { get; set; }
        /// <summary>
        /// 내역
        /// </summary>
        public string Content { get; set; }
    }
}