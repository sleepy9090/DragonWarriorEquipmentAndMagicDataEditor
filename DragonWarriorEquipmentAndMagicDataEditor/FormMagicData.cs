using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 2018+
 */
namespace DragonWarriorEquipmentAndMagicDataEditor
{
    public partial class FormMagicData : Form
    {
        string path;

        public FormMagicData(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormMagicData_Load(object sender, EventArgs e)
        {
            setMaxTextboxLength();
            loadROMMagicData();
        }

        private void loadROMMagicData()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPriceSingleByte(0x1D63);
            textBox2.Text = backend.getPriceSingleByte(0x1D64);
            textBox3.Text = backend.getPriceSingleByte(0x1D65);
            textBox4.Text = backend.getPriceSingleByte(0x1D66);
            textBox5.Text = backend.getPriceSingleByte(0x1D67);
            textBox6.Text = backend.getPriceSingleByte(0x1D68);
            textBox7.Text = backend.getPriceSingleByte(0x1D69);
            textBox8.Text = backend.getPriceSingleByte(0x1D6A);
            textBox9.Text = backend.getPriceSingleByte(0x1D6B);
            textBox10.Text = backend.getPriceSingleByte(0x1D6C);
        }

        private void setMaxTextboxLength()
        {
            // 255
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 3;
            textBox4.MaxLength = 3;
            textBox5.MaxLength = 3;
            textBox6.MaxLength = 3;
            textBox7.MaxLength = 3;
            textBox8.MaxLength = 3;
            textBox9.MaxLength = 3;
            textBox10.MaxLength = 3;
        }

        private void buttonUpdateMagicData_Click(object sender, EventArgs e)
        {
            Backend backend = new Backend(path);

            bool result1 = backend.setPriceSingleByte(0x1D63, textBox1.Text);
            bool result2 = backend.setPriceSingleByte(0x1D64, textBox2.Text);
            bool result3 = backend.setPriceSingleByte(0x1D65, textBox3.Text);
            bool result4 = backend.setPriceSingleByte(0x1D66, textBox4.Text);
            bool result5 = backend.setPriceSingleByte(0x1D67, textBox5.Text);
            bool result6 = backend.setPriceSingleByte(0x1D68, textBox6.Text);
            bool result7 = backend.setPriceSingleByte(0x1D69, textBox7.Text);
            bool result8 = backend.setPriceSingleByte(0x1D6A, textBox8.Text);
            bool result9 = backend.setPriceSingleByte(0x1D6B, textBox9.Text);
            bool result10 = backend.setPriceSingleByte(0x1DC3, textBox10.Text);

            if (result1 && result2 && result3 && result4 && result5 && result6 && result7 && result8 && result9 && result10)
            {
                MessageBox.Show("ROM updated!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("ROM update failed.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        #region textbox validation


        private void validateTextBox(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (char.IsDigit(keypress) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                // 
            }
            else
            {
                MessageBox.Show("This must be a numeric value, inclusive, between 0 and 255.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                e.Handled = true;
            }
        }

        private void validateTextBox(object sender, KeyEventArgs e, TextBox textBox)
        {
            int value;

            if (int.TryParse(textBox.Text, out value))
            {
                if (value > 255)
                {
                    textBox.Text = "255";
                }
            }
            else
            {
                // Should not happen.
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox1);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox2);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox3);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox4);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox5);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox6);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox7);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox8);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox9);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox10);
        }
        #endregion
    }
}
