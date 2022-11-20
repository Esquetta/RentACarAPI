using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Rules
{
    public class GearBoxBusinessRules
    {
        private readonly IGearBoxRepository gearBoxRepository;
        public GearBoxBusinessRules(IGearBoxRepository gearBoxRepository)
        {
            this.gearBoxRepository = gearBoxRepository;
        }
        public async Task GearBoxCannotBeDuplicatedWhenInserted(string gearBoxType)
        {
            GearBox gearBox = await gearBoxRepository.GetAsync(x => x.GearType == gearBoxType);
            if (gearBox != null) throw new BusinessException("GearType name exists.");
        }
        public async Task GearBoxCannotBeDuplicatedWhenUpdated(string gearBoxType)
        {
            GearBox gearBox = await gearBoxRepository.GetAsync(x => x.GearType == gearBoxType);
            if (gearBox != null) throw new BusinessException("GearType name exists.");
        }
        public async Task<GearBox> GearBoxCheckById(int id)
        {
            GearBox gearBox = await gearBoxRepository.GetAsync(x => x.Id == id);
            if (gearBox == null) throw new BusinessException("GearType not exists.");

            return gearBox;
        }
    }
}
