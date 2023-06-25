﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

[assembly: HostingStartup(typeof(SpeedHostingStartup))]

namespace SpeedBoot.AspNetCore;

public class SpeedHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((webHostBuilderContext, services) =>
        {
            services.AddSpeed(options =>
            {
                var assemblyName = webHostBuilderContext.Configuration["SpeedBoot:AssemblyName"];
                if (assemblyName != null) options.AssemblyName = assemblyName;

                options.Configuration = webHostBuilderContext.Configuration;
                options.Environment = webHostBuilderContext.HostingEnvironment.EnvironmentName;
            });
        });
    }
}