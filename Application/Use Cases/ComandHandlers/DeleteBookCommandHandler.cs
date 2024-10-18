using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"The book with ID {request.Id} not found.");
            }
            await repository.DeleteAsync(request.Id);
        }
    }
}