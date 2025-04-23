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
    public class Transitions : StoryboardObjectGenerator
    {
        Color4 Black = new Color4(24, 24, 24, 255);

        public override void Generate()
        {
		    curtains(4039, 4584);
            flash(4584);

            curtains(17121, 17666);
            flash(17666);

            var pulse = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                pulse.ScaleVec(29658, 854, 480);
                pulse.Color(29658, Black);
                pulse.Fade(29658, 30748, 0, 1);

            flash(35109);

            curtains(47646, 47918);
        }
        
        public void curtains(int startTime, int endTime)
        {
            var pulse = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(747, 0));
                pulse.ScaleVec(startTime, 450, 1000);
                pulse.Fade(startTime, 1);
                    pulse.Color(startTime, Black);
                    pulse.Rotate(OsbEasing.OutSine, startTime, endTime, 0, MathHelper.DegreesToRadians(60));
                pulse.Fade(endTime, 0);

            var pulse2 = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.BottomRight, new Vector2(-107, 480));
                pulse2.ScaleVec(startTime, 450, 1000);
                pulse2.Fade(startTime, 1);
                    pulse2.Color(startTime, Black);
                    pulse2.Rotate(OsbEasing.OutSine, startTime, endTime, 0, MathHelper.DegreesToRadians(60));
                pulse2.Fade(endTime, 0);
        }

        public void flash(int startTime)
        {
            var pulse = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                pulse.ScaleVec(startTime, 854, 480);
                pulse.Fade(startTime, startTime + 400, 0.4, 0);
                pulse.Additive(startTime);
        }
    }
}
