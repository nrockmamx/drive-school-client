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
                MessageBox.Show("ค้นหาสำเร็จ", "สำเร็จ");
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

            textBox_Ssid.Text = "";
            pictureBox_Photo.Image = null;

            textBox_Witdth.Text = "";
            textBox_EnrollIndex.Text = "";
            textBox_Height.Text = "";
            textBox_Qulity.Text = "";
            textBox_BioType.Text = "";

            pictureBox_finger.Image = null;
        }

        public Bitmap Base64StringToBitmap(string
                                           base64String)
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

                textBox_Ssid.Text = card.nat_id;

                var bitMap = Base64StringToBitmap(card.photo);

                pictureBox_Photo.Image = (Image)bitMap;
                MessageBox.Show("โปรดวางนิ้วและกดปุ่มแสกนลายนิ้วมือ", "สำเร็จ");
            }
        }
    }
}
