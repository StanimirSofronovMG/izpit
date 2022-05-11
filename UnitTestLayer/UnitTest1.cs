using NUnit.Framework;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TestingLayer
{
    public class AreaContextUnitTest
    {
        private StanimirSofronovDbContext dbContext;
        private AreaContext AreaContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new StanimirSofronovDbContext(builder.Options);
            AreaContext = new AreaContext(dbContext);
        }

        [Test]
        public void TestCreateArea()
        {
            int AreasBefore = AreaContext.ReadAll().Count();

            AreaContext.Create(new Area("football"));

            int AreasAfter = AreaContext.ReadAll().Count();

            Assert.IsTrue(AreasBefore != AreasAfter);
        }

        [Test]
        public void TestReadArea()
        {
            AreaContext.Create(new Area("football"));

            Area Area = AreaContext.Read(1);

            Assert.That(Area != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateArea()
        {
            AreaContext.Create(new Area("football"));

            Area Area = AreaContext.Read(1);

            Area.Name = "basketball";
            AreaContext.Update(Area);

            Area Area1 = AreaContext.Read(1);

            Assert.IsTrue(Area1.Name == "basketball", "Area Update() does not change name!");
        }

        [Test]
        public void TestDeleteArea()
        {
            AreaContext.Create(new Area("football"));

            int AreasBefore = AreaContext.ReadAll().Count();

            AreaContext.Delete(1);

            int AreasAfter = AreaContext.ReadAll().Count();

            Assert.AreNotEqual(AreasBefore, AreasAfter);
        }
    }
}