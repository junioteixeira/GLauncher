using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Controls;

namespace System.Windows.Forms
{
    public static class Extension
    {
        public static void AppendText(this RichTextBoxEx box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void Call<T>(this Control control, Action<T> action) 
            where T: Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() =>
                {
                    action(control as T);
                }));
            }
            else
            {
                action(control as T);
            }
        }
    }
}
