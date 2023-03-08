
namespace VKR_project
{
    partial class Form_Teg_Wtite
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
            this.tB_title_teg = new System.Windows.Forms.TextBox();
            this.tB_albom_teg = new System.Windows.Forms.TextBox();
            this.tB_track_teg = new System.Windows.Forms.TextBox();
            this.tB_year_teg = new System.Windows.Forms.TextBox();
            this.tB_lyrics_teg = new System.Windows.Forms.TextBox();
            this.lab_title = new System.Windows.Forms.Label();
            this.lab_album = new System.Windows.Forms.Label();
            this.lab_track = new System.Windows.Forms.Label();
            this.lab_year = new System.Windows.Forms.Label();
            this.lab_lyrics = new System.Windows.Forms.Label();
            this.but_save_teg = new System.Windows.Forms.Button();
            this.but_img_add = new System.Windows.Forms.Button();
            this.tB_artist_teg = new System.Windows.Forms.TextBox();
            this.tB_albom_artist_teg = new System.Windows.Forms.TextBox();
            this.tB_genre_teg = new System.Windows.Forms.TextBox();
            this.lab_artist = new System.Windows.Forms.Label();
            this.lab_albom_artist = new System.Windows.Forms.Label();
            this.lab_genre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tB_title_teg
            // 
            this.tB_title_teg.Location = new System.Drawing.Point(76, 12);
            this.tB_title_teg.Name = "tB_title_teg";
            this.tB_title_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_title_teg.TabIndex = 0;
            // 
            // tB_albom_teg
            // 
            this.tB_albom_teg.Location = new System.Drawing.Point(76, 38);
            this.tB_albom_teg.Name = "tB_albom_teg";
            this.tB_albom_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_albom_teg.TabIndex = 1;
            // 
            // tB_track_teg
            // 
            this.tB_track_teg.Location = new System.Drawing.Point(76, 64);
            this.tB_track_teg.Name = "tB_track_teg";
            this.tB_track_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_track_teg.TabIndex = 2;
            // 
            // tB_year_teg
            // 
            this.tB_year_teg.Location = new System.Drawing.Point(76, 90);
            this.tB_year_teg.Name = "tB_year_teg";
            this.tB_year_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_year_teg.TabIndex = 3;
            // 
            // tB_lyrics_teg
            // 
            this.tB_lyrics_teg.Location = new System.Drawing.Point(76, 195);
            this.tB_lyrics_teg.Multiline = true;
            this.tB_lyrics_teg.Name = "tB_lyrics_teg";
            this.tB_lyrics_teg.Size = new System.Drawing.Size(219, 161);
            this.tB_lyrics_teg.TabIndex = 5;
            // 
            // lab_title
            // 
            this.lab_title.AutoSize = true;
            this.lab_title.Location = new System.Drawing.Point(12, 15);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(60, 13);
            this.lab_title.TabIndex = 6;
            this.lab_title.Text = "Название:";
            // 
            // lab_album
            // 
            this.lab_album.AutoSize = true;
            this.lab_album.Location = new System.Drawing.Point(12, 41);
            this.lab_album.Name = "lab_album";
            this.lab_album.Size = new System.Drawing.Size(49, 13);
            this.lab_album.TabIndex = 7;
            this.lab_album.Text = "Альбом:";
            // 
            // lab_track
            // 
            this.lab_track.AutoSize = true;
            this.lab_track.Location = new System.Drawing.Point(12, 67);
            this.lab_track.Name = "lab_track";
            this.lab_track.Size = new System.Drawing.Size(35, 13);
            this.lab_track.TabIndex = 8;
            this.lab_track.Text = "Трек:";
            // 
            // lab_year
            // 
            this.lab_year.AutoSize = true;
            this.lab_year.Location = new System.Drawing.Point(12, 93);
            this.lab_year.Name = "lab_year";
            this.lab_year.Size = new System.Drawing.Size(28, 13);
            this.lab_year.TabIndex = 9;
            this.lab_year.Text = "Год:";
            // 
            // lab_lyrics
            // 
            this.lab_lyrics.AutoSize = true;
            this.lab_lyrics.Location = new System.Drawing.Point(12, 198);
            this.lab_lyrics.Name = "lab_lyrics";
            this.lab_lyrics.Size = new System.Drawing.Size(40, 13);
            this.lab_lyrics.TabIndex = 11;
            this.lab_lyrics.Text = "Текст:";
            // 
            // but_save_teg
            // 
            this.but_save_teg.Location = new System.Drawing.Point(226, 375);
            this.but_save_teg.Name = "but_save_teg";
            this.but_save_teg.Size = new System.Drawing.Size(75, 23);
            this.but_save_teg.TabIndex = 12;
            this.but_save_teg.Text = "Сохранить";
            this.but_save_teg.UseVisualStyleBackColor = true;
            this.but_save_teg.Click += new System.EventHandler(this.but_save_teg_Click);
            // 
            // but_img_add
            // 
            this.but_img_add.Image = global::VKR_project.Properties.Resources.AddImg_Img;
            this.but_img_add.Location = new System.Drawing.Point(15, 319);
            this.but_img_add.Name = "but_img_add";
            this.but_img_add.Size = new System.Drawing.Size(43, 37);
            this.but_img_add.TabIndex = 13;
            this.but_img_add.UseVisualStyleBackColor = true;
            this.but_img_add.Click += new System.EventHandler(this.but_img_add_Click);
            // 
            // tB_artist_teg
            // 
            this.tB_artist_teg.Location = new System.Drawing.Point(76, 117);
            this.tB_artist_teg.Name = "tB_artist_teg";
            this.tB_artist_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_artist_teg.TabIndex = 14;
            // 
            // tB_albom_artist_teg
            // 
            this.tB_albom_artist_teg.Location = new System.Drawing.Point(76, 143);
            this.tB_albom_artist_teg.Name = "tB_albom_artist_teg";
            this.tB_albom_artist_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_albom_artist_teg.TabIndex = 15;
            // 
            // tB_genre_teg
            // 
            this.tB_genre_teg.Location = new System.Drawing.Point(76, 169);
            this.tB_genre_teg.Name = "tB_genre_teg";
            this.tB_genre_teg.Size = new System.Drawing.Size(219, 20);
            this.tB_genre_teg.TabIndex = 16;
            // 
            // lab_artist
            // 
            this.lab_artist.AutoSize = true;
            this.lab_artist.Location = new System.Drawing.Point(12, 120);
            this.lab_artist.Name = "lab_artist";
            this.lab_artist.Size = new System.Drawing.Size(42, 13);
            this.lab_artist.TabIndex = 17;
            this.lab_artist.Text = "Испол:";
            // 
            // lab_albom_artist
            // 
            this.lab_albom_artist.AutoSize = true;
            this.lab_albom_artist.Location = new System.Drawing.Point(12, 146);
            this.lab_albom_artist.Name = "lab_albom_artist";
            this.lab_albom_artist.Size = new System.Drawing.Size(64, 13);
            this.lab_albom_artist.TabIndex = 18;
            this.lab_albom_artist.Text = "Исп. Альб.:";
            // 
            // lab_genre
            // 
            this.lab_genre.AutoSize = true;
            this.lab_genre.Location = new System.Drawing.Point(12, 172);
            this.lab_genre.Name = "lab_genre";
            this.lab_genre.Size = new System.Drawing.Size(39, 13);
            this.lab_genre.TabIndex = 19;
            this.lab_genre.Text = "Жанр:";
            // 
            // Form_Teg_Wtite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 410);
            this.Controls.Add(this.lab_genre);
            this.Controls.Add(this.lab_albom_artist);
            this.Controls.Add(this.lab_artist);
            this.Controls.Add(this.tB_genre_teg);
            this.Controls.Add(this.tB_albom_artist_teg);
            this.Controls.Add(this.tB_artist_teg);
            this.Controls.Add(this.but_img_add);
            this.Controls.Add(this.but_save_teg);
            this.Controls.Add(this.lab_lyrics);
            this.Controls.Add(this.lab_year);
            this.Controls.Add(this.lab_track);
            this.Controls.Add(this.lab_album);
            this.Controls.Add(this.lab_title);
            this.Controls.Add(this.tB_lyrics_teg);
            this.Controls.Add(this.tB_year_teg);
            this.Controls.Add(this.tB_track_teg);
            this.Controls.Add(this.tB_albom_teg);
            this.Controls.Add(this.tB_title_teg);
            this.MaximizeBox = false;
            this.Name = "Form_Teg_Wtite";
            this.Text = "Form_Teg_Wtite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_title_teg;
        private System.Windows.Forms.TextBox tB_albom_teg;
        private System.Windows.Forms.TextBox tB_track_teg;
        private System.Windows.Forms.TextBox tB_year_teg;
        private System.Windows.Forms.TextBox tB_lyrics_teg;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Label lab_album;
        private System.Windows.Forms.Label lab_track;
        private System.Windows.Forms.Label lab_year;
        private System.Windows.Forms.Label lab_lyrics;
        private System.Windows.Forms.Button but_save_teg;
        private System.Windows.Forms.Button but_img_add;
        private System.Windows.Forms.TextBox tB_artist_teg;
        private System.Windows.Forms.TextBox tB_albom_artist_teg;
        private System.Windows.Forms.TextBox tB_genre_teg;
        private System.Windows.Forms.Label lab_artist;
        private System.Windows.Forms.Label lab_albom_artist;
        private System.Windows.Forms.Label lab_genre;
    }
}