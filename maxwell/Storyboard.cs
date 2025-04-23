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
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        public override void Generate()
        {
            int startTime = 224;
            int endTime = 47918;

            var playfieldFade = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfieldFade.ScaleVec(startTime, 854.0f, 114.0f);
                playfieldFade.Color(startTime, Color4.Black);
                playfieldFade.Fade(startTime, 1);
                playfieldFade.Fade(endTime, 0);

            var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(startTime, 854.0f, 114.0f);
                playfield.Color(startTime, colorBlack);
                playfield.Fade(startTime, 1);
                playfield.Fade(endTime, 0);
            
            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(startTime, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Color(startTime, colorBlack);
                vignette.Fade(startTime, 0.8); 
                vignette.Fade(endTime, 0); 
        }
    }
}
