using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ElectroStatFild.Model
{
    class Charge
    {
        public PointF location;
        public float q;
        static float K = (float)(9 * Math.Pow(10, 9));

        public Charge(float q, PointF point)
        {
            this.q = q;
            location = point;
        }

        internal ChargeList ChargeList
        {
            get => default;
            set
            {
            }
        }

        public float GetE(PointF point)
        {
            float E;

            E = (float)(K * q / (Math.Pow(point.GetLength(this.location), 2)));

            if (float.IsInfinity(E))
            {
                E = 0;
            }
            return E;
        }
    }

    static public class GeterLength
    {
        public static float GetLength(this PointF point1, PointF point2)
        {
            float delnaX = Math.Abs(point1.X - point2.X);
            float deltaY = Math.Abs(point1.Y - point2.Y);

            return (float)Math.Sqrt(delnaX * delnaX + deltaY * deltaY);
        }
    }
}
