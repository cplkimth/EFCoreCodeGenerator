//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chinook.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Track
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Track()
        {
            this.PlaylistTracks = new HashSet<PlaylistTrack>();
        }
    
        public int TrackId { get; set; }
        public string Name { get; set; }
        public Nullable<int> AlbumId { get; set; }
        public bool BitCol { get; set; }
        public Nullable<bool> BitColNull { get; set; }
        public byte TinyIntCol { get; set; }
        public Nullable<byte> TinyIntColNull { get; set; }
        public short SmallIntCol { get; set; }
        public Nullable<short> SmallIntColNull { get; set; }
        public long BigIntCol { get; set; }
        public Nullable<long> BigIntColNull { get; set; }
        public string CharCol { get; set; }
        public string CharColNull { get; set; }
        public string VarCharCol { get; set; }
        public string VarCharColNull { get; set; }
        public string NcharCol { get; set; }
        public string NcharColNull { get; set; }
        public string NvarCharCol { get; set; }
        public string NvarCharColNull { get; set; }
        public byte[] BinaryCol { get; set; }
        public byte[] BinaryColNull { get; set; }
        public System.DateTime DateCol { get; set; }
        public Nullable<System.DateTime> DateColNull { get; set; }
        public System.DateTime DateTimeCol { get; set; }
        public Nullable<System.DateTime> DateTimeColNull { get; set; }
        public System.DateTime SmallDateTimeCol { get; set; }
        public Nullable<System.DateTime> SmallDateTimeColNull { get; set; }
        public decimal DecimalCol { get; set; }
        public Nullable<decimal> DecimalColNull { get; set; }
        public double FloatCol { get; set; }
        public Nullable<double> FloatColNull { get; set; }
        public float RealCol { get; set; }
        public Nullable<float> RealColNull { get; set; }
        public decimal SmallMoneyCol { get; set; }
        public Nullable<decimal> SmallMoneyColNull { get; set; }
        public byte[] TimeStampCol { get; set; }
        public System.TimeSpan TimeCol { get; set; }
        public Nullable<System.TimeSpan> TimeColNull { get; set; }
        public System.Guid GuidCol { get; set; }
        public Nullable<System.Guid> GuidColNull { get; set; }
        public byte[] VarBinaryCol { get; set; }
        public byte[] VarBinaryColNull { get; set; }
    
        public virtual Album Album { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
