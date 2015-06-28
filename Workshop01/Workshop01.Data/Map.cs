using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Workshop01.Custom
{
    /// <summary>
    /// Data class for maps
    /// </summary>
    public sealed class Map
    {
        #region Variables
        /// <summary>
        /// Tileset ID to be used in the map
        /// </summary>
        //[XmlAttribute(AttributeName="t")]
        public short TilesetId;

        /// <summary>
        /// Map Name
        /// </summary>
        [ContentSerializer(Optional = true)]
        public string Name;

        ///<summary>The map width
        ///</summary>
        //[XmlAttribute(AttributeName="W")]
        public short Width;

        /// <summary>
        /// The map height
        /// </summary>
        //[XmlAttribute(AttributeName="H")]
        public short Height;

        /// <summary>
        /// Truth-value of whether Song autoswitching is enabled
        /// </summary>
        public bool AutoplayMusicLoop;

        /// <summary>
        /// If Music Loop autoswitching is enabled, the Name of that looping Music
        /// </summary>
        //public AudioFile MusicLoop;

        /// <summary>
        /// Truth-value of whether Sound Loop autoswitching is enabled
        /// </summary>
        public bool AutoplaySoundLoop;

        /// <summary>
        /// If Background Effect autoswitching is enabled, the Name of that looping Sound
        /// </summary>
        //public AudioFile SoundLoop;

        /// <summary>
        /// Encounter list. A troop ID array
        /// </summary>
        public short[] EncounterList;

        /// <summary>
        /// Number of steps between encounters
        /// </summary>
        public short EncounterStep = 30;

        /// <summary>
        /// The map data. A 3-dimensional Tile ID Jagged Array
        /// </summary>
        public short[][][] Data;

        /// <summary>
        /// Map events. An array that represents Event instances as values, using event IDs as the keys
        /// </summary>
        //[XmlAttribute(AttributeName="E")]
        //public Event[] Events;

        /// <summary>
        /// Map Fog blend type
        /// </summary>
        [ContentSerializer(Optional = true)]
        public short FogBlendType;

        /// <summary>
        /// Map Fog Hue
        /// </summary>
        [ContentSerializer(Optional = true)]
        public int FogHue;

        /// <summary>
        /// Map Fog Name
        /// </summary>
        [ContentSerializer(Optional = true)]
        public string FogName = string.Empty;

        /// <summary>
        /// Map Fof Opacity
        /// </summary>
        [ContentSerializer(Optional = true)]
        public byte FogOpacity;

        /// <summary>
        /// Map Fog Shift X
        /// </summary>
        [ContentSerializer(Optional = true)]
        public int FogSx;

        /// <summary>
        /// Map Fog Shift Y
        /// </summary>
        [ContentSerializer(Optional = true)]
        public int FogSy;

        /// <summary>
        /// Map Fog Zoom
        /// </summary>
        [ContentSerializer(Optional = true)]
        public float FogZoom;

        /// <summary>
        /// Map Panorama Hue
        /// </summary>
        [ContentSerializer(Optional = true)]
        public int PanoramaHue;

        /// <summary>
        /// Map Panorama Name
        /// </summary>
        [ContentSerializer(Optional = true)]
        public string PanoramaName = string.Empty;
        #endregion

        /*/// <summary>
        /// Data class for maps
        /// </summary>
        public Map()
        {
            TilesetId = 1;
            Width = 0;
            Height = 0;
            AutoplayMusicLoop = false;
            MusicLoop = new AudioFile();
            AutoplaySoundLoop = false;
            SoundLoop = new AudioFile();
        }*/
    }
}
