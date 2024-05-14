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
        private const string CALE_FISIER = @"C:\Users\ACER\Desktop\Uni\PIU\SSIV\SistemSolar\bin\Debug\DateSS.txt";
        private ListBox listBoxSisteme;
        private ComboBox comboBoxSisteme;
        private TextBox txtIdCautat;
        private Button btnCauta;

        public Form1()
        {
            InitializeComponent();
            InitializeazaComponenteUI();
            InitializeazaListView();
            this.AutoScroll = true;
            this.Load += Form1_Load;
        }

        private Label lblEroare;

        private void InitializeazaComponenteUI()
        {
            txtNumeSistem = new TextBox { Location = new Point(10, this.Height - 100), Width = 200 };
            txtNumeStea = new TextBox { Location = new Point(220, this.Height - 100), Width = 200 };
            txtNrPlanete = new TextBox { Location = new Point(430, this.Height - 100), Width = 200 };

            btnAdauga = new Button { Text = "Adauga Sistem Solar", Location = new Point(640, this.Height - 100), Width = 200 };
            btnAdauga.Click += btnAdauga_Click;

            
            lblEroare = new Label
            {
                Location = new Point(10, this.Height - 70),
                Width = 830,
                ForeColor = Color.Red,
                Text = ""
            };

            RadioButton radioButton1 = new RadioButton
            {
                Text = "Optiune 1",
                Location = new Point(640, this.Height - 150),
                AutoSize = true
            };
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;

            
            CheckBox checkBox1 = new CheckBox
            {
                Text = "Bifat",
                Location = new Point(640, this.Height - 180),
                AutoSize = true
            };
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            listBoxSisteme = new ListBox
            {
                Location = new Point(10, 250),
                Size = new Size(200, 100)
            };

            comboBoxSisteme = new ComboBox
            {
                Location = new Point(220, 250),
                Size = new Size(200, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            txtIdCautat = new TextBox
            {
                Location = new Point(430, 250),
                Width = 200
            };
            txtIdCautat.KeyDown += TxtIdCautat_KeyEnter;

            btnCauta = new Button
            {

                Text = "Cauta dupa ID",
                Location = new Point(640, 250),
                Size = new Size(100, 23)
            };
            btnCauta.Click += BtnCauta_Click;

            listBoxSisteme = new ListBox
            {
                Location = new Point(300, 100),
                Size = new Size(200, 100),
                ScrollAlwaysVisible = true  
            };

            comboBoxSisteme = new ComboBox
            {
                Location = new Point(220, 250),
                Size = new Size(200, 21),
                DropDownHeight = 106,  
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false  
            };

            Controls.AddRange(new Control[] { listBoxSisteme, comboBoxSisteme, txtIdCautat, btnCauta });

            Controls.Add(txtNumeSistem);
            Controls.Add(txtNumeStea);
            Controls.Add(txtNrPlanete);
            Controls.Add(btnAdauga);
            Controls.Add(lblEroare);
            Controls.Add(radioButton1);
            Controls.Add(checkBox1);
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
                Scrollable = true
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
            IncarcaDateInListe();
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
            lblEroare.Text = "";

            if (string.IsNullOrWhiteSpace(txtNumeSistem.Text) ||
                string.IsNullOrWhiteSpace(txtNumeStea.Text) ||
                string.IsNullOrWhiteSpace(txtNrPlanete.Text))
            {
                lblEroare.Text = "Toate campurile trebuie completate.";
                return;
            }

            if (!int.TryParse(txtNrPlanete.Text, out int nrPlanete) || nrPlanete < 0)
            {
                lblEroare.Text = "Numarul de planete trebuie sa fie un numar intreg si pozitiv.";
                return;
            }

            int idNou = lvSistemeSolare.Items.Count;
            ListViewItem item = new ListViewItem(new[] { idNou.ToString(), txtNumeSistem.Text, txtNumeStea.Text, nrPlanete.ToString() });
            lvSistemeSolare.Items.Add(item);
            listBoxSisteme.Items.Add($"{idNou}: {txtNumeSistem.Text}, {txtNumeStea.Text}, {nrPlanete}");
            comboBoxSisteme.Items.Add($"{idNou}: {txtNumeSistem.Text}, {txtNumeStea.Text}, {nrPlanete}");

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

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblEroare.Text = " 'Optiune 1' selectata.";
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                lblEroare.Text = "este bifat.";
            }
            else
            {
                lblEroare.Text = "a fost debifat.";
            }
        }

        private void BtnCauta_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdCautat.Text, out int idCautat))
            {
                MessageBox.Show("Introduceti un ID valid.");
                return;
            }

            var liniiFisier = File.ReadAllLines(CALE_FISIER);
            var linieGasita = liniiFisier.FirstOrDefault(linie => linie.StartsWith($"{idCautat}:"));

            if (linieGasita != null)
            {
                listBoxSisteme.Items.Clear();
                comboBoxSisteme.Items.Clear();

                listBoxSisteme.Items.Add(linieGasita);
                comboBoxSisteme.Items.Add(linieGasita);
            }
            else
            {
                MessageBox.Show("ID-ul introdus nu a fost gasit.");
                listBoxSisteme.Items.Clear();
                comboBoxSisteme.Items.Clear();
            }
        }

        private void IncarcaDateInListe()
        {
            var liniiFisier = File.ReadAllLines(CALE_FISIER);
            listBoxSisteme.Items.Clear();  
            comboBoxSisteme.Items.Clear(); 

            foreach (var linie in liniiFisier)
            {
                listBoxSisteme.Items.Add(linie);
                comboBoxSisteme.Items.Add(linie);
            }   
        }

        private void TxtIdCautat_KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnCauta_Click(this, EventArgs.Empty); 
                e.SuppressKeyPress = true; 
            }
        }


    }
}
