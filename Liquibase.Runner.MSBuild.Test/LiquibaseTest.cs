using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Liquibase.Runner.MSBuild;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Liquibase.Runner.MSBuild.Test
{
    public class LiquibaseTest
    {
        [Fact]
        [LiquibaseTest]
        public void PassingTest()
        {
            var task = new Liquibase
            {
                FileName = "update.batasdasdasd"
            };

            var result = task.Execute();
            Assert.True(result);
        }

        [Fact]
        [LiquibaseTest]
        public void FailingTest()
        {
            TestHelper.ExecuteCommand("CREATE TABLE `animal` (`Eye` VARCHAR(255))");

            var task = new Liquibase
            {
                FileName = "update.bat"
            };

            var result = task.Execute();
            Assert.False(result);
        }
    }
}
