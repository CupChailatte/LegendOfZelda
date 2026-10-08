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
    private EntityCreator _EntityCreator;
    private List<Entity> _entities = new List<Entity>();
    public Vector2 Position = new Vector2(400, 400);
    private TileMap _tileMap; 
    private Texture2D _floorTexture; 


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 256;
        _graphics.PreferredBackBufferHeight = 240;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {

        _EntityCreator = new EntityCreator();
      

        base.Initialize();
    }

    protected override void LoadContent()
    {
        GameAssets.LoadTextureAssets(Content); 
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _floorTexture = GameAssets.FloorSprite; 
        _tileMap = new TileMap(_floorTexture, tileWidth : 32, tileHeight: 32); 

        _tileMap.LoadFromCSV("Content/map.txt");    

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

        _tileMap.Draw(_spriteBatch); 

        foreach (var entity in _entities)
        {
            entity.Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
