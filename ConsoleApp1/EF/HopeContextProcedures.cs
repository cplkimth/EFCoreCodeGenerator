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
    public partial class HopeContext
    {
        private IHopeContextProcedures _procedures;

        public virtual IHopeContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new HopeContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IHopeContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usp_GetAssignmentLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_GetAttendanceLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_GetConsultLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_GetCustomerLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_GetUserLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_GetWorkLogResult>().HasNoKey().ToView(null);
        }
    }

    public partial class HopeContextProcedures : IHopeContextProcedures
    {
        private readonly HopeContext _context;

        public HopeContextProcedures(HopeContext context)
        {
            _context = context;
        }

        public virtual async Task<List<usp_GetAssignmentLogResult>> usp_GetAssignmentLogAsync(DateTime? AssignedOn, int? CustomerId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "AssignedOn",
                    Value = AssignedOn ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "CustomerId",
                    Value = CustomerId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetAssignmentLogResult>("EXEC @returnValue = [dbo].[usp_GetAssignmentLog] @AssignedOn, @CustomerId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_GetAttendanceLogResult>> usp_GetAttendanceLogAsync(DateTime? Date, int? UserId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Date",
                    Value = Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = UserId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetAttendanceLogResult>("EXEC @returnValue = [dbo].[usp_GetAttendanceLog] @Date, @UserId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_GetConsultLogResult>> usp_GetConsultLogAsync(int? ConsultId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ConsultId",
                    Value = ConsultId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetConsultLogResult>("EXEC @returnValue = [dbo].[usp_GetConsultLog] @ConsultId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_GetCustomerLogResult>> usp_GetCustomerLogAsync(int? CustomerId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CustomerId",
                    Value = CustomerId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetCustomerLogResult>("EXEC @returnValue = [dbo].[usp_GetCustomerLog] @CustomerId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_GetUserLogResult>> usp_GetUserLogAsync(int? UserId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = UserId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetUserLogResult>("EXEC @returnValue = [dbo].[usp_GetUserLog] @UserId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_GetWorkLogResult>> usp_GetWorkLogAsync(int? workId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "workId",
                    Value = workId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetWorkLogResult>("EXEC @returnValue = [dbo].[usp_GetWorkLog] @workId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}