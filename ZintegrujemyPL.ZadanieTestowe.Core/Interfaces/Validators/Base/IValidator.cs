namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Validators.Base
{
    public interface IValidator<T>
    {
        /// <summary>
        /// Validates the model object.
        /// Throws exceptions if the provided object does not meet the requirements.
        /// </summary>
        void Validate(T model, string name = "");
    }
}
