
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region InvoiceLineMetadata
public class InvoiceLineMetaData
{
    public int InvoiceLineId {get; set;} 
		public int InvoiceId {get; set;} 
		public int Quantity {get; set;} 
		public int TrackId {get; set;} 
		public decimal UnitPrice {get; set;} 
}
#endregion

[MetadataType(typeof(InvoiceLineMetaData))]
public partial class InvoiceLine
{
}

