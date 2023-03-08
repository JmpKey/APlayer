using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using System.Windows.Forms.DataVisualization.Charting;

namespace AudioSpectrumAdvance
{
    internal class Analyzer
    {
        private bool enable_flag;                       // Enabled status
        private DispatcherTimer display_refresh_timer;  // Timer that refreshes the display
        public float[] buff_fft;                        // Buffer for fft data
        private ProgressBar l, r;                       // Progressbars for left and right channel intensity
        private WASAPIPROC process;                     // Callback function to obtain data
        private int level_out_last;                     // Last output level
        private int count_level_out_last;               // Last output level counter
        public List<byte> spectrum_data_buff;           // Spectrum data buffer
        private Spectrum spectrum_obj;                  // Spectrum dispay control
        private ComboBox device_list;                   // Device list
        private bool init_flag;                         // Initialized flag
        private int index_used_device;                  // Used device index
        private Chart chart_obj;

        private int lines = 64;                         // Number of spectrum lines

        //ctor
        public Analyzer(ProgressBar _left, ProgressBar _right, Spectrum _spectrum, ComboBox _devicelist, Chart _chart)
        {
            buff_fft = new float[8192];
            level_out_last = 0;
            count_level_out_last = 0;
            display_refresh_timer = new DispatcherTimer();
            display_refresh_timer.Tick += T_Tick;
            display_refresh_timer.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate//25
            display_refresh_timer.IsEnabled = false;
            l = _left;
            r = _right;
            l.Minimum = 0;
            r.Minimum = 0;
            r.Maximum = (ushort.MaxValue);
            l.Maximum = (ushort.MaxValue);
            process = new WASAPIPROC(Process);
            spectrum_data_buff = new List<byte>();
            spectrum_obj = _spectrum;
            chart_obj = _chart;
            device_list = _devicelist;
            init_flag = false;

            _chart.Series.Add("wave");
            _chart.Series["wave"].ChartType = SeriesChartType.FastLine;
            _chart.Series["wave"].ChartArea = "ChartArea1";

            _chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            _chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            _chart.ChartAreas["ChartArea1"].AxisY.Maximum = 255;
            _chart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            _chart.ChartAreas["ChartArea1"].AxisX.Maximum = 64;
            _chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;

            for (int i = 0; i < _chart.ChartAreas["ChartArea1"].AxisX.Maximum; i++)
            {
                _chart.Series["wave"].Points.Add(0);
            }

            Init();
        }

        // flag for display enable
        public bool display_enable { get; set; }

        //flag for enabling and disabling program functionality
        public bool enable
        {
            get { return enable_flag; }
            set
            {
                enable_flag = value;
                if (value)
                {
                    if (!init_flag)
                    {
                        var array = (device_list.Items[device_list.SelectedIndex] as string).Split(' ');
                        index_used_device = Convert.ToInt32(array[0]);
                        bool result = BassWasapi.BASS_WASAPI_Init(index_used_device, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, process, IntPtr.Zero);

                        if (!result)
                        {
                            var error = Bass.BASS_ErrorGetCode();
                            MessageBox.Show(error.ToString());
                        }
                        else
                        {
                            init_flag = true;
                            device_list.Enabled = false;
                        }
                    }
                    BassWasapi.BASS_WASAPI_Start();
                }
                else BassWasapi.BASS_WASAPI_Stop(true);
                System.Threading.Thread.Sleep(500);
                display_refresh_timer.IsEnabled = value;
            }
        }

        // initialization
        private void Init()
        {
            bool result = false;
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);

                if (device.IsEnabled && device.IsLoopback)
                {
                    device_list.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }

            device_list.SelectedIndex = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            if (!result) throw new Exception("Init Error");
        }

        //timer 
        private void T_Tick(object sender, EventArgs e)
        {
            int ret = BassWasapi.BASS_WASAPI_GetData(buff_fft, (int)BASSData.BASS_DATA_FFT8192);  //get ch.annel fft data
            if (ret < -1) return;
            int x, y;
            int b0 = 0;

            //computes the spectrum data, the code is taken from a bass_wasapi sample.
            for (x = 0; x < lines; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (lines - 1));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;

                for (; b0 < b1; b0++)
                {
                    if (peak < buff_fft[1 + b0]) peak = buff_fft[1 + b0];
                }

                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255) y = 255;
                if (y < 0) y = 0;
                spectrum_data_buff.Add((byte)y);
                //Console.Write("{0, 3} ", y);
            }

            if (display_enable) spectrum_obj.Set(spectrum_data_buff);
            for (int i = 0; i < spectrum_data_buff.ToArray().Length; i++)
            {
                try
                {
                    chart_obj.Series["wave"].Points.Add(spectrum_data_buff[i]);
                }
                catch (Exception) { }
                try
                {
                    chart_obj.Series["wave"].Points.RemoveAt(0);
                }
                catch (Exception) { }

            }
            spectrum_data_buff.Clear();


            int level = BassWasapi.BASS_WASAPI_GetLevel();
            l.Value = (Utils.LowWord32(level));
            r.Value = (Utils.HighWord32(level));
            if (level == level_out_last && level != 0) count_level_out_last++;
            level_out_last = level;

            //Required, because some programs hang the output. If the output hangs for a 75ms
            //this piece of code re initializes the output so it doesn't make a gliched sound for long.
            if (count_level_out_last > 3)
            {
                count_level_out_last = 0;
                l.Value = (0);
                r.Value = (0);
                Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                init_flag = false;
                enable = true;
            }

        }

        // WASAPI callback, required for continuous recording
        private int Process(IntPtr _buffer, int _length, IntPtr _user)
        {
            return _length;
        }

        //cleanup
        public void Free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }
    }
}