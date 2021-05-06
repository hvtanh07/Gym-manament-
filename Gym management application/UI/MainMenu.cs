﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_management_appication.Database.QuanLyHoiVien;
using Gym_management_appication.UI;
using Gym_management_appication.UI.ThongKeHoiVien;

namespace Gym_management_appication.UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            GroupQuanLyHoiVien.Visible = false;
            //Add more Group of Form 
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }      

        #region QuanLyHoiVien
        private void btn_QuanLyHoiVien_Click(object sender, EventArgs e)
        {
            showSubMenu(GroupQuanLyHoiVien);
        }
        private void btn_Danhsach_Click(object sender, EventArgs e)
        {
            openChildForm(new DanhSachHoiVien());

            hideSubMenu();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new thongKeHoiVien());

            hideSubMenu();
        }

        #endregion
        private void btn_QuanLyNhanvien_Click(object sender, EventArgs e)
        {
            openChildForm(new DanhSachNhanVien());

            hideSubMenu();
        }
        private void btn_QuanLyThietbi_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyThietBi());

            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            container.Controls.Add(childForm);
            container.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       
    }
}