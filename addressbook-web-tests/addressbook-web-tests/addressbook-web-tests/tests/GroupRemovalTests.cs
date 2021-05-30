using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsGroupListEmpty()) 
            {
                app.Groups.Create(new GroupData("RemoveGroup"));
            }
            app.Groups.Remove(1);
        }
    }
}
