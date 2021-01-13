
namespace WinFormTool
{
    partial class frmMain
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
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_center = new System.Windows.Forms.Panel();
            this.groupBox_date = new System.Windows.Forms.GroupBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.groupBox_ChineseDate = new System.Windows.Forms.GroupBox();
            this.lbl_chineseDate = new System.Windows.Forms.Label();
            this.tabControl_main.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel_center.SuspendLayout();
            this.groupBox_date.SuspendLayout();
            this.groupBox_ChineseDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(800, 357);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Location = new System.Drawing.Point(0, 428);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.Size = new System.Drawing.Size(800, 22);
            this.statusStrip_main.TabIndex = 1;
            this.statusStrip_main.Text = "statusStrip1";
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.panel_center);
            this.panel_main.Controls.Add(this.panel_top);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(800, 428);
            this.panel_main.TabIndex = 2;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.groupBox_ChineseDate);
            this.panel_top.Controls.Add(this.groupBox_date);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(800, 71);
            this.panel_top.TabIndex = 1;
            // 
            // panel_center
            // 
            this.panel_center.Controls.Add(this.tabControl_main);
            this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_center.Location = new System.Drawing.Point(0, 71);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(800, 357);
            this.panel_center.TabIndex = 2;
            // 
            // groupBox_date
            // 
            this.groupBox_date.Controls.Add(this.lbl_date);
            this.groupBox_date.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_date.Location = new System.Drawing.Point(0, 0);
            this.groupBox_date.Name = "groupBox_date";
            this.groupBox_date.Size = new System.Drawing.Size(800, 36);
            this.groupBox_date.TabIndex = 0;
            this.groupBox_date.TabStop = false;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_date.Location = new System.Drawing.Point(3, 17);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(41, 12);
            this.lbl_date.TabIndex = 0;
            this.lbl_date.Text = "label1";
            // 
            // groupBox_ChineseDate
            // 
            this.groupBox_ChineseDate.Controls.Add(this.lbl_chineseDate);
            this.groupBox_ChineseDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_ChineseDate.Location = new System.Drawing.Point(0, 33);
            this.groupBox_ChineseDate.Name = "groupBox_ChineseDate";
            this.groupBox_ChineseDate.Size = new System.Drawing.Size(800, 38);
            this.groupBox_ChineseDate.TabIndex = 1;
            this.groupBox_ChineseDate.TabStop = false;
            // 
            // lbl_chineseDate
            // 
            this.lbl_chineseDate.AutoSize = true;
            this.lbl_chineseDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_chineseDate.Location = new System.Drawing.Point(3, 17);
            this.lbl_chineseDate.Name = "lbl_chineseDate";
            this.lbl_chineseDate.Size = new System.Drawing.Size(41, 12);
            this.lbl_chineseDate.TabIndex = 0;
            this.lbl_chineseDate.Text = "label2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.statusStrip_main);
            this.Name = "frmMain";
            this.Text = "WinFormTools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_main.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_center.ResumeLayout(false);
            this.groupBox_date.ResumeLayout(false);
            this.groupBox_date.PerformLayout();
            this.groupBox_ChineseDate.ResumeLayout(false);
            this.groupBox_ChineseDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_center;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.GroupBox groupBox_ChineseDate;
        private System.Windows.Forms.Label lbl_chineseDate;
        private System.Windows.Forms.GroupBox groupBox_date;
        private System.Windows.Forms.Label lbl_date;
    }
}

