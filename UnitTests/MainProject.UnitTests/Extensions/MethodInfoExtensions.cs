using System.Reflection;

namespace MainProject.UnitTests.Extensions;

public static class MethodInfoExtensions
{
    public static MethodInfo GetMethodBySignature(
            this Type type,
            string methodName,
            Type returnType,
            IEnumerable<Type>? parameterTypes = null,
            IEnumerable<Type>? genericArgumentTypes = null)
    {
        return type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(mi =>
            {
                var parameters = mi.GetParameters();
                if (mi.Name != methodName)
                    return false;
                else if (mi.ReturnType != returnType)
                    return false;
                else if (parameterTypes is null || !parameterTypes.Any())
                    return parameters.Length == 0;
                else if (parameters.Length != parameterTypes.Count())
                    return false;
                else if (!parameters.Select(x => x.ParameterType)
                                    .Zip(parameterTypes)
                                    .All(x => x.First == x.Second))
                    return false;
                else return true;
            })
            .Single();
    }
}
