using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWID_lock
{
    static class Program
    {
        private static string GetHWID()
        {
            RegistryKey registryKey;

            if (Environment.Is64BitOperatingSystem)
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            }

            return registryKey.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion").GetValue("ProductId").ToString();
        }

        [STAThread]
        static void Main()
        {
            string userid = GetHWID();
            string[] users = new string[100];
            users[0] = "00330-53530-77725-AAOEM"; // your hardware id   0 ~ 100
            users[1] = ""; // your hardware id
            users[2] = ""; // your hardware id 
            users[3] = ""; // your hardware id
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == GetHWID())
                {
                    MessageBox.Show("Welcome");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;
                }
                else
                {
                    MessageBox.Show("하드번호가 맞지 않습니다.");
                    return;
                }
            }
        }
    }
}
