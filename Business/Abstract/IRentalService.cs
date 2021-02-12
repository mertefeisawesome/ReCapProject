using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int rental_id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
