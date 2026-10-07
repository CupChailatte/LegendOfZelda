using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CoreLibrary;

namespace Zelda;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private GameAssets _GameAssets;
    private EntityCreator _EntityCreator;
    private List<Entity> _entities = new List<Entity>();
    public Vector2 Position = new Vector2(400, 400);


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1300;
        _graphics.PreferredBackBufferHeight = 1300;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {

        _GameAssets = new GameAssets();
        _EntityCreator = new EntityCreator();
      

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _GameAssets.LoadTextureAssets(Content);
        
        Entity player = _EntityCreator.CreatePlayer(new Vector2(30, 40));
        Entity enemy1 = _EntityCreator.CreateEnemy1(new Vector2(59,59)); 
        _entities.Add(player);
        _entities.Add(enemy1); 


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        foreach(var entity in _entities)
        {
            entity.Update(gameTime); 
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();

        foreach (var entity in _entities)
        {
            entity.Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
