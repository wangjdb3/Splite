using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

namespace sqlite
{
    public partial class Form1 : Form
    {
        public int rowIndex = 0;
        public int columnIndex = 0;
        public SQLiteConnection conn = null;
        public int changedKey = 0;
        
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            //////
            SqliteHelper.Set_AES_Key();
            /////
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/数据库.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            //           test();
            //           test1();
            conn.Open();//打开连接
            string sql = "CREATE TABLE IF NOT EXISTS 文本(文本 BLOB, 修改时间 TEXT, 长度 INTEGER);";//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表 
            conn.Close();
            SqliteHelper.Readdata(conn, dataGridView1);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        rowIndex = e.RowIndex;
                        columnIndex = e.ColumnIndex;
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SetDataGridViewRowXh(e, dataGridView1);
        }

        private void SetDataGridViewRowXh(DataGridViewRowPostPaintEventArgs e, DataGridView dataGridView)
        {
            SolidBrush solidBrush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);
            int xh = e.RowIndex + 1;
            e.Graphics.DrawString(xh.ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
        }

        private void 复制_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView1.Rows[rowIndex].Cells[columnIndex].Value);
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                changedKey = 1;
            }
        }

        private void 粘贴_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.Rows[rowIndex].IsNewRow == true)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = iData.GetData(DataFormats.Text);
                }
                //DialogResult dr;
                else if (MessageBox.Show("是否覆盖？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = iData.GetData(DataFormats.Text);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = DateTime.Now.ToString();
                    changedKey = 1;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                if (e.RowIndex == dataGridView1.Rows.Count - 1)
                {
                    if (dataGridView1.IsCurrentCellDirty)
                        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void 保存button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定保存？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SqliteHelper.Writedata(conn, dataGridView1);
                changedKey = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changedKey == 1)
            {
                保存提示 form = new 保存提示();
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.Yes)
                {
                    SqliteHelper.Writedata(conn, dataGridView1);
                    e.Cancel = false;
                }
                else if (r == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (MessageBox.Show("是否关闭程序？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
