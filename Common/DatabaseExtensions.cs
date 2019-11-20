using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleStore.Models;

namespace VehicleStore.Common
{
    public static class DatabaseExtensions
    {
        /// <summary>  
        /// Migrates the database.  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="webHost">The web host.</param>  
        /// <returns>IWebHost.</returns>  
        public static IWebHost CreateDatabase<T>(this IWebHost webHost) where T : VSDBContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    ex.LogException();
                }
            }
            return webHost;
        }
    }
}
