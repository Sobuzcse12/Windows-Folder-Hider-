using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;


namespace WinHideFolder
{
    public partial class FolderHide : Form
    {
        DirectoryInfo ch;
        string []gtext = new string[100];
        string[] drive = new string[1000];
        int i = 0;
        int count = 0;
        DataTable dt = new DataTable();
        FileInfo fileinfo;
        string text = "";
        public FolderHide()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Bitmap img;
                img = new Bitmap(@"E:\lock.bmp");
               // openFileDialog1.Multiselect = true; 
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    text = openFileDialog1.FileName;
                    gtext[i] = text;
                    i++;
                }
              /* File.
                 FileIO.FileSystem.FileExists(text) Then
                    fileinfo = File.getF);
                    fileinfo.Attributes = IO.FileAttributes.Hidden + IO.FileAttributes.System;*/
                //End If
                MessageBox.Show(text);
                ch = new DirectoryInfo(text);
                ch.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Offline;
                //ch.Attributes = FileAttributes.System;
                MessageBox.Show("Hidden");
               /* DataRow dr = dt.NewRow();
                dt.Columns.Add("name");
                dt.Columns.Add("status");
                dr["name"] = text;
                dr["status"] = "Hidden";
                dt.Rows.Add(dr);*/
                //DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                //dataGridView1.Columns.Add(imageCol);
                dataGridView1.Rows.Add(text,img,"Hidden","Open");
                Connection con = new Connection();
                con.insert(text);
               // dataGridView1.Rows[0].Cells[4].Value = img;
 
