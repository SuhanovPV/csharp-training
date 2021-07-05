using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            Thread.Sleep(500);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux 
        {
            get 
            {
                return aux;
            }
        }

        public GroupHelper Groups 
        {
            get 
            {
                return groupHelper;
            }
        }
    }
}
