using Application.Interfase.Context;
using Domain.Visitors;
using MongoDB.Driver;

namespace Application.Visitors.SaveVisitorInfo
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _visitorMongoCollection;

        public SaveVisitorInfoService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _visitorMongoCollection = _mongoDbContext.GetCollection();
        }
        public void Execute(RequestSaveVisitorInfoDto request)
        {
            _visitorMongoCollection.InsertOne(new Visitor
            {
                Browser = new VisitorVersion
                {
                    Family = request.Browser.Family,
                    Version = request.Browser.Version,
                },
                CurrentLink = request.CurrentLink,
                Device = new Device
                {
                    Brand = request.Device.Brand,
                    Family = request.Device.Family,
                    IsSpider = request.Device.IsSpider,
                    Model = request.Device.Model
                },
                Ip = request.Ip,
                Method = request.Method,
                OperatingSystem = new VisitorVersion
                {
                    Family = request.OperatingSystem.Family,
                    Version = request.OperatingSystem.Version
                },
                PhysicalPath = request.PhysicalPath,
                Protocol = request.Protocol,
                ReferreLink = request.ReferreLink,
                VisitorId = request.VisitorId,
                Time = DateTime.Now,
            });
        }
    }
}
