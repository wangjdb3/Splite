using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace sqlite
{
    class SqliteHelper
    {
        [DllImport(@"AES.dll", EntryPoint = "setKey")]
        private static extern void setKey([In, Out] byte[] AES_Key);

        [DllImport(@"AES.dll", EntryPoint = "aesDecrypt_interface")]
        private static extern void aesDecrypt_interface([In, Out] byte[] buffer, [In, Out] byte[] chainBlock, [In]int i);

        [DllImport(@"AES.dll", EntryPoint = "aesEncrypt_interface")]
        private static extern void aesEncrypt_interface([In, Out] byte[] buffer, [In, Out] byte[] chainBlock, [In]int i);

        static string key = "51x'xzCu$QXfu7vQg1AUiYsfcW3GI:fH";
        static byte[] AES_Key_Table = System.Text.Encoding.Default.GetBytes(key);

        public static void Set_AES_Key()
        {
            setKey(AES_Key_Table);
        }


        public static void Writedata(SQLiteConnection conn, DataGridView dataGridView)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "DELETE FROM 文本";
            cmd.ExecuteNonQuery();
            using (SQLiteTransaction tran = conn.BeginTransaction())//实例化一个事务  
            {
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    string tmp = dataGridView.Rows[i].Cells[0].Value.ToString();
                    //byte[] dat= System.Text.Encoding.Default.GetBytes(tmp);
                    byte[] dat = System.Text.Encoding.Default.GetBytes(tmp);
                    byte[] chainCipherBlock = new byte[16];
                    Array.Clear(chainCipherBlock, 0, chainCipherBlock.Length);
                    int num = dat.Length / 16;
                    int b = dat.Length % 16;
                    if (b > 0)
                    {
                        num = num + 1;
                    }
                    byte[] dat_tmp = new byte[num * 16];
                    Array.Copy(dat, dat_tmp, dat.Length);
                    aesEncrypt_interface(dat_tmp, chainCipherBlock, num);
//                    tmp = System.Text.Encoding.Default.GetString(dat);
                    //////////////
                    cmd.Transaction = tran;
                    cmd.CommandText = "insert into 文本 values(@文本, @修改时间, @长度)";//设置带参SQL语句  
                    cmd.Parameters.AddRange(new[] {//添加参数  
                                   new SQLiteParameter("@文本", dat_tmp),
                                   new SQLiteParameter("@修改时间", dataGridView.Rows[i].Cells[1].Value.ToString()),
                                   new SQLiteParameter("@长度", dat.Length)
                               });
                    cmd.ExecuteNonQuery();//执行查询  
                }
                tran.Commit();//提交  
            }
            cmd.CommandText = "vacuum";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Readdata(SQLiteConnection conn, DataGridView dataGridView)
        {

            conn.Open();
            string sql = "select * from 文本";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            try
            {
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                while (reader.Read())
                {
                    int data_length = reader.GetInt32(2);
                    int num = data_length / 16;
                    int b = data_length % 16;
                    if (b > 0)
                    {
                        num = num + 1;
                    }
                    byte[] dat_tmp = new byte[num * 16];
                    reader.GetBytes(0, 0, dat_tmp, 0, num * 16);
                    //byte[] dat = System.Text.Encoding.Default.GetBytes(reader.GetString(0));
                    byte[] chainCipherBlock = new byte[16];
                    //setKey(AES_Key_Table);
                    aesDecrypt_interface(dat_tmp, chainCipherBlock, num);
                    byte[] dat = new byte[data_length];
                    Array.Copy(dat_tmp, dat, data_length);
                    string tmp = System.Text.Encoding.Default.GetString(dat);
                    dataGridView.Rows.Add(tmp, reader.GetString(1));
                }
            }
            catch (Exception e)
            {
            }
            conn.Close();
        }
    }
}
/*        public static void Writedata(SQLiteConnection conn)
                {
                    //            SQLiteConnection conn = null;

                    //            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
                    //            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                    conn.Open();//打开数据库，若文件不存在会自动创建  

                    string sql = "CREATE TABLE IF NOT EXISTS student(name TEXT, sex TEXT);";//建表语句  
                    SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                    cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

                    SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                    //            cmdInsert.CommandText = "truncate table student";
                    //            cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "INSERT INTO student VALUES('小红', '男')";//插入几条数据  
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "INSERT INTO student VALUES('小李', '女')";
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "INSERT INTO student VALUES('小明', '男')";
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "CREATE TEMPORARY TABLE  _tmp(name, sex)";
                    //"delete from table where ..."
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "INSERT INTO _tmp SELECT name,sex from student where rowid >10000";// NOT IN (1)";//INSERT INTO t1_backup SELECT a,b FROM t1
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "DELETE FROM student";
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "insert into student select * from _tmp";
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "drop table _tmp";
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.CommandText = "vacuum";
                    cmdInsert.ExecuteNonQuery();
                    conn.Close();
                }*/
