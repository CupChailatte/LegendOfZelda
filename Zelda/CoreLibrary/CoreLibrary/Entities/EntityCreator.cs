using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CoreLibrary;
using CoreLibrary.Components.Movement;

namespace CoreLibrary;

public class EntityCreator
{


  public Entity CreatePlayer(Vector2 playerPosition)
  {
    Entity player = new Entity{Position = playerPosition}; 
    player.AddComponent(new SpriteRenderer(GameAssets.PlayerSprite)); 
    player.AddComponent(new PlayerInput(speed: 200f));  
    return player; 
  }

};