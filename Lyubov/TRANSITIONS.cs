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
    public class TRANSITIONS : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    panelSIDES(7130, 7614, new Color4(0, 0, 0, 1));

            flash(17937);
            flash(23098);

            panelSIDES(27775, 28259, new Color4(80, 15, 25, 1));

            flash(28259);
            flash(38582);
            panelSIDES(48421, 48904, new Color4(0, 0, 0, 1));

            flash(54066);
            
            flash(74711);
            flash(76001);
            flash(77292);

            for(int i=0; i<31; i++)
            {
                var circle = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(-107 + i*(857/61), 0));
                circle.ScaleVec(53421, 53421 + i*10, 0, 480, 854/61, 480);
                circle.Fade(53421, 1); circle.Fade(54066, 0);
                circle.Color(53421, new Color4(0, 0, 0, 1));
            }

            for(int i=0; i<31; i++)
            {
                var circle = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(747 - i*(857/61), 0));
                circle.ScaleVec(53421, 53421 + i*10, 0, 480, 854/61, 480);
                circle.Fade(53421, 1); circle.Fade(54066, 0);
                circle.Color(53421, new Color4(0, 0, 0, 1));
            }
        }

        public void flash(int startTime)
        {
            var flash = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 240));
                    flash.ScaleVec(startTime, 854, 480);
                    flash.Fade(startTime, startTime + 550, 0.5, 0);
        }

        public void flashIN(int startTime, int endTime)
        {
            var flash = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 240));
                    flash.ScaleVec(startTime, 854, 480);
                    flash.Fade(startTime, endTime, 0, 0.7);
                    flash.Fade(endTime, endTime + 550, 0.9, 0);
        }

        public void panelUP(int startTime, int endTime, int endStuck)
        {
            var curtain = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
                    curtain.ScaleVec(OsbEasing.InSine, startTime, endTime, 854, 0, 854, 480);
                    curtain.ScaleVec(endTime, 854, 480);
                    curtain.Fade(startTime, 1); curtain.Fade(endStuck, 0);
                    curtain.Color(startTime, new Color4(252, 130, 147, 1));
        }

        public void panelSIDES(int startTime, int endTime, Color4 color, int endStuck = 0, string layer="")
        {
            var curtain = GetLayer(layer==""? "Transitions":layer).CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(320 - (854/2), 240));
                    curtain.ScaleVec(OsbEasing.InCubic, startTime, endTime, 0, 480, 854/2, 480);
                    curtain.Fade(startTime, 1); curtain.Fade(endStuck==0? endTime:endStuck, endTime+150, 1, 0);
                    curtain.Color(startTime, color);

            var curtain2 = GetLayer(layer==""? "Transitions":layer).CreateSprite("sb/pixel.png", OsbOrigin.CentreRight, new Vector2(320 + (854/2), 240));
                    curtain2.ScaleVec(OsbEasing.InCubic, startTime, endTime, 0, 480, 854/2, 480);
                    curtain2.Fade(startTime, 1); curtain2.Fade(endStuck==0? endTime:endStuck, endTime+150, 1, 0);
                    curtain2.Color(startTime, color);
        }
    }
}
