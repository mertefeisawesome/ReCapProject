using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int user_id);

        IDataResult<User> GetByMail(string email);

        IDataResult<List<User>> GetAll();

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);
    }
}