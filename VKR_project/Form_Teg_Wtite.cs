using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace VKR_project
{
    public partial class Form_Teg_Wtite : Form
    {
        private string file;

        public Form_Teg_Wtite(string _file)
        {
            InitializeComponent();

            this.file = _file;

            StartPosition = FormStartPosition.CenterParent;

            //ClientSize = new Size(329, 356);

            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        string set_image_path;

        private void but_save_teg_Click(object sender, EventArgs e)
        {
            Teg_Write(file);
        }

        private string[] GetStringArray(string _data)
        {
            return new[] { _data };
        }

        [Obsolete]
        internal void Teg_Write(string _file)
        {
            TagLib.File teg_write = TagLib.File.Create(_file);
            teg_write.Tag.Title = tB_title_teg.Text;
            teg_write.Tag.Album = tB_albom_teg.Text;
            teg_write.Tag.Lyrics = tB_lyrics_teg.Text;
            teg_write.Tag.AlbumArtists = GetStringArray(tB_albom_artist_teg.Text);
            teg_write.Tag.Artists = GetStringArray(tB_artist_teg.Text);
            teg_write.Tag.Genres = GetStringArray(tB_genre_teg.Text);

            if (set_image_path != "")
            {
                IPicture[] picture = new IPicture[1] { Picture.CreateFromPath(set_image_path) };
                teg_write.Tag.Pictures = picture;
            }

            try { teg_write.Tag.Year = uint.Parse(tB_year_teg.Text); } 
            catch { teg_write.Tag.Year = 0; }

            try { teg_write.Tag.Track = uint.Parse(tB_track_teg.Text); }
            catch { teg_write.Tag.Track = 0; }

            try
            {
                teg_write.Save();
            }
            catch { BassWork.Stop(); teg_write.Save(); }
        }

        private void but_img_add_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_img = new OpenFileDialog();
            open_img.Filter = "All|*.jpg; *.png; *.bmp" + "|JPG (*.jpg)|*.jpg" + "|PNG (*.png)|*.png" + "|BMP (*.bmp)|*.bmp";

            try
            {
                if (open_img.ShowDialog() == DialogResult.OK)
                {
                    if (VarData.Get_Flag_Point_Control(open_img.FileName))
                    {
                        set_image_path = open_img.FileName;
                    }
                }
            }
            catch { }
        }
    }
}