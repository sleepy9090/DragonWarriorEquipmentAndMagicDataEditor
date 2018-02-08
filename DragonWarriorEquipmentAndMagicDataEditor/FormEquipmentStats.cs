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
    public partial class FormEquipmentStats : Form
    {
        string path;

        public FormEquipmentStats(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormEquipmentStats_Load(object sender, EventArgs e)
        {
            setMaxTextboxLength();
            loadROMEquipmentStats();
        }

        private void loadROMEquipmentStats()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPriceSingleByte(0x19E0);
            textBox2.Text = backend.getPriceSingleByte(0x19E1);
            textBox3.Text = backend.getPriceSingleByte(0x19E2);
            textBox4.Text = backend.getPriceSingleByte(0x19E3);
            textBox5.Text = backend.getPriceSingleByte(0x19E4);
            textBox6.Text = backend.getPriceSingleByte(0x19E5);
            textBox7.Text = backend.getPriceSingleByte(0x19E6);
            textBox8.Text = backend.getPriceSingleByte(0x19E8);
            textBox9.Text = backend.getPriceSingleByte(0x19E9);
            textBox10.Text = backend.getPriceSingleByte(0x19EA);
            textBox11.Text = backend.getPriceSingleByte(0x19EB);
            textBox12.Text = backend.getPriceSingleByte(0x19EC);
            textBox13.Text = backend.getPriceSingleByte(0x19ED);
            textBox14.Text = backend.getPriceSingleByte(0x19EE);
            textBox15.Text = backend.getPriceSingleByte(0x19F0);
            textBox16.Text = backend.getPriceSingleByte(0x19F1);
            textBox17.Text = backend.getPriceSingleByte(0x19F2);
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
            textBox11.MaxLength = 3;
            textBox12.MaxLength = 3;
            textBox13.MaxLength = 3;
            textBox14.MaxLength = 3;
            textBox15.MaxLength = 3;
            textBox16.MaxLength = 3;
            textBox17.MaxLength = 3;
        }

        private void buttonUpdateStats_Click(object sender, EventArgs e)
        {
            Backend backend = new Backend(path);

            bool result1 = backend.setPriceSingleByte(0x19E0, textBox1.Text);
            bool result2 = backend.setPriceSingleByte(0x19E1, textBox2.Text);
            bool result3 = backend.setPriceSingleByte(0x19E2, textBox3.Text);
            bool result4 = backend.setPriceSingleByte(0x19E3, textBox4.Text);
            bool result5 = backend.setPriceSingleByte(0x19E4, textBox5.Text);
            bool result6 = backend.setPriceSingleByte(0x19E5, textBox6.Text);
            bool result7 = backend.setPriceSingleByte(0x19E6, textBox7.Text);
            bool result8 = backend.setPriceSingleByte(0x19E8, textBox8.Text);
            bool result9 = backend.setPriceSingleByte(0x19E9, textBox9.Text);
            bool result10 = backend.setPriceSingleByte(0x19EA, textBox10.Text);
            bool result11 = backend.setPriceSingleByte(0x19EB, textBox11.Text);
            bool result12 = backend.setPriceSingleByte(0x19EC, textBox12.Text);
            bool result13 = backend.setPriceSingleByte(0x19ED, textBox13.Text);
            bool result14 = backend.setPriceSingleByte(0x19EE, textBox14.Text);
            bool result15 = backend.setPriceSingleByte(0x19EF, textBox15.Text);
            bool result16 = backend.setPriceSingleByte(0x19F1, textBox16.Text);
            bool result17 = backend.setPriceSingleByte(0x19F2, textBox17.Text);

            if (result1 && result2 && result3 && result4 && result5 && result6 && result7 && result8 && result9 && result10
                && result11 && result12 && result13 && result14 && result15 && result16 && result17)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox11);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox12);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox13);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox14);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox15_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox15);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox16_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox16);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox(sender, e);
        }

        private void textBox17_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox(sender, e, textBox17);
        }
        #endregion

        
    }
}
