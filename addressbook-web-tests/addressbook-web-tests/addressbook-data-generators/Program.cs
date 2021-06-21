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
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];

            List<GroupData> groups = new List<GroupData>(); 
            for (int i = 0; i < count; i++) 
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10)) 
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
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

        static void writeGroupsToCSVFile(List<GroupData> groups, StreamWriter writer) 
        {
            foreach (GroupData group in groups) 
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Name));

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
            sheet.Cells[1, 1] = "test";

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
    }
}