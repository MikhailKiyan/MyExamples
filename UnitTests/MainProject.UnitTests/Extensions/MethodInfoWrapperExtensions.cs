namespace MainProject.UnitTests.Extensions;

using MainProject.UnitTests.Utilities.MethodWrappers;

public static class MethodInfoWrapperExtensions
{
    public static VoidMethod GetVoidMethodBySignature(
            this object @object,
            string methodName)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(void), null, null);
        return new VoidMethod(mi, @object);
    }

    public static VoidMethod<TParam> GetVoidMethodBySignature<TParam>(
            this object @object,
            string methodName,
            Parameter<TParam> param)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(void), [typeof(TParam)], null);
        return new VoidMethod<TParam>(mi, @object, param);
    }

    public static VoidMethod<TParam1, TParam2> GetVoidMethodBySignature<TParam1, TParam2>(
            this object @object,
            string methodName,
            Parameter<TParam1> param1,
            Parameter<TParam2> param2)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(void), [typeof(TParam1), typeof(TParam2)], null);
        return new VoidMethod<TParam1, TParam2>(mi, @object, param1, param2);
    }

    public static ReturnValueMethod<TReturn> GetReturnParamMethod<TReturn>(
            this object @object,
            string methodName)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(TReturn), null, null);
        return new ReturnValueMethod<TReturn>(mi, @object);
    }

    public static ReturnParamMethod<TReturn, TParam> GetReturnParamMethod<TReturn, TParam>(
            this object @object,
            string methodName,
            TParam param)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(TReturn), [typeof(TParam)], null);
        return new ReturnParamMethod<TReturn, TParam>(mi, @object, param);
    }

    public static ReturnParamMethod<TReturn, TParam1, TParam2> GetReturnParamMethod<TReturn, TParam1, TParam2>(
            this object @object,
            string methodName,
            Parameter<TParam1> param1,
            Parameter<TParam2> param2)
    {
        var mi = @object.GetType().GetMethodBySignature(methodName, typeof(TReturn), [typeof(TParam1), typeof(TParam2)], null);
        return new ReturnParamMethod<TReturn, TParam1, TParam2>(mi, @object, param1, param2);
    }
}
