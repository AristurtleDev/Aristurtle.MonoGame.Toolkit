// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aristurtle.MonoGame.Toolkit.Camera;

public class Camera2D
{
    private Matrix _matrix;
    private Matrix _inverse;
    private bool _dirty;
    private Vector2 _position;
    private Vector2 _zoom;
    private Vector2 _origin;
    private float _rotation;

    /// <summary>
    /// Gets or Sets the viewport associated with the camera.
    /// </summary>
    public Viewport Viewport { get; set; }

    /// <summary>
    /// Gets the transformation matrix representing the camera view.
    /// </summary>
    public Matrix Matrix
    {
        get
        {
            if (_dirty) { UpdateMatrices(); }
            return _matrix;
        }
    }

    /// <summary>
    /// Gets the inverse transformation matrix representing the inverse of the camera view.
    /// </summary>
    public Matrix Inverse
    {
        get
        {
            if (_dirty) { UpdateMatrices(); }
            return _inverse;
        }
    }

    /// <summary>
    /// Gets or Sets the position of the camera.
    /// </summary>
    public Vector2 Position
    {
        get => _position;
        set
        {
            if (_position.Equals(value)) { return; }
            _position = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the x-coordinate position of the camera.
    /// </summary>
    public float X
    {
        get => _position.X;
        set
        {
            if (_position.X.Equals(value)) { return; }
            _position.X = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the y-coordinate position of the camera.
    /// </summary>
    public float Y
    {
        get => _position.Y;
        set
        {
            if (_position.Y.Equals(value)) { return; }
            _position.Y = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the origin point of the camera.
    /// </summary>
    public Vector2 Origin
    {
        get => _origin;
        set
        {
            if (_origin.Equals(value)) { return; }
            _origin = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the x-coordinate origin point of the camera.
    /// </summary>
    public float OriginX
    {
        get => _origin.X;
        set
        {
            if (_origin.X.Equals(value)) { return; }
            _origin.X = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the y-coordinate origin point of the camera.
    /// </summary>
    public float OriginY
    {
        get => _origin.Y;
        set
        {
            if (_origin.Y.Equals(value)) { return; }
            _origin.Y = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the zoom factor of the camera.
    /// </summary>
    public Vector2 Zoom
    {
        get => _zoom;
        set
        {
            if (_zoom.Equals(value)) { return; }
            _zoom = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the x-axis zoom factor of the camera.
    /// </summary>
    public float ZoomX
    {
        get => _zoom.X;
        set
        {
            if (_zoom.X.Equals(value)) { return; }
            _zoom.X = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the y-axis zoom factor of the camera.
    /// </summary>
    public float ZoomY
    {
        get => _zoom.Y;
        set
        {
            if (_zoom.Y.Equals(value)) { return; }
            _zoom.Y = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Gets or Sets the rotation of the camera, in radians.
    /// </summary>
    public float Rotation
    {
        get => _rotation;
        set
        {
            if (_rotation.Equals(value)) { return; }
            _rotation = value;
            _dirty = true;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Camera2D"/> class.
    /// </summary>
    /// <param name="width">The width, in pixels, of the viewport.</param>
    /// <param name="height">The height, in pixels, of the viewport.</param>
    public Camera2D(int width, int height)
    {
        Viewport = new Viewport(0, 0, width, height);
        UpdateMatrices();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Camera2D"/> class.
    /// </summary>
    /// <param name="viewport">The viewport of the camera.</param>
    public Camera2D(Viewport viewport)
    {
        Viewport = viewport;
        UpdateMatrices();
    }

    private void UpdateMatrices()
    {
        Vector2 positionFloored = new Vector2(-(int)Math.Floor(_position.X), -(int)Math.Floor(_position.Y));
        Vector2 originFloored = new Vector2((int)Math.Floor(_origin.X), (int)Math.Floor(_origin.Y));

        _matrix = Matrix.Identity
                * Matrix.CreateTranslation(new Vector3(positionFloored, 0))
                * Matrix.CreateRotationZ(_rotation)
                * Matrix.CreateScale(new Vector3(_zoom, 1.0f))
                * Matrix.CreateTranslation(new Vector3(originFloored, 0.0f));

        _inverse = Matrix.Invert(_matrix);
        _dirty = false;
    }
}
