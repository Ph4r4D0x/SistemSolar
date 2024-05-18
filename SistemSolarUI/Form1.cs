using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemSolarUI
{
    public partial class Form1 : Form
    {
        private const string CALE_FISIER = @"C:\Users\ACER\Desktop\Uni\PIU\SSIV\SistemSolar\bin\Debug\DateSS.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.Load += Form1_Load;
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("NumeSistem", "Nume Sistem");
            dataGridView1.Columns.Add("Soare", "Soare");
            dataGridView1.Columns.Add("NrPlanete", "Nr. Planete");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaSistemeSolare();
            IncarcaDateInListe();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AdaugaSistemSolar();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            BtnCauta_Click();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                labelError.Text = "este bifat.";
            }
            else
            {
                labelError.Text = "a fost debifat.";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                labelError.Text = " 'Optiune 1' selectata.";
            }
        }

        private void AdaugaSistemSolar()
        {
            labelError.Text = "";

            if (string.IsNullOrWhiteSpace(textBoxNameSystem.Text) ||
                string.IsNullOrWhiteSpace(textBoxStarName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPlanetNumber.Text))
            {
                labelError.Text = "Toate campurile trebuie completate.";
                return;
            }

            if (!int.TryParse(textBoxPlanetNumber.Text, out int nrPlanete) || nrPlanete < 0)
            {
                labelError.Text = "Numarul de planete trebuie sa fie un numar intreg si pozitiv.";
                return;
            }

            int idNou = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add(idNou.ToString(), textBoxNameSystem.Text, textBoxStarName.Text, nrPlanete.ToString());
            listBoxSystems.Items.Add($"{idNou}: {textBoxNameSystem.Text}, {textBoxStarName.Text}, {nrPlanete}");
            comboBoxSystems.Items.Add($"{idNou}: {textBoxNameSystem.Text}, {textBoxStarName.Text}, {nrPlanete}");

            SalveazaSistemSolarInFisier(idNou, textBoxNameSystem.Text, textBoxStarName.Text, nrPlanete);

            textBoxNameSystem.Clear();
            textBoxStarName.Clear();
            textBoxPlanetNumber.Clear();
        }

        private void SalveazaSistemSolarInFisier(int id, string numeSistem, string numeStea, int nrPlanete)
        {
            using (StreamWriter sw = File.AppendText(CALE_FISIER))
            {
                sw.WriteLine($"{id}: {numeSistem}, {numeStea}, {nrPlanete}");
            }
        }

        private void BtnCauta_Click()
        {
            if (!int.TryParse(textBoxSearchID.Text, out int idCautat))
            {
                MessageBox.Show("Introduceti un ID valid.");
                return;
            }

            var liniiFisier = File.ReadAllLines(CALE_FISIER);
            var linieGasita = liniiFisier.FirstOrDefault(linie => linie.StartsWith($"{idCautat}:"));

            if (linieGasita != null)
            {
                listBoxSystems.Items.Clear();
                comboBoxSystems.Items.Clear();

                listBoxSystems.Items.Add(linieGasita);
                comboBoxSystems.Items.Add(linieGasita);
            }
            else
            {
                MessageBox.Show("ID-ul introdus nu a fost gasit.");
                listBoxSystems.Items.Clear();
                comboBoxSystems.Items.Clear();
            }
        }

        private void AfiseazaSistemeSolare()
        {
            dataGridView1.Rows.Clear();

            if (!File.Exists(CALE_FISIER))
            {
                MessageBox.Show("Fisierul cu date nu a fost gasit.");
                return;
            }

            string[] liniiFisier = File.ReadAllLines(CALE_FISIER);

            foreach (string linie in liniiFisier)
            {
                string[] parts = linie.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    continue;
                }

                string id = parts[0].Trim();
                string[] dateSistem = parts[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < dateSistem.Length; i++)
                {
                    dateSistem[i] = dateSistem[i].Trim();
                }

                if (dateSistem.Length == 3)
                {
                    dataGridView1.Rows.Add(id, dateSistem[0], dateSistem[1], dateSistem[2]);
                }
            }
        }

        private void IncarcaDateInListe()
        {
            var liniiFisier = File.ReadAllLines(CALE_FISIER);
            listBoxSystems.Items.Clear();
            comboBoxSystems.Items.Clear();

            foreach (var linie in liniiFisier)
            {
                listBoxSystems.Items.Add(linie);
                comboBoxSystems.Items.Add(linie);
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            ModifySistemSolar();
        }

        private void ModifySistemSolar()
        {
            labelError.Text = "";

            if (!int.TryParse(textBoxSearchID.Text, out int idCautat))
            {
                MessageBox.Show("Introduceti un ID valid.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNameSystem.Text) ||
                string.IsNullOrWhiteSpace(textBoxStarName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPlanetNumber.Text))
            {
                labelError.Text = "Toate campurile trebuie completate.";
                return;
            }

            if (!int.TryParse(textBoxPlanetNumber.Text, out int nrPlanete) || nrPlanete < 0)
            {
                labelError.Text = "Numarul de planete trebuie sa fie un numar intreg si pozitiv.";
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == idCautat.ToString())
                {
                    row.Cells[1].Value = textBoxNameSystem.Text;
                    row.Cells[2].Value = textBoxStarName.Text;
                    row.Cells[3].Value = nrPlanete.ToString();

                    UpdateFile();
                    MessageBox.Show("Sistemul Solar a fost modificat.");
                    return;
                }
            }

            MessageBox.Show("ID-ul introdus nu a fost gasit.");
        }

        private void UpdateFile()
        {
            using (StreamWriter sw = new StreamWriter(CALE_FISIER))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        sw.WriteLine($"{row.Cells[0].Value}: {row.Cells[1].Value}, {row.Cells[2].Value}, {row.Cells[3].Value}");
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
