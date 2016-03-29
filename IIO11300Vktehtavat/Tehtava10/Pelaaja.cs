using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    class Pelaaja
    {
        private String etunimi, sukunimi, seura;
        private int hinta;

        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        public int Hinta
        {
            get { return hinta; }
            set { hinta = value; }
        }

        public string Seura
        {
            get { return seura; }
            set { seura = value; }
        }

        private string getKokonimi()
        {
            return etunimi + " " + sukunimi;
        }

        public string getEsitysnimi()
        {
            return etunimi + " " + sukunimi + ", " + seura;
        }

        #region CONSTRUCTORS
        public Pelaaja(string a, string b, int c, string d)
        {
            this.etunimi = a;
            this.sukunimi = b;
            this.hinta = c;
            this.seura = d;
        }
        #endregion
    }
}