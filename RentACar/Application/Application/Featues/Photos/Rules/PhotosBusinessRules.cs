using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Rules
{
    public class PhotosBusinessRules
    {
        private readonly IPhotoRepository photoRepository;
        public PhotosBusinessRules(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        public async Task PhotoCheckById(int id)
        {
            Photo photo = await photoRepository.GetAsync(x => x.Id == id);
            if (photo == null) throw new BusinessException("Photo not exists.");

            
        }
    }
}
