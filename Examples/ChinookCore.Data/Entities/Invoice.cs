
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(InvoiceMetaData))]
    public partial class Invoice
    {
    }

    #region InvoiceMetadata
    public class InvoiceMetaData
    {
        public int InvoiceId {get; set;}
		public string BillingAddress {get; set;}
		public string BillingCity {get; set;}
		public string BillingCountry {get; set;}
		public string BillingPostalCode {get; set;}
		public string BillingState {get; set;}
		public int CustomerId {get; set;}
		public DateTime InvoiceDate {get; set;}
		public decimal Total {get; set;}
    }
    #endregion
}
