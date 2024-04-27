using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieShows_Coursework
{
    public partial class FormJOMovie : Form
    {
        public FormJOMovie()
        {
            InitializeComponent();
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
