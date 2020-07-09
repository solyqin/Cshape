using Flir.Atlas.Image;
using Flir.Atlas.Image.Isotherms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Flir.Atlas2._0;

namespace Flir.Atlas2._0
{
    public partial class MainForm : Form
    {
        private string[] IsoImageFile;
        private ThermalImageFile th;  // 热成像图片文件对象
        bool blnDrawing = false;  // 绘制矩形框标志
        bool bl_Image_Load = false;  // 判断picturebox是否加载了红外图片

        int index = 0; //默认当前图片下标
        int ImageCount = 0; //打开图片总数
        int MinItems = 6; //定义最小显示item数（在界面设计的时候决定的）
        Point Ptstart; //画框的起始点
        Point Ptend;//画框的结束点
        Rectangle rect;  //矩形框

        List<oneRect> Rect_list ;
        List<oneRect> Temp_Rect_list = new List<oneRect>();

        public struct oneRect
        {
            public Rectangle _rectangle;
            public int _index;
            public Point pt_max;
            public Point pt_min;
        }
        // 判断输入的是否为数字
        private bool IsNumber(string str)
        {
            
            Regex reg = new Regex("^[-]*[0-9]+$"); //正则表达式
            Match ma = reg.Match(str);

            if (ma.Success && reg.IsMatch(str))
                return true;
            else
                return false;
        }

        //图片信息
        private void PictureInfo(ThermalImageFile th)
        {
            CameraInformation camera = th.CameraInformation; 
             string info =
                "  标题: " + th.Title + "\r\n" +
                "  标题: " + th.Statistics.HotSpot.ToString() + "\r\n" +
                "  宽度: " + th.Size.Width.ToString() + "\r\n" +
                "  高度: " + th.Size.Height.ToString() + "\r\n" + "\r\n" +
                "  拍摄日期: " + th.DateTaken.TimeOfDay.ToString() + "\r\n" +
                "  拍摄时间: " + th.DateTaken.Date.Year.ToString() + "/" + th.DateTaken.Date.Month.ToString() + "/" + th.DateTaken.Date.Day.ToString() + "\r\n" + "\r\n" +
                "  最高温度: " + Math.Round(th.Statistics.Max.Value, 2).ToString() + "  " + th.Statistics.Max.State.ToString() + "\r\n" +
                "  最低温度: " + Math.Round(th.Statistics.Min.Value, 2).ToString() + "  " + th.Statistics.Min.State.ToString() + "\r\n" + "\r\n" +
                "  相机序列号: " + camera.SerialNumber;
            lb_picture_info.Text = info;
        }

        private void Enabled_Control(bool bl)
        {
            cb_FocusArea.Enabled = bl;   //框选焦点区域
            lb_temperature.Enabled = bl; //温度
            lb_X.Enabled = bl;           //X轴
            lb_Y.Enabled = bl;           //Y轴
            

            bl_Image_Load = bl;          //图片加载标志

            if (!bl && cb_FocusArea.Checked) //出现需要关闭控件使能时
                cb_FocusArea.Checked = false; //取消 框选焦点区域 选择

            if (!bl)
            {
                ResetInfoShow();
            }

            tb_rang_min.Enabled = bl; //等温线范围区间 最大值
            tb_rang_max.Enabled = bl;//等温线范围区间 最小值
            tb_limit_min.Enabled = bl; //等温线下限最小值(小于这个值的点着色）
            tb_limit_max.Enabled = bl; //等温线上限最大值(大于这个值的点着色）
            btn_setIsoInterval.Enabled = bl;
            btn_setIsoAbove.Enabled = bl;
            btn_setIsoBelow.Enabled = bl;
            btn_clearIsotherms.Enabled = bl; //清空等温线
        }

        private void ResetInfoShow()
        {
            // 重置实时数据面板
            lb_X.Text = "0";
            lb_Y.Text = "0";
            lb_temperature.Text = "0℃";
            lb_state.Text = "off";
           
            //重置图片信息面板
            lb_picture_info.ResetText();
        }

