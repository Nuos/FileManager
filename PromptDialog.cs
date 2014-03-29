using System.Windows.Forms;

namespace FileManager
{
    public static class PromptDialog
    {
        public static string ShowDialog(string text, string caption)
        {
            var prompt = new Form {Width = 300, Height = 150, Text = caption};
            var textLabel = new Label {Left = 50, Top = 20, Text = text};
            var textBox = new TextBox {Left = 50, Top = 50, Width = 180};
            var confirmation = new Button {Text = "Ok", Left = 90, Width = 100, Top = 70};
            confirmation.Click += (sender, e) => prompt.Close();
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}