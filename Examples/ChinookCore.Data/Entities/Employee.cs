
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    #region EmployeeMetadata
    public class EmployeeMetaData
    {
        public int EmployeeId {get; set;}
		public string Address {get; set;}
		public DateTime? BirthDate {get; set;}
		public string City {get; set;}
		public string Country {get; set;}
		public string Email {get; set;}
		public string Fax {get; set;}
		public string FirstName {get; set;}
		public DateTime? HireDate {get; set;}
		public string LastName {get; set;}
		public string Phone {get; set;}
		public string PostalCode {get; set;}
		public int? ReportsTo {get; set;}
		public string State {get; set;}
		public string Title {get; set;}
    }
    #endregion
}
