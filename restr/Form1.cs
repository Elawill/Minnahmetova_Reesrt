using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace restr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey Key1 = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System");//чтение реестра
            string iden = (string)Key1.GetValue("Identifier");
            string sys = (string)Key1.GetValue("SystemBiosDate");
            string vid = (string)Key1.GetValue("VideoBiosDate");
            Key1.Close();
            string key1 = iden + sys + vid;

            RegistryKey currentUserKey = Registry.CurrentUser;//чтение программы
            RegistryKey Key = currentUserKey.OpenSubKey(@"Software\Programm_reestr\Settings");
            string key2 = Key.GetValue("KEY").ToString();
            Key.Close();

            int login = Convert.ToInt16(textBox1.Text);
            int password = Convert.ToInt16(textBox2.Text);
           
            if (login == 123 && password == 123)
            {
                if (key1 != key2)
                {
                    MessageBox.Show("Обратитесь к разработчику программы", "Ошибка");
                }
                else
                    MessageBox.Show("Программа работает", "");
            }
            else
                MessageBox.Show("Введите верный пароль или логин", "Ошибка");

        }
    }
}
