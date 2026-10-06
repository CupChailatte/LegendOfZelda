using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 

namespace CoreLibrary; 

public interface IComponents
{
    Entity Owner {get ; set ; }
    public void Initialize(); 
    public void Update(GameTime gameTime); 
    public void Draw(SpriteBatch spriteBatch); 
}