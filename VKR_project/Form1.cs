using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Un4seen.Bass.AddOn.Tags;
using System.Net;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;

namespace VKR_project
{
    public partial class Form_win : Form
    {
        public Form_win()
        {
            InitializeComponent();
            VarData.form_winP = this;
            this.KeyPreview = true;
            BassWork.Init_Bass_Lib(BassWork.hz);
            VarData.Set_Input_Formats();
        }

        string[] files;
        bool flag_trB_one_scroll = false;

        private void toolStripMenuItem_open_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
        }

        private void but_play_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                if(!flag_trB_one_scroll) { flag_trB_one_scroll = true; trB_vol_Scroll(sender, e); }
                string current = VarData.file_list[lB_Play_List.SelectedIndex];
                VarData.current_track_number = lB_Play_List.SelectedIndex;
                BassWork.Play(current, BassWork.volume);
                lab_time1.Text = TimeSpan.FromSeconds(BassWork.Get_Pos_Of_Stream(BassWork.stream)).ToString();
                lab_time2.Text = TimeSpan.FromSeconds(BassWork.Get_Time_Of_Stream(BassWork.stream)).ToString();
                trB_time.Maximum = BassWork.Get_Time_Of_Stream(BassWork.stream);
                trB_time.Value = BassWork.Get_Pos_Of_Stream(BassWork.stream);
                timer.Enabled = true;

                //try
                //{
                //pb_covers.Update();
                //pb_covers.Size = new Size(1000, 1000);
                pb_covers.Image = TegWork.image;
                pb_covers.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_covers.Update();

