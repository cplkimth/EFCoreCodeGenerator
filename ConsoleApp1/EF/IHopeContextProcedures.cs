﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Hope.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Data
{
    public partial interface IHopeContextProcedures
    {
        Task<List<usp_GetAssignmentLogResult>> usp_GetAssignmentLogAsync(DateTime? AssignedOn, int? CustomerId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetAttendanceLogResult>> usp_GetAttendanceLogAsync(DateTime? Date, int? UserId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetConsultLogResult>> usp_GetConsultLogAsync(int? ConsultId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetCustomerLogResult>> usp_GetCustomerLogAsync(int? CustomerId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetUserLogResult>> usp_GetUserLogAsync(int? UserId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetWorkLogResult>> usp_GetWorkLogAsync(int? workId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}