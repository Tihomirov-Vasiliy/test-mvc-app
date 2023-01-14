using Infrastructure.Exceptions;

namespace Infrastructure.Validators
{
    public static class ValueValidator
    {
        public static void IdValueGreaterThanZero(int id)
        {
            if (id <= 0)
                throw new InvalidInputValueException($"Значение id должно быть больше 0, фактическое значение:{id}.");
        }
    }
}
