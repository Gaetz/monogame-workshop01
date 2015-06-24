using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop01.Custom;

namespace Workshop01
{
    class CollisionManager
    {
        public const int NumberOfAutotileID = 384;
        public const int NumberOfLayers = 3;
        #region Variables
        /// <summary>
        /// Pixel Color to be set as passable in the Chipset Mask
        /// </summary>
        static byte PassableByte = (byte)(ColorTag.Passable);
        /// <summary>
        /// Pixel Color to be set as NOT passable in the Chipset Mask
        /// </summary>
        static byte NotPassableByte = (byte)(ColorTag.NotPassable);
        /// <summary>
        /// Pixel Color to be set to force passability in the Chipset Mask
        /// </summary>
        static byte ForcePassableByte = (byte)(ColorTag.ForcePassable);

        /// <summary>
        /// Position of Zoom focus usually the game player
        /// </summary>
        public static Vector2 ZoomCenter = new Vector2(1280 / 2, 720 / 2);
        /// <summary>
        /// ROTATION of Tilemap in radian
        /// </summary>
        public static float Angle = 0;

        /// <summary>
        /// Contains Mask Color data
        /// </summary>
        static Mask maskColorData;

        /// <summary>
        /// Refers to the y order adjustment due to map scroll shifts
        /// </summary>
        internal static int adjustOrder;

        /// <summary>
        /// Get or set autotile Animation number of frame
        /// </summary>
        public static short[] AutotileAnimations;

        /// <summary>
        /// Get ior Set the Shifting vector value of ox and oy
        /// </summary>
        internal static Vector2 shift;

        /// <summary>
        /// Autotile Portion
        /// </summary>
        internal static Vector2 autotilePortion1 = new Vector2(16, 0);
        internal static Vector2 autotilePortion2 = new Vector2(0, 16);
        internal static Vector2 autotilePortion3 = new Vector2(16, 16);

        /// <summary>
        /// Current Tile position to be drawn
        /// </summary>
        static Vector2 position;
        /// <summary>
        /// Current Autotile X position to be drawn
        /// </summary>
        static int autotileX;
        /// <summary>
        /// Current Autotile Y position to be drawn
        /// </summary>
        static int autotileY;
        /// <summary>
        /// Current Tile rectangle to be drawn
        /// </summary>
        static Rectangle rectangle;

        /// <summary>
        /// Reference to Map data
        /// </summary>
        static short[][][] data;

        /// <summary>
        /// Combination of Tile within autotile
        /// </summary>
        static byte[, ,] Autotile = {
      { {27, 28, 33, 34}, { 5, 28, 33, 34}, {27,  6, 33, 34}, { 5,  6, 33, 34},
        {27, 28, 33, 12}, { 5, 28, 33, 12}, {27,  6, 33, 12}, { 5,  6, 33, 12} },
      { {27, 28, 11, 34}, { 5, 28, 11, 34}, {27,  6, 11, 34}, { 5,  6, 11, 34},
        {27, 28, 11, 12}, { 5, 28, 11, 12}, {27,  6, 11, 12}, { 5,  6, 11, 12} },
      { {25, 26, 31, 32}, {25,  6, 31, 32}, {25, 26, 31, 12}, {25,  6, 31, 12},
        {15, 16, 21, 22}, {15, 16, 21, 12}, {15, 16, 11, 22}, {15, 16, 11, 12} },
      { {29, 30, 35, 36}, {29, 30, 11, 36}, { 5, 30, 35, 36}, { 5, 30, 11, 36},
        {39, 40, 45, 46}, { 5, 40, 45, 46}, {39,  6, 45, 46}, { 5,  6, 45, 46} },
      { {25, 30, 31, 36}, {15, 16, 45, 46}, {13, 14, 19, 20}, {13, 14, 19, 12},
        {17, 18, 23, 24}, {17, 18, 11, 24}, {41, 42, 47, 48}, { 5, 42, 47, 48} },
      { {37, 38, 43, 44}, {37,  6, 43, 44}, {13, 18, 19, 24}, {13, 14, 43, 44},
        {37, 42, 43, 48}, {17, 18, 47, 48}, {13, 18, 43, 48}, { 1,  2,  7,  8} }
    };
        /// <summary>
        /// Array of Tile ID rectangles in the chipset
        /// </summary>
        internal static Rectangle[] tileRect;
        internal static Rectangle[,] autotileRect = new Rectangle[NumberOfAutotileID - 48, 4];

