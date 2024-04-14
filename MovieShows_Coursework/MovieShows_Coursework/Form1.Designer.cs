namespace MovieShows_Coursework
{
    partial class FormJOMovie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.panelHome = new System.Windows.Forms.Panel();
            this.groupBoxInputData = new System.Windows.Forms.GroupBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelBeginning = new System.Windows.Forms.Label();
            this.textBoxBeginning = new System.Windows.Forms.TextBox();
            this.labelNameCinema = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxNameCinema = new System.Windows.Forms.TextBox();
            this.comboBoxGenreFilm = new System.Windows.Forms.ComboBox();
            this.labelNameFilm = new System.Windows.Forms.Label();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.textBoxNameFilm = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateShow = new System.Windows.Forms.DateTimePicker();
            this.labelGenre = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelDataMovieShows = new System.Windows.Forms.Panel();
            this.dataGridViewMovieShows = new System.Windows.Forms.DataGridView();
            this.Film = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beginning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabPageHome.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.groupBoxInputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelDataMovieShows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieShows)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(907, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPageHome
            // 
            this.tabPageHome.Controls.Add(this.panelHome);
            this.tabPageHome.Location = new System.Drawing.Point(4, 34);
            this.tabPageHome.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Size = new System.Drawing.Size(907, 516);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.panelDataMovieShows);
            this.panelHome.Controls.Add(this.groupBox1);
            this.panelHome.Controls.Add(this.groupBoxInputData);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Location = new System.Drawing.Point(0, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(907, 516);
            this.panelHome.TabIndex = 0;
            // 
            // groupBoxInputData
            // 
            this.groupBoxInputData.Controls.Add(this.labelDuration);
            this.groupBoxInputData.Controls.Add(this.labelBeginning);
            this.groupBoxInputData.Controls.Add(this.textBoxBeginning);
            this.groupBoxInputData.Controls.Add(this.labelNameCinema);
            this.groupBoxInputData.Controls.Add(this.labelDate);
            this.groupBoxInputData.Controls.Add(this.textBoxNameCinema);
            this.groupBoxInputData.Controls.Add(this.comboBoxGenreFilm);
            this.groupBoxInputData.Controls.Add(this.labelNameFilm);
            this.groupBoxInputData.Controls.Add(this.numericUpDownDuration);
            this.groupBoxInputData.Controls.Add(this.textBoxNameFilm);
            this.groupBoxInputData.Controls.Add(this.dateTimePickerDateShow);
            this.groupBoxInputData.Controls.Add(this.labelGenre);
            this.groupBoxInputData.Location = new System.Drawing.Point(13, 3);
            this.groupBoxInputData.Name = "groupBoxInputData";
            this.groupBoxInputData.Size = new System.Drawing.Size(300, 230);
            this.groupBoxInputData.TabIndex = 9;
            this.groupBoxInputData.TabStop = false;
            // 
            // labelDuration
            // 
            this.labelDuration.Location = new System.Drawing.Point(6, 185);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(143, 28);
            this.labelDuration.TabIndex = 11;
            this.labelDuration.Text = "Duration (min):";
            // 
            // labelBeginning
            // 
            this.labelBeginning.Location = new System.Drawing.Point(6, 152);
            this.labelBeginning.Name = "labelBeginning";
            this.labelBeginning.Size = new System.Drawing.Size(104, 28);
            this.labelBeginning.TabIndex = 10;
            this.labelBeginning.Text = "Beginning:";
            // 
            // textBoxBeginning
            // 
            this.textBoxBeginning.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBeginning.Location = new System.Drawing.Point(116, 151);
            this.textBoxBeginning.Name = "textBoxBeginning";
            this.textBoxBeginning.Size = new System.Drawing.Size(174, 29);
            this.textBoxBeginning.TabIndex = 9;
            // 
            // labelNameCinema
            // 
            this.labelNameCinema.Location = new System.Drawing.Point(6, 25);
            this.labelNameCinema.Name = "labelNameCinema";
            this.labelNameCinema.Size = new System.Drawing.Size(133, 28);
            this.labelNameCinema.TabIndex = 0;
            this.labelNameCinema.Text = "Name cinema:";
            // 
            // labelDate
            // 
            this.labelDate.Location = new System.Drawing.Point(124, 90);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(55, 23);
            this.labelDate.TabIndex = 8;
            this.labelDate.Text = "Date:";
            // 
            // textBoxNameCinema
            // 
            this.textBoxNameCinema.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameCinema.Location = new System.Drawing.Point(145, 24);
            this.textBoxNameCinema.Name = "textBoxNameCinema";
            this.textBoxNameCinema.Size = new System.Drawing.Size(145, 29);
            this.textBoxNameCinema.TabIndex = 1;
            // 
            // comboBoxGenreFilm
            // 
            this.comboBoxGenreFilm.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGenreFilm.FormattingEnabled = true;
            this.comboBoxGenreFilm.Location = new System.Drawing.Point(11, 116);
            this.comboBoxGenreFilm.Name = "comboBoxGenreFilm";
            this.comboBoxGenreFilm.Size = new System.Drawing.Size(112, 29);
            this.comboBoxGenreFilm.TabIndex = 7;
            // 
            // labelNameFilm
            // 
            this.labelNameFilm.Location = new System.Drawing.Point(6, 59);
            this.labelNameFilm.Name = "labelNameFilm";
            this.labelNameFilm.Size = new System.Drawing.Size(104, 28);
            this.labelNameFilm.TabIndex = 2;
            this.labelNameFilm.Text = "Name film:";
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownDuration.Location = new System.Drawing.Point(155, 186);
            this.numericUpDownDuration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(135, 29);
            this.numericUpDownDuration.TabIndex = 6;
            // 
            // textBoxNameFilm
            // 
            this.textBoxNameFilm.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameFilm.Location = new System.Drawing.Point(116, 59);
            this.textBoxNameFilm.Name = "textBoxNameFilm";
            this.textBoxNameFilm.Size = new System.Drawing.Size(174, 29);
            this.textBoxNameFilm.TabIndex = 3;
            // 
            // dateTimePickerDateShow
            // 
            this.dateTimePickerDateShow.CalendarFont = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateShow.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateShow.Location = new System.Drawing.Point(129, 116);
            this.dateTimePickerDateShow.Name = "dateTimePickerDateShow";
            this.dateTimePickerDateShow.Size = new System.Drawing.Size(161, 29);
            this.dateTimePickerDateShow.TabIndex = 5;
            // 
            // labelGenre
            // 
            this.labelGenre.Location = new System.Drawing.Point(6, 90);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(69, 28);
            this.labelGenre.TabIndex = 4;
            this.labelGenre.Text = "Genre:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHome);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 554);
            this.tabControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Location = new System.Drawing.Point(13, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 271);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(11, 25);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(279, 34);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(11, 65);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(279, 34);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(11, 105);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(279, 34);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // panelDataMovieShows
            // 
            this.panelDataMovieShows.Controls.Add(this.dataGridViewMovieShows);
            this.panelDataMovieShows.Location = new System.Drawing.Point(319, 16);
            this.panelDataMovieShows.Name = "panelDataMovieShows";
            this.panelDataMovieShows.Size = new System.Drawing.Size(574, 487);
            this.panelDataMovieShows.TabIndex = 13;
            // 
            // dataGridViewMovieShows
            // 
            this.dataGridViewMovieShows.AllowUserToAddRows = false;
            this.dataGridViewMovieShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovieShows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Film,
            this.Cinema,
            this.Genre,
            this.Date,
            this.Beginning,
            this.Duration});
            this.dataGridViewMovieShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMovieShows.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMovieShows.Name = "dataGridViewMovieShows";
            this.dataGridViewMovieShows.Size = new System.Drawing.Size(574, 487);
            this.dataGridViewMovieShows.TabIndex = 0;
            // 
            // Film
            // 
            this.Film.HeaderText = "Film";
            this.Film.Name = "Film";
            this.Film.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Cinema
            // 
            this.Cinema.HeaderText = "Cinema";
            this.Cinema.Name = "Cinema";
            // 
            // Genre
            // 
            this.Genre.HeaderText = "Genre";
            this.Genre.Name = "Genre";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Beginning
            // 
            this.Beginning.HeaderText = "Beginning";
            this.Beginning.Name = "Beginning";
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(11, 225);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(279, 34);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(11, 185);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(279, 34);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(11, 145);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(279, 34);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // FormJOMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 583);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormJOMovie";
            this.Text = "JOMovie";
            this.tabPageHome.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.groupBoxInputData.ResumeLayout(false);
            this.groupBoxInputData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelDataMovieShows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieShows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.GroupBox groupBoxInputData;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelBeginning;
        private System.Windows.Forms.TextBox textBoxBeginning;
        private System.Windows.Forms.Label labelNameCinema;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxNameCinema;
        private System.Windows.Forms.ComboBox comboBoxGenreFilm;
        private System.Windows.Forms.Label labelNameFilm;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.TextBox textBoxNameFilm;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateShow;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelDataMovieShows;
        private System.Windows.Forms.DataGridView dataGridViewMovieShows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Film;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cinema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beginning;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
    }
}

