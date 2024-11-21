namespace MainProject.UnitTests.Utilities.MethodWrappers;

using System.Reflection;

public abstract class BaseMethodInfoWrapper
{
    protected readonly MethodInfo methodInfo;
    protected readonly object @object;
    protected readonly Parameter[] parameters;
    protected readonly Type returnType;

    protected BaseMethodInfoWrapper(
            MethodInfo methodInfo,
            object @object,
            Type? returnValueType = null,
            Parameter[]? parameters = null)
    {
        this.methodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
        this.@object = @object ?? throw new ArgumentNullException(nameof(@object));
        this.returnType = returnValueType ?? typeof(void);
        this.parameters = parameters ?? [];
    }

    protected object?[] GetParameterValues() =>
        this.parameters
            .Select(x => x.Value)
            .ToArray();
}

public abstract class BaseVoidMethodInfoWrapper(
        MethodInfo methodInfo,
        object @object,
        params Parameter[]? parameters)
    : BaseMethodInfoWrapper(methodInfo, @object, null, parameters)
{
    public void Invoke()
    {
        this.methodInfo.Invoke(this.@object, GetParameterValues());
    }
}

public abstract class BaseReturnValueMethodInfoWrapper<TReturn>(
        MethodInfo methodInfo,
        object @object,
        params Parameter[]? parameters)
    : BaseMethodInfoWrapper(methodInfo, @object, typeof(TReturn), parameters)
{
    public TReturn? Invoke()
    {
        return (TReturn?)this.methodInfo.Invoke(this.@object, GetParameterValues());
    }
}
