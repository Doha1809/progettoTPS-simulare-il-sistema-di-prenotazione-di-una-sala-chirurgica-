namespace ProgettoTPS_sistema_prenotazione_sale_chirurgiche_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new MaskedTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button5 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(255, 192, 192);
            textBox1.Location = new Point(38, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 106);
            label1.Name = "label1";
            label1.Size = new Size(155, 16);
            label1.TabIndex = 1;
            label1.Text = "NOME CHIRURGICO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 288);
            label2.Name = "label2";
            label2.Size = new Size(265, 16);
            label2.TabIndex = 3;
            label2.Text = "SI PREGA DI SCEGLIERE UNA SALA";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(69, 204);
            label3.Name = "label3";
            label3.Size = new Size(137, 16);
            label3.TabIndex = 4;
            label3.Text = "NOME PAZIENTE ";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(255, 192, 192);
            textBox2.Location = new Point(38, 237);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(197, 23);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(571, 138);
            button1.Name = "button1";
            button1.Size = new Size(346, 55);
            button1.TabIndex = 6;
            button1.Text = "MOSTRA LA PRIMA DATA DISPONIBILE ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SandyBrown;
            button2.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(571, 400);
            button2.Name = "button2";
            button2.Size = new Size(346, 53);
            button2.TabIndex = 7;
            button2.Text = "MOSTRA UN'ALTRA DATA";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.Font = new Font("Georgia", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.Location = new Point(357, 265);
            button3.Name = "button3";
            button3.Size = new Size(231, 64);
            button3.TabIndex = 8;
            button3.Text = "PRENOTAZIONE EFFETUATA";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 192, 192);
            button4.Font = new Font("Cambria Math", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(666, 265);
            button4.Name = "button4";
            button4.Size = new Size(182, 64);
            button4.TabIndex = 9;
            button4.Text = "PRENOTA SALA";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 418);
            label4.Name = "label4";
            label4.Size = new Size(158, 16);
            label4.TabIndex = 10;
            label4.Text = "GRADO DI URGENZA";
            label4.Click += label4_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(255, 192, 192);
            comboBox1.Font = new Font("Cambria Math", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(38, 454);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 69);
            comboBox1.TabIndex = 11;
            comboBox1.Text = "seleziona il grado ";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.FromArgb(255, 192, 192);
            comboBox2.Font = new Font("Cambria Math", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(38, 315);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(197, 69);
            comboBox2.TabIndex = 12;
            comboBox2.Text = "seleziona una sala";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 192, 255);
            button5.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(875, 10);
            button5.Name = "button5";
            button5.Size = new Size(93, 61);
            button5.TabIndex = 13;
            button5.Text = "CAMBIA UTENTE";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(357, 32);
            label5.Name = "label5";
            label5.Size = new Size(261, 16);
            label5.TabIndex = 14;
            label5.Text = "PRENOTA UNA SALA CHIRURGICA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 560);
            Controls.Add(label5);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private MaskedTextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button5;
        private Label label5;
    }
}
