using Application.Featues.Photos.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest<CreatedPhotoDto>
    {
        public int CarId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, CreatedPhotoDto>
        {
            private readonly IPhotoRepository photoRepository;
            private readonly IMapper mapper;
            public CreatePhotoCommandHandler(IPhotoRepository photoRepository, IMapper mapper)
            {
                this.photoRepository = photoRepository;
                this.mapper = mapper;
            }

            public async Task<CreatedPhotoDto> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
            {
                Photo photo = mapper.Map<Photo>(request);

                Photo createdPhoto = await photoRepository.AddAsync(photo);

                CreatedPhotoDto createdPhotoDto = mapper.Map<CreatedPhotoDto>(createdPhoto);

                return createdPhotoDto;
            }
        }
    }
}
