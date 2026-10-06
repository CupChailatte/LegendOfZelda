
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content; 
using Microsoft.Xna.Framework.Graphics;

namespace CoreLibrary; 

public class GameAssets
{
    public static Texture2D PlayerSprite {get; private set;}


    public void LoadTextureAssets(ContentManager content)
    {
        PlayerSprite = content.Load<Texture2D>("PlayerSprite/Link_1"); 
    }
}