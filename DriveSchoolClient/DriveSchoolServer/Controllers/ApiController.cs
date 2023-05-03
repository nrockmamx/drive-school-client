using DriveSchoolServer.Model.Response;
using DriveSchoolServer.Model.Response.Card;
using DriveSchoolServer.Model.Response.Finger;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace DriveSchoolServer.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;
        private readonly string _url = "https://drive-school-api.test-api-system-prod.com";

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }


        //[HttpOptions("info")]
        [HttpGet("info")]
        public async Task<IActionResult> GetInfoCard()
        {
            try
            {
                Model.Response.Card.InfoResponse infoResponse = new Model.Response.Card.InfoResponse();
                return Ok(infoResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("zkbioonline/info")]
        public async Task<IActionResult> GetInfoFinger()
        {
            try
            {
                FigerBaseResponse fb = new FigerBaseResponse();
                Model.Response.Finger.InfoResponse infoResponse = new Model.Response.Finger.InfoResponse();
                BioMeticTypeRespose b1 = new BioMeticTypeRespose();
                BioMeticTypeRespose b2 = new BioMeticTypeRespose();

                b1.type = "fingerprint";
                b1.engversion = "10.0";

                b2.type = "fingervein";
                b2.engversion = "3.0.0";

                infoResponse.biometric.Add(b1);
                infoResponse.biometric.Add(b2);

                fb.data = infoResponse;

                return Ok(fb);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("readCardNoPhoto")]
        public async Task<IActionResult> ReadCardNoPhoto()
        {
            try
            {

                if (string.IsNullOrEmpty(GlobalVar.ssid))
                    return BadRequest();

                ReadCardResponse readCardResponse = new ReadCardResponse();

                DateTime dateTime = DateTime.Now;

                readCardResponse.read_date = dateTime.ToString().Replace(" ", "T") + ".706829+07:00";
                readCardResponse.read_time = readCardResponse.read_date;

                var client = new RestClient(_url);
                var request = new RestRequest($"v1/get-iden/{GlobalVar.ssid}");
                var res = await client.ExecuteGetAsync(request);

                if (res.IsSuccessful)
                {
                    var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                    var iden = baseResponse.GetData<GetIdenResponse>();

                    if (iden.card != null)
                    {
                        readCardResponse.nat_id = iden.card.nat_id;

                        readCardResponse.issue_date = iden.card.issue_date;
                        readCardResponse.issuer = iden.card.issuer;
                        readCardResponse.issue_expire = iden.card.issue_expire;

                        readCardResponse.birthdate = iden.card.birthdate;

                        readCardResponse.address_no = iden.card.address_no;
                        readCardResponse.address_amphor = iden.card.address_amphor;
                        readCardResponse.address_moo = iden.card.address_moo;
                        readCardResponse.address_provinice = iden.card.address_provinice;
                        readCardResponse.address_road = iden.card.address_road;
                        readCardResponse.address_soi = iden.card.address_soi;
                        readCardResponse.address_trok = iden.card.address_trok;
                        readCardResponse.address_tumbol = iden.card.address_tumbol;

                        readCardResponse.mname_th = iden.card.mname_th;
                        readCardResponse.sname_th = iden.card.sname_th;
                        readCardResponse.fname_th = iden.card.fname_th;
                        readCardResponse.title_th = iden.card.title_th;

                        readCardResponse.mname_en = iden.card.mname_en;
                        readCardResponse.sname_en = iden.card.sname_en;
                        readCardResponse.fname_en = iden.card.fname_en;
                        readCardResponse.title_en = iden.card.title_en;

                    }

                }

                return Ok(readCardResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        //[HttpOptions("readCard")]
        [HttpGet("readCard")]
        public async Task<IActionResult> ReadCard()
        {
            try
            {

                if (string.IsNullOrEmpty(GlobalVar.ssid))
                    return BadRequest();

                ReadCardResponse readCardResponse = new ReadCardResponse();

                DateTime dateTime = DateTime.Now;

                readCardResponse.read_date = dateTime.ToString().Replace(" ","T")+ ".706829+07:00";
                readCardResponse.read_time = readCardResponse.read_date;

                var client = new RestClient(_url);
                var request = new RestRequest($"v1/get-iden/{GlobalVar.ssid}");
                var res = await client.ExecuteGetAsync(request);

                if(res.IsSuccessful)
                {
                    var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                    var iden = baseResponse.GetData<GetIdenResponse>();

                    if (iden.card != null)
                    {
                        readCardResponse.nat_id = iden.card.nat_id;
                        
                        readCardResponse.issue_date = iden.card.issue_date;
                        readCardResponse.issuer = iden.card.issuer;
                        readCardResponse.issue_expire = iden.card.issue_expire;

                        readCardResponse.birthdate = iden.card.birthdate;
                        
                        readCardResponse.address_no = iden.card.address_no;
                        readCardResponse.address_amphor = iden.card.address_amphor;
                        readCardResponse.address_moo = iden.card.address_moo;
                        readCardResponse.address_provinice = iden.card.address_provinice;
                        readCardResponse.address_road = iden.card.address_road;
                        readCardResponse.address_soi = iden.card.address_soi;
                        readCardResponse.address_trok = iden.card.address_trok;
                        readCardResponse.address_tumbol = iden.card.address_tumbol;

                        readCardResponse.mname_th = iden.card.mname_th;
                        readCardResponse.sname_th = iden.card.sname_th;
                        readCardResponse.fname_th = iden.card.fname_th;
                        readCardResponse.title_th = iden.card.title_th;

                        readCardResponse.mname_en = iden.card.mname_en;
                        readCardResponse.sname_en = iden.card.sname_en;
                        readCardResponse.fname_en = iden.card.fname_en;
                        readCardResponse.title_en = iden.card.title_en;

                        readCardResponse.photo = iden.card.photo;

                    }

                }
                
                return Ok(readCardResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("/zkbioonline/fingerprint/cancelCapture")]
        public async Task<IActionResult> CancleCapture()
        {
            try
            {
                FigerBaseResponse fingerBaseResponse = new FigerBaseResponse();
                fingerBaseResponse.data = "";
                return Ok(fingerBaseResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("/zkbioonline/fingerprint/beginCapture")]
        public async Task<IActionResult> BeginCapture()
        {
            try
            {
                FigerBaseResponse fingerBaseResponse = new FigerBaseResponse();

                BeginCaptureResponse beginCapture = new BeginCaptureResponse();

                fingerBaseResponse.data = beginCapture;

                return Ok(fingerBaseResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("/zkbioonline/fingerprint/getTemplate")]
        public async Task<IActionResult> GetTemplate()
        {
            try
            {
                FigerBaseResponse fingerBaseResponse = new FigerBaseResponse();

                GetTemplateResponse getTemplateResponse = new GetTemplateResponse();

                var client = new RestClient(_url);
                var request = new RestRequest($"v1/get-iden/{GlobalVar.ssid}");
                var res = await client.ExecuteGetAsync(request);

                if (res.IsSuccessful)
                {
                    var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                    var iden = baseResponse.GetData<GetIdenResponse>();
                    getTemplateResponse.template = iden.finger.template;
                    getTemplateResponse.length = iden.finger.template.Length;
                    getTemplateResponse.biotype = iden.finger.biotype;

                    fingerBaseResponse.data = getTemplateResponse;

                }

                 return Ok(fingerBaseResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpGet("/zkbioonline/fingerprint/getImage")]
        public async Task<IActionResult> GetImage()
        {
            try
            {
                FigerBaseResponse fingerBaseResponse = new FigerBaseResponse();

                GetImageResponse getImageResponse = new GetImageResponse();

                var client = new RestClient(_url);
                var request = new RestRequest($"v1/get-iden/{GlobalVar.ssid}");
                var res = await client.ExecuteGetAsync(request);

                if (res.IsSuccessful)
                {
                    var baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(res.Content.ToString());
                    var iden = baseResponse.GetData<GetIdenResponse>();
                    getImageResponse.witdth = iden.finger.witdth;
                    getImageResponse.jpg_base64 = iden.finger.jpg_base64;
                    getImageResponse.biotype = iden.finger.biotype;
                    getImageResponse.enroll_index = iden.finger.enroll_index;
                    getImageResponse.height = iden.finger.height;
                    getImageResponse.quality = iden.finger.quality;

                    fingerBaseResponse.data = getImageResponse;

                }

                return Ok(fingerBaseResponse);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }
    }
}