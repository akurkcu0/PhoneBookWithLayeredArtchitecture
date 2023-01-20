using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        IContactInformationDal _contactInformationDal;

        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal= contactInformationDal;
        }

        public IResult Add(ContactInformation contactInformation)
        {
            _contactInformationDal.Add(contactInformation);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ContactInformation contactInformation)
        {
            _contactInformationDal.Delete(contactInformation);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
