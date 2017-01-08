using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ScreenShot_Grab
{
    public partial class HistoryForm : Form
    {
        private MainForm form1;
        private Dictionary<ListViewItem,string[]> events = new Dictionary<ListViewItem, string[]>();

        public HistoryForm(MainForm parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            foreach (var item in form1.events) {
                AddEvent(item);
            }
            /*var ColumnIndex = 2;
            foreach (ListViewItem lvi in eventlist.Items) {
                Debug.WriteLine(lvi.SubItems[ColumnIndex].Text);
                lvi.SubItems[ColumnIndex].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
                lvi.SubItems[ColumnIndex].ForeColor = Color.Blue;
            }*/
        }

        internal void AddEvent(string[] item)
        {
            var itm = new ListViewItem(item);
            //itm.UseItemStyleForSubItems = false;
            if (item[4]!="0") itm.ForeColor = SystemColors.HotTrack;
            eventlist.Items.Insert(0,itm);
            events.Add(itm,item);
        }

        ListViewItem selected = null;

        private void eventlist_MouseMove(object sender, MouseEventArgs e)
        {
            var info = eventlist.HitTest(e.Location);
            if (info.Item == selected) return;
            if (selected != null) {
                selected.Font = eventlist.Font;
            }
            selected = null;
            if (info.SubItem != null && info.Item.SubItems[4].Text!="0") {
                info.Item.Font = new Font(info.SubItem.Font, FontStyle.Underline);
                eventlist.Cursor = Cursors.Hand;
                selected = info.Item;
            } else {
                eventlist.Cursor = Cursors.Default;
            }
        }

        private void eventlist_MouseClick(object sender, MouseEventArgs e)
        {
            var info = eventlist.HitTest(e.Location);
            if (info == null) return;
            if (e.Button != MouseButtons.Right) return;
            var loc = e.Location;
            loc.Y += 5;
            var show = info.Item.SubItems[4].Text != "0" && eventlist.SelectedItems.Count == 1 ? true : false;
            contentmenu.Items[0].Visible = show;
            contentmenu.Items[1].Visible = show;
            contentmenu.Items[3].Visible = (show && info.Item.SubItems[4].Text != "3");
            contentmenu.Items[3].Enabled = (info.Item.SubItems[5].Text != "" || info.Item.SubItems[4].Text == "1");
            /*for (int i = 0; i < info.Item.SubItems.Count; i++) { 
                Debug.WriteLine(info.Item.SubItems[i].Text);
            }*/
            contentmenu.Show(this, loc);
            return;
        }

        private void eventlist_DoubleMouseClick(object sender, MouseEventArgs e)
        {
            var info = eventlist.HitTest(e.Location);
            if (info == null) return;
            if (e.Button == MouseButtons.Right) return;
            var link = info.Item.SubItems[3].Text;
            if (link != "") {
                try {
                    System.Diagnostics.Process.Start(link);
                } catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in eventlist.SelectedItems) {
                form1.events.Remove(events[item]);
                eventlist.Items.Remove(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in eventlist.SelectedItems) {
                removefileorlink(item);
            }
        }

        private void copylink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(eventlist.SelectedItems[0].SubItems[3].Text);
        }

        private void removelist_Click(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }

        private void removefileorlink(ListViewItem item)
        {
            if (item.SubItems[4].Text == "1") {
                form1.DeleteFile(item.SubItems[3].Text);
                item.SubItems[4].Text = "3";
                events[item][4] = "3";
                //selected.ForeColor = eventlist.ForeColor;
            } else if (item.SubItems[4].Text == "2" && item.SubItems[5].Text != "") {
                if (item.SubItems[3].Text.Contains("fastpic.ru")) {
                    FastpicAPI.DeleteImage(form1, item.SubItems[3].Text, item.SubItems[5].Text);
                } else {
                    ImgurAPI.DeleteImage(form1, item.SubItems[3].Text, item.SubItems[5].Text);
                }
                item.SubItems[4].Text = "3";
                events[item][4] = "3";
            }
        }

        private void removefile_Click(object sender, EventArgs e)
        {
            removefileorlink(eventlist.SelectedItems[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            savelog.InitialDirectory = form1.spath;
            savelog.ShowDialog();
        }

        private void savelog_FileOk(object sender, CancelEventArgs e)
        {
            var name = savelog.FileName;
            try {
                var file = new StreamWriter(name);
                foreach (var item in events) {
                    var line = (string[])item.Value;
                    file.WriteLine("["+line[0]+"] "+line[2]+(line[1]!=""?" - " +line[3]:""));
                }
                file.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, MainForm.LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            var link = eventlist.SelectedItems[0].SubItems[3].Text;
            if (link != "") {
                try {
                    System.Diagnostics.Process.Start(link);
                } catch { }
            }
        }
    }
}
