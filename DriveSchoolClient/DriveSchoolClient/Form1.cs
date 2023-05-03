using DriveSchoolClient.Model.Request;
using DriveSchoolClient.Model.Response;
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
using System.Web;
using System.Windows.Forms;

namespace DriveSchoolClient
{
    public partial class MainForm : Form
    {
        private readonly string _url = "https://drive-school-api.test-api-system-prod.com";
        public MainForm()
        {
            InitializeComponent();
        }

        private async void button_SsidSearch_Click(object sender, EventArgs e)
        {
            await ClearAll();

            var client = new RestClient(_url);
            var request = new RestRequest($"v1/get-iden/{textBox_SsidSearch.Text}");

            var res = await client.ExecuteGetAsync(request);

            if(res.IsSuccessful)
            {
                var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                var iden = baseResponse.GetData<GetIdenResponse>();

                if (iden.card != null)
                {
                    textBox_TitleTh.Text = iden.card.title_th;
                    textBox_FnameTh.Text = iden.card.fname_th;
                    textBox_SnameTh.Text = iden.card.sname_th;
                    textBox_MnameTh.Text = iden.card.mname_th;

                    textBox_TitleEn.Text = iden.card.title_en;
                    textBox_FnameEn.Text = iden.card.fname_en;
                    textBox_SnameEn.Text = iden.card.sname_en;
                    textBox_MnameEn.Text = iden.card.mname_en;

                    textBox_Amphor.Text = iden.card.address_amphor;
                    textBox_BirthDate.Text = iden.card.birthdate;
                    textBox_Gender.Text = iden.card.gender;
                    textBox_Issue.Text = iden.card.issuer;
                    textBox_Tumbol.Text = iden.card.address_tumbol;
                    textBo_Soi.Text = iden.card.address_soi;
                    textBox_No.Text = iden.card.address_no;
                    textBox_Moo.Text = iden.card.address_moo;
                    textBox_Provinice.Text = iden.card.address_provinice;
                    textBox_Road.Text = iden.card.address_road;
                    textBox_issue_date.Text = iden.card.issue_date;
                    textBox_issue_expire.Text = iden.card.issue_expire;

                    textBox_Ssid.Text = iden.card.nat_id;

                    var bitMap = Base64StringToBitmap(iden.card.photo);

                    pictureBox_Photo.Image = (Image)bitMap;
                }

                if(iden.finger!=null)
                {
                    textBox_Witdth.Text = iden.finger.witdth.ToString();
                    textBox_EnrollIndex.Text = iden.finger.enroll_index.ToString();
                    textBox_Height.Text = iden.finger.height.ToString();
                    textBox_Qulity.Text = iden.finger.quality.ToString();
                    textBox_BioType.Text = iden.finger.biotype.ToString();

                    var bitMap = Base64StringToBitmap(iden.finger.jpg_base64);
                    Size size = new Size(300, 300);
                    pictureBox_finger.Image = resizeImage((Image)bitMap,size);
                    

                }
                //MessageBox.Show("ค้นหาสำเร็จ", "สำเร็จ");
            }
            else
            {
        
                MessageBox.Show("ค้นหาเลขบัตรประชาชนในระบบไม่พบ","ผิดพลาด");
            }

        }

