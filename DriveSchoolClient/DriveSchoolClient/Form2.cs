using DriveSchoolClient.Model.Request;
using DriveSchoolClient.Model.Response;
using Microsoft.VisualBasic;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSchoolClient
{
    public partial class Form2 : Form
    {
        private readonly string _url = "https://drive-school-api.test-api-system-prod.com";
        public Form2()
        {
            InitializeComponent();
        }

        private async void button_FingerRead_Click(object sender, EventArgs e)
        {

            var ssid =  Interaction.InputBox("โปรดกรอกรหัสประจำตัวบุคคน", "โปรดกรอกรหัสประจำตัวบุคคน", "");


            label_status.Visible = true;
            var client = new RestClient("http://localhost:22001");
            var request = new RestRequest($"zkbioonline/fingerprint/beginCapture?type=2&FakeFunOn=1");

            var res = await client.ExecuteGetAsync(request);

            if (!res.IsSuccessful)
            {
                MessageBox.Show("โปรดลง Driver เครื่อง แสกนนิ้ว", "ผิดพลาด");
                await cancle_Finger();
                return;
            }

            await Task.Delay(1000);

            client = new RestClient("http://localhost:22001");
            request = new RestRequest($"zkbioonline/fingerprint/getTemplate");

            for (int i = 0; i < 20; i++)
            {
                res = await client.ExecuteGetAsync(request);

                if (res.IsSuccessful && res.Content.Contains("biotype"))
                {
                    var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                    var template = baseResponse.GetData<GetTemplateResponse>();

                    if (template != null)
                    {
                        label_template.Text = template.template;
                    }

                    break;
                }
                await Task.Delay(1000);
            }

            if (!res.IsSuccessful)
            {
                MessageBox.Show("โปรดลง Driver เครื่อง แสกนนิ้ว", "ผิดพลาด");
                await cancle_Finger();
                return;
            }

            if (res.Content.Contains("please press finger"))
            {
                MessageBox.Show("โปรดกดปุ่มแสกนนิ้วและรีบวางนิ้วมือลงไปขึ้นลง 3 ครั้ง", "ผิดพลาด");
                await cancle_Finger();
                return;
            }

            await Task.Delay(1000);

            int count = 0;
            request = new RestRequest($"zkbioonline/fingerprint/getImage");

            for (int i = 0; i < 20; i++)
            {

                res = await client.ExecuteGetAsync(request);

                if (res.IsSuccessful && res.Content.Contains("biotype"))
                {

                    break;
                }
            }

            if (res.Content.Contains("please press finger"))
            {
                MessageBox.Show("โปรดกดปุ่มแสกนนิ้วและรีบวางนิ้วมือลงไปขึ้นลง 3 ครั้ง", "ผิดพลาด");
                await cancle_Finger();
                return;
            }
            else
            {
                var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                var finger = baseResponse.GetData<FingerClass>();
                textBox_BioType.Text = finger.biotype.ToString();
                textBox_EnrollIndex.Text = finger.enroll_index.ToString();
                textBox_Qulity.Text = finger.quality.ToString();
                textBox_Height.Text = finger.height.ToString();
                textBox_Witdth.Text = finger.witdth.ToString();
                label_finger.Text = finger.jpg_base64;
                textBox_ssidRead.Text = ssid;
                var bitMap = Base64StringToBitmap(finger.jpg_base64);
                Size size = new Size(300, 300);

                pictureBox_finger.Image = resizeImage((Image)bitMap, size);

                //await SaveCard();
                await SaveFinger(ssid);

                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ");

                await cancle_Finger();
            }
        }


        public async Task<bool> SaveFinger(string ssid)
        {
            AddFinger addFinger = new AddFinger();
            addFinger.height = Convert.ToInt64(textBox_Height.Text);
            addFinger.witdth = Convert.ToInt64(textBox_Witdth.Text);
            addFinger.jpg_base64 = label_finger.Text;
            addFinger.enroll_index = Convert.ToInt64(textBox_EnrollIndex.Text);
            addFinger.biotype = Convert.ToInt64(textBox_BioType.Text);
            addFinger.nat_id = ssid;
            addFinger.template = label_template.Text;

            var client = new RestClient(_url);
            var request = new RestRequest($"v1/add-finger-no-card");
            request.AddBody(addFinger);

            var res = await client.ExecutePostAsync(request);

            if (res.IsSuccessful)
                return true;

            return false;
        }

        public async Task cancle_Finger()
        {
            var client = new RestClient("http://localhost:22001");
            var request = new RestRequest($"zkbioonline/fingerprint/cancelCapture");

            var res = await client.ExecuteGetAsync(request);
            label_status.Visible = false;

        }
        private System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        public Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;


            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);


            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;


            return bmpReturn;
        }

        private async void button_SsidSearch_Click(object sender, EventArgs e)
        {
            await ClearAll();

            var client = new RestClient(_url);
            var request = new RestRequest($"v1/get-iden/{textBox_SsidSearch.Text}");

            var res = await client.ExecuteGetAsync(request);

            if (res.IsSuccessful)
            {
                var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                var iden = baseResponse.GetData<GetIdenResponse>();

                if (iden.finger != null)
                {
                    textBox_Witdth.Text = iden.finger.witdth.ToString();
                    textBox_EnrollIndex.Text = iden.finger.enroll_index.ToString();
                    textBox_Height.Text = iden.finger.height.ToString();
                    textBox_Qulity.Text = iden.finger.quality.ToString();
                    textBox_BioType.Text = iden.finger.biotype.ToString();
                    textBox_ssidRead.Text = iden.ssid;

                    var bitMap = Base64StringToBitmap(iden.finger.jpg_base64);
                    Size size = new Size(300, 300);
                    pictureBox_finger.Image = resizeImage((Image)bitMap, size);


                }
                //MessageBox.Show("ค้นหาสำเร็จ", "สำเร็จ");
            }
            else
            {

                MessageBox.Show("ค้นหาเลขบัตรประชาชนในระบบไม่พบ", "ผิดพลาด");
            }
        }

        public async Task ClearAll()
        {
            textBox_Witdth.Text = "";
            textBox_EnrollIndex.Text = "";
            textBox_Height.Text = "";
            textBox_Qulity.Text = "";
            textBox_BioType.Text = "";
            label_finger.Text = "";
            label_template.Text = "";
            textBox_ssidRead.Text = "";

            pictureBox_finger.Image = null;
        }

    }
}

