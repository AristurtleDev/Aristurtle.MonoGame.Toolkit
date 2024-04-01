// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines a model for handling mouse input in game.
/// </summary>
public class MouseInfo
{
    /// <summary>
    /// Gets the current state of mouse input.
    /// </summary>
    public MouseState CurrentState { get; private set; }

    /// <summary>
    /// Gets the state of mouse input during the previous frame.
    /// </summary>
    public MouseState PreviousState { get; private set; }

    /// <summary>
    /// Gets the position of the mouse cursor during the current frame.
    /// </summary>
    public Point Position => CurrentState.Position;

    /// <summary>
    /// Gets the position of the mouse cursor during the previous frame.
    /// </summary>
    public Point PreviousPosition => PreviousState.Position;

    /// <summary>
    /// Gets the difference in position of the mouse cursor between the current and previous frames.
    /// </summary>
    public Point PositionDelta => Position - PreviousPosition;

    /// <summary>
    /// Gets a value that indicates whether the mouse cursor has moved position between the current and previous
    /// frames.
    /// </summary>
    public bool HasMoved => PositionDelta != Point.Zero;

    /// <summary>
    /// Gets the current value of the mouse's scroll wheel.
    /// </summary>
    public int ScrollWheelValue => CurrentState.ScrollWheelValue;

    /// <summary>
    /// Gets the difference in the scroll wheel value for the mouse between the current and previous frames.
    /// </summary>
    public int ScrollWheelDelta => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="MouseInfo"/> class.
    /// </summary>
    public MouseInfo()
    {
        CurrentState = new MouseState();
        PreviousState = new MouseState();
    }

    /// <summary>
    /// Updates the internal states of this instance of the <see cref="MouseInfo"/> class.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Mouse.GetState();
    }

    /// <summary>
    /// Returns a value that indicates if the specified mouse button is down.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="button"/> is down; otherwise, <see langword="false"/>.  This method
    /// will return <see langword="true"/> during every frame the button is down.
    /// </returns>
    public bool Check(MouseButton button) => button switch
    {
        #pragma warning disable format
        MouseButton.LeftButton      => CurrentState.LeftButton == ButtonState.Pressed,
        MouseButton.MiddleButton    => CurrentState.MiddleButton == ButtonState.Pressed,
        MouseButton.RightButton     => CurrentState.RightButton == ButtonState.Pressed,
        MouseButton.XButton1        => CurrentState.XButton1 == ButtonState.Pressed,
        MouseButton.XButton2        => CurrentState.XButton2 == ButtonState.Pressed,
        _                           => false
        #pragma warning restore format
    };

    /// <summary>
    /// Returns a value that indicates if the specified mouse button was just pressed.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="button"/> was just pressed; otherwise, <see langword="false"/>.  This
    /// method will only return true on the first frame the button was pressed.
    /// </returns>.
    public bool Pressed(MouseButton button) => button switch
    {
        #pragma warning disable format
        MouseButton.LeftButton      => CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released,
        MouseButton.MiddleButton    => CurrentState.MiddleButton == ButtonState.Pressed && PreviousState.MiddleButton == ButtonState.Released,
        MouseButton.RightButton     => CurrentState.RightButton == ButtonState.Pressed && PreviousState.RightButton == ButtonState.Released,
        MouseButton.XButton1        => CurrentState.XButton1 == ButtonState.Pressed && PreviousState.XButton1 == ButtonState.Released,
        MouseButton.XButton2        => CurrentState.XButton2 == ButtonState.Pressed && PreviousState.XButton2 == ButtonState.Released,
        _                           => false
        #pragma warning restore format
    };

    /// <summary>
    /// Returns a value that indicates if the specified mouse button was just released.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="button"/> was just released; otherwise, <see langword="false"/>.
    /// This method will only return true on the first frame the button was released.
    /// </returns>.
    public bool Released(MouseButton button) => button switch
    {
        #pragma warning disable format
        MouseButton.LeftButton      => CurrentState.LeftButton == ButtonState.Released && PreviousState.LeftButton == ButtonState.Pressed,
        MouseButton.MiddleButton    => CurrentState.MiddleButton == ButtonState.Released && PreviousState.MiddleButton == ButtonState.Pressed,
        MouseButton.RightButton     => CurrentState.RightButton == ButtonState.Released && PreviousState.RightButton == ButtonState.Pressed,
        MouseButton.XButton1        => CurrentState.XButton1 == ButtonState.Released && PreviousState.XButton1 == ButtonState.Pressed,
        MouseButton.XButton2        => CurrentState.XButton2 == ButtonState.Released && PreviousState.XButton2 == ButtonState.Pressed,
        _                           => false
        #pragma warning restore format
    };

    /// <summary>
    /// Sets the current position of the mouse to the specific point.
    /// </summary>
    /// <param name="to">The position to set the mouse cursor to.</param>
    public void SetPosition(Point to) => SetPosition(to.X, to.Y);

    /// <summary>
    /// Sets the current position of the mouse to the specified point.
    /// </summary>
    /// <param name="x">The x-coordinate position to ste the mouse cursor to.</param>
    /// <param name="y">The y-coordinate position to set the mouse cursor to.</param>
    public void SetPosition(int x, int y)
    {
        Mouse.SetPosition(x, y);
        CurrentState = new MouseState(x,
                                      y,
                                      CurrentState.ScrollWheelValue,
                                      CurrentState.LeftButton,
                                      CurrentState.MiddleButton,
                                      CurrentState.RightButton,
                                      CurrentState.XButton1,
                                      CurrentState.XButton2,
                                      CurrentState.HorizontalScrollWheelValue);

    }
}
