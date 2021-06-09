using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            if (app.Groups.IsGroupListEmpty()) 
            {
                app.Groups.Create(new GroupData("RemoveGroup"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(index);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(index);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
