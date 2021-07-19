using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void RemoveRojectTest() 
        {

            ProjectData project = new ProjectData()
            {
                Name = "new Project99",
                Description = "Testing Project"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "123"
            };

            List <ProjectData> oldProjects = app.API.GetProjectList(account);

            

            if (!oldProjects.Contains(project)) 
            {
                app.API.CreateProject(account, project);
                oldProjects = app.API.GetProjectList(account);
            }

            app.Projects.RemoveProject(project);

            List<ProjectData> newProjects = app.API.GetProjectList(account);

            oldProjects.RemoveAt(oldProjects.IndexOf(project));
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
