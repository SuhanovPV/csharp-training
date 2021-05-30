using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {      

        [Test]
        public void GroupCreationTest()
        {
            // testing data
            GroupData group = new GroupData("ANN");
            group.Header = "HHH";
            group.Footer = "FFF";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            // testing data
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            
        }
    }
}
