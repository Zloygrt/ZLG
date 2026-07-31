using System;
using System.IO;
using System.Windows.Forms;

namespace ZLG
{
    public partial class form1 : Form
    {
        private bool havesave = true;


        private void havex()
        {
            if (havesave == false)
            {
                label3.Text = "*";
            }
            else
            {
                label3.Text = "";
            }
        }

        public form1()
        {
            InitializeComponent();
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            havesave = false;
            havex();
        }

        public void SetHaveSave(bool value)
        {
            havesave = value;
            havex();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Выберите место для создания файла";
                saveFileDialog.FileName = "unnamed.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, string.Empty);
                    textBox2.Text = Path.GetFileName(saveFileDialog.FileName);
                    SetHaveSave(true);
                    MessageBox.Show("Файл успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = Path.GetFileName(openFileDialog.FileName);
                    string text = File.ReadAllText(openFileDialog.FileName);
                    textBox1.Text = text;
                    SetHaveSave(true);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        public string GetFileName()
        {
            return textBox2.Text;
        }

        public string GetFileContent()
        {
            return textBox1.Text;
        }

        private void ctrls()
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!havesave)
            {
                Form2 form2 = new Form2(this);
                form2.ShowDialog();

                if (!havesave)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
