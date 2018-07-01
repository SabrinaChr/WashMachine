using System;

namespace WashMachine.Validations
{
	public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
		public string ValidationMessage { get; set; }  

        public bool Validate(T value)  
        {  
            if (value == null)  
            {  
                return false;  
            }  

			var str = value as string; 

            return !string.IsNullOrWhiteSpace(str);  
        }  
    }
}
