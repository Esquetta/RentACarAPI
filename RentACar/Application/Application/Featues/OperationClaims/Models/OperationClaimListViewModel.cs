using Application.Featues.OperationClaims.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.OperationClaims.Models
{
    public class OperationClaimListViewModel
    {
        public List<OperationClaimListViewDto> Items { get; set; }
    }
}
