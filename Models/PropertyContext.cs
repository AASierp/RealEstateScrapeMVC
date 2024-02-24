using Microsoft.EntityFrameworkCore;
using System.Data;

namespace RealEstateScrapeMVC.Models
{
    public class PropertyContext : DbContext
    {
        public DbSet<PropertyModel> PropertyModels { get; set; }

        public DbSet<PropertySearchModel> PropertySearchModels {  get; set; }  

        public string DbPath { get; }

        public PropertyContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "PropertyData.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite($"Data Source={DbPath}");
    }

}
