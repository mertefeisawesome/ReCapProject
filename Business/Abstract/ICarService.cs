using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int car_id);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(int color_id);

        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brand_id);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);

        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);
    }
}