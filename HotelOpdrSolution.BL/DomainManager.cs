using HotelOpdrSolution.BL.Model;
using HotelOpdrSolution.BL.Repositories;
using HotelOpdrSolution.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL
{
    public class DomainManager
    {
        private ICustomerRepository _customerRepo;
        private Customer _currentCustomer = null;
        public DomainManager(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }


        public List<CustomerListDTO> GetCustomerListDTOs()
        {
            List<CustomerListDTO> dtos = _customerRepo.GetAllCustomerListDTOs();
            return dtos;
        }

        public CustomerListDTO GetCurrentCustomerListDTO()
        {
            string address = $"({_currentCustomer.ContactInfoCustomer.AddressInfo.City} [{_currentCustomer.ContactInfoCustomer.AddressInfo.ZipCode}] - {_currentCustomer.ContactInfoCustomer.AddressInfo.Street} - {_currentCustomer.ContactInfoCustomer.AddressInfo.HouseNr})";
            return new CustomerListDTO(_currentCustomer.Id, _currentCustomer.Name, _currentCustomer.ContactInfoCustomer.Email, address, _currentCustomer.ContactInfoCustomer.Phone, _currentCustomer.Members.Count());
        }

        public FullCustomerDTO GetCurrentFullCustomerDTO()
        {
            return new FullCustomerDTO(_currentCustomer.Id, _currentCustomer.Name, _currentCustomer.ContactInfoCustomer.Email, _currentCustomer.ContactInfoCustomer.Phone, _currentCustomer.ContactInfoCustomer.AddressInfo.Street, _currentCustomer.ContactInfoCustomer.AddressInfo.HouseNr, _currentCustomer.ContactInfoCustomer.AddressInfo.ZipCode, _currentCustomer.ContactInfoCustomer.AddressInfo.City);
        }

        public void setCurrentCustomer(int id)
        {
            _currentCustomer = _customerRepo.GetCustomer(id);
        }
        public void updateCustomer(FullCustomerDTO fullCustomerDTO)
        {
            Address address = new Address(fullCustomerDTO.Street, fullCustomerDTO.HouseNr, fullCustomerDTO.Zipcode, fullCustomerDTO.City);
            ContactInfo contactInfo = new ContactInfo(fullCustomerDTO.Email, fullCustomerDTO.Phone, address);
            Customer updatedCustomer = new Customer(_currentCustomer.Id, fullCustomerDTO.Name, _currentCustomer.Members, _currentCustomer.Registrations, contactInfo);

        }
    }
}
