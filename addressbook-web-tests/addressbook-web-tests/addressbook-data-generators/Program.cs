using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "groups")
            {
                GroupsGenerator(Convert.ToInt32(args[1]), args[2], args[3]);
            }
            else if (args[0] == "contacts")
            {
                ContactsGenerator(Convert.ToInt32(args[1]), args[2], args[3]);
            }
            else 
            {
                System.Console.Out.Write("Unknown data type: " + args[0]);
            }
            
        }

        static void GroupsGenerator(int count, string filename, string format)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(GroupGenerator());
            }

            if (format == "excel")
            {
                writeGroupsToXLSFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCSVFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXMLFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJSONFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unknowned format: " + format);
                }
                writer.Close();
            }
        }

        static void ContactsGenerator(int count, string filename, string format) 
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++) 
            {
                contacts.Add(ContactGenerator());
            }

            StreamWriter writer = new StreamWriter(filename);

            if (format == "xml")
            {
                writeContactsToXMLFile(contacts, writer);
            }
            else if (format == "json")
            {
                writeContactsToJSONFile(contacts, writer);
            }
            else 
            {
                System.Console.Out.Write("Unknowned format: " + format);
            }
            writer.Close();
        }

        static void writeGroupsToCSVFile(List<GroupData> groups, StreamWriter writer) 
        {
            foreach (GroupData group in groups) 
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));

            }            
        }

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJSONFile(List<GroupData> groups, StreamWriter writer) 
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToXLSFile(List<GroupData> groups, string filename) 
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet =  wb.ActiveSheet;

            int row = 1;

            foreach (GroupData group in groups) 
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static GroupData GroupGenerator() 
        {
            return new GroupData()
            {
                Name = TestBase.GenerateRandomString(10),
                Header = TestBase.GenerateRandomString(10),
                Footer = TestBase.GenerateRandomString(10)
            };
        }

        static ContactData ContactGenerator() {
            return new ContactData()
            {
                Name = TestBase.GenerateRandomString(30),
                LastName = TestBase.GenerateRandomString(30),
                MiddleName = TestBase.GenerateRandomString(30),
                Nickname = TestBase.GenerateRandomString(30),
                Title = TestBase.GenerateRandomString(30),
                Company = TestBase.GenerateRandomString(30),
                Address = TestBase.GenerateRandomString(100),
                HomePhone = TestBase.GenerateRandomPhone(),
                MobilePhone = TestBase.GenerateRandomPhone(),
                WorkPhone = TestBase.GenerateRandomPhone(),
                Fax = TestBase.GenerateRandomPhone(),
                Email = TestBase.GenerateRandomString(30),
                Email2 = TestBase.GenerateRandomString(30),
                Email3 = TestBase.GenerateRandomString(30),
                Homepage = TestBase.GenerateRandomString(100),
                Bday = TestBase.GenerateRandomDay(),
                Bmonth = TestBase.GenerateRandomMonth(),
                Byear = TestBase.GenerateRandomYear(),
                Aday = TestBase.GenerateRandomDay(),
                Amonth = TestBase.GenerateRandomMonth(),
                Ayear = TestBase.GenerateRandomYear(),
                Group = "ForContacts",
                Address2 = TestBase.GenerateRandomString(100),
                Phone2 = TestBase.GenerateRandomPhone(),
                Notes = TestBase.GenerateRandomString(30)
            };
        }
    }
}