               // dataGridView1.DataSource = dt;
                foreach (Process p in Process.GetProcessesByName("explorer"))
                {

                    p.Kill();
                }
                this.Show();
                
            }
            catch (Exception exp) { MessageBox.Show(exp.ToString()); };
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                Bitmap img;
                img = new Bitmap(@"E:\lock.bmp");
                var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
                foreach (var myscore in drives)
                {

                    string myresult = myscore.ToString();
                    MessageBox.Show("" + myresult);
                    text = myresult;
                    DirectoryInfo d = new DirectoryInfo(myresult);
                    FileInfo[] Files = d.GetFiles(); //Getting Text files
                    string[] dirs = Directory.GetDirectories(text);
                    string str = "";
                    count = 0;

                    foreach (FileInfo file in Files)
                    {
                        str = text + file.Name;
                        MessageBox.Show(str);


                        //MessageBox.Show(str);
                        file.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Offline;
                        drive[count] = str;
                     
                        con.insert(str);
                        count++;

                    }
                    foreach (string dir in dirs)
                    {
                        // MessageBox.Show(dir);
                        str = dir;
                        ch = new DirectoryInfo(dir);
                        ch.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Offline;
                        drive[count] = str;
                        con.insert(str);
                        count++;
                    }
                    dataGridView1.Rows.Add(text, img, "Hidden", "Open");
                    foreach (Process p in Process.GetProcessesByName("explorer"))
                    {
                        
                        p.Kill();
                    }
                    this.Show();

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }
        private void itemSelected()
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  int num=dataGridView1.SelectedColumns.Count;
            MessageBox.Show(""+num);*/
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
           
        }
        private void AdminFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            int count = dataGridView1.RowCount;
            
            DialogResult res = MessageBox.Show(this, "You really want to quit?", "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
            if ( res == DialogResult.Yes )
            {
        
                //MessageBox.Show(gtext[0]+drive[0]);
                if (count != 0)
                {
                    MessageBox.Show("Here is at least one item that is not Unhide!!!");
                    e.Cancel = false;
                    return;
                }
                else
                {
                    e.Cancel = false;
                    return;
                }
               
            }
            if (res == DialogResult.No )
            {
                e.Cancel = true;
                return;
                
            }
           
           
        }

        private void FolderHide_Load(object sender, EventArgs e)
        {

            timer1.Start();
            Bitmap img;
            img = new Bitmap(@"E:\lock.bmp");
            Connection con = new Connection();
           
           // MessageBox.Show(length.ToString());
            string[] notClose;
            notClose = con.load();
            int length = con.count;
            //MessageBox.Show(notClose[0]+length);
            for (int j = 0; j <length; j++)
            {
                dataGridView1.Rows.Add(notClose[j], img, "Hidden", "Open");
                gtext[i] = notClose[j];
                i++;
            }
              

          // MyGrid grid = new MyGrid();
           // this.Controls.Add(grid);

           /* MyGrid dataGridView1 = new MyGrid();
            this.Controls.Add(dataGridView1);

            dataGridView1.BackgroundImage = Properties.Resources.EVIveEN;
            dataGridView1.SetCellsTransparent();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                Bitmap img;
                img = new Bitmap(@"E:\lock.bmp");
                string text = "";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    text = folderBrowserDialog1.SelectedPath;
                    MessageBox.Show(text);
                    gtext[i] = text;
                    i++;
                    //txtFilePath.Text = folderBrowserDialog1.SelectedPath;
                }
                ch = new DirectoryInfo(text);
                ch.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Offline;
                MessageBox.Show("Hidden");
                dataGridView1.Rows.Add(text, img, "Hidden", "Open");
                Connection con = new Connection();
                con.insert(text);
                foreach (Process p in Process.GetProcessesByName("explorer"))
                {

                    p.Kill();
                }
                this.Show();
            }
            catch { }
           
        }

        private void itemSele(object sender, EventArgs e)
        {
            pictureBox1.Visible=false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Website ws = new Website();
            ws.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Website ws = new Website();
            ws.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt"); 
        }

        private void mEnterw(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.CadetBlue;
        }

        private void mLeavew(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.White;
        }

        private void mEnters(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void mLeaves(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void selectedCellsButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
           /* Int32 selectedCellCount =
            dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (dataGridView1.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0;
                        i < selectedCellCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(dataGridView1.SelectedCells[i].RowIndex
                            .ToString());
                        sb.Append(", Column: ");
                        sb.Append(dataGridView1.SelectedCells[i].ColumnIndex
                            .ToString());
                        sb.Append(Environment.NewLine);
                    }

                    sb.Append("Total: " + selectedCellCount.ToString());
                    MessageBox.Show(sb.ToString(), "Selected Cells");
                }
            }*/
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                Bitmap img;
                img = new Bitmap(@"E:\lock.bmp");
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    text = folderBrowserDialog1.SelectedPath;
                    MessageBox.Show(text);
                   // gtext[i] = text;
                   // i++;
                    //txtFilePath.Text = folderBrowserDialog1.SelectedPath;
                }
                DirectoryInfo d = new DirectoryInfo(text);
                // string text = "J:" + @"\";


                //ch = new DirectoryInfo(text);
                //ch.Attributes = FileAttributes.Hidden;
                // MessageBox.Show("Hidden");
                //DirectoryInfo d = new DirectoryInfo(@"J:\");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                string[] dirs = Directory.GetDirectories(text);
                string str = "";
                 count = 0;
                foreach (FileInfo file in Files)
                {
                    str = text+ file.Name;
                    MessageBox.Show(str);

                       
                    //MessageBox.Show(str);
                    file.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Offline | FileAttributes.Directory;
                    drive[count] = str;
                    con.insert(str);
                    count++;

                }
                foreach (string dir in dirs)
                {
                    // MessageBox.Show(dir);
                    str = dir;
                    ch = new DirectoryInfo(dir);
                    ch.Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Offline;
                    drive[count] = str;
                    con.insert(str);
                    count++;
                }
                dataGridView1.Rows.Add(text, img, "Hidden", "Open");
                foreach (Process p in Process.GetProcessesByName("explorer"))
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataMouseClick(object sender, MouseEventArgs e)
        {
            /*if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }*/
        }

        private void dataCell(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (text == @"D:\" || text == @"C:\" || text == @"J:\" || text == @"E:\" || text == @"F:\")
                {
                    Connection con = new Connection();
                    drive = con.load();
                    count--;
                    while (count >= 0)
                    {
                        ch = new DirectoryInfo(drive[count]);

                        ch.Attributes = FileAttributes.Normal;
                        MessageBox.Show("Visible");
                        count--;
                    }


                 }
                else
                {
                    i--;
                    // ch = new DirectoryInfo(txtFilePath.Text);
                    if (i >= 0)
                    {
                        ch = new DirectoryInfo(gtext[i]);

                        ch.Attributes = FileAttributes.Normal;
                        Connection con = new Connection();
                        con.delete(gtext[i]);
                        MessageBox.Show("Visible");
                    }
                }
                // MessageBox.Show("Nothing is hide!!!");
                // dataGridView1.Rows.Add("", "", "", "");
                // dataGridView1.Rows.Clear();
                //foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                // {
                // dataGridView1.Rows.RemoveAt(i);
                // }
                if (e.ColumnIndex == 3)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    if (dataGridView1.RowCount == 0)
                        pictureBox1.Visible = true;
                }

            }
            catch(Exception exp) { MessageBox.Show("error"+exp.ToString()); }
           
        }
       
    }

  /*  public class MyGrid : DataGridView
    {
        private Image _backgroundPic;

        [Browsable(true)]
        public override Image BackgroundImage
        {
            get { return _backgroundPic; }
            set { _backgroundPic = value; }
        }

        protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);

            if (((this.BackgroundImage != null)))
            {
                graphics.FillRectangle(Brushes.Black, gridBounds);
                graphics.DrawImage(this.BackgroundImage, gridBounds);
            }
        }

        //Make BackgroundImage can be seen in all cells
        public void SetCellsTransparent()
        {
            this.EnableHeadersVisualStyles = false;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;

            this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;

            foreach (DataGridViewColumn col in this.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Transparent;
            }
        }
    }*/
}
