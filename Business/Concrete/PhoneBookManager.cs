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
    public class PhoneBookManager : IPhoneBookService
    {
        IPhoneBookDal _phoneBookDal;
        public PhoneBookManager(IPhoneBookDal phoneBookDal)
        {
            _phoneBookDal= phoneBookDal;
        }

        public IResult Add(PhoneBook phoneBook)
        {
            if (phoneBook.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _phoneBookDal.Add(phoneBook);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(PhoneBook phoneBook)
        {
            _phoneBookDal.Delete(phoneBook);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<PhoneBook>> GetAll()
        {
            return new SuccesDataResult<List<PhoneBook>>(_phoneBookDal.GetAll(),Messages.PhoneBookListed);
        }

        public IDataResult<PhoneBook> GetById(int phoneBookId)
        {
            return new SuccesDataResult<PhoneBook>(_phoneBookDal.Get(p=> p.Id == phoneBookId), Messages.GetPerson);
        }

        public IResult Update(PhoneBook phoneBook)
        {
            _phoneBookDal.Update(phoneBook);
            return new SuccessResult(Messages.Updated);
        }
    }
}
