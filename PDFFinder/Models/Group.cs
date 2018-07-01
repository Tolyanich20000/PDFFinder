using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;
using iTextSharp.text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDFFinder.Models
{
    public class Group
    {
        private Rectangle _pageSize;

        public int Id { get; set; }

        public string GroupName { get; set; }

        public string PrinterName { get; set; }

        public bool? Duplex { get; set; }

        public int? PaperFormatId { get; set; }

        public PaperFormat PaperFormat { get; set; }

        [NotMapped]
        public Rectangle PageSize
        {
            get { return _pageSize; }
            private set
            {
                if (_pageSize != value)
                {
                    _pageSize = iTextSharp.text.PageSize.GetRectangle(PaperFormat.Name);
                }
            }
        }

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
