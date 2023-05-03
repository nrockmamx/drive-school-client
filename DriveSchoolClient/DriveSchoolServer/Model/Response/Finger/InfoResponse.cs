namespace DriveSchoolServer.Model.Response.Finger
{
    public class InfoResponse
    {
        public string server_version { get; set; } = "5.2.14";
        public string start { get; set; } = DateTime.Now.AddSeconds(-12).ToString();
        public string now { get; set; } = DateTime.Now.ToString();
        public List<BioMeticTypeRespose> biometric { get; set; } = new List<BioMeticTypeRespose>();
    }

    public class BioMeticTypeRespose
    {
        public string type { get; set; } = "fingerprint";
        public string engversion { get; set; }
    }
}
