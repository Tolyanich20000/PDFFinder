using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;
using System.Drawing;

namespace PDFFinder.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public string PrinterName { get; set; }

        public bool? Duplex { get; set; }

        public int? PaperFormatId { get; set; }

        public PaperFormat PaperFormat { get; set; }

        public ICollection<Document> Documents { get; set; }

        public Group()
        {
            Documents = new List<Document>();
        }
    }

    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.GroupName).HasMaxLength(100).IsOptional();
            Ignore(e => e.PrinterName);
            Property(e => e.Duplex).IsOptional();
            HasMany(e => e.Documents).WithOptional(e => e.Group).HasForeignKey(e => e.GroupId);
        }
    }
}
