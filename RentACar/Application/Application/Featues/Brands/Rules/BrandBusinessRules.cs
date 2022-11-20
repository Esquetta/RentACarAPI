using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository gearBoxRepository;
        public BrandBusinessRules(IBrandRepository gearBoxRepository)
        {
            this.gearBoxRepository = gearBoxRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string brandName)
        {
            Brand brand = await gearBoxRepository.GetAsync(x => x.BrandName == brandName);
            if (brand != null) throw new BusinessException("Brand name exists.");
        }
        public async Task BrandNameCannotBeDuplicatedWhenUpdated(string brandName)
        {
            Brand brand = await gearBoxRepository.GetAsync(x => x.BrandName == brandName);
            if (brand != null) throw new BusinessException("Brand name exists.");
        }
        public async Task<Brand> BrandCheckById(int id)
        {
            Brand brand = await gearBoxRepository.GetAsync(x => x.Id==id);
            if (brand == null) throw new BusinessException("Brand not exists.");

            return brand;
        }
    }
}
