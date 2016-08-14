namespace sqlite
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.保存button = new System.Windows.Forms.Button();
            this.取消button = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制 = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切 = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.删除 = new System.Windows.Forms.ToolStripMenuItem();
            this.文本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修改时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.文本,
            this.修改时间});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(682, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // 保存button
            // 
            this.保存button.Location = new System.Drawing.Point(536, 366);
            this.保存button.Name = "保存button";
            this.保存button.Size = new System.Drawing.Size(75, 23);
            this.保存button.TabIndex = 1;
            this.保存button.Text = "保存";
            this.保存button.UseVisualStyleBackColor = true;
            this.保存button.Click += new System.EventHandler(this.保存button_Click);
            // 
            // 取消button
            // 
            this.取消button.Location = new System.Drawing.Point(617, 366);
            this.取消button.Name = "取消button";
            this.取消button.Size = new System.Drawing.Size(75, 23);
            this.取消button.TabIndex = 2;
            this.取消button.Text = "取消";
            this.取消button.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制,
            this.剪切,
            this.粘贴,
            this.toolStripSeparator1,
            this.删除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 98);
            // 
            // 复制
            // 
            this.复制.Name = "复制";
            this.复制.Size = new System.Drawing.Size(100, 22);
            this.复制.Text = "复制";
            this.复制.Click += new System.EventHandler(this.复制_Click);
            // 
            // 剪切
            // 
            this.剪切.Name = "剪切";
            this.剪切.Size = new System.Drawing.Size(100, 22);
            this.剪切.Text = "剪切";
            // 
            // 粘贴
            // 
            this.粘贴.Name = "粘贴";
            this.粘贴.Size = new System.Drawing.Size(100, 22);
            this.粘贴.Text = "粘贴";
            this.粘贴.Click += new System.EventHandler(this.粘贴_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // 删除
            // 
            this.删除.Name = "删除";
            this.删除.Size = new System.Drawing.Size(100, 22);
            this.删除.Text = "删除";
            this.删除.Click += new System.EventHandler(this.删除_Click);
            // 
            // 文本
            // 
            this.文本.HeaderText = "文本";
            this.文本.MaxInputLength = 65535;
            this.文本.MinimumWidth = 500;
            this.文本.Name = "文本";
            this.文本.Width = 538;
            // 
            // 修改时间
            // 
            this.修改时间.HeaderText = "修改时间";
            this.修改时间.MinimumWidth = 100;
            this.修改时间.Name = "修改时间";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(704, 401);
            this.Controls.Add(this.取消button);
            this.Controls.Add(this.保存button);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 保存button;
        private System.Windows.Forms.Button 取消button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制;
        private System.Windows.Forms.ToolStripMenuItem 粘贴;
        private System.Windows.Forms.ToolStripMenuItem 剪切;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 删除;
        private System.Windows.Forms.DataGridViewTextBoxColumn 文本;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修改时间;
    }
}

