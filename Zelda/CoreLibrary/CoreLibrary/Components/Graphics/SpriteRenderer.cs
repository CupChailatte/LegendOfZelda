using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using CoreLibrary; 

namespace CoreLibrary; 

/*
* Ritar ut texturerna av Entity 

*/

public class SpriteRenderer : IComponents
{
    public Entity Owner {get; set;}
    public Texture2D Texture {get; set;}
    public Color Tint {get; set; } = Color.White; 

    public SpriteRenderer(Texture2D texture)
    {
        Texture = texture; 
    }

    public void Initialize()
    {
        
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if(Texture != null && Owner != null)
        spriteBatch.Draw(Texture, Owner.Position, Tint);  
    }
}