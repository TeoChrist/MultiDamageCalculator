using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDamageCalculator
{
    public partial class MultiDamageCalculator : Form
    {
        public ViewModel ViewModel { get; set; }

        public List<Calcolo> Calcoli { get; set; }

        public bool HaStampato { get; set; }

        public MultiDamageCalculator()
        {
            InitializeComponent();

            ViewModel = new ViewModel();
            Calcoli = new List<Calcolo>();
            HaStampato = true;
            labelMemoria.DataBindings.Add("Text", ViewModel, "calcoliInMemoria");
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            string fromClipboard = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(fromClipboard))
            {
                listBox1.Items.Add(fromClipboard);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for(int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    listBox1.Items.RemoveAt(i);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonCalcola_Click(object sender, EventArgs e)
        {
            Calcolo calcolo = new Calcolo();

            int nAtk = listBox1.Items.Count;

            if (int.TryParse(textBox1.Text, out int HPconverted) && HPconverted > 0)
            {
                if(nAtk > 1)
                {
                    List<int> danniGiaCombinati = new List<int> { 0 };
                    List<int> danniNuoviCombinati = new List<int>();

                    for (int i = 0; i < nAtk; i++)
                    {
                        List<int> danniNuovi = new List<int>();

                        while (danniNuovi.Count == 0)
                        {
                            string damages = listBox1.Items[i].ToString().Replace(" ", "").Trim('(', ')');

                            foreach (string damage in damages.Split(','))
                            {
                                if (int.TryParse(damage, out int damageConverted) && damageConverted > 0)
                                {
                                    danniNuovi.Add(damageConverted);
                                }
                            }

                            if (danniNuovi.Count == 0)
                            {
                                const string text = "Almeno una lista di danni non è valida. Assicurati di inserire liste di numeri interi maggiori di zero separati tra loro da virgole, una lista per volta";
                                const string caption = "Errore nei dati inseriti";
                                _ = MessageBox.Show(text, caption,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);

                                return;
                            }
                        }

                        calcolo.ListeDanni.Add(danniNuovi);

                        danniNuoviCombinati.Clear();
                        foreach (int x in danniGiaCombinati)
                        {
                            foreach (int y in danniNuovi)
                            {
                                danniNuoviCombinati.Add(x + y);
                            }
                        }

                        danniGiaCombinati.Clear();
                        foreach (int x in danniNuoviCombinati)
                        {
                            danniGiaCombinati.Add(x);
                        }
                    }

                    calcolo.HP = HPconverted;
                    calcolo.ContatoreKO = danniNuoviCombinati.Where(x => x >= calcolo.HP).Count();
                    calcolo.Totale = danniNuoviCombinati.Count;

                    if (calcolo.ContatoreKO == 0)
                    {
                        const string text = "Il Pokémon non va mai KO";
                        labelCalcoloBlando.Text = text;
                        if (!string.IsNullOrEmpty(labelCalcoloMin.Text))
                        {
                            labelCalcoloMin.Text = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(labelCalcoloPreciso.Text))
                        {
                            labelCalcoloPreciso.Text = string.Empty;
                        }
                    }
                    else if (calcolo.ContatoreKO == calcolo.Totale)
                    {
                        const string text = "Il Pokémon va KO sempre";
                        labelCalcoloBlando.Text = text;
                        if (!string.IsNullOrEmpty(labelCalcoloMin.Text))
                        {
                            labelCalcoloMin.Text = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(labelCalcoloPreciso.Text))
                        {
                            labelCalcoloPreciso.Text = string.Empty;
                        }
                    }
                    else
                    {
                        int mcd = Matematica.MCD(calcolo.ContatoreKO, calcolo.Totale);
                        calcolo.ContatoreKOmin = calcolo.ContatoreKO / mcd;
                        calcolo.TotaleMin = calcolo.Totale / mcd;
                        calcolo.PercentualeKO = calcolo.ContatoreKOmin * 100.0 / calcolo.TotaleMin;
                        string text1 = $"Il Pokémon va KO {calcolo.ContatoreKO} volte su {calcolo.Totale}";
                        string text2 = $"Rapporto semplificato: {calcolo.ContatoreKOmin}/{calcolo.TotaleMin}";
                        string text3 = $"In percentuale: {calcolo.PercentualeKO}%";
                        labelCalcoloBlando.Text = text1;
                        labelCalcoloMin.Text = text2;
                        labelCalcoloPreciso.Text = text3;
                    }

                    Calcoli.Add(calcolo);

                    ViewModel.CalcoliInMemoria = Calcoli.Count;

                    HaStampato = false;
                }
                else
                {
                    const string text = "Inserisci almeno due liste di danni";
                    const string caption = "Liste danni insufficienti";
                    _ = MessageBox.Show(text, caption,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                const string text = "Inserisci un numero intero maggiore di zero";
                const string caption = "HP non validi";
                _ = MessageBox.Show(text, caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(labelCalcoloBlando.Text))
            {
                if (string.IsNullOrWhiteSpace(labelCalcoloMin.Text) && string.IsNullOrWhiteSpace(labelCalcoloPreciso.Text))
                {
                    Clipboard.SetText(labelCalcoloBlando.Text);
                }
                else
                {
                    Clipboard.SetText($"{labelCalcoloBlando.Text}. {labelCalcoloMin.Text}. {labelCalcoloPreciso.Text}");
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (Calcoli.Count > 0)
            {
                string nomeFile = $"calc{DateTime.Today.ToString("ddMMyy")}{DateTime.Now.ToString("HHmmss")}.txt";

                if (File.Exists(nomeFile))
                {
                    File.Delete(nomeFile);
                }

                using (StreamWriter sw = File.CreateText(nomeFile))
                {
                    foreach (Calcolo calcolo in Calcoli)
                    {
                        sw.WriteLine($"HP: {calcolo.HP}");

                        foreach (var lista in calcolo.ListeDanni)
                        {
                            sw.Write("(");

                            for (int i = 0, len = lista.Count, commalen = len - 1; i < len; i++)
                            {
                                sw.Write($"{lista.ElementAt(i)}");

                                if (i < commalen)
                                {
                                    sw.Write(", ");
                                }
                            }

                            sw.WriteLine(")");
                        }

                        sw.WriteLine($"KO {calcolo.ContatoreKO}/{calcolo.Totale} ({calcolo.ContatoreKOmin}/{calcolo.TotaleMin}), {calcolo.PercentualeKO}%\n");
                    }
                }

                Calcoli.Clear();

                ViewModel.CalcoliInMemoria = Calcoli.Count;

                HaStampato = true;

                string text = $"Nome del file: {nomeFile}";
                const string caption = "Esportazione eseguita con successo";
                _ = MessageBox.Show(text, caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            else
            {
                const string text = "Prima fai un calcolo";
                const string caption = "Ancora niente da esportare";
                _ = MessageBox.Show(text, caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void Calcolatore2danni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!HaStampato)
            {
                const string text = "Non tutti i calcoli sono stati esportati. Sei sicuro di voler chiudere l'applicazione?";
                const string caption = "Chiusura applicazione";
                var result = MessageBox.Show(text, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Calcoli.Clear();
                }
            }
        }
    }
}
