using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szukacz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += new EventHandler(Form2_Load);

        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            string startFolder = @"c:\windows\media";

            // Take a snapshot of the file system.  
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //Create the query  
            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                where file.Extension == ".wav"
                orderby file.Name
                select file;

            //Execute the query. This might write out a lot of files!  
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text += fi.FullName + '\n';
               // Console.WriteLine(fi.FullName);
            }
    //        richTextBox1.ForeColor = Color.Red;
   //        richTextBox1.Text = "Pokaz";
   //         System.Diagnostics.Debug.WriteLine("Load");



        }
    }
}
