﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    /// <summary>
    /// 서버 설정
    /// </summary>
    public partial class ServerSetting
    {
        /// <summary>
        /// 회사(클라이언트) 아이디
        /// </summary>
        public int ServerSettingId { get; set; }
        /// <summary>
        /// 쪽지 갱신 주기(분)
        /// </summary>
        public int MemoCheckInterval { get; set; }
        /// <summary>
        /// 배정을 뽑을 수 있는 최대 잔존 수량
        /// </summary>
        public int AssignmentMaxHolding { get; set; }
        /// <summary>
        /// 배정 일일 쿼터
        /// </summary>
        public int AssignmentDailyQuota { get; set; }
        /// <summary>
        /// 한번에 뽑는 배정 갯수
        /// </summary>
        public int AssignmentPerPick { get; set; }
        /// <summary>
        /// 챗 갱신 주기(분)
        /// </summary>
        public int ChatCheckInterval { get; set; }
    }
}