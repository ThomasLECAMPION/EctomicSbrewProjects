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
    public class Kiai : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    
            rain(31461, 52330);
            rain(73200, 94070);

            rain(152127, 162233);
            rain(164759, 192864);

            rain(255282, 285518);

            rain(341471, 362552);

            rain(396173, 420947);

            rain(453123, 479976);
            rain(506829, 533682);

            rain(594469, 611969);
            rain(634469, 651969);

            rain(695956, 715648); 
            rain(735341, 755033);
            rain(774725, 794418);

            rain(839887, 853800);
            rain(881626, 909452);

            rain(966515, 977678);
            rain(1000003, 1022329);

            rain(1094755, 1116698);
            rain(1138641, 1160584);

            rain(1221763, 1241974);
            rain(1272290, 1302132);

            rain(1353912, 1376368);
            rain(1410052, 1432508);

            rain(1544464, 1560874);

            rain(1623048, 1647048);
            rain(1677048, 1701048);
        }

        public void rain(int startTime, int endTime)
        {
            var flash = GetLayer("Flash").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                    flash.ScaleVec(startTime, 854, 480);
                    flash.Fade(startTime, startTime + 400, 0.7, 0);
                    flash.Fade(endTime - 1500, endTime, 0, 0.7);
                    flash.Fade(endTime, endTime + 400, 0.9, 0);

            var quantity = 30;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Rain").CreateSprite("sb/particles/spark.png");

                var rainStartTime = Random(startTime-2000, startTime);

                var randX = Random(-107, 747); var randY = Random(490, 510); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 2000 / randZ;

                double angle = Math.Atan2(80 - randY, -80 - randX) * (180/Math.PI);
                var radius = 500 - randY;
                Vector2 endPos = new Vector2(Random(-130, -70) , Random(80, 130));

                rain.ScaleVec(rainStartTime, 0.02, 0.005);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(angle));
                rain.Fade(rainStartTime, 0); rain.Fade(startTime, 0.5); rain.Fade(endTime - 1000, endTime, 0.5, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime)+1);
                    rain.MoveX(OsbEasing.OutSine, 0, rainEndTime, randX, endPos.X);
                    rain.MoveY(OsbEasing.InSine, 0, rainEndTime, randY, endPos.Y);
                rain.EndGroup();
            }

            int topLength = 3000;

            for (int i=0; i<quantity*1.5; i++)
            {
                var rain = GetLayer("RainTop").CreateSprite("sb/particles/hl.png");

                var rainStartTime = Random(startTime-topLength, startTime);

                var randX = Random(-47, 687); var randY = Random(60, 80);
                var rainEndTime = topLength;

                var radius = 500 - randY;
                int endX = Random(0,10)%2 == 0 ? randX - 40 : randX + 40;
                int endY = Random(0,10)%2 == 0 ? randY - 20 : randY + 20;
                Vector2 endPos = new Vector2(endX , endY);

                rain.Scale(rainStartTime, i%3==0 ? 0.8 : 0.5);
                rain.Color(rainStartTime, new Color4(1, Random(0.4f, 0.6f), Random(0f, 0.2f), 1));
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime)+1);
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                    rain.Fade(0, rainEndTime/2, 0, 0.08); rain.Fade(rainEndTime/2, rainEndTime, 0.1, 0);
                rain.EndGroup();
            }

            for (int i=0; i<quantity*1.5; i++)
            {
                var rain = GetLayer("RainTop").CreateSprite("sb/particles/o.png");

                var rainStartTime = Random(startTime-topLength, startTime);

                var randX = Random(-47, 687); var randY = Random(40, 100);
                var rainEndTime = topLength;

                var radius = 500 - randY;
                int endX = Random(0,10)%2 == 0 ? randX - 40 : randX + 40;
                int endY = Random(0,10)%2 == 0 ? randY - 20 : randY + 20;
                Vector2 endPos = new Vector2(endX , endY);

                rain.Scale(rainStartTime, i%3==0 ? 0.2 : 0.15);
                rain.Color(rainStartTime, new Color4(Random(0.8f, 1f), Random(0.3f, 0.7f), Random(0f, 0.3f), 1));
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime)+1);
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                    rain.Fade(0, rainEndTime/2, 0, 0.2); rain.Fade(rainEndTime/2, rainEndTime, 0.3, 0);
                rain.EndGroup();
            }

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("RainTop").CreateSprite("sb/particles/n.png");

                var rainStartTime = Random(startTime-topLength, startTime);

                var randX = Random(-47, 687); var randY = Random(40, 100);
                var rainEndTime = topLength;

                var radius = 500 - randY;
                int endX = Random(0,10)%2 == 0 ? randX - 40 : randX + 40;
                int endY = Random(0,10)%2 == 0 ? randY - 20 : randY + 20;
                Vector2 endPos = new Vector2(endX , endY);

                rain.Scale(rainStartTime, i%3==0 ? 0.05 : 0.025);
                rain.Color(rainStartTime, new Color4(Random(0.9f, 1f), Random(0.5f, 0.9f), Random(0.2f, 0.5f), 1));
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime)+1);
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                    rain.Fade(0, rainEndTime/2, 0, 0.4); rain.Fade(rainEndTime/2, rainEndTime, 0.6, 0);
                rain.EndGroup();
            }
        }
    }
}
