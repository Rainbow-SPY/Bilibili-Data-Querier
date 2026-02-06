namespace Bilibili_Data_Querier
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
            this.pageHeader1 = new AntdUI.PageHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.divider1 = new AntdUI.Divider();
            this.button2 = new AntdUI.Button();
            this.IInput = new AntdUI.Input();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dropdown1 = new AntdUI.Dropdown();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageHeader1
            // 
            this.pageHeader1.DividerShow = true;
            this.pageHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.Margin = new System.Windows.Forms.Padding(4);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(821, 32);
            this.pageHeader1.TabIndex = 32;
            this.pageHeader1.Text = "bilibili 公开摘要查询 - v1.0.0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 30);
            this.panel1.TabIndex = 33;
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.Location = new System.Drawing.Point(0, 90);
            this.divider1.Name = "divider1";
            this.divider1.OrientationMargin = 0F;
            this.divider1.Size = new System.Drawing.Size(821, 23);
            this.divider1.TabIndex = 35;
            this.divider1.Text = "";
            this.divider1.Thickness = 1F;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(537, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 31);
            this.button2.TabIndex = 33;
            this.button2.Text = "button1";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IInput
            // 
            this.IInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IInput.Location = new System.Drawing.Point(240, 3);
            this.IInput.Name = "IInput";
            this.IInput.PlaceholderText = "键入文本";
            this.IInput.Size = new System.Drawing.Size(291, 38);
            this.IInput.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dropdown1);
            this.panel2.Controls.Add(this.IInput);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 45);
            this.panel2.TabIndex = 33;
            // 
            // dropdown1
            // 
            this.dropdown1.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.dropdown1.DropDownArrow = true;
            this.dropdown1.DropDownTextAlign = AntdUI.TAlign.Bottom;
            this.dropdown1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dropdown1.IconPosition = AntdUI.TAlignMini.Right;
            this.dropdown1.IconRatio = 0.5F;
            this.dropdown1.IconSvg = "DownOutlined";
            this.dropdown1.Items.AddRange(new object[] {
            "用户UID",
            "直播间ID"});
            this.dropdown1.Location = new System.Drawing.Point(90, 5);
            this.dropdown1.Name = "dropdown1";
            this.dropdown1.Size = new System.Drawing.Size(144, 36);
            this.dropdown1.TabIndex = 36;
            this.dropdown1.Text = "下拉选择查询的选项";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.pageHeader1);
            this.MinimumSize = new System.Drawing.Size(821, 480);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        private AntdUI.PageHeader pageHeader1;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AntdUI.Divider divider1;
        private AntdUI.Button button2;
        private AntdUI.Input IInput;
        private System.Windows.Forms.Panel panel2;
        private AntdUI.Dropdown dropdown1;
    }
}

