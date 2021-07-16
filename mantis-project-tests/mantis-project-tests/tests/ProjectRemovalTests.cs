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
                Name = "new Project1",
                State = "выпущен",
                Inheritance = true,
                Visibility = "публичный",
                Description = "Testing Project"
            };

            List <ProjectData> oldProjects = app.Projects.GetProjectsList();

            if (!oldProjects.Contains(project)) 
            {
                app.Projects.CreateProject(project);
                oldProjects = app.Projects.GetProjectsList();
            }

            app.Projects.RemoveProject(project);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(oldProjects.IndexOf(project));
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
