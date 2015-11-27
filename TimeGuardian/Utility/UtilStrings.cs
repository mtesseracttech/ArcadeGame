using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian
{
    class UtilStrings
    {
        private const string AssetPath = "../assets/";

        //SPRITES
        public static readonly string SpritesPlayer = AssetPath + "sprites/player/";
        public static readonly string SpritesEnemy = AssetPath + "sprites/enemy/";
        public static readonly string SpritesUpgrades = AssetPath + "sprites/upgrade/";

        public static readonly string SpritesMenu = AssetPath + "sprites/misc/menu/";
        public static readonly string SpritesHUD = AssetPath + "sprites/misc/hud/";
        public static readonly string SpritesPause = AssetPath + "sprites/misc/pause/";
        public static readonly string SpritesOther = AssetPath + "sprites/misc/";

        public static readonly string SpritesLevel = AssetPath + "sprites/level/";

        public static readonly string SpritesLevel1 = SpritesLevel + "1/";
        public static readonly string TileLevel1 = SpritesLevel1 + "tiles/tile";

        public static readonly string SpritesLevel2 = SpritesLevel + "2/";
        public static readonly string TileLevel2 = SpritesLevel2 + "tiles/tile";

        public static readonly string SpritesLevel3 = SpritesLevel + "3/";
        public static readonly string TileLevel3 = SpritesLevel3 + "tiles/tile";

        //SOUNDS & MUSIC
        public static readonly string SoundsPlayer = AssetPath + "sounds/player/";
        public static readonly string SoundsEnemy = AssetPath + "sounds/enemy/";
        public static readonly string SoundsMenu = AssetPath + "sounds/menu/";
        public static readonly string SoundsBackground = AssetPath + "sounds/music/";

        //DEBUG RESOURCES
        public static readonly string SpriteDebug = AssetPath + "sprites/debug/debugSprite.png";
        public static readonly string SpriteDebugSmall = AssetPath + "sprites/debug/debugSpriteSmall.png";
        public static readonly string AnimSpriteDebug = AssetPath + "sprites/debug/debugAnimSprite.png";
        public static readonly string BackgroundDebug = AssetPath + "sprites/debug/debugBackground.png";

        //GENERAL VALUES
        public static readonly int TileSize = 32;
        public static readonly int TilesX = 32;
        public static readonly int TilesY = 24;
    }
}
