using CarBook.Application.Features.Mediator.Results.FooterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries
{
    public class GetFooterQuery:IRequest<List<GetFooterQueryResult>>
    {
    }
}
