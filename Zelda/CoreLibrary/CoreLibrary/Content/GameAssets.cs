
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content; 
using Microsoft.Xna.Framework.Graphics;

namespace CoreLibrary; 

public static class GameAssets
{
    public static Texture2D PlayerSprite {get; private set;}
    public static Texture2D EnemySprite {get; private set;}
    public static Texture2D FloorSprite {get; private set; }


    public static void LoadTextureAssets(ContentManager content)
    {
        PlayerSprite = content.Load<Texture2D>("PlayerSprite/Link_1"); 
        EnemySprite = content.Load<Texture2D>("EnemySprite/skelett");

        FloorSprite = content.Load<Texture2D>("MapSprite/grass");  
    }
}