namespace MainProject.UnitTests.Utilities.MethodWrappers;

using System.Reflection;

public class VoidMethod(
        MethodInfo methodInfo,
        object @object)
    : BaseVoidMethodInfoWrapper(methodInfo, @object) { }

public class VoidMethod<TParam>(
        MethodInfo methodInfo,
        object @object,
        Parameter<TParam> parameter)
    : BaseVoidMethodInfoWrapper(methodInfo, @object, [parameter]) { }

public class VoidMethod<TParam1, TParam2>(
        MethodInfo methodInfo,
        object @object,
        Parameter<TParam1> parameter1,
        Parameter<TParam2> parameter2)
    : BaseVoidMethodInfoWrapper(methodInfo, @object, [parameter1, parameter2]) { }
