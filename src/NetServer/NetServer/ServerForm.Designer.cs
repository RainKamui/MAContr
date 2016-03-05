namespace NetServer
{
    partial class ServerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
			this.meu_Menu = new System.Windows.Forms.MenuStrip();
			this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsp_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.tsb_StartServer = new System.Windows.Forms.ToolStripButton();
			this.tsb_StopServer = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.sta_Status = new System.Windows.Forms.StatusStrip();
			this.tsl_CurrentClient = new System.Windows.Forms.ToolStripStatusLabel();
			this.tss_CurrentClient = new System.Windows.Forms.ToolStripStatusLabel();
			this.gpb_Clients = new System.Windows.Forms.GroupBox();
			this.lsv_Clients = new System.Windows.Forms.ListView();
			this.col_HostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_IPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.spl_Main = new System.Windows.Forms.SplitContainer();
			this.spl_Center = new System.Windows.Forms.SplitContainer();
			this.tab_Control = new System.Windows.Forms.TabControl();
			this.tap_File = new System.Windows.Forms.TabPage();
			this.lsv_FileList = new System.Windows.Forms.ListView();
			this.col_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsp_FileCtrl = new System.Windows.Forms.ToolStrip();
			this.tsb_GetDevice = new System.Windows.Forms.ToolStripButton();
			this.tsb_LastPath = new System.Windows.Forms.ToolStripButton();
			this.tsb_Compress = new System.Windows.Forms.ToolStripButton();
			this.tsb_DownloadFile = new System.Windows.Forms.ToolStripButton();
			this.tex_Path = new System.Windows.Forms.TextBox();
			this.tap_Screen = new System.Windows.Forms.TabPage();
			this.tex_ScreenInterval = new System.Windows.Forms.TextBox();
			this.pic_Screen = new System.Windows.Forms.PictureBox();
			this.meu_Screen = new System.Windows.Forms.MenuStrip();
			this.startScreenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.stopScreenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.mouseClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_ScreenChangeMod = new System.Windows.Forms.ToolStripMenuItem();
			this.setScreenIntervalInternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tap_Shell = new System.Windows.Forms.TabPage();
			this.rcb_CommandResult = new System.Windows.Forms.RichTextBox();
			this.spl_Shell = new System.Windows.Forms.SplitContainer();
			this.tex_Command = new System.Windows.Forms.TextBox();
			this.btn_RunCommand = new System.Windows.Forms.Button();
			this.tap_Camera = new System.Windows.Forms.TabPage();
			this.tex_CameraInterval = new System.Windows.Forms.TextBox();
			this.meu_Camera = new System.Windows.Forms.MenuStrip();
			this.StartCameraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.StopCameraToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.SetCameraIntervaltoolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.pic_Camera = new System.Windows.Forms.PictureBox();
			this.tab_DynamicCompile = new System.Windows.Forms.TabPage();
			this.rcb_CompileCode = new System.Windows.Forms.RichTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tab_Download = new System.Windows.Forms.TabPage();
			this.grb_Update = new System.Windows.Forms.GroupBox();
			this.btn_Update = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tex_NewVersionFilePath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tex_UpdateFileUrl = new System.Windows.Forms.TextBox();
			this.grb_DownloadFile = new System.Windows.Forms.GroupBox();
			this.btn_DownloadFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tex_DownloadFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tex_DownloadFileUrl = new System.Windows.Forms.TextBox();
			this.tab_Setting = new System.Windows.Forms.TabPage();
			this.btn_SetDownloadDirectory = new System.Windows.Forms.Button();
			this.tex_DownloadDirectory = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.rcb_Messages = new System.Windows.Forms.RichTextBox();
			this.meu_Menu.SuspendLayout();
			this.tsp_ToolStrip.SuspendLayout();
			this.sta_Status.SuspendLayout();
			this.gpb_Clients.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spl_Main)).BeginInit();
			this.spl_Main.Panel1.SuspendLayout();
			this.spl_Main.Panel2.SuspendLayout();
			this.spl_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spl_Center)).BeginInit();
			this.spl_Center.Panel1.SuspendLayout();
			this.spl_Center.Panel2.SuspendLayout();
			this.spl_Center.SuspendLayout();
			this.tab_Control.SuspendLayout();
			this.tap_File.SuspendLayout();
			this.tsp_FileCtrl.SuspendLayout();
			this.tap_Screen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).BeginInit();
			this.meu_Screen.SuspendLayout();
			this.tap_Shell.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spl_Shell)).BeginInit();
			this.spl_Shell.Panel1.SuspendLayout();
			this.spl_Shell.Panel2.SuspendLayout();
			this.spl_Shell.SuspendLayout();
			this.tap_Camera.SuspendLayout();
			this.meu_Camera.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Camera)).BeginInit();
			this.tab_DynamicCompile.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tab_Download.SuspendLayout();
			this.grb_Update.SuspendLayout();
			this.grb_DownloadFile.SuspendLayout();
			this.tab_Setting.SuspendLayout();
			this.SuspendLayout();
			// 
			// meu_Menu
			// 
			this.meu_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.testToolStripMenuItem});
			this.meu_Menu.Location = new System.Drawing.Point(0, 0);
			this.meu_Menu.Name = "meu_Menu";
			this.meu_Menu.Size = new System.Drawing.Size(969, 24);
			this.meu_Menu.TabIndex = 0;
			this.meu_Menu.Text = "menuStrip1";
			// 
			// serverToolStripMenuItem
			// 
			this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.resetToolStripMenuItem});
			this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
			this.serverToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.serverToolStripMenuItem.Text = "Server";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.startToolStripMenuItem.Text = "Start";
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.testToolStripMenuItem.Text = "Test";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
			// 
			// tsp_ToolStrip
			// 
			this.tsp_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_StartServer,
            this.tsb_StopServer,
            this.toolStripButton1});
			this.tsp_ToolStrip.Location = new System.Drawing.Point(0, 24);
			this.tsp_ToolStrip.Name = "tsp_ToolStrip";
			this.tsp_ToolStrip.Size = new System.Drawing.Size(969, 25);
			this.tsp_ToolStrip.TabIndex = 1;
			this.tsp_ToolStrip.Text = "toolStrip1";
			// 
			// tsb_StartServer
			// 
			this.tsb_StartServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_StartServer.Image = ((System.Drawing.Image)(resources.GetObject("tsb_StartServer.Image")));
			this.tsb_StartServer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_StartServer.Name = "tsb_StartServer";
			this.tsb_StartServer.Size = new System.Drawing.Size(23, 22);
			this.tsb_StartServer.Text = "Start Server";
			this.tsb_StartServer.Click += new System.EventHandler(this.tsb_StartServer_Click);
			// 
			// tsb_StopServer
			// 
			this.tsb_StopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_StopServer.Image = ((System.Drawing.Image)(resources.GetObject("tsb_StopServer.Image")));
			this.tsb_StopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_StopServer.Name = "tsb_StopServer";
			this.tsb_StopServer.Size = new System.Drawing.Size(23, 22);
			this.tsb_StopServer.Text = "toolStripButton1";
			this.tsb_StopServer.Click += new System.EventHandler(this.tsb_StopServer_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// sta_Status
			// 
			this.sta_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_CurrentClient,
            this.tss_CurrentClient});
			this.sta_Status.Location = new System.Drawing.Point(0, 563);
			this.sta_Status.Name = "sta_Status";
			this.sta_Status.Size = new System.Drawing.Size(969, 22);
			this.sta_Status.TabIndex = 2;
			this.sta_Status.Text = "statusStrip1";
			// 
			// tsl_CurrentClient
			// 
			this.tsl_CurrentClient.Name = "tsl_CurrentClient";
			this.tsl_CurrentClient.Size = new System.Drawing.Size(0, 17);
			// 
			// tss_CurrentClient
			// 
			this.tss_CurrentClient.Name = "tss_CurrentClient";
			this.tss_CurrentClient.Size = new System.Drawing.Size(0, 17);
			// 
			// gpb_Clients
			// 
			this.gpb_Clients.Controls.Add(this.lsv_Clients);
			this.gpb_Clients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gpb_Clients.Location = new System.Drawing.Point(0, 0);
			this.gpb_Clients.Name = "gpb_Clients";
			this.gpb_Clients.Size = new System.Drawing.Size(231, 514);
			this.gpb_Clients.TabIndex = 0;
			this.gpb_Clients.TabStop = false;
			this.gpb_Clients.Text = "Logined Client";
			// 
			// lsv_Clients
			// 
			this.lsv_Clients.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lsv_Clients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_HostName,
            this.col_IPAddress,
            this.col_Location});
			this.lsv_Clients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsv_Clients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lsv_Clients.FullRowSelect = true;
			this.lsv_Clients.Location = new System.Drawing.Point(3, 17);
			this.lsv_Clients.Name = "lsv_Clients";
			this.lsv_Clients.Size = new System.Drawing.Size(225, 494);
			this.lsv_Clients.TabIndex = 0;
			this.lsv_Clients.UseCompatibleStateImageBehavior = false;
			this.lsv_Clients.View = System.Windows.Forms.View.Details;
			this.lsv_Clients.DoubleClick += new System.EventHandler(this.lsv_Clients_DoubleClick);
			// 
			// col_HostName
			// 
			this.col_HostName.Text = "Host";
			this.col_HostName.Width = 71;
			// 
			// col_IPAddress
			// 
			this.col_IPAddress.Text = "IP";
			this.col_IPAddress.Width = 85;
			// 
			// col_Location
			// 
			this.col_Location.Text = "Location";
			// 
			// spl_Main
			// 
			this.spl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spl_Main.Location = new System.Drawing.Point(0, 49);
			this.spl_Main.Name = "spl_Main";
			// 
			// spl_Main.Panel1
			// 
			this.spl_Main.Panel1.Controls.Add(this.gpb_Clients);
			// 
			// spl_Main.Panel2
			// 
			this.spl_Main.Panel2.Controls.Add(this.spl_Center);
			this.spl_Main.Size = new System.Drawing.Size(969, 514);
			this.spl_Main.SplitterDistance = 231;
			this.spl_Main.TabIndex = 3;
			// 
			// spl_Center
			// 
			this.spl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spl_Center.Location = new System.Drawing.Point(0, 0);
			this.spl_Center.Name = "spl_Center";
			this.spl_Center.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// spl_Center.Panel1
			// 
			this.spl_Center.Panel1.Controls.Add(this.tab_Control);
			// 
			// spl_Center.Panel2
			// 
			this.spl_Center.Panel2.Controls.Add(this.rcb_Messages);
			this.spl_Center.Size = new System.Drawing.Size(734, 514);
			this.spl_Center.SplitterDistance = 382;
			this.spl_Center.TabIndex = 0;
			// 
			// tab_Control
			// 
			this.tab_Control.Controls.Add(this.tap_File);
			this.tab_Control.Controls.Add(this.tap_Screen);
			this.tab_Control.Controls.Add(this.tap_Shell);
			this.tab_Control.Controls.Add(this.tap_Camera);
			this.tab_Control.Controls.Add(this.tab_DynamicCompile);
			this.tab_Control.Controls.Add(this.tab_Download);
			this.tab_Control.Controls.Add(this.tab_Setting);
			this.tab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tab_Control.Location = new System.Drawing.Point(0, 0);
			this.tab_Control.Name = "tab_Control";
			this.tab_Control.SelectedIndex = 0;
			this.tab_Control.Size = new System.Drawing.Size(734, 382);
			this.tab_Control.TabIndex = 1;
			// 
			// tap_File
			// 
			this.tap_File.Controls.Add(this.lsv_FileList);
			this.tap_File.Controls.Add(this.tsp_FileCtrl);
			this.tap_File.Controls.Add(this.tex_Path);
			this.tap_File.Location = new System.Drawing.Point(4, 22);
			this.tap_File.Name = "tap_File";
			this.tap_File.Padding = new System.Windows.Forms.Padding(3);
			this.tap_File.Size = new System.Drawing.Size(726, 356);
			this.tap_File.TabIndex = 0;
			this.tap_File.Text = "File";
			this.tap_File.UseVisualStyleBackColor = true;
			// 
			// lsv_FileList
			// 
			this.lsv_FileList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lsv_FileList.CheckBoxes = true;
			this.lsv_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Name,
            this.col_Size,
            this.col_Type});
			this.lsv_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsv_FileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lsv_FileList.FullRowSelect = true;
			this.lsv_FileList.Location = new System.Drawing.Point(3, 24);
			this.lsv_FileList.Name = "lsv_FileList";
			this.lsv_FileList.Size = new System.Drawing.Size(720, 304);
			this.lsv_FileList.TabIndex = 2;
			this.lsv_FileList.UseCompatibleStateImageBehavior = false;
			this.lsv_FileList.View = System.Windows.Forms.View.Details;
			this.lsv_FileList.DoubleClick += new System.EventHandler(this.lsv_FileList_DoubleClick);
			// 
			// col_Name
			// 
			this.col_Name.Text = "Name";
			this.col_Name.Width = 374;
			// 
			// col_Size
			// 
			this.col_Size.Text = "Size";
			this.col_Size.Width = 206;
			// 
			// col_Type
			// 
			this.col_Type.Text = "Type";
			// 
			// tsp_FileCtrl
			// 
			this.tsp_FileCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tsp_FileCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_GetDevice,
            this.tsb_LastPath,
            this.tsb_Compress,
            this.tsb_DownloadFile});
			this.tsp_FileCtrl.Location = new System.Drawing.Point(3, 328);
			this.tsp_FileCtrl.Name = "tsp_FileCtrl";
			this.tsp_FileCtrl.Size = new System.Drawing.Size(720, 25);
			this.tsp_FileCtrl.TabIndex = 1;
			this.tsp_FileCtrl.Text = "toolStrip1";
			// 
			// tsb_GetDevice
			// 
			this.tsb_GetDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_GetDevice.Image = ((System.Drawing.Image)(resources.GetObject("tsb_GetDevice.Image")));
			this.tsb_GetDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_GetDevice.Name = "tsb_GetDevice";
			this.tsb_GetDevice.Size = new System.Drawing.Size(23, 22);
			this.tsb_GetDevice.Text = "GetDevice";
			this.tsb_GetDevice.Click += new System.EventHandler(this.tsb_GetDevice_Click);
			// 
			// tsb_LastPath
			// 
			this.tsb_LastPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_LastPath.Image = ((System.Drawing.Image)(resources.GetObject("tsb_LastPath.Image")));
			this.tsb_LastPath.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_LastPath.Name = "tsb_LastPath";
			this.tsb_LastPath.Size = new System.Drawing.Size(23, 22);
			this.tsb_LastPath.Text = "Back";
			this.tsb_LastPath.Click += new System.EventHandler(this.tsb_LastPath_Click);
			// 
			// tsb_Compress
			// 
			this.tsb_Compress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_Compress.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Compress.Image")));
			this.tsb_Compress.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Compress.Name = "tsb_Compress";
			this.tsb_Compress.Size = new System.Drawing.Size(23, 22);
			this.tsb_Compress.Text = "Compress";
			this.tsb_Compress.Click += new System.EventHandler(this.tsb_Compress_Click);
			// 
			// tsb_DownloadFile
			// 
			this.tsb_DownloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_DownloadFile.Image = ((System.Drawing.Image)(resources.GetObject("tsb_DownloadFile.Image")));
			this.tsb_DownloadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_DownloadFile.Name = "tsb_DownloadFile";
			this.tsb_DownloadFile.Size = new System.Drawing.Size(23, 22);
			this.tsb_DownloadFile.Text = "DownloadFile";
			this.tsb_DownloadFile.Click += new System.EventHandler(this.tsb_DownloadFile_Click);
			// 
			// tex_Path
			// 
			this.tex_Path.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tex_Path.Dock = System.Windows.Forms.DockStyle.Top;
			this.tex_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.tex_Path.Location = new System.Drawing.Point(3, 3);
			this.tex_Path.Name = "tex_Path";
			this.tex_Path.Size = new System.Drawing.Size(720, 21);
			this.tex_Path.TabIndex = 0;
			// 
			// tap_Screen
			// 
			this.tap_Screen.Controls.Add(this.tex_ScreenInterval);
			this.tap_Screen.Controls.Add(this.pic_Screen);
			this.tap_Screen.Controls.Add(this.meu_Screen);
			this.tap_Screen.Location = new System.Drawing.Point(4, 22);
			this.tap_Screen.Name = "tap_Screen";
			this.tap_Screen.Padding = new System.Windows.Forms.Padding(3);
			this.tap_Screen.Size = new System.Drawing.Size(726, 356);
			this.tap_Screen.TabIndex = 1;
			this.tap_Screen.Text = "Screen";
			this.tap_Screen.UseVisualStyleBackColor = true;
			// 
			// tex_ScreenInterval
			// 
			this.tex_ScreenInterval.Location = new System.Drawing.Point(340, 6);
			this.tex_ScreenInterval.Name = "tex_ScreenInterval";
			this.tex_ScreenInterval.Size = new System.Drawing.Size(134, 21);
			this.tex_ScreenInterval.TabIndex = 3;
			// 
			// pic_Screen
			// 
			this.pic_Screen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pic_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pic_Screen.Location = new System.Drawing.Point(3, 27);
			this.pic_Screen.Name = "pic_Screen";
			this.pic_Screen.Size = new System.Drawing.Size(720, 326);
			this.pic_Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic_Screen.TabIndex = 1;
			this.pic_Screen.TabStop = false;
			this.pic_Screen.Click += new System.EventHandler(this.pic_Screen_Click);
			// 
			// meu_Screen
			// 
			this.meu_Screen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScreenToolStripMenuItem1,
            this.stopScreenToolStripMenuItem1,
            this.mouseClickToolStripMenuItem,
            this.btn_ScreenChangeMod,
            this.setScreenIntervalInternalToolStripMenuItem});
			this.meu_Screen.Location = new System.Drawing.Point(3, 3);
			this.meu_Screen.Name = "meu_Screen";
			this.meu_Screen.Size = new System.Drawing.Size(720, 24);
			this.meu_Screen.TabIndex = 2;
			this.meu_Screen.Text = "menuStrip1";
			// 
			// startScreenToolStripMenuItem1
			// 
			this.startScreenToolStripMenuItem1.Name = "startScreenToolStripMenuItem1";
			this.startScreenToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
			this.startScreenToolStripMenuItem1.Text = "Start";
			this.startScreenToolStripMenuItem1.Click += new System.EventHandler(this.startScreenToolStripMenuItem1_Click);
			// 
			// stopScreenToolStripMenuItem1
			// 
			this.stopScreenToolStripMenuItem1.Name = "stopScreenToolStripMenuItem1";
			this.stopScreenToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
			this.stopScreenToolStripMenuItem1.Text = "Stop";
			this.stopScreenToolStripMenuItem1.Click += new System.EventHandler(this.stopScreenToolStripMenuItem1_Click);
			// 
			// mouseClickToolStripMenuItem
			// 
			this.mouseClickToolStripMenuItem.Name = "mouseClickToolStripMenuItem";
			this.mouseClickToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.mouseClickToolStripMenuItem.Text = "StartMouse";
			this.mouseClickToolStripMenuItem.Click += new System.EventHandler(this.mouseClickToolStripMenuItem_Click);
			// 
			// btn_ScreenChangeMod
			// 
			this.btn_ScreenChangeMod.Name = "btn_ScreenChangeMod";
			this.btn_ScreenChangeMod.Size = new System.Drawing.Size(77, 20);
			this.btn_ScreenChangeMod.Text = "ChangeMode";
			this.btn_ScreenChangeMod.Click += new System.EventHandler(this.btn_ScreenChangeMod_Click);
			// 
			// setScreenIntervalInternalToolStripMenuItem
			// 
			this.setScreenIntervalInternalToolStripMenuItem.Name = "setScreenIntervalInternalToolStripMenuItem";
			this.setScreenIntervalInternalToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.setScreenIntervalInternalToolStripMenuItem.Text = "SetInterval";
			this.setScreenIntervalInternalToolStripMenuItem.Click += new System.EventHandler(this.setScreenIntervalInternalToolStripMenuItem_Click);
			// 
			// tap_Shell
			// 
			this.tap_Shell.Controls.Add(this.rcb_CommandResult);
			this.tap_Shell.Controls.Add(this.spl_Shell);
			this.tap_Shell.Location = new System.Drawing.Point(4, 22);
			this.tap_Shell.Name = "tap_Shell";
			this.tap_Shell.Size = new System.Drawing.Size(726, 356);
			this.tap_Shell.TabIndex = 2;
			this.tap_Shell.Text = "Shell";
			this.tap_Shell.UseVisualStyleBackColor = true;
			// 
			// rcb_CommandResult
			// 
			this.rcb_CommandResult.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.rcb_CommandResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rcb_CommandResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rcb_CommandResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.rcb_CommandResult.HideSelection = false;
			this.rcb_CommandResult.Location = new System.Drawing.Point(0, 0);
			this.rcb_CommandResult.Name = "rcb_CommandResult";
			this.rcb_CommandResult.Size = new System.Drawing.Size(726, 334);
			this.rcb_CommandResult.TabIndex = 1;
			this.rcb_CommandResult.Text = "";
			// 
			// spl_Shell
			// 
			this.spl_Shell.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spl_Shell.Location = new System.Drawing.Point(0, 334);
			this.spl_Shell.Name = "spl_Shell";
			// 
			// spl_Shell.Panel1
			// 
			this.spl_Shell.Panel1.Controls.Add(this.tex_Command);
			// 
			// spl_Shell.Panel2
			// 
			this.spl_Shell.Panel2.Controls.Add(this.btn_RunCommand);
			this.spl_Shell.Size = new System.Drawing.Size(726, 22);
			this.spl_Shell.SplitterDistance = 591;
			this.spl_Shell.TabIndex = 0;
			// 
			// tex_Command
			// 
			this.tex_Command.BackColor = System.Drawing.Color.Black;
			this.tex_Command.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tex_Command.ForeColor = System.Drawing.Color.White;
			this.tex_Command.Location = new System.Drawing.Point(0, 0);
			this.tex_Command.Name = "tex_Command";
			this.tex_Command.Size = new System.Drawing.Size(591, 21);
			this.tex_Command.TabIndex = 0;
			// 
			// btn_RunCommand
			// 
			this.btn_RunCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_RunCommand.Location = new System.Drawing.Point(0, 0);
			this.btn_RunCommand.Name = "btn_RunCommand";
			this.btn_RunCommand.Size = new System.Drawing.Size(131, 22);
			this.btn_RunCommand.TabIndex = 0;
			this.btn_RunCommand.Text = "Run";
			this.btn_RunCommand.UseVisualStyleBackColor = true;
			this.btn_RunCommand.Click += new System.EventHandler(this.btn_RunCommand_Click);
			// 
			// tap_Camera
			// 
			this.tap_Camera.Controls.Add(this.tex_CameraInterval);
			this.tap_Camera.Controls.Add(this.meu_Camera);
			this.tap_Camera.Controls.Add(this.pic_Camera);
			this.tap_Camera.Location = new System.Drawing.Point(4, 22);
			this.tap_Camera.Name = "tap_Camera";
			this.tap_Camera.Padding = new System.Windows.Forms.Padding(3);
			this.tap_Camera.Size = new System.Drawing.Size(726, 356);
			this.tap_Camera.TabIndex = 3;
			this.tap_Camera.Text = "Camera";
			this.tap_Camera.UseVisualStyleBackColor = true;
			// 
			// tex_CameraInterval
			// 
			this.tex_CameraInterval.Location = new System.Drawing.Point(183, 3);
			this.tex_CameraInterval.Name = "tex_CameraInterval";
			this.tex_CameraInterval.Size = new System.Drawing.Size(131, 21);
			this.tex_CameraInterval.TabIndex = 4;
			// 
			// meu_Camera
			// 
			this.meu_Camera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartCameraToolStripMenuItem1,
            this.StopCameraToolStripMenuItem2,
            this.SetCameraIntervaltoolStripMenuItem4});
			this.meu_Camera.Location = new System.Drawing.Point(3, 3);
			this.meu_Camera.Name = "meu_Camera";
			this.meu_Camera.Size = new System.Drawing.Size(720, 24);
			this.meu_Camera.TabIndex = 3;
			this.meu_Camera.Text = "menuStrip1";
			// 
			// StartCameraToolStripMenuItem1
			// 
			this.StartCameraToolStripMenuItem1.Name = "StartCameraToolStripMenuItem1";
			this.StartCameraToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
			this.StartCameraToolStripMenuItem1.Text = "Start";
			this.StartCameraToolStripMenuItem1.Click += new System.EventHandler(this.StartCameraToolStripMenuItem1_Click);
			// 
			// StopCameraToolStripMenuItem2
			// 
			this.StopCameraToolStripMenuItem2.Name = "StopCameraToolStripMenuItem2";
			this.StopCameraToolStripMenuItem2.Size = new System.Drawing.Size(41, 20);
			this.StopCameraToolStripMenuItem2.Text = "Stop";
			this.StopCameraToolStripMenuItem2.Click += new System.EventHandler(this.StopCameraToolStripMenuItem2_Click);
			// 
			// SetCameraIntervaltoolStripMenuItem4
			// 
			this.SetCameraIntervaltoolStripMenuItem4.Name = "SetCameraIntervaltoolStripMenuItem4";
			this.SetCameraIntervaltoolStripMenuItem4.Size = new System.Drawing.Size(83, 20);
			this.SetCameraIntervaltoolStripMenuItem4.Text = "SetInterval";
			this.SetCameraIntervaltoolStripMenuItem4.Click += new System.EventHandler(this.SetCameraIntervaltoolStripMenuItem4_Click);
			// 
			// pic_Camera
			// 
			this.pic_Camera.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pic_Camera.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pic_Camera.Location = new System.Drawing.Point(3, 3);
			this.pic_Camera.Name = "pic_Camera";
			this.pic_Camera.Size = new System.Drawing.Size(720, 350);
			this.pic_Camera.TabIndex = 1;
			this.pic_Camera.TabStop = false;
			// 
			// tab_DynamicCompile
			// 
			this.tab_DynamicCompile.Controls.Add(this.rcb_CompileCode);
			this.tab_DynamicCompile.Controls.Add(this.menuStrip1);
			this.tab_DynamicCompile.Location = new System.Drawing.Point(4, 22);
			this.tab_DynamicCompile.Name = "tab_DynamicCompile";
			this.tab_DynamicCompile.Padding = new System.Windows.Forms.Padding(3);
			this.tab_DynamicCompile.Size = new System.Drawing.Size(726, 356);
			this.tab_DynamicCompile.TabIndex = 4;
			this.tab_DynamicCompile.Text = "Dynamic Compile";
			this.tab_DynamicCompile.UseVisualStyleBackColor = true;
			// 
			// rcb_CompileCode
			// 
			this.rcb_CompileCode.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.rcb_CompileCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rcb_CompileCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rcb_CompileCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.rcb_CompileCode.HideSelection = false;
			this.rcb_CompileCode.Location = new System.Drawing.Point(3, 27);
			this.rcb_CompileCode.Name = "rcb_CompileCode";
			this.rcb_CompileCode.Size = new System.Drawing.Size(720, 326);
			this.rcb_CompileCode.TabIndex = 2;
			this.rcb_CompileCode.Text = "";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(3, 3);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(720, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.runToolStripMenuItem.Text = "Run";
			// 
			// tab_Download
			// 
			this.tab_Download.Controls.Add(this.grb_Update);
			this.tab_Download.Controls.Add(this.grb_DownloadFile);
			this.tab_Download.Location = new System.Drawing.Point(4, 22);
			this.tab_Download.Name = "tab_Download";
			this.tab_Download.Padding = new System.Windows.Forms.Padding(3);
			this.tab_Download.Size = new System.Drawing.Size(726, 356);
			this.tab_Download.TabIndex = 5;
			this.tab_Download.Text = "Download";
			this.tab_Download.UseVisualStyleBackColor = true;
			// 
			// grb_Update
			// 
			this.grb_Update.Controls.Add(this.btn_Update);
			this.grb_Update.Controls.Add(this.label3);
			this.grb_Update.Controls.Add(this.tex_NewVersionFilePath);
			this.grb_Update.Controls.Add(this.label4);
			this.grb_Update.Controls.Add(this.tex_UpdateFileUrl);
			this.grb_Update.Location = new System.Drawing.Point(6, 186);
			this.grb_Update.Name = "grb_Update";
			this.grb_Update.Size = new System.Drawing.Size(712, 164);
			this.grb_Update.TabIndex = 1;
			this.grb_Update.TabStop = false;
			this.grb_Update.Text = "Update";
			// 
			// btn_Update
			// 
			this.btn_Update.Location = new System.Drawing.Point(537, 120);
			this.btn_Update.Name = "btn_Update";
			this.btn_Update.Size = new System.Drawing.Size(75, 23);
			this.btn_Update.TabIndex = 4;
			this.btn_Update.Text = "Update";
			this.btn_Update.UseVisualStyleBackColor = true;
			this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nv Url:";
			// 
			// tex_NewVersionFilePath
			// 
			this.tex_NewVersionFilePath.Location = new System.Drawing.Point(79, 72);
			this.tex_NewVersionFilePath.Name = "tex_NewVersionFilePath";
			this.tex_NewVersionFilePath.Size = new System.Drawing.Size(533, 21);
			this.tex_NewVersionFilePath.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(35, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "Up Url:";
			// 
			// tex_UpdateFileUrl
			// 
			this.tex_UpdateFileUrl.Location = new System.Drawing.Point(79, 32);
			this.tex_UpdateFileUrl.Name = "tex_UpdateFileUrl";
			this.tex_UpdateFileUrl.Size = new System.Drawing.Size(533, 21);
			this.tex_UpdateFileUrl.TabIndex = 0;
			// 
			// grb_DownloadFile
			// 
			this.grb_DownloadFile.Controls.Add(this.btn_DownloadFile);
			this.grb_DownloadFile.Controls.Add(this.label2);
			this.grb_DownloadFile.Controls.Add(this.tex_DownloadFilePath);
			this.grb_DownloadFile.Controls.Add(this.label1);
			this.grb_DownloadFile.Controls.Add(this.tex_DownloadFileUrl);
			this.grb_DownloadFile.Location = new System.Drawing.Point(6, 6);
			this.grb_DownloadFile.Name = "grb_DownloadFile";
			this.grb_DownloadFile.Size = new System.Drawing.Size(712, 164);
			this.grb_DownloadFile.TabIndex = 0;
			this.grb_DownloadFile.TabStop = false;
			this.grb_DownloadFile.Text = "DownloadFile";
			// 
			// btn_DownloadFile
			// 
			this.btn_DownloadFile.Location = new System.Drawing.Point(537, 120);
			this.btn_DownloadFile.Name = "btn_DownloadFile";
			this.btn_DownloadFile.Size = new System.Drawing.Size(75, 23);
			this.btn_DownloadFile.TabIndex = 4;
			this.btn_DownloadFile.Text = "Download";
			this.btn_DownloadFile.UseVisualStyleBackColor = true;
			this.btn_DownloadFile.Click += new System.EventHandler(this.btn_DownloadFile_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "Path:";
			// 
			// tex_DownloadFilePath
			// 
			this.tex_DownloadFilePath.Location = new System.Drawing.Point(79, 72);
			this.tex_DownloadFilePath.Name = "tex_DownloadFilePath";
			this.tex_DownloadFilePath.Size = new System.Drawing.Size(533, 21);
			this.tex_DownloadFilePath.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "URL:";
			// 
			// tex_DownloadFileUrl
			// 
			this.tex_DownloadFileUrl.Location = new System.Drawing.Point(79, 32);
			this.tex_DownloadFileUrl.Name = "tex_DownloadFileUrl";
			this.tex_DownloadFileUrl.Size = new System.Drawing.Size(533, 21);
			this.tex_DownloadFileUrl.TabIndex = 0;
			// 
			// tab_Setting
			// 
			this.tab_Setting.Controls.Add(this.btn_SetDownloadDirectory);
			this.tab_Setting.Controls.Add(this.tex_DownloadDirectory);
			this.tab_Setting.Controls.Add(this.label5);
			this.tab_Setting.Location = new System.Drawing.Point(4, 22);
			this.tab_Setting.Name = "tab_Setting";
			this.tab_Setting.Padding = new System.Windows.Forms.Padding(3);
			this.tab_Setting.Size = new System.Drawing.Size(726, 356);
			this.tab_Setting.TabIndex = 6;
			this.tab_Setting.Text = "Setting";
			this.tab_Setting.UseVisualStyleBackColor = true;
			// 
			// btn_SetDownloadDirectory
			// 
			this.btn_SetDownloadDirectory.Location = new System.Drawing.Point(430, 30);
			this.btn_SetDownloadDirectory.Name = "btn_SetDownloadDirectory";
			this.btn_SetDownloadDirectory.Size = new System.Drawing.Size(75, 23);
			this.btn_SetDownloadDirectory.TabIndex = 2;
			this.btn_SetDownloadDirectory.Text = "Apply";
			this.btn_SetDownloadDirectory.UseVisualStyleBackColor = true;
			this.btn_SetDownloadDirectory.Click += new System.EventHandler(this.btn_SetDownloadDirectory_Click);
			// 
			// tex_DownloadDirectory
			// 
			this.tex_DownloadDirectory.Location = new System.Drawing.Point(155, 30);
			this.tex_DownloadDirectory.Name = "tex_DownloadDirectory";
			this.tex_DownloadDirectory.Size = new System.Drawing.Size(257, 21);
			this.tex_DownloadDirectory.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "Download Direcrory:";
			// 
			// rcb_Messages
			// 
			this.rcb_Messages.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.rcb_Messages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rcb_Messages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.rcb_Messages.HideSelection = false;
			this.rcb_Messages.Location = new System.Drawing.Point(0, 0);
			this.rcb_Messages.Name = "rcb_Messages";
			this.rcb_Messages.Size = new System.Drawing.Size(734, 128);
			this.rcb_Messages.TabIndex = 0;
			this.rcb_Messages.Text = "";
			// 
			// ServerForm
			// 
			this.AcceptButton = this.btn_RunCommand;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(969, 585);
			this.Controls.Add(this.spl_Main);
			this.Controls.Add(this.sta_Status);
			this.Controls.Add(this.tsp_ToolStrip);
			this.Controls.Add(this.meu_Menu);
			this.MainMenuStrip = this.meu_Menu;
			this.Name = "ServerForm";
			this.Text = "ServerForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
			this.Load += new System.EventHandler(this.ServerForm_Load);
			this.meu_Menu.ResumeLayout(false);
			this.meu_Menu.PerformLayout();
			this.tsp_ToolStrip.ResumeLayout(false);
			this.tsp_ToolStrip.PerformLayout();
			this.sta_Status.ResumeLayout(false);
			this.sta_Status.PerformLayout();
			this.gpb_Clients.ResumeLayout(false);
			this.spl_Main.Panel1.ResumeLayout(false);
			this.spl_Main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spl_Main)).EndInit();
			this.spl_Main.ResumeLayout(false);
			this.spl_Center.Panel1.ResumeLayout(false);
			this.spl_Center.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spl_Center)).EndInit();
			this.spl_Center.ResumeLayout(false);
			this.tab_Control.ResumeLayout(false);
			this.tap_File.ResumeLayout(false);
			this.tap_File.PerformLayout();
			this.tsp_FileCtrl.ResumeLayout(false);
			this.tsp_FileCtrl.PerformLayout();
			this.tap_Screen.ResumeLayout(false);
			this.tap_Screen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).EndInit();
			this.meu_Screen.ResumeLayout(false);
			this.meu_Screen.PerformLayout();
			this.tap_Shell.ResumeLayout(false);
			this.spl_Shell.Panel1.ResumeLayout(false);
			this.spl_Shell.Panel1.PerformLayout();
			this.spl_Shell.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spl_Shell)).EndInit();
			this.spl_Shell.ResumeLayout(false);
			this.tap_Camera.ResumeLayout(false);
			this.tap_Camera.PerformLayout();
			this.meu_Camera.ResumeLayout(false);
			this.meu_Camera.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Camera)).EndInit();
			this.tab_DynamicCompile.ResumeLayout(false);
			this.tab_DynamicCompile.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tab_Download.ResumeLayout(false);
			this.grb_Update.ResumeLayout(false);
			this.grb_Update.PerformLayout();
			this.grb_DownloadFile.ResumeLayout(false);
			this.grb_DownloadFile.PerformLayout();
			this.tab_Setting.ResumeLayout(false);
			this.tab_Setting.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip meu_Menu;
        private System.Windows.Forms.ToolStrip tsp_ToolStrip;
        private System.Windows.Forms.StatusStrip sta_Status;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsb_StartServer;
        private System.Windows.Forms.GroupBox gpb_Clients;
        private System.Windows.Forms.ListView lsv_Clients;
        private System.Windows.Forms.ColumnHeader col_HostName;
        private System.Windows.Forms.ColumnHeader col_IPAddress;
        private System.Windows.Forms.SplitContainer spl_Main;
        private System.Windows.Forms.SplitContainer spl_Center;
        private System.Windows.Forms.TabControl tab_Control;
        private System.Windows.Forms.TabPage tap_File;
        private System.Windows.Forms.TabPage tap_Screen;
        private System.Windows.Forms.TabPage tap_Shell;
		private System.Windows.Forms.RichTextBox rcb_Messages;
		private System.Windows.Forms.ColumnHeader col_Location;
		private System.Windows.Forms.TabPage tap_Camera;
		private System.Windows.Forms.PictureBox pic_Screen;
		private System.Windows.Forms.ListView lsv_FileList;
		private System.Windows.Forms.ToolStrip tsp_FileCtrl;
		private System.Windows.Forms.TextBox tex_Path;
		private System.Windows.Forms.SplitContainer spl_Shell;
		private System.Windows.Forms.TextBox tex_Command;
		private System.Windows.Forms.Button btn_RunCommand;
		private System.Windows.Forms.RichTextBox rcb_CommandResult;
		private System.Windows.Forms.ColumnHeader col_Name;
		private System.Windows.Forms.ColumnHeader col_Size;
		private System.Windows.Forms.ColumnHeader col_Type;
		private System.Windows.Forms.PictureBox pic_Camera;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton tsb_StopServer;
		private System.Windows.Forms.MenuStrip meu_Screen;
		private System.Windows.Forms.ToolStripMenuItem startScreenToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem stopScreenToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem setScreenIntervalInternalToolStripMenuItem;
		private System.Windows.Forms.TextBox tex_ScreenInterval;
		private System.Windows.Forms.ToolStripButton tsb_GetDevice;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripMenuItem mouseClickToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton tsb_LastPath;
		private System.Windows.Forms.ToolStripStatusLabel tsl_CurrentClient;
		private System.Windows.Forms.ToolStripStatusLabel tss_CurrentClient;
		private System.Windows.Forms.ToolStripButton tsb_Compress;
		private System.Windows.Forms.TabPage tab_DynamicCompile;
		private System.Windows.Forms.RichTextBox rcb_CompileCode;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton tsb_DownloadFile;
		private System.Windows.Forms.TextBox tex_CameraInterval;
		private System.Windows.Forms.MenuStrip meu_Camera;
		private System.Windows.Forms.ToolStripMenuItem StartCameraToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem StopCameraToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem SetCameraIntervaltoolStripMenuItem4;
		private System.Windows.Forms.TabPage tab_Download;
		private System.Windows.Forms.GroupBox grb_DownloadFile;
		private System.Windows.Forms.Button btn_DownloadFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tex_DownloadFilePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tex_DownloadFileUrl;
		private System.Windows.Forms.GroupBox grb_Update;
		private System.Windows.Forms.Button btn_Update;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tex_NewVersionFilePath;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tex_UpdateFileUrl;
		private System.Windows.Forms.ToolStripMenuItem btn_ScreenChangeMod;
		private System.Windows.Forms.TabPage tab_Setting;
		private System.Windows.Forms.Button btn_SetDownloadDirectory;
		private System.Windows.Forms.TextBox tex_DownloadDirectory;
		private System.Windows.Forms.Label label5;




    }
}