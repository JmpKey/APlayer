using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace VKR_project
{
    static class BassWork
    {
        public static int hz = 44100; // Частота дискретизации.
        public static bool init_bass_lib; // Инициализация библиотеки.
        public static int stream; // Поток аудио.
        public static int volume; // Громкость.
        private static bool is_stoped = true; // Ручная остановка.
        internal static bool end_play_list; //Конец плей листа.

        internal static bool flag_play_back_mode_while = false; // Режим воспроизведения по кругу.
        internal static bool flag_play_back_mode_one = false; // Режим воспроизведения в случайном порядке.

        private static readonly List<int> bass_plugins_handles = new List<int>();

        public static bool Init_Bass_Lib(int _hz) // Инициализация Bass.
        {
            if (!init_bass_lib)
            {
                init_bass_lib = Bass.BASS_Init(-1, _hz, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                if (init_bass_lib)
                {
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bass_aac.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bass_ac3.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bass_ape.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bass_mpc.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bass_tta.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bassalac.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bassflac.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\bassopus.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\basswma.dll"));
                    bass_plugins_handles.Add(Bass.BASS_PluginLoad(VarData.app_path + @"plugins\basswv.dll"));

                    int er_count = 0;
                    for (int i = 0; i < bass_plugins_handles.Count; i++)
                        if (bass_plugins_handles[i] == 0)
                            er_count++;
                    if (er_count != 0)
                        MessageBox.Show(er_count + " not load!", "Error", MessageBoxButtons.OK);
                    er_count = 0;
                }
            }
            return init_bass_lib;
        }

        public static void Play(string _fileName, int _vol) // Воспроизведение.
        {
            if (Bass.BASS_ChannelIsActive(stream) != BASSActive.BASS_ACTIVE_PAUSED)
            {
                Stop();

                if (Init_Bass_Lib(hz))
                {
                    stream = Bass.BASS_StreamCreateFile(_fileName, 0, 0, BASSFlag.BASS_DEFAULT);

                    if (stream != 0)
                    {
                        volume = _vol;
                        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100F);
                        Bass.BASS_ChannelPlay(stream, false);
                        TegWork teg_cover = new TegWork(_fileName, true);
                    }
                }
            }
            else Bass.BASS_ChannelPlay(stream, false);
            is_stoped = false;
        }

        public static void Pause()
        {
            if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
                Bass.BASS_ChannelPause(stream);
        }

        public static void Stop() // Стоп.
        {
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_StreamFree(stream);
            is_stoped = true;
        }

        public static int Get_Time_Of_Stream(int _stream)
        {
            long time_bytes = Bass.BASS_ChannelGetLength(stream); // Получение длительности в байтах.
            double time = Bass.BASS_ChannelBytes2Seconds(stream, time_bytes); // Перевод в секунды.
            return (int)time;
        }

        public static void Set_Volume_To_Stream(int _stream, int __vol) // Установка громкости.
        {
            volume = __vol;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100f);
        }

        public static int Get_Pos_Of_Stream(int _stream) // Текущая позиция воспроизведения в секундах.
        {
            long pos = Bass.BASS_ChannelGetPosition(stream);
            int pos_sec = (int)Bass.BASS_ChannelBytes2Seconds(stream, pos);
            return pos_sec;
        }

        public static void Set_Pos_Of_Scroll(/*int _stream,*/ int _pos) // Перемотка.
        {
            Bass.BASS_ChannelSetPosition(stream, (double)_pos);
        }

        public static bool Next_Track()
        {
            if ((Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_STOPPED) && (!is_stoped))
            {
                if (!flag_play_back_mode_while)
                {
                    if (!flag_play_back_mode_one)
                    {
                        if (VarData.file_list.Count > VarData.current_track_number + 1)
                        {
                            Play(VarData.file_list[++VarData.current_track_number], volume);
                            end_play_list = false;
                            return true;
                        }
                    }
                }
                else
                {
                    if (flag_play_back_mode_while)
                    {
                        try
                        {
                            Play(VarData.file_list[++VarData.current_track_number], volume);
                        }
                        catch { VarData.current_track_number = 0; Play(VarData.file_list[VarData.current_track_number], volume); }

                        end_play_list = false;
                        return true;
                    }
                    else if (flag_play_back_mode_one)
                    {
                        Play(VarData.file_list[VarData.current_track_number], volume);

                        end_play_list = false;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void Change_Of_Pos_Down(int _current_pos)
        {
            if (VarData.file_list.Count > _current_pos + 1)
            {
                string data_next = VarData.file_list[_current_pos + 1];
                VarData.file_list[_current_pos + 1] = VarData.file_list[_current_pos];
                VarData.file_list[_current_pos] = data_next;
                //VarData.flagDown = true;
            }
            else end_play_list = true;
        }

        public static void Change_Of_Pos_Up(int __current_pos)
        {
            if (VarData.file_list.IndexOf(VarData.file_list[0]) < __current_pos)
            {
                string data_next = VarData.file_list[__current_pos - 1];
                VarData.file_list[__current_pos - 1] = VarData.file_list[__current_pos];
                VarData.file_list[__current_pos] = data_next;
                //VarData.flagUp = true;
            }
        }

        public static void Mix_Well()
        {
            //Stop();

            Random rand_p = new Random();

            for(int index = 0; index < VarData.file_list.Count; index++)
            {
                int random_index = rand_p.Next(1, VarData.file_list.Count);
                if ((VarData.file_list.Count > index + 1) & (VarData.file_list.Count > random_index + 1))
                {
                    string next_elem = VarData.file_list[random_index + 1];
                    VarData.file_list[random_index + 1] = VarData.file_list[random_index];
                    VarData.file_list[random_index] = next_elem;
                }
                else break;
            }
        }
    }
}