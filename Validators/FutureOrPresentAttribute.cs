using System.ComponentModel.DataAnnotations;

namespace To_Do.Validators;

public class FutureOrPresentAttribute : ValidationAttribute
{
    public FutureOrPresentAttribute()
    {
        ErrorMessage = "The field {0} must be future or present data";
    }

    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return true;
        }
        var date = (DateOnly)value;
        return date >= DateOnly.FromDateTime(DateTime.Now);
    }
}