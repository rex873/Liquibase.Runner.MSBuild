using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Reflection;

namespace Liquibase.Runner.MSBuild.Test
{
    public class LiquibaseTestAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            TestHelper.ClearDb();
        }

        public override void After(MethodInfo methodUnderTest)
        {
            TestHelper.ClearDb();
        }
    }
}
