using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Features.Results;

public class GetFeatureByIdQueryResult
{
    public int FeatureId { get; set; }
    public string Name { get; set; }
}
