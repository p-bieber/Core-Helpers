using System.Globalization;

namespace Bieber.Core.Helpers.Tests;

public class ObjectHelperTests
{
    [Fact]
    public void EnsureNotAbstract_ShouldThrowException_WhenTypeIsAbstract()
    {
        Should.Throw<InvalidOperationException>(() => ObjectHelper.EnsureNotAbstract<AbstractClass>())
            .Message.ShouldBe("Ensure method failed for AbstractClass because it is an abstract class.");
    }

    [Fact]
    public void EnsureNotAbstract_ShouldNotThrowException_WhenTypeIsNotAbstract()
    {
        Should.NotThrow(() => ObjectHelper.EnsureNotAbstract<ConcreteClass>());
    }

    [Fact]
    public void EnsureNotNull_ShouldThrowArgumentNullException_WhenObjectIsNull()
    {
        Should.Throw<ArgumentNullException>(() => ObjectHelper.EnsureNotNull(null, "testParameter"))
            .ParamName.ShouldBe("testParameter");
    }

    [Fact]
    public void EnsureNotNull_ShouldNotThrowException_WhenObjectIsNotNull()
    {
        Should.NotThrow(() => ObjectHelper.EnsureNotNull(new object(), "testParameter"));
    }

    [Fact]
    public void IsOfType_ShouldReturnTrue_WhenObjectIsOfType()
    {
        bool result = ObjectHelper.IsOfType<string>("test");
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsOfType_ShouldReturnFalse_WhenObjectIsNotOfType()
    {
        bool result = ObjectHelper.IsOfType<string>(123);
        result.ShouldBeFalse();
    }

    [Fact]
    public void DeepClone_ShouldReturnExactCopy()
    {
        TestClass original = new() { Property = "Value" };
        TestClass clone = ObjectHelper.DeepClone(original);

        clone.ShouldNotBeSameAs(original);
        clone.Property.ShouldBe(original.Property);
    }

    [Fact]
    public void TryParse_ShouldReturnTrue_WhenInputIsValid()
    {
        bool result = ObjectHelper.TryParse("123", out int parsedValue);
        result.ShouldBeTrue();
        parsedValue.ShouldBe(123);
    }

    [Fact]
    public void TryParse_ShouldReturnFalse_WhenInputIsInvalid()
    {
        bool result = ObjectHelper.TryParse("abc", out int parsedValue);
        result.ShouldBeFalse();
        parsedValue.ShouldBe(default);
    }

    [Fact]
    public void TryParse_WithFormatProvider_ShouldReturnTrue_WhenInputIsValid()
    {
        bool result = ObjectHelper.TryParse("123.45", out decimal parsedValue, CultureInfo.InvariantCulture);
        result.ShouldBeTrue();
        parsedValue.ShouldBe(123.45M);
    }

    [Fact]
    public void TryParse_WithFormatProvider_ShouldReturnFalse_WhenInputIsInvalid()
    {
        bool result = ObjectHelper.TryParse("abc", out decimal parsedValue, CultureInfo.InvariantCulture);
        result.ShouldBeFalse();
        parsedValue.ShouldBe(default);
    }

    [Fact]
    public void IsNullOrDefault_ShouldReturnTrue_WhenValueIsNullOrDefault()
    {
        bool result = ObjectHelper.IsNullOrDefault(0);
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrDefault_ShouldReturnFalse_WhenValueIsNotDefault()
    {
        bool result = ObjectHelper.IsNullOrDefault(123);
        result.ShouldBeFalse();
    }

    [Fact]
    public void GetPropertyValue_ShouldReturnPropertyValue()
    {
        TestClass testObj = new() { Property = "Value" };
        object? value = ObjectHelper.GetPropertyValue(testObj, "Property");
        value.ShouldBe("Value");
    }

    [Fact]
    public void SetPropertyValue_ShouldSetPropertyValue()
    {
        TestClass testObj = new() { Property = "Value" };
        ObjectHelper.SetPropertyValue(testObj, "Property", "NewValue");
        testObj.Property.ShouldBe("NewValue");
    }

    private abstract class AbstractClass { }
    private sealed class ConcreteClass { }
    private sealed class TestClass
    {
        public string Property { get; set; }
    }
}
