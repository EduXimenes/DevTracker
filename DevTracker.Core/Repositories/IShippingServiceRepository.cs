using DevTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTracker.Core.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}
