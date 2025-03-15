using System.Threading;

namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    public partial class Form1 : Form
    {
        SalaInvasiva salainvasiva;
        SalaSpecializzata salaspecializzata;
        SalaGenerale salagenerale;
        DateTime data_salagenerale;
        DateTime data_salaspecializzata;
        DateTime data_salainvasiva;
        Semaphore semaforo;
        Thread thread_raccoltarichieste;
        List<Thread> lista_thread;
        List<Anteprima> anteprima_prenotazioni;
        PriorityQueue<RichiestaPrenotazione, int> codaPrenotazioniSG;
        PriorityQueue<RichiestaPrenotazione, int> codaPrenotazioniSS;
        PriorityQueue<RichiestaPrenotazione, int> codaPrenotazioniSI;
         

        public Form1()
        {
            InitializeComponent();
            salainvasiva = new SalaInvasiva("salainvasiva");
            salaspecializzata = new SalaSpecializzata("salaspecializzata");
            salagenerale = new SalaGenerale("salagenerale");
            semaforo = new Semaphore(1, 1); //Permette solo un thread alla volta
            button2.Visible = false;
            thread_raccoltarichieste = new Thread(raccolta_richieste);
            anteprima_prenotazioni = new List<Anteprima>();
            codaPrenotazioniSG = new PriorityQueue<RichiestaPrenotazione, int>();
            codaPrenotazioniSS = new PriorityQueue<RichiestaPrenotazione, int>();
            codaPrenotazioniSI = new PriorityQueue<RichiestaPrenotazione, int>();
            


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = false;
            label3.Visible=false;
            label5.Visible = false;
            comboBox2.Items.Add("SALA GENERALE");
            comboBox2.Items.Add("SALA SPECIALIZZATA");
            comboBox2.Items.Add("SALA INVASIVA");

            comboBox1.Items.Add("MOLTO URGENTE");
            comboBox1.Items.Add("URGENTE");
            thread_raccoltarichieste.Start();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button1.Visible = true;
            DateTime data_nonvalida = new DateTime(1, 1, 1);
            if (comboBox2.SelectedIndex == 0 && data_salagenerale != data_nonvalida)
            {
                if (codaPrenotazioniSG.Count > 0)
                {
                    var richiesta_SG = codaPrenotazioniSG.Dequeue();
                    salagenerale.altredate.Clear();
                    Thread thread = richiesta_SG.Thread;
                    string chirurga = richiesta_SG.Nome_chirurga;
                    MessageBox.Show($"Il chirurga {chirurga}potrà prenotare ora");

                    semaforo.WaitOne();
                    thread.Start();
                    semaforo.Release();
                    button2.Visible = false;
                }
                else
                    MessageBox.Show("Non ci sono più richieste di prenotazione");
            }
             else
                 if (comboBox2.SelectedIndex == 1 && data_salaspecializzata != data_nonvalida)
             {
                if (codaPrenotazioniSS.Count > 0)
                {

                    var richiesta_SS = codaPrenotazioniSS.Dequeue();
                    salaspecializzata.altredate.Clear();
                    Thread thread = richiesta_SS.Thread;
                    string chirurga = richiesta_SS.Nome_chirurga;
                    MessageBox.Show($"Il chirurga {chirurga}potrà prenotare ora");

                    semaforo.WaitOne();
                    thread.Start();
                    semaforo.Release();
                    button2.Visible = false;
                }
                else
                    MessageBox.Show("Non ci sono più richieste di prenotazione");
            }
             else
             {
                 if (comboBox2.SelectedIndex == 2 && data_salainvasiva != data_nonvalida)
                 {      if (codaPrenotazioniSI.Count > 0)
                    {
                        var richiesta_SI = codaPrenotazioniSI.Dequeue();
                        salainvasiva.altredate.Clear();
                        Thread thread = richiesta_SI.Thread;
                        string chirurga = richiesta_SI.Nome_chirurga;
                        MessageBox.Show($"Il chirurga {chirurga}potrà prenotare ora");

                        semaforo.WaitOne();
                        thread.Start();
                        semaforo.Release();
                        button2.Visible = false;
                    }
                    else
                        MessageBox.Show("Non ci sono più richieste di prenotazione");
                }
             }



        }


        private void Prenotare_salagenerale(string nome_chirurga)
        {
            semaforo.WaitOne();
            try
            {

                salagenerale.prenotazionii.Add(data_salagenerale);
                salagenerale.prenotazioni.Add(data_salagenerale);
                Prenotazione appuntamento = new Prenotazione(data_salagenerale, textBox1.Text, textBox2.Text, " SALA GENERALE", " ");
                salagenerale.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salagenerale.ToString("dd - MM - yyyy");
                button3.Invoke(new Action(() =>
                {
                    button3.Text = $"La prenotazione della SALA GENERALE in data {dataSenzaOre} a nome del chirurgico {nome_chirurga} è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));
            }

            finally
            {
                semaforo.Release();
            }

        }


        private void Prenotare_salainvasiva(string nome_chirurga)
        {
            semaforo.WaitOne();
            try
            {
                salainvasiva.prenotazionii.Add(data_salainvasiva);
                salainvasiva.prenotazioni.Add(data_salainvasiva);
                Prenotazione appuntamento = new Prenotazione(data_salainvasiva, textBox1.Text, textBox2.Text, "SALA INVASIVA", "");
                salainvasiva.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salainvasiva.ToString("dd - MM - yyyy");
                button3.Invoke(new Action(() =>
                {
                    button3.Text = $"La prenotazione della SALA INVASIVA in data {dataSenzaOre} a nome del chirurgico {nome_chirurga}  è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));

            }
            finally
            {
                semaforo.Release();
            }

        }

        private void Prenotare_salaspecializzata(string nome_chirurga)
        {

            semaforo.WaitOne();
            try
            {
                salaspecializzata.prenotazionii.Add(data_salaspecializzata);
                salaspecializzata.prenotazioni.Add(data_salaspecializzata);
                Prenotazione appuntamento = new Prenotazione(data_salaspecializzata, textBox1.Text, textBox2.Text, "SALA SPECIALIZZATA", " ");
                salaspecializzata.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salaspecializzata.ToString("dd - MM - yyyy");
                button3.Invoke(new Action(() =>
                {
                    button3.Text = $"La prenotazione della SALA SPECIALIZZATA in data {dataSenzaOre} a nome del chirurgico {nome_chirurga}  è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));


            }
            finally
            {
                semaforo.Release();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible= false;
            if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("Devi selezionare una Sala!!!");
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Devi selezionare un grado di urgenza!!!");
            else
            if (comboBox2.SelectedIndex == 0)
            {
                if (comboBox1.SelectedIndex == 0)
                    data_salagenerale = salagenerale.DataUrgentissima();
                else
                    if (comboBox1.SelectedIndex == 1)
                    data_salagenerale = salagenerale.DataUrgente();
                 
               
            }
            else
                if (comboBox2.SelectedIndex == 1)
            {
                if (comboBox1.SelectedIndex == 0)
                    data_salaspecializzata = salaspecializzata.DataUrgentissima();
                else
                    if (comboBox1.SelectedIndex == 1)
                    data_salaspecializzata = salaspecializzata.DataUrgente();

            }
            else
            {
                if (comboBox2.SelectedIndex == 2)
                {
                    if (comboBox1.SelectedIndex == 0)
                        data_salainvasiva = salainvasiva.DataUrgentissima();
                    else
                    if (comboBox1.SelectedIndex == 1)
                        data_salainvasiva = salainvasiva.DataUrgente();

                }

            }
           if (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 1 && comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 1)
            {
                button2.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime data_nonvalida = new DateTime(1, 1, 1);
            if (comboBox2.SelectedIndex == 0 && data_salagenerale != data_nonvalida)
            {
                salagenerale.altredate.Add(data_salagenerale);
                button1_Click(sender, e);
            }
            else
                if (comboBox2.SelectedIndex == 1 && data_salaspecializzata != data_nonvalida)
            {
                salaspecializzata.altredate.Add(data_salaspecializzata);
                button1_Click(sender, e);
            }
            else
            {
                if (comboBox2.SelectedIndex == 2 && data_salainvasiva != data_nonvalida)
                {
                    salainvasiva.altredate.Add(data_salainvasiva);
                    button1_Click(sender, e);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            comboBox1.Text = "seleziona un grado ";
            textBox2.Text = " ";
            comboBox2.Text = "seleziona una sala";
            button3.Text = " ";
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }
        private int grado_urgenza(string testocomboBox)
        {
            int liv_urgenza;
            if (comboBox1.Text== "MOLTO URGENTE")
                liv_urgenza = 0;
            else
                liv_urgenza = 1;
            return liv_urgenza;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("Devi selezionare una Sala!!!");
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Devi selezionare un grado di urgenza!!!");
            if(textBox1.Text==" "|| textBox2.Text ==" "|| comboBox2.SelectedIndex == -1|| comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Dati non validi!!");
            }
            else
            {
                
                    Anteprima anteprima = new Anteprima(textBox1.Text, textBox2.Text, comboBox2.Text, comboBox1.Text);
                  
                anteprima_prenotazioni.Add(anteprima);
                   listBox1.Items.Add(anteprima);
                Thread thread=null;
                RichiestaPrenotazione richiesta;
                if (anteprima.SalaSelezionata == "SALA GENERALE")
                {
                    thread = new Thread(()=>Prenotare_salagenerale (anteprima.Chirurgico));
                     richiesta = new RichiestaPrenotazione(anteprima.Chirurgico, grado_urgenza(comboBox1.Text), thread);
                    codaPrenotazioniSG.Enqueue(richiesta, richiesta.Urgenza);

                }
                else if (anteprima.SalaSelezionata == "SALA SPECIALIZZATA")
                {
                    thread = new Thread(()=>Prenotare_salaspecializzata(anteprima.Chirurgico));
                    richiesta = new RichiestaPrenotazione(anteprima.Chirurgico, grado_urgenza(comboBox1.Text), thread);
                    codaPrenotazioniSS.Enqueue(richiesta, grado_urgenza(comboBox1.Text));
                }
                else if (anteprima.SalaSelezionata == "SALA INVASIVA")
                {
                    thread = new Thread(()=>Prenotare_salainvasiva(anteprima.Chirurgico));
                    richiesta = new RichiestaPrenotazione(anteprima.Chirurgico, grado_urgenza(comboBox1.Text), thread);
                    codaPrenotazioniSI.Enqueue(richiesta, grado_urgenza(comboBox1.Text));
                }

               
            }

        }
        private void raccolta_richieste()
        {
            thread_raccoltarichieste.Join(40000);
            if (InvokeRequired)
            {
                Invoke(new Action(raccolta_richieste));
                Invoke(new Action(() =>
                {
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = true;
                    button5.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    comboBox2.Visible = true;
                    label1.Visible = false;
                    label2.Visible = true;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = true;
                    label6.Visible = false;
                    listBox1.Visible = false;
                    button6.Visible=false;
                    comboBox1 .Visible = false;
                }));
            }
        }

    
    }
}
