using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemSolarUI
{
    public partial class Form1 : Form
    {
        private ListView lvSistemeSolare;
        private const string CALE_FISIER = @"C:\Users\ACER\Desktop\PIU\SSIV\SistemSolar\bin\Debug\DateSS.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeazaForma();
        }

        private void InitializeazaForma()
        {
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Text = "Informatii Sisteme Solare";

            lvSistemeSolare = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Fill,
            };

            lvSistemeSolare.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Nume Sistem", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Soare", -2, HorizontalAlignment.Left);
            lvSistemeSolare.Columns.Add("Nr. Planete", -2, HorizontalAlignment.Left);

            this.Controls.Add(lvSistemeSolare);
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaSistemeSolare();
        }

        private void AfiseazaSistemeSolare()
        {
            lvSistemeSolare.Items.Clear(); //

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
                    var item = new ListViewItem(id);
                    item.SubItems.Add(dateSistem[0]);
                    item.SubItems.Add(dateSistem[1]);
                    item.SubItems.Add(dateSistem[2]);
                    lvSistemeSolare.Items.Add(item);
                }
            }
        }
    }

}
