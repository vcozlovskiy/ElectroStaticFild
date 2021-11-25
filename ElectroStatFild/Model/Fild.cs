using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ElectroStatFild;

namespace ElectroStatFild.Model
{
    internal class Fild
    {
        public ChargeList ChargeList
        {
            get
            {
                return chargeList;
            }
            private set
            {

            } 
        }

        private ChargeList chargeList;

        public Fild(ChargeList chargeList)
        {
            this.chargeList = chargeList;
        }

        public void GetFildLians(object sender,PaintEventArgs e, float step)
        {
            PictureBox picture = sender as PictureBox;
            Graphics graphics = e.Graphics;
            SolidBrush f = new SolidBrush(Color.Black);
            ChargeList = chargeList;
            float[,] marixFild = GetMatrixFild(picture, step);

            float maxValue = 1000;


            for (float tempValue = 0; tempValue < maxValue; tempValue += maxValue / 10)
            {
                for (int i = 0; i <= marixFild.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= marixFild.GetUpperBound(1); j++)
                    {
                        if (marixFild[i, j] > tempValue &&
                            marixFild[i, j] < tempValue + 10)
                        {
                            graphics.FillRectangle(f, j * step, i * step, step, step);
                        }
                    }
                }
            }
        }

        private float[,] GetMatrixFild(PictureBox picture, float step)
        {
            if (picture == null)
            {
                throw new ArgumentNullException();
            }

            float tempE = 0;
            float[,] matrixFild = new float[(int)(picture.Height / step + 1),
                (int)(picture.Width / step + 1)];

            for (float x = 0; x < picture.Width; x += step)
            {
                for (float y = 0; y < picture.Height; y += step)
                {
                    tempE = Math.Abs(GetSuperpozitionElectricFild(new PointF(x, y)));
                    matrixFild[(int)(y / step), (int)(x / step)] = tempE;
                }
            }

            return matrixFild;
        }

        private float GetSuperpozitionElectricFild(PointF point)
        {
            float elecricFildValue = 0;

            foreach (Charge charge in ChargeList)
            {
                elecricFildValue += charge.GetE(point);
            }

            return elecricFildValue;
        }
    }
}
