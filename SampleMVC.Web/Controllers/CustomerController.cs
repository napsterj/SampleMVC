using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleMVC.Service;
using SampleMVC.Web.Models;
using CloudinaryDotNet;
using SampleMVC.Entities;

namespace SampleMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
       
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;                       
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var customers = await _customerService.GetAllCustomers();
            var customersRequest = new HashSet<CustomersRequest>();
            
            if (customers != null && customers.Any())
            {                
                foreach (var customer in customers)
                {
                    var addedCustomer = new CustomersRequest
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        DateOfBirth = customer.DateOfBirth,
                        Gender = customer.Gender,
                        ProfilePicture = customer.UploadedPhotoUrl,
                        UploadedPhotoUrl = customer.UploadedPhotoUrl
                    };

                    customersRequest.Add(addedCustomer);
                }                
            }

            return View(customersRequest);
        }

        [HttpGet]
        public IActionResult Add()
        {                        
            return View(new AddNewCustomerRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewCustomerRequest newCustomerRequest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error","Something is wrong with the input data");
                return View(newCustomerRequest);
            }

            //Check if the customer entered an existing customer name by mistake
            var existingCustomer = await _customerService.GetCustomerByEmail(newCustomerRequest.Email);
            
            if(existingCustomer != null) 
            {
                ViewBag.Error = "This email is already registered with us against different customer.Please correct the email.";
                return View(newCustomerRequest);
            }
            
            var uploadUrl = Request.Form["UploadedPhotoUrl"].ToString();
            var customer = new Customer
            {
                  FirstName = newCustomerRequest.FirstName,
                  LastName =  newCustomerRequest.LastName,
                  Email =  newCustomerRequest.Email,
                  Phone =   newCustomerRequest.Phone,
                  DateOfBirth = newCustomerRequest.DateOfBirth,
                  Gender = newCustomerRequest.SelectedGender,              
                  UploadedPhotoUrl = newCustomerRequest.UploadedPhotoUrl
            };

            return RedirectToAction("List");
        }
    }
}
