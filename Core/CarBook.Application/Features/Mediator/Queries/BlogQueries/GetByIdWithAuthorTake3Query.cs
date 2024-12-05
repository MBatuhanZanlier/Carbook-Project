using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
 public class GetByIdWithAuthorTake3Query:IRequest<List<GetByIdWithAuthorTake3QueryResult>>
    {
        public int Id { get; set; }

        public GetByIdWithAuthorTake3Query(int id)
        {
            Id = id;
        }
    }
}
