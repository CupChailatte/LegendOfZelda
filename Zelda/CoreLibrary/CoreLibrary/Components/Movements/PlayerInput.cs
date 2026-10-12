using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using CoreLibrary;

namespace CoreLibrary.Components.Movement;

public class PlayerInput : IComponents
{
    public Entity Owner { get; set; }
    private float Speed { get; set; } = 100f;
    public PlayerInput(float speed)
    {
        Speed = speed;
    }
    private KeyboardState _currentKeyState, _previousKeyState;

    public void Initialize()
    {

    }

    public void Update(GameTime gameTime)
    {
      
        _currentKeyState = Keyboard.GetState();

        Vector2 direction = Vector2.Zero;

        if (_currentKeyState.IsKeyDown(Keys.W) || _currentKeyState.IsKeyDown(Keys.Up)) direction.Y -= 1;
        else if(_currentKeyState.IsKeyDown(Keys.S) || _currentKeyState.IsKeyDown(Keys.Down)) direction.Y += 1;
        else if (_currentKeyState.IsKeyDown(Keys.A) || _currentKeyState.IsKeyDown(Keys.Left)) direction.X -= 1;
        else if (_currentKeyState.IsKeyDown(Keys.D) || _currentKeyState.IsKeyDown(Keys.Right)) direction.X += 1;

        if (_currentKeyState.IsKeyDown(Keys.Space) && _previousKeyState.IsKeyUp(Keys.Space)) Console.Write("Dash");


        if (direction != Vector2.Zero)
        {
            direction.Normalize();
            float DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Owner.Position += direction * Speed * DeltaTime;
        }
        _previousKeyState = _currentKeyState;


    }
    public void Draw(SpriteBatch spriteBatch)
    {

    }
}
