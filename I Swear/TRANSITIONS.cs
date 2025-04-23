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
            flashIN(13723, 15152);

            flashIN(25829, 26548);
            flash(37996);

            panelSIDES(48174, 48710, 49424, "TRANSITIONS_UNDERLYRICS");
            flash(49424);

		    panelSIDES(60317, 60853);
            panelUP(63174, 63353, 63710);
            flashIN(63353, 63710);
            flashIN(96384, 99444);

            flashIN(104444, 105148);
            flash(116576);

            panelSIDES(126762, 127294, 128004, "TRANSITIONS_UNDERLYRICS");
            flash(128004);

            panelSIDES(138896, 139432);
            panelUP(141753, 141932, 142289);
            flashIN(141932, 142289);
            flashIN(174957, 176573);

            flash(199436);

            flash(210837);

            //panelSIDES(221031, 221560);
            flashIN(219238, 222285);

            panelSIDES(247474, 248010);
            
            //panelUP(258903, 259082, 259424);
            flashIN(257832, 259424);

            flashIN(269969, 270845);

            flashIN(292102, 295138);

            flashIN(300138, 300852);

            flash(304959);
        }

        public void flash(int startTime)
        {
            var flash = GetLayer("Transitions").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 240));
                    flash.ScaleVec(startTime, 854, 480);
                    flash.Fade(startTime, startTime + 550, 0.9, 0);
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

        public void panelSIDES(int startTime, int endTime, int endStuck = 0, string layer="")
        {
            var curtain = GetLayer(layer==""? "Transitions":layer).CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(320 - (854/2), 240));
                    curtain.ScaleVec(OsbEasing.OutSine, startTime, endTime, 0, 480, 854/2, 480);
                    curtain.Fade(startTime, 1); curtain.Fade(endStuck==0? endTime:endStuck, 0);
                    curtain.Color(startTime, new Color4(0, 0, 0, 1));

            var curtain2 = GetLayer(layer==""? "Transitions":layer).CreateSprite("sb/pixel.png", OsbOrigin.CentreRight, new Vector2(320 + (854/2), 240));
                    curtain2.ScaleVec(OsbEasing.OutSine, startTime, endTime, 0, 480, 854/2, 480);
                    curtain2.Fade(startTime, 1); curtain2.Fade(endStuck==0? endTime:endStuck, 0);
                    curtain2.Color(startTime, new Color4(0, 0, 0, 1));
        }
    }
}
