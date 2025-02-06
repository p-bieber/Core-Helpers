using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace Bieber.Core.Helpers;

/// <summary>
/// Provides helper methods for object manipulation and validation.
/// </summary>
public static class ObjectHelper
{
    /// <summary>
    /// Ensures that the specified type is not abstract.
    /// </summary>
    /// <typeparam name="T">The type to check.</typeparam>
    /// <exception cref="InvalidOperationException">Thrown if the type is abstract.</exception>
    public static void EnsureNotAbstract<T>()
    {
        if (typeof(T).IsAbstract)
        {
            throw new InvalidOperationException($"Ensure method failed for {typeof(T).Name} because it is an abstract class.");
        }
    }

    /// <summary>
    /// Ensures that the specified object is not null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
    public static void EnsureNotNull(object? obj, string parameterName)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(parameterName, "Value cannot be null.");
        }
    }

    /// <summary>
    /// Creates a deep clone of the specified object using JSON serialization.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="obj">The object to clone.</param>
    /// <returns>A deep clone of the specified object.</returns>
    public static T DeepClone<T>(T obj)
    {
        string json = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(json)!;
    }

    /// <summary>
    /// Determines whether the specified object is of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to check.</typeparam>
    /// <param name="obj">The object to check.</param>
    /// <returns>true if the object is of the specified type; otherwise, false.</returns>
    public static bool IsOfType<T>(object obj)
    {
        return obj is T;
    }

    /// <summary>
    /// Attempts to convert the specified string representation of a logical value to its equivalent strongly-typed value.
    /// </summary>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <param name="input">The string to convert.</param>
    /// <param name="result">When this method returns, contains the strongly-typed value equivalent of the logical value contained in input, if the conversion succeeded, or the default value of the type if the conversion failed.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>true if input was converted successfully; otherwise, false.</returns>
    public static bool TryParse<T>(string input, out T result, IFormatProvider? provider = null)
    {
        try
        {
            result = (T)Convert.ChangeType(input, typeof(T), provider ?? CultureInfo.InvariantCulture);
            return true;
        }
        catch
        {
            result = default!;
            return false;
        }
    }

    /// <summary>
    /// Checks if the specified object is null or the default value for its type.
    /// </summary>
    /// <typeparam name="T">The type to check.</typeparam>
    /// <param name="value">The object to check.</param>
    /// <returns>true if the object is null or the default value for its type; otherwise, false.</returns>
    public static bool IsNullOrDefault<T>(T value)
    {
        return EqualityComparer<T>.Default.Equals(value, default);
    }

    /// <summary>
    /// Retrieves the value of a specified property from an object.
    /// </summary>
    /// <param name="obj">The object that contains the property.</param>
    /// <param name="propertyName">The name of the property whose value is to be retrieved.</param>
    /// <returns>The value of the specified property, or null if the property does not exist.</returns>
    public static object? GetPropertyValue(object obj, string propertyName)
    {
        PropertyInfo? propInfo = obj.GetType().GetProperty(propertyName);
        return propInfo?.GetValue(obj, null);
    }

    /// <summary>
    /// Sets the value of a specified property on an object.
    /// </summary>
    /// <param name="obj">The object that contains the property.</param>
    /// <param name="propertyName">The name of the property whose value is to be set.</param>
    /// <param name="value">The new value for the property.</param>
    public static void SetPropertyValue(object obj, string propertyName, object? value)
    {
        PropertyInfo? propInfo = obj.GetType().GetProperty(propertyName);
        propInfo?.SetValue(obj, value, null);
    }
}
