using Business.Abstract;
using PhoneBookWebApi.Controllers;
using PhoneBookWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTest
{
    public class ReportControllerTest
    {
        private readonly IReportService _reportService;

        public ReportControllerTest(IReportService reportService)
        {
            _reportService = reportService;
        }

        [Fact]
        public void ReportController_GetAllByLocation_ReturnOk()
        {
            //Arrange

            var controller = new ReportController(_reportService);

            //Act

            var result = controller.GetByLocationAll();

            //Assert

            Assert.NotNull(result);
        }
    }
}
