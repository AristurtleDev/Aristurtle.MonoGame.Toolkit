// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;

namespace Aristurtle.MonoGame.Toolkit.Camera;

/// <summary>
/// Defines extension methods for the <see cref="Camera2D"/> class..
/// </summary>
public static class Camera2DExtensions
{
    /// <summary>
    /// Centers the origin of a camera based on the bounds of the <see cref="Camera2D.Viewport"/>.
    /// </summary>
    /// <param name="camera">The camera to center the origin of.</param>
    public static void CenterOrigin(this Camera2D camera)
    {
        ArgumentNullException.ThrowIfNull(camera);
        camera.Origin = camera.Viewport.Bounds.Center.ToVector2();
    }

    /// <summary>
    /// Rounds the <see cref="Camera2D.Position"/> property of the camera.
    /// </summary>
    /// <param name="camera">The camera to round the position of.</param>
    public static void RoundPosition(this Camera2D camera)
    {
        ArgumentNullException.ThrowIfNull(camera);
        float x = (float)Math.Round(camera.Position.X);
        float y = (float)Math.Round(camera.Position.Y);
        camera.Position = new Vector2(x, y);
    }

    /// <summary>
    /// Translates the specified screen space xy-coordinates to camera space.
    /// </summary>
    /// <param name="camera">
    /// The camera to translate the screen space coordinates to that camera's coordinate space.
    /// </param>
    /// <param name="x">The x-coordinate location of the position to translate.</param>
    /// <param name="y">The y-coordinate location of the position to translate.</param>
    /// <returns>The position translated to camera space.</returns>
    public static Vector2 ScreenToCamera(this Camera2D camera, float x, float y) => camera.ScreenToCamera(new Vector2(x, y));

    /// <summary>
    /// Translates the specified screen space position to camera space.
    /// </summary>
    /// <param name="camera">
    /// The camera to translate the screen space coordinates to that camera's coordinate space.
    /// </param>
    /// <param name="position">The position to translate</param>
    /// <returns>The position translated to camera space.</returns>
    public static Vector2 ScreenToCamera(this Camera2D camera, Vector2 position)
    {
        ArgumentNullException.ThrowIfNull(camera);
        return Vector2.Transform(camera.Position, camera.Inverse);
    }

    /// <summary>
    /// Translates the specified camera space xy-coordinates to screen space.
    /// </summary>
    /// <param name="camera">
    /// The camera to translate the camera's space coordinates to that screen's coordinate space.
    /// </param>
    /// <param name="x">The x-coordinate location of the position to translate/</param>
    /// <param name="y">The y-coordinate location of the position to translate.</param>
    /// <returns></returns>
    public static Vector2 CameraToScreen(this Camera2D camera, float x, float y) => camera.CameraToScreen(new Vector2(x, y));

    /// <summary>
    /// Translates the specified camera space position to screen space.
    /// </summary>
    /// <param name="position">The position to translate.</param>
    /// <returns>The position translated to sceen space.</returns>
    public static Vector2 CameraToScreen(this Camera2D camera, Vector2 position)
    {
        ArgumentNullException.ThrowIfNull(camera);
        return Vector2.Transform(camera.Position, camera.Matrix);
    }
}
