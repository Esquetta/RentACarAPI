using Application.Featues.Photos.Dtos;
using Application.Featues.Photos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommand:IRequest<DeletedPhotoDto>
    {
        public int Id { get; set; }


        public class DeletePhotoCommandHandler:IRequestHandler<DeletePhotoCommand, DeletedPhotoDto>
        {
            private readonly IPhotoRepository photoRepository;
            private readonly IMapper mapper;
            private readonly PhotoBusinessRules photosBusinessRules;
            public DeletePhotoCommandHandler(IPhotoRepository photoRepository, IMapper mapper, PhotoBusinessRules photosBusinessRules)
            {
                this.photoRepository = photoRepository;
                this.mapper = mapper;
                this.photosBusinessRules = photosBusinessRules;
            }

            public async  Task<DeletedPhotoDto> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
            {
                Photo photo  = await photosBusinessRules.PhotoCheckById(request.Id);

                Photo deletedPhoto = await photoRepository.DeleteAsync(photo);

                DeletedPhotoDto deletedPhotoDto  =  mapper.Map<DeletedPhotoDto>(deletedPhoto);

                return deletedPhotoDto;
            }
        }
    }
}
