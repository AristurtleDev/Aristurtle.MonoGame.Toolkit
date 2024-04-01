// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Defines the state of a game pad's vibration.
/// </summary>
public class GamePadVibrationInfo
{
    private readonly PlayerIndex _playerIndex;
    private float _leftMotor;
    private float _rightMotor;
    private float _leftTrigger;
    private float _rightTrigger;
    private TimeSpan _leftMotorTimeRemaining;
    private TimeSpan _rightMotorTimeRemaining;
    private TimeSpan _leftTriggerTimeRemaining;
    private TimeSpan _rightTriggerTimeRemaining;

    internal GamePadVibrationInfo(PlayerIndex playerIndex)
    {
        _playerIndex = playerIndex;
        _leftMotorTimeRemaining = TimeSpan.Zero;
        _rightMotorTimeRemaining = TimeSpan.Zero;
        _leftTriggerTimeRemaining = TimeSpan.Zero;
        _rightTriggerTimeRemaining = TimeSpan.Zero;
    }

    internal void Update(GameTime gameTime)
    {
        Update(ref _leftMotor, ref _leftMotorTimeRemaining, gameTime);
        Update(ref _rightMotor, ref _rightMotorTimeRemaining, gameTime);
        Update(ref _leftTrigger, ref _leftTriggerTimeRemaining, gameTime);
        Update(ref _rightTrigger, ref _rightTriggerTimeRemaining, gameTime);
        Vibrate();
    }

    private static void Update(ref float value, ref TimeSpan timeRemaining, GameTime gameTime)
    {
        if (timeRemaining > TimeSpan.Zero)
        {
            timeRemaining -= gameTime.ElapsedGameTime;
            if (timeRemaining <= TimeSpan.Zero)
            {
                value = 0.0f;
            }
        }
    }

    /// <summary>
    /// Informs the left motor to vibrate at the specified strength for the specified duration.
    /// </summary>
    /// <param name="strength">The strength at which to vibrate, from 0.0f to 1.0f.</param>
    /// <param name="duration">The total amount of time to vibrate.</param>
    public void VibrateLeftMotor(float strength, TimeSpan duration)
    {
        _leftMotor = strength;
        _leftMotorTimeRemaining = duration;
        Vibrate();
    }

    /// <summary>
    /// Informs the right motor to vibrate at the specified strength for the specified duration.
    /// </summary>
    /// <param name="strength">The strength at which to vibrate, from 0.0f to 1.0f.</param>
    /// <param name="duration">The total amount of time to vibrate.</param>
    public void VibrateRightMotor(float strength, TimeSpan duration)
    {
        _rightMotor = strength;
        _rightMotorTimeRemaining = duration;
        Vibrate();
    }

    /// <summary>
    /// Informs the left trigger motor to vibrate at the specified strength for the specified duration.
    /// </summary>
    /// <param name="strength">The strength at which to vibrate, from 0.0f to 1.0f.</param>
    /// <param name="duration">The total amount of time to vibrate.</param>
    public void VibrateLeftTrigger(float strength, TimeSpan duration)
    {
        _leftTrigger = strength;
        _leftTriggerTimeRemaining = duration;
        Vibrate();
    }

    /// <summary>
    /// Informs the right trigger motor to vibrate at the specified strength for the specified duration.
    /// </summary>
    /// <param name="strength">The strength at which to vibrate, from 0.0f to 1.0f.</param>
    /// <param name="duration">The total amount of time to vibrate.</param>
    public void VibrateRightTrigger(float strength, TimeSpan duration)
    {
        _rightTrigger = strength;
        _rightTriggerTimeRemaining = duration;
        Vibrate();
    }

    /// <summary>
    /// Informs all motors to vibrate at the specified strength for the specified duration.
    /// </summary>
    /// <param name="strength">The strength at which to vibrate, from 0.0f to 1.0f.</param>
    /// <param name="duration">The total amount of time to vibrate.</param>
    public void Vibrate(float strength, TimeSpan duration)
    {
        _leftMotor = _rightMotor = _leftTrigger = _rightTrigger = strength;
        _leftMotorTimeRemaining = _rightMotorTimeRemaining = _leftTriggerTimeRemaining = _rightTriggerTimeRemaining = duration;
        Vibrate();
    }

    /// <summary>
    /// Informs the left motor to stop vibrating.
    /// </summary>
    public void StopLeftMotor() => VibrateLeftMotor(0.0f, TimeSpan.Zero);

    /// <summary>
    /// Informs the right motor to stop vibrating.
    /// </summary>
    public void StopRightMotor() => VibrateRightMotor(0.0f, TimeSpan.Zero);

    /// <summary>
    /// Informs the left trigger motor to stop vibrating.
    /// </summary>
    public void StopLeftTrigger() => VibrateLeftTrigger(0.0f, TimeSpan.Zero);

    /// <summary>
    /// Informs the right trigger motor to stop vibrating.
    /// </summary>
    public void StopRightTrigger() => VibrateRightMotor(0.0f, TimeSpan.Zero);

    internal void Vibrate() => GamePad.SetVibration(_playerIndex, _leftMotor, _rightMotor, _leftTrigger, _rightTrigger);
}
