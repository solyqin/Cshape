﻿namespace Flir.Atlas2._0
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_FocusArea = new System.Windows.Forms.CheckBox();
            this.btn_setIsoInterval = new System.Windows.Forms.Button();
            this.tb_rang_max = new System.Windows.Forms.TextBox();
            this.tb_rang_min = new System.Windows.Forms.TextBox();
            this.tb_limit_min = new System.Windows.Forms.TextBox();
            this.btn_setIsoAbove = new System.Windows.Forms.Button();
            this.btn_setIsoBelow = new System.Windows.Forms.Button();
            this.tb_limit_max = new System.Windows.Forms.TextBox();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.lb_count = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_X = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_Y = new System.Windows.Forms.Label();
            this.lb_wendu = new System.Windows.Forms.Label();
            this.lb_temperature = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.lb_picture_info = new System.Windows.Forms.Label();
            this.btn_clearIsotherms = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_baifenbi = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_curtime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_rect_max = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_rect_min = new System.Windows.Forms.Label();
            this.MItem_browse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MItem_export = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上海测和电子科技ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_rect_avg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 61);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(217, 641);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 80);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(239, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(765, 537);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // cb_FocusArea
            // 
            this.cb_FocusArea.AutoSize = true;
            this.cb_FocusArea.Location = new System.Drawing.Point(21, 25);
            this.cb_FocusArea.Name = "cb_FocusArea";
            this.cb_FocusArea.Size = new System.Drawing.Size(142, 22);
            this.cb_FocusArea.TabIndex = 3;
            this.cb_FocusArea.Text = "框选焦点区域";
            this.cb_FocusArea.UseVisualStyleBackColor = true;
            this.cb_FocusArea.CheckedChanged += new System.EventHandler(this.cb_FocusArea_CheckedChanged);
            // 
            // btn_setIsoInterval
            // 
            this.btn_setIsoInterval.Location = new System.Drawing.Point(187, 50);
            this.btn_setIsoInterval.Name = "btn_setIsoInterval";
            this.btn_setIsoInterval.Size = new System.Drawing.Size(94, 38);
            this.btn_setIsoInterval.TabIndex = 4;
            this.btn_setIsoInterval.Text = "设置";
            this.btn_setIsoInterval.UseVisualStyleBackColor = true;
            this.btn_setIsoInterval.Click += new System.EventHandler(this.btn_setIsoInterval_Click);
            // 
            // tb_rang_max
            // 
            this.tb_rang_max.Location = new System.Drawing.Point(132, 50);
            this.tb_rang_max.Name = "tb_rang_max";
            this.tb_rang_max.Size = new System.Drawing.Size(49, 28);
            this.tb_rang_max.TabIndex = 5;
            // 
            // tb_rang_min
            // 
            this.tb_rang_min.Location = new System.Drawing.Point(73, 50);
            this.tb_rang_min.Name = "tb_rang_min";
            this.tb_rang_min.Size = new System.Drawing.Size(52, 28);
            this.tb_rang_min.TabIndex = 6;
            // 
            // tb_limit_min
            // 
            this.tb_limit_min.Location = new System.Drawing.Point(132, 91);
            this.tb_limit_min.Name = "tb_limit_min";
            this.tb_limit_min.Size = new System.Drawing.Size(49, 28);
            this.tb_limit_min.TabIndex = 7;
            // 
            // btn_setIsoAbove
            // 
            this.btn_setIsoAbove.Location = new System.Drawing.Point(187, 91);
            this.btn_setIsoAbove.Name = "btn_setIsoAbove";
            this.btn_setIsoAbove.Size = new System.Drawing.Size(94, 33);
            this.btn_setIsoAbove.TabIndex = 8;
            this.btn_setIsoAbove.Text = "设置";
            this.btn_setIsoAbove.UseVisualStyleBackColor = true;
            this.btn_setIsoAbove.Click += new System.EventHandler(this.btn_SetIsoAbove_Click);
            // 
            // btn_setIsoBelow
            // 
            this.btn_setIsoBelow.Location = new System.Drawing.Point(187, 130);
            this.btn_setIsoBelow.Name = "btn_setIsoBelow";
            this.btn_setIsoBelow.Size = new System.Drawing.Size(94, 31);
            this.btn_setIsoBelow.TabIndex = 9;
            this.btn_setIsoBelow.Text = "设置";
            this.btn_setIsoBelow.UseVisualStyleBackColor = true;
            this.btn_setIsoBelow.Click += new System.EventHandler(this.btn_setIsoBelow_Click);
            // 
            // tb_limit_max
            // 
            this.tb_limit_max.Location = new System.Drawing.Point(132, 125);
            this.tb_limit_max.Name = "tb_limit_max";
            this.tb_limit_max.Size = new System.Drawing.Size(49, 28);
            this.tb_limit_max.TabIndex = 10;
            // 
            // btn_prev
            // 
            this.btn_prev.Enabled = false;
            this.btn_prev.Location = new System.Drawing.Point(762, 129);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(79, 30);
            this.btn_prev.TabIndex = 13;
            this.btn_prev.Text = "上一张";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_next
            // 
            this.btn_next.Enabled = false;
            this.btn_next.Location = new System.Drawing.Point(870, 129);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(79, 30);
            this.btn_next.TabIndex = 14;
            this.btn_next.Text = "下一张";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(962, 135);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(35, 18);
            this.lb_count.TabIndex = 15;
            this.lb_count.Text = "0/0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "区间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "下限阈值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "上限阈值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(547, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "X:";
            // 
            // lb_X
            // 
            this.lb_X.AutoSize = true;
            this.lb_X.Location = new System.Drawing.Point(548, 52);
            this.lb_X.Name = "lb_X";
            this.lb_X.Size = new System.Drawing.Size(17, 18);
            this.lb_X.TabIndex = 20;
            this.lb_X.Text = "0";
            this.lb_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(597, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Y:";
            // 
            // lb_Y
            // 
            this.lb_Y.AutoSize = true;
            this.lb_Y.Location = new System.Drawing.Point(598, 52);
            this.lb_Y.Name = "lb_Y";
            this.lb_Y.Size = new System.Drawing.Size(17, 18);
            this.lb_Y.TabIndex = 22;
            this.lb_Y.Text = "0";
            this.lb_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_wendu
            // 
            this.lb_wendu.AutoSize = true;
            this.lb_wendu.Location = new System.Drawing.Point(343, 22);
            this.lb_wendu.Name = "lb_wendu";
            this.lb_wendu.Size = new System.Drawing.Size(62, 18);
            this.lb_wendu.TabIndex = 23;
            this.lb_wendu.Text = "温度：";
            // 
            // lb_temperature
            // 
            this.lb_temperature.AutoSize = true;
            this.lb_temperature.Location = new System.Drawing.Point(343, 52);
            this.lb_temperature.Name = "lb_temperature";
            this.lb_temperature.Size = new System.Drawing.Size(35, 18);
            this.lb_temperature.TabIndex = 24;
            this.lb_temperature.Text = "0℃";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 25;
            this.label12.Text = "状态：";
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(110, 52);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(35, 18);
            this.lb_state.TabIndex = 26;
            this.lb_state.Text = "off";
            // 
            // tb_path
            // 
            this.tb_path.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_path.Location = new System.Drawing.Point(239, 129);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(505, 28);
            this.tb_path.TabIndex = 27;
            // 
            // lb_picture_info
            // 
            this.lb_picture_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_picture_info.Location = new System.Drawing.Point(6, 31);
            this.lb_picture_info.Name = "lb_picture_info";
            this.lb_picture_info.Size = new System.Drawing.Size(265, 275);
            this.lb_picture_info.TabIndex = 32;
            // 
            // btn_clearIsotherms
            // 
            this.btn_clearIsotherms.Enabled = false;
            this.btn_clearIsotherms.Location = new System.Drawing.Point(187, 12);
            this.btn_clearIsotherms.Name = "btn_clearIsotherms";
            this.btn_clearIsotherms.Size = new System.Drawing.Size(94, 32);
            this.btn_clearIsotherms.TabIndex = 33;
            this.btn_clearIsotherms.Text = "清空等温线";
            this.btn_clearIsotherms.UseVisualStyleBackColor = true;
            this.btn_clearIsotherms.Click += new System.EventHandler(this.btn_clearIsotherms_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(270, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 35;
            this.progressBar1.Visible = false;
            // 
            // lb_baifenbi
            // 
            this.lb_baifenbi.AutoSize = true;
            this.lb_baifenbi.Location = new System.Drawing.Point(382, 11);
            this.lb_baifenbi.Name = "lb_baifenbi";
            this.lb_baifenbi.Size = new System.Drawing.Size(26, 18);
            this.lb_baifenbi.TabIndex = 36;
            this.lb_baifenbi.Text = "0%";
            this.lb_baifenbi.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_curtime
            // 
            this.lb_curtime.AutoSize = true;
            this.lb_curtime.Location = new System.Drawing.Point(1043, 9);
            this.lb_curtime.Name = "lb_curtime";
            this.lb_curtime.Size = new System.Drawing.Size(44, 18);
            this.lb_curtime.TabIndex = 38;
            this.lb_curtime.Text = "time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "最高温度：";
            // 
            // lb_rect_max
            // 
            this.lb_rect_max.AutoSize = true;
            this.lb_rect_max.Location = new System.Drawing.Point(165, 52);
            this.lb_rect_max.Name = "lb_rect_max";
            this.lb_rect_max.Size = new System.Drawing.Size(44, 18);
            this.lb_rect_max.TabIndex = 40;
            this.lb_rect_max.Text = "0 ℃";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "最低温度：";
            // 
            // lb_rect_min
            // 
            this.lb_rect_min.AutoSize = true;
            this.lb_rect_min.Location = new System.Drawing.Point(165, 80);
            this.lb_rect_min.Name = "lb_rect_min";
            this.lb_rect_min.Size = new System.Drawing.Size(44, 18);
            this.lb_rect_min.TabIndex = 42;
            this.lb_rect_min.Text = "0 ℃";
            // 
            // MItem_browse
            // 
            this.MItem_browse.Name = "MItem_browse";
            this.MItem_browse.Size = new System.Drawing.Size(62, 28);
            this.MItem_browse.Text = "浏览";
            this.MItem_browse.Click += new System.EventHandler(this.MItem_browse_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MItem_browse,
            this.MItem_export,
            this.退出ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1322, 32);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MItem_export
            // 
            this.MItem_export.Name = "MItem_export";
            this.MItem_export.RightToLeftAutoMirrorImage = true;
            this.MItem_export.Size = new System.Drawing.Size(62, 28);
            this.MItem_export.Text = "导出";
            this.MItem_export.Click += new System.EventHandler(this.MItem_export_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click_1);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上海测和电子科技ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 上海测和电子科技ToolStripMenuItem
            // 
            this.上海测和电子科技ToolStripMenuItem.Name = "上海测和电子科技ToolStripMenuItem";
            this.上海测和电子科技ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.上海测和电子科技ToolStripMenuItem.Text = "上海测和电子科技";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_rect_avg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_rect_min);
            this.groupBox1.Controls.Add(this.cb_FocusArea);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lb_rect_max);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1016, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 144);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "框选";
            // 
            // lb_rect_avg
            // 
            this.lb_rect_avg.AutoSize = true;
            this.lb_rect_avg.Location = new System.Drawing.Point(165, 107);
            this.lb_rect_avg.Name = "lb_rect_avg";
            this.lb_rect_avg.Size = new System.Drawing.Size(44, 18);
            this.lb_rect_avg.TabIndex = 44;
            this.lb_rect_avg.Text = "0 ℃";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "平均温度：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_temperature);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lb_X);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lb_Y);
            this.groupBox2.Controls.Add(this.lb_wendu);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lb_state);
            this.groupBox2.Location = new System.Drawing.Point(239, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 76);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时数据";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_setIsoInterval);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btn_clearIsotherms);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tb_limit_max);
            this.groupBox3.Controls.Add(this.btn_setIsoBelow);
            this.groupBox3.Controls.Add(this.btn_setIsoAbove);
            this.groupBox3.Controls.Add(this.tb_limit_min);
            this.groupBox3.Controls.Add(this.tb_rang_min);
            this.groupBox3.Controls.Add(this.tb_rang_max);
            this.groupBox3.Location = new System.Drawing.Point(1016, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 168);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "等温线";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lb_picture_info);
            this.groupBox4.Location = new System.Drawing.Point(1010, 393);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(287, 309);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图片信息";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1322, 731);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_curtime);
            this.Controls.Add(this.lb_baifenbi);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flir.Atlas1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cb_FocusArea;
        private System.Windows.Forms.Button btn_setIsoInterval;
        private System.Windows.Forms.TextBox tb_rang_max;
        private System.Windows.Forms.TextBox tb_rang_min;
        private System.Windows.Forms.TextBox tb_limit_min;
        private System.Windows.Forms.Button btn_setIsoAbove;
        private System.Windows.Forms.Button btn_setIsoBelow;
        private System.Windows.Forms.TextBox tb_limit_max;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_X;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_Y;
        private System.Windows.Forms.Label lb_wendu;
        private System.Windows.Forms.Label lb_temperature;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Label lb_picture_info;
        private System.Windows.Forms.Button btn_clearIsotherms;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_baifenbi;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_curtime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_rect_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_rect_min;
        private System.Windows.Forms.ToolStripMenuItem MItem_browse;
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MItem_export;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_rect_avg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem 上海测和电子科技ToolStripMenuItem;
    }
}