using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    internal class Salachirurgica
    {
 
        private string nome;
        public string Nome
        {
            get { return nome; }
        }
        private bool stato;
        public bool Stato
        {
            get { return stato; }
        }
        public DateTime Dataurgente;
        public DateTime Dataurgentissima;
        public DateTime Datanormale;
        
        public  Salachirurgica (string nome)
        {
            this.nome = nome;
        }
        public List<DateTime> prenotazioni = new List<DateTime>();
        public HashSet<DateTime> prenotazionii= new HashSet<DateTime>();
        public HashSet<DateTime> altredate= new HashSet<DateTime>();
        public List<Prenotazione> prenotazioni_sale= new List<Prenotazione>();
        public void stampa()
        {
            for (int i = 0; i < prenotazionii.Count; i++)
            {
                MessageBox.Show($"sala{prenotazioni[i]}");
            }
        }
        public DateTime DataUrgentissima()
        {
            int conta=0;
             DateTime data;
            do
            {
                conta = conta + 1;
                data=DateTime.Now.Date.AddDays(conta);
            }while((prenotazionii.Contains(data.Date)||altredate.Contains(data.Date)) &&conta<=31);
            if (prenotazionii.Contains(data) || altredate.Contains(data.Date))
            {
                Dataurgentissima = new DateTime(1, 1, 1);
                MessageBox.Show("La sala oppure il chirurgico Non è disponibile entro 31 giorni. Mi dispiace ");
            }
            else
            {
                 Dataurgentissima= data;
                MessageBox.Show(Dataurgentissima.ToString("dd-MM-yyyy"));
            }
            return Dataurgentissima;
        }
        public DateTime DataUrgente()
        {
            int conta = 0;
            DateTime data;
            do
            {
                conta = conta + 1;
                data = DateTime.Now.Date.AddDays(conta);
            } while ((prenotazionii.Contains(data) || altredate.Contains(data.Date))&& conta <= 100);
            if (prenotazionii.Contains(data) || altredate.Contains(data.Date))   
            {
                Dataurgente=new DateTime(1,1,1);
                MessageBox.Show("La sala oppure il chirurgico NON è disponibile entro 100 giorni. Mi dispiace ");
            }
            else
            {
                Dataurgente = data;
                MessageBox.Show(Dataurgente.ToString("dd-MM-yyyy"));
            }
            return Dataurgente;
        }
        public DateTime DataNormale()
        {
            Random mese = new Random();
            Random anno = new Random();
            Random giorno= new Random();
            DateTime data = DateTime.Now;


            do
            {
                int giornoo = giorno.Next(1, 28); // sceglie un giorno tra uno e 28 perchè se ad esempio viene scelto il numero 31 e il mese febbraio, in questo caso la data non sarà valida. 
                int mesee = mese.Next(1, 12);
                int annoo = anno.Next(data.Year + 1, data.Year+3);
                data = new DateTime(annoo, mesee, giornoo);
            } while (prenotazionii.Contains(data.Date)|| altredate.Contains(data.Date));
            Datanormale = data;
            MessageBox.Show(Datanormale.ToString("dd-MM-yyyy"));
            return Datanormale;
        }

      


    }
  
}
