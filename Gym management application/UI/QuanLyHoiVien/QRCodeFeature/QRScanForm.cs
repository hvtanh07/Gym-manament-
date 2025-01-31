﻿using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using Gym_management_appication.Class;

namespace Gym_management_appication.UI.QuanLyHoiVien.QRCodeFeature {
    public partial class QRScanForm : Form {
        public QRScanForm() {
            InitializeComponent();
        }

        private Member Result = null;

        private MJPEGStream stream;

        private void btnConnect_Click(object sender, EventArgs e) {
            if (btnConnect.Text == "Connect") {
                stream = new MJPEGStream(tbURLDroidCam.Text);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
                timer1.Enabled = true;
                timer1.Start();
                btnConnect.Text = "Disconnect";
            }
            else {
                btnConnect.Text = "Connect";
                timer1.Stop();
                stream.Stop();
            }

        }
        public void stream_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            picCam.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Bitmap img = (Bitmap)picCam.Image;
            if (img != null) {
                ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode(img);
                try {
                    string decoded = result.ToString();

                    SearchMember(decoded);

                    img.Dispose();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message + "");
                }

            }
        }

        private void SearchMember(string id) {
            using (MainDataClassesDataContext db = new MainDataClassesDataContext()) {
                Member foundMember = db.Members.Where(item => item.ma.Equals(id)).FirstOrDefault();
                if (foundMember!=null) {
                    Result = foundMember;
                    timer1.Stop();
                    stream.Stop();
                    this.Close();
                }
            }
        }

        public Member ShowDialogWithReturnedMember() {
            this.ShowDialog();
            return Result;
        }

    }
}
