using Microsoft.AspNetCore.Mvc;
using OrderCustomerApi.Service.Interfaces;
using OrderCustomerApi.Service.Model;
using OrderCustomerApi.Shared.Model.BindingModel;

namespace OrderCustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;   
        }

        [HttpPost]
        public ServiceResult Create(AddOrderBindingModel model) => _orderService.Create(model);

        [HttpPut]
        public ServiceResult Update(UpdateOrderBindingModel model) =>  _orderService.Update(model);

        [HttpDelete,Route("{guid}")]
        public ServiceResult Update(Guid guid) => _orderService.Delete(guid);

    }
}
