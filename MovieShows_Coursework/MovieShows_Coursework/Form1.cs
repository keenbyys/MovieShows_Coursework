using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlTypes;

namespace MovieShows_Coursework
{
    public partial class FormJOMovie : Form
    {
        private string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";

        List<Billboard> billboard = new List<Billboard>();

        public FormJOMovie()
        {
            InitializeComponent();
            LoadDataFromXml(xmlFilePath);
        }
        // 
        // LOAD FORM
        //
        private void FormJOMovie_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm";
            dateTimePickerStart.Value = DateTime.Now.Date;

            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "HH:mm";
            dateTimePickerEnd.Value = DateTime.Now.Date;

            dataGridViewMovieShows_Home.RowTemplate.Height = 40;
            dataGridViewMovieShows_Search.RowTemplate.Height = 40;
        }


        // <STRUCT>
        //
        public struct Billboard
        {
            public string Film { get; set; }
            public string Cinema { get; set; }
            public string Genre { get; set; }
            public string Date { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public int Duration { get; set; }
        }
        //
        // Load a data from Xml-file to struct
        //
        private void LoadDataFromXml(string filePathXML)
        {
            XmlDocument xmlDocAllMovies = new XmlDocument();

            xmlDocAllMovies.Load(xmlFilePath);

            XmlNodeList itemNodes = xmlDocAllMovies.SelectNodes("//Billboard");

            foreach (XmlNode node in xmlDocAllMovies.DocumentElement)
            {
                string nameCinema = string.Format(node["Cinema"].InnerText);
                string nameFilm = string.Format(node["Film"].InnerText);
                string date = string.Format(node["Date"].InnerText);
                string genre = string.Format(node["Genre"].InnerText);
                string startTime = string.Format(node["Start"].InnerText);
                string endTime = string.Format(node["End"].InnerText);
                int duration = Convert.ToInt32(node["Duration"].InnerText);

                billboard.Add(new Billboard { Cinema = nameCinema, Film = nameFilm, Genre = genre, Date = date, Start = startTime, End = endTime, Duration = duration });
            }
        }
        // <STRUCT>


