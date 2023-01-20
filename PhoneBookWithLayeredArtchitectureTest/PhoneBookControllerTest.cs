using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using PhoneBookWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTest
{
    public class PhoneBookControllerTest
    {
        private readonly IPhoneBookService _phoneBookService;
        public PhoneBookControllerTest(IPhoneBookService phoneBookService)
        {
            _phoneBookService = A.Fake<IPhoneBookService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PhoneBooksController_GetAllPhoneBooks_ReturnOk()
        {
            //Arrange

            var controller = new PhoneBooksController(_phoneBookService);

            //Act

            var result = controller.GetAll();

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public  void PhoneBooksController_CreatePhoneBook_ReturnOk()
        {
            //Arrange

            var phoneBook = new PhoneBook { CompanyName = "Test", Lastname = "test2", Name = "tes1", Id=1 };
            var controller = new PhoneBooksController(_phoneBookService);

            //Act
            var result = controller.Add(phoneBook);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public  void PhoneBooksController_PutPhoneBook_ReturnOk()
        {
            //Arrange
            var phoneBook = new PhoneBook {Id=1, CompanyName = "Test", Lastname = "test2", Name = "tes1" };
            var controller = new PhoneBooksController(_phoneBookService);

            //Act
            var result = controller.Put(phoneBook);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public  void PhoneBooksController_DeletePhoneBook_ReturnOk()
        {
            //Arrange
            var phoneBook = new PhoneBook { Id = 1, CompanyName = "Test", Lastname = "test2", Name = "tes1" };
            var controller = new PhoneBooksController(_phoneBookService);

            //Act
            var result = controller.Delete(phoneBook);

            //Assert
            Assert.Null(result);
        }

    }
}
