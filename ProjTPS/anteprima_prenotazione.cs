using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    internal class Prenotazione : Anteprima
    {
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
        }

        public Prenotazione(DateTime data, string chirurgico, string paziente, string salaSelezionata, string gradoSelezionato) : base(chirurgico, paziente,  salaSelezionata,  gradoSelezionato)
        {
            this.data = data;
        }
       

    }
}
