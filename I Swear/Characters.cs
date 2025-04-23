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
    public class Characters : StoryboardObjectGenerator
    {
        /*
            1: no lyrics 1
            2: calm lyrics 1

            3: pre kiai 1
            4: kiai 1

            5: no lyrics 2
            6: calm lyrics 2

            7: pre kiai 2
            8: kiai 2

            9: low calm lyrics
            10: calm lyrics
            11: no lyrics hype
            12: calm lyrics

            13: pre kiai 3 (kinda)
            14: kiai 3

            15: ending no lyrics
        */
        Color4 WHITE = new Color4(246, 241, 238, 1);

        public override void Generate()
        {
		    kiai1();
            kiai2();
            kiai3();
        }
        
        public void kiai3()
        {   
            var bgPath = "sb/characters/fullart/kiais/kiai3/kiai_flou.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            var bg = GetLayer("Background2").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 180));
            bg.Scale(259424, 270845, bgScale, bgScale);
            bg.Fade(259424, 1); bg.Fade(270845, 0);

            var bg0 = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 180));
            bg0.Scale(270845, 295138, bgScale, bgScale);
            bg0.Fade(259424, 0); bg0.Fade(270845, 1); bg0.Fade(295138, 0);

            var noiseBitmap = GetMapsetBitmap("sb/noise/noise0.jpg");
            var noise = GetLayer("Background").CreateAnimation("sb/noise/noise.jpg", 4, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240));
                noise.Scale(259424, 854.0f / noiseBitmap.Width);
                noise.Fade(259424, 295138, 0.1, 0.1); 
            
            var chara = GetLayer("Background2").CreateSprite("sb/characters/fullart/kiais/kiai3/kiai_cut.png", OsbOrigin.TopCentre, new Vector2(320, 145));
            chara.Scale(259424, 295138, bgScale, bgScale);
            chara.Fade(259424, 0); chara.Fade(270845, 295138, 1, 1);
            
            bg.MoveY(259424, 295138, 180, 250);
            bg0.MoveY(259424, 295138, 180, 250);
            chara.MoveY(259424, 295138, 180, 250);
            
            for(int i=0; i<4; i++)
            {
                var curtain = GetLayer("Curtain").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(200, 210 ));
                curtain.ScaleVec(264566, 100, 400);
                curtain.Fade(264566, 0); curtain.Fade(270845, 0.4); curtain.Fade(295138, 0);
                curtain.Rotate(264566, MathHelper.DegreesToRadians(35));
                curtain.Color(264566, new Color4(252, 130, 147, 1));

                curtain.StartLoopGroup(264566 + i*1750, 5);
                    curtain.MoveX(0, 7000, -140, 1000);
                curtain.EndGroup();
            }
 
            rain(270845, 295138);
        }

        public void kiai2()
        {
            var bgPath = "sb/characters/fullart/kiais/kiai2/kiai_flou.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 145));
            bg.Scale(142289, 176573, bgScale, bgScale);
            bg.Fade(142289, 176573, 1, 1);

            var noiseBitmap = GetMapsetBitmap("sb/noise/noise0.jpg");
            var noise = GetLayer("Background").CreateAnimation("sb/noise/noise.jpg", 4, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240));
                noise.Scale(142289, 854.0f / noiseBitmap.Width);
                noise.Fade(142289, 176573, 0.1, 0.1); 
            
            var chara = GetLayer("Background2").CreateSprite("sb/characters/fullart/kiais/kiai2/kiai_cut.png", OsbOrigin.TopCentre, new Vector2(320, 145));
            chara.Scale(142289, 176573, bgScale, bgScale);
            chara.Fade(142289, 176573, 1, 1);
            
            bg.MoveY(142289, 176573, 200, 130);
            chara.MoveY(142289, 176573, 200, 130);

            for(int i=0; i<4; i++)
            {
                var curtain = GetLayer("Curtain").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(200, 210 ));
                curtain.ScaleVec(136500, 100, 400);
                curtain.Fade(136500, 0); curtain.Fade(142289, 0.4); curtain.Fade(176573, 0);
                curtain.Rotate(136500, MathHelper.DegreesToRadians(35));
                curtain.Color(136500, new Color4(252, 130, 147, 1));

                curtain.StartLoopGroup(136500 + i*1750, 6);
                    curtain.MoveX(0, 7000, -140, 1000);
                curtain.EndGroup();
            }

            rain(142289, 176573);
        }

        public void kiai1()
        {
            var bgPath = "sb/characters/fullart/kiais/kiai1/kiai_flou.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 145));
            bg.Scale(63710, 99444, bgScale, bgScale);
            bg.Fade(63710, 99444, 1, 1);

            var noiseBitmap = GetMapsetBitmap("sb/noise/noise0.jpg");
            var noise = GetLayer("Background").CreateAnimation("sb/noise/noise.jpg", 4, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240));
                noise.Scale(63710, 854.0f / noiseBitmap.Width);
                noise.Fade(63710, 99444, 0.1, 0.1); 
            
            var chara = GetLayer("Background2").CreateSprite("sb/characters/fullart/kiais/kiai1/kiai_cut.png", OsbOrigin.TopCentre, new Vector2(320, 145));
            chara.Scale(63710, 99444, bgScale, bgScale);
            chara.Fade(63710, 99444, 1, 1);
            
            bg.MoveY(63710, 99444, 110, 180);
            chara.MoveY(63710, 99444, 110, 180);


            for(int i=0; i<4; i++)
            {
                var curtain = GetLayer("Curtain").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(200, 210 ));
                curtain.ScaleVec(59000, 100, 400);
                curtain.Fade(59000, 0); curtain.Fade(63710, 0.4); curtain.Fade(99444, 0);
                curtain.Rotate(59000, MathHelper.DegreesToRadians(35));
                curtain.Color(59000, new Color4(252, 130, 147, 1));

                curtain.StartLoopGroup(59000 + i*1750, 5);
                    curtain.MoveX(0, 7000, -140, 1000);
                curtain.EndGroup();
            }

            rain(63710, 99444);
            rainTop(63710, 99444, 103729, new Color4(252, 130, 147, 1));
            rainTop(142289, 176573, 180866, new Color4(252, 130, 147, 1));
            rainTop(270845, 295138, 300851, new Color4(252, 130, 147, 1));
        }

        public void rain(int startTime, int endTime)
        {
            var quantity = 70;
            int topLength = 4000;
            
            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("KiaiParticles").CreateSprite("sb/particles/o.png");

                var rainStartTime = Random(startTime-topLength, startTime);

                var randX = Random(-80, 820)-180; var randY = Random(480, 560);
                var rainEndTime = topLength;

                float angle = MathHelper.DegreesToRadians(55);
                float distance = 350;

                int endX = (int)(randX + Math.Cos(angle) * distance);
                int endY = (int)(randY - Math.Sin(angle) * distance);
                Vector2 endPos = new Vector2(endX , endY);

                rain.Scale(rainStartTime, i%3==0 ? 0.2 : 0.15);
                rain.Fade(rainStartTime, 0);
                rain.Color(rainStartTime, new Color4(Random(0.5f, 0.7f), Random(0.3f, 0.4f), Random(0f, 0.4f), 1));
                rain.Additive(rainStartTime);

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime)+1);
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                    rain.Fade(0, 0.5); rain.Fade(rainEndTime/2, rainEndTime, 0.8, 0);
                rain.EndGroup();
            }
        }

        public void rainTop(int startTime, int endTime, int trueEnd, Color4 color)
        {
            var quantity = 20;

            for (int i=0; i<quantity; i++)
            {
                var rainStartTime = Random(startTime - 8000, startTime);
                var randX = Random(-107, 747); var randY = Random(170, 180);
                var rainEndTime = 8000;

                var rain = GetLayer("RainTop").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(randX, 145));

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 200;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                int randRota = Random(360);
                rain.Scale(rainStartTime, 40);
                rain.Color(rainStartTime, new Color4(252, 130, 147, 1));
                rain.Rotate(rainStartTime, trueEnd, MathHelper.DegreesToRadians(randRota), MathHelper.DegreesToRadians(i%2==0?randRota+720:randRota-720));
                rain.Fade(rainStartTime, 0); rain.Fade(startTime, 0.15); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime);

                rain.StartLoopGroup(rainStartTime, (int)((trueEnd - rainStartTime) / rainEndTime));
                    rain.MoveY(0, rainEndTime, randY, endPos.Y);
                rain.EndGroup();
            }
        }
    }
}
