﻿using Application.Featues.Fuels.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Profiles
{
    public class Profiles: Profile
    {
        public Profiles()
        {

            CreateMap<Fuel, CreatedFuelDto>().ReverseMap();
        }
    }
}