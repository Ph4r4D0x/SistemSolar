namespace SistemSolarUI
{
    partial class Form1
    {
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBoxSystems;
        private System.Windows.Forms.ComboBox comboBoxSystems;
        private System.Windows.Forms.TextBox textBoxNameSystem;
        private System.Windows.Forms.TextBox textBoxStarName;
        private System.Windows.Forms.TextBox textBoxPlanetNumber;
        private System.Windows.Forms.TextBox textBoxSearchID;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelNameSystem;
        private System.Windows.Forms.Label labelStarName;
        private System.Windows.Forms.Label labelPlanetNumber;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            listBoxSystems = new ListBox();
            comboBoxSystems = new ComboBox();
            textBoxNameSystem = new TextBox();
            textBoxStarName = new TextBox();
            textBoxPlanetNumber = new TextBox();
            textBoxSearchID = new TextBox();
            buttonAdd = new Button();
            buttonSearch = new Button();
            buttonModify = new Button();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            labelError = new Label();
            labelNameSystem = new Label();
            labelStarName = new Label();
            labelPlanetNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            // 
            // listBoxSystems
            // 
            listBoxSystems.FormattingEnabled = true;
            listBoxSystems.ItemHeight = 15;
            listBoxSystems.Location = new Point(12, 168);
            listBoxSystems.Name = "listBoxSystems";
            listBoxSystems.Size = new Size(776, 94);
            listBoxSystems.TabIndex = 1;
            // 
            // comboBoxSystems
            // 
            comboBoxSystems.FormattingEnabled = true;
            comboBoxSystems.Location = new Point(12, 269);
            comboBoxSystems.Name = "comboBoxSystems";
            comboBoxSystems.Size = new Size(776, 23);
            comboBoxSystems.TabIndex = 2;
            // 
            // textBoxNameSystem
            // 
            textBoxNameSystem.Location = new Point(12, 337);
            textBoxNameSystem.Name = "textBoxNameSystem";
            textBoxNameSystem.Size = new Size(200, 23);
            textBoxNameSystem.TabIndex = 3;
            // 
            // textBoxStarName
            // 
            textBoxStarName.Location = new Point(218, 337);
            textBoxStarName.Name = "textBoxStarName";
            textBoxStarName.Size = new Size(200, 23);
            textBoxStarName.TabIndex = 4;
            // 
            // textBoxPlanetNumber
            // 
            textBoxPlanetNumber.Location = new Point(424, 337);
            textBoxPlanetNumber.Name = "textBoxPlanetNumber";
            textBoxPlanetNumber.Size = new Size(200, 23);
            textBoxPlanetNumber.TabIndex = 5;
            // 
            // textBoxSearchID
            // 
            textBoxSearchID.Location = new Point(12, 373);
            textBoxSearchID.Name = "textBoxSearchID";
            textBoxSearchID.Size = new Size(200, 23);
            textBoxSearchID.TabIndex = 6;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(630, 334);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(158, 23);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Adauga Sistem Solar";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(218, 373);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(158, 23);
            buttonSearch.TabIndex = 8;
            buttonSearch.Text = "Cauta dupa ID";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonModify
            // 
            buttonModify.Location = new Point(382, 373);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(158, 23);
            buttonModify.TabIndex = 15;
            buttonModify.Text = "Modify";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 409);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(84, 409);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(12, 438);
            labelError.Name = "labelError";
            labelError.Size = new Size(197, 15);
            labelError.TabIndex = 11;
            labelError.Text = "Toate campurile trebuie completate.";
            // 
            // labelNameSystem
            // 
            labelNameSystem.AutoSize = true;
            labelNameSystem.Location = new Point(12, 321);
            labelNameSystem.Name = "labelNameSystem";
            labelNameSystem.Size = new Size(78, 15);
            labelNameSystem.TabIndex = 12;
            labelNameSystem.Text = "Nume Sistem";
            // 
            // labelStarName
            // 
            labelStarName.AutoSize = true;
            labelStarName.Location = new Point(215, 321);
            labelStarName.Name = "labelStarName";
            labelStarName.Size = new Size(36, 15);
            labelStarName.TabIndex = 13;
            labelStarName.Text = "Soare";
            // 
            // labelPlanetNumber
            // 
            labelPlanetNumber.AutoSize = true;
            labelPlanetNumber.Location = new Point(421, 321);
            labelPlanetNumber.Name = "labelPlanetNumber";
            labelPlanetNumber.Size = new Size(65, 15);
            labelPlanetNumber.TabIndex = 14;
            labelPlanetNumber.Text = "Nr. Planete";
            // 
            // Form1
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(buttonModify);
            Controls.Add(labelPlanetNumber);
            Controls.Add(labelStarName);
            Controls.Add(labelNameSystem);
            Controls.Add(labelError);
            Controls.Add(radioButton1);
            Controls.Add(checkBox1);
            Controls.Add(buttonSearch);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxSearchID);
            Controls.Add(textBoxPlanetNumber);
            Controls.Add(textBoxStarName);
            Controls.Add(textBoxNameSystem);
            Controls.Add(comboBoxSystems);
            Controls.Add(listBoxSystems);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