        private void ShowThermalImage(string path)
        {
            try
            {
                th = new ThermalImageFile(path);   //打开热成像图片文件  
                this.pictureBox1.Image = th.Image;
                bl_Image_Load = true;  //成功加载红外图

                ResetInfoShow(); // 重置显示的信息
                PictureInfo(th);//界面右下角显示相关信息
                //ShowPictureInfo(th);

                // 打开控件使能
                Enabled_Control(true);
               

            }
            catch( Exception ee)
            {
                bl_Image_Load = false;
                this.pictureBox1.Image = null;
                Enabled_Control(false);
                //Console.WriteLine("打开热图片失败");
                MessageBox.Show("打开热图片失败:"+ ee);
            }
        }

        private void InitListView(string[] str)
        {
            //加载list view上的图片列表g
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    imageList1.Images.Add(Image.FromFile(str[i]));

                    //找到最后一个"\"的位置，从它的后一位开始截取
                    //string name = str[i].Substring(str[i].LastIndexOf(@"\") );
                  
                    this.listView1.Items.Add(Path.GetFileNameWithoutExtension(str[i]), i);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("缩略图加载失败：" + ee);
            }
        }

        //设置缩略图选中图片
        private void SetListViewFouceItem(int n)
        {
            listView1.Items[n].Selected = true;
            listView1.Items[n].Focused = true;
            listView1.Items[n].EnsureVisible(); //确保控件可见
        }

        //清空等温线
        private void ClearIsotherms()
        {
            if (th.Isotherms.Count > 0)
            {
                th.Isotherms.Clear(); //清除所有等温线。
                pictureBox1.Image = th.Image; //重新显示图片
                // pictureBox1.Invalidate();
                pictureBox1.Refresh();
            }
        }

        //按比例转换坐标点
        public Point ConversionXY(Point pp)
        {
            int x = (int)Math.Round(Convert.ToDouble(pp.X * pictureBox1.Image.Width / pictureBox1.Width), 0);
            int y = (int)Math.Round(Convert.ToDouble(pp.Y * pictureBox1.Image.Height / pictureBox1.Height), 0); ;

            Point point = new Point(x, y);
            return point;
        }

        public Point GetMaxPointInRectangle(double[] arr,Rectangle rect)
        {
            //获取框选区域温度最高点的坐标
            int index = Array.IndexOf(arr, arr.Max());
            int x = rect.Location.X + index % rect.Width;
            int y = rect.Location.Y + index / rect.Width;
            //Console.WriteLine(arr.Max().ToString()+" MaxPoint:({0},{1}),  index:{2}, location:({3},{4})", x, y, index, rect.Location.X, rect.Location.Y);
            return new Point(x,y);
        }
        public Point GetMinPointInRectangle(double[] arr, Rectangle rect)
        {
            //获取框选区域温度最高点的坐标
            int index = Array.IndexOf(arr, arr.Min());
            int x = rect.Location.X + index % rect.Width;
            int y = rect.Location.Y + index / rect.Width;
            //Console.WriteLine(arr.Min().ToString() + "  MaxPoint:({0},{1}),  index:{2}, location:({3},{4})", x, y, index, rect.Location.X, rect.Location.Y);
            return new Point(x, y);
        }

        //随着框选数据增加，调整右边显示内容，保证完全显示框选数据，不显示滑动条
        public void AdjustPanel_info(bool bl_increase)
        {
            int offset = 17;
            if (!bl_increase)
                offset = -17;

            groupBox1.Height += offset;
            lv_rectinfo.Height += offset;
            foreach (Control ctrl in panel_info.Controls)
            {
                if (ctrl.Name == "groupBox3"|| ctrl.Name == "groupBox4")
                {
                    Control control = ctrl;
                    control.Location = new Point(control.Location.X, control.Location.Y + offset);
                }
            }
        }
        public enum Dire
        {
            UP,
            DOWN
        }
        
        // 填充三角形       point 三角尖
        private void FillTriangle_1(Graphics g, Point point, Dire dire)
        {
            int dev = 8;
            Point cornerleft;
            Point cornerright;
           
            switch (dire)
            {
                case Dire.UP:
                    cornerleft = new Point(point.X - dev/2, point.Y-dev);
                    cornerright = new Point(point.X + dev / 2, point.Y - dev);
                    Point[] pntArr = { point, cornerleft, cornerright };
                    g.FillPolygon(Brushes.Red, pntArr);
                    break;
                case Dire.DOWN:
                     cornerleft = new Point(point.X - dev / 2, point.Y + dev);
                     cornerright = new Point(point.X + dev / 2, point.Y + dev);
                    Point[] pntArr1 = { point, cornerleft, cornerright };
                    g.FillPolygon(Brushes.Blue, pntArr1);
                    break;
                default:
                    break;
            }
        }

