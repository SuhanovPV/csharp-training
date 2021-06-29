using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest() 
        {
            int index = 0;

            GroupData newData = new GroupData("sss");
            newData.Header = null;
            newData.Footer = null;

            if (app.Groups.IsGroupListEmpty())
            {
                app.Groups.Create(new GroupData("RemoveGroup"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldDate = oldGroups[index];

            app.Groups.Modify(oldDate.Id, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[index].Name = newData.Name;

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups) 
            {
                if (group.Id == oldDate.Id) 
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
