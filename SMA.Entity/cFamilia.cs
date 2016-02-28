using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
    public class cFamilia: cComponente
    {
        private int _EstatusID;

        public int EstatusID
        {
            get { return _EstatusID; }
            set { _EstatusID = value; }
        }
    }
}
