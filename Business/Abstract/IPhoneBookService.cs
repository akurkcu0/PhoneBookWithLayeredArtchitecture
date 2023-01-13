using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhoneBookService
    {
        IDataResult<List<PhoneBook>> GetAll();
        IDataResult<PhoneBook> GetById(int phoneBookId);
        IResult Add(PhoneBook phoneBook);
        IResult Update(PhoneBook phoneBook);
        IResult Delete(PhoneBook phoneBook);
    }
}
