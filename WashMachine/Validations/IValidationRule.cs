using System;
namespace WashMachine.Validations
{
    public interface IValidationRule<T>
    {
		string ValidationMessage { get; }
		bool Validate(T value);
	}
}
