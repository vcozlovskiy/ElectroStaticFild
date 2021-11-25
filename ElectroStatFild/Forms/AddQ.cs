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
    internal partial class AddQ : Form
    {
        public ChargeList ChargeList;
        private PointF point;
        private PictureBox box;
        public AddQ(ChargeList charge, PointF point, PictureBox picture)
        {
            InitializeComponent();
            ChargeList = charge;
            this.point = point;
            box = picture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float.TryParse(textBox1.Text, out float q);
            if (q == 0)
            {
                MessageBox.Show("Введите заряд");
            }
            else
            {
                ChargeList.Charges.Add(new Charge(q, point));
            }
            box.Refresh();
            this.Close();
        }
    }
}
