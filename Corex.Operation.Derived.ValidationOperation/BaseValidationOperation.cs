﻿using Corex.Operation.Infrastructure;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Operation.Derived.ValidationOperation
{
    public abstract class BaseValidationOperation<T> : IValidationOperation<T>
           where T : class
    {
        public T Item { get; set; }
        //public BaseValidationOperation(T item)
        //{
        //    ItemDto = item;
        //}
        public BaseValidationOperation()
        {
            Item = SetItem();
        }
        public abstract T SetItem();
        public abstract List<ValidationBase<T>> GetValidations();
        public virtual List<ValidationMessage> GetValidationResults()
        {
            List<ValidationMessage> messages = new List<ValidationMessage>();
            foreach (ValidationBase<T> validationBase in GetValidations())
            {
                if (!validationBase.IsValid)
                {
                    messages.AddRange(validationBase.Messages);
                }
            }
            return messages;
        }
    }
}
