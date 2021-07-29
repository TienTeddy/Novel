using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of Novel" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of Novel" },
                new AppConfig() { Key = "HomeDesciption", Value = "This is description of Novel" }
                );


            modelBuilder.Entity<Language>().HasData(
                new Language() { id_language = "vi-VN", name = "Tiếng Việt", IsDefault = true },
                new Language() { id_language = "en-US", name = "English", IsDefault = false }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    id_category = 1, 
                    IsShowOnHome= true, 
                    id_parent = null, 
                    sort_order = 1, 
                    status = Enum.Status.Active,
                },
                new Category()
                {
                    id_category = 2,
                    IsShowOnHome = true,
                    id_parent = null,
                    sort_order = 2,
                    status = Enum.Status.Active,
                }
                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    id_categoryTranslation = 1,
                    id_category = 1,
                    name = "Áo Nam",
                    id_language = "vi-VN",
                    seo_alias = "ao-nam",
                    seo_title = "Sản phẩm thời trang nam",
                    seo_description = "Sản phẩm thời trang nam"
                },
                new CategoryTranslation()
                {
                    id_categoryTranslation = 2,
                    id_category = 1,
                    name = "Men Shirt",
                    id_language = "en-US",
                    seo_alias = "men-shirt",
                    seo_title = "The shirt product for men",
                    seo_description = "The shirt product for men"
                }
            );
            
            modelBuilder.Entity<Product>().HasData(
                new Product() { 
                    id_product = 1, 
                    date_created=DateTime.Now, 
                    original_price=100000, 
                    price= 200000, 
                    stock=0, 
                    view_count=0,
                }
                );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    id_productTranslation = 1,
                    id_product = 1,
                    name = "Áo sơ mi nam trắng Việt Tiến",
                    id_language = "vi-VN",
                    seo_alias = "ao-so-mi-nam-trang-viet-tien",
                    seo_title = "Sản phẩm thời trang nam",
                    seo_description = "Sản phẩm thời trang nam",
                    details = "Mô tả sản phẩm",
                    description = ""
                },
                new ProductTranslation()
                {
                    id_productTranslation = 2,
                    id_product = 1,
                    name = "Viet Tien Men T-Shirt",
                    id_language = "en-US",
                    seo_alias = "viet-tien-men-t-shirt",
                    seo_title = "The shirt product for men",
                    seo_description = "The shirt product for men",
                    details = "Description of product",
                    description = ""
                }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { id_category = 1 , id_product = 1}
                );


            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tienle10998@gmail.com",
                NormalizedEmail = "tienle10998@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "abc123@"),
                SecurityStamp = string.Empty,
                first_name = "Tien",
                last_name = "Lee",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId,
                    UserId = adminId
                });
        }
    }
}
