// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Speed.Boot.Data.EFCore.Tests;

[TestClass]
public class DbContextTest
{
    [TestMethod]
    public void Add()
    {
        var services = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.json");
        var configurationRoot = configurationBuilder.Build();
        services.AddConfiguration(configurationRoot);
        services.AddSpeed();
        services.AddSpeedDbContext<TestDbContext>(speedDbContextOptionsBuilder => speedDbContextOptionsBuilder.UseSqlServer());
        var serviceProvider = services.BuildServiceProvider();
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();
            dbContext.Database.EnsureCreated();
            var user = new User()
            {
                Name = "speed",
                CreateTime = DateTime.Today,
                UpdateTime = DateTime.Now
            };
            dbContext.User.Add(user);
            var effectRow = dbContext.SaveChanges();
            Assert.AreEqual(1, effectRow);
        }
    }
}