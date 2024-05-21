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
                    Name = "Đá phong thuỷ tự nhiên",
                    Description = "Số 1 cao 40cm rộng 20cm dày 20cm màu xanh lá cây đậm",
                    Price = 1000000
                },
                new Drug()
                {
                    DrugId = 2,
                    Name = "Đèn đá muối hình tròn",
                    Description = "Trang trí trong nhà Chất liệu : • Đá muối",
                    Price = 1500000
                },
                new Drug()
                {
                    DrugId = 3,
                    Name = "Tranh sơn mài",
                    Description = "Tranh sơn mài loại nhỏ 15x 15 giá 50.000",
                    Price = 50000
                },
                new Drug()
                {
                    DrugId = 4,
                    Name = "Tranh sơn dầu - Ngựa",
                    Description = "Nguyên liệu thể hiện :    Sơn dầu",
                    Price = 450000
                }

            );
        }
    }
}
