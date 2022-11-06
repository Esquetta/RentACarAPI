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
    }
}
