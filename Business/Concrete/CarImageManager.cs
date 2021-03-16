using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckNumberOfImages(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var oldPath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            FileHelper.DeleteAsync(oldPath);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int car_id)
        {
            var result = _carImageDal.GetAll(filter: i => i.CarId == car_id).Any();

            if (!result)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = car_id, ImagePath = @"\Images\default.jpg" });
                return new SuccessDataResult<List<CarImage>>(carImages);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.Id == car_id), Messages.ImagesListed);
        }

        public IResult TransactionalOperation(CarImage carImage, IFormFile file)
        {
            Add(carImage, file);
            Update(carImage, file);

            return new SuccessResult(Messages.ImageUpdated);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldPath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldPath, file);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckNumberOfImages(int car_id)
        {
            var carImageCount = GetImagesByCarId(car_id).Data.Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.ImageLimit);
            }
            return new SuccessResult();
        }
    }
}