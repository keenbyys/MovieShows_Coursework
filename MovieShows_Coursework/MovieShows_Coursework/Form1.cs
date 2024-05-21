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
using static MovieShows_Coursework.FormJOMovie;
using static System.Net.WebRequestMethods;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MovieShows_Coursework
{
    public partial class FormJOMovie : Form
    {
        // PeREMOGA
        private string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";

        List<Billboard> billboard = new List<Billboard>();

        public FormJOMovie()
        {
            InitializeComponent();
            LoadDataFromXml(xmlFilePath);
        }
        

        private void FormJOMovie_Load(object sender, EventArgs e)
        {
            comboBoxNameCinema_Search.Items.Add("EvilLight");
            comboBoxNameCinema_Search.Items.Add("RestlessDreams");
            comboBoxNameCinema_Search.Items.Add("VibeJo");

            comboBoxGenreFilm.Items.Add("Action");
            comboBoxGenreFilm.Items.Add("Comedy");
            comboBoxGenreFilm.Items.Add("Drama");
            comboBoxGenreFilm.Items.Add("Fantasy");
            comboBoxGenreFilm.Items.Add("Horror");
            comboBoxGenreFilm.Items.Add("Thriller");
            comboBoxGenreFilm.Items.Add("Mystery");

            comboBoxDayOfWeeknd.Items.Add("Monday");
            comboBoxDayOfWeeknd.Items.Add("Tuesday");
            comboBoxDayOfWeeknd.Items.Add("Wednesday");
            comboBoxDayOfWeeknd.Items.Add("Thursday");
            comboBoxDayOfWeeknd.Items.Add("Friday");
            comboBoxDayOfWeeknd.Items.Add("Saturday");
            comboBoxDayOfWeeknd.Items.Add("Sunday");

            comboBoxNameCinema_Home.Items.Add("EvilLight");
            comboBoxNameCinema_Home.Items.Add("RestlessDreams");
            comboBoxNameCinema_Home.Items.Add("VibeJo");

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
            public string Day { get; set; }
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
                string day = string.Format(node["Day"].InnerText);
                string genre = string.Format(node["Genre"].InnerText);
                string startTime = string.Format(node["Start"].InnerText);
                string endTime = string.Format(node["End"].InnerText);
                int duration = Convert.ToInt32(node["Duration"].InnerText);

                billboard.Add(new Billboard { Cinema = nameCinema, Film = nameFilm, Genre = genre, Date = date, Day = day, Start = startTime, End = endTime, Duration = duration });
            }
        }
        // <STRUCT>


        // <HOME>
        //
        // add new row [button]
        //
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameFilm.Text == "" || comboBoxNameCinema_Home.Text == "" || comboBoxGenreFilm.Text == ""
                || dateTimePickerStart.Text == "00:00" || dateTimePickerEnd.Text == "00:00" || numericUpDownDuration.Value == 0)
            {
                MessageBox.Show("Fill in all the fields!");
            }
            else
            {
                string film = textBoxNameFilm.Text;
                string cinema = comboBoxNameCinema_Home.Text;
                string genre = comboBoxGenreFilm.Text;
                string date = dateTimePickerDateShow_Home.Text;
                string day = comboBoxDayOfWeeknd.Text;
                string start = dateTimePickerStart.Text;
                string end = dateTimePickerEnd.Text;
                int duration = Convert.ToInt32(numericUpDownDuration.Text);

                if (!IsDuplicateData(film, cinema, genre, date, day, start, end, duration))
                {
                    int n = dataGridViewMovieShows_Home.Rows.Add();
                    dataGridViewMovieShows_Home.Rows[n].Cells[0].Value = film;
                    dataGridViewMovieShows_Home.Rows[n].Cells[1].Value = cinema;
                    dataGridViewMovieShows_Home.Rows[n].Cells[2].Value = genre;
                    dataGridViewMovieShows_Home.Rows[n].Cells[3].Value = date;
                    dataGridViewMovieShows_Home.Rows[n].Cells[4].Value = day;
                    dataGridViewMovieShows_Home.Rows[n].Cells[5].Value = start;
                    dataGridViewMovieShows_Home.Rows[n].Cells[6].Value = end;
                    dataGridViewMovieShows_Home.Rows[n].Cells[7].Value = duration;

                    dataGridViewMovieShows_Home.Sort(dataGridViewMovieShows_Home.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("Duplicate data. The data already exists.");
                }

            }
        }
        //
        // duplicate data [bool]
        //
        private bool IsDuplicateData(string film, string cinema, string genre, string date, string day, string start, string end, int duration)
        {
            foreach (DataGridViewRow row in dataGridViewMovieShows_Home.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString() == film && 
                    row.Cells[1].Value.ToString() == cinema && 
                    row.Cells[2].Value.ToString() == genre && 
                    row.Cells[3].Value.ToString() == date && 
                    row.Cells[4].Value.ToString() == day && 
                    row.Cells[5].Value.ToString() == start &&
                    row.Cells[6].Value.ToString() == end && 
                    Convert.ToInt32(row.Cells[7].Value)== duration)
                {
                    return true;
                }
            }
            return false;
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
                dataGridViewMovieShows_Home.Rows[n].Cells[1].Value = comboBoxNameCinema_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[2].Value = comboBoxGenreFilm.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[3].Value = dateTimePickerDateShow_Home.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[4].Value = comboBoxDayOfWeeknd.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[5].Value = dateTimePickerStart.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[6].Value = dateTimePickerEnd.Text;
                dataGridViewMovieShows_Home.Rows[n].Cells[7].Value = numericUpDownDuration.Text;
            }
            else
            {
                MessageBox.Show("Error!\nTry again!");
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
                MessageBox.Show("Error!\nTry again!");
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
                dataTable.Columns.Add("Day");
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
                    row["Day"] = r.Cells[4].Value;
                    row["Start"] = r.Cells[5].Value;
                    row["End"] = r.Cells[6].Value;
                    row["Duration"] = r.Cells[7].Value;

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
                    if (System.IO.File.Exists(openFileDialog.FileName))
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.ReadXml(openFileDialog.FileName);

                        foreach (DataRow item in dataSet.Tables[0].Rows)
                        {
                            if (dataGridView.ColumnCount == 0)
                            {
                                dataGridView.ColumnCount = 8;
                                dataGridView.Columns[0].Name = "Film";
                                dataGridView.Columns[1].Name = "Cinema";
                                dataGridView.Columns[2].Name = "Genre";
                                dataGridView.Columns[3].Name = "Date";
                                dataGridView.Columns[4].Name = "Day";
                                dataGridView.Columns[5].Name = "Start";
                                dataGridView.Columns[6].Name = "End";
                                dataGridView.Columns[7].Name = "Duration";

                                dataGridViewMovieShows_Search.Columns[0].Width = 250;

                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells[0].Value = item["Film"];
                                dataGridView.Rows[n].Cells[1].Value = item["Cinema"];
                                dataGridView.Rows[n].Cells[2].Value = item["Genre"];
                                dataGridView.Rows[n].Cells[3].Value = item["Date"];
                                dataGridView.Rows[n].Cells[4].Value = item["Day"];
                                dataGridView.Rows[n].Cells[5].Value = item["Start"];
                                dataGridView.Rows[n].Cells[6].Value = item["End"];
                                dataGridView.Rows[n].Cells[7].Value = item["Duration"];

                                dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                            }
                            else
                            {
                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells[0].Value = item["Film"];
                                dataGridView.Rows[n].Cells[1].Value = item["Cinema"];
                                dataGridView.Rows[n].Cells[2].Value = item["Genre"];
                                dataGridView.Rows[n].Cells[3].Value = item["Date"];
                                dataGridView.Rows[n].Cells[4].Value = item["Day"];
                                dataGridView.Rows[n].Cells[5].Value = item["Start"];
                                dataGridView.Rows[n].Cells[6].Value = item["End"];
                                dataGridView.Rows[n].Cells[7].Value = item["Duration"];

                                dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
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
                comboBoxNameCinema_Home.Enabled = true;
                textBoxNameFilm.Enabled = true;
                comboBoxGenreFilm.Enabled = true;
                dateTimePickerDateShow_Home.Enabled = true;
                comboBoxDayOfWeeknd.Enabled = true;
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
                comboBoxNameCinema_Home.Enabled = false;
                textBoxNameFilm.Enabled = false;
                comboBoxGenreFilm.Enabled = false;
                dateTimePickerDateShow_Home.Enabled = false;
                comboBoxDayOfWeeknd.Enabled= false;
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
        private void SelectionSortStart(List<Billboard> billboards)
        {
            for (int i = 0; i < billboards.Count - 1; i++)
            {
                int minValue = i;
                for (int j = i + 1; j < billboards.Count; j++)
                {
                    if (CompareSessions(billboards[j], billboards[minValue]) < 0)
                    {
                        minValue = j;
                    }
                }
                Swap(billboards, i, minValue);
            }
        }
        private void Swap(List<Billboard> billboards, int i, int min)
        {
            var tempValue = billboards[i];
            billboards[i] = billboards[min];
            billboards[min] = tempValue;
        }

        private int CompareSessions(Billboard a, Billboard b)
        {
            int dateComparison = a.Date.CompareTo(b.Date);
            if (dateComparison != 0) return dateComparison;

            int cinemaComparison = a.Cinema.CompareTo(b.Cinema);
            if (cinemaComparison != 0) return cinemaComparison;

            return a.Start.CompareTo(b.Start);
        }
        //
        // binary search [algorythm]
        //
        private int BinarySearch(List<Billboard> sessions, string targetDate, string targetCinema)
        {
            int low = 0;
            int high = sessions.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (sessions[mid].Date.CompareTo(targetDate) < 0 ||
                    (sessions[mid].Date == targetDate && sessions[mid].Cinema.CompareTo(targetCinema) < 0))
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (low < sessions.Count && sessions[low].Date == targetDate && sessions[low].Cinema == targetCinema)
            {
                return low;
            }

            return -1;
        }
        //
        // calculate sessions and average duration [button]
        //
        private void CalculateSessionsAndAverageDuration()
        {
            string date = dateTimePickerDateShow_Search.Text;

            List<Billboard> filmsOnDate = billboard.Where(f => f.Date == date).ToList();

            if (filmsOnDate.Any())
            {
                int totalDuration = filmsOnDate.Sum(f => f.Duration);
                int count = filmsOnDate.Count;
                double averageDuration = count > 0 ? (double)totalDuration / count : 0;

                labelAmountResult.Text = $"{count}";
                labelAverageResult.Text = $"{averageDuration}";
            }
            else
            {
                MessageBox.Show("There're no session on this day!");
            }
        }
        //
        // search [button]
        //
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            if (radioButtonEndSessions.Checked == true)
            {
                SelectionSortStart(billboard);
                DisplayAllEndSessions();
            }
            if (radioButtonSessionsWeeknd.Checked == true)
            {
                SelectionSortStart(billboard);
                DisplayWeekndSessions();
            }
            if (radioButtonFirstSessions.Checked == true)
            {
                //SelectionSortStart(billboard);
                if (comboBoxNameCinema_Search.Text == "")
                {
                    MessageBox.Show("Enter name of cinema!");
                } 
                else
                {
                    string searchCinema = comboBoxNameCinema_Search.Text;
                    string searchDate = dateTimePickerDateShow_Search.Text;

                    FindFirstSession(searchCinema, searchDate);
                }
            }
            if (radioButtonAmountAndAverage.Checked == true)
            {
                CalculateSessionsAndAverageDuration();
            }
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
            var weekendSessions = new List<Billboard>();
            foreach (var session in billboard)
            {
                if (session.Day == "Saturday" || session.Day == "Sunday")
                {
                    weekendSessions.Add(session);
                }
            }

            SettingDataGridView();

            foreach (var session in weekendSessions)
            {
                string[] row = new string[]
                {
                    session.Film,
                    session.Cinema,
                    session.Genre,
                    session.Date,
                    session.Day,
                    session.Start,
                    session.End,
                    session.Duration.ToString()
                };
                dataGridViewMovieShows_Search.Rows.Add(row);
            }

        }
        //
        // first sessions 
        //
        private void FindFirstSession(string cinemaName, string targetDate)
        {
            SelectionSortStart(billboard);
            
            // Виклик бінарного пошуку
            int index = BinarySearch(billboard, targetDate, cinemaName);

            // Перевірка наявності сеансів для вказаної дати та кінотеатру
            if (index != -1)
            { 
                Billboard firstSession = billboard[index];

                // Додаємо дані у DataGridView
                dataGridViewMovieShows_Search.Rows.Clear();

                SettingDataGridView();

                dataGridViewMovieShows_Search.Rows.Add(firstSession.Film, firstSession.Cinema, firstSession.Genre, firstSession.Date, firstSession.Day, firstSession.Start, firstSession.End, firstSession.Duration);
            }
            else
            {
                MessageBox.Show("There're no session on this day!");
            }
        }
        //
        // setting DataGridView
        //
        private void SettingDataGridView()
        {
            dataGridViewMovieShows_Search.ColumnCount = 8;
            dataGridViewMovieShows_Search.Columns[0].Name = "Film";
            dataGridViewMovieShows_Search.Columns[1].Name = "Cinema";
            dataGridViewMovieShows_Search.Columns[2].Name = "Genre";
            dataGridViewMovieShows_Search.Columns[3].Name = "Date";
            dataGridViewMovieShows_Search.Columns[4].Name = "Day";
            dataGridViewMovieShows_Search.Columns[5].Name = "Start";
            dataGridViewMovieShows_Search.Columns[6].Name = "End";
            dataGridViewMovieShows_Search.Columns[7].Name = "Duration";

            dataGridViewMovieShows_Search.Columns[0].Width = 250;
            dataGridViewMovieShows_Search.Columns[1].Width = 150;
            dataGridViewMovieShows_Search.Columns[2].Width = 85;
            dataGridViewMovieShows_Search.Columns[3].Width = 105;
            dataGridViewMovieShows_Search.Columns[4].Width = 95;
            dataGridViewMovieShows_Search.Columns[5].Width = 70;
            dataGridViewMovieShows_Search.Columns[6].Width = 70;
            dataGridViewMovieShows_Search.Columns[7].Width = 90;
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
            {
                dataGridViewMovieShows_Search.Columns.Clear();
                dataGridViewMovieShows_Search.Rows.Clear();
                dateTimePickerDateShow_Search.Enabled = true;
            }
            else
            {
                labelAmountResult.Text = "";
                labelAverageResult.Text = "";
                dateTimePickerDateShow_Search.Enabled = false;
            }
        }
        //
        //  upcoming session [radio button]
        //
        private void radioButtonUpcoming_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUpcoming.Checked == true)
            {
                dataGridViewMovieShows_Search.Columns.Clear();
                dataGridViewMovieShows_Search.Rows.Clear();
                buttonLoadUpcomingReleases.Enabled = true;
                buttonSearch.Enabled = false;
            }
            else
            {
                buttonLoadUpcomingReleases.Enabled = false;
                buttonSearch.Enabled = true;
            }
        }

        private void radioButtonEndSessions_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEndSessions.Checked == true)
            {
                dataGridViewMovieShows_Search.Columns.Clear();
                dataGridViewMovieShows_Search.Rows.Clear();
            }
        }

        private void radioButtonSessionsWeeknd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSessionsWeeknd.Checked == true)
            {
                dataGridViewMovieShows_Search.Columns.Clear();
                dataGridViewMovieShows_Search.Rows.Clear();
            }
        }

        private void radioButtonFirstSessions_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFirstSessions.Checked == true)
            {
                dataGridViewMovieShows_Search.Columns.Clear();
                dataGridViewMovieShows_Search.Rows.Clear();
                dateTimePickerDateShow_Search.Enabled = true;
                comboBoxNameCinema_Search.Enabled = true;
            } 
            else
            {
                dateTimePickerDateShow_Search.Enabled = false;
                comboBoxNameCinema_Search.Enabled = false;
            }
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
