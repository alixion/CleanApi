using System;
using System.Diagnostics.CodeAnalysis;
using CleanApi.Domain.Common;
using Light.GuardClauses;

namespace CleanApi.Domain.ToDoItems
{
#nullable enable
    public class ToDoItem : AuditableEntity
    {
        public ToDoItemId Id { get; private set; }
        public string Title { get; private set; }
        public string? Note { get; private set; }
        public bool Done { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeleteDate { get; set; }

        public ToDoItem(string title, string note)
        {
            title.MustNotBeNullOrWhiteSpace(nameof(title));
            
            Id = new ToDoItemId(Guid.NewGuid());
            Title = title;
            Note = note;
            AddDomainEvent(new ToDoItemCreatedEvent(Id));
        }

        public void UpdateDetails(string title, string note)
        {
            title.MustNotBeNullOrWhiteSpace(nameof(title));
            
            Title = title;
            Note = note;
        }

        public void MarkDone()
        {
            if(!Done)
                Done = true;
        }

        public void MarkUndone()
        {
            if(Done)
                Done = false;
        }

        public void Delete()
        {
            if (IsDeleted)
                return;
            IsDeleted = true;
            DeleteDate = DateTimeOffset.Now;
        }


    }
}