﻿using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
