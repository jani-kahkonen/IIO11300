using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class MittausData
    {
        private string kello, mittaus, nimi;

        public string Kello
        {
            get { return kello; }
            set { kello = value; }
        }
        public string Nimi
        {
            get { return nimi; }
            set { nimi = value; }
        }
        public string Mittaus
        {
            get { return mittaus; }
            set { mittaus = value; }
        }

        #region CONSTRUCTORS
        //luokalle tehdään kaksi konstruktoria
        public MittausData()
        {
            kello = "0:00";
            mittaus = "empty";
            nimi = "name";
        }
        public MittausData(string klo, string mdata, string name)
        {
            this.kello = klo;
            this.mittaus = mdata;
            this.nimi = name;
        }
        #endregion
        //ylikirjoitetaan ToString
        public override string ToString()
        {
            return "PVM: " + kello + " FILE: " + mittaus + " NAME: " + nimi;
        }
    }
}
