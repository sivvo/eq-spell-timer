using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EQ_Parser
{

    // Create Event Arguments
    public class SpellBarEventArgs : EventArgs
    {
        public SpellBarEventArgs(string _SpellName, int _SpellDuration)
        {
            this.spellName = _SpellName;
            this.spellDuration = _SpellDuration;
        }

        public string spellName;
        public int spellDuration;

    }


    public partial class spellbar : UserControl
    {
        public int spellDuration = 0;
        public string spellName = "";
        public int TimesMatched = 0;
        private int internalCounter = 0;

        private bool bTimeIsUpDelegateCalled; // to call my time delegate once only

        public spellbar()
        {
            bTimeIsUpDelegateCalled = false;
            InitializeComponent();

        }

        // ok, i declare a delegate type ;
        public delegate void MyTimeIsUpEventHandler(object sender, SpellBarEventArgs e);

        // Then an event instance that i ll call when my timer reach 0
        public event MyTimeIsUpEventHandler TimeIsUpEvent;  

        public void EnableBox()
        {
            // set the spell duration and bar
            lblspellname.Text = spellName;
            progress.Maximum = spellDuration;
            progress.Maximum = spellDuration;
            internalCounter = 0;
            timer1.Enabled = true;
        }


        public void timer1_Tick(object sender, EventArgs e)
        {

            if (progress.Value > 0)
            {
                progress.Value -= 1;
                lbltimeleft.Text = Convert.ToString(progress.Value) + "s";
            }
            else
            {
                // YGE : Just to call it once
                if(!bTimeIsUpDelegateCalled)
                {
                    bTimeIsUpDelegateCalled = true;

                    // YGE : so, i create an argument and fill it
                    SpellBarEventArgs Args = new SpellBarEventArgs(spellName, spellDuration);

                    TimeIsUpEvent(this, Args); 
                }

                internalCounter++;
                if (internalCounter % 2 == 0)
                {
                    groupBox1.BackColor = System.Drawing.Color.White;
                    //lblspellname.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    groupBox1.BackColor = System.Drawing.Color.Gray;
                    //lblspellname.ForeColor = System.Drawing.Color.Blue;
                }
            }


        }

        private void lblspellname_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                EnableBox();
            }
        }
    }

}
