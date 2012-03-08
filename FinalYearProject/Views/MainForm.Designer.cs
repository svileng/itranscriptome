namespace ExperimentsManager.Views
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftTabControl = new System.Windows.Forms.TabControl();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.tpSelection = new System.Windows.Forms.TabPage();
            this.lblIdentifiers = new System.Windows.Forms.Label();
            this.txtIdentifiers = new System.Windows.Forms.TextBox();
            this.btnRunSelectionAlgorithm = new System.Windows.Forms.Button();
            this.nudSignificance = new System.Windows.Forms.NumericUpDown();
            this.lblSignificance = new System.Windows.Forms.Label();
            this.nudSeeds = new System.Windows.Forms.NumericUpDown();
            this.lblSeeds = new System.Windows.Forms.Label();
            this.grpExperimentDetails = new System.Windows.Forms.GroupBox();
            this.btnSaveTags = new System.Windows.Forms.Button();
            this.lblTags = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.txtExperimentNameOutput = new System.Windows.Forms.TextBox();
            this.txtExperimentDescriptionOutput = new System.Windows.Forms.TextBox();
            this.lblExperimentDescription = new System.Windows.Forms.Label();
            this.lblExperimentName = new System.Windows.Forms.Label();
            this.lvExperiments = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scMainSubContainer = new System.Windows.Forms.SplitContainer();
            this.statusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.experimentLoader = new System.ComponentModel.BackgroundWorker();
            this.cmsExperiment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expSelectionRunner = new System.ComponentModel.BackgroundWorker();
            this.tsmiViewExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.leftTabControl.SuspendLayout();
            this.tpSearch.SuspendLayout();
            this.tpSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeeds)).BeginInit();
            this.grpExperimentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMainSubContainer)).BeginInit();
            this.scMainSubContainer.Panel1.SuspendLayout();
            this.scMainSubContainer.Panel2.SuspendLayout();
            this.scMainSubContainer.SuspendLayout();
            this.cmsExperiment.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.statusStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 533);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(860, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStripProgressBar
            // 
            this.statusStripProgressBar.Name = "statusStripProgressBar";
            this.statusStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.statusStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusStripProgressBar.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(860, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadExperimentToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadExperimentToolStripMenuItem
            // 
            this.loadExperimentToolStripMenuItem.Name = "loadExperimentToolStripMenuItem";
            this.loadExperimentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadExperimentToolStripMenuItem.Text = "Load experiment...";
            this.loadExperimentToolStripMenuItem.Click += new System.EventHandler(this.loadExperimentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // leftTabControl
            // 
            this.leftTabControl.Controls.Add(this.tpSearch);
            this.leftTabControl.Controls.Add(this.tpSelection);
            this.leftTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTabControl.Location = new System.Drawing.Point(0, 0);
            this.leftTabControl.MinimumSize = new System.Drawing.Size(175, 0);
            this.leftTabControl.Name = "leftTabControl";
            this.leftTabControl.SelectedIndex = 0;
            this.leftTabControl.Size = new System.Drawing.Size(175, 502);
            this.leftTabControl.TabIndex = 0;
            // 
            // tpSearch
            // 
            this.tpSearch.Controls.Add(this.cbFilterBy);
            this.tpSearch.Controls.Add(this.lblFilterBy);
            this.tpSearch.Controls.Add(this.lblKeywords);
            this.tpSearch.Controls.Add(this.txtKeywords);
            this.tpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpSearch.Location = new System.Drawing.Point(4, 22);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearch.Size = new System.Drawing.Size(167, 476);
            this.tpSearch.TabIndex = 0;
            this.tpSearch.Text = "Search";
            this.tpSearch.UseVisualStyleBackColor = true;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Name",
            "Institute",
            "Dataset",
            "Tags"});
            this.cbFilterBy.Location = new System.Drawing.Point(6, 25);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(153, 21);
            this.cbFilterBy.TabIndex = 3;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(4, 9);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(46, 13);
            this.lblFilterBy.TabIndex = 2;
            this.lblFilterBy.Text = "Filter by:";
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeywords.Location = new System.Drawing.Point(4, 58);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(111, 13);
            this.lblKeywords.TabIndex = 1;
            this.lblKeywords.Text = "Type keyword to filter:";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Location = new System.Drawing.Point(6, 74);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(153, 20);
            this.txtKeywords.TabIndex = 0;
            this.txtKeywords.TextChanged += new System.EventHandler(this.txtKeywords_TextChanged);
            // 
            // tpSelection
            // 
            this.tpSelection.Controls.Add(this.lblIdentifiers);
            this.tpSelection.Controls.Add(this.txtIdentifiers);
            this.tpSelection.Controls.Add(this.btnRunSelectionAlgorithm);
            this.tpSelection.Controls.Add(this.nudSignificance);
            this.tpSelection.Controls.Add(this.lblSignificance);
            this.tpSelection.Controls.Add(this.nudSeeds);
            this.tpSelection.Controls.Add(this.lblSeeds);
            this.tpSelection.Location = new System.Drawing.Point(4, 22);
            this.tpSelection.Name = "tpSelection";
            this.tpSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelection.Size = new System.Drawing.Size(167, 476);
            this.tpSelection.TabIndex = 1;
            this.tpSelection.Text = "Experiments Selection";
            this.tpSelection.UseVisualStyleBackColor = true;
            // 
            // lblIdentifiers
            // 
            this.lblIdentifiers.AutoSize = true;
            this.lblIdentifiers.Location = new System.Drawing.Point(4, 109);
            this.lblIdentifiers.Name = "lblIdentifiers";
            this.lblIdentifiers.Size = new System.Drawing.Size(145, 13);
            this.lblIdentifiers.TabIndex = 6;
            this.lblIdentifiers.Text = "Identifiers (comma-separated)";
            // 
            // txtIdentifiers
            // 
            this.txtIdentifiers.Location = new System.Drawing.Point(7, 125);
            this.txtIdentifiers.Name = "txtIdentifiers";
            this.txtIdentifiers.Size = new System.Drawing.Size(154, 20);
            this.txtIdentifiers.TabIndex = 5;
            // 
            // btnRunSelectionAlgorithm
            // 
            this.btnRunSelectionAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunSelectionAlgorithm.Location = new System.Drawing.Point(7, 162);
            this.btnRunSelectionAlgorithm.Name = "btnRunSelectionAlgorithm";
            this.btnRunSelectionAlgorithm.Size = new System.Drawing.Size(154, 27);
            this.btnRunSelectionAlgorithm.TabIndex = 4;
            this.btnRunSelectionAlgorithm.Text = "Run Selection Algorithm";
            this.btnRunSelectionAlgorithm.UseVisualStyleBackColor = true;
            this.btnRunSelectionAlgorithm.Click += new System.EventHandler(this.btnRunSelectionAlgorithm_Click);
            // 
            // nudSignificance
            // 
            this.nudSignificance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSignificance.DecimalPlaces = 5;
            this.nudSignificance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudSignificance.Location = new System.Drawing.Point(7, 73);
            this.nudSignificance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSignificance.Name = "nudSignificance";
            this.nudSignificance.Size = new System.Drawing.Size(154, 20);
            this.nudSignificance.TabIndex = 3;
            // 
            // lblSignificance
            // 
            this.lblSignificance.AutoSize = true;
            this.lblSignificance.Location = new System.Drawing.Point(4, 57);
            this.lblSignificance.Name = "lblSignificance";
            this.lblSignificance.Size = new System.Drawing.Size(65, 13);
            this.lblSignificance.TabIndex = 2;
            this.lblSignificance.Text = "Significance";
            // 
            // nudSeeds
            // 
            this.nudSeeds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSeeds.Location = new System.Drawing.Point(7, 25);
            this.nudSeeds.Name = "nudSeeds";
            this.nudSeeds.Size = new System.Drawing.Size(154, 20);
            this.nudSeeds.TabIndex = 1;
            // 
            // lblSeeds
            // 
            this.lblSeeds.AutoSize = true;
            this.lblSeeds.Location = new System.Drawing.Point(4, 9);
            this.lblSeeds.Name = "lblSeeds";
            this.lblSeeds.Size = new System.Drawing.Size(37, 13);
            this.lblSeeds.TabIndex = 0;
            this.lblSeeds.Text = "Seeds";
            // 
            // grpExperimentDetails
            // 
            this.grpExperimentDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpExperimentDetails.Controls.Add(this.btnSaveTags);
            this.grpExperimentDetails.Controls.Add(this.lblTags);
            this.grpExperimentDetails.Controls.Add(this.txtTags);
            this.grpExperimentDetails.Controls.Add(this.txtExperimentNameOutput);
            this.grpExperimentDetails.Controls.Add(this.txtExperimentDescriptionOutput);
            this.grpExperimentDetails.Controls.Add(this.lblExperimentDescription);
            this.grpExperimentDetails.Controls.Add(this.lblExperimentName);
            this.grpExperimentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExperimentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExperimentDetails.Location = new System.Drawing.Point(0, 0);
            this.grpExperimentDetails.Name = "grpExperimentDetails";
            this.grpExperimentDetails.Size = new System.Drawing.Size(189, 502);
            this.grpExperimentDetails.TabIndex = 1;
            this.grpExperimentDetails.TabStop = false;
            this.grpExperimentDetails.Text = "Details";
            // 
            // btnSaveTags
            // 
            this.btnSaveTags.Enabled = false;
            this.btnSaveTags.Location = new System.Drawing.Point(8, 307);
            this.btnSaveTags.Name = "btnSaveTags";
            this.btnSaveTags.Size = new System.Drawing.Size(66, 23);
            this.btnSaveTags.TabIndex = 7;
            this.btnSaveTags.Text = "Save";
            this.btnSaveTags.UseVisualStyleBackColor = true;
            this.btnSaveTags.Click += new System.EventHandler(this.btnSaveTags_Click);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(6, 265);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(135, 13);
            this.lblTags.TabIndex = 6;
            this.lblTags.Text = "Tags separated by comma:";
            // 
            // txtTags
            // 
            this.txtTags.AccessibleName = "txtTags";
            this.txtTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTags.Location = new System.Drawing.Point(9, 281);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(170, 20);
            this.txtTags.TabIndex = 5;
            this.txtTags.Enter += new System.EventHandler(this.txtTags_Enter);
            // 
            // txtExperimentNameOutput
            // 
            this.txtExperimentNameOutput.AccessibleName = "txtExperimentNameOutput";
            this.txtExperimentNameOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExperimentNameOutput.Location = new System.Drawing.Point(10, 42);
            this.txtExperimentNameOutput.Name = "txtExperimentNameOutput";
            this.txtExperimentNameOutput.ReadOnly = true;
            this.txtExperimentNameOutput.Size = new System.Drawing.Size(170, 20);
            this.txtExperimentNameOutput.TabIndex = 4;
            // 
            // txtExperimentDescriptionOutput
            // 
            this.txtExperimentDescriptionOutput.AccessibleName = "txtExperimentDescriptionOutput";
            this.txtExperimentDescriptionOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExperimentDescriptionOutput.Location = new System.Drawing.Point(10, 98);
            this.txtExperimentDescriptionOutput.Multiline = true;
            this.txtExperimentDescriptionOutput.Name = "txtExperimentDescriptionOutput";
            this.txtExperimentDescriptionOutput.ReadOnly = true;
            this.txtExperimentDescriptionOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperimentDescriptionOutput.Size = new System.Drawing.Size(170, 146);
            this.txtExperimentDescriptionOutput.TabIndex = 3;
            // 
            // lblExperimentDescription
            // 
            this.lblExperimentDescription.AutoSize = true;
            this.lblExperimentDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperimentDescription.Location = new System.Drawing.Point(7, 79);
            this.lblExperimentDescription.Name = "lblExperimentDescription";
            this.lblExperimentDescription.Size = new System.Drawing.Size(63, 13);
            this.lblExperimentDescription.TabIndex = 2;
            this.lblExperimentDescription.Text = "Description:";
            // 
            // lblExperimentName
            // 
            this.lblExperimentName.AutoSize = true;
            this.lblExperimentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperimentName.Location = new System.Drawing.Point(7, 23);
            this.lblExperimentName.Name = "lblExperimentName";
            this.lblExperimentName.Size = new System.Drawing.Size(38, 13);
            this.lblExperimentName.TabIndex = 0;
            this.lblExperimentName.Text = "Name:";
            // 
            // lvExperiments
            // 
            this.lvExperiments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lvExperiments.ContextMenuStrip = this.cmsExperiment;
            this.lvExperiments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExperiments.FullRowSelect = true;
            this.lvExperiments.GridLines = true;
            this.lvExperiments.HideSelection = false;
            this.lvExperiments.Location = new System.Drawing.Point(0, 0);
            this.lvExperiments.Name = "lvExperiments";
            this.lvExperiments.Size = new System.Drawing.Size(488, 502);
            this.lvExperiments.TabIndex = 2;
            this.lvExperiments.UseCompatibleStateImageBehavior = false;
            this.lvExperiments.View = System.Windows.Forms.View.Details;
            this.lvExperiments.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvExperiments_ColumnClick);
            this.lvExperiments.SelectedIndexChanged += new System.EventHandler(this.lvExperiments_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Institute";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Dataset";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tags";
            this.columnHeader3.Width = 116;
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 27);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.leftTabControl);
            this.scMain.Panel1MinSize = 175;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scMainSubContainer);
            this.scMain.Panel2MinSize = 400;
            this.scMain.Size = new System.Drawing.Size(860, 502);
            this.scMain.SplitterDistance = 175;
            this.scMain.TabIndex = 3;
            // 
            // scMainSubContainer
            // 
            this.scMainSubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainSubContainer.Location = new System.Drawing.Point(0, 0);
            this.scMainSubContainer.Name = "scMainSubContainer";
            // 
            // scMainSubContainer.Panel1
            // 
            this.scMainSubContainer.Panel1.Controls.Add(this.lvExperiments);
            this.scMainSubContainer.Panel1MinSize = 200;
            // 
            // scMainSubContainer.Panel2
            // 
            this.scMainSubContainer.Panel2.Controls.Add(this.grpExperimentDetails);
            this.scMainSubContainer.Panel2MinSize = 150;
            this.scMainSubContainer.Size = new System.Drawing.Size(681, 502);
            this.scMainSubContainer.SplitterDistance = 488;
            this.scMainSubContainer.TabIndex = 0;
            // 
            // statusStripProgressBar
            // 
            this.statusStripProgressBar.Name = "statusStripProgressBar";
            this.statusStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.statusStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusStripProgressBar.Visible = false;
            // 
            // experimentLoader
            // 
            this.experimentLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.experimentLoader_DoWork);
            this.experimentLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.experimentLoader_RunWorkerCompleted);
            // 
            // cmsExperiment
            // expSelectionRunner
            // 
            this.cmsExperiment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewExperiment,
            this.tsmiDeleteExperiment});
            this.expSelectionRunner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.expSelectionRunner_DoWork);
            this.expSelectionRunner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.expSelectionRunner_RunWorkerCompleted);
            // 
            this.cmsExperiment.Name = "cmsExperiment";
            this.cmsExperiment.Size = new System.Drawing.Size(153, 70);
            this.cmsExperiment.Opening += new System.ComponentModel.CancelEventHandler(this.cmsExperiment_Opening);
            // 
            // tsmiViewExperiment
            // 
            this.tsmiViewExperiment.Name = "tsmiViewExperiment";
            this.tsmiViewExperiment.Size = new System.Drawing.Size(152, 22);
            this.tsmiViewExperiment.Text = "View Details...";
            this.tsmiViewExperiment.Click += new System.EventHandler(this.tsmiViewExperiment_Click);
            // 
            // tsmiDeleteExperiment
            // 
            this.tsmiDeleteExperiment.Name = "tsmiDeleteExperiment";
            this.tsmiDeleteExperiment.Size = new System.Drawing.Size(152, 22);
            this.tsmiDeleteExperiment.Text = "Delete";
            this.tsmiDeleteExperiment.Click += new System.EventHandler(this.tsmiDeleteExperiment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 555);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experiment Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.leftTabControl.ResumeLayout(false);
            this.tpSearch.ResumeLayout(false);
            this.tpSearch.PerformLayout();
            this.tpSelection.ResumeLayout(false);
            this.tpSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeeds)).EndInit();
            this.grpExperimentDetails.ResumeLayout(false);
            this.grpExperimentDetails.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scMainSubContainer.Panel1.ResumeLayout(false);
            this.scMainSubContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainSubContainer)).EndInit();
            this.scMainSubContainer.ResumeLayout(false);
            this.cmsExperiment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl leftTabControl;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.GroupBox grpExperimentDetails;
        private System.Windows.Forms.ListView lvExperiments;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem loadExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblExperimentDescription;
        private System.Windows.Forms.Label lblExperimentName;
        private System.Windows.Forms.TextBox txtExperimentDescriptionOutput;
        private System.Windows.Forms.TextBox txtExperimentNameOutput;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scMainSubContainer;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Button btnSaveTags;
        private System.Windows.Forms.ToolStripProgressBar statusStripProgressBar;
        private System.ComponentModel.BackgroundWorker experimentLoader;
        private System.Windows.Forms.ContextMenuStrip cmsExperiment;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewExperiment;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteExperiment;
        private System.Windows.Forms.TabPage tpSelection;
        private System.Windows.Forms.Button btnRunSelectionAlgorithm;
        private System.Windows.Forms.NumericUpDown nudSignificance;
        private System.Windows.Forms.Label lblSignificance;
        private System.Windows.Forms.NumericUpDown nudSeeds;
        private System.Windows.Forms.Label lblSeeds;
        private System.Windows.Forms.Label lblIdentifiers;
        private System.Windows.Forms.TextBox txtIdentifiers;
        private System.ComponentModel.BackgroundWorker expSelectionRunner;
    }
}