                //}
                /*catch
                {
                    if (pb_covers.Image == null) {
                        pb_covers.Update();
                        //pb_covers.Image.Dispose();
                        pb_covers.Image = null;
                        TegWork tegCover = new TegWork(VarData.FileList[lB_Play_List.SelectedIndex], true);
                        pb_covers.Size = new Size(1000, 1000);
                        pb_covers.Image = TegWork.image;
                        pb_covers.Update();
                        return;
                    } 
                }*/
            }
        }

        private void but_stop_Click(object sender, EventArgs e)
        {
            BassWork.Stop();
            timer.Enabled = false;
            trB_time.Value = 0;
            lab_time1.Text = "00:00:00";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lab_time1.Text = TimeSpan.FromSeconds(BassWork.Get_Pos_Of_Stream(BassWork.stream)).ToString();
            try
            {
                trB_time.Value = BassWork.Get_Pos_Of_Stream(BassWork.stream);
            }
            catch { trB_time.Value = 0; }

            if (BassWork.Next_Track())
            {/*
                if(VarData.flagUp)
                {
                    lB_Play_List.SelectedIndex++;
                }
                else if (VarData.flagDown)
                {
                    lB_Play_List.SelectedIndex--;
                }*/

                lB_Play_List.SelectedIndex = VarData.current_track_number;
                lab_time1.Text = TimeSpan.FromSeconds(BassWork.Get_Pos_Of_Stream(BassWork.stream)).ToString();
                lab_time2.Text = TimeSpan.FromSeconds(BassWork.Get_Time_Of_Stream(BassWork.stream)).ToString();
                trB_time.Maximum = BassWork.Get_Time_Of_Stream(BassWork.stream);
                trB_vol.Value = BassWork.Get_Pos_Of_Stream(BassWork.stream);
            }

            if (BassWork.end_play_list)
            {
                but_stop_Click(this, new EventArgs());
                lB_Play_List.SelectedIndex = VarData.current_track_number = 0;
                BassWork.end_play_list = false;
            }
        }

        private void trB_time_Scroll(object sender, EventArgs e)
        {
            BassWork.Set_Pos_Of_Scroll(/*BassWork.stream,*/ trB_time.Value);
        }

        private void trB_vol_Scroll(object sender, EventArgs e)
        {
            BassWork.Set_Volume_To_Stream(BassWork.stream, trB_vol.Value);
            VarData.volume_value_tmp = trB_vol.Value;
        }

        private void but_pause_Click(object sender, EventArgs e)
        {
            BassWork.Pause();
        }

        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            files = openFile.FileNames;
            Teg_Write();
        }

        private void Teg_Write()
        {
            for (int i = 0; i < files.Length; i++)
            {
                VarData.file_list.Add(files[i]);
                TegWork teg = new TegWork(files[i]);
                lB_Play_List.Items.Add(teg.track + " - " + teg.title + " - " + teg.artist + " - " + teg.alboum + " - " + teg.alboum_artist + " - " + teg.year + " - " + teg.genre + " - " + teg.bit_rate + " - " + teg.freq + " - " + teg.channels);
            }
        }

        private void but_up_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                int current_index = lB_Play_List.SelectedIndex;
                BassWork.Change_Of_Pos_Up(current_index);
                //VarData.CurrentTrackNumber++;
                //lB_Play_List.Items.Clear();
                //TegWrite();
                //lB_Play_List.Update();

                lB_Play_List_Update();
            }
        }

        private void but_down_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                int current_index = lB_Play_List.SelectedIndex;
                BassWork.Change_Of_Pos_Down(current_index);
                //VarData.CurrentTrackNumber--;
                //lB_Play_List.Items.Clear();

                /*
                TegWork tegCurrent = new TegWork(VarData.FileList[current_index]);
                lB_Play_List.Items.Add(tegCurrent.Title + " - " + tegCurrent.Artist + " - " + tegCurrent.Alboum + " - " + tegCurrent.AlboumArtist + " - " + tegCurrent.Year + " - " + tegCurrent.BitRate + ", " + tegCurrent.Freq + ", " + tegCurrent.Channels);
                */

                //TegWrite();
                //lB_Play_List.Update();

                lB_Play_List_Update();
            }
        }

        private void but_insert_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                //OpenFileDialog insertDialog = new OpenFileDialog();
                //insertDialog.Multiselect = true;

                openFile.ShowDialog();

                //insertDialog.Filter = "All|*.mp3; *.m4a; *.mp4; *.ogg; *.opus; *.ac3; *.ape; *.mpc; *.flac; *.wma; *.tta; *.alac; *.wv"
                //    + "|MP3 (*.mp3)|*.mp3"
                //    + "|AAC (*.m4a; *.mp4)|*.m4a; *.mp4"
                //    + "|OGG (*.ogg)|*.ogg"
                //    + "|OPUS (*.opus)|*.opus"
                //    + "|AC3 (*.ac3)|*.ac3"
                //    + "|MA (*.ape)|*.ape"
                //    + "|MP (*.mpc)|*.mpc"
                //    + "|FLAC (*.flac)|*.flac"
                //    + "|WMA (*.wma)|*.wma"
                //    + "|TA (*.wma)|*.tta"
                //    + "|ALAC (*.alac)|*.alac"
                //    + "|WP (*.wv)|*.wv";

                //insertDialog.ShowDialog();
                string[] insrt_Files = openFile.FileNames;//insertDialog.FileNames;


                //int i = 0;

                foreach (string file in insrt_Files)
                {
                    //VarData.FileList.Add(files[i]);
                    VarData.file_list.Insert(lB_Play_List.SelectedIndex, file);
                    //TegWork teg = new TegWork(file);
                    //lB_Play_List.Items.Add(teg.Title + " - " + teg.Artist + " - " + teg.Alboum + " - " + teg.AlboumArtist + " - " + teg.Year + " - " + teg.BitRate + ", " + teg.Freq + ", " + teg.Channels);
                    //i++;
                }

                lB_Play_List_Update();
            }
        }

        private void but_delet_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                VarData.file_list.RemoveAt(lB_Play_List.SelectedIndex);
                lB_Play_List.Items.Remove(lB_Play_List.SelectedIndex);

                lB_Play_List_Update();
            }
        }

        private void but_playback_mode_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                if (VarData.flag_playback_mode == 4) VarData.flag_playback_mode = 1;
                else VarData.flag_playback_mode++;

                switch (VarData.flag_playback_mode)
                {
                    case 1: BassWork.flag_play_back_mode_while = false; BassWork.flag_play_back_mode_one = false; but_playback_mode.Text = "Обычный"; break;
                    case 2: BassWork.flag_play_back_mode_while = true; BassWork.flag_play_back_mode_one = false; but_playback_mode.Text = "Повтор всех"; break;
                    case 3: BassWork.flag_play_back_mode_while = false; BassWork.flag_play_back_mode_one = true; but_playback_mode.Text = "Повтор 1"; VarData.flag_playback_mode = 4; break;
                }
            }
        }

        private void but_mix_well_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                BassWork.Mix_Well();
                lB_Play_List_Update();
            }
        }

        private void lB_Play_List_Update()
        {
            lB_Play_List.Items.Clear();

            for (int i = 0; i < VarData.file_list.Count; i++)
            {
                TegWork teg = new TegWork(VarData.file_list[i]);
                lB_Play_List.Items.Add(teg.track + " - " + teg.title + " - " + teg.artist + " - " + teg.alboum + " - " + teg.alboum_artist + " - " + teg.year + " - " + teg.genre + " - " + teg.bit_rate + " - " + teg.freq + " - " + teg.channels);
            }
        }

        private void toolStripMenuItem_open_play_list_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPlayList = new OpenFileDialog();
            openPlayList.Filter = "All|*.txt; *.pls; *.m3u8; *.m3u" + "|TXT (*.txt)|*.txt" + "|PLS (*.pls)|*.pls" + "|M3U8 (*.m3u8)|*.m3u8" + "|M3U (*.m3u)|*.m3u";

            if (openPlayList.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (VarData.Get_Flag_Point_Control(openPlayList.FileName))
                    {
                        StreamReader reader_Play_List = new StreamReader(openPlayList.FileName);

                        string[] format_playlist = openPlayList.FileName.Split(new char[] { '.' });

                        if (format_playlist[1] == "txt")
                        {
                            string[] file_Name = (reader_Play_List.ReadToEnd()).Split(new char[] { ';' });

                            Add_File_And_Trimming_The_Tail(file_Name);
                        }
                        else { PlayListWork play_list_another = new PlayListWork(openPlayList.FileName); }

                        lB_Play_List_Update();
                    }
                    else { }
                }
                catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void toolStripMenuItem_save_play_list_Click(object sender, EventArgs e)
        {
            if (lB_Play_List.Items.Count != 0)
            {
                SaveFileDialog savePlayList = new SaveFileDialog();
                //savePlayList.Filter = "All|*.txt; *.pls; *.m3u8;" + "|TXT (*.txt)|*.txt" + "|PLS (*.pls)|*.pls" + "|M3U8 (*.m3u8)|*.m3u8";
                savePlayList.Filter = "Text (*.txt)|*.txt" + "|All (*.)|*.";

                //if (VarData.save_format_play_list == 0)
                //{
                if (savePlayList.ShowDialog() == DialogResult.OK)
                {
                    string file_Name = savePlayList.FileName;

                    StreamWriter save = new StreamWriter(file_Name);

                    foreach (string file in VarData.file_list)
                    {
                        save.Write(file + ";");
                    }

                    save.Close();
                }
                //}
                //else 
                //{
                //    if (VarData.save_format_play_list == 1)
                //    {
                //        if (savePlayList.ShowDialog() == DialogResult.OK)
                //        {
                //            PlayListWork.Save_List_PLS(savePlayList.FileName);
                //        }
                //    }
                //    else if(VarData.save_format_play_list == 2)
                //    {
                //        if (savePlayList.ShowDialog() == DialogResult.OK)
                //        {
                //            PlayListWork.Save_List_M3U8(savePlayList.FileName + ".m3u8");
                //        }
                //    }
                //}
            }
            else MessageBox.Show("Плейлист пуст.", "Error");
        }

        private void toolStripMenuItem_sort_by_album_Click(object sender, EventArgs e)
        {
            VarData.flag_sort_by = true;

            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                TAG_INFO selected_Track = new TAG_INFO();
                TAG_INFO current_Track = new TAG_INFO();
                List<string> serch_num_track = new List<string>();

                try
                {
                    StreamWriter savePlayList = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_album.txt");

                    selected_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[lB_Play_List.SelectedIndex]);

                    for (int i = 0; i < VarData.file_list.Count; i++)
                    {
                        current_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[i]);

                        if (selected_Track.album == current_Track.album & selected_Track.albumartist == current_Track.albumartist)
                        {
                            savePlayList.Write(VarData.file_list[i] + ";");
                        }
                    }

                    savePlayList.Close();

                    lB_Play_List.Items.Clear();

                    VarData.file_list.Clear();

                    StreamReader read_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_album.txt");

                    string[] file_Name = (read_Play_List.ReadToEnd()).Split(new char[] { ';' });

                    Add_File_And_Trimming_The_Tail(file_Name);
                }
                catch { }
            }
        }

        private void toolStripMenuItem_sort_by_arttist_Click(object sender, EventArgs e)
        {
            VarData.flag_sort_by = true;

            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
                {
                    TAG_INFO selected_Track = new TAG_INFO();
                    TAG_INFO current_Track = new TAG_INFO();

                    try
                    {
                        StreamWriter save_Play_List = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_artist.txt");

                        selected_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[lB_Play_List.SelectedIndex]);

                        for (int i = 0; i < VarData.file_list.Count; i++)
                        {
                            current_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[i]);

                            if (selected_Track.artist == current_Track.artist)
                            {
                                save_Play_List.Write(VarData.file_list[i] + ";");
                            }
                        }

                        save_Play_List.Close();

                        lB_Play_List.Items.Clear();

                        VarData.file_list.Clear();

                        StreamReader read_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\*/"playlist_tmp\\playlist_artist.txt");

                        string[] file_Name = (read_Play_List.ReadToEnd()).Split(new char[] { ';' });

                        Add_File_And_Trimming_The_Tail(file_Name);
                    }
                    catch { }
                }
            }
        }

        private void toolStripMenuItem_sort_by_album_arttist_Click(object sender, EventArgs e)
        {
            VarData.flag_sort_by = true;

            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
                {
                    TAG_INFO selected_Track = new TAG_INFO();
                    TAG_INFO current_Track = new TAG_INFO();

                    try
                    {
                        StreamWriter savePlayList = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_album_arttist.txt");

                        selected_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[lB_Play_List.SelectedIndex]);

                        for (int i = 0; i < VarData.file_list.Count; i++)
                        {
                            current_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[i]);

                            if (selected_Track.albumartist == current_Track.albumartist)
                            {
                                savePlayList.Write(VarData.file_list[i] + ";");
                            }
                        }

                        savePlayList.Close();

                        lB_Play_List.Items.Clear();

                        VarData.file_list.Clear();

                        StreamReader read_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_album_arttist.txt");

                        string[] file_Name = (read_Play_List.ReadToEnd()).Split(new char[] { ';' });

                        Add_File_And_Trimming_The_Tail(file_Name);
                    }
                    catch { }
                }
            }
        }

        private void toolStripMenuItem_sort_by_genre_Click(object sender, EventArgs e)
        {
            VarData.flag_sort_by = true;

            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
                {
                    TAG_INFO selected_Track = new TAG_INFO();
                    TAG_INFO current_Track = new TAG_INFO();

                    try
                    {
                        StreamWriter savePlayList = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_genre.txt");

                        selected_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[lB_Play_List.SelectedIndex]);

                        for (int i = 0; i < VarData.file_list.Count; i++)
                        {
                            current_Track = BassTags.BASS_TAG_GetFromFile(VarData.file_list[i]);

                            if (selected_Track.genre == current_Track.genre)
                            {
                                savePlayList.Write(VarData.file_list[i] + ";");
                            }
                        }

                        savePlayList.Close();

                        lB_Play_List.Items.Clear();

                        VarData.file_list.Clear();

                        StreamReader read_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_genre.txt");

                        string[] file_Name = (read_Play_List.ReadToEnd()).Split(new char[] { ';' });

                        Add_File_And_Trimming_The_Tail(file_Name);
                    }
                    catch { }
                }
            }
        }

        private void toolStripMenuItem_sort_by_track_Click(object sender, EventArgs e)
        {
            VarData.flag_recover_playlist = true;

            VarData.file_list.Clear();

            try
            {
                StreamReader reader_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_no_sort.txt");

                string[] file_Name = (reader_Play_List.ReadToEnd()).Split(new char[] { ';' });

                Add_File_And_Trimming_The_Tail(file_Name);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void toolStripMenuItem_sort_by_Click(object sender, EventArgs e)
        {
            if (!VarData.flag_sort_by)
            {
                try
                {
                    StreamWriter save_No_Sort_Play_List = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_no_sort.txt");

                    foreach (string file in VarData.file_list)
                    {
                        save_No_Sort_Play_List.Write(file + ";");
                    }

                    save_No_Sort_Play_List.Close();
                }
                catch { }
            }
        }

        private void but_add_url_Click(object sender, EventArgs e)
        {
            try
            {
                string[] url_Mas = tB_list_url.Text.Split(new char[] { ';' });

                int iterator = 0;

                foreach (string url in url_Mas)
                {
                    if (url != "")
                        using (System.Net.WebClient webClient = new WebClient())
                        {
                            string file_Save_Path = /*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\" + */iterator++.ToString() + ".mp3";
                            webClient.DownloadFile(url, file_Save_Path);
                            VarData.file_list.Add(file_Save_Path);
                        }
                    else break;
                }

                lB_Play_List_Update();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void toolStripMenuItem_clear_playlist_Click(object sender, EventArgs e)
        {
            VarData.flag_recover_playlist = true;

            VarData.file_list.Clear();

            lB_Play_List_Update();
        }

        private void toolStripMenuItem_edit_Click(object sender, EventArgs e)
        {
            VarData.flag_recover_playlist = true;

            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                Form_Teg_Wtite call_form_teg = new Form_Teg_Wtite(VarData.file_list[lB_Play_List.SelectedIndex]);
                call_form_teg.ShowDialog();

                lB_Play_List_Update();
            }
        }

        private void toolStripMenuItem_actions_by_Click(object sender, EventArgs e)
        {
            if (!VarData.flag_recover_playlist)
            {
                try
                {
                    StreamWriter save_Recover_Play_List = new StreamWriter(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/ @"playlist_tmp\playlist_recover.txt");

                    foreach (string file in VarData.file_list)
                    {
                        save_Recover_Play_List.Write(file + ";");
                    }

                    save_Recover_Play_List.Close();

                    VarData.flag_recover_playlist = false;
                }
                catch { }
            }
        }

        private void toolStripMenuItem_recover_Click(object sender, EventArgs e)
        {
            VarData.file_list.Clear();

            try
            {
                StreamReader reader_Play_List = new StreamReader(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads*/"playlist_tmp\\playlist_recover.txt");

                string[] file_Name = (reader_Play_List.ReadToEnd()).Split(new char[] { ';' });

                Add_File_And_Trimming_The_Tail(file_Name);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void toolStripMenuItem_analyzer_spectrum_Click(object sender, EventArgs e)
        {
            if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
            {
                try
                {
                    Process.Start("Spector\\AudioSpectrumAdvance.exe");

                    VarData.flag_spector_process_active = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");

                    VarData.flag_spector_process_active = false;
                }
            }
        }

        private void Form_win_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VarData.flag_spector_process_active)
            {
                try
                {
                    foreach (Process process in Process.GetProcessesByName("AudioSpectrumAdvance"))
                    {
                        process.Kill();
                    }
                }
                catch { }
            }
        }

        private void toolStripMenuItem_open_cotalog_Click(object sender, EventArgs e)
        {            
            FolderBrowserDialog openСotalog = new FolderBrowserDialog();

            if (openСotalog.ShowDialog() == DialogResult.OK)
            {
                try {
                    string[] files_on_catalog = Directory.GetFiles(openСotalog.SelectedPath);
                    string[] tip_try = { "mp3", "m4a", "mp4", "ogg", "opus", "ac3", "ape", "mpc", "flac", "wma", "tta", "alac", "wv" };

                    foreach (string file in files_on_catalog)
                    {
                        if (VarData.Get_Flag_Point_Control(file))
                        {
                            string[] current_tip = file.Split(new char[] { '.' });

                            for (int i = 0; i < 12; i++)
                            {
                                if (current_tip[1] == tip_try[i])
                                {
                                    VarData.file_list.Add(file);
                                    current_tip[0] = "";
                                    current_tip[1] = "";

                                    break;
                                }
                            }
                        }
                        else { }
                    }

                    lB_Play_List_Update();
                }
                catch { }
            }
        }

        private void Add_File_And_Trimming_The_Tail(string[] _array_file)
        {
             int i = 0;

            foreach (string path in _array_file)
            {
                if (i == _array_file.Length - 1)
                {
                    break;
                }
                else VarData.file_list.Add(path);
                i++;
            }

            lB_Play_List_Update();
        }

        private void lB_Play_List_DragDrop(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            string[] exclude_types;

            foreach (string current_file in files)
            {
                if (VarData.Get_Flag_Point_Control(current_file))
                {
                    exclude_types = current_file.Split(new char[] { '.' });

                    switch (exclude_types[1])
                    {
                        // Formats AUDIO
                        case "mp3": VarData.file_list.Add(current_file); break;
                        case "m4a": VarData.file_list.Add(current_file); break;
                        case "mp4": VarData.file_list.Add(current_file); break;
                        case "ogg": VarData.file_list.Add(current_file); break;
                        case "opus": VarData.file_list.Add(current_file); break;
                        case "ac3": VarData.file_list.Add(current_file); break;
                        case "ape": VarData.file_list.Add(current_file); break;
                        case "mpc": VarData.file_list.Add(current_file); break;
                        case "flac": VarData.file_list.Add(current_file); break;
                        case "wma": VarData.file_list.Add(current_file); break;
                        case "tta": VarData.file_list.Add(current_file); break;
                        case "alac": VarData.file_list.Add(current_file); break;
                        case "wv": VarData.file_list.Add(current_file); break;

                        // Formats PLAYLIST
                        case "txt":
                            StreamReader reader_Play_List = new StreamReader(current_file);
                            string[] file_Name = (reader_Play_List.ReadToEnd()).Split(new char[] { ';' });
                            Add_File_And_Trimming_The_Tail(file_Name);
                            break;
                        case "pls":
                            PlayListWork play_list_another = new PlayListWork(current_file);
                            break;
                        case "m3u8":
                            _ = new PlayListWork(current_file);
                            break;
                        case "m3u":
                            _ = new PlayListWork(current_file);
                            break;
                        default: MessageBox.Show("Unrecognizable type", "Error"); break;
                    }
                }
                else { }
            }

            lB_Play_List_Update();
        }

        private void lB_Play_List_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form_win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P: but_play.PerformClick(); break;
                case Keys.F: but_pause.PerformClick(); break;
                case Keys.S: but_stop.PerformClick(); break;
                case Keys.U: but_up.PerformClick(); break;
                case Keys.D: but_down.PerformClick(); break;
                case Keys.M: but_playback_mode.PerformClick(); break;
                case Keys.C: but_mix_well.PerformClick(); break;
                case Keys.I: but_insert.PerformClick(); break;
                case Keys.O: toolStripMenuItem_open.PerformClick(); break;
                case Keys.L: toolStripMenuItem_open_play_list.PerformClick(); break;
                case Keys.D4: toolStripMenuItem_save_play_list.PerformClick(); break;
                case Keys.D3: toolStripMenuItem_open_cotalog.PerformClick(); break;
                case Keys.X: but_delet.PerformClick(); break;
                case Keys.Escape: but_pause.PerformClick(); this.WindowState = FormWindowState.Minimized; break;

                case Keys.Oemcomma:
                    if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
                    {
                        if (BassWork.flag_play_back_mode_while & lB_Play_List.SelectedIndex - 1 == -1) 
                        {
                            lB_Play_List.SelectedIndex = lB_Play_List.Items.Count - 1;
                            but_play.PerformClick();
                        }
                        else
                        if (lB_Play_List.SelectedIndex - 1 != -1)
                        {
                            lB_Play_List.SelectedIndex--;
                            but_play.PerformClick();
                        }
                    }
                    break;

                case Keys.OemPeriod:
                    if ((lB_Play_List.Items.Count != 0) && (lB_Play_List.SelectedIndex != -1))
                    {
                        if (BassWork.flag_play_back_mode_while & lB_Play_List.SelectedIndex + 1 == lB_Play_List.Items.Count)
                        {
                            lB_Play_List.SelectedIndex = 0;
                            but_play.PerformClick();
                        }
                        else
                        if (lB_Play_List.SelectedIndex + 1 != lB_Play_List.Items.Count)
                        {
                            lB_Play_List.SelectedIndex++;
                            but_play.PerformClick();
                        }
                    }
                    break;

                default: break;
            }
        }

        private void Form_win_Load(object sender, EventArgs e)
        {
            try
            {
                pb_covers.Image = Image.FromFile("non.jpg");
                pb_covers.SizeMode = PictureBoxSizeMode.StretchImage;
            } catch { }
        }

        private void trB_vol_ValueChanged(object sender, EventArgs e)
        {
            trB_vol.Value = VarData.volume_value_tmp;
        }
    }
}