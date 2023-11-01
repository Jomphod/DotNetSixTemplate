using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;

namespace Core.Interfaces.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        private ProvinceServiceResponse ConvertToResponseModel(Province entity)
        {
            return new ProvinceServiceResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedUTC = entity.CreatedUTC,
                UpdatedUTC = entity.UpdatedUTC,
                IsActive = entity.IsActive
            };
        }

        public async Task<ProvinceServiceResponse> CreateNewProvinceAsync(ProvinceServiceInput input){

            // Return duplication error if the name is already used.
            bool isTheNameAlreadyUsed = await _provinceRepository.DoesExist(c => c.Name == input.Name);
            if(isTheNameAlreadyUsed)
                throw new ArgumentException("Province name is used already, Please choose another name.");
            
            Province entity = new Province() {
                Name = input.Name,
                Description = input.Description
            };

            Province insertedEntity = await _provinceRepository.AddAsync(entity);
            await _provinceRepository.SaveChangesAsync();

            return ConvertToResponseModel(insertedEntity);
        }

        public async Task<ProvinceServiceResponse> UpdateProvinceAsync(Guid id, ProvinceServiceInput input){
            Province exitingProvince = await _provinceRepository.GetByIdAsync(id);

            bool isTheEntityNotExist = (exitingProvince == null);
            if(isTheEntityNotExist)
                throw new ArgumentException("Cannot update the province. It does not exist.");
            
            exitingProvince.Name = input.Name;
            exitingProvince.Description = input.Description;
            exitingProvince = _provinceRepository.Update(exitingProvince);
            await _provinceRepository.SaveChangesAsync();

            return ConvertToResponseModel(exitingProvince);
        }

        public async Task<ProvinceServiceResponse> DeleteProvinceAsync(Guid provinceId){
            Province existingProvince = await _provinceRepository.GetByIdAsync(provinceId);

            bool isTheEntityNotExist = (existingProvince == null);
            if(isTheEntityNotExist)
                throw new ArgumentException("Cannot delete the province, It does not exist.");
            
            existingProvince = _provinceRepository.Remove(existingProvince);
            await _provinceRepository.SaveChangesAsync();

            return ConvertToResponseModel(existingProvince);
        }

        public async Task<ProvinceServiceResponse> GetProvinceAsync(Guid provinceId){
            Province existingProvince = await _provinceRepository.GetByIdAsync(provinceId);

            bool isTheEntityNotExist = (existingProvince == null);
            if(isTheEntityNotExist)
                throw new ArgumentException("Cannot get the province, It does not exist");
            
            return ConvertToResponseModel(existingProvince);
        }

        public async Task<ProvinceServiceResponseWithPointOfInterest> GetProvinceAsyncWithPointOfInterestAsync(Guid provinceId){
            Province existingProvince = await _provinceRepository.GetByIdWithPointOfInterestAsync(provinceId);

            bool isTheEntityNotExist = (existingProvince == null);
            if(isTheEntityNotExist)
                throw new ArgumentException("Cannot get the province, It does not exist");
            
            ProvinceServiceResponseWithPointOfInterest response = new ProvinceServiceResponseWithPointOfInterest(){
                Id = existingProvince.Id,
                Name = existingProvince.Name,
                PointOfInterests = new List<ProvinceServiceResponsePointOfInterest>() 
            };

            foreach(PointOfInterest pointOfInterest in existingProvince.PointOfInterests.Where(c => c.IsActive).OrderBy(c => c.Name).ToList()){
                ProvinceServiceResponsePointOfInterest pointOfInterestResponse = new ProvinceServiceResponsePointOfInterest(){
                    Id = pointOfInterest.Id,
                    Name = pointOfInterest.Name
                };

                response.PointOfInterests.Add(pointOfInterestResponse);
            }

            return response;
        }
    }
}