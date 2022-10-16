using Domain.Visitors;

namespace Application.Visitors.SaveVisitorInfo
{
    public class RequestSaveVisitorInfoDto
    {
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferreLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersion Browser { get; set; }
        public VisitorVersionDto OperatingSystem { get; set; }
        public DeviceDto Device { get; set; }
        public string  VisitorId { get; set; }
    }
}
