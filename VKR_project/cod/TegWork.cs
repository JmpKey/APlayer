using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Tags;

namespace VKR_project
{
    class TegWork
    {
        public int bit_rate;
        public int freq;
        public string artist;
        public string channels;
        public string alboum;
        public string title;
        public string year;
        public string alboum_artist;
        public string genre;
        public string track;
        //private int index_call_Jpg = 2;
        //private int indexCallPng = 2;
        internal static Image image;

        Dictionary<int, string> сhanne_is_dict = new Dictionary<int, string>()
        {
            {0, "Null"}, {1, "Mono"}, {2, "Stereo"}
        };

        //public TegWork() { }

        
        public TegWork(string _file)
        {
            try
            {
                TAG_INFO tag_data = new TAG_INFO();
                tag_data = BassTags.BASS_TAG_GetFromFile(_file);
                bit_rate = tag_data.bitrate;
                freq = tag_data.channelinfo.freq;
                channels = сhanne_is_dict[tag_data.channelinfo.chans];
                artist = tag_data.artist;
                alboum = tag_data.album;
                genre = tag_data.genre;
                track = tag_data.track;
                if (tag_data.title == "")
                    title = VarData.Get_File_Name(_file);
                else
                    title = tag_data.ToString();
                year = tag_data.year;
                alboum_artist = tag_data.albumartist;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        public Image GetPicture(string _file)
        {
            TAG_INFO tag_data = new TAG_INFO();
            tag_data = BassTags.BASS_TAG_GetFromFile(_file);

            TagPicture tagPicture = tag_data.PictureGet(0);
            ImageFormat format = ImageFormat.Jpeg;
            format = ImageFormat.Png;
            return tagPicture.PictureImage;
        }

        public TegWork(string __file, bool _formal)
        {
            try
            {
                /*try {*/ image = GetPicture(__file); //} // Ret Jpg
                //catch { image = Image.FromFile(RetPngImg(__file)); } // Ret Png
            }
            catch { image = Image.FromFile(/*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\" + */"non.jpg"); }

            //indexCall++;
        }

        
        //private string Pull_Out_The_Cover(string __file)
        //{
        //    string cover_file_name_JPG = "";

        //    // JPEG signature 

        //    byte[] start = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 };    // start jpeg 225, 216, 255, 224
        //    byte[] end = new byte[] { 0xFF, 0xD9 };                  // end jpeg 255, 217

        //    byte[] imgArr = null;
        //    try
        //    {
        //        try
        //        {
        //            // read file
        //            byte[] barray = File.ReadAllBytes(__file);

        //            if (Get_Sub_Array(barray, start, end, out imgArr))
        //            // save to file      
        //            {
        //                cover_file_name_JPG = /*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\cover" + */index_call_Jpg--.ToString() + ".jpeg";
        //                File.WriteAllBytes(cover_file_name_JPG, imgArr);
        //            }
        //        }
        //        catch
        //        {
        //            cover_file_name_JPG = /*"C:\\Users\\" + VarData.user_Name[1] + "\\Downloads\\cover" + */index_call_Jpg++.ToString() + ".jpeg";
        //            File.WriteAllBytes(cover_file_name_JPG, imgArr);
        //        }
        //    }
        //    catch { cover_file_name_JPG = ""; }

        //    return cover_file_name_JPG;
        //}

        //// find position of subarray
        //private int Get_Pos(byte[] __source, byte[] __pattern)
        //{
        //    for (int i = 0; i < __source.Length; i++)
        //    {
        //        if (i + __pattern.Length < __source.Length)
        //        {
        //            byte[] result = new byte[__pattern.Length];
        //            Array.Copy(__source, i, result, 0, __pattern.Length);
        //            if (result.SequenceEqual(__pattern))
        //            {
        //                return i;
        //            }
        //        }
        //    }
        //    return -1;
        //}

        //// extract subarray
        //private bool Get_Sub_Array(byte[] _source, byte[] _beg, byte[] _end, out byte[] _subArrP)
        //{
        //    int st_Pos = 0,
        //        fin_Pos = 0;

        //    _subArrP = null;

        //    st_Pos = Get_Pos(_source, _beg);

        //    if (st_Pos != -1)
        //        if ((fin_Pos = Get_Pos(_source, _end)) != -1)
        //        {
        //            fin_Pos += _end.Length;
        //            _subArrP = _source.Skip(st_Pos).Take(fin_Pos - st_Pos).ToArray();
        //            return true;
        //        }

        //    return false;
        //}

        //internal static string Get_Duration(string _path_play_list)
        //{
        //    TAG_INFO tagData = new TAG_INFO();
        //    tagData = BassTags.BASS_TAG_GetFromFile(_path_play_list);
        //    string[] durationInt = tagData.duration.ToString().Split(new char[] { ',' });

        //    return durationInt[0].ToString();
        //}

        //internal static string Get_Artist_And_Title(string __path_play_list)
        //{
        //    TAG_INFO tagData = new TAG_INFO();
        //    tagData = BassTags.BASS_TAG_GetFromFile(__path_play_list);

        //    return tagData.artist + " - " + tagData.title;
        //}

        /*
        private string RetPngImg(string ___file)
        {
            byte[] TMP = File.ReadAllBytes(___file);

            byte[] pngStartSequence = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
            byte[] pngEndSequence = new byte[] { 0x49, 0x46, 0x4E, 0x44 };

            int start1 = IndexOfByte(TMP, pngStartSequence, 0);
            if (start1 == -1)
            {
                // no PNG present
                MessageBox.Show("Could not find PNG header");
            }

            int end1 = IndexOfByte(TMP, pngEndSequence, start1 + pngStartSequence.Length);
            if (end1 == -1)
            {
                // no IEND present
                MessageBox.Show("Could not find PNG footer");
            }

            int pngLength = end1 - start1 + 8;
            byte[] PNG = new byte[pngLength];

            string coverFileNamePNG = "";

            Array.Copy(TMP, start1, PNG, 0, pngLength);
            try
            {
                try
                {
                    coverFileNamePNG = @"C:\Users\Mila7\source\repos\VKR_project\VKR_project\bin\Debug\img\cover" + indexCallPng--.ToString() + ".png";
                    File.WriteAllBytes(coverFileNamePNG, PNG);
                }
                catch
                {
                    coverFileNamePNG = @"C:\Users\Mila7\source\repos\VKR_project\VKR_project\bin\Debug\img\cover" + indexCallPng++.ToString() + ".png";
                    File.WriteAllBytes(coverFileNamePNG, PNG);
                }
            }
            catch { coverFileNamePNG = ""; }

            return coverFileNamePNG;
        }

        private int IndexOfByte(byte[] _array, byte[] _sequence, int _startIndex)
        {
            if (_sequence.Length == 0)
                return -1;

            int found = 0;
            for (int i = _startIndex; i < _array.Length; i++)
            {
                if (_array[i] == _sequence[found])
                {
                    if (++found == _sequence.Length)
                    {
                        return i - found + 1;
                    }
                }
                else
                {
                    found = 0;
                }
            }

            return -1;
        }*/
    }
}