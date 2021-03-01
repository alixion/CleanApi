using System;
using System.Threading;
using System.Threading.Tasks;
using CleanApi.Domain.Common;
using CleanApi.Domain.ToDoItems;
using MediatR;

namespace CleanApi.Application.ToDoItems
{
    public class CreateToDoCommand:IRequest<Guid>
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
    
    public  class CreateToDoCommandHandler:IRequestHandler<CreateToDoCommand,Guid>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateToDoCommandHandler(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
        {
            _toDoRepository = toDoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = new ToDoItem(request.Title, request.Note);
            await _toDoRepository.AddAsync(toDoItem);
            await _unitOfWork.CommitAsync(cancellationToken);
            return toDoItem.Id.Value;
        }
    }
}