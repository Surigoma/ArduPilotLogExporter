using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogDecoder;

namespace ArduPilotLogConverter
{
    public partial class Form1 : Form
    {
        LogDecoder ld = new LogDecoder();

        public Form1()
        {
            InitializeComponent();
        }

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Log File(*.log)|*.log|All Files|*.*",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = fileDialog.FileName;
            }
        }

        private void fileLoad_Click(object sender, EventArgs e)
        {
            if (filePathBox.Text == "")
            {
                MessageBox.Show("ファイルが選択されていません。");
                return;
            }
            if (!File.Exists(filePathBox.Text))
            {
                MessageBox.Show("ファイルが存在しません。\nファイルをご確認ください。");
                return;
            }
            try
            {
                StreamReader streamReader = new StreamReader(File.OpenRead(filePathBox.Text));

                loadTargetTreeView.Nodes.Clear();
                ld.init();
                ld.load(streamReader);

            }
            catch (FileLoadException err)
            {
                MessageBox.Show("ファイルが読み込めませんでした。 Errstr: " + err.Message);
                return;
            }
        }
    }
}
