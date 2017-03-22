using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Reviews.Any())
            {
                if (await roleManager.FindByNameAsync("Reviewer") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Reviewer"));
                }

                if (await roleManager.FindByNameAsync("Admin") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                User member = await userManager.FindByNameAsync("Admin");
                if (member == null)
                {
                    member = new User { UserName = "Admin", DisplayName = "Admin", Email = "admin@woodvale.com", Quote = "" };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                    await userManager.AddToRoleAsync(member, "Admin");
                }

                member = await userManager.FindByNameAsync("ladyjen");
                if (member == null)
                {
                    member = new User { UserName = "ladyjen", DisplayName = "Jens", Email = "jens@woodvale.com", Quote = "A room without books is like a body without a soul." };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                    await userManager.AddToRoleAsync(member, "Reviewer");
                }

                

                Author author1 = new Author { FirstName = "Robin", LastName = "McKinley" };
                context.Authors.Add(author1);

                Author author2 = new Author { FirstName = "Patricia", LastName = "McKillip" };
                context.Authors.Add(author2);

                Book book1 = new Book { Title = "The Hero and the Crown", Genre = "Fantasy" };
                book1.Authors.Add(author1);
                context.Books.Add(book1);

                Book book2 = new Book { Title = "The Blue Sword", Genre = "Fantasy" };
                book1.Authors.Add(author1);
                context.Books.Add(book2);

                Book book3 = new Book { Title = "The Forgotten Beasts of Eld", Genre = "Fantasy" };
                book1.Authors.Add(author2);
                context.Books.Add(book3);

                Review review1 = new Review
                {
                    Title = "Best Read With Tea",
                    Body = "Consectetur adipiscing elit, sed do eiusmod tempor" +
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip" +
                    "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Book = book1,
                    Reviewer = member
                };
                context.Reviews.Add(review1);

                Review review2 = new Review
                {
                    Title = "A Grand Time",
                    Body = "Consectetur adipiscing elit, sed do eiusmod tempor" +
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip" +
                    "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Book = book2,
                    Reviewer = member
                };
                context.Reviews.Add(review2);

                member = await userManager.FindByNameAsync("mitzi");
                if (member == null)
                {
                    member = new User { UserName = "mitzi", DisplayName = "Marigold Gladwell", Email = "mitzi@woodvale.com", Quote = "Outside of a dog, a book is man's best friend. Inside of a dog it's too dark to read." };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                    await userManager.AddToRoleAsync(member, "Reviewer");
                }

                Review review3 = new Review
                {
                    Title = "A Grand Time",
                    Body = "Consectetur adipiscing elit, sed do eiusmod tempor" +
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip" +
                    "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Book = book3,
                    Reviewer = member
                };
                context.Reviews.Add(review3);

                context.SaveChanges();
            }
        }
    }
}
