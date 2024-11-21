namespace MainProject.UnitTests;

using Extensions;

public class MyClass_PrivateMathodWithOneParameter_UnitTests
{
    [Fact(DisplayName = "Using default constructor")]
    public void UsingDefaultConstruction()
    {
        var obj = new MyClass();
        var method = obj.GetReturnParamMethod<string, int>("PrivateMethod", 2);
        var returnValue = method.Invoke();
        Assert.Equal("Default greeting! Argument is 2", returnValue);
    }

    [Fact(DisplayName = "Using custom constructor")]
    public void UsingCustomConstruction()
    {
        var obj = new MyClass("Custom!");
        var method = obj.GetReturnParamMethod<string, int>("PrivateMethod", 22);
        var returnValue = method.Invoke();
        Assert.Equal("Custom! Argument is 22", returnValue);
    }
}