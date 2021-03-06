using System;
using System.Threading;
using System.Threading.Tasks;
using CleanApi.Application.Common.Exceptions;
using CleanApi.Domain.Common;
using CleanApi.Domain.ToDoItems;
using MediatR;

namespace CleanApi.Application.ToDoItems
{
    public class MarkAsDoneCommand:IRequest
    {
        public MarkAsDoneCommand(ToDoItemId id)
        {
            Id = id;
        }
        public ToDoItemId Id { get; set; }
    }
    
    public class MarkAsDoneCommandHandler:IRequestHandler<MarkAsDoneCommand>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarkAsDoneCommandHandler(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
        {
            _toDoRepository = toDoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(MarkAsDoneCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await _toDoRepository.GetByIdAsync(request.Id);
            
            if(toDoItem==null)
                throw new NotFoundException(nameof(ToDoItem), request.Id);
            
            toDoItem.MarkDone();
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}