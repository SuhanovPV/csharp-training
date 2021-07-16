using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_project_tests
{
    public class ProjectManagementHelper: HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.MenuHelper.GoToProjectsControl();
            IList<IWebElement> rows = driver.FindElements(By.TagName("tbody"))[0].FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows) 
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                projects.Add(new ProjectData {
                    Name = cells[0].Text,
                    State = cells[1].Text,
                    Visibility = cells[3].Text,
                    Description = cells[4].Text
                });
            }
            return projects;
        }

        public void RemoveProject(ProjectData project)
        {
            manager.MenuHelper.GoToProjectsControl();
            GoToProjectForm(project);
            SubmitProjectRemoval();
            ConfirmProjectRemoval();
            manager.MenuHelper.GoToProjectsControl();
        }

        public void CreateProject(ProjectData project)
        {
            manager.MenuHelper.GoToProjectsControl();
            driver.FindElement(By.XPath("//button[contains(text(), 'Создать')]")).Click();
            FillProjectForm(project);
            SubmitProjectForm();
            ReurnToProjects();
        }

        private void ConfirmProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SubmitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void GoToProjectForm(ProjectData project)
        {
            driver.FindElement(By.LinkText(project.Name)).Click();
        }

        private void ReurnToProjects()
        {
            if (IsElementPresent(By.LinkText("Продолжить"))) 
            {
                driver.FindElement(By.LinkText("Продолжить")).Click();
            } 
        }

        public void SubmitProjectForm()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            SelectValue(By.Name("status"), project.State);
            SetCheckBox(By.Name("inherit_global"), project.Inheritance);
            SelectValue(By.Name("view_state"), project.Visibility);
            Type(By.Name("description"), project.Description);
        }

        public void SetCheckBox(By locator, bool state)
        {
            if (state != IsCheckBoxChecked(locator)) 
            {
                driver.FindElement(By.CssSelector("span.lbl")).Click();
            }
        }

        private bool IsCheckBoxChecked(By locator)
        {
            if (driver.FindElement(locator).GetAttribute("checked") != null) 
            {
                return true;
            }
            return false;
        }
    }
}
