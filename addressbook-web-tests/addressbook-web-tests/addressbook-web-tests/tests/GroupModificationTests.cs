using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest() 
        {
            GroupData newData = new GroupData("sss");
            newData.Header = null;
            newData.Footer = null;

            int index = 0;

            if (app.Groups.IsGroupListEmpty())
            {
                app.Groups.Create(new GroupData("RemoveGroup"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(index, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
