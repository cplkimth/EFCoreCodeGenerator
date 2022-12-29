
#region using
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Chinook.Data;

public partial class EntityDao<T>
{
    protected virtual partial void OnSaved(T entity, LogType logType)
    {
        // TODO : 엔티티의 로그를 기록한다.
    }

    protected virtual partial void OnSaved(IEnumerable<T> entities, LogType logType)
    {
        // TODO : 엔티티의 로그를 기록한다.
    }
}