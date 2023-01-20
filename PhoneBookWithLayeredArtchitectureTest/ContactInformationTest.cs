using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using PhoneBookWebApi.Controllers;
using PhoneBookWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTest
{
    public class ContactInformationTest
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationTest(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [Fact]
        public  void ContactInformationController_CreateContactInformation_ReturnOk()
        {
            //Arrange

            var contactInformation = new ContactInformation {Adress = "Adana", Email = "krkcabdurrahman@hotmail.com", Location = "Adana", PhoneBookId = 2, PhoneNumber = "1223344556"  };
            var controller = new ContactInformationController(_contactInformationService);

            //Act
            var result = controller.Add(contactInformation);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public  void ContactInformationController_DeleteContactInformation_ReturnOk()
        {
            //Arrange
            var contactInformation = new ContactInformation { Adress = "Adana", Email = "krkcabdurrahman@hotmail.com", Location = "Adana", PhoneBookId = 2, PhoneNumber = "1223344556" };
            var controller = new ContactInformationController(_contactInformationService);

            //Act
            var result = controller.Delete(contactInformation);

            //Assert
            Assert.Null(result);
        }
    }
}