        /// <summary>
        /// Reference to Game Map priorities
        /// </summary>
        public static byte[] Priorities;

        /// <summary>
        /// Reference to Game Map Blend Mode per tile
        /// </summary>
        public static bool[] IsAddBlend;

        /// <summary>
        /// Game Map Width in tiles
        /// </summary>
        internal static int mapWidth;
        /// <summary>
        /// Game Map Height in tiles
        /// </summary>
        internal static int mapHeight;

        /// <summary>
        /// Tile engine X start case
        /// </summary>
        internal static int caseX;

        /// <summary>
        /// Tile engine Y start case
        /// </summary>
        internal static int caseY;

        /// <summary>
        /// The X-coordinate of the tilemap's starting point. Change this value to scroll the tilemap
        /// </summary>
        static int shiftX;

        /// <summary>
        /// The Y-coordinate of the tilemap's starting point. Change this value to scroll the tilemap
        /// </summary>
        static int shiftY;

        /// <summary>
        /// Get Vector2 zoom of Tilemap including viewport
        /// </summary>
        public static Vector2 Zoom = Vector2.One;
        /// <summary>
        /// Get or Set the box (Rectangle) defining the viewport.
        /// </summary>
        public static Rectangle Rect = new Rectangle(0, 0, 1280, 720);
        #endregion

        #region Properties
        public static Mask MaskColorData
        {
            get
            {
                return maskColorData;
            }
            set
            {
                maskColorData = value;
            }
        }

        /// <summary>
        /// X Shift of tilemap
        /// </summary>
        public static int Ox
        {
            get
            {
                return shiftX;
            }
            set
            {
                shiftX = value;
            }
        }
        /// <summary>
        /// Y Shift of tilemap
        /// </summary>
        public static int Oy
        {
            get
            {
                return shiftY;
            }
            set
            {
                shiftY = value;
            }
        }

        /// <summary>
        /// The viewport Vector starting position
        /// </summary>
        internal static Vector2 StartingPoint
        {
            get
            {
                return new Vector2(ZoomCenter.X, ZoomCenter.Y);
            }
        }

        /// <summary>
        /// Reference to Map data
        /// </summary>
        public static short[][][] MapData
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


        /// <summary>
        /// Get Tilemap draw order
        /// </summary>
        internal static int DrawOrder
        {
            get
            {
                return 0;
            }
        }
        #endregion

        /// <summary>
        /// True if the rectangle collides with the Current Map
        /// </summary>
        /// <param name="A"></param>
        public static bool MapCollision(Rectangle A)
        {
            if (maskColorData.IsNull || A.IsEmpty)
                return true;
            if (A.Right >= mapWidth * 32 || A.Bottom >= mapHeight * 32 || A.Left < 0 || A.Top < 0)
                return false;
            byte pixelByte = PassableByte;
            int shiftX = 0;
            int shiftY = 0;
            int rectX = 0;
            int rectY = 0;
            for (int x = Math.Max(0, A.Left); x < Math.Min(mapWidth * 32, A.Right); x++)
            {
                shiftX = x % 32;
                for (int y = Math.Max(0, A.Top); y < Math.Min(mapHeight * 32, A.Bottom); y++)
                {
                    shiftY = y % 32;
                    pixelByte = PassableByte;
                    for (int layer = 0; layer < NumberOfLayers; layer++)
                    {
                        int tileId = MapData[x / 32][y / 32][layer];
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
                }
            }
            return true;
        }
    }
}
