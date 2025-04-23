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
    public class CALM : StoryboardObjectGenerator
    {
        Color4 WHITE = new Color4(246, 241, 238, 1);

        public override void Generate()
        {
		    calm1();

            calm2();
            
            interlude();
            
            calm3();
        }

        public void calm1()
        {
            var bgPath = "sb/characters/fullart/calms/doubt.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1.3f;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(500, 120));
            bg.Scale(26548, 49424, bgScale, bgScale);
            bg.Fade(26548, 49424, 1, 1);

            bg.MoveX(26548, 37996, 500, 350);
            bg.MoveX(OsbEasing.InOutSine, 37996, 38353, 350, 150);
            bg.MoveX(38353, 49424, 150, 0);

            var bar = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-290, 210 ));
            bar.ScaleVec(OsbEasing.InOutSine, 26548, 26905, 0, 600, 400, 600);
            bar.ScaleVec(26905, 37996, 400, 600, 450, 600);
            bar.ScaleVec(37996, 38174, 450, 600, 0, 600);
            bar.Fade(26548, 0.9); bar.Fade(38174, 0);
            bar.Rotate(26548, MathHelper.DegreesToRadians(-25));
            bar.Color(26548, WHITE);

            var curtain = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-300, 210 ));
            curtain.ScaleVec(OsbEasing.InOutSine, 26548, 26905, 0, 600, 400, 600);
            curtain.ScaleVec(26905, 37996, 400, 600, 450, 600);
            curtain.ScaleVec(37996, 38174, 450, 600, 0, 600);
            curtain.Fade(26548, 0.9); curtain.Fade(38174, 0);
            curtain.Rotate(26548, MathHelper.DegreesToRadians(-25));
            curtain.Color(26548, new Color4(252, 130, 147, 1));

            var bar2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(920, 210 ));
            bar2.ScaleVec(OsbEasing.InOutSine, 37996, 38353, 0, 600, 400, 600);
            bar2.ScaleVec(38353, 49424, 400, 600, 460, 600);
            bar2.Fade(37996, 0.9); bar2.Fade(49424, 0);
            bar2.Rotate(37996, MathHelper.DegreesToRadians(25));
            bar2.Color(37996, WHITE);

            var curtain2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(930, 210 ));
            curtain2.ScaleVec(OsbEasing.InOutSine, 37996, 38353, 0, 600, 400, 600);
            curtain2.ScaleVec(38353, 49424, 400, 600, 460, 600);
            curtain2.Fade(37996, 0.9); curtain2.Fade(49424, 0);
            curtain2.Rotate(37996, MathHelper.DegreesToRadians(25));
            curtain2.Color(37996, new Color4(252, 130, 147, 1));

            var gear = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(-107, 480));
            gear.Scale(26548, 0.6);
            gear.Fade(OsbEasing.InOutSine, 26548, 26905, 0, 0.5); gear.Fade(37996, 0);
            gear.Rotate(26548, 37996, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(360));
            gear.Color(26548, WHITE);

            var gear2 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(90, 480));
            gear2.Scale(26548, 0.3);
            gear2.Fade(OsbEasing.InOutSine, 26548, 26905, 0, 0.5); gear2.Fade(37996, 0);
            gear2.Rotate(26548, 37996, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-720));
            gear2.Color(26548, WHITE);

            var gear3 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(747, 480));
            gear3.Scale(37996, 0.6);
            gear3.Fade(OsbEasing.InOutSine, 37996, 38353, 0, 0.5); gear3.Fade(49424, 0);
            gear3.Rotate(37996, 49424, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-360));
            gear3.Color(37996, WHITE);

            var gear4 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(550, 480));
            gear4.Scale(37996, 0.3);
            gear4.Fade(OsbEasing.InOutSine, 37996, 38353, 0, 0.5); gear4.Fade(49424, 0);
            gear4.Rotate(37996, 49424, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(720));
            gear4.Color(37996, WHITE);
        }

        public void calm2()
        {
            var bgPath = "sb/characters/fullart/calms/doubt2.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1.2f;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(500, 190));
            bg.Scale(105148, 128003, bgScale, bgScale);
            bg.Fade(105148, 128003, 1, 1);

            bg.MoveX(105148, 116576, 450, 300);
            bg.MoveX(OsbEasing.InOutSine, 116576, 116933, 300, 100);
            bg.MoveX(116933, 128003, 100, -50);

            var bar = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-290, 210 ));
            bar.ScaleVec(OsbEasing.InOutSine, 105148, 105505, 0, 600, 400, 600);
            bar.ScaleVec(105505, 116576, 400, 600, 450, 600);
            bar.ScaleVec(116576, 116933, 450, 600, 0, 600);
            bar.Fade(105148, 0.9); bar.Fade(116933, 0);
            bar.Rotate(105148, MathHelper.DegreesToRadians(-25));
            bar.Color(105148, WHITE);

            var curtain = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-300, 210 ));
            curtain.ScaleVec(OsbEasing.InOutSine, 105148, 105505, 0, 600, 400, 600);
            curtain.ScaleVec(105505, 116576, 400, 600, 450, 600);
            curtain.ScaleVec(116576, 116933, 450, 600, 0, 600);
            curtain.Fade(105148, 0.9); curtain.Fade(116933, 0);
            curtain.Rotate(105148, MathHelper.DegreesToRadians(-25));
            curtain.Color(105148, new Color4(252, 130, 147, 1));

            var bar2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(920, 210 ));
            bar2.ScaleVec(OsbEasing.InOutSine, 116576, 116933, 0, 600, 400, 600);
            bar2.ScaleVec(116933, 128003, 400, 600, 460, 600);
            bar2.Fade(116576, 0.9); bar2.Fade(128003, 0);
            bar2.Rotate(116576, MathHelper.DegreesToRadians(25));
            bar2.Color(116576, WHITE);

            var curtain2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(930, 210 ));
            curtain2.ScaleVec(OsbEasing.InOutSine, 116576, 116933, 0, 600, 400, 600);
            curtain2.ScaleVec(116933, 128003, 400, 600, 460, 600);
            curtain2.Fade(116576, 0.9); curtain2.Fade(128003, 0);
            curtain2.Rotate(116576, MathHelper.DegreesToRadians(25));
            curtain2.Color(116576, new Color4(252, 130, 147, 1));

            var gear = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(-107, 480));
            gear.Scale(105148, 0.6);
            gear.Fade(OsbEasing.InOutSine, 105148, 105505, 0, 0.5); gear.Fade(116576, 0);
            gear.Rotate(105148, 116576, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(360));
            gear.Color(105148, WHITE);

            var gear2 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(90, 480));
            gear2.Scale(105148, 0.3);
            gear2.Fade(OsbEasing.InOutSine, 105148, 105505, 0, 0.5); gear2.Fade(116576, 0);
            gear2.Rotate(105148, 116576, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-720));
            gear2.Color(105148, WHITE);

            var gear3 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(747, 480));
            gear3.Scale(116576, 0.6);
            gear3.Fade(OsbEasing.InOutSine, 116576, 116933, 0, 0.5); gear3.Fade(128003, 0);
            gear3.Rotate(116576, 128003, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-360));
            gear3.Color(116576, WHITE);

            var gear4 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(550, 480));
            gear4.Scale(116576, 0.3);
            gear4.Fade(OsbEasing.InOutSine, 116576, 116933, 0, 0.5); gear4.Fade(128003, 0);
            gear4.Rotate(116576, 128003, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(720));
            gear4.Color(116576, WHITE);
        }

        public void calm3()
        {
            var bgPath = "sb/characters/fullart/calms/doubt3.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1.15f;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(500, 70));
            bg.Scale(199436, 222286, bgScale, bgScale);
            bg.Fade(199436, 222286, 1, 1);

            bg.MoveX(199436, 210838, 650, 575);
            bg.MoveX(OsbEasing.InOutSine, 210838, 211203, 575, 375);
            bg.MoveX(211203, 222286, 375, 275);

            var bar = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-290, 210 ));
            bar.ScaleVec(OsbEasing.InOutSine, 199437, 199787, 0, 600, 400, 600);
            bar.ScaleVec(199787, 210837, 400, 600, 450, 600);
            bar.ScaleVec(210837, 211203, 450, 600, 0, 600);
            bar.Fade(199437, 0.9); bar.Fade(211203, 0);
            bar.Rotate(199437, MathHelper.DegreesToRadians(-25));
            bar.Color(199437, WHITE);

            var curtain = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-300, 210 ));
            curtain.ScaleVec(OsbEasing.InOutSine, 199437, 199787, 0, 600, 400, 600);
            curtain.ScaleVec(199787, 210837, 400, 600, 450, 600);
            curtain.ScaleVec(210837, 211203, 450, 600, 0, 600);
            curtain.Fade(199437, 0.9); curtain.Fade(211203, 0);
            curtain.Rotate(199437, MathHelper.DegreesToRadians(-25));
            curtain.Color(199437, new Color4(252, 130, 147, 1));

            var bar2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(920, 210 ));
            bar2.ScaleVec(OsbEasing.InOutSine, 210837, 211203, 0, 600, 400, 600);
            bar2.ScaleVec(211203, 222285, 400, 600, 460, 600);
            bar2.Fade(210837, 0.9); bar2.Fade(222285, 0);
            bar2.Rotate(210837, MathHelper.DegreesToRadians(25));
            bar2.Color(210837, WHITE);

            var curtain2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(930, 210 ));
            curtain2.ScaleVec(OsbEasing.InOutSine, 210837, 211203, 0, 600, 400, 600);
            curtain2.ScaleVec(211203, 222285, 400, 600, 460, 600);
            curtain2.Fade(210837, 0.9); curtain2.Fade(222285, 0);
            curtain2.Rotate(210837, MathHelper.DegreesToRadians(25));
            curtain2.Color(210837, new Color4(252, 130, 147, 1));

            var gear = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(-107, 480));
            gear.Scale(199436, 0.6);
            gear.Fade(OsbEasing.InOutSine, 199436, 199787, 0, 0.5); gear.Fade(210837, 0);
            gear.Rotate(199436, 210837, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(360));
            gear.Color(199436, WHITE);

            var gear2 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(90, 480));
            gear2.Scale(199436, 0.3);
            gear2.Fade(OsbEasing.InOutSine, 199436, 199787, 0, 0.5); gear2.Fade(210837, 0);
            gear2.Rotate(199436, 210837, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-720));
            gear2.Color(199436, WHITE);

            var gear3 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(747, 480));
            gear3.Scale(210838, 0.6);
            gear3.Fade(OsbEasing.InOutSine, 210838, 211203, 0, 0.5); gear3.Fade(222285, 0);
            gear3.Rotate(210838, 222285, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-360));
            gear3.Color(210838, WHITE);

            var gear4 = GetLayer("Background").CreateSprite("sb/gear.png", OsbOrigin.Centre, new Vector2(550, 480));
            gear4.Scale(210838, 0.3);
            gear4.Fade(OsbEasing.InOutSine, 210838, 211203, 0, 0.5); gear4.Fade(222285, 0);
            gear4.Rotate(210838, 222285, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(720));
            gear4.Color(210838, WHITE);
        }

        public void interlude()
        {
            var misere1 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere1.ScaleVec(176573, 854, 480-254);
                misere1.Fade(176573, 1); misere1.Fade(199436, 0);
                misere1.Color(176573, new Color4(0, 0, 0, 1));

            rain(172278, 199437, WHITE);

        }

        public void rain(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Background").CreateSprite("sb/smoke/s"+Random(0,9)+".png");

                var rainStartTime = Random(startTime, startTime + 6400);

                var randX = Random(-107, 747) - 50; var randY = Random(550, 650);
                var rainEndTime = 6400;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1000 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.Scale(rainStartTime, 0.6);
                rain.Color(rainStartTime, color);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(Random(0,360)));
                rain.Fade(rainStartTime, 0.2); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                    rain.Scale(OsbEasing.InSine, 0, rainEndTime, 0.7, 0.3);
                    rain.Fade(OsbEasing.InSine, 0, rainEndTime, 0.2, 0);
                rain.EndGroup();
            }
        }
    }
}
