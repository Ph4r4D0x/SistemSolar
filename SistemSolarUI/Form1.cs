using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemSolarUI
{
    public partial class Form1 : Form
    {
        private ListView lvSistemeSolare;
        private TextBox txtNumeSistem;
        private TextBox txtNumeStea;
        private TextBox txtNrPlanete;
        private Button btnAdauga;
        private const string CALE_FISIER = @"C:\Users\ACER\Desktop\PIU\SSIV\SistemSolar\bin\Debug\DateSS.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeazaComponenteUI();
            InitializeazaListView();
            this.Load += Form1_Load;
        }

        private void InitializeazaComponenteUI()
        {

            txtNumeSistem = new TextBox { Location = new Point(10, this.Height - 100), Width = 200 };
            txtNumeStea = new TextBox { Location = new Point(220, this.Height - 100), Width = 200 };
            txtNrPlanete = new TextBox { Location = new Point(430, this.Height - 100), Width = 200 };
            
            btnAdauga = new Button { Text = "Adauga Sistem Solar", Location = new Point(640, this.Height - 100), Width = 200 };
            btnAdauga.Click += btnAdauga_Click;

            Controls.Add(txtNumeSistem);
            Controls.Add(txtNumeStea);
            Controls.Add(txtNrPlanete);
            Controls.Add(btnAdauga);
        }

        private void InitializeazaListView()
        {
            lvSistemeSolare = new ListView
            {
                Location = new Point(10, 10),
                Size = new Size(this.Width - 20, this.Height - 130),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
            };

            lvSistemeSolare.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Nume Sistem", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Soare", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Nr. Planete", -2, HorizontalAlignment.Left);

            Controls.Add(lvSistemeSolare);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaSistemeSolare();
        }

        private void AfiseazaSistemeSolare()
        {
            lvSistemeSolare.Items.Clear();

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
                    ListViewItem item = new ListViewItem(new[] { id, dateSistem[0], dateSistem[1], dateSistem[2] });
                    lvSistemeSolare.Items.Add(item);
                }
            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            AdaugaSistemSolar();
        }

        private void AdaugaSistemSolar()
        {
            if (string.IsNullOrWhiteSpace(txtNumeSistem.Text) ||
                string.IsNullOrWhiteSpace(txtNumeStea.Text) ||
                string.IsNullOrWhiteSpace(txtNrPlanete.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate.");
                return;
            }

            if (!int.TryParse(txtNrPlanete.Text, out int nrPlanete) || nrPlanete < 0)
            {
                MessageBox.Show("Numarul de planete trebuie sa fie un numar inrtreg si pozitiv.");
                return;
            }

            int idNou = lvSistemeSolare.Items.Count;
            ListViewItem item = new ListViewItem(new[] { idNou.ToString(), txtNumeSistem.Text, txtNumeStea.Text, nrPlanete.ToString() });
            lvSistemeSolare.Items.Add(item);

            SalveazaSistemSolarInFisier(idNou, txtNumeSistem.Text, txtNumeStea.Text, nrPlanete);

            txtNumeSistem.Clear();
            txtNumeStea.Clear();
            txtNrPlanete.Clear();
        }

        private void SalveazaSistemSolarInFisier(int id, string numeSistem, string numeStea, int nrPlanete)
        {
            using (StreamWriter sw = File.AppendText(CALE_FISIER))
            {
                sw.WriteLine($"{id}: {numeSistem}, {numeStea}, {nrPlanete}");
            }
        }
    }
}
