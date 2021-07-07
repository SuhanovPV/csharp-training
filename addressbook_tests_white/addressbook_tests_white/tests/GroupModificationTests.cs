using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    class GroupModificationTests : TestBase
    {
        [Test]
        public void ModifyGroupTest() 
        {
            int index = 0;
            GroupData group = new GroupData() { Name = "NewName" };

            List<GroupData> oldGroupList = app.Groups.GetGroupList();

            app.Groups.ModifyGropAtIndex(index, group);

            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList[index].Name = group.Name;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
