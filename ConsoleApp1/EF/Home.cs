﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class Home
    {
        public int HomeId { get; set; }
        public int ConsultId { get; set; }
        /// <summary>
        /// [38] 주택 소유
        /// </summary>
        public int OwnershipCode { get; set; }
        /// <summary>
        /// [39] 주택 종류
        /// </summary>
        public int BuildingTypeCode { get; set; }
        /// <summary>
        /// [24] 담보
        /// </summary>
        public int CollateralCode { get; set; }
        /// <summary>
        /// [48] 거주
        /// </summary>
        public int ResidenceCode { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Consult Consult { get; set; }
    }
}