using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Tehtava4
{
    [Serializable()]    //Set this attribute to all the classes that want to serialize
    public class Pelaaja
    {       
        private String etunimi { get; set; }   
        private String sukunimi { get; set; }
        private String seura { get; set; }
        private int hinta { get; set; }
        private String polku { get; set; }

        public string Polku
        {
            get { return polku; }
            set { polku = value; }
        }

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
        public Pelaaja()
        {

        }
        public Pelaaja(string a, string b, int c, string d, string e)
        {
            this.etunimi = a;
            this.sukunimi = b; 
            this.hinta = c;
            this.seura = d;
            this.polku = e;
        }
        #endregion
    }
}
