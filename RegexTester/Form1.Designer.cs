namespace RegexTester
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode(".");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("\\w");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("\\s");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("\\d");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("\\b");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("\\f");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("\\n");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("\\r");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("\\t");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("\\v");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("^");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("$");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("metacharacter", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("\\");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Escape character", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("*");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("+");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("?");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("{n}");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("{n,}");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("{n,m}");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("repetition", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("[]");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Charactor", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Regular expression syntax", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode15,
            treeNode22,
            treeNode24});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnReplace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIgnoreCase = new System.Windows.Forms.ToolStripButton();
            this.btnSingleLine = new System.Windows.Forms.ToolStripButton();
            this.btnMultiLine = new System.Windows.Forms.ToolStripButton();
            this.btnIgnoreWhiteSpace = new System.Windows.Forms.ToolStripButton();
            this.btnExplicitCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTip = new System.Windows.Forms.TabPage();
            this.txtTips = new System.Windows.Forms.TextBox();
            this.tabPageOriginal = new System.Windows.Forms.TabPage();
            this.richTextBoxOriginal = new System.Windows.Forms.RichTextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.tabPageMatching = new System.Windows.Forms.TabPage();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageReplacement = new System.Windows.Forms.TabPage();
            this.richTxtReplacement = new System.Windows.Forms.RichTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageTip.SuspendLayout();
            this.tabPageOriginal.SuspendLayout();
            this.tabPageMatching.SuspendLayout();
            this.tabPageReplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMatch,
            this.toolStripSeparator1,
            this.btnSearch,
            this.btnReplace,
            this.toolStripSeparator2,
            this.btnIgnoreCase,
            this.btnSingleLine,
            this.btnMultiLine,
            this.btnIgnoreWhiteSpace,
            this.btnExplicitCapture,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMatch
            // 
            this.btnMatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMatch.Image = ((System.Drawing.Image)(resources.GetObject("btnMatch.Image")));
            this.btnMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(47, 22);
            this.btnMatch.Text = "match";
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.CheckOnClick = true;
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 22);
            this.btnSearch.Text = "search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.CheckOnClick = true;
            this.btnReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReplace.Image = ((System.Drawing.Image)(resources.GetObject("btnReplace.Image")));
            this.btnReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(55, 22);
            this.btnReplace.Text = "replace";
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnIgnoreCase
            // 
            this.btnIgnoreCase.CheckOnClick = true;
            this.btnIgnoreCase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIgnoreCase.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnoreCase.Image")));
            this.btnIgnoreCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIgnoreCase.Name = "btnIgnoreCase";
            this.btnIgnoreCase.Size = new System.Drawing.Size(79, 22);
            this.btnIgnoreCase.Text = "IgnoreCase";
            // 
            // btnSingleLine
            // 
            this.btnSingleLine.CheckOnClick = true;
            this.btnSingleLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSingleLine.Image = ((System.Drawing.Image)(resources.GetObject("btnSingleLine.Image")));
            this.btnSingleLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSingleLine.Name = "btnSingleLine";
            this.btnSingleLine.Size = new System.Drawing.Size(67, 22);
            this.btnSingleLine.Text = "Singleline";
            // 
            // btnMultiLine
            // 
            this.btnMultiLine.CheckOnClick = true;
            this.btnMultiLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMultiLine.Image = ((System.Drawing.Image)(resources.GetObject("btnMultiLine.Image")));
            this.btnMultiLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMultiLine.Name = "btnMultiLine";
            this.btnMultiLine.Size = new System.Drawing.Size(61, 22);
            this.btnMultiLine.Text = "Multiline";
            // 
            // btnIgnoreWhiteSpace
            // 
            this.btnIgnoreWhiteSpace.CheckOnClick = true;
            this.btnIgnoreWhiteSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIgnoreWhiteSpace.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnoreWhiteSpace.Image")));
            this.btnIgnoreWhiteSpace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIgnoreWhiteSpace.Name = "btnIgnoreWhiteSpace";
            this.btnIgnoreWhiteSpace.Size = new System.Drawing.Size(118, 22);
            this.btnIgnoreWhiteSpace.Text = "IgnoreWhitespace";
            // 
            // btnExplicitCapture
            // 
            this.btnExplicitCapture.CheckOnClick = true;
            this.btnExplicitCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExplicitCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnExplicitCapture.Image")));
            this.btnExplicitCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExplicitCapture.Name = "btnExplicitCapture";
            this.btnExplicitCapture.Size = new System.Drawing.Size(98, 22);
            this.btnExplicitCapture.Text = "ExplicitCapture";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLength});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelLength
            // 
            this.statusLabelLength.Name = "statusLabelLength";
            this.statusLabelLength.Size = new System.Drawing.Size(50, 17);
            this.statusLabelLength.Text = "Length:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(796, 309);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = ".";
            treeNode2.Name = "Node3";
            treeNode2.Text = "\\w";
            treeNode3.Name = "Node4";
            treeNode3.Text = "\\s";
            treeNode4.Name = "Node5";
            treeNode4.Text = "\\d";
            treeNode5.Name = "Node6";
            treeNode5.Text = "\\b";
            treeNode6.Name = "Node0";
            treeNode6.Text = "\\f";
            treeNode7.Name = "Node1";
            treeNode7.Text = "\\n";
            treeNode8.Name = "Node2";
            treeNode8.Text = "\\r";
            treeNode9.Name = "Node3";
            treeNode9.Text = "\\t";
            treeNode10.Name = "Node4";
            treeNode10.Text = "\\v";
            treeNode11.Name = "Node7";
            treeNode11.Text = "^";
            treeNode12.Name = "Node8";
            treeNode12.Text = "$";
            treeNode13.Name = "Node1";
            treeNode13.Text = "metacharacter";
            treeNode14.Name = "Node10";
            treeNode14.Text = "\\";
            treeNode15.Name = "Node9";
            treeNode15.Text = "Escape character";
            treeNode16.Name = "Node0";
            treeNode16.Text = "*";
            treeNode17.Name = "Node1";
            treeNode17.Text = "+";
            treeNode18.Name = "Node2";
            treeNode18.Text = "?";
            treeNode19.Name = "Node3";
            treeNode19.Text = "{n}";
            treeNode20.Name = "Node5";
            treeNode20.Text = "{n,}";
            treeNode21.Name = "Node6";
            treeNode21.Text = "{n,m}";
            treeNode22.Name = "Node11";
            treeNode22.Text = "repetition";
            treeNode23.Name = "Node8";
            treeNode23.Text = "[]";
            treeNode24.Name = "Node7";
            treeNode24.Text = "Charactor";
            treeNode25.Name = "Node0";
            treeNode25.Text = "Regular expression syntax";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode25});
            this.treeView1.Size = new System.Drawing.Size(188, 309);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtRegex);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl);
            this.splitContainer2.Size = new System.Drawing.Size(604, 309);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtRegex
            // 
            this.txtRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegex.Location = new System.Drawing.Point(0, 0);
            this.txtRegex.Multiline = true;
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(604, 83);
            this.txtRegex.TabIndex = 0;
            this.txtRegex.Text = "<img id=\"(.*?)\" alt=\"(.*?)\" src=\"(.*?)\" title=\"(.*?)\" xmlns=\"(.*?)\" class=\"(.*?)\"" +
    " />";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTip);
            this.tabControl.Controls.Add(this.tabPageOriginal);
            this.tabControl.Controls.Add(this.tabPageMatching);
            this.tabControl.Controls.Add(this.tabPageReplacement);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(604, 222);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageTip
            // 
            this.tabPageTip.Controls.Add(this.txtTips);
            this.tabPageTip.Location = new System.Drawing.Point(4, 22);
            this.tabPageTip.Name = "tabPageTip";
            this.tabPageTip.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTip.Size = new System.Drawing.Size(596, 196);
            this.tabPageTip.TabIndex = 0;
            this.tabPageTip.Text = "GrammarTips";
            this.tabPageTip.UseVisualStyleBackColor = true;
            // 
            // txtTips
            // 
            this.txtTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTips.Location = new System.Drawing.Point(3, 3);
            this.txtTips.Multiline = true;
            this.txtTips.Name = "txtTips";
            this.txtTips.ReadOnly = true;
            this.txtTips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTips.Size = new System.Drawing.Size(590, 190);
            this.txtTips.TabIndex = 0;
            // 
            // tabPageOriginal
            // 
            this.tabPageOriginal.Controls.Add(this.richTextBoxOriginal);
            this.tabPageOriginal.Controls.Add(this.btnOpenFile);
            this.tabPageOriginal.Location = new System.Drawing.Point(4, 22);
            this.tabPageOriginal.Name = "tabPageOriginal";
            this.tabPageOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOriginal.Size = new System.Drawing.Size(596, 196);
            this.tabPageOriginal.TabIndex = 1;
            this.tabPageOriginal.Text = "OriginalText";
            this.tabPageOriginal.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOriginal
            // 
            this.richTextBoxOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOriginal.Location = new System.Drawing.Point(3, 36);
            this.richTextBoxOriginal.Name = "richTextBoxOriginal";
            this.richTextBoxOriginal.Size = new System.Drawing.Size(590, 157);
            this.richTextBoxOriginal.TabIndex = 1;
            this.richTextBoxOriginal.Text = "";
            this.richTextBoxOriginal.SelectionChanged += new System.EventHandler(this.richTextBoxOriginal_SelectionChanged);
            this.richTextBoxOriginal.TextChanged += new System.EventHandler(this.richTextBoxOriginal_TextChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(7, 7);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "OpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabPageMatching
            // 
            this.tabPageMatching.Controls.Add(this.listViewResult);
            this.tabPageMatching.Location = new System.Drawing.Point(4, 22);
            this.tabPageMatching.Name = "tabPageMatching";
            this.tabPageMatching.Size = new System.Drawing.Size(596, 196);
            this.tabPageMatching.TabIndex = 2;
            this.tabPageMatching.Text = "MatchingResults";
            this.tabPageMatching.UseVisualStyleBackColor = true;
            // 
            // listViewResult
            // 
            this.listViewResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.FullRowSelect = true;
            this.listViewResult.GridLines = true;
            this.listViewResult.Location = new System.Drawing.Point(0, 0);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.ShowItemToolTips = true;
            this.listViewResult.Size = new System.Drawing.Size(596, 196);
            this.listViewResult.TabIndex = 0;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MatchingText";
            this.columnHeader2.Width = 104;
            // 
            // tabPageReplacement
            // 
            this.tabPageReplacement.Controls.Add(this.richTxtReplacement);
            this.tabPageReplacement.Location = new System.Drawing.Point(4, 22);
            this.tabPageReplacement.Name = "tabPageReplacement";
            this.tabPageReplacement.Size = new System.Drawing.Size(596, 196);
            this.tabPageReplacement.TabIndex = 3;
            this.tabPageReplacement.Text = "Replacement";
            this.tabPageReplacement.UseVisualStyleBackColor = true;
            // 
            // richTxtReplacement
            // 
            this.richTxtReplacement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtReplacement.Location = new System.Drawing.Point(0, 0);
            this.richTxtReplacement.Name = "richTxtReplacement";
            this.richTxtReplacement.Size = new System.Drawing.Size(596, 196);
            this.richTxtReplacement.TabIndex = 0;
            this.richTxtReplacement.Text = "";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Size = new System.Drawing.Size(150, 100);
            this.splitContainer3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 356);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageTip.ResumeLayout(false);
            this.tabPageTip.PerformLayout();
            this.tabPageOriginal.ResumeLayout(false);
            this.tabPageMatching.ResumeLayout(false);
            this.tabPageReplacement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTip;
        private System.Windows.Forms.TabPage tabPageOriginal;
        private System.Windows.Forms.TextBox txtTips;
        private System.Windows.Forms.TabPage tabPageMatching;
        private System.Windows.Forms.TabPage tabPageReplacement;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ToolStripButton btnMatch;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLength;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.RichTextBox richTextBoxOriginal;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnIgnoreCase;
        private System.Windows.Forms.ToolStripButton btnSingleLine;
        private System.Windows.Forms.ToolStripButton btnMultiLine;
        private System.Windows.Forms.ToolStripButton btnIgnoreWhiteSpace;
        private System.Windows.Forms.ToolStripButton btnExplicitCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.RichTextBox richTxtReplacement;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtReplace;
    }
}

