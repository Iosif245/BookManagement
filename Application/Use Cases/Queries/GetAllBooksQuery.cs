using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}