﻿using System;
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

        //SOUNDS & MUSIC
        public static readonly string SoundsPlayer = AssetPath + "sounds/player/";
        public static readonly string SoundsWeapon = AssetPath + "sounds/weapon/";
        public static readonly string SoundsBackground = AssetPath + "sounds/music/";

        //DEBUG RESOURCES
        public static readonly string SpriteDebug = AssetPath + "sprites/debug/debugSprite.png";
        public static readonly string AnimSpriteDebug = AssetPath + "sprites/debug/debugAnimSprite.png";
        public static readonly string BackgroundDebug = AssetPath + "sprites/debug/debugBackground.png";
    }
}
