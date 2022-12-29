﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hope.Data
{
    public partial class Document
    {
        public Document()
        {
            DocumentVersions = new HashSet<DocumentVersion>();
        }

        public int DocumentId { get; set; }
        public int FolderId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int? EditingBy { get; set; }

        public virtual User EditingByNavigation { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual ICollection<DocumentVersion> DocumentVersions { get; set; }
    }
}