        //--------------------------------------------------------------------//
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //listView1.SmallImageList = imageList1;
            listView1.LargeImageList = imageList1;
            listView1.StateImageList = imageList1;

            lb_curtime.Text = DateTime.Now.ToString(); //显示当前时间，避免定时器第一秒不刷新
            timer1.Enabled = true;//打开定时器，用于刷新时间
            //关闭控件使能
            Enabled_Control(false);

            //实例化矩形框列表
            Rect_list = new List<oneRect>();

            label10.Text = "pictureBox1: "+ pictureBox1.Width + " " + pictureBox1.Height;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (th != null)
                {
                    th.Close(); //关闭文件流
                    th.Dispose();
                    th = null;
                }
                Console.WriteLine("index: " + this.listView1.SelectedItems[0].Index.ToString());
                Console.WriteLine("path: " + this.IsoImageFile[this.listView1.SelectedItems[0].Index].ToString());
                ShowThermalImage(this.IsoImageFile[this.listView1.SelectedItems[0].Index]);
                //更新当前选中图片的index
                index = this.listView1.SelectedItems[0].Index;

                lb_count.Text = index + 1 + @"/" + ImageCount; // 显示当前index
               
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cb_FocusArea.Checked == true)
            {
                Ptstart = e.Location;
                Invalidate();
                blnDrawing = true;//绘制中
            }
        }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (cb_FocusArea.Checked == true)
            {
                Ptend = e.Location;
                blnDrawing = false; //结束绘制

                if (rect.Width > 0 && rect.Height > 0)
                {
                    //Rectangle rectangle = new Rectangle(new Point(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y)),
                    //    new Size(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y)));

                    lb_state.Text = "off";  //框选区域没有状态显示

                    oneRect oneRect = new oneRect();
                    oneRect._rectangle = rect;           //矩形框(记录的时未转化坐标的框)
                    oneRect._index = Rect_list.Count + 1;//框的序号

                    //因为打开的图片可能和图片容器大小不一致，按比例转换实时坐标,
                    //按比例转换为了对应上源图片上的点
                    Ptstart = ConversionXY(Ptstart);
                    Ptend = ConversionXY(Ptend);
                   
                    //转换坐标后矩形框的位置和大小
                    rect.Location = new Point(
                    Math.Min(Ptstart.X,Ptend.X),
                    Math.Min(Ptstart.Y, Ptend.Y));
                    rect.Size = new Size(
                    Math.Abs(Ptstart.X - Ptend.X),
                    Math.Abs(Ptstart.Y - Ptend.Y));

                    //获取矩形范围内温度
                    double[] tempertureRect = th.GetValues(rect); //Math.Round(d, 2).ToString()
                    oneRect.pt_max = GetMaxPointInRectangle(tempertureRect, oneRect._rectangle);//获取高温点
                    oneRect.pt_min = GetMinPointInRectangle(tempertureRect, oneRect._rectangle);//获取高温点
                    Rect_list.Add(oneRect); //添加到矩形框列表里

                    //填充到数据表
                    ListViewItem item = new ListViewItem();//新建一条item
                    double tempertureRectAvg = Math.Round((tempertureRect.Sum() / tempertureRect.Length), 1);
                    double tempertureRectMax = Math.Round((tempertureRect.Max()), 1);
                    double tempertureRectMin = Math.Round((tempertureRect.Min()), 1);
                    item.Text = Rect_list.Last()._index.ToString(); //序号
                    item.SubItems.Add(tempertureRectAvg.ToString());//平均
                    item.SubItems.Add(tempertureRectMax.ToString());//最高
                    item.SubItems.Add(tempertureRectMin.ToString());//最低
                    lv_rectinfo.Items.Add(item);  //数据表追加记录

                    //适应性调整右边面板布局（向下移动）
                    if ( lv_rectinfo.Items.Count > MinItems)
                        AdjustPanel_info(true); 
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bl_Image_Load)
            {
                //获取温度
                //因为打开的图片可能和图片容器大小不一致，按比例转换为红外图片上对应坐标
                label11.Text = e.X+","+ e.Y;

                Point point = ConversionXY(e.Location);

                //显示坐标
                lb_X.Text = point.X.ToString();
                lb_Y.Text = point.Y.ToString();

                ThermalValue pointvalut = th.GetValueAt(point);

                if (!cb_FocusArea.Checked )
                {
                    //根据鼠标移动坐标获取温度和状态
                    lb_temperature.Text = Math.Round(pointvalut.Value, 2).ToString() + " ℃";  //
                    lb_state.Text = pointvalut.State.ToString();
                }

                //矩形框
                if (blnDrawing && cb_FocusArea.Checked)
                {
                    if (e.Button != MouseButtons.Left)//判断是否按下左键
                        return;
                    Point tempEndPoint = e.Location;

                    //框的位置和大小
                    rect.Location = new Point(
                    Math.Min(Ptstart.X, tempEndPoint.X),
                    Math.Min(Ptstart.Y, tempEndPoint.Y));
                    rect.Size = new Size(
                    Math.Abs(Ptstart.X - tempEndPoint.X),
                    Math.Abs(Ptstart.Y - tempEndPoint.Y));
                    pictureBox1.Invalidate();

                    if (rect.Width > 10 && rect.Height > 10)
                    {
                        oneRect oneRect = new oneRect
                        {
                            _rectangle = rect,
                            _index = Rect_list.Count + 1,//框的序号
                            pt_max = GetMaxPointInRectangle(th.GetValues(rect), rect),
                            pt_min = GetMinPointInRectangle(th.GetValues(rect), rect)

                        };
                        Temp_Rect_list.Add(oneRect);
                    }
                }
            }
        }
       
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (bl_Image_Load)
            {
                //Brushes DimGray = new Brushes(Color.Green);
                SolidBrush GreenBrush = new SolidBrush(Color.Green);
                if (blnDrawing) 
                {
                    if (rect != null && rect.Width > 0 && rect.Height > 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Red, 1), rect);//重新绘制颜色为红色
                        e.Graphics.DrawString((Rect_list.Count+1).ToString(), new Font("宋体", 10, FontStyle.Bold), GreenBrush, rect.Location); //Brushes.DimGray 框序号
                    }
                }

                //实时标注框选区域内温度点的位置
                if (Temp_Rect_list.Count > 0)
                {
                    FillTriangle_1(e.Graphics, Temp_Rect_list.Last().pt_max, Dire.UP);
                    FillTriangle_1(e.Graphics, Temp_Rect_list.Last().pt_min, Dire.DOWN);
                    Temp_Rect_list.Clear();
                }
               
                //将之前绘制的矩形框再次绘制一遍
                foreach (oneRect rec in Rect_list)
                {
                    FillTriangle_1(e.Graphics, rec.pt_max, Dire.UP);
                    FillTriangle_1(e.Graphics, rec.pt_min, Dire.DOWN);
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 1), rec._rectangle);//重新绘制颜色为红色
                    e.Graphics.DrawString(rec._index.ToString(), new Font("宋体", 10, FontStyle.Bold), GreenBrush, rec._rectangle.Location); //Brushes.DimGray 框序号
                }
            }
        }
        
        private void btn_setIsoInterval_Click(object sender, EventArgs e)
        {
            string str_min = tb_rang_min.Text;
            string str_max = tb_rang_max.Text;
            //判空，输入内容是否合法
            if (!string.IsNullOrEmpty(str_min) && IsNumber(str_min) &&
                 !string.IsNullOrEmpty(str_max) && IsNumber(str_max))
            {
                th.Isotherms.Clear(); //清除所有等温线。
                int.TryParse(tb_rang_min.Text, out int min);
                int.TryParse(tb_rang_max.Text, out int max);
                IsothermInterval isothermInterval = th.Isotherms.AddInterval();
                isothermInterval.Color = Color.Green;
                isothermInterval.Interval = new Range<double>(min, max);
                pictureBox1.Image = th.Image;
            }
        }

        private void btn_SetIsoAbove_Click(object sender, EventArgs e)
        {
            string str_limit = tb_limit_min.Text;
            if (!string.IsNullOrEmpty(str_limit) && IsNumber(str_limit))
            {
                th.Isotherms.Clear(); //清除所有等温线。
                int.TryParse(str_limit, out int limit_max);
                IsothermAbove isothermAbove = th.Isotherms.AddAbove();

                isothermAbove.Threshold = limit_max;
                th.Isotherms[0].Color = Color.Blue;
                pictureBox1.Image = null;
                pictureBox1.Image = th.Image;
                pictureBox1.Invalidate();
            }
        }

        private void btn_setIsoBelow_Click(object sender, EventArgs e)
        {
            string str_limit = tb_limit_max.Text;
            if (!string.IsNullOrEmpty(str_limit) && IsNumber(str_limit))
            {
                th.Isotherms.Clear(); //清除所有等温线。
                int.TryParse(str_limit, out int limit_min);
                IsothermBelow isothermBelow = th.Isotherms.AddBelow();
                isothermBelow.Threshold = limit_min;
                //isothermAbove.Color = Color.Blue;
                th.Isotherms[0].Color = Color.Blue;
                pictureBox1.Image = th.Image;
            }
        }

        private void cb_FocusArea_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_FocusArea.Checked)
            {
                lb_temperature.Text = "0 ℃";
            }
            else
            {
                int count = lv_rectinfo.Items.Count - MinItems;
                while ( count-- > 0)
                {
                    AdjustPanel_info(false);
                }
                Rect_list.Clear();//清空保存画过的矩形框
                lv_rectinfo.Items.Clear();//清空数据表

                pictureBox1.Invalidate();    //重绘窗口

                lb_temperature.Text = "0 ℃";
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            index -= 1;
            if (index < 0)
            {
                index = ImageCount - 1;
            }
            lb_count.Text = index + 1 + @"/" + ImageCount; // 显示当前index
            tb_path.Text = IsoImageFile[index]; // 文件路径(默认0，从第一张开始显示)

            //设置缩略图选中图片
            SetListViewFouceItem(index);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            index += 1;
            if (index >= ImageCount)
            {
                index = 0;
            }
            lb_count.Text = index + 1 + @"/" + ImageCount; // 显示当前index
            tb_path.Text = IsoImageFile[index]; // 文件路径(默认0，从第一张开始显示)

            //设置缩略图选中图片
            SetListViewFouceItem(index);
           
        }
        
        private void btn_clearIsotherms_Click(object sender, EventArgs e)
        {
            ClearIsotherms();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
           
        }

        //更新主线程上的进度条
        void UpdataProgressBar(int num,int count)
        {
            this.Invoke(new MethodInvoker(delegate () {
                if (count > 0 )
                {
                    progressBar1.Maximum = 100;
                }
                if (num > 0)
                {
                    double percent = Convert.ToDouble(num) / Convert.ToDouble(count);
                   
                    progressBar1.Value = Convert.ToInt16(Math.Round(percent, 2) * 100); //Math.Round按照四舍五入的国际标准 percent * 100;

                    lb_baifenbi.Text = progressBar1.Value.ToString() + "%";
                }
            }));
        }

        private void IO_Thread(string output_Path)
        {
            string str_image_path;  //图片路径
            List<string> lst_error_image_path; // 图片打开失败列表

            //清空out导出文件夹里的文件
            Clear_Directors(output_Path);
            //bl_check:检查上传文件是否含有非热成像图片
            lst_error_image_path = Checkpicture(IsoImageFile, out bool bl_check);

            if (bl_check)
            {
                for (int n = 0; n < IsoImageFile.Length; n++)
                {
                    str_image_path = IsoImageFile[n];

                    try
                    {
                        ThermalImageFile tif = new ThermalImageFile(str_image_path);   //打开热成像图片文件 

                        string sw_path = output_Path + @"\" + tif.Title + ".csv"; //以图片名命名csv文件
                        StreamWriter sww = new StreamWriter(sw_path, false, Encoding.Unicode);

                        //写入温度值
                        for (int i = 0; i < tif.Size.Width; i++)
                        {
                            for (int k = 0; k < tif.Size.Height; k++)
                            {
                                Point point = new Point(i, k);

                                // 获取温度点的温度值
                                ThermalValue pointvalut = th.GetValueAt(point);
                                double pointtemp = Math.Round(pointvalut.Value, 2); //温度，保留两位小数

                                sww.Write(pointtemp.ToString() + "\t");
                            }
                            sww.Write("\n");
                        }
                        sww.Close(); //关闭数据流

                        tif.Close();//关闭文件流
                        tif.Dispose();//释放使用资源

                        UpdataProgressBar(n+1, IsoImageFile.Length); //更新进度条
                    }
                    catch (ThreadAbortException e)
                    {
                        Console.WriteLine("Thread Abort Exception: " + e);
                        //error_image_path = error_image_path + ";" + tif.Title;
                    }
                }
                //导出完成后隐藏进度条
                DialogResult dr = MessageBox.Show("temprature info write success!", "完成!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Invoke(new MethodInvoker(delegate () {
                        lb_baifenbi.Visible = false;//隐藏百分比
                        progressBar1.Visible = false;//隐藏进度条
                    }));
                }
            }
            else
            {
                //输出非热成像图片名
                string op_false_name = "";
                foreach (string item in lst_error_image_path)
                {
                    op_false_name = op_false_name + item + "\r\n";
                }
                MessageBox.Show(op_false_name + "为非热成像图片!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //检查图片是否为红外图
        List<string> Checkpicture(string[] list, out bool flag)
        {
            flag = true;
            List<string> Opentfalselist = new List<string>();
            string[] str_filename ;
            for (int n = 0; n < list.Length; n++)
            {
                string check_path = list[n];

                try
                {
                    ThermalImageFile tif = new ThermalImageFile(check_path);   //打开热成像图片文件 
                    tif.Close();
                    tif.Dispose();
                }
                catch
                {
                    flag = false;
                    str_filename = check_path.Split('\\');
                    Opentfalselist.Add(str_filename[str_filename.Length - 1]);
                }
               
            }
            return Opentfalselist;
        }

        //删除路径下文件
        public void Clear_Directors(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    //获取该路径下的文件,子目录路径             
                    string[] directorsList = System.IO.Directory.GetFileSystemEntries(path);
                    foreach (string directory in directorsList)
                    {
                        if (System.IO.File.Exists(directory))
                            File.Delete(directory); //Directory.Delete(directory, true);

                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show("清除文件夹异常！" + ee);
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            lb_X.Text = "0";
            lb_Y.Text = "0";
            lb_temperature.Text = "0℃";
            lb_state.Text = "off"; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_curtime.Text = DateTime.Now.ToString();
        }

        private void MItem_browse_Click(object sender, EventArgs e) //MItem_browse
        {
            //打开文件
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要打开的文件";
            ofd.InitialDirectory = @"C:\Users\Administrator\Desktop";
            ofd.Filter = "图片文件|*.jpg|视频文件|*.avi|所有文件|*.*"; //  文本文件|*.txt|
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                index = 0;
                this.listView1.Clear();
                this.imageList1.Images.Clear();

                if (th != null)
                {
                    th.Close();
                    th.Dispose();
                    th = null;
                }

                IsoImageFile = ofd.FileNames; //获取文件名数组
                ImageCount = IsoImageFile.Length; //获取文件名总数

                btn_prev.Enabled = true;
                btn_next.Enabled = true;
                    
                //加载缩略图
                InitListView(IsoImageFile);
                //默认显示第一张图
                ShowThermalImage(IsoImageFile[index]);

                lb_count.Text = index + 1 + @"/" + ImageCount; // 显示当前index
                tb_path.Text = IsoImageFile[index]; // 文件路径(默认0，从第一张开始显示)
            }
        }

        private void MItem_export_Click(object sender, EventArgs e)
        {
            if (bl_Image_Load)
            {
                lb_baifenbi.Visible = true;//显示百分比
                progressBar1.Visible = true;//显示进度条

                Function function = new Function();
                string output_Path = function.GetOutPutPath();//创建输出文件夹 默认 D:\Atlas_OutPut
                
                Thread thread = new Thread(() => IO_Thread(output_Path));  //新建一个线程
                thread.Start(); //开始线程
                                //thread.Abort(); // 结束线程
            }
            else
                MessageBox.Show("请先打开红外图像！");
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Rect_list.Count > 0)
            {
                Rect_list.RemoveAt(Rect_list.Count-1);//框列表删除最后一条记录
                pictureBox1.Refresh();                //刷新显示

                lv_rectinfo.Items.RemoveAt(lv_rectinfo.Items.Count-1);//删除框选信息列表最后一条记录
            }
            if (lv_rectinfo.Items.Count >= MinItems)
                AdjustPanel_info(false); //适应性调整面板布局
        }

        private void lv_rectinfo_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = this.lv_rectinfo.Columns[e.ColumnIndex].Width;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
           
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
