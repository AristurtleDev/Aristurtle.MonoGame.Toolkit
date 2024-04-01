// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines the states of a game pad during the current and previous frames.
/// </summary>
public class GamePadInfo
{
    /// <summary>
    /// Gets a <see cref="PlayerIndex"/> value that represents the player this game pad is for.
    /// </summary>
    public PlayerIndex Player { get; }

    /// <summary>
    /// Gets the state of this game pad's input during the previous frame.
    /// </summary>
    public GamePadState PreviousState { get; private set; }

    /// <summary>
    /// Gets the state of this game pad's input during the current frame.
    /// </summary>
    public GamePadState CurrentState { get; private set; }

    /// <summary>
    /// Gets a value that indicates whether this game pad is currently attached.
    /// </summary>
    public bool IsAttached => CurrentState.IsConnected;

    /// <summary>
    /// Gets the state of the left thumb stick of this game pad.
    /// </summary>
    public ThumbStickInfo LeftThumbStick { get; private set; }

    /// <summary>
    /// Gets the state of the right thumb stick of this game pad.
    /// </summary>
    public ThumbStickInfo RightThumbStick { get; private set; }

    /// <summary>
    /// Gets the state of the left trigger of this game pad.
    /// </summary>
    public GamePadTriggerInfo LeftTrigger { get; private set; }

    /// <summary>
    /// Gets the state of the right trigger of this game pad.
    /// </summary>
    public GamePadTriggerInfo RightTrigger { get; private set; }

    /// <summary>
    /// Gets the state of vibration for this game pad.
    /// </summary>
    public GamePadVibrationInfo Vibration { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GamePadInfo"/> class.
    /// </summary>
    /// <param name="playerIndex">
    /// A <see cref="PlayerIndex"/> value that represents the play this game pad is for.
    /// </param>
    public GamePadInfo(PlayerIndex playerIndex)
    {
        Player = playerIndex;
        PreviousState = new GamePadState();
        CurrentState = new GamePadState();
        Vibration = new GamePadVibrationInfo(playerIndex);
        LeftThumbStick = new ThumbStickInfo();
        RightThumbStick = new ThumbStickInfo();
        LeftTrigger = new GamePadTriggerInfo();
        RightTrigger = new GamePadTriggerInfo();
    }

    internal void Update(GameTime gameTime)
    {
        PreviousState = CurrentState;
        CurrentState = GamePad.GetState((int)Player);
        LeftThumbStick.Update(CurrentState.ThumbSticks.Left);
        RightThumbStick.Update(CurrentState.ThumbSticks.Right);
        LeftTrigger.Update(CurrentState.Triggers.Left);
        RightTrigger.Update(CurrentState.Triggers.Right);
        Vibration.Update(gameTime);
    }

    /// <summary>
    /// Returns a value that indicates if the specified button is currently down.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>
    /// <see langword="true"/> if the specified button is currently down; otherwise, <see langword="false"/>.  This
    /// method will return <see langword="true"/> for every frame the button is down.
    /// </returns>
    public bool Check(Buttons button) => CurrentState.IsButtonDown(button);

    /// <summary>
    /// Returns a value that indicates if the specified button was just pressed.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>
    /// <see langword="true"/> if the specified button was just pressed; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> during the first frame the button was pressed down.
    /// </returns>
    public bool Pressed(Buttons button) => CurrentState.IsButtonDown(button) && PreviousState.IsButtonUp(button);

    /// <summary>
    /// Returns a value that indicates if the specified button was just released.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>
    /// <see langword="true"/> if the specified button was just released; otherwise, <see langword="false"/>.  This
    /// method will only return <see langword="true"/> during the first frame the button was released.
    /// </returns>
    public bool Released(Buttons button) => CurrentState.IsButtonUp(button) && PreviousState.IsButtonDown(button);
}
