using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ElectroStatFild.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectroStatFild
{
    internal partial class FildCharge : Form
    {
        public ChargeList ChargeList;
        public FildCharge()
        {
            InitializeComponent();
            ChargeList = new ChargeList();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AddQ addQ = new AddQ(ChargeList, e.Location, pictureBox1);
            addQ.Show();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Red);

            Fild fild = new Fild(ChargeList);

            foreach (Charge charge in ChargeList)
            {
                graphics.FillEllipse(brush, charge.location.X - 5,charge.location.Y - 5, 10f,10f);
            }

            fild.GetFildLians(sender, e, 2);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            ChargeList.Charges.Clear();
            pictureBox1.Refresh();
        }

        private void FildCharge_ClientSizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(this.Width - 175, this.Height);
            Удалить.Location = new Point(this.Width - 149, this.Height - 99);
        }
    }
}
