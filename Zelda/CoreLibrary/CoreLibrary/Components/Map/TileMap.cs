using System.IO;
using System;
using System.Collections.Generic; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CoreLibrary; 
public class TileMap
{
    private readonly Texture2D _tileSet;
    private readonly int _tileWidth, _tileHeight, _tilesPerRow;
    private int[,] _mapData;
    private int MapWidth => _mapData.GetLength(1); 
    private int MapHeight => _mapData.GetLength(0); 

    public TileMap(Texture2D tileset, int tileWidth, int tileHeight)
    {
       
        _tileSet = tileset;
        _tileWidth = tileWidth;
        _tileHeight = tileHeight;
        _tilesPerRow = tileset.Width / tileWidth;
    }

    public void LoadFromCSV(string filePath)
    {
        var linesList = new List<string[]>();

        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                linesList.Add(line.Split(',', StringSplitOptions.TrimEntries));
            }
        }
        int height = linesList.Count;
        int width = linesList[0].Length;
        _mapData = new int[height, width]; 

        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                _mapData[y,x] = int.Parse(linesList[y][x]); 
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int row = 0; row < MapHeight; row++)
        {
            for (int col = 0; col < MapWidth; col++)
            {
                int tileId = _mapData[row, col]; 

                if (tileId < 0) continue; // skips empty tiles

                // col = x, row = y 
                int tilesetCol = tileId % _tilesPerRow; 
                int tilesetRow = tileId / _tilesPerRow; 

                var sourceRectangle = new Rectangle(
                    tilesetCol * _tileWidth,
                    tilesetRow * _tileHeight, 
                    _tileWidth,
                    _tileHeight
                ); 
                // Col = x ,Row = Y 
                var destinationRectangle = new Rectangle(
                    col * _tileWidth,
                    row * _tileHeight,
                    _tileWidth,
                    _tileHeight
                ); 
                
                spriteBatch.Draw(_tileSet, destinationRectangle, sourceRectangle, Color.White); 
                    
                
            }
        }
        
    }

}


/*

*1 TileSet Class 
*2 CVS/Txt class (Map Data)
*3 Tileset funktion som går igenom varje ruta av TileSetTexture 
*4 Matematik som klipper och klistrar in från TileSet och MapData 
*5 SpriteBatch ritar ut.  


*/
