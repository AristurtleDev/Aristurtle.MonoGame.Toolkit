// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aristurtle.MonoGame.Toolkit.Graphics;

/// <summary>
/// Represents a sub-region of a 2D texture.
/// </summary>
public sealed class Texture2DExtended : IDisposable
{
    /// <summary>
    /// Gets the underlying texture.
    /// </summary>
    public Texture2D Texture { get; }

    /// <summary>
    /// Gets the source rectangle defining the area of the sub-texture within the parent texture.
    /// </summary>
    public Rectangle SourceRectangle { get; }

    /// <summary>
    /// Gets the width of the sub-texture, in pixels.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the sub-texture, in pixels.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the center point of the sub-texture.
    /// </summary>
    public Vector2 Center { get; }

    /// <summary>
    /// Gets the normalized top texture coordinate.
    /// </summary>
    public float TopUV { get; }

    /// <summary>
    /// Gets the normalized bottom texture coordinate.
    /// </summary>
    public float BottomUV { get; }

    /// <summary>
    /// Gets the normalized left texture coordinate.
    /// </summary>
    public float LeftUV { get; }

    /// <summary>
    /// Gets the normalized right texture coordinate.
    /// </summary>
    public float RightUV { get; }

    /// <summary>
    /// Gets a value indicating whether the sub-texture has been disposed.
    /// </summary>
    public bool IsDisposed { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DExtended"/> class.
    /// </summary>
    /// <param name="texture">The base texture.</param>
    public Texture2DExtended(Texture2D texture)
    {
        DebugGuard.ArgumentNotNull(texture);
        Texture = texture;
        SourceRectangle = texture.Bounds;
        Width = SourceRectangle.Width;
        Height = SourceRectangle.Height;
        Center = SourceRectangle.Center.ToVector2();
        LeftUV = SourceRectangle.Left / (float)texture.Width;
        RightUV = SourceRectangle.Right / (float)texture.Width;
        TopUV = SourceRectangle.Top / (float)texture.Height;
        BottomUV = SourceRectangle.Bottom / (float)texture.Height;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DExtended"/> class using a parent texture and specified
    /// dimensions.
    /// </summary>
    /// <param name="parent">The parent <see cref="Texture2DExtended"/> containing the sub-texture.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the sub-texture within the parent texture.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the sub-texture within the parent texture.</param>
    /// <param name="width">The width of the sub-texture.</param>
    /// <param name="height">The height of the sub-texture.</param>
    /// <remarks>
    public Texture2DExtended(Texture2DExtended parent, int x, int y, int width, int height)
    {
        DebugGuard.ArgumentGreaterThanOrEqualTo(x, 0);
        DebugGuard.ArgumentGreaterThanOrEqualTo(y, 0);
        DebugGuard.ArgumentGreaterThan(width, 0);
        DebugGuard.ArgumentGreaterThan(height, 0);
        DebugGuard.ArgumentNotNull(parent);

        Texture = parent.Texture;
        SourceRectangle = parent.SourceRectangle.GetRelativeRectangle(x, y, width, height);

        Width = SourceRectangle.Width;
        Height = SourceRectangle.Height;
        Center = SourceRectangle.Center;
        LeftUV = SourceRectangle.Left / (float)parent.Width;
        RightUV = SourceRectangle.Right / (float)parent.Width;
        TopUV = SourceRectangle.Top / (float)parent.Height;
        BottomUV = SourceRectangle.Bottom / (float)parent.Height;
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DExtended"/> class using a parent texture and a relative
    /// bounding rectangle.
    /// </summary>
    /// <param name="parent">The parent <see cref="Texture2DExtended"/> containing the sub-texture.</param>
    /// <param name="relativeBounds">The bounding rectangle relative to the parent texture.</param>
    public Texture2DExtended(Texture2DExtended parent, Rectangle relativeBounds)
        : this(parent, relativeBounds.X, relativeBounds.Y, relativeBounds.Width, relativeBounds.Height) { }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool isDisposing)
    {
        if (IsDisposed) { return; }
        if (isDisposing)
        {
            Texture.Dispose();
        }
        IsDisposed = true;
    }
}
