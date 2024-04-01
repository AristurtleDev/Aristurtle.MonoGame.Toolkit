// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;

namespace Aristurtle.MonoGame.Toolkit.Input;

/// <summary>
/// Provides services for detecting and managing input for the game.
/// </summary>
public class InputService : IUpdateable, IGameComponent
{
    private bool _enabled;
    private int _updateOrder;
    private readonly GamePadInfo[] _gamePads;

    /// <summary>
    /// Gets or Sets a value that indicates whether this service is enabled.
    /// </summary>
    public bool Enabled
    {
        get => _enabled;
        set
        {
            if (_enabled == value) { return; }
            _enabled = value;
            EnabledChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Gets or Sets a value that indicates the order in which this service should be updated relative to other
    /// <see cref="IUpdateable"/> components when used in a <see cref="GameComponentCollection"/>.
    /// </summary>
    /// <remarks>
    /// If this service is not used as part of the MonOGame <see cref="GameComponentCollection"/>, then this value
    /// does nothing.
    /// </remarks>
    public int UpdateOrder
    {
        get => _updateOrder;
        set
        {
            if (_updateOrder == value) { return; }
            _updateOrder = value;
            UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Gets the information about the state of keyboard input.
    /// </summary>
    public KeyboardInfo Keyboard { get; private set; }

    /// <summary>
    /// Gets the information about the state of mouse input.
    /// </summary>
    public MouseInfo Mouse { get; private set; }


    /// <summary>
    /// Event triggered when the value of the <see cref="Enabled"/> property changes.
    /// </summary>
    public event EventHandler<EventArgs>? EnabledChanged;

    /// <summary>
    /// Event triggered when the value of the <see cref="UpdateOrder"/> property changes.
    /// </summary>
    public event EventHandler<EventArgs>? UpdateOrderChanged;

    /// <summary>
    /// Initialize a new instance of the <see cref="InputService"/> class.
    /// </summary>
    public InputService()
    {
        Keyboard = new KeyboardInfo();
        Mouse = new MouseInfo();
        _gamePads = new GamePadInfo[4];
        for (int i = 0; i < 4; i++)
        {
            _gamePads[i] = new GamePadInfo((PlayerIndex)i);
        }
    }


    /// <summary>
    /// Performs initializations.
    /// </summary>
    /// <remarks>
    /// This method is part of the <see cref="IGameComponent"/> interface, but does nothing for the
    /// <see cref="InputService"/> class. There is no need to call this method manually.
    /// </remarks>
    public void Initialize() { }

    /// <summary>
    /// Updates this service.
    /// </summary>
    /// <param name="gameTime">
    /// A snapshot of the timing values for the game between the current and previous frames.
    /// </param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(GameTime gameTime)
    {
        if (!Enabled) { return; }
        Keyboard.Update();
        Mouse.Update();
        for (int i = 0; i < 4; i++)
        {
            _gamePads[i].Update(gameTime);
        }
    }

    /// <summary>
    /// Returns the <see cref="GamePadInfo"/> specific to the player at the specified player index.
    /// </summary>
    /// <param name="player">The index of the player.</param>
    /// <returns>The <see cref="GamePadInfo"/> for the specified player.</returns>
    public GamePadInfo GetGamePad(PlayerIndex player) => _gamePads[(int)player];
}
