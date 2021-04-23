using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace CoronaXml
{
    public partial class Form1 : Form
    {
        XElement root,root2;

        public Form1()
        {
            InitializeComponent();
            if (!(System.IO.File.Exists("Corona.txt")))
            {
                root = XElement.Load("https://data.cityofnewyork.us/api/views/7xjx-2mhj/rows.xml?accessType=DOWNLOAD");
                root.Save("Corona.txt");
                MessageBox.Show("Yeni bir XML dosyası oluşturuldu.");
                timer1.Enabled = true;
            }
            else
            {
                root = XElement.Load("Corona.txt");
                MessageBox.Show("XML dosyası okundu");
                timer1.Enabled = true;
            }

        }

        void guncelle()
        {

            root = XElement.Load("https://data.cityofnewyork.us/api/views/7xjx-2mhj/rows.xml?accessType=DOWNLOAD");
            root.Save("Corona.txt");
            MessageBox.Show("Bilgiler güncellendi");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            root2 = XElement.Load("https://data.cityofnewyork.us/api/views/7xjx-2mhj/rows.xml?accessType=DOWNLOAD");
            if(root.Elements().Elements().ToList().Count!= root2.Elements().Elements().ToList().Count)
            {
                timer1.Enabled = false;
                guncelle();
            }
        }
    }
}
