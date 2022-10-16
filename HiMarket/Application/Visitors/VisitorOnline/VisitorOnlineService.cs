using Application.Interfase.Context;
using Domain.Visitors;
using MongoDB.Driver;

namespace Application.Visitors.VisitorOnline
{
    public class VisitorOnlineService : IVisitorOnlineService
    {
        private readonly IMongoDbContext<OnlineVisitor> _mongoDbContext;
        private readonly IMongoCollection<OnlineVisitor> mongocollection;

        public VisitorOnlineService(IMongoDbContext<OnlineVisitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            mongocollection = mongoDbContext.GetCollection();
        }

        public void ConnectUser(string ClientId)
        {
            var exist = mongocollection.AsQueryable().FirstOrDefault(p => p.ClientId == ClientId);
            if (exist == null)
            {
                mongocollection.InsertOne(new OnlineVisitor
                {
                    ClientId = ClientId,
                    time = DateTime.Now,
                });
            }       
        }

        public void DisConnectUser(string ClientId)
        {
            mongocollection.FindOneAndDelete(p=>p.ClientId==ClientId);
        }

        public int GetCount()
        {
            return mongocollection.AsQueryable().Count();
        }
    }
}
