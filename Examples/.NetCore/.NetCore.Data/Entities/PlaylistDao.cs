
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;

#region <#T PascalName T#>Metadata
public class <#T PascalName T#>MetaData
{
    `A:[N][T][T]:public `Type` `Name` {get; set;} ``
}
#endregion

[MetadataType(typeof(<#T PascalName T#>MetaData))]
public partial class <#T PascalName T#>
{
}