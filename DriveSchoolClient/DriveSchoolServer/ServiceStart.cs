namespace DriveSchoolServer
{
    public class ServiceStart : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("Please Input ID:");
                    var cmd = Console.ReadLine();
                    GlobalVar.ssid = cmd;
                }
            });
        }
    }
}
