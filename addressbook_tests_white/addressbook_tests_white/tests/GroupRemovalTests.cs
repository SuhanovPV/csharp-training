using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {
        [Test]
        public void TestRemoveGroup() 
        {
            int index = 1;
            List<GroupData> oldGroupList = app.Groups.GetGroupList();

            if (oldGroupList.Count == 1)
            {
                GroupData group = new GroupData() { Name = "1" };
                app.Groups.Add(group);
                oldGroupList.Add(group);
                oldGroupList.Sort();
            }

            app.Groups.RemoveGroupAtIndex(index);

            List<GroupData> newGroupList = app.Groups.GetGroupList();
            oldGroupList.RemoveAt(index);

            Assert.AreEqual(oldGroupList, newGroupList);

        }
    }
}
