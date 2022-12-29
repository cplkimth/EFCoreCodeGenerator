﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class Income
    {
        public int IncomeId { get; set; }
        public int ConsultId { get; set; }
        /// <summary>
        /// [45] 고용형태
        /// </summary>
        public int EmploymentTypeCode { get; set; }
        /// <summary>
        /// [70] 직업유형
        /// </summary>
        public int JobTypeCode { get; set; }
        /// <summary>
        /// [44] 기업유형
        /// </summary>
        public int CompanyTypeCode { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// 입사일,개업일
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// [53] 소득증빙유형
        /// </summary>
        public int IncomeProofTypeCode { get; set; }
        /// <summary>
        /// 소득금액
        /// </summary>
        public int IncomeAmount { get; set; }
        public string Memo { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Consult Consult { get; set; }
    }
}