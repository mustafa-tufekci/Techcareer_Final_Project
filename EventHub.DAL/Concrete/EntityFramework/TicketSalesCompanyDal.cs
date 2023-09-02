using EventHub.Core.DataAccess.EntityFramework;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;

namespace EventHub.DAL.Concrete.EntityFramework
{
    public class TicketSalesCompanyDal : EfEntityRepositoryBase<TicketSalesCompany, EventHubDbContext>, ITicketSalesCompanyDal
    {
    }
}
