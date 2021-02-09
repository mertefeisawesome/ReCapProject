﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int car_id);
        List<Car> GetCarsByColorId(int color_id);
        List<Car> GetCarsByBrandId(int brand_id);
        List<CarDetailDto> GetCarDetails();
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
