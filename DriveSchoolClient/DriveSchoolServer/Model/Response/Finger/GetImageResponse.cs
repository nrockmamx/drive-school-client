namespace DriveSchoolServer.Model.Response.Finger
{
    public class GetImageResponse
    {
        public long biotype { get; set; }
        public long enroll_index { get; set; }
        public long quality { get; set; }
        public long witdth { get; set; }
        public long height { get; set; }
        public string jpg_base64 { get; set; }
        public string template { get; set; }
    }
}
