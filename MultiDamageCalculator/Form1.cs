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

        public List<Calculation> Calcs { get; set; }

        public bool DidPrint { get; set; }

        public MultiDamageCalculator()
        {
            InitializeComponent();

            ViewModel = new ViewModel();
            Calcs = new List<Calculation>();
            DidPrint = true;
            labelMemoria.DataBindings.Add("Text", ViewModel, "CalcsInMemory");
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
            Calculation calc = new Calculation();

            int nAttacks = listBox1.Items.Count;

            if (int.TryParse(textBox1.Text, out int HPconverted) && HPconverted > 0)
            {
                if(nAttacks > 1)
                {
                    List<int> previousRolls = new List<int> { 0 };
                    List<int> finalRolls = new List<int>();

                    for (int i = 0; i < nAttacks; i++)
                    {
                        List<int> rollsToSum = new List<int>();

                        string rolls = listBox1.Items[i].ToString().Trim(' ', '(', ')');

                        foreach (string roll in rolls.Split(','))
                        {
                            if (int.TryParse(roll.Trim(' '), out int convertedRoll) && convertedRoll > 0)
                            {
                                rollsToSum.Add(convertedRoll);
                            }
                        }

                        if (rollsToSum.Count == 0)
                        {
                            const string text = "Almeno una lista di danni non è valida. Assicurati di inserire liste di numeri interi maggiori di zero separati tra loro da virgole, una lista per volta";
                            const string caption = "Errore nei dati inseriti";
                            _ = MessageBox.Show(text, caption,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);

                            return;
                        }

                        calc.ListAttackRolls.Add(rollsToSum);

                        finalRolls.Clear();
                        foreach (int x in previousRolls)
                        {
                            foreach (int y in rollsToSum)
                            {
                                finalRolls.Add(x + y);
                            }
                        }

                        previousRolls.Clear();
                        foreach (int x in finalRolls)
                        {
                            previousRolls.Add(x);
                        }
                    }

                    calc.HP = HPconverted;
                    calc.KOcounter = finalRolls.Where(x => x >= calc.HP).Count();
                    calc.Total = finalRolls.Count;

                    if (calc.KOcounter == 0)
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
                    else if (calc.KOcounter == calc.Total)
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
                        if (calc.Total % calc.KOcounter == 0)
                        {
                            calc.SimplifiedKOcounter = 1;
                            calc.SimplifiedTotal = calc.Total / calc.KOcounter;

                        }
                        else
                        {
                            int gcd = SimpleMath.GCD(calc.KOcounter, calc.Total);
                            calc.SimplifiedKOcounter = calc.KOcounter / gcd;
                            calc.SimplifiedTotal = calc.Total / gcd;
                        }
                        calc.KOpercentage = calc.SimplifiedKOcounter * 100.0 / calc.SimplifiedTotal;
                        string text1 = $"Il Pokémon va KO {calc.KOcounter} volte su {calc.Total}";
                        string text2 = $"Rapporto semplificato: {calc.SimplifiedKOcounter}/{calc.SimplifiedTotal}";
                        string text3 = $"In percentuale: {calc.KOpercentage}%";
                        labelCalcoloBlando.Text = text1;
                        labelCalcoloMin.Text = text2;
                        labelCalcoloPreciso.Text = text3;
                    }

                    Calcs.Add(calc);

                    ViewModel.CalcsInMemory = Calcs.Count;

                    DidPrint = false;
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
            if (Calcs.Count > 0)
            {
                string nomeFile = $"calc{DateTime.Today.ToString("ddMMyy")}{DateTime.Now.ToString("HHmmss")}.txt";

                if (File.Exists(nomeFile))
                {
                    File.Delete(nomeFile);
                }

                using (StreamWriter sw = File.CreateText(nomeFile))
                {
                    foreach (Calculation calcolo in Calcs)
                    {
                        sw.WriteLine($"HP: {calcolo.HP}");

                        foreach (var lista in calcolo.ListAttackRolls)
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

                        sw.WriteLine($"KO {calcolo.KOcounter}/{calcolo.Total} ({calcolo.SimplifiedKOcounter}/{calcolo.SimplifiedTotal}), {calcolo.KOpercentage}%\n");
                    }
                }

                Calcs.Clear();

                ViewModel.CalcsInMemory = Calcs.Count;

                DidPrint = true;

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
            if (!DidPrint)
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
                    Calcs.Clear();
                }
            }
        }
    }
}
