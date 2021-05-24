using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void TheUntitledTestCaseTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(2);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
            loginHelper.LogOut();
        }
    }
}
