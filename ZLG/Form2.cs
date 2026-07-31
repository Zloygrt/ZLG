using System;
using System.IO;
using System.Windows.Forms;

namespace ZLG
{
    public partial class Form2 : Form
    {
        private form1 parentForm;

        public Form2(form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filesavename = parentForm.GetFileName();

            if (!string.IsNullOrEmpty(filesavename))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    saveFileDialog.Title = "Сохранение";
                    saveFileDialog.FileName = filesavename;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, parentForm.GetFileContent());
                        MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        parentForm.SetHaveSave(true);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка. Убедитесь, что у файла есть имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
