using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CoreLibrary; 

namespace CoreLibrary; 

public class Animation 
{
    private Texture2D _spriteSheet {get; set; }
    private int _totalFrames {get; set; }
    private int _currentFrame; 
    private float _frameWidth, _frameHeight; 
    private float _timePerFrame, _timer;

    public Animation(Texture2D spriteSheet, int totalFrames, float timePerFrame)
    {
        _spriteSheet = spriteSheet; 
        _totalFrames = totalFrames; 
        _timePerFrame = 1f / timePerFrame; 

        _currentFrame = 0;
        _timer = 0f; 

        _frameWidth =  spriteSheet.Width / totalFrames; // delar spriteSheeten med totala frames för att få fram den frame som ska vissas i currentFrame. 
        _frameHeight = spriteSheet.Height; 

    } 

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
    }
}