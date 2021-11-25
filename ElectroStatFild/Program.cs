using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ElectroStatFild.Model;

namespace ElectroStatFild
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ChargeList charges = new ChargeList();
            charges.Charges.Add(new Charge(1, new PointF()));
            charges.Charges.Add(new Charge(2, new PointF()));
            charges.Charges.Add(new Charge(3, new PointF()));

            Application.Run(new FildCharge());
        }
    }
}
