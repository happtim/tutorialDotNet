using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegexTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageOriginal;
            treeView1.ExpandAll();
            btnSearch.Checked = true;
        }



        //点击匹配
        private void btnMatch_Click(object sender, EventArgs e)
        {

            RegexOptions opt = RegexOptions.None;
            if (btnIgnoreCase.CheckState == CheckState.Checked) {
                opt |= RegexOptions.IgnoreCase;
            }
            if (btnSingleLine.CheckState == CheckState.Checked) {
                opt |= RegexOptions.Singleline;
            }
            if (btnMultiLine.CheckState == CheckState.Checked) {
                opt |= RegexOptions.Multiline;
            }
            if (btnIgnoreWhiteSpace.CheckState == CheckState.Checked) {
                opt |= RegexOptions.IgnorePatternWhitespace;
            }
            if (btnExplicitCapture.CheckState == CheckState.Checked) {
                opt |= RegexOptions.ExplicitCapture;
            }

            listViewResult.Clear();
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MatchingText";
            this.columnHeader2.Width = 104;

            String pattern = txtRegex.Text.Trim();
            String input = richTextBoxOriginal.Text.Trim();

            Regex rgx = new Regex(pattern, opt);
            if (btnReplace.CheckState == CheckState.Checked) {
                richTxtReplacement.Text =  rgx.Replace(input,txtReplace.Text);
                tabControl.SelectedTab = tabPageReplacement;
                return;
            }
            MatchCollection mc =  rgx.Matches(input);
            if (mc.Count > 0 && mc[0].Groups.Count - 1 > 0) {
                for (int i = 0; i < mc[0].Groups.Count - 1; i++) {
                    listViewResult.Columns.Add("SubMatching" + (i + 1));
                }
            }

            for(int i = 0;i < mc.Count; i++){
                ListViewItem item =  listViewResult.Items.Add(
                    new ListViewItem(i+"")
                );

                if (mc[i].Groups.Count > 0) { 
                    for(int j = 0 ; j < mc[i].Groups.Count; j++){
                        item.SubItems.Add( mc[i].Groups[j].Value);
                    }
                }
            }

            tabControl.SelectedTab = tabPageMatching;
        }

        private void richTextBoxOriginal_TextChanged(object sender, EventArgs e)
        {
            statusLabelLength.Text = "Length:" + richTextBoxOriginal.Text.Length ;
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam); 

        private void richTextBoxOriginal_SelectionChanged(object sender, EventArgs e)
        {
            int length = richTextBoxOriginal.SelectionLength;
            int start = richTextBoxOriginal.SelectionStart;

            int row = (int)SendMessage(richTextBoxOriginal.Handle, 0xC9, -1, 0) + 1;

            if(length == 0)
                richTextBoxOriginal.Select(start, 1);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                richTextBoxOriginal.Text = File.ReadAllText(open.FileName);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tabControl.SelectedTab = tabPageTip;
            switch (e.Node.Text) { 
                case ".":
                    txtTips.Text = "匹配换行符以外的任何字符.";
                    break;
                case "\\w":
                    txtTips.Text = "与任何单词字符匹配，包括下划线.等价于[A-Za-z0-9_].\r\n";
                    txtTips.Text += @"\W与任何非单词字符匹配.等价于[^A-Za-z0-9_].";
                    break;
                case "\\s":
                    txtTips.Text = @"与任何白字符匹配，包括空格、制表符、分页符等。等价于[\f\n\r\t\v].";
                    txtTips.Text += "\r\n";
                    txtTips.Text += @"\S与任何非空白的字符匹配.等价于[^\f\n\r\t\v].";
                    break;
                case "\\d":
                    txtTips.Text = "与一个数字字符匹配.等价于[0-9].].\r\n";
                    txtTips.Text += "与非数字的字符匹配.等价于[^0-9].";
                    break;
                case "\\b":
                    txtTips.Text = "与单词的边界匹配,即单词与空格之间的位置.\r\n";
                    txtTips.Text += "例如:\"er\\b\"与\"never\"中的\"er\"匹配,但是不匹配\"verb\"中的\"er\".\r\n";
                    txtTips.Text += "\\B与非单词边界匹配.\r\n";
                    txtTips.Text += "例如:ea*r\\B\"与\"neverearly\"中的\"ear\"匹配.";
                    break;
                case "\\f":
                    txtTips.Text = "与分页符匹配.";
                    break;
                case "\\n":
                    txtTips.Text = "与换行符字符匹配.";
                    break;
                case "\\r":
                    txtTips.Text = "与回车字符匹配.";
                    break;
                case "\\t":
                    txtTips.Text = "与制表符匹配.";
                    break;
                case "\\v":
                    txtTips.Text = "与垂直制表符匹配."; 
                    break;
                case "^":
                    txtTips.Text = "匹配输入的开始位置.";
                    break;
                case "$":
                    txtTips.Text = "匹配输入的结尾.";
                    break;

                case "\\":
                    txtTips.Text = "将下一个字符标记为特殊字符或字面值.\r\n";
                    txtTips.Text += "例如\"n\"与字符\"n\"匹配.\"]\n]\"与换行符匹配.";
                    break;

                case "*":
                    txtTips.Text = "匹配前一个字符零次或几次.";
                    break;
                case "+":
                    txtTips.Text = "匹配前一个字符一次或多次.";
                    break;
                case "?":
                    txtTips.Text = "匹配前一个字符零次或一次.";
                    break;
                case "{n}":
                    txtTips.Text = "n为非负的整数.匹配恰好n次.";
                    break;
                case "{n,}":
                    txtTips.Text = "n为非负的整数.匹配至少n次.";
                    break;
                case "{n,m}":
                    txtTips.Text = "m和n为非负的整数.匹配至少n次,至多m次.";
                    break;

                case "[]":
                    txtTips.Text = "一个字符集.与括号中字符的其中之一匹配.\r\n";
                    txtTips.Text += "[^abc]一个否定的字符集.匹配不在此括号中的任何字符.\r\n";
                    txtTips.Text += "[^m-n]否定的字符区间.与不在指定区间内的字符匹配.";
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnReplace.CheckState == CheckState.Checked) {
                btnReplace.Checked = false;

                splitContainer2.Panel1.Controls.Clear();
                splitContainer2.Panel1.Controls.Add(txtRegex);

            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (btnSearch.CheckState == CheckState.Checked) {
                btnSearch.Checked = false;

                splitContainer2.Panel1.Controls.Clear();
                splitContainer2.Panel1.Controls.Add(splitContainer3);
                splitContainer3.Dock = DockStyle.Fill;
                splitContainer3.SplitterDistance = splitContainer3.Size.Width / 2;

                splitContainer3.Panel1.Controls.Add(txtRegex);
                txtReplace.Multiline = true;
                txtReplace.Dock = DockStyle.Fill;

                splitContainer3.Panel2.Controls.Add(txtReplace);
            }

        }

   




  
    }
}
