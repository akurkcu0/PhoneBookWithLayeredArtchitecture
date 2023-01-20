using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReportsDal : EfEntityRepositoryBase<ContactInformation, PhoneBookDbContext>, IReportsDal
    {
        public List<ReportDto> GetByLocations()
        {
            using (PhoneBookDbContext context = new PhoneBookDbContext())
            {
                var locations = context.contactInformations.GroupBy(p => p.Location).Select(s => s.Key).ToList();
                var result = from location in locations
                             select new ReportDto()
                             {
                                 Location = location,
                                 NumberOfPeople = context.contactInformations.Where(p => p.Location == location).Count(),
                                 NumberOfPhone = context.contactInformations.Where(p => p.Location == location && p.PhoneNumber != "").Count(),
                             };

                return result.OrderBy(p => p.NumberOfPeople).ToList();

            }
        }
    }
}
