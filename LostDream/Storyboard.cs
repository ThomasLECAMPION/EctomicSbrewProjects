using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Storyboard : StoryboardObjectGenerator
    {
        int beat = 1673 - 1340;

        Color4 colorBlack = new Color4(24, 24, 24, 1);

        public override void Generate()
        {   
            var top = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            top.ScaleVec(0, 854.0f, 140.0f);
            top.Color(0, new Color4(54, 54, 124, 1));
            top.Fade(0, 118673, 1, 1);


            var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
            playfield.ScaleVec(0, 854.0f, 114.0f);
            playfield.Color(0, colorBlack);
            playfield.Fade(0, 118673, 1, 1);

            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = 854.0f / bgBitmap.Width;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 140));
            bg.Scale(0, 118673, bgScale, bgScale);
            bg.Fade(0, 118673, 1, 1);

            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(0, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Color(0, colorBlack);
                vignette.Fade(0, 118673, 0.8, 0.8);
        }
    }
}
