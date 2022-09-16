using OrderCustomerApi.Service.Model;
using OrderCustomerApi.Shared.Model.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Interfaces
{
    public interface IOrderService
    {
        ServiceResult Create(AddOrderBindingModel addOrderBindingModel);
        ServiceResult Update(UpdateOrderBindingModel model);
        ServiceResult Delete(Guid guid);
    }
}
