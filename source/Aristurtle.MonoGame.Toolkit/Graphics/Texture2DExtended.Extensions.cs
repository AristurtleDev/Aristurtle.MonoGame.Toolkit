// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aristurtle.MonoGame.Toolkit.Graphics;

/// <summary>
/// Defines extension methods for the <see cref="Texture2DExtended"/> class.
/// </summary>
public static class Texture2DExtendedExtensions
{
    [Conditional("DEBUG")]
    private static void EnsureTextureNotDisposed(Texture2DExtended texture)
    {
        DebugGuard.AssertIsFalse<ObjectDisposedException>(texture.IsDisposed, "Texture has been disposed");
    }

    /// <summary>
    /// Draws the texture at the specified position.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    public static void Draw(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position) =>
        texture.Draw(spriteBatch, position, Color.White);

    /// <summary>
    /// Draws the texture at the specified position with the specified color.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    public static void Draw(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color) =>
        texture.Draw(spriteBatch, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the texture at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="origin">The origin of the texture (relative to its dimensions).</param>
    /// <param name="scale">The scale factor to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void Draw(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) =>
        texture.Draw(spriteBatch, position, color, rotation, origin, new Vector2(scale, scale), effects, layerDepth);

    /// <summary>
    /// Draws the texture at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="origin">The origin of the texture (relative to its dimensions).</param>
    /// <param name="scale">The scale factors to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void Draw(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        DebugGuard.ArgumentNotNull(texture);
        DebugGuard.ArgumentNotNull(spriteBatch);
        EnsureTextureNotDisposed(texture);
        spriteBatch.Draw(texture.Texture, position, texture.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the texture centered at the specified position.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    public static void DrawCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position) =>
        texture.DrawCentered(spriteBatch, position, Color.White);

    /// <summary>
    /// Draws the texture centered at the specified position with the specified color.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    public static void DrawCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color) =>
        texture.DrawCentered(spriteBatch, position, color, 0.0f, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the texture centered at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="scale">The uniform scale factor to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, float scale, SpriteEffects effects, float layerDepth) =>
        texture.DrawCentered(spriteBatch, position, color, rotation, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the texture centered at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="scale">The scale factors to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        DebugGuard.ArgumentNotNull(texture);
        DebugGuard.ArgumentNotNull(spriteBatch);
        EnsureTextureNotDisposed(texture);
        spriteBatch.Draw(texture.Texture, position, texture.SourceRectangle, color, rotation, texture.Center, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the texture with an outline effect at the specified position.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    public static void DrawOutlined(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position) =>
        texture.DrawOutlined(spriteBatch, position, Color.White);

    /// <summary>
    /// Draws the texture with an outline effect at the specified position with the specified color.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    public static void DrawOutlined(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color) =>
        texture.DrawOutlined(spriteBatch, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the texture with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="origin">The origin of the texture (relative to its dimensions).</param>
    /// <param name="scale">The uniform scale factor to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawOutlined(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) =>
        texture.DrawOutlined(spriteBatch, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the texture with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="origin">The origin of the texture (relative to its dimensions).</param>
    /// <param name="scale">The scale factors to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawOutlined(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        DebugGuard.ArgumentNotNull(texture);
        DebugGuard.ArgumentNotNull(spriteBatch);
        EnsureTextureNotDisposed(texture);

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }
                Vector2 offset = new Vector2(x, y);
                spriteBatch.Draw(texture.Texture, position + offset, texture.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
            }
        }

        spriteBatch.Draw(texture.Texture, position, texture.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the texture centered with an outline effect at the specified position.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    public static void DrawOutlinedCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position) =>
        texture.DrawOutlinedCentered(spriteBatch, position, Color.White);

    /// <summary>
    /// Draws the texture centered with an outline effect at the specified position with the specified color.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    public static void DrawOutlinedCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color) =>
        texture.DrawOutlinedCentered(spriteBatch, position, color, 0.0f, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the texture centered with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="scale">The uniform scale factor to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawOutlinedCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, float scale, SpriteEffects effects, float layerDepth) =>
        texture.DrawOutlinedCentered(spriteBatch, position, color, rotation, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the texture centered with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="texture">The <see cref="Texture2DExtended"/> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="position">The position at which to draw the texture.</param>
    /// <param name="color">The color tint to apply to the texture and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the texture.</param>
    /// <param name="scale">The scale factors to apply to the texture.</param>
    /// <param name="effects">The sprite effects to apply to the texture.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw the texture.</param>
    public static void DrawOutlinedCentered(this Texture2DExtended texture, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        DebugGuard.ArgumentNotNull(texture);
        DebugGuard.ArgumentNotNull(spriteBatch);
        EnsureTextureNotDisposed(texture);

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }
                Vector2 offset = new Vector2(x, y);
                spriteBatch.Draw(texture.Texture, position + offset, texture.SourceRectangle, color, rotation, texture.Center, scale, effects, layerDepth);
            }
        }

        spriteBatch.Draw(texture.Texture, position, texture.SourceRectangle, color, rotation, texture.Center, scale, effects, layerDepth);
    }

}
