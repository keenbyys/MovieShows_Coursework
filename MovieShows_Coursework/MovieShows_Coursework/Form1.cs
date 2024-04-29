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

namespace MovieShows_Coursework
{
    public partial class FormJOMovie : Form
    {
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
            
            string xmlFilePath = "C:\\Users\\sjdro\\source\\repos\\MovieShows_Coursework\\MovieShows_Coursework\\MovieShows_Coursework\\AllMovies.xml";
            xmlDocAllMovies.Load(xmlFilePath);
            
            XmlNodeList itemNodes = xmlDocAllMovies.SelectNodes("//Billboard");

            foreach (XmlNode node in xmlDocAllMovies.DocumentElement)
            {
                string nameCinema = node.Attributes[0].Value;
                string nameFilm = string.Format(node["Cinema"].InnerText);
                string date = string.Format(node["Date"].InnerText);
                string genre = string.Format(node["Genre"].InnerText);
                string startTime = string.Format(node["Start"].InnerText);
                string endTime = string.Format(node["End"].InnerText);
                int duration = Convert.ToInt32(node["Duration"].InnerText);

                items.Add(new Billboard { Cinema = nameCinema, Film = nameFilm, Genre = genre, Date = date, Start = startTime, End = endTime });    
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

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
                textBoxBeginning.Enabled = true;
                textBoxEnd.Enabled = true;
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
                textBoxBeginning.Enabled = false;
                textBoxEnd.Enabled = false;
                numericUpDownDuration.Enabled = false;
                buttonAdd.Enabled = false;
                buttonClear.Enabled = false;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
                buttonSave.Enabled = false;
            }
        }


    }
}
