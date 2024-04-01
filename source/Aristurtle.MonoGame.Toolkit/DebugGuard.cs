// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Aristurtle.MonoGame.Toolkit;

/// <summary>
/// Provides a set of debug guard methods for validating method arguments during development.
/// </summary>
public static class DebugGuard
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the specified value is null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check for null.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentNotNull<T>([NotNull] T? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : class => ArgumentNullException.ThrowIfNull(value);

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified string is null, empty, or consists only of
    /// white-space characters.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentNotNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (string.IsNullOrWhiteSpace(value))
        {
            ThrowArgumentException($"Cannot be null or an empty string", parameterName!);
        }
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified value is not greater than the specified
    /// value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="greaterThan">The value it must be greater than.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentGreaterThan<T>(T value, T greaterThan, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(greaterThan) <= 0)
        {
            ThrowArgumentOutOfRangeException(parameterName!, $"Value {value} must be greater than {greaterThan}.");
        }
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified value is not greater than or equal to the
    /// specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="greaterThanOrEqualTo">The value it must be greater than or equal to.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentGreaterThanOrEqualTo<T>(T value, T greaterThanOrEqualTo, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(greaterThanOrEqualTo) < 0)
        {
            ThrowArgumentOutOfRangeException(parameterName!, $"Value {value} must be greater than or equal to {greaterThanOrEqualTo}.");
        }
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified value is not less than the specified
    /// value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lessThan">The value it must be less than.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentLessThan<T>(T value, T lessThan, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(lessThan) >= 0)
        {
            ThrowArgumentOutOfRangeException(parameterName!, $"Value {value} must be less than {lessThan}.");
        }
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified value is not less than or equal to the
    /// specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lessThanOrEqualTo">The value it must be less than or equal to.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    [Conditional("DEBUG")]
    public static void ArgumentLessThanOrEqualTo<T>(T value, T lessThanOrEqualTo, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(lessThanOrEqualTo) > 0)
        {
            ThrowArgumentOutOfRangeException(parameterName!, $"Value {value} must be less than or equal to {lessThanOrEqualTo}.");
        }
    }

    /// <summary>
    /// Throws an exception of type <typeparamref name="T"/> with the specified message if the provided value is
    /// <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of exception to throw.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="message">The message for the exception.</param>
    [Conditional("DEBUG")]
    public static void AssertIsTrue<T>(bool value, string message) where T : Exception
    {
        if (!value) { ThrowException<T>(message); }
    }

    /// <summary>
    /// Throws an exception of type <typeparamref name="T"/> with the specified message if the provided value is
    /// <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of exception to throw.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="message">The message for the exception.</param>
    [Conditional("DEBUG")]
    public static void AssertIsFalse<T>(bool value, string message) where T : Exception
    {
        if (value) { ThrowException<T>(message); }
    }

    private static void ThrowArgumentException(string message, string parameterName) =>
    throw new ArgumentException(message, parameterName);

    private static void ThrowArgumentOutOfRangeException(string parameterName, string message) =>
        throw new ArgumentOutOfRangeException(parameterName, message);

    private static void ThrowException<T>(string message) where T : Exception
    {
        Type type = typeof(T);
        ConstructorInfo? constructor = type.GetConstructor(new[] { typeof(string) });
        if (constructor is not null)
        {
            throw (T)constructor.Invoke(new object[] { message });
        }

        throw new InvalidOperationException(message);
    }


}
