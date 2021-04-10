﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Gym_management_appication.Database;

namespace Gym_management_appication.UI.ThongKeHoiVien
{
    public partial class thongKeHoiVien : Form
    {
        public thongKeHoiVien()
        {
            InitializeComponent();
        }

        private void thongKeHoiVien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dt_fromDate.Value.AddMonths(1) >= dt_toDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải bé hơn ngày kết thúc 1 tháng!","Error!");
                return;
            }
            //if (dt_toDate.Value > DateTime.Today)
            //{
            //    MessageBox.Show("Ngày kết thúc không được lớn hơn hiện tại!", "Error!");
            //    return;
            //}
            if (cb_DataType.Text.Trim() == "")
            {
                MessageBox.Show("Chọn loại thống kê!", "Error!");
                return;
            }
            if (cb_ChartType.Text.Trim() == "")
            {
                MessageBox.Show("Chọn loại bảng!", "Error!");
                return;
            }
            switch (cb_DataType.Text)
            {
                case "Số lượng hội viên từng tháng":
                    numOfMemeachMonth();
                    break;
                case "Số lượng hội viên mới từng tháng":
                    numOfNewMemeachMonth();
                    break;
                case "Số lượng hội viên nghỉ từng tháng":
                    numOfResignMemeachMonth();
                    break;
            }
        }

        private void numOfMemeachMonth()
        {
            c_ThongKe.DataSource = null;
            hoiVien trangThietBi = new hoiVien();
            DataTable thietbiList = trangThietBi.getMemberofMonth(dt_fromDate.Value, dt_toDate.Value);
            c_ThongKe.DataSource = thietbiList;
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Nhóm";
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Tổng số lượng";

            c_ThongKe.Series["Số lượng"].XValueMember = "thang";
            c_ThongKe.Series["Số lượng"].YValueMembers = "total";
            c_ThongKe.Series["Số lượng"].Color = Color.Blue;
        }
        private void numOfNewMemeachMonth()
        {
            c_ThongKe.DataSource = null;
            //c_ThongKe.typ
            hoiVien trangThietBi = new hoiVien();
            DataTable thietbiList = trangThietBi.getNewMemberofMonth(dt_fromDate.Value, dt_toDate.Value);
            c_ThongKe.DataSource = thietbiList;
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Nhóm";
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Tổng số lượng";

            c_ThongKe.Series["Số lượng"].XValueMember = "thang";
            c_ThongKe.Series["Số lượng"].YValueMembers = "total";
            c_ThongKe.Series["Số lượng"].Color = Color.Green;
        }
        private void numOfResignMemeachMonth()
        {
            c_ThongKe.DataSource = null;
            //c_ThongKe.typ
            hoiVien trangThietBi = new hoiVien();
            DataTable thietbiList = trangThietBi.getResignMemberofMonth(dt_fromDate.Value, dt_toDate.Value);
            c_ThongKe.DataSource = thietbiList;
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Nhóm";
            c_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Tổng số lượng";

            c_ThongKe.Series["Số lượng"].XValueMember = "thang";
            c_ThongKe.Series["Số lượng"].YValueMembers = "total";
            c_ThongKe.Series["Số lượng"].Color = Color.Red;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_ThongKe.DataSource = null;
        }   

        private void cb_ChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChartType.Text == "Line")
                c_ThongKe.Series["Số lượng"].ChartType = SeriesChartType.Line;
            else if (cb_ChartType.Text == "Column")
                c_ThongKe.Series["Số lượng"].ChartType = SeriesChartType.Column;
        }
    }
}
