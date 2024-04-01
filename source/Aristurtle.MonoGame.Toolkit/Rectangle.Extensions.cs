// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;

namespace Aristurtle.MonoGame.Toolkit;

/// <summary>
/// Defines extension methods for the <see cref="Rectangle"/> struct.
/// </summary>
public static class RectangleExtensions
{
    /// <summary>
    /// Gets a relative rectangle within the specified bounds relative to the source rectangle.
    /// </summary>
    /// <param name="source">The source rectangle.</param>
    /// <param name="relativeBounds">The bounds relative to the source rectangle.</param>
    /// <returns>A relative rectangle within the specified bounds relative to the source rectangle.</returns>
    public static Rectangle GetRelativeRectangle(this Rectangle source, Rectangle relativeBounds) =>
        source.GetRelativeRectangle(relativeBounds.X, relativeBounds.Y, relativeBounds.Width, relativeBounds.Height);

    /// <summary>
    /// Gets a relative rectangle with the specified position and dimensions relative to the source rectangle.
    /// </summary>
    /// <param name="source">The source rectangle.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the relative rectangle.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the relative rectangle.</param>
    /// <param name="width">The width of the relative rectangle.</param>
    /// <param name="height">The height of the relative rectangle.</param>
    /// <returns>
    /// A relative rectangle with the specified position and dimensions relative to the source rectangle.
    /// </returns>
    public static Rectangle GetRelativeRectangle(this Rectangle source, int x, int y, int width, int height)
    {
        int absoluteX = source.X + x;
        int absoluteY = source.Y + y;

        Rectangle relative;
        relative.X = MathHelper.Clamp(absoluteX, source.Left, source.Right);
        relative.Y = MathHelper.Clamp(absoluteY, source.Top, source.Bottom);
        relative.Width = Math.Max(Math.Min(absoluteX + width, source.Right) - relative.X, 0);
        relative.Height = Math.Max(Math.Min(absoluteY + height, source.Bottom) - relative.Y, 0);

        return relative;
    }

}
