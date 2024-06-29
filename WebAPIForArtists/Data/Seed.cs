using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using WebAPIForArtists.Data.Enum;
using WebAPIForArtists.Models;

namespace WebAPIForArtists.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Drawing Club 1",
                            Image = "https://cs4.pikabu.ru/post_img/big/2014/04/07/1/1396825056_1394129965.jpg",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Animals,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                         },
                        new Club()
                        {
                            Title = "Drawing Club 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Human,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                        },
                        new Club()
                        {
                            Title = "Drawing Club 3",
                            Image = "https://c.wallhere.com/photos/eb/e9/2560x1600_px_landscape-706891.jpg!d",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Village,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Michigan",
                                Region = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Challenges
                if (!context.Challenges.Any())
                {
                    context.Challenges.AddRange(new List<Challenge>()
                    {
                        new Challenge()
                        {
                            Title = "Challenge 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first Challenge",
                            Category = ChallengeCategory.Draw_other_hand
                            
                        },
                        new Challenge()
                        {
                            Title = "Challenge 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first Challenge",
                            Category = ChallengeCategory.Draw_faster

                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
           using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
           {
              //Roles
               var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

               if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //*Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    string adminUserEmail = "teddysmithdeveloper@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new AppUser()
                        {
                            UserName = "teddysmithdev",
                            Email = adminUserEmail,
                            EmailConfirmed = true,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    string appUserEmail = "user@etickets.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                   {
                        var newAppUser = new AppUser()
                        {
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true,
                            Address = new Address()
                            {
                                Park = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                           }
                        };
                        await userManager.CreateAsync(newAppUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }
    }
}
