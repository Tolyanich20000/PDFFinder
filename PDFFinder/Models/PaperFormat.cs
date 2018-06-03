using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.Models
{
    public class PaperFormat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Height { get; set; }

        public double? Width { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<Group> Groups { get; set; }

        public PaperFormat()
        {
            Documents = new List<Document>();
            Groups = new List<Group>();
        }
    }

    public class PaperFormatConfiguration : EntityTypeConfiguration<PaperFormat>
    {
        public PaperFormatConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsOptional().HasMaxLength(100);
            Property(e => e.Height).IsOptional();
            Property(e => e.Width).IsOptional();
            HasMany(e => e.Documents).WithOptional(e => e.PaperFormat).HasForeignKey(e => e.PaperFormatId);
            HasMany(e => e.Groups).WithOptional(e => e.PaperFormat).HasForeignKey(e => e.PaperFormatId);
        }
    }
}
