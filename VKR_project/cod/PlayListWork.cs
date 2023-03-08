using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;

namespace VKR_project
{
    class PlayListWork
    {
        private int iterator_url;
        static private Encoding save_encoding;

        public PlayListWork(string _file)
        {
            if (VarData.Get_Flag_Point_Control(_file))
            {
                string[] sub_String_Path = _file.Split(new char[] { '.' });

                if (sub_String_Path[1] == "pls") Open_List_PLS(_file);
                else Open_List_M3U(_file);
            }
            else { }
        }

        public PlayListWork() { }

        private void Open_List_PLS(string _file_PLS)
        {
            try
            {
                //VarData.save_format_play_list = 1;

                StreamReader read_play_list = new StreamReader(_file_PLS, Encoding.Default);
                Encoding original_encoding = Encoding.Default;
                string file_data = "";
                string select_str = "";
                int iterator = 0;
                int iterator_next_track = 1;
                int iterator_del = 1;

                while (!read_play_list.EndOfStream)
                {
                    original_encoding = read_play_list.CurrentEncoding;

                    file_data = read_play_list.ReadLine();

                    if (iterator > 0)
                    {
                        if (file_data.StartsWith("Number")) break;

                        if (iterator == iterator_next_track)
                        {
                            if (iterator_del > 0 & iterator_del < 10) select_str += file_data.Remove(0, 6) + ";";
                            else
                            {
                                if (iterator_del >= 10 & iterator_del <= 100) select_str += file_data.Remove(0, 7) + ";";
                                else
                                {
                                    if (iterator_del >= 100 & iterator_del <= 1000) select_str += file_data.Remove(0, 8) + ";";
                                    else System.Windows.Forms.MessageBox.Show("Playlist > 100 elem!", "Error");
                                }
                            }

                            iterator_del++;
                            iterator_next_track += 3;
                        }
                    }

                    file_data = "";
                    iterator++;
                }

                read_play_list.Close();

                save_encoding = original_encoding;

                byte[] encod_bytes = original_encoding.GetBytes(select_str);
                string utf8 = Encoding.UTF8.GetString(Encoding.Convert(original_encoding, Encoding.UTF8, encod_bytes));

                string[] file_path = utf8.Split(new char[] { ';' });

                int i = 0;

                foreach (string path in file_path)
                {
                    if (i == file_path.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        if (path.StartsWith("http"))
                        {
                            Add_Url_To_Play_List(path);
                        }
                        else VarData.file_list.Add(path);
                    }
                    i++;
                }
            }
            catch(Exception ex) { System.Windows.MessageBox.Show(ex.Message, "Error"); }
        }

        private void Open_List_M3U(string _file_M3U)
        {
            try
            {
                //VarData.save_format_play_list = 2;

                StreamReader read_play_list = new StreamReader(_file_M3U, Encoding.Default);
                Encoding original_encoding = Encoding.Default;
                string file_data = "";
                string select_str = "";
                int iterator = 0;

                while (!read_play_list.EndOfStream)
                {
                    original_encoding = read_play_list.CurrentEncoding;

                    file_data = read_play_list.ReadLine();

                    if (iterator > 1)
                    {
                        if (iterator % 2 == 0)
                        {
                            select_str += file_data + ";";
                        }
                    }
                    file_data = "";
                    iterator++;
                }

                read_play_list.Close();

                byte[] encod_bytes = original_encoding.GetBytes(select_str);
                string utf8 = Encoding.UTF8.GetString(Encoding.Convert(original_encoding, Encoding.UTF8, encod_bytes));

                string[] file_path = utf8.Split(new char[] { ';' });

                int i = 0;

                foreach (string path in file_path)
                {
                    if (i == file_path.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        if (path.StartsWith("http"))
                        {
                            Add_Url_To_Play_List(path);
                        }
                        else VarData.file_list.Add(path);
                    }
                    i++;
                }
            }
            catch(Exception ex) { System.Windows.MessageBox.Show(ex.Message, "Error"); }
        }

        private void Add_Url_To_Play_List(string _url)
        {
            using (System.Net.WebClient webClient = new WebClient())
            {
                string fileSavePath = /*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\" + */iterator_url++.ToString() + ".mp3";
                webClient.DownloadFile(_url, fileSavePath);
                VarData.file_list.Add(fileSavePath);
            }
        }
        /*
        internal static void Save_List_PLS(string __file_PLS)
        {
            StreamWriter write_playlist = new StreamWriter(__file_PLS, true);

            int index_list = 1;
            string data_assemb;

            data_assemb = "[playlist]" + "\n";

            foreach (string track in VarData.FileList)
            {
                data_assemb += "File" + index_list.ToString() + "=" + track
                    + "\n" + "Length" + index_list.ToString() + "="
                    + TegWork.Get_Duration(track) + "\n" + "Title"
                    + index_list.ToString() + "=" + TegWork.Get_Artist_And_Title(track) + "\n";

                if (index_list == VarData.FileList.Count) break;

                index_list++;
            }

            data_assemb += "NumberOfEntries" + "=" + index_list--.ToString()
                + "\n" + "Version=2" + "\n";
            
            //Encoding ansi = Encoding.GetEncoding(1252);
            //Encoding utf8 = Encoding.UTF8;
            //byte[] utf8_bytes, ansi_bytes;

            //utf8_bytes = utf8.GetBytes(data_assemb);
            //ansi_bytes = Encoding.Convert(utf8, ansi, utf8_bytes);

            //string ansi_str = ansi.GetString(ansi_bytes);

            //write_playlist.Write(ansi_str, Encoding.GetEncoding(1251));

            write_playlist.Write(data_assemb);

            write_playlist.Close();
        }/*
        /*
        internal static void Save_List_M3U8(string __file_M3U8)
        {
            StreamWriter write_playlist = new StreamWriter(__file_M3U8, true);

            string data_assemb;

            data_assemb = "#EXTM3U" + "\n";

            foreach (string track in VarData.FileList)
            {
                data_assemb += "#EXTINF" + ":" + TegWork.Get_Duration(track).ToString()
                    + "," + TegWork.Get_Artist_And_Title(track) + "\n" + track + "\n";
            }

            
            //Encoding ansi = Encoding.GetEncoding(1252);
            //Encoding utf8 = Encoding.UTF8;
            //byte[] utf8_bytes, ansi_bytes;

            //utf8_bytes = utf8.GetBytes(data_assemb);
            //ansi_bytes = Encoding.Convert(utf8, ansi, utf8_bytes);

            //string ansi_str = ansi.GetString(ansi_bytes);

            //write_playlist.Write(ansi_str, Encoding.GetEncoding(1251));

            write_playlist.Write(data_assemb, Encoding.UTF8);

            write_playlist.Close();
        }*/
    }
}