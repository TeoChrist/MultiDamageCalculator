namespace MultiDamageCalculator
{
    partial class MultiDamageCalculator
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiDamageCalculator));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelCalcoloBlando = new System.Windows.Forms.Label();
            this.labelMemoria = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCalcola = new System.Windows.Forms.Button();
            this.labelCalcoloPreciso = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.labelCalcoloMin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(550, 244);
            this.listBox1.TabIndex = 0;
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(12, 274);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(109, 67);
            this.buttonPaste.TabIndex = 1;
            this.buttonPaste.Text = "Importa lista da Clipboard";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calcoli in memoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "HP:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(631, 12);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 22);
            this.textBox1.TabIndex = 5;
            // 
            // labelCalcoloBlando
            // 
            this.labelCalcoloBlando.AutoSize = true;
            this.labelCalcoloBlando.Location = new System.Drawing.Point(592, 137);
            this.labelCalcoloBlando.Name = "labelCalcoloBlando";
            this.labelCalcoloBlando.Size = new System.Drawing.Size(0, 17);
            this.labelCalcoloBlando.TabIndex = 6;
            // 
            // labelMemoria
            // 
            this.labelMemoria.AutoSize = true;
            this.labelMemoria.Location = new System.Drawing.Point(820, 327);
            this.labelMemoria.Name = "labelMemoria";
            this.labelMemoria.Size = new System.Drawing.Size(0, 17);
            this.labelMemoria.TabIndex = 7;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(158, 274);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(109, 67);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Rimuovi liste selezionate";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(453, 274);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(109, 67);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "Esporta i calcoli su txt";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonCalcola
            // 
            this.buttonCalcola.Location = new System.Drawing.Point(658, 53);
            this.buttonCalcola.Name = "buttonCalcola";
            this.buttonCalcola.Size = new System.Drawing.Size(137, 43);
            this.buttonCalcola.TabIndex = 10;
            this.buttonCalcola.Text = "Calcola";
            this.buttonCalcola.UseVisualStyleBackColor = true;
            this.buttonCalcola.Click += new System.EventHandler(this.buttonCalcola_Click);
            // 
            // labelCalcoloPreciso
            // 
            this.labelCalcoloPreciso.AutoSize = true;
            this.labelCalcoloPreciso.Location = new System.Drawing.Point(592, 214);
            this.labelCalcoloPreciso.Name = "labelCalcoloPreciso";
            this.labelCalcoloPreciso.Size = new System.Drawing.Size(0, 17);
            this.labelCalcoloPreciso.TabIndex = 11;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(305, 274);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(109, 67);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Cancella tutte le liste";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(658, 274);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(137, 43);
            this.buttonCopy.TabIndex = 13;
            this.buttonCopy.Text = "Copia calcolo";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // labelCalcoloMin
            // 
            this.labelCalcoloMin.AutoSize = true;
            this.labelCalcoloMin.Location = new System.Drawing.Point(592, 177);
            this.labelCalcoloMin.Name = "labelCalcoloMin";
            this.labelCalcoloMin.Size = new System.Drawing.Size(0, 17);
            this.labelCalcoloMin.TabIndex = 14;
            // 
            // MultiDamageCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 353);
            this.Controls.Add(this.labelCalcoloMin);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelCalcoloPreciso);
            this.Controls.Add(this.buttonCalcola);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelMemoria);
            this.Controls.Add(this.labelCalcoloBlando);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 400);
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "MultiDamageCalculator";
            this.Text = "MultiDamageCalculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calcolatore2danni_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelCalcoloBlando;
        private System.Windows.Forms.Label labelMemoria;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonCalcola;
        private System.Windows.Forms.Label labelCalcoloPreciso;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelCalcoloMin;
    }
}

