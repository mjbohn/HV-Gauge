using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GaugeTestapp
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void rndtimer_Tick(object sender, EventArgs e)
        {

            foreach (Control con in this.Controls)
            {
                if (con is Mich3l.Controls.Gauges.HVGauge)
                {
                    (con as Mich3l.Controls.Gauges.HVGauge).GaugePercent = rnd.Next(0, 1000) / 10;
                }
            }
        }

        

        

        

        

       

        

        
    }
}
