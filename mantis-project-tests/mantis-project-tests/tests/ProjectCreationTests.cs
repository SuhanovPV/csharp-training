using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest() 
        {
            ProjectData project = new ProjectData()
            {
                Name = "new Project",
                State = "выпущен",
                Inheritance = true,
                Visibility = "публичный",
                Description = "Testing Project"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "123"
            };

            List<ProjectData> oldProjects = app.API.GetProjectList(account);
            ProjectData existingProject = oldProjects.Find(x => x.Name == project.Name);

            if (existingProject != null)
            {
                app.API.DeleteProject(account, existingProject);
                oldProjects = app.API.GetProjectList(account);
            }

            app.Projects.CreateProject(project);
            
            List<ProjectData> newProjects = app.API.GetProjectList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