        public async Task ClearAll()
        {
            textBox_TitleTh.Text = "";
            textBox_FnameTh.Text = "";
            textBox_SnameTh.Text = "";
            textBox_MnameTh.Text = "";

            textBox_TitleEn.Text = "";
            textBox_FnameEn.Text = "";
            textBox_SnameEn.Text = "";
            textBox_MnameEn.Text = "";

            textBox_Amphor.Text = "";
            textBox_BirthDate.Text = "";
            textBox_Gender.Text = "";
            textBox_Issue.Text = "";
            textBox_Tumbol.Text = "";
            textBo_Soi.Text = "";
            textBox_No.Text = "";
            textBox_Moo.Text = "";
            textBox_Provinice.Text = "";
            textBox_Road.Text = "";
            textBox_issue_expire.Text = "";
            textBox_issue_date.Text = "";
            textBox_Ssid.Text = "";
            pictureBox_Photo.Image = null;

            textBox_Witdth.Text = "";
            textBox_EnrollIndex.Text = "";
            textBox_Height.Text = "";
            textBox_Qulity.Text = "";
            textBox_BioType.Text = "";
            label_photo.Text = "";
            label_finger.Text = "";
            label_template.Text = "";

            pictureBox_finger.Image = null;
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

        private async void button_CardRead_Click(object sender, EventArgs e)
        {
            await ClearAll();
            var client = new RestClient("http://localhost:21998");
            var request = new RestRequest($"info");

            var res = await client.ExecuteGetAsync(request);

            if(!res.IsSuccessful)
            {
                MessageBox.Show("ไม่สามารถหา Drive เครื่องอ่านบัตรประชาชนได้", "ผิดพลาด");
                return;
            }

            request = new RestRequest($"readCard");

            res = await client.ExecuteGetAsync(request);

            if (!res.IsSuccessful)
            {
                MessageBox.Show("โปรดตรวจสอบบั้ตรประชาชนว่าเสียบแล้วหรือไม่", "ผิดพลาด");
                return;
            }

            var card= Newtonsoft.Json.JsonConvert.DeserializeObject<CardClass>(res.Content.ToString());

            if(card!=null)
            {
                if(string.IsNullOrEmpty(card.photo))
                {
                    MessageBox.Show("โปรดตรวจสอบบัตรประชาชนว่ามีปัญหาไหม", "ผิดพลาด");
                    return;
                }

                textBox_TitleTh.Text = card.title_th;
                textBox_FnameTh.Text = card.fname_th;
                textBox_SnameTh.Text = card.sname_th;
                textBox_MnameTh.Text = card.mname_th;

                textBox_TitleEn.Text = card.title_en;
                textBox_FnameEn.Text = card.fname_en;
                textBox_SnameEn.Text = card.sname_en;
                textBox_MnameEn.Text = card.mname_en;

                textBox_Amphor.Text = card.address_amphor;
                textBox_BirthDate.Text = card.birthdate;
                textBox_Gender.Text = card.gender;
                textBox_Issue.Text = card.issuer;
                textBox_Tumbol.Text = card.address_tumbol;
                textBo_Soi.Text = card.address_soi;
                textBox_No.Text = card.address_no;
                textBox_Moo.Text = card.address_moo;
                textBox_Provinice.Text = card.address_provinice;
                textBox_Road.Text = card.address_road;
                textBox_Trok.Text = card.address_trok;
                textBox_issue_date.Text = card.issue_date;
                textBox_issue_expire.Text = card.issue_expire;
                

                textBox_Ssid.Text = card.nat_id;

                var bitMap = Base64StringToBitmap(card.photo);

                pictureBox_Photo.Image = (Image)bitMap;
                label_photo.Text = card.photo;
                MessageBox.Show("โปรดกดปุ่มแสกนนิ้วและรีบวางนิ้วมือลงไปขึ้นลง 3 ครั้ง", "สำเร็จ");
            }
        }

        private async void button_FingerRead_Click(object sender, EventArgs e)
        {
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

                if(res.IsSuccessful && res.Content.Contains("biotype"))
                {

                    break;
                }
            }

            if(res.Content.Contains("please press finger"))
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
                var bitMap = Base64StringToBitmap(finger.jpg_base64);
                Size size = new Size(300, 300);

                pictureBox_finger.Image = resizeImage((Image)bitMap, size);

                await SaveCard();
                await SaveFinger();

                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ");

                await cancle_Finger();
            }
        }

        public async Task cancle_Finger()
        {
            var client = new RestClient("http://localhost:22001");
            var request = new RestRequest($"zkbioonline/fingerprint/cancelCapture");

            var res = await client.ExecuteGetAsync(request);
            label_status.Visible = false;
           
        }

        public async Task<bool> SaveFinger()
        {
            AddFinger addFinger = new AddFinger();
            addFinger.height = Convert.ToInt64(textBox_Height.Text);
            addFinger.witdth = Convert.ToInt64(textBox_Witdth.Text);
            addFinger.jpg_base64 = label_finger.Text;
            addFinger.enroll_index = Convert.ToInt64(textBox_EnrollIndex.Text);
            addFinger.biotype = Convert.ToInt64(textBox_BioType.Text);
            addFinger.nat_id = textBox_Ssid.Text;
            addFinger.template = label_template.Text;

            var client = new RestClient(_url);
            var request = new RestRequest($"v1/add-finger");
            request.AddBody(addFinger);

            var res = await client.ExecutePostAsync(request);

            if (res.IsSuccessful)
                return true;

            return false;
        }
        public async Task<bool> SaveCard()
        {
            AddCard addCard = new AddCard();
            addCard.title_th = textBox_TitleTh.Text;
            addCard.fname_th = textBox_FnameTh.Text;
            addCard.sname_th = textBox_SnameTh.Text;
            addCard.mname_th = textBox_MnameTh.Text;

            addCard.title_en = textBox_TitleEn.Text;
            addCard.fname_en = textBox_FnameEn.Text;
            addCard.sname_en = textBox_SnameEn.Text;
            addCard.mname_en = textBox_MnameEn.Text;

            addCard.address_amphor = textBox_Amphor.Text;
            addCard.birthdate = textBox_BirthDate.Text;
            addCard.gender = textBox_Gender.Text;
            addCard.issuer = textBox_Issue.Text;
            addCard.address_tumbol = textBox_Tumbol.Text;
            addCard.address_soi = textBo_Soi.Text;
            addCard.address_no = textBox_No.Text;
            addCard.address_moo = textBox_Moo.Text;
            addCard.address_provinice = textBox_Provinice.Text;
            addCard.address_road = textBox_Road.Text;
            addCard.nat_id = textBox_Ssid.Text;
            addCard.photo = label_photo.Text;
            addCard.address_trok = textBox_Trok.Text;
            addCard.nat_id = textBox_Ssid.Text;
            addCard.issue_date = textBox_issue_date.Text;
            addCard.issue_expire = textBox_issue_expire.Text;

            var client = new RestClient(_url);
            var request = new RestRequest($"v1/add-card");
            request.AddBody(addCard);

            var res = await client.ExecutePostAsync(request);

            if (res.IsSuccessful)
                return true;

            return false;
        }

        private void button_otherIden_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }

 
}
