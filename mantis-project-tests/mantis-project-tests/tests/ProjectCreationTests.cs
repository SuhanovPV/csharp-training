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

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            if (oldProjects.Contains(project))
            {
                app.Projects.RemoveProject(project);
                oldProjects = app.Projects.GetProjectsList();
            }

            app.Projects.CreateProject(project);
            
            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
