using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    internal class Anteprima
    {
        

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
        private string salaSelezionata;
        public string SalaSelezionata
        {
            get { return salaSelezionata; }
        }
        private string gradoSelezionato;
        public string GradoSelezionato
        {
            get { return gradoSelezionato; }
        }
        
        public Anteprima(string chirurgico, string paziente, string salaSelezionata, string gradoSelezionato)
        {
            this.chirurgico= chirurgico;
            this.paziente= paziente;
            this.salaSelezionata= salaSelezionata;
        }
       
        
    }
}
