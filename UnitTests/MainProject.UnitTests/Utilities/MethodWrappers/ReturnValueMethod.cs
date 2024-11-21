namespace MainProject.UnitTests.Utilities.MethodWrappers;

using System.Reflection;

public class ReturnValueMethod<TReturn>(
        MethodInfo methodInfo,
        object @object)
    : BaseReturnValueMethodInfoWrapper<TReturn>(methodInfo, @object) { }

public class ReturnParamMethod<TReturn, TParam>(
        MethodInfo methodInfo,
        object @object,
        TParam parameter)
    : BaseReturnValueMethodInfoWrapper<TReturn>(methodInfo, @object, [new Parameter<TParam>(parameter)]) { }

public class ReturnParamMethod<TReturn, TParam1, TParam2>(
        MethodInfo methodInfo,
        object @object,
        Parameter<TParam1> parameter1,
        Parameter<TParam2> parameter2)
    : BaseReturnValueMethodInfoWrapper<TReturn>(methodInfo, @object, [parameter1, parameter2]) { }
