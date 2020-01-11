using Core;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            txtProgramA.Text = @"C:\Program Files\Notepad++\notepad++.exe";
            txtProgramB.Text = @"C:\Windows\System32\notepad.exe"; 
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            txtProgramA.Text = string.Empty;
            txtProgramB.Text = string.Empty;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var programA = txtProgramA.Text;
            var programB = txtProgramB.Text;

            if (string.IsNullOrWhiteSpace(programA) || string.IsNullOrWhiteSpace(programA))
            {
                MessageBox.Show("Check your paths for program A and program B");
            }
            else
            {
                var processWatcher = new ProcessWatcherWrapper();
                processWatcher.Execute(programA, programB);
            } 
        }
    }
}
