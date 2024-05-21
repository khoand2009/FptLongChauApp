using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FptLongChauApp.Data;

namespace FptLongChauApp.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options){
        //public object Categories { get; internal set; }
        //public object Drugs { get; internal set; }

        //public DbSet<Category> Categories { set; get; }
        //public DbSet<Post> Posts { set; get; }
        //public DbSet<PostCategory> PostCategories { set; get; }

        public DbSet<Drug> Drugs { set; get; }
        public object Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<Drug>(
                // Thiết lập kiểu Decimal cho Price
                p => p.Property(p => p.Price).HasColumnType("DECIMAL")
            );
            // SeedData - chèn ngay bốn sản phẩm khi bảng Drug được tạo
            builder.Entity<Drug>().HasData(
                new Drug()
                {
                    DrugId = 1,
                    Name = "Paracetamol 500mg",
                    ImagePath = "paracetamol.jpg",
                    Description = "Non-prescription pain relievers and fever reducers.",
                    Price = 25000
                },
                new Drug()
                {
                    DrugId = 2,
                    Name = "Aspirin 81mg",
                    ImagePath = "aspirin.jpg",
                    Description = "Antiplatelet drugs, stroke prevention.",
                    Price = 38000
                },
                new Drug()
                {
                    DrugId = 3,
                    Name = "Ibuprofen 400mg",
                    ImagePath = "ibuprofen.jpg",
                    Description = "Non-steroidal anti-inflammatory and pain relievers.",
                    Price = 42000
                },
                new Drug()
                {
                    DrugId = 4,
                    Name = "Loratadine 10mg",
                    ImagePath = "loratadine.jpg",
                    Description = "Antihistamines, allergy treatment.",
                    Price = 55000
                },
                new Drug()
                {
                    DrugId = 5,
                    Name = "Omeprazole 20mg",
                    ImagePath = "omeprazole.jpg",
                    Description = "Proton pump inhibitors, treatment of stomach ulcers.",
                    Price = 80000
                },
                new Drug()
                {
                    DrugId = 6,
                    Name = "Simvastatin 20mg",
                    ImagePath = "simvastatin.jpg",
                    Description = "Statin drugs, lowering blood cholesterol.",
                    Price = 120000
                },
                new Drug()
                {
                    DrugId = 7,
                    Name = "Metformin 500mg",
                    ImagePath = "metformin.jpg",
                    Description = "Drugs to treat type 2 diabetes.",
                    Price = 95000
                },
                new Drug()
                {
                    DrugId = 8,
                    Name = "Amoxicillin 500mg",
                    ImagePath = "amoxicillin.jpg",
                    Description = "Antibiotics, treatment of infections.",
                    Price = 68000
                }
            );

        }
    }
}
