using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class IkkunaVE0
    {
        // Tehdään public, ÄLÄ KÄYTÄ! Edustaa "huonoa" ohjelmointitapaa
        public double leveys, korkeus;
        public double LaskePintaala()
        {
            return leveys * korkeus;
        }
    }

    public class Ikkuna
    {
        // Properties
        // Property = Ominaisuus
        // Parempi tapa on avata "hallitusti" olio ominaisuuksien kautta
        private double korkeus;
        private double leveys;

        public double Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        // Read-only tyyppinen property
        public double PintaAla
        {
            get
            {
                //return korkeus * leveys;
                return LaskeIPintaAla();
            }
        }

        // Metodit
        public double LaskePintaala()
        {
            return LaskeIPintaAla();
        }

        private double LaskeIPintaAla()
        {
            return korkeus * leveys;
        }
    }
}
