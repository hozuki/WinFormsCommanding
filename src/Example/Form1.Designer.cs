namespace Example {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btnInvoke1 = new System.Windows.Forms.Button();
            this.btnToggle1 = new System.Windows.Forms.Button();
            this.btnInvoke1Param = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileInvoke1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileInvoke2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInvoke2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvoke1
            // 
            this.btnInvoke1.Location = new System.Drawing.Point(23, 41);
            this.btnInvoke1.Name = "btnInvoke1";
            this.btnInvoke1.Size = new System.Drawing.Size(132, 52);
            this.btnInvoke1.TabIndex = 0;
            this.btnInvoke1.Text = "Invoke Command 1";
            this.btnInvoke1.UseVisualStyleBackColor = true;
            // 
            // btnToggle1
            // 
            this.btnToggle1.Location = new System.Drawing.Point(23, 99);
            this.btnToggle1.Name = "btnToggle1";
            this.btnToggle1.Size = new System.Drawing.Size(132, 47);
            this.btnToggle1.TabIndex = 1;
            this.btnToggle1.Text = "Toggle Command 1";
            this.btnToggle1.UseVisualStyleBackColor = true;
            // 
            // btnInvoke1Param
            // 
            this.btnInvoke1Param.Location = new System.Drawing.Point(23, 152);
            this.btnInvoke1Param.Name = "btnInvoke1Param";
            this.btnInvoke1Param.Size = new System.Drawing.Size(132, 53);
            this.btnInvoke1Param.TabIndex = 2;
            this.btnInvoke1Param.Text = "Invoke Command 1 with Parameter";
            this.btnInvoke1Param.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(184, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileInvoke1,
            this.mnuFileInvoke2,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileInvoke1
            // 
            this.mnuFileInvoke1.Name = "mnuFileInvoke1";
            this.mnuFileInvoke1.Size = new System.Drawing.Size(190, 22);
            this.mnuFileInvoke1.Text = "Invoke Command 1";
            // 
            // mnuFileInvoke2
            // 
            this.mnuFileInvoke2.Name = "mnuFileInvoke2";
            this.mnuFileInvoke2.Size = new System.Drawing.Size(190, 22);
            this.mnuFileInvoke2.Text = "Invoke Command 2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(190, 22);
            this.mnuFileExit.Text = "E&xit";
            // 
            // btnInvoke2
            // 
            this.btnInvoke2.Location = new System.Drawing.Point(23, 211);
            this.btnInvoke2.Name = "btnInvoke2";
            this.btnInvoke2.Size = new System.Drawing.Size(132, 52);
            this.btnInvoke2.TabIndex = 4;
            this.btnInvoke2.Text = "Invoke Command 2";
            this.btnInvoke2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 283);
            this.Controls.Add(this.btnInvoke2);
            this.Controls.Add(this.btnInvoke1Param);
            this.Controls.Add(this.btnToggle1);
            this.Controls.Add(this.btnInvoke1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvoke1;
        private System.Windows.Forms.Button btnToggle1;
        private System.Windows.Forms.Button btnInvoke1Param;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileInvoke1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileInvoke2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.Button btnInvoke2;
    }
}

