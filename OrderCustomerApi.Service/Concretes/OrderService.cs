using OrderApi.Data.Repositories;
using OrderCustomerApi.Data.UnitOfWork.Interfaces;
using OrderCustomerApi.Entities;
using OrderCustomerApi.Service.Interfaces;
using OrderCustomerApi.Service.Model;
using OrderCustomerApi.Shared.Model.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   
        public ServiceResult Create(AddOrderBindingModel model)
        {
            try
            {
                Guid guid = Guid.NewGuid(); 
                var order = new Order
                {
                    Guid = guid,
                    CreatedAt = DateTime.Now, //To do: unitof work içerisine çekilebilir.
                    CreatedBy = Guid.NewGuid(), //To do : tokendan gelecek şekilde request helper oluşturulabilir.
                    CustomerGuid = model.CustomerGuid,
                    AddressGuid = model.AddressGuid,


                };
                var orderProductList = new List<OrderProduct>();
                foreach (var item in model.Products)
                {
                    orderProductList.Add(new OrderProduct
                    {
                        OrderGuid = guid,
                        ProductGuid = item.Guid,
                        Quantity = item.Quatity
                    });

                }
                _unitOfWork.GetRepository<Order>().Add(order);
                _unitOfWork.GetRepository<OrderProduct>().AddRange(orderProductList);
                _unitOfWork.SaveChanges();

                return ServiceResult.GetSuccessResult(status:System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ServiceResult.GetFailedResult("Bir hata oluştu!",status: System.Net.HttpStatusCode.BadRequest);
            }
            

        }

        public ServiceResult Update(UpdateOrderBindingModel model)
        {
            var updateData = _unitOfWork.GetRepository<Order>().GetAll(x => x.Guid == model.Guid).FirstOrDefault();

            try
            {
                if (updateData != null)
                {
                    foreach(var item in model.Products)
                    {
                       var orderProduct =  _unitOfWork.GetRepository<OrderProduct>().GetAll(x => x.Guid == item.Guid).FirstOrDefault();
                        if (orderProduct != null)
                        {
                            orderProduct.ProductGuid = item.Guid;
                            orderProduct.Quantity = item.Quatity;
                            orderProduct.OrderGuid = model.Guid;
                            _unitOfWork.GetRepository<OrderProduct>().Update(orderProduct);
                        }
                        else
                        {
                            _unitOfWork.GetRepository<OrderProduct>().Add(new OrderProduct
                            {
                                ProductGuid = item.Guid,
                                Quantity = item.Quatity,
                                OrderGuid = model.Guid
                            });
                        }

                    }
                    var productAllGuidsForOrder = _unitOfWork.GetRepository<OrderProduct>().GetAll(x => x.OrderGuid == model.Guid).ToList();
                    var updatedProductGuidsForOrder =  model.Products.Select(x => new { Guid = x.Guid }).ToList();
                    var deleteElements = productAllGuidsForOrder.Where(p => !updatedProductGuidsForOrder.Any(productAllGuidsForOrder => productAllGuidsForOrder.Guid == p.Guid)).ToList();
                    _unitOfWork.GetRepository<OrderProduct>().RemoveRange(deleteElements);

                   

                    updateData.AddressGuid = model.AddressGuid;
                    updateData.CustomerGuid = model.CustomerGuid;
                    updateData.Amount = GetAmount(model.Products);

                    _unitOfWork.GetRepository<Order>().Update(updateData);
                    _unitOfWork.SaveChanges();

                    return ServiceResult.GetSuccessResult(status: System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return ServiceResult.GetFailedResult("Kayıt bulunamadı!", status: System.Net.HttpStatusCode.NotFound);
                }
                
            }
           
            catch (Exception ex)
            {
                return ServiceResult.GetFailedResult("Bir hata oluştu!", status: System.Net.HttpStatusCode.BadRequest);
            }


        }

        public ServiceResult Delete(Guid guid)
        {
            try
            {
                var deletedData = _unitOfWork.GetRepository<Order>().GetAll(x => x.Guid == guid).FirstOrDefault();
                if (deletedData != null)
                {
                    _unitOfWork.GetRepository<Order>().Delete(guid);
                    _unitOfWork.SaveChanges();
                    return ServiceResult.GetSuccessResult(status: System.Net.HttpStatusCode.OK);

                }
                else
                {
                    return ServiceResult.GetSuccessResult(status: System.Net.HttpStatusCode.NotFound);
                }
  
            }
            catch (Exception ex)
            {
                return ServiceResult.GetFailedResult("Silme işlemi sırasında hata oluştu!", status: System.Net.HttpStatusCode.BadRequest);
            }



        }

        public decimal GetAmount (List<UpdateProductBindingModel> productBindingModels)
        {
            decimal totalAmount = 0;
            foreach(var item in productBindingModels) //To do : Repo foreach dışına alınacak
            {
                totalAmount += item.Quatity * _unitOfWork.GetRepository<Product>().GetAll(x=> x.Guid == item.Guid).Select(x=> x.Price).First();

            }

            return totalAmount;
        }
    }
}
