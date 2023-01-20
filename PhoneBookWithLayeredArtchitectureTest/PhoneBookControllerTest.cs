using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using PhoneBookWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWithLayeredArtchitectureTest
{
    public class PhoneBookControllerTest
    {
        private readonly IPhoneBookService _phoneBookService;
        private readonly IMapper _mapper;
        public PhoneBooksControllerTest(IPhoneBookService phoneBookService, IMapper mapper)
        {
            _phoneBookService = A.Fake<IPhoneBookService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void PhoneBooksController_GetAllPhoneBooks_ReturnOk()
        {
            //Arrange

            var controller = new PhoneBooksController(_phoneBookService, _mapper);

            //Act

            var result = await controller.GetAll();

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async void PhoneBooksController_CreatePhoneBook_ReturnOk()
        {
            //Arrange

            var phoneBookDto = new PhoneBookDto { CompanyName = "Test", Lastname = "test2", Name = "tes1" };
            var controller = new PhoneBooksController(_phoneBookService, _mapper);

            //Act
            var result = await controller.Add(phoneBookDto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void PhoneBooksController_PutPhoneBook_ReturnOk()
        {
            //Arrange
            int id = 1;
            var phoneBookDto = new PhoneBookDto { CompanyName = "Test", Lastname = "test2", Name = "tes1" };
            var controller = new PhoneBooksController(_phoneBookService, _mapper);

            //Act
            var result = await controller.Put(id, phoneBookDto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void PhoneBooksController_DeletePhoneBook_ReturnOk()
        {
            //Arrange
            int id = 1;
            var controller = new PhoneBooksController(_phoneBookService, _mapper);

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.NotNull(result);
        }

    }
}
