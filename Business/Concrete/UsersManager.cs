using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UsersManager :IUsersService
    {
        IUsersDal _usersDal;
        public UsersManager(IUsersDal UsersDal)
        {
            _usersDal = UsersDal;
        }

        public IResult Add(Users users)
        {
            if (users.FirstName.Length>4)
            {
                return new ErrorResult(Messages.UsersDescriptionInvalid);
            }
            _usersDal.Add(users);

            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Delete(Users users)
        {
           _usersDal.Delete(users);
            return new SuccessResult(Messages.UsersDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
           
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<Users> GetById(int Id)
        {
            return new SuccessDataResult<Users>(_usersDal.Get(u => u.Id == Id));
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.UsersUpdated);
        }
    }
}
