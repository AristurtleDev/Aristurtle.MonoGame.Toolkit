// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines the states of a game pad trigger during the current and previous frames.
/// </summary>
public class GamePadTriggerInfo
{
    private float _previousValue;
    private float _currentVlaue;

    internal GamePadTriggerInfo()
    {
        _previousValue = 0.0f;
        _currentVlaue = 0.0f;
    }

    internal void Update(float value)
    {
        _previousValue = _currentVlaue;
        _currentVlaue = value;
    }

    /// <summary>
    /// Returns the value of this game pad trigger during the previous frame.
    /// </summary>
    /// <returns>The value of this game pad trigger during the previous frame.</returns>
    public float PreviousValue() => _previousValue;

    /// <summary>
    /// Returns the value of this game pad trigger during the previous frame.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>The value of this game pad trigger during the previous frame.</returns>
    public float PreviousValue(float threshold)
    {
        if (_previousValue >= threshold)
        {
            return _previousValue;
        }

        return 0.0f;
    }

    /// <summary>
    /// Returns the value of this game pad trigger during the current frame.
    /// </summary>
    /// <returns>The value of this game pad trigger during the current frame.</returns>
    public float CurrentValue() => _currentVlaue;

    /// <summary>
    /// Returns the value of this game pad trigger during the current frame.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>The value of this game pad trigger during the current frame.</returns>
    public float CurrentValue(float threshold)
    {
        if (_currentVlaue >= threshold)
        {
            return _currentVlaue;
        }

        return 0.0f;
    }

    /// <summary>
    /// Gets the difference in value for this game pad trigger between the current and previous frames.
    /// </summary>
    /// <returns>The difference in value for this game pad trigger between the current and previous frames.</returns>
    public float DeltaValue() => CurrentValue() - PreviousValue();

    /// <summary>
    /// Gets the difference in value for this game pad trigger between the current and previous frames.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>The difference in value for this game pad trigger between the current and previous frames.</returns>
    public float DeltaValue(float threshold) => CurrentValue(threshold) - PreviousValue(threshold);

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was moved between the current and previous frames.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger was moved between the current and previous frames; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool HasMoved() => DeltaValue() > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was moved between the current and previous frames.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger was moved between the current and previous frames; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool HasMoved(float threshold) => DeltaValue(threshold) > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger is current down.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger is currently down; otherwise, <see langword="false"/>.  This
    /// method will return <see langword="true"/> for every frame this game pad trigger is down.
    /// </returns>
    public bool Check() => CurrentValue() > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger is current down.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger is currently down; otherwise, <see langword="false"/>.  This
    /// method will return <see langword="true"/> for every frame this game pad trigger is down.
    /// </returns>
    public bool Check(float threshold) => CurrentValue(threshold) > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was just pressed down.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger is currently down; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> only on the first frame this game pad trigger was pressed down.
    /// </returns>
    public bool Pressed() => Check() && PreviousValue() < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was just pressed down.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger is currently down; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> only on the first frame this game pad trigger was pressed down.
    /// </returns>
    public bool Pressed(float threshold) => CurrentValue(threshold) < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was just released.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger was just released ; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> only on the first frame this game pad trigger was released/
    /// </returns>
    public bool Released() => !Check() && PreviousValue() > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this game pad trigger was just released.
    /// </summary>
    /// <param name="threshold">
    /// The minimum value this game pad trigger must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this game pad trigger was just released ; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> only on the first frame this game pad trigger was released/
    /// </returns>
    public bool Released(float threshold) => !CurrentValue(threshold) > float.Epsilon;
}
