using Application.Featues.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand:IRequest<DeletedBrandDto>
    {
        public int Id { get; set; }


        class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
        {
            private readonly IBrandRepository brandRepository;
            private readonly IMapper mapper;
            private readonly BrandBusinessRules brandBusinessRules;
            public DeleteBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper,BrandBusinessRules brandBusinessRules)
            {
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
                this.brandRepository = brandRepository;
            }

            public async Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
