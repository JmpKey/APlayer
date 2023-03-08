using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_project
{
    class VarData
    {
        public static Form_win form_winP;
        public static string app_path = AppDomain.CurrentDomain.BaseDirectory; // Пути к dll.

        public static List<string> file_list = new List<string>(); // Полные имена файлов.
        public static int current_track_number; // Позиция трека в плейлисте.
        //public static bool flagUp = false;
        //public static bool flagDown = false;
        public static int volume_value_tmp;

        public static int flag_playback_mode = 1; // Режим воспроизведения.

        public static bool flag_sort_by = false;

        public static bool flag_recover_playlist = false;

        public static bool flag_spector_process_active = false;

        //public static short save_format_play_list = 0;

        public static string[] user_Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');

        public static string Get_File_Name(string _file)
        {
            string[] tmp = _file.Split('\\');
            return tmp[tmp.Length - 1];
        }

        public static bool Get_Flag_Point_Control(string _path)
        {
            string[] mas_point_off = _path.Split(new char[] { '.' });
            return mas_point_off.Length == 2 ? true : false;
        }

        public static void Set_Input_Formats()
        {
            form_winP.openFile.Filter = "All|*.mp3; *.m4a; *.mp4; *.ogg; *.opus; *.ac3; *.ape; *.mpc; *.flac; *.wma; *.tta; *.alac; *.wv"
                + "|MP3 (*.mp3)|*.mp3"
                + "|AAC (*.m4a; *.mp4)|*.m4a; *.mp4"
                + "|OGG (*.ogg)|*.ogg"
                + "|OPUS (*.opus)|*.opus"
                + "|AC3 (*.ac3)|*.ac3"
                + "|MA (*.ape)|*.ape"
                + "|MP (*.mpc)|*.mpc"
                + "|FLAC (*.flac)|*.flac"
                + "|WMA (*.wma)|*.wma"
                + "|TA (*.wma)|*.tta"
                + "|ALAC (*.alac)|*.alac"
                + "|WP (*.wv)|*.wv";
        }
    }
}