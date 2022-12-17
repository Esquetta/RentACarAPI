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

namespace Application.Featues.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommand : IRequest<UpdatedPhotoDto>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, UpdatedPhotoDto>
        {
            private readonly IPhotoRepository photoRepository;
            private readonly IMapper mapper;
            private readonly PhotosBusinessRules photosBusinessRules;
            public UpdatePhotoCommandHandler(IPhotoRepository photoRepository, IMapper mapper)
            {
                this.photoRepository = photoRepository;
                this.mapper = mapper;
            }

            public async Task<UpdatedPhotoDto> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
            {
                await photosBusinessRules.PhotoCheckById(request.Id);

                Photo photo = mapper.Map<Photo>(request);

                Photo updatedPhoto = await photoRepository.UpdateAsync(photo);

                UpdatedPhotoDto updatedPhotoDto = mapper.Map<UpdatedPhotoDto>(updatedPhoto);

                return updatedPhotoDto;

            }
        }
    }
}
