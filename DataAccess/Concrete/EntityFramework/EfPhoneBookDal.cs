using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhoneBookDal : EfEntityRepositoryBase<PhoneBook, PhoneBookDbContext>, IPhoneBookDal
    {
    }
}
