using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectList(AccountData account) 
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] m_projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (Mantis.ProjectData m_project in m_projects) 
            {
                projects.Add(new ProjectData() { 
                    Name = m_project.name,
                    Description = m_project.description,
                    Id = m_project.id
                });
            }

            return projects;
        }

        public void CreateProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData m_project = new Mantis.ProjectData() 
            {
                name = project.Name,
                description = project.Description
            };
            client.mc_project_add(account.Name, account.Password, m_project);
        }

        public void DeleteProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }
    }
}
