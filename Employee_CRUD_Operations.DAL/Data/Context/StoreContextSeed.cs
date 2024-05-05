using Employee_CRUD_Operations.DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.DAL.Data.Context
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext.StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Departments.Any())
                {
                    var departmentsData = File.ReadAllText("../Employee_CRUD_Operations.DAL/Data/SeedData/department.json");
                    var departments = JsonSerializer.Deserialize<List<Departments>>(departmentsData);
                    foreach (var department in departments)
                        context.Departments.Add(department);

                    await context.SaveChangesAsync();

                }
                if (!context.Users.Any())
                {
                    var usersData = File.ReadAllText("../Employee_CRUD_Operations.DAL/Data/SeedData/user.json");
                    var users = JsonSerializer.Deserialize<List<Users>>(usersData);
                    foreach (var user in users)
                        context.Users.Add(user);

                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
