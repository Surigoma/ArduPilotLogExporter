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
using ArduPilotLogConverter;

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
                infilePathBox.Text = fileDialog.FileName;
            }
        }

        private void fileLoad_Click(object sender, EventArgs e)
        {
            if (infilePathBox.Text == "")
            {
                MessageBox.Show("ファイルが選択されていません。");
                return;
            }
            if (!File.Exists(infilePathBox.Text))
            {
                MessageBox.Show("ファイルが存在しません。\nファイルをご確認ください。");
                return;
            }
            try
            {
                StreamReader streamReader = new StreamReader(File.OpenRead(infilePathBox.Text));

                loadTargetTreeView.Nodes.Clear();
                ld.init();
                ld.load(streamReader);
                foreach (KeyValuePair<string, LogFormat> valuePair in ld.Formats)
                {
                    TreeNode node = loadTargetTreeView.Nodes.Add(valuePair.Key);
                    foreach (LogFormatValue formatValue in valuePair.Value.values)
                    {
                        node.Nodes.Add(formatValue.name);
                    }
                }

            }
            catch (FileLoadException err)
            {
                MessageBox.Show("ファイルが読み込めませんでした。 Errstr: " + err.Message);
                return;
            }
        }

        private void loadTargetTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int checkCount = 0;
            if (e.Action != TreeViewAction.ByMouse)
            {
                return;
            }
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
            if (e.Node.Parent != null)
            {
                foreach (TreeNode node in e.Node.Parent.Nodes)
                {
                    if (node.Checked) { checkCount++; }
                }
                if (checkCount == 0)
                {
                    e.Node.Parent.Checked = false;
                }
                if (checkCount >= 1)
                {
                    e.Node.Parent.Checked = true;
                }
            }
        }

        private void outputFile_Click(object sender, EventArgs e)
        {
            List<string> Categories = new List<string>();
            List<string> Items = new List<string>();
            foreach (TreeNode node in loadTargetTreeView.Nodes)
            {
                if (!node.Checked) { continue; }
                Categories.Add(node.Text);
                foreach (TreeNode node2 in node.Nodes)
                {
                    if (!node2.Checked) { continue; }
                    Items.Add(node.Text+ "." + node2.Text);
                }
            }
            ld.writeFile(Categories.ToArray(), Items.ToArray(), outfilePathBox.Text);
            MessageBox.Show("Outputted.");
        }

        private void saveFileSelectButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File(*.csv)|*.csv|All Files|*.*";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outfilePathBox.Text = saveFileDialog.FileName;
            }
        }
    }
}
