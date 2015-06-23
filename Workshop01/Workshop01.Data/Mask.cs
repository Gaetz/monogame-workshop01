using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop01.Custom
{
    /// <summary>
    /// Struct for a managed 2D jagged array
    /// </summary>
    public class Mask
    {
        /// <summary>
        /// Jagged array
        /// </summary>
        public byte[][] array;

        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="dim1">First dimension</param>
        ///// <param name="dim2">Second dimension</param>
        //public Mask(int dim1, int dim2)
        //{
        //    array = new byte[dim1][];
        //    for (int i = 0; i < dim1; i++)
        //    {
        //        array[i] = new byte[dim2];
        //        for (int j = 0; j < dim2; j++)
        //            array[i][j] = (byte)(ColorTag.Passable);
        //    }
        //}

        ///// <summary>
        ///// Get or set array data
        ///// </summary>
        ///// <param name="a">first dimension</param>
        ///// <param name="b">second dimension</param>
        //public byte this[int a, int b]
        //{
        //    get
        //    {
        //        return array[a][b];
        //    }
        //    set
        //    {
        //        array[a][b] = value;
        //    }
        //}

        ///// <summary>
        ///// True if Array is empty
        ///// </summary>
        //public bool IsNull
        //{
        //    get
        //    {
        //        return array == null;
        //    }
        //}
    }

    /// <summary>
    /// Possible predefined Geex Effect
    /// </summary>
    public enum ColorTag
    {
        /// <summary>
        /// White (RGB = 255,255,255) is the Passable pixel
        /// </summary>
        Passable = 0,
        /// <summary>
        /// Black (RGB = 0,0,0) is not passable pixel
        /// </summary>
        NotPassable = 1,
        /// <summary>
        /// Red (RGB = 255,0,0) is Force Passability pixel (bridge, ladder, rope etc)
        /// </summary>
        ForcePassable = 2,
        /// <summary>
        /// Blue (RGB = 255,0,0)
        /// </summary>
        Blue = 3,
        /// <summary>
        /// Green (RGB = 0,255,0)
        /// </summary>
        Green = 4,
        /// <summary>
        /// Yellow (RGB = 255,255,0)
        /// </summary>
        Yellow = 5,
        /// <summary>
        /// Fuchsia (RGB = 255,0,255)
        /// </summary>
        Fuchsia = 6,
        /// <summary>
        /// Orange (RGB = 255,165,00)
        /// </summary>
        Orange = 7,
        /// <summary>
        /// Pink (RGB = 255,192,203)
        /// </summary>
        Pink = 8,
        /// <summary>
        /// Gray (RGB = 128,128,128)
        /// </summary>
        Gray = 9,
        /// <summary>
        /// Olive (RGB = 128,128,0)
        /// </summary>
        Olive = 10
    }
}
