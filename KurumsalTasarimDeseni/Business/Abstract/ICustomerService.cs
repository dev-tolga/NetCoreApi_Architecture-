using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(string customerId);
        IDataResult<List<Customer>> GetList();
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
