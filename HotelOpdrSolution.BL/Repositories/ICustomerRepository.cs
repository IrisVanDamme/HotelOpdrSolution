using HotelOpdrSolution.BL.Model;
using HotelOpdrSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Repositories
{
    public interface ICustomerRepository
    {
        public List<CustomerListDTO> GetAllCustomerListDTOs();
        public Customer GetCustomer(int id);
    }
}