        // <HOME>
        //
        // add new row [button]
        //
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameFilm.Text == "" || textBoxNameCinema_Home.Text == "" || comboBoxGenreFilm.Text == ""
                || dateTimePickerStart.Text == "00:00" || dateTimePickerEnd.Text == "00:00" || numericUpDownDuration.Value == 0)
            {
                MessageBox.Show("Error!");
            }
            else
            {
                int n = dataGridViewMovieShows_Home.Rows.Add();
                dataGridViewMovieShows_Home.Rows[n].Cells[0].Value = textBoxNameFilm.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[1].Value = textBoxNameCinema_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[2].Value = comboBoxGenreFilm.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[3].Value = dateTimePickerDateShow_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[4].Value = dateTimePickerStart.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[5].Value = dateTimePickerEnd.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[6].Value = numericUpDownDuration.Text;
            }
        }
        //
        // edit row [button]
        // 
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieShows_Home.SelectedRows.Count > 0)
            {
                int n = dataGridViewMovieShows_Home.SelectedRows[0].Index;
                dataGridViewMovieShows_Home.Rows[n].Cells[0].Value = textBoxNameFilm.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[1].Value = textBoxNameCinema_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[2].Value = comboBoxGenreFilm.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[3].Value = dateTimePickerDateShow_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[4].Value = dateTimePickerStart.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[5].Value = dateTimePickerEnd.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[6].Value = numericUpDownDuration.Text;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        //
        // delete row [button]
        // 
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieShows_Home.SelectedRows.Count > 0)
            {
                dataGridViewMovieShows_Home.Rows.RemoveAt(dataGridViewMovieShows_Home.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }


        // <SAVE>
        //
        // save data to xml-file [button]
        //
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-file (*.xml)|*.xml";
            saveFileDialog.Title = "Save XML-file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                SaveToXML(dataGridViewMovieShows_Home, saveFileDialog.FileName);
            }
        }
        //
        // save data to xml-fil [procces]
        //
        private void SaveToXML(DataGridView dataGridViewMovieShow_Home, string xmlFileName)
        {
            try
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Billboard";
                dataTable.Columns.Add("Film");
                dataTable.Columns.Add("Cinema");
                dataTable.Columns.Add("Genre");
                dataTable.Columns.Add("Date");
                dataTable.Columns.Add("Start");
                dataTable.Columns.Add("End");
                dataTable.Columns.Add("Duration");

                dataSet.Tables.Add(dataTable);

                foreach (DataGridViewRow r in dataGridViewMovieShows_Home.Rows)
                {
                    DataRow row = dataSet.Tables["Billboard"].NewRow();
                    row["Film"] = r.Cells[0].Value;
                    row["Cinema"] = r.Cells[1].Value;
                    row["Genre"] = r.Cells[2].Value;
                    row["Date"] = r.Cells[3].Value;
                    row["Start"] = r.Cells[4].Value;
                    row["End"] = r.Cells[5].Value;
                    row["Duration"] = r.Cells[6].Value;

                    dataSet.Tables["Billboard"].Rows.Add(row);
                }
                dataSet.WriteXml(xmlFileName);
                MessageBox.Show("XML-file is saved!", "Done!");
            }
            catch
            {
                MessageBox.Show("Could not save XML-file", "Error!");
            }
        }
        // <SAVE>


        // load data from xml-file [button]
        //
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadDataFromXMLFile(dataGridViewMovieShows_Home);
        }
        // 
        // load data
        //
        private void LoadDataFromXMLFile(DataGridView dataGridView)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML-file (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (dataGridViewMovieShows_Home.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Please, clear the field before loading new XML-file!", "Error!");
                }
                else
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.ReadXml(openFileDialog.FileName);

                        foreach (DataRow item in dataSet.Tables[0].Rows)
                        {
                            if (dataGridView.ColumnCount == 0)
                            {
                                dataGridView.ColumnCount = 7;
                                dataGridView.Columns[0].Name = "Film";
                                dataGridView.Columns[1].Name = "Cinema";
                                dataGridView.Columns[2].Name = "Genre";
                                dataGridView.Columns[3].Name = "Date";
                                dataGridView.Columns[4].Name = "Start";
                                dataGridView.Columns[5].Name = "End";
                                dataGridView.Columns[6].Name = "Duration";

                                dataGridViewMovieShows_Search.Columns[0].Width = 250;

                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells[0].Value = item["Film"];
                                dataGridView.Rows[n].Cells[1].Value = item["Cinema"];
                                dataGridView.Rows[n].Cells[2].Value = item["Genre"];
                                dataGridView.Rows[n].Cells[3].Value = item["Date"];
                                dataGridView.Rows[n].Cells[4].Value = item["Start"];
                                dataGridView.Rows[n].Cells[5].Value = item["End"];
                                dataGridView.Rows[n].Cells[6].Value = item["Duration"];
                            }
                            else
                            {
                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells[0].Value = item["Film"];
                                dataGridView.Rows[n].Cells[1].Value = item["Cinema"];
                                dataGridView.Rows[n].Cells[2].Value = item["Genre"];
                                dataGridView.Rows[n].Cells[3].Value = item["Date"];
                                dataGridView.Rows[n].Cells[4].Value = item["Start"];
                                dataGridView.Rows[n].Cells[5].Value = item["End"];
                                dataGridView.Rows[n].Cells[6].Value = item["Duration"];
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("XML-file not found!", "Error!");
                    }
                }
            }
        }
        //
        // clear all rows in table [button]
        //
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieShows_Home.SelectedRows.Count > 0)
            {
                dataGridViewMovieShows_Home.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Table is empty!", "Error!");
            }
        }
        //
        // ADMIN RIGHT
        //
        private void checkBoxRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRoot.Checked)
            {
                textBoxNameCinema_Home.Enabled = true;
                textBoxNameFilm.Enabled = true;
                comboBoxGenreFilm.Enabled = true;
                dateTimePickerDateShow_Home.Enabled = true;
                dateTimePickerStart.Enabled = true;
                dateTimePickerEnd.Enabled = true;
                numericUpDownDuration.Enabled = true;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = true;
                buttonEdit.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                textBoxNameCinema_Home.Enabled = false;
                textBoxNameFilm.Enabled = false;
                comboBoxGenreFilm.Enabled = false;
                dateTimePickerDateShow_Home.Enabled = false;
                dateTimePickerStart.Enabled = false;
                dateTimePickerEnd.Enabled = false;
                numericUpDownDuration.Enabled = false;
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
                buttonSave.Enabled = false;
            }
        }
        // <HOME>


        // <SEARCH>
        //
        // selection sort [algorithm]
        //
        private void SelectionSortMovie()
        {
            for (int i = 0; i < billboard.Count - 1; i++)
            {
                int minValue = i;
                for (int j = i + 1; j < billboard.Count; j++)
                {
                    if (billboard[j].Duration < billboard[minValue].Duration)
                    {
                        minValue = j;
                    }
                }

                if (minValue != i)
                {
                    Billboard tempValue = billboard[i];
                    billboard[i] = billboard[minValue];
                    billboard[minValue] = tempValue;
                }
            }
        }
        //
        // binary search [algorithm]
        //
        private void BinarySeaech(string searchAnyDate)
        {
            int count = 0, i;
            int mid = 0, low = 0, high = billboard.Count;

            while (low <= high)
            {
                mid = low + high / 2;
            }

        }
        //
        // search [button]
        //
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SelectionSortMovie();
            if (radioButtonEndSessions.Checked == true)
                DisplayAllEndSessions();
            if (radioButtonSessionsWeeknd.Checked == true)
                DisplayWeekndSessions();
        }
        //
        // display all ends sessions
        //
        private void DisplayAllEndSessions()
        {
            dataGridViewMovieShows_Search.ColumnCount = 4;
            dataGridViewMovieShows_Search.Columns[0].Name = "Film";
            dataGridViewMovieShows_Search.Columns[1].Name = "Cinema";
            dataGridViewMovieShows_Search.Columns[2].Name = "Date";
            dataGridViewMovieShows_Search.Columns[3].Name = "End";

            dataGridViewMovieShows_Search.Columns[0].Width = 250;
            dataGridViewMovieShows_Search.Columns[1].Width = 150;
            dataGridViewMovieShows_Search.Columns[2].Width = 105;
            dataGridViewMovieShows_Search.Columns[3].Width = 65;

            dataGridViewMovieShows_Search.Rows.Clear();
            foreach (var billboard in billboard)
            {
                dataGridViewMovieShows_Search.Rows.Add(billboard.Film, billboard.Cinema, billboard.Date, billboard.End);
            }
        }
        //
        // weekend session
        //
        private void DisplayWeekndSessions()
        {
            DataSet billboard = new DataSet();
            billboard.ReadXml(xmlFilePath);


        }
        //
        // load upcoming session [button]
        //
        private void buttonLoadUpcomingReleases_Click(object sender, EventArgs e)
        {
            LoadDataFromXMLFile(dataGridViewMovieShows_Search);
        }
        //
        // clear all data [button]
        //
        private void buttonClear_Search_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieShows_Search.SelectedRows.Count > 0)
            {
                dataGridViewMovieShows_Search.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Table is empty!", "Error!");
            }
        }
        //
        // amount and average [radio button]
        //
        private void radioButtonAmountAndAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAmountAndAverage.Checked == true)
                dateTimePickerDateShow_Search.Enabled = true;
            else
                dateTimePickerDateShow_Search.Enabled = false;
        }
        //
        //  upcoming session [radio button]
        //
        private void radioButtonUpcoming_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUpcoming.Checked == true)
                buttonLoadUpcomingReleases.Enabled = true;
            else
                buttonLoadUpcomingReleases.Enabled = false;
        }
        // <SEARCH>


        // close app [button]
        //
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
