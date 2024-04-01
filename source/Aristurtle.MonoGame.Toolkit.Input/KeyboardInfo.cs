// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework.Input;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines a model for handling keyboard input in game.
/// </summary>
public class KeyboardInfo
{
    /// <summary>
    /// Gets the current state of keyboard input.
    /// </summary>
    public KeyboardState CurrentState { get; private set; }

    /// <summary>
    /// Gets the state of keyboard input during the previous frame.
    /// </summary>
    public KeyboardState PreviousState { get; private set; }

    /// <summary>
    /// Gets a value that indicates whether NumLock is currently enabled for the keyboard input.
    /// </summary>
    public bool NumLock => CurrentState.NumLock;

    /// <summary>
    /// Gets a value that indicates whether CapsLock is currently enabled for the keyboard input.
    /// </summary>
    public bool CapsLock => CurrentState.CapsLock;

    /// <summary>
    /// An event that is triggered when the <see cref="Enabled"/> property value is changed.
    /// </summary>
    public event EventHandler<EventArgs>? EnabledChanged;

    /// <summary>
    /// An event that is triggered when the <see cref="UpdateOrder"/> property value is changed.
    /// </summary>
    public event EventHandler<EventArgs>? UpdateOrderChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyboardInfo"/> class.
    /// </summary>
    public KeyboardInfo() { }

    /// <summary>
    /// Updates the internal states of this instance of the <see cref="KeyboardInfo"/> class.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Keyboard.GetState();
    }

    /// <summary>
    /// Returns a value that indicates if the specified key is down.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="key"/> is down; otherwise, <see langword="false"/>.  This method
    /// will return <see langword="true"/> during every frame the key is down.
    /// </returns>
    public bool Check(Keys key) => CurrentState.IsKeyDown(key);

    /// <summary>
    /// Returns a value that indicates if the specified key was just pressed.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="key"/> was just pressed; otherwise, <see langword="false"/>.  This
    /// method will only return true on the first frame the key was pressed down.
    /// </returns>.  
    public bool Pressed(Keys key) => CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);

    /// <summary>
    /// Returns a value that indicates if the specified key was just released.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="key"/> was just released; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> on the first frame the key was released.
    /// </returns>
    public bool Released(Keys key) => CurrentState.IsKeyUp(key) && PreviousState.IsKeyDown(key);
}
