
namespace VKR_project
{
    partial class Form_win
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_win));
            this.lB_Play_List = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_open_play_list = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_save_play_list = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_open_cotalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by_album = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by_arttist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by_album_arttist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by_genre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_by_track = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_actions_by = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_clear_playlist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_recover = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_analyzer_spectrum = new System.Windows.Forms.ToolStripMenuItem();
            this.trB_time = new System.Windows.Forms.TrackBar();
            this.trB_vol = new System.Windows.Forms.TrackBar();
            this.lab_time1 = new System.Windows.Forms.Label();
            this.lab_time2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.but_up = new System.Windows.Forms.Button();
            this.but_down = new System.Windows.Forms.Button();
            this.but_insert = new System.Windows.Forms.Button();
            this.but_delet = new System.Windows.Forms.Button();
            this.but_playback_mode = new System.Windows.Forms.Button();
            this.but_mix_well = new System.Windows.Forms.Button();
            this.toolStripMenuItem_sort_artist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_album = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_album_artists = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_year = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_sort_genre = new System.Windows.Forms.ToolStripMenuItem();
            this.tB_list_url = new System.Windows.Forms.TextBox();
            this.but_add_url = new System.Windows.Forms.Button();
            this.tT_info = new System.Windows.Forms.ToolTip(this.components);
            this.but_pause = new System.Windows.Forms.Button();
            this.but_stop = new System.Windows.Forms.Button();
            this.but_play = new System.Windows.Forms.Button();
            this.pb_covers = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trB_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trB_vol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_covers)).BeginInit();
            this.SuspendLayout();
            // 
            // lB_Play_List
            // 
            this.lB_Play_List.AllowDrop = true;
            this.lB_Play_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lB_Play_List.FormattingEnabled = true;
            this.lB_Play_List.Location = new System.Drawing.Point(201, 27);
            this.lB_Play_List.Name = "lB_Play_List";
            this.lB_Play_List.Size = new System.Drawing.Size(450, 160);
            this.lB_Play_List.TabIndex = 0;
            this.lB_Play_List.DragDrop += new System.Windows.Forms.DragEventHandler(this.lB_Play_List_DragDrop);
            this.lB_Play_List.DragEnter += new System.Windows.Forms.DragEventHandler(this.lB_Play_List_DragEnter);
            this.lB_Play_List.DoubleClick += new System.EventHandler(this.but_play_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem,
            this.toolStripMenuItem_sort_by,
            this.toolStripMenuItem_actions_by});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_open,
            this.toolStripMenuItem_open_play_list,
            this.toolStripMenuItem_save_play_list,
            this.toolStripMenuItem_open_cotalog});
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItem_open
            // 
            this.toolStripMenuItem_open.Name = "toolStripMenuItem_open";
            this.toolStripMenuItem_open.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_open.Text = "Открыть (O)";
            this.toolStripMenuItem_open.Click += new System.EventHandler(this.toolStripMenuItem_open_Click);
            // 
            // toolStripMenuItem_open_play_list
            // 
            this.toolStripMenuItem_open_play_list.Name = "toolStripMenuItem_open_play_list";
            this.toolStripMenuItem_open_play_list.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_open_play_list.Text = "Открыть плейлист (L)";
            this.toolStripMenuItem_open_play_list.Click += new System.EventHandler(this.toolStripMenuItem_open_play_list_Click);
            // 
            // toolStripMenuItem_save_play_list
            // 
            this.toolStripMenuItem_save_play_list.Name = "toolStripMenuItem_save_play_list";
            this.toolStripMenuItem_save_play_list.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_save_play_list.Text = "Сохранить плейлист ($)";
            this.toolStripMenuItem_save_play_list.Click += new System.EventHandler(this.toolStripMenuItem_save_play_list_Click);
            // 
            // toolStripMenuItem_open_cotalog
            // 
            this.toolStripMenuItem_open_cotalog.Name = "toolStripMenuItem_open_cotalog";
            this.toolStripMenuItem_open_cotalog.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_open_cotalog.Text = "Открыть папку (#)";
            this.toolStripMenuItem_open_cotalog.Click += new System.EventHandler(this.toolStripMenuItem_open_cotalog_Click);
            // 
            // toolStripMenuItem_sort_by
            // 
            this.toolStripMenuItem_sort_by.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_sort_by_album,
            this.toolStripMenuItem_sort_by_arttist,
            this.toolStripMenuItem_sort_by_album_arttist,
            this.toolStripMenuItem_sort_by_genre,
            this.toolStripMenuItem_sort_by_track});
            this.toolStripMenuItem_sort_by.Name = "toolStripMenuItem_sort_by";
            this.toolStripMenuItem_sort_by.Size = new System.Drawing.Size(102, 20);
            this.toolStripMenuItem_sort_by.Text = "Сортировка по";
            this.toolStripMenuItem_sort_by.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_Click);
            // 
            // toolStripMenuItem_sort_by_album
            // 
            this.toolStripMenuItem_sort_by_album.Name = "toolStripMenuItem_sort_by_album";
            this.toolStripMenuItem_sort_by_album.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem_sort_by_album.Text = "Альбому";
            this.toolStripMenuItem_sort_by_album.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_album_Click);
            // 
            // toolStripMenuItem_sort_by_arttist
            // 
            this.toolStripMenuItem_sort_by_arttist.Name = "toolStripMenuItem_sort_by_arttist";
            this.toolStripMenuItem_sort_by_arttist.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem_sort_by_arttist.Text = "Исполнителю";
            this.toolStripMenuItem_sort_by_arttist.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_arttist_Click);
            // 
            // toolStripMenuItem_sort_by_album_arttist
            // 
            this.toolStripMenuItem_sort_by_album_arttist.Name = "toolStripMenuItem_sort_by_album_arttist";
            this.toolStripMenuItem_sort_by_album_arttist.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem_sort_by_album_arttist.Text = "Исполнителю альбомов";
            this.toolStripMenuItem_sort_by_album_arttist.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_album_arttist_Click);
            // 
            // toolStripMenuItem_sort_by_genre
            // 
            this.toolStripMenuItem_sort_by_genre.Name = "toolStripMenuItem_sort_by_genre";
            this.toolStripMenuItem_sort_by_genre.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem_sort_by_genre.Text = "Жанр";
            this.toolStripMenuItem_sort_by_genre.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_genre_Click);
            // 
            // toolStripMenuItem_sort_by_track
            // 
            this.toolStripMenuItem_sort_by_track.Name = "toolStripMenuItem_sort_by_track";
            this.toolStripMenuItem_sort_by_track.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem_sort_by_track.Text = "Трэкам";
            this.toolStripMenuItem_sort_by_track.Click += new System.EventHandler(this.toolStripMenuItem_sort_by_track_Click);
            // 
            // toolStripMenuItem_actions_by
            // 
            this.toolStripMenuItem_actions_by.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_clear_playlist,
            this.toolStripMenuItem_recover,
            this.toolStripMenuItem_edit,
            this.toolStripMenuItem_analyzer_spectrum});
            this.toolStripMenuItem_actions_by.Name = "toolStripMenuItem_actions_by";
            this.toolStripMenuItem_actions_by.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem_actions_by.Text = "Действия";
            this.toolStripMenuItem_actions_by.Click += new System.EventHandler(this.toolStripMenuItem_actions_by_Click);
            // 
            // toolStripMenuItem_clear_playlist
            // 
            this.toolStripMenuItem_clear_playlist.Name = "toolStripMenuItem_clear_playlist";
            this.toolStripMenuItem_clear_playlist.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem_clear_playlist.Text = "Очистить плейлист";
            this.toolStripMenuItem_clear_playlist.Click += new System.EventHandler(this.toolStripMenuItem_clear_playlist_Click);
            // 
            // toolStripMenuItem_recover
            // 
            this.toolStripMenuItem_recover.Name = "toolStripMenuItem_recover";
            this.toolStripMenuItem_recover.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem_recover.Text = "Восстановить плейлист";
            this.toolStripMenuItem_recover.Click += new System.EventHandler(this.toolStripMenuItem_recover_Click);
            // 
            // toolStripMenuItem_edit
            // 
            this.toolStripMenuItem_edit.Name = "toolStripMenuItem_edit";
            this.toolStripMenuItem_edit.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem_edit.Text = "Редактировать";
            this.toolStripMenuItem_edit.Click += new System.EventHandler(this.toolStripMenuItem_edit_Click);
            // 
            // toolStripMenuItem_analyzer_spectrum
            // 
            this.toolStripMenuItem_analyzer_spectrum.Name = "toolStripMenuItem_analyzer_spectrum";
            this.toolStripMenuItem_analyzer_spectrum.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem_analyzer_spectrum.Text = "Спектр";
            this.toolStripMenuItem_analyzer_spectrum.Click += new System.EventHandler(this.toolStripMenuItem_analyzer_spectrum_Click);
            // 
            // trB_time
            // 
            this.trB_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trB_time.Location = new System.Drawing.Point(12, 193);
            this.trB_time.Name = "trB_time";
            this.trB_time.Size = new System.Drawing.Size(495, 45);
            this.trB_time.TabIndex = 4;
            this.trB_time.Scroll += new System.EventHandler(this.trB_time_Scroll);
            // 
            // trB_vol
            // 
            this.trB_vol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trB_vol.Location = new System.Drawing.Point(513, 193);
            this.trB_vol.Maximum = 100;
            this.trB_vol.Name = "trB_vol";
            this.trB_vol.Size = new System.Drawing.Size(138, 45);
            this.trB_vol.TabIndex = 5;
            this.trB_vol.Value = 50;
            this.trB_vol.Scroll += new System.EventHandler(this.trB_vol_Scroll);
            this.trB_vol.ValueChanged += new System.EventHandler(this.trB_vol_ValueChanged);
            // 
            // lab_time1
            // 
            this.lab_time1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_time1.AutoSize = true;
            this.lab_time1.Location = new System.Drawing.Point(12, 225);
            this.lab_time1.Name = "lab_time1";
            this.lab_time1.Size = new System.Drawing.Size(49, 13);
            this.lab_time1.TabIndex = 6;
            this.lab_time1.Text = "00:00:00";
            // 
            // lab_time2
            // 
            this.lab_time2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_time2.AutoSize = true;
            this.lab_time2.Location = new System.Drawing.Point(458, 225);
            this.lab_time2.Name = "lab_time2";
            this.lab_time2.Size = new System.Drawing.Size(49, 13);
            this.lab_time2.TabIndex = 7;
            this.lab_time2.Text = "00:00:00";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFile
            // 
            this.openFile.Multiselect = true;
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // but_up
            // 
            this.but_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_up.Location = new System.Drawing.Point(657, 27);
            this.but_up.Name = "but_up";
            this.but_up.Size = new System.Drawing.Size(115, 23);
            this.but_up.TabIndex = 9;
            this.but_up.Text = "Вверх";
            this.tT_info.SetToolTip(this.but_up, "Переместить в вверх (U)");
            this.but_up.UseVisualStyleBackColor = true;
            this.but_up.Click += new System.EventHandler(this.but_up_Click);
            // 
            // but_down
            // 
            this.but_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_down.Location = new System.Drawing.Point(657, 56);
            this.but_down.Name = "but_down";
            this.but_down.Size = new System.Drawing.Size(115, 23);
            this.but_down.TabIndex = 10;
            this.but_down.Text = "Вниз";
            this.tT_info.SetToolTip(this.but_down, "Переместить вниз (D)");
            this.but_down.UseVisualStyleBackColor = true;
            this.but_down.Click += new System.EventHandler(this.but_down_Click);
            // 
            // but_insert
            // 
            this.but_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_insert.Location = new System.Drawing.Point(657, 173);
            this.but_insert.Name = "but_insert";
            this.but_insert.Size = new System.Drawing.Size(115, 23);
            this.but_insert.TabIndex = 11;
            this.but_insert.Text = "Вставить";
            this.tT_info.SetToolTip(this.but_insert, "Вставить в плейлист (I)");
            this.but_insert.UseVisualStyleBackColor = true;
            this.but_insert.Click += new System.EventHandler(this.but_insert_Click);
            // 
            // but_delet
            // 
            this.but_delet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_delet.Location = new System.Drawing.Point(657, 202);
            this.but_delet.Name = "but_delet";
            this.but_delet.Size = new System.Drawing.Size(115, 23);
            this.but_delet.TabIndex = 12;
            this.but_delet.Text = "Удалить";
            this.tT_info.SetToolTip(this.but_delet, "Удалтиь из плейлиста (X)");
            this.but_delet.UseVisualStyleBackColor = true;
            this.but_delet.Click += new System.EventHandler(this.but_delet_Click);
            // 
            // but_playback_mode
            // 
            this.but_playback_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_playback_mode.Location = new System.Drawing.Point(657, 100);
            this.but_playback_mode.Name = "but_playback_mode";
            this.but_playback_mode.Size = new System.Drawing.Size(115, 23);
            this.but_playback_mode.TabIndex = 13;
            this.but_playback_mode.Text = "Обычный";
            this.tT_info.SetToolTip(this.but_playback_mode, "Режим воспроизведения (M)");
            this.but_playback_mode.UseVisualStyleBackColor = true;
            this.but_playback_mode.Click += new System.EventHandler(this.but_playback_mode_Click);
            // 
            // but_mix_well
            // 
            this.but_mix_well.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_mix_well.Location = new System.Drawing.Point(657, 129);
            this.but_mix_well.Name = "but_mix_well";
            this.but_mix_well.Size = new System.Drawing.Size(115, 23);
            this.but_mix_well.TabIndex = 14;
            this.but_mix_well.Text = "Перемешать";
            this.tT_info.SetToolTip(this.but_mix_well, "Перемешать плейлист (C)");
            this.but_mix_well.UseVisualStyleBackColor = true;
            this.but_mix_well.Click += new System.EventHandler(this.but_mix_well_Click);
            // 
            // toolStripMenuItem_sort_artist
            // 
            this.toolStripMenuItem_sort_artist.Name = "toolStripMenuItem_sort_artist";
            this.toolStripMenuItem_sort_artist.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem_sort_album
            // 
            this.toolStripMenuItem_sort_album.Name = "toolStripMenuItem_sort_album";
            this.toolStripMenuItem_sort_album.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem_sort_album_artists
            // 
            this.toolStripMenuItem_sort_album_artists.Name = "toolStripMenuItem_sort_album_artists";
            this.toolStripMenuItem_sort_album_artists.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem_sort_year
            // 
            this.toolStripMenuItem_sort_year.Name = "toolStripMenuItem_sort_year";
            this.toolStripMenuItem_sort_year.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem_sort_genre
            // 
            this.toolStripMenuItem_sort_genre.Name = "toolStripMenuItem_sort_genre";
            this.toolStripMenuItem_sort_genre.Size = new System.Drawing.Size(32, 19);
            // 
            // tB_list_url
            // 
            this.tB_list_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_list_url.Location = new System.Drawing.Point(372, 258);
            this.tB_list_url.Multiline = true;
            this.tB_list_url.Name = "tB_list_url";
            this.tB_list_url.Size = new System.Drawing.Size(319, 35);
            this.tB_list_url.TabIndex = 16;
            // 
            // but_add_url
            // 
            this.but_add_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_add_url.Location = new System.Drawing.Point(697, 256);
            this.but_add_url.Name = "but_add_url";
            this.but_add_url.Size = new System.Drawing.Size(75, 23);
            this.but_add_url.TabIndex = 17;
            this.but_add_url.Text = "URL";
            this.tT_info.SetToolTip(this.but_add_url, "Добавить URL");
            this.but_add_url.UseVisualStyleBackColor = true;
            this.but_add_url.Click += new System.EventHandler(this.but_add_url_Click);
            // 
            // but_pause
            // 
            this.but_pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_pause.Image = global::VKR_project.Properties.Resources.Pause_Img;
            this.but_pause.Location = new System.Drawing.Point(59, 244);
            this.but_pause.Name = "but_pause";
            this.but_pause.Size = new System.Drawing.Size(38, 37);
            this.but_pause.TabIndex = 8;
            this.tT_info.SetToolTip(this.but_pause, "Пауза (F)");
            this.but_pause.UseVisualStyleBackColor = true;
            this.but_pause.Click += new System.EventHandler(this.but_pause_Click);
            // 
            // but_stop
            // 
            this.but_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_stop.Image = global::VKR_project.Properties.Resources.Stop_Img;
            this.but_stop.Location = new System.Drawing.Point(103, 244);
            this.but_stop.Name = "but_stop";
            this.but_stop.Size = new System.Drawing.Size(38, 37);
            this.but_stop.TabIndex = 3;
            this.tT_info.SetToolTip(this.but_stop, "Стоп (S)");
            this.but_stop.UseVisualStyleBackColor = true;
            this.but_stop.Click += new System.EventHandler(this.but_stop_Click);
            // 
            // but_play
            // 
            this.but_play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_play.Image = ((System.Drawing.Image)(resources.GetObject("but_play.Image")));
            this.but_play.Location = new System.Drawing.Point(15, 244);
            this.but_play.Name = "but_play";
            this.but_play.Size = new System.Drawing.Size(38, 37);
            this.but_play.TabIndex = 2;
            this.tT_info.SetToolTip(this.but_play, "Воспроизвести (P)");
            this.but_play.UseVisualStyleBackColor = true;
            this.but_play.Click += new System.EventHandler(this.but_play_Click);
            // 
            // pb_covers
            // 
            this.pb_covers.Location = new System.Drawing.Point(12, 27);
            this.pb_covers.Name = "pb_covers";
            this.pb_covers.Size = new System.Drawing.Size(183, 160);
            this.pb_covers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_covers.TabIndex = 15;
            this.pb_covers.TabStop = false;
            // 
            // Form_win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 305);
            this.Controls.Add(this.but_add_url);
            this.Controls.Add(this.tB_list_url);
            this.Controls.Add(this.pb_covers);
            this.Controls.Add(this.but_mix_well);
            this.Controls.Add(this.but_playback_mode);
            this.Controls.Add(this.but_delet);
            this.Controls.Add(this.but_insert);
            this.Controls.Add(this.but_down);
            this.Controls.Add(this.but_up);
            this.Controls.Add(this.but_pause);
            this.Controls.Add(this.lab_time2);
            this.Controls.Add(this.lab_time1);
            this.Controls.Add(this.trB_vol);
            this.Controls.Add(this.trB_time);
            this.Controls.Add(this.but_stop);
            this.Controls.Add(this.but_play);
            this.Controls.Add(this.lB_Play_List);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(800, 344);
            this.Name = "Form_win";
            this.Text = "Audio Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_win_FormClosing);
            this.Load += new System.EventHandler(this.Form_win_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_win_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trB_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trB_vol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_covers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lB_Play_List;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_open;
        private System.Windows.Forms.Button but_play;
        private System.Windows.Forms.Button but_stop;
        private System.Windows.Forms.TrackBar trB_time;
        private System.Windows.Forms.TrackBar trB_vol;
        private System.Windows.Forms.Label lab_time1;
        private System.Windows.Forms.Label lab_time2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button but_pause;
        public System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button but_up;
        private System.Windows.Forms.Button but_down;
        private System.Windows.Forms.Button but_insert;
        private System.Windows.Forms.Button but_delet;
        private System.Windows.Forms.Button but_playback_mode;
        private System.Windows.Forms.Button but_mix_well;
        private System.Windows.Forms.PictureBox pb_covers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_artist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_album;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_album_artists;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_year;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_genre;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_open_play_list;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_save_play_list;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by_album;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by_arttist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by_album_arttist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by_genre;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_sort_by_track;
        private System.Windows.Forms.TextBox tB_list_url;
        private System.Windows.Forms.Button but_add_url;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_actions_by;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_clear_playlist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_recover;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_analyzer_spectrum;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_open_cotalog;
        private System.Windows.Forms.ToolTip tT_info;
    }
}