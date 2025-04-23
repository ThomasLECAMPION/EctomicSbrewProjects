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
        public override void Generate()
        {   
            curtain(43817, 44141);
            flash(44141);

            pulse(64249, 64898);

            pulse(85006, 85655);

            curtain(106978, 107353);
            flash(107353);

            curtain(134837, 135224);
            flash(135224);

            pulse(159224, 159999);

            curtain(223966, 224266);
            flash(224266);

            pulse(242865, 243466);
            pulse(262066, 262665);

            curtain(281245, 281524);
            flash(281524);

            pulse(289705, 290251);

            curtain(367184, 367462);
            flash(367462);

            pulse(307160, 307705);

            pulse(324614, 325160);

            pulse(382462, 383017);

            curtain(344963, 345240);
            flash(345240);

            pulse(346906, 347462);

            pulse(364684, 365239);

            curtain(110063, 110450);
            flash(110450);

            flash(113547);
            flash(116644);
            flash(119741);
            flash(122837);

            flash(125934);
            flash(129031);

            pulse(182865, 183466);

            curtain(204766, 205065);
            flash(205065);

            pulse(185266, 185865);

            curtain(334481, 334725);
            flash(334725);

        }   

        public void curtain(int startTime, int endTime)
        {
            var curtainBitmap = GetMapsetBitmap("sb/geometry/white.png");
		    var curtain = GetLayer("Transitions").CreateSprite("sb/geometry/white.png", OsbOrigin.BottomCentre, new Vector2(320, 0));
                curtain.ScaleVec(startTime, (854.0f/curtainBitmap.Width)*1.2, (480.0f/curtainBitmap.Height)*1.3);
                curtain.Color(OsbEasing.InCubic, startTime, endTime, Color4.White, Color4.Black);
                curtain.Rotate(startTime, MathHelper.DegreesToRadians(5));
                curtain.Fade(startTime, endTime, 0.2, 1); curtain.Fade(endTime, 0);

                curtain.MoveY(OsbEasing.InSine, startTime, endTime, -40, 560);
        }

        public void flash(int startTime)
        {
            var pulse = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                pulse.ScaleVec(startTime, 854, 480);
                pulse.Fade(startTime, startTime + 500, 0.4, 0);
                pulse.Additive(startTime);
        }

        public void pulse(int startTime, int midTime)
        {   
            var pulse = GetLayer("Pulse").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            pulse.ScaleVec(startTime, 854, 480);
            pulse.Fade(startTime, midTime, 0, 0.3);
            pulse.Fade(midTime, midTime + 500, 0.4, 0);
            pulse.Additive(startTime);
        }
    }
}
