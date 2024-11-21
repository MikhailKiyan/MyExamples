namespace MainProject.UnitTests.Utilities.MethodWrappers;

public class Parameter<T>(T? value = default)
    : Parameter(typeof(T), value) { }

public abstract class Parameter
{
    public Parameter(Type type, object? value)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));

        if (value is not null && value.GetType() != type)
            throw new ArgumentOutOfRangeException(nameof(value), value.GetType(), "Wrong type for value");

        this.Type = type;
        this.Value = value;
    }

    public Type Type { get; }

    public object? Value { get; }

}
