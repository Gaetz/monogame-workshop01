using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop01.Custom;

namespace Workshop01
{
    public class CurrentMask
    {
        bool hasChanged;
        Texture2D collisionTexture;
        Mask mask;
        int mapWidth;
        int mapHeight;
        public short[][][] MapData 
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                mapWidth = data.GetLength(0);
                mapHeight = data[0].GetLength(0);
            }
        }
        short[][][] data;

        public void Initialize(GraphicsDevice graphicsDevice, Mask mask)
        {
            // Mask
            this.mask = mask;
            // Charge texture
            collisionTexture = new Texture2D(graphicsDevice, 1280, 736);
            Color[] pixels = new Color[collisionTexture.Width * collisionTexture.Height];
            for (int i = 0; i < pixels.Length; i++)
            {
                int tileX = (i % mapWidth) / 32;
                int tileY = (i / mapWidth) / 32;
                int shiftX = (i % mapWidth) % 32;
                int shiftY = (i / mapWidth) % 32;
                int rectX = 0;
                int rectY = 0;

                pixelByte = PassableByte;
                for (int layer = 0; layer < NumberOfLayers; layer++)
                {
                    int tileId = MapData[tileX][tileY][layer];
                    if (tileId < 48)
                        continue;
                    // Tile
                    if (tileId >= 384)
                    {
                        rectX = tileRect[tileId - 384].X + shiftX;
                        rectY = tileRect[tileId - 384].Y + shiftY;
                    }
                    else  // Autotiles
                    {
                        rectX = ((tileId - 48) / 48) * 32 + shiftX; ;
                        rectY = ((tileId - 48) % 48) * 32 + shiftY; ;
                    }
                    if (maskColorData[rectX, rectY] == NotPassableByte ||
                        maskColorData[rectX, rectY] == ForcePassableByte)
                        pixelByte = maskColorData[rectX, rectY];
                }
                if (pixelByte == NotPassableByte)
                    return false;
                else
                return true;





                if(i < 500000)
                {
                    pixels[i].R = 0;
                    pixels[i].G = 255;
                    pixels[i].B = 255;
                }
                else
                {
                    pixels[i].R = 255;
                    pixels[i].G = 255;
                    pixels[i].B = 0;
                }
            }
            collisionTexture.SetData(pixels);
            // Set true
            hasChanged = true;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if(hasChanged)
            //{
                spriteBatch.Draw(collisionTexture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                hasChanged = false;
            //}
        } 
    }
}
