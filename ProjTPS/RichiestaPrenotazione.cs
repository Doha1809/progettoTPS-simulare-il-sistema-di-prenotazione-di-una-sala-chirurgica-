using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    internal class RichiestaPrenotazione
    {

        public int Urgenza; 
        public Thread Thread;
        public string Nome_chirurga;
        public RichiestaPrenotazione(string Nome_chirurga ,int urgenza, Thread thread)
        {
            Urgenza = urgenza;
            Thread = thread;
            this.Nome_chirurga = Nome_chirurga;
        }
    }
}

