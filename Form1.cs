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
       
        public Form1()
        {
            InitializeComponent();
            salainvasiva = new SalaInvasiva("salainvasiva");
            salaspecializzata = new SalaSpecializzata("salaspecializzata");
            salagenerale = new SalaGenerale("salagenerale");
            semaforo = new Semaphore(1,1); //Permette solo un thread alla volta
            button2.Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("SALA GENERALE");
            comboBox2.Items.Add("SALA SPECIALIZZATA");
            comboBox2.Items.Add("SALA INVASIVA");

            comboBox1.Items.Add("MOLTO URGENTE");
            comboBox1.Items.Add("URGENTE");
            comboBox1.Items.Add("NORMALE");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime data_nonvalida = new DateTime(1, 1, 1);
            if (comboBox2.SelectedIndex == 0 && data_salagenerale != data_nonvalida)
            {
                ThreadPool.QueueUserWorkItem(Thread_salagenerale); // il sistema mette il metodo Thread_salagenerale nella coda dei lavori da eseguire nel Thread Pool.
            }
            else
                if (comboBox2.SelectedIndex == 1 && data_salaspecializzata != data_nonvalida)
            {
                ThreadPool.QueueUserWorkItem(Thread_salaspecializzata,button3);
            }
            else
            {
                if (comboBox2.SelectedIndex == 2&&data_salainvasiva != data_nonvalida)
                {
                    ThreadPool.QueueUserWorkItem(Thread_salainvasiva);
                }
            }
           


        }
        private void Thread_salagenerale(object state)
        {
            semaforo.WaitOne();
            try
            {
                salagenerale.prenotazionii.Add(data_salagenerale);
                salagenerale.prenotazioni.Add(data_salagenerale);
                Prenotazione appuntamento = new Prenotazione(data_salagenerale, textBox1.Text, textBox2.Text);
                salagenerale.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salagenerale.ToString("dd - MM - yyyy");
                button3.Invoke(new Action(() =>
                {
                    button3.Text=$"La prenotazione della SALA GENERALE in data {dataSenzaOre} a nome del chirurgico {textBox1.Text} per il paziente {textBox2.Text} è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));
            }
            finally
            {
                semaforo.Release();
            }
           
        }
        

        private void Thread_salainvasiva(object state)
        {
            semaforo.WaitOne();
            try
            {
                salainvasiva.prenotazionii.Add(data_salainvasiva);
                salainvasiva.prenotazioni.Add(data_salainvasiva);
                Prenotazione appuntamento = new Prenotazione(data_salainvasiva, textBox1.Text,textBox2.Text);
                salainvasiva.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salainvasiva.ToString("dd - MM - yyyy");
                button3.Invoke(new Action(() =>
                {
                    button3.Text = $"La prenotazione della SALA INVASIVA in data {dataSenzaOre} a nome del chirurgico {textBox1.Text} per il paziente {textBox2.Text} è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));
            
            }
            finally
            {
                semaforo.Release();
            }

        }

        private void Thread_salaspecializzata(object button)
        {
            Button buttone = (Button)button;
            semaforo.WaitOne();
            try
            {
                salaspecializzata.prenotazionii.Add(data_salaspecializzata);
                salaspecializzata.prenotazioni.Add(data_salaspecializzata);
                Prenotazione appuntamento = new Prenotazione(data_salaspecializzata, textBox1.Text, textBox2.Text);
               salaspecializzata.prenotazioni_sale.Add(appuntamento);
                string dataSenzaOre = data_salaspecializzata.ToString("dd - MM - yyyy");
                buttone.Invoke(new Action(() =>
                {
                    buttone.Text = $"La prenotazione della SALA SPECIALIZZATA in data {dataSenzaOre} a nome del chirurgico {textBox1.Text} per il paziente {textBox2.Text} è avvenuto con successo. "; // Esegui l'operazione sul thread principale
                }));
            

            }
            finally
            {
                semaforo.Release();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("Devi selezionare una Sala!!!");
            if(comboBox1.SelectedIndex==-1)
                MessageBox.Show("Devi selezionare un grado di urgenza!!!");
            else
            if (comboBox2.SelectedIndex == 0)
            {
                if (comboBox1.SelectedIndex == 0)
                    data_salagenerale = salagenerale.DataUrgentissima();
                else
                    if (comboBox1.SelectedIndex == 1)
                    data_salagenerale = salagenerale.DataUrgente();
                else
                    if (comboBox1.SelectedIndex == 2)
                    data_salagenerale = salagenerale.DataNormale();
            }
            else
                if (comboBox2.SelectedIndex == 1)
            {
                if (comboBox1.SelectedIndex == 0)
                    data_salaspecializzata = salaspecializzata.DataUrgentissima();
                else
                    if (comboBox1.SelectedIndex == 1)
                    data_salaspecializzata = salaspecializzata.DataUrgente();
                else
                        if (comboBox1.SelectedIndex == 2)
                    data_salaspecializzata = salaspecializzata.DataNormale();
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
                    else
                         if (comboBox1.SelectedIndex == 2)
                        data_salainvasiva = salainvasiva.DataNormale();
                }
               
            }
            if (comboBox2.SelectedIndex>=0&&comboBox2.SelectedIndex<=2&& comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 2)
            {
                button1.Visible = false;
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
                if (comboBox2.SelectedIndex == 2&&data_salainvasiva != data_nonvalida)
                {
                    salainvasiva.altredate.Add(data_salainvasiva);
                    button1_Click(sender, e);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            comboBox1.Text= "seleziona un grado ";
           textBox2.Text= " ";
            comboBox2.Text= "seleziona una sala";
            salagenerale.altredate.Clear();
            salaspecializzata.altredate.Clear();
            salainvasiva.altredate.Clear();
            button3.Text = " ";
            button1.Visible = true;
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }
    }
}
