using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Featues.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository brandRepository;
        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string brandName)
        {
            Brand brand = await brandRepository.GetAsync(x => x.BrandName == brandName);
            if (brand != null) throw new BusinessException("Brand name exists.");
        }
        public async Task BrandNameCannotBeDuplicatedWhenUpdated(string brandName)
        {
            Brand brand = await brandRepository.GetAsync(x => x.BrandName == brandName);
            if (brand != null) throw new BusinessException("Brand name exists.");
        }
        public async Task<Brand> BrandCheckById(int id)
        {
            Brand brand = await brandRepository.GetAsync(x => x.Id==id);
            if (brand == null) throw new BusinessException("Brand not exists.");

            return brand;
        }
    }
}
