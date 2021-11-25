using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroStatFild.Model
{
    internal class ChargeList : IEnumerable
    {
        public List<Charge> Charges { get;  }

        internal Fild Fild
        {
            get => default;
            set
            {
            }
        }

        public ChargeList()
        {
            Charges = new List<Charge>();
        }

        public void AddQ(Charge charge)
        {
            Charges.Add(charge);
        }

        public IEnumerator GetEnumerator()
        {
            return Charges.GetEnumerator();
        }
    }
}
