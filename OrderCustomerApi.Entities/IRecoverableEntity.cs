using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Data.Repositories.Interfaces
{
    public interface IRecoverableEntity
    {
        bool IsDeleted { get; set; }
    }
}
