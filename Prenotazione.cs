using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    internal class Prenotazione
    {
        private DateTime data;
        public DateTime Data
        { 
            get { return data; }
        }

        private string chirurgico;
        public string Chirurgico
        {
            get { return chirurgico; }

        }
        private string paziente;
        public string Paziente
        {
            get { return paziente; }

        }
        public Prenotazione(DateTime data, string chirurgico, string paziente)
        {
            this.data = data;
            this.chirurgico= chirurgico;
            this.paziente= paziente;
        }

    }
}
