namespace ManagedSpy {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeWindow = new System.Windows.Forms.TreeView();
            this.treeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.propertiesPage = new System.Windows.Forms.TabPage();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.eventsPage = new System.Windows.Forms.TabPage();
            this.eventGrid = new System.Windows.Forms.DataGridView();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventArgs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowNative = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutManagedSpyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new ManagedSpy.ClickToolStrip();
            this.tsbuttonFilterEvents = new System.Windows.Forms.ToolStripButton();
            this.tsbuttonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonStartStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonClear = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treeMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.propertiesPage.SuspendLayout();
            this.eventsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeWindow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(538, 406);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeWindow
            // 
            this.treeWindow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeWindow.ContextMenuStrip = this.treeMenuStrip;
            this.treeWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeWindow.FullRowSelect = true;
            this.treeWindow.HideSelection = false;
            this.treeWindow.HotTracking = true;
            this.treeWindow.Location = new System.Drawing.Point(0, 0);
            this.treeWindow.Name = "treeWindow";
            this.treeWindow.Size = new System.Drawing.Size(242, 406);
            this.treeWindow.TabIndex = 0;
            this.treeWindow.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeWindow_BeforeExpand);
            this.treeWindow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeWindow_AfterSelect);
            // 
            // treeMenuStrip
            // 
            this.treeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWindowToolStripMenuItem});
            this.treeMenuStrip.Name = "contextMenuStrip1";
            this.treeMenuStrip.Size = new System.Drawing.Size(153, 26);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showWindowToolStripMenuItem.Text = "Show Window";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.propertiesPage);
            this.tabControl1.Controls.Add(this.eventsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(292, 406);
            this.tabControl1.TabIndex = 0;
            // 
            // propertiesPage
            // 
            this.propertiesPage.Controls.Add(this.propertyGrid);
            this.propertiesPage.Location = new System.Drawing.Point(4, 22);
            this.propertiesPage.Name = "propertiesPage";
            this.propertiesPage.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesPage.Size = new System.Drawing.Size(284, 380);
            this.propertiesPage.TabIndex = 0;
            this.propertiesPage.Text = "Properties";
            this.propertiesPage.UseVisualStyleBackColor = true;
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.White;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(278, 374);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // eventsPage
            // 
            this.eventsPage.Controls.Add(this.eventGrid);
            this.eventsPage.Location = new System.Drawing.Point(4, 22);
            this.eventsPage.Name = "eventsPage";
            this.eventsPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsPage.Size = new System.Drawing.Size(284, 380);
            this.eventsPage.TabIndex = 1;
            this.eventsPage.Text = "Events";
            this.eventsPage.UseVisualStyleBackColor = true;
            // 
            // eventGrid
            // 
            this.eventGrid.AllowUserToAddRows = false;
            this.eventGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.eventGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.eventGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventName,
            this.EventArgs});
            this.eventGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventGrid.Location = new System.Drawing.Point(3, 3);
            this.eventGrid.Name = "eventGrid";
            this.eventGrid.RowHeadersVisible = false;
            this.eventGrid.RowTemplate.Height = 16;
            this.eventGrid.Size = new System.Drawing.Size(278, 374);
            this.eventGrid.TabIndex = 0;
            // 
            // EventName
            // 
            this.EventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EventName.HeaderText = "Event Name";
            this.EventName.Name = "EventName";
            this.EventName.Width = 84;
            // 
            // EventArgs
            // 
            this.EventArgs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EventArgs.HeaderText = "Event Arguments";
            this.EventArgs.Name = "EventArgs";
            this.EventArgs.Width = 104;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterEventsToolStripMenuItem,
            this.flashWindow,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator4,
            this.ShowNative});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // filterEventsToolStripMenuItem
            // 
            this.filterEventsToolStripMenuItem.Name = "filterEventsToolStripMenuItem";
            this.filterEventsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.filterEventsToolStripMenuItem.Text = "Filter Events";
            this.filterEventsToolStripMenuItem.ToolTipText = "Select which events to log";
            this.filterEventsToolStripMenuItem.Click += new System.EventHandler(this.filterEventsToolStripMenuItem_Click);
            // 
            // flashWindow
            // 
            this.flashWindow.Name = "flashWindow";
            this.flashWindow.Size = new System.Drawing.Size(191, 22);
            this.flashWindow.Text = "Show Window";
            this.flashWindow.ToolTipText = "Flashes the currently selected Control";
            this.flashWindow.Click += new System.EventHandler(this.flashWindow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.ToolTipText = "Rescans active process and windows";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // ShowNative
            // 
            this.ShowNative.CheckOnClick = true;
            this.ShowNative.Name = "ShowNative";
            this.ShowNative.Size = new System.Drawing.Size(191, 22);
            this.ShowNative.Text = "Show Native Windows";
            this.ShowNative.ToolTipText = "Show NonManaged Windows (choose Refresh after)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutManagedSpyToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutManagedSpyToolStripMenuItem
            // 
            this.aboutManagedSpyToolStripMenuItem.Name = "aboutManagedSpyToolStripMenuItem";
            this.aboutManagedSpyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutManagedSpyToolStripMenuItem.Text = "About ManagedSpy";
            this.aboutManagedSpyToolStripMenuItem.Click += new System.EventHandler(this.aboutManagedSpyToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(538, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbuttonFilterEvents,
            this.tsbuttonRefresh,
            this.toolStripSeparator2,
            this.tsButtonStartStop,
            this.toolStripSeparator3,
            this.tsButtonClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(538, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbuttonFilterEvents
            // 
            this.tsbuttonFilterEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbuttonFilterEvents.Image = ((System.Drawing.Image)(resources.GetObject("tsbuttonFilterEvents.Image")));
            this.tsbuttonFilterEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbuttonFilterEvents.Name = "tsbuttonFilterEvents";
            this.tsbuttonFilterEvents.Size = new System.Drawing.Size(23, 22);
            this.tsbuttonFilterEvents.Text = "toolStripButton1";
            this.tsbuttonFilterEvents.ToolTipText = "Select Events to Display";
            this.tsbuttonFilterEvents.Click += new System.EventHandler(this.tsbuttonFilterEvents_Click);
            // 
            // tsbuttonRefresh
            // 
            this.tsbuttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbuttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbuttonRefresh.Image")));
            this.tsbuttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbuttonRefresh.Name = "tsbuttonRefresh";
            this.tsbuttonRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbuttonRefresh.Text = "toolStripButton1";
            this.tsbuttonRefresh.ToolTipText = "Refresh Windows";
            this.tsbuttonRefresh.Click += new System.EventHandler(this.tsbuttonRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonStartStop
            // 
            this.tsButtonStartStop.CheckOnClick = true;
            this.tsButtonStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonStartStop.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonStartStop.Image")));
            this.tsButtonStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonStartStop.Name = "tsButtonStartStop";
            this.tsButtonStartStop.Size = new System.Drawing.Size(23, 22);
            this.tsButtonStartStop.Text = "toolStripButton1";
            this.tsButtonStartStop.ToolTipText = "Start/Stop Event Logging";
            this.tsButtonStartStop.Click += new System.EventHandler(this.tsButtonStartStop_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonClear
            // 
            this.tsButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonClear.Image")));
            this.tsButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonClear.Name = "tsButtonClear";
            this.tsButtonClear.Size = new System.Drawing.Size(23, 22);
            this.tsButtonClear.Text = "toolStripButton1";
            this.tsButtonClear.ToolTipText = "Clear Event Window";
            this.tsButtonClear.Click += new System.EventHandler(this.tsButtonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 477);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managed Spy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.treeMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.propertiesPage.ResumeLayout(false);
            this.eventsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeWindow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashWindow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage propertiesPage;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TabPage eventsPage;
        private System.Windows.Forms.ToolStripMenuItem filterEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutManagedSpyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeMenuStrip;
        private System.Windows.Forms.ToolStripButton tsbuttonRefresh;
        private System.Windows.Forms.ToolStripButton tsbuttonFilterEvents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButtonStartStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsButtonClear;
        private System.Windows.Forms.DataGridView eventGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventArgs;
        private ClickToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ShowNative;
    }
}

