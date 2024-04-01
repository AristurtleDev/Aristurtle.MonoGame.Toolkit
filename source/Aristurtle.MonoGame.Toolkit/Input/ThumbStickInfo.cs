// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines the state of a thumb stick's input during the current and previous frames.
/// </summary>
public class ThumbStickInfo
{
    private Vector2 _previousValue;
    private Vector2 _currentValue;

    internal ThumbStickInfo()
    {
        _previousValue = Vector2.Zero;
        _currentValue = Vector2.Zero;
    }

    internal void Update(Vector2 value)
    {
        _previousValue = _currentValue;
        _currentValue = value;

        //  Flip the y-axis value
        _currentValue.Y = -_currentValue.Y;
    }

    /// <summary>
    /// Returns the value of this thumb stick during the previous frame.
    /// </summary>
    /// <returns>The value of this thumb stick during the previous frame.</returns>
    public Vector2 PreviousValue() => _previousValue;

    /// <summary>
    /// Returns the value of this thumb stuck during the previous frame.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// The value of this thumb stuck during the previous frame, if the value exceeds the specified
    /// <paramref name="deadZone"/> parameter; otherwise, <see cref="Vector2.Zero"/>.
    /// </returns>
    public Vector2 PreviousValue(float deadZone)
    {
        if (_previousValue.LengthSquared() >= deadZone * deadZone)
        {
            return _previousValue;
        }

        return Vector2.Zero;
    }

    /// <summary>
    /// Returns the value of this thumb stick during the current frame.
    /// </summary>
    /// <returns>The value of this thumb stick during the current frame.</returns>
    public Vector2 CurrentValue() => _currentValue;

    /// <summary>
    /// Returns the value this this thumb stick during the current frame.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// The value of this thumb stuck during the current frame, if the value exceeds the specified
    /// <paramref name="deadZone"/> parameter; otherwise, <see cref="Vector2.Zero"/>.
    /// </returns>
    public Vector2 CurrentValue(float deadZone)
    {
        if (_currentValue.LengthSquared() >= deadZone * deadZone)
        {
            return _currentValue;
        }

        return Vector2.Zero;
    }

    /// <summary>
    /// Returns the difference in this thumb stick's value between the current and previous frames.
    /// </summary>
    /// <returns>The difference in this thumb stick's value between the current and previous frames.</returns>
    public Vector2 DeltaValue() => CurrentValue() - PreviousValue();

    /// <summary>
    /// Returns the difference in this thumb stick's value between the current and previous frames.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>The difference in this thumb stick's value between the current and previous frames.</returns>
    public Vector2 DeltaValue(float deadZone) => CurrentValue(deadZone) - PreviousValue(deadZone);

    /// <summary>
    /// Returns a value that indicates whether this thumb stick has moved between the current and previous frames.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick has moved between the current and previous frames; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool HasMoved() => DeltaValue() != Vector2.Zero;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick has moved between the current and previous frames.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick has moved between the current and previous frames; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool HasMoved(float deadZone) => DeltaValue(deadZone) != Vector2.Zero;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an upward direction
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an upward direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckUp() => CurrentValue().Y > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an upward direction
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an upward direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckUp(float deadZone) => CurrentValue(deadZone).Y > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an downward direction
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an downward direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckDown() => CurrentValue().Y < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an downward direction
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an downward direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckDown(float deadZone) => CurrentValue(deadZone).Y < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an the left direction
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an the left direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckLeft() => CurrentValue().X < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an the left direction
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an the left direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckLeft(float deadZone) => CurrentValue(deadZone).X < float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an the right direction
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an the right direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckRight() => CurrentValue().X > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates whether this thumb stick is moved in an the right direction
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick is moved in an the right direction; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool CheckRight(float deadZone) => CurrentValue(deadZone).X > float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in an upward direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in an upward direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved upward.
    /// </returns>
    public bool PressedUp() => CheckUp() && PreviousValue().Y <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in an upward direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in an upward direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved upward.
    /// </returns>
    public bool PressedUp(float deadZone) => CheckUp(deadZone) && PreviousValue(deadZone).Y <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in an downward direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in an downward direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved downward.
    /// </returns>
    public bool PressedDown() => CheckDown() && PreviousValue().Y >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in an downward direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in an downward direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved downward.
    /// </returns>
    public bool PressedDown(float deadZone) => CheckDown(deadZone) && PreviousValue(deadZone).Y >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in a left direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in a left direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved left.
    /// </returns>
    public bool PressedLeft() => CheckLeft() && PreviousValue().X >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in a left direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in a left direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved left.
    /// </returns>
    public bool PressedLeft(float deadZone) => CheckLeft(deadZone) && PreviousValue(deadZone).X >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in a right direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in a right direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved right.
    /// </returns>
    public bool PressedRight() => CheckRight() && PreviousValue().X <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just moved in a right direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just moved in a right direction; otherwise,
    /// <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame this thumb
    /// stick was moved right.
    /// </returns>
    public bool PressedRight(float deadZone) => CheckRight(deadZone) && PreviousValue(deadZone).X <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in an upward
    /// direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in an upward direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedUp() => !CheckUp() && PreviousValue().Y >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in an upward
    /// direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in an upward direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedUp(float deadZone) => !CheckUp(deadZone) && PreviousValue(deadZone).Y >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in an downward
    /// direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in an downward direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedDown() => !CheckDown() && PreviousValue().Y <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in an downward
    /// direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in an downward direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedDown(float deadZone) => !CheckDown(deadZone) && PreviousValue(deadZone).Y <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in a left
    /// direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in a left direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedLeft() => !CheckLeft() && PreviousValue().X <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in a left
    /// direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in a left direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedLeft(float deadZone) => !CheckLeft(deadZone) && PreviousValue(deadZone).X <= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in a right
    /// direction.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in a right direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedRight() => !CheckRight() && PreviousValue().X >= float.Epsilon;

    /// <summary>
    /// Returns a value that indicates if this thumb stick was just released from being pressed in a right
    /// direction.
    /// </summary>
    /// <param name="deadZone">
    /// The minimum value the thumb stick must exceed to be considered a non-zero value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if this thumb stick was just released from being pressed in an right direction;
    /// otherwise, <see langword="false"/>.  This method only returns <see langword="true"/> for the first frame
    /// this thumb stick was released.
    /// </returns>
    public bool ReleasedRight(float deadZone) => !CheckRight(deadZone) && PreviousValue(deadZone).X >= float.Epsilon;
}
