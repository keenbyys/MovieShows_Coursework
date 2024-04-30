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
using System.IO;
using System.Runtime.InteropServices;

namespace MovieShows_Coursework
{
    public partial class FormJOMovie : Form
    {
        private string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";
        public FormJOMovie()
        {
            InitializeComponent();
            LoadDataFromXml();
        }

        public struct Billboard 
        {
            public string Cinema { get; set; }
            public string Film { get; set; }
            public string Genre { get; set; }
            public string Date { get; set; }
            public string Start { get; set; }
            public string End { get; set; }   
            public int Duration { get; set; }
        }

        // Load a data from Xml-file to struct
        private void LoadDataFromXml()
        {
            List<Billboard> items = new List<Billboard>(); 
            XmlDocument xmlDocAllMovies = new XmlDocument();
            
            //string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";
            xmlDocAllMovies.Load(xmlFilePath);
            
            XmlNodeList itemNodes = xmlDocAllMovies.SelectNodes("//Billboard");

            foreach (XmlNode node in xmlDocAllMovies.DocumentElement)
            {
                string nameCinema = string.Format(node["Film"].InnerText);
                string nameFilm = string.Format(node["Cinema"].InnerText);
                string date = string.Format(node["Date"].InnerText);
                string genre = string.Format(node["Genre"].InnerText);
                string startTime = string.Format(node["Start"].InnerText);
                string endTime = string.Format(node["End"].InnerText);
                int duration = Convert.ToInt32(node["Duration"].InnerText);

                items.Add(new Billboard { Cinema = nameCinema, Film = nameFilm, Genre = genre, Date = date, Start = startTime, End = endTime });    
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameFilm.Text == "" || textBoxNameCinema_Home.Text == "" || comboBoxGenreFilm.Text == ""
                || dateTimePickerStart.Text == "00:00" || dateTimePickerEnd.Text == "00:00" || numericUpDownDuration.Value == 0)
            {
                MessageBox.Show("Error!");
            } else
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Movie Show";
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
                    DataRow row = dataSet.Tables["Movie Show"].NewRow();
                    row["Film"] = r.Cells[0].Value;
                    row["Cinema"] = r.Cells[1].Value;
                    row["Genre"] = r.Cells[2].Value;
                    row["Date"] = r.Cells[3].Value;
                    row["Start"] = r.Cells[4].Value;
                    row["End"] = r.Cells[5].Value;
                    row["Duration"] = r.Cells[6].Value;

                    dataSet.Tables["Movie Show"].Rows.Add(row);
                }
                dataSet.WriteXml(xmlFilePath);
                MessageBox.Show("XML-file is saved!", "Done!");
            }
            catch
            {
                MessageBox.Show("Could not save XML-file", "Error!");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";
            if (dataGridViewMovieShows_Home.SelectedRows.Count > 0)
            {
                MessageBox.Show("Please, clear the field before loading new XML-file!", "Error!");
            }
            else
            {
                if (File.Exists(xmlFilePath))
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(xmlFilePath);
                 
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        int n = dataGridViewMovieShows_Home.Rows.Add();
                        dataGridViewMovieShows_Home.Rows[n].Cells[0].Value = item["Film"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[1].Value = item["Cinema"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[2].Value = item["Date"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[3].Value = item["Genre"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[4].Value = item["Start"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[5].Value = item["End"];
                        dataGridViewMovieShows_Home.Rows[n].Cells[6].Value = item["Duration"];
                    }
                }
                else
                {
                    MessageBox.Show("XML-file not found!", "Error!");
                }
            }
        }

        //Close App
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Enable more function for admin
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
                buttonClear.Enabled = true;
                buttonDelete.Enabled = true;
                buttonEdit.Enabled = true;
                buttonSave.Enabled = true;
            } else
            {
                textBoxNameCinema_Home.Enabled = false;
                textBoxNameFilm.Enabled = false;
                comboBoxGenreFilm.Enabled = false;
                dateTimePickerDateShow_Home.Enabled = false;
                dateTimePickerStart.Enabled = false;
                dateTimePickerEnd.Enabled = false;
                numericUpDownDuration.Enabled = false;
                buttonAdd.Enabled = false;
                buttonClear.Enabled = false;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void TimePickerCustomFormat()
        {
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm";
            dateTimePickerStart.Value = DateTime.Now.Date;

            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "HH:mm";
            dateTimePickerEnd.Value = DateTime.Now.Date;
        }

        private void FormJOMovie_Load(object sender, EventArgs e)
        {
            TimePickerCustomFormat();
            dataGridViewMovieShows_Home.RowTemplate.Height = 40;
        }
    }
}
