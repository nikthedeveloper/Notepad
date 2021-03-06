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

namespace Notepad
{
    public partial class TextEditorForm : Form
    {
        #region Vars
        private string fileName;
        private bool isEdit;
        #endregion  

        private string FileName { get { return fileName; } set { fileName = value; } }
        private bool IsEdit { get { return isEdit; } set { isEdit = value; } }

        public TextEditorForm()
        {
            InitializeComponent();
            FileName = " ";
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Text = openFileDialog.FileName;
                FileName = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(FileName);
            }
            else
            {
                Text = "Новый документ";
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (!FileName.Contains(" "))
            {
                File.WriteAllText(FileName, textBox.Text);
            }
            else
            {
                saveFileDialog.ShowDialog();
                if (!saveFileDialog.FileName.Contains(".txt"))
                {
                    File.WriteAllText(saveFileDialog.FileName + ".txt", textBox.Text);
                    this.Text = saveFileDialog.FileName;
                }
                else
                {
                    File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                    this.Text = saveFileDialog.FileName;
                }
            }
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsEdit)
            {
                this.Close();
            }
            else
            {
                if (!FileName.Contains(" "))
                {
                    File.WriteAllText(FileName, textBox.Text);
                }
                else
                {
                    saveFileDialog.ShowDialog();
                    File.WriteAllText(saveFileDialog.FileName + ".txt", textBox.Text);
                    this.Text = saveFileDialog.FileName;
                }
            }
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
            textBox.Font = fontDialog.Font;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            IsEdit = true;
        }
    }
}
