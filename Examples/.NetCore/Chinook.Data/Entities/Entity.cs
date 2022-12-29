
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;

public partial class Entity<T>
{
    public partial void WriteAuditInfo()
    {
		// TODO : 객체에 감사정보를 기입한다. 보통 ModifiedAt, ModifiedBy 등의 속성을 기록함.
    }
}