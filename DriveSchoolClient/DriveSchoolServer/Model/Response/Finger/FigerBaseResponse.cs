namespace DriveSchoolServer.Model.Response.Finger
{
    public class FigerBaseResponse
    {
        public int ret { get; set; } = 0;
        public string erros { get; set; } = "";
        public Object data { get; set; } = null;
    }
}
