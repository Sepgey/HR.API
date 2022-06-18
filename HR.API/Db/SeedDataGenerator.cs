using HR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Db
{
    public class SeedDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HRContext(
                serviceProvider.GetRequiredService<DbContextOptions<HRContext>>()))
            {
                // Check any employee exists 
                if (context.Employees.Any())
                {
                    return; // Data already exists no need to generate
                }

                context.Employees.AddRange(
                    new Employee
                    {
                        Name = "John Smith",
                        Designation = "Head of Software Development",
                        FathersName = "Bob Smith",
                        MothersName = "Helen Smith",
                        DateOfBirth = new DateTime(1984, 12, 19, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "Sam Brown",
                        Designation = "Senior Software Engineer",
                        FathersName = "Ben Brown",
                        MothersName = "Alisa Brown",
                        DateOfBirth = new DateTime(1990, 10, 29, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "Antony Black",
                        Designation = "Middle Software Engineer",
                        FathersName = "Ilon Black",
                        MothersName = "Candy Black",
                        DateOfBirth = new DateTime(2017, 09, 17, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "Katrin White",
                        Designation = "Junior. Software Engineer",
                        FathersName = "Victor White",
                        MothersName = "Alexa White",
                        DateOfBirth = new DateTime(2021, 03, 17, 00, 00, 00)
                    }
                );
                context.SaveChanges();

            }
        }
    }
}
