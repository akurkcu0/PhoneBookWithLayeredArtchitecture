using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportsDal _reportDal;

        public ReportManager(IReportsDal reportDal)
        {
            _reportDal = reportDal;
        }

        public IDataResult<List<ReportDto>> GetByLocations()
        {
            return new SuccesDataResult<List<ReportDto>>(_reportDal.GetByLocations());
        }
    }
}
