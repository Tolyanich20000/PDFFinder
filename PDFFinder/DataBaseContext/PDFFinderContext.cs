using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PDFFinder.DataBaseContext
{
    using Models;

    /// <summary>
    /// DBContext for PDF Finder
    /// </summary>
    public class PDFFinderContext : DbContext
    {
        public PDFFinderContext() : base("PDFFinderContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocumentConfiguration());
        }

        public DbSet<Document> Documents { get; set; }
    }
}
