using System.Collections.Generic;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreLibrary;

namespace CoreLibrary; 

public class Entity
{
    private readonly List<IComponents> _components = new List<IComponents>(); 
    public Vector2 Position {get;  set;} = Vector2.Zero; 


    // lägger in komponenterna i listan som en entity ska ha. 
    public T AddComponent<T>(T component) where T : IComponents
    {
        component.Owner = this; 
        _components.Add(component); 
        component.Initialize(); 
        return component; 
    }

    // Funktion som hämtar alla komponenter som matchar typen. 
    public T GetComponent<T>() where T : IComponents
    {
        foreach (var component in _components)
        {
            if (component is T match)
            {
                return match; 
            }
        }
        return default; 
    }

    public void Update(GameTime gameTime)
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].Update(gameTime); 
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].Draw(spriteBatch); 
        }
    }
}