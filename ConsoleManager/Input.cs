using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DevExpress;


    class Input
    {
       
        public static DialogResult InputBox(string title, string promptText, ref string text)
        {

            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            
            form.Text = title;
            label.Text = promptText;
            textBox.Text = text;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.ForeColor = Color.White;
            buttonCancel.ForeColor = Color.White;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            
            buttonOk.ForeColor = Color.White;
            buttonCancel.ForeColor = Color.White;
            textBox.ForeColor = Color.White;
            textBox.BackColor = Color.FromArgb(95, 95, 95);

            label.ForeColor = Color.White;
            form.BackColor = Color.FromArgb(45, 45, 48);
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            text = textBox.Text;
            return dialogResult;
        }
    }

    