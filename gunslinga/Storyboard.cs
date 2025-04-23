using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Storyboard : StoryboardObjectGenerator
    {   
        //storyboard dimension = 854, 480
        //pos centre = 320, 240
        //top section extends to Y = 140
        //mid section extends from Y = 140 to Y = 254
        //bottom section starts from Y = 254
        
        public override void Generate()
        {
            double beat = Beatmap.GetTimingPointAt(0).BeatDuration;    

            //vignette
            var vigBitmap = GetMapsetBitmap("sb/vig.png");
            var vig = GetLayer("Vig").CreateSprite("sb/vig.png", OsbOrigin.TopCentre, new Vector2(320, 254));

            vig.ScaleVec(1411, 854.0f / vigBitmap.Width, (480 - 254.0f) / vigBitmap.Height);
            vig.Fade(1411, 161411, 1, 1);

            //Bottom of taiko playfield
            background(1411, 9687);
            background(12445, 44169);
            background(67618, 78652);
            background(84169, 92445);
            background(95204, 128307);
            background(150376, 161411);

            //Top of taiko playfield
            iso(1411, 161411);

            //Beginning & Ending
            noise(0, 1411, OsbEasing.InSine, 0.2f, 0.6f);
            noise(161411, 163825, OsbEasing.InExpo, 0.6f, 0.0f);

            //interludes
            party(9687, 12445);
            interlude(78652, 84169);
            party(92445, 95204);

            //pulses
            pulse(1411, beat*4);
            pulse(6928, beat*4);
            pulse(9687, beat);
            pulse(12445, beat*2);
            pulse(23480, beat*2);
            pulse(34514, beat*2);
            pulse(40032, beat*2);
            pulse(41411, beat*2);
            pulse(42790, beat*2);
            pulse(67618, beat*2);
            pulse(78652, beat*2);
            pulse(84169, beat*4);
            pulse(89687, beat*4);
            pulse(92445, beat);
            pulse(95204, beat*2);
            pulse(117273, beat*2);
            pulse(124169, beat*2);
            pulse(122790, beat*2);
            pulse(125549, beat*2);
            pulse(150376, beat*2);

            pulseChara(12445, 34514, beat*2);
            pulseChara(34514, 40032, beat);
            pulseChara(40032, 43480, beat/2);
            pulseChara(67618, 78652, beat*2);
            pulseChara(95204, 117273, beat*2);
            pulseChara(117273, 122790, beat);
            pulseChara(122790, 126238, beat/2);
            pulseChara(150376, 161411, beat*2);

            //first kiai
            curtains(42790, 45549, 8, beat/4);
            kiai1(45549, 67618, beat);

            //second kiai
            curtains(125549, 128307, 10, beat/4);
            kiai2(128307, 150376, beat);
        }  

        public void background(int startTime, int endTime)
        {
            //bg
            var bgBitmap = GetMapsetBitmap("sb/bg_low.png");
            var bg = GetLayer("MainBackground").CreateSprite("sb/bg_low.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));

            bg.Scale(startTime, 854.0f / bgBitmap.Width);
            bg.Fade(startTime, endTime, 1, 1);

            //chara
            var charaBitmap = GetMapsetBitmap("sb/bg_chara.png");
            var chara = GetLayer("Character").CreateSprite("sb/bg_chara.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));
            
            chara.Scale(startTime, 854.0f / charaBitmap.Width);
            chara.Fade(startTime, endTime, 1, 1);
        }
        
        public void party(int startTime, int endTime)
        {
            //bg
            var bgBitmap = GetMapsetBitmap("sb/bg_low.png");
            var bg = GetLayer("MainBackground").CreateSprite("sb/bg_low.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));

            bg.Scale(startTime, 854.0f / bgBitmap.Width);
            bg.Fade(OsbEasing.OutSine, startTime, endTime, 1, 0.2);

            //chara
            var charaBitmap = GetMapsetBitmap("sb/bg_chara.png");
            var chara = GetLayer("Character").CreateSprite("sb/bg_chara.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));
            
            chara.Scale(startTime, 854.0f / charaBitmap.Width);
            chara.Fade(OsbEasing.OutSine, startTime, endTime, 1, 0.4);

            var eyesBitmap = GetMapsetBitmap("sb/eyes.png");
            var eyes = GetLayer("Character2").CreateSprite("sb/Eyes.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));
            
            eyes.Scale(startTime, 854.0f / eyesBitmap.Width);
            eyes.Fade(startTime, endTime, 1, 1);
        }

        public void interlude(int startTime, int endTime)
        {
            noise(startTime, endTime, OsbEasing.InExpo, 0.4f, 1.0f);

            var bgBitmap = GetMapsetBitmap("sb/bg_low.png");
            var bg = GetLayer("MainBackground").CreateSprite("sb/bg_low.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));

            bg.Scale(startTime, 854.0f / bgBitmap.Width);
            bg.Fade(OsbEasing.OutExpo, startTime, endTime, 1, 0);

            var chara2Bitmap = GetMapsetBitmap("sb/bg_chara2.png");
            var chara2 = GetLayer("Character2").CreateSprite("sb/bg_chara2.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));
            
            chara2.Scale(startTime, 854.0f / chara2Bitmap.Width);
            chara2.Fade(OsbEasing.OutSine, startTime, endTime, 1, 0.4f);
            chara2.Fade(endTime, 0);

            var eyesBitmap = GetMapsetBitmap("sb/eyes.png");
            var eyes = GetLayer("Character2").CreateSprite("sb/Eyes.png", OsbOrigin.TopCentre, new Vector2(320, 254 - 119));
            
            eyes.Scale(startTime, 854.0f / eyesBitmap.Width);
            eyes.Fade(startTime, endTime, 1, 1);
        }

        public void iso(int startTime, int endTime) 
        {
            var bgTop = GetLayer("Iso").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));

            bgTop.ScaleVec(startTime, 854.0f, 254.0f);
            bgTop.Color(startTime, 250.0f / 255.0f , 211.0f / 255.0f , 18.0f / 255.0f);
            bgTop.Fade(startTime, endTime, 1, 1);

            var isoBitmap = GetMapsetBitmap("sb/iso.png");
            var iso = GetLayer("Iso").CreateSprite("sb/iso.png", OsbOrigin.BottomCentre, new Vector2(320, 254));

            iso.Scale(startTime, (854.0f / isoBitmap.Width));
            iso.Color(startTime, 220.0f / 255.0f , 177.0f / 255.0f , 50.0f / 255.0f);   //color = metallic gold

            var iso2 = GetLayer("Iso").CreateSprite("sb/iso.png", OsbOrigin.BottomCentre, new Vector2(320, 254));
            iso2.Scale(startTime, (854.0f / isoBitmap.Width));
            iso2.Color(startTime, 220.0f / 255.0f , 177.0f / 255.0f , 50.0f / 255.0f);  //color = metallic gold

            var speed = 32000; 

            iso.StartLoopGroup(startTime, (endTime - startTime) / speed);
            iso.MoveX(0, speed, 320.0f - 854.0f, 320.0f);
            iso.MoveY(OsbEasing.InOutSine, 0, speed/2, 254.0f, 204.0f);
            iso.MoveY(OsbEasing.InOutSine, speed/2, speed, 204.0f, 254.0f);
            iso.EndGroup();
            
            iso2.StartLoopGroup(startTime, (endTime - startTime) / speed);
            iso2.MoveX(0, speed, 320.0f, 320.0f + 854.0f);
            iso2.MoveY(OsbEasing.InOutSine, 0, speed/2, 254.0f, 204.0f);
            iso2.MoveY(OsbEasing.InOutSine, speed/2, speed, 204.0f, 254.0f);
            iso2.EndGroup();
        }

        public void pulse(int startTime, double beat)
        {
            var bitmap = GetMapsetBitmap("sb/pulse.png");
            var sprite = GetLayer("PulseSide").CreateSprite("sb/pulse.png", OsbOrigin.TopCentre, new Vector2(320, 254));

            sprite.ScaleVec(startTime, 854.0f / bitmap.Width, (480.0f - 254.0f) / bitmap.Height);
            sprite.Fade(startTime, startTime + beat, 0.6f, 0);
        }

        public void pulseChara(int startTime, int endTime, double beat)
        {   
            var charaBitmap = GetMapsetBitmap("sb/bg_chara_low.png");
            var chara = GetLayer("PulseChara").CreateSprite("sb/bg_chara_low.png", OsbOrigin.TopCentre, new Vector2(320, (254 - 119) ));
            
            chara.Color(startTime, 220.0f / 255.0f , 177.0f / 255.0f , 50.0f / 255.0f); //color = metallic gold

            var step = (endTime - startTime) / beat;
            chara.StartLoopGroup(startTime, Convert.ToInt32(step));

            chara.Scale(0, beat, (854.0f / charaBitmap.Width ), (854.0f / charaBitmap.Width ) * 1.15f);
            chara.MoveY(0, beat, (254 - 119), (254 - 119) - (254 - 119)* 0.3f);
            chara.Fade(0, beat, 0.8f, 0);

            chara.EndGroup();
        }
 
        public void noise(int startTime, int endTime, OsbEasing easing, float startOpacity, float endOpacity)
        {
            var noiseBitmap = GetMapsetBitmap("sb/noise/noise0.jpg");
            var noise = GetLayer("Noise").CreateAnimation("sb/noise/noise.jpg", 4, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240));
            noise.ScaleVec(startTime, 854.0f / noiseBitmap.Width, 480.0f / noiseBitmap.Height);
            noise.Fade(easing, startTime, endTime, startOpacity, endOpacity);
        }
        
        public void curtains(int startTime, int endTime, int quantity, double beat)
        {       
            var size = (854.0f/quantity);
            var posLeft = (320 + 854.0f/(quantity*2) - size*(quantity/2));
            var posTop = 254 - (480 - 254);

            for (var step = 0; step<quantity; step++) 
            {      
                var start = startTime + step*beat;
                int pos =   (((step+1)%2) * (step - (step/2))) +    // even
                            ((step%2) * (quantity - (step+1)/2));   // odd

                var sprite = GetLayer("Curtains").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(posLeft + size*pos, posTop));
                float red =     (((pos+1)%2) * 44) +    // even
                                ((pos%2) * 34);         // odd
                float green =   (((pos+1)%2) * 50) + 
                                ((pos%2) * 34);
                float blue =    (((pos+1)%2) * 61) + 
                                ((pos%2) * 38);

                sprite.Color(
                            start, 
                            red / 255,    // even 44 | odd 34
                            green / 255, // even 50 | odd 34
                            blue / 255  // even 61 | odd 38
                            );

                sprite.ScaleVec(start, 854.0f / quantity, 480.0f - 254.0f);
                sprite.Fade(start, endTime, 1, 1); 
                sprite.MoveY(OsbEasing.OutBounce, start, start + 150, posTop, posTop + (480 - 254));
            }
        }

        public void particlesUpward(int startTime, int endTime, int quantity, Color4 particleColor)
        {
            for(int i = 0; i < quantity; i ++)
            {
                int randomX = Random(-100, 740);

                var p = GetLayer("MovingLights").CreateSprite("sb/light.png");

                int durationStart = Random(startTime - 250, endTime - 5000 / 2);
                int durationEnd = durationStart + Random(5000 / 2, 10000 / 2);
                
                if((int)(i % Math.Sqrt(quantity)) == 0)
                {
                    p.Scale(0, Random(0.5 / 1.5, 1 / 1.5));
                }
                else
                {
                    p.Scale(0, Random(0.15 / 1.5, 0.35 / 1.5));
                }

                var perDuration = 2000;
                p.MoveY(durationStart, durationEnd, 500, Random(254, 294));

                p.StartLoopGroup(durationStart, (durationEnd - durationStart) / perDuration);
                var dir = Random(5, 10);
                p.MoveX(OsbEasing.InOutSine, 0, perDuration/2, randomX, randomX + dir);
                p.MoveX(OsbEasing.InOutSine, perDuration/2, perDuration, randomX + dir, randomX);
                p.EndGroup();
                
                p.Fade(durationStart, durationStart + 1000, 0, 0.6);

                if(durationEnd >= endTime)
                {
                    p.Fade(endTime - 1000, endTime, 0.8, 0);
                }
                else
                {
                    p.Fade(durationEnd - 1000, durationEnd, 0.8, 0);
                }
                
                p.Color(durationStart, particleColor);
                p.Additive(durationStart, durationEnd);
            }
        }

        public void kiai1(int startTime, int endTime, double beat)
        {   
            pulse(startTime, beat*2);
            pulse(48307, beat);
            pulse(51066, beat*2);
            pulse(53825, beat);
            pulse(54514, beat);
            pulse(55204, beat);
            pulse(55894, beat);

            pulse(56583, beat*2);
            pulse(59342, beat);
            pulse(62100, beat*2);
            pulse(64859, beat);
            pulse(65549, beat);
            pulse(66238, beat);
            pulse(66928, beat);

            noise(startTime, endTime, OsbEasing.None, 0.2f, 0.2f);
            particlesUpward(startTime, endTime, 100, Color4.Gold);

            shake(startTime, 46238);
            shake(48307, 48652);
            shake(51066, 51756);

            shake(53825, 54169);
            shake(54514, 54859);
            shake(55204, 55549);
            shake(55894, 56238);

            shake(56583, 57273);
            shake(59342, 59687);
            shake(62100, 62790);

            shake(64859, 65204);
            shake(65549, 65894);
            shake(66238, 66583);
            shake(66928, 67273);

            ripple(46238, 48307, 10, beat/2, 2);
            ripple(48652, 51066, 12, beat/2, 2);
            ripple(51756, 53825, 10, beat/2, 2);

            ripple(57273, 59342, 10, beat/2, 2);
            ripple(59687, 62100, 10, beat/2, 0);

            rainEffect(62790, 64859);
        }

        public void kiai2(int startTime, int endTime, double beat)
        {
            pulse(startTime, beat*2);
            pulse(131066, beat*2);
            pulse(133825, beat*2);
            pulse(136583, beat);
            pulse(137273, beat);
            pulse(137963, beat);
            pulse(138652, beat);

            pulse(139342, beat*2);
            pulse(142100, beat*2);
            pulse(144859, beat*2);
            pulse(147618, beat);
            pulse(148307, beat);
            pulse(148997, beat);
            pulse(149687, beat);

            noise(startTime, endTime, OsbEasing.None, 0.2f, 0.2f);
            particlesUpward(startTime, endTime, 100, Color4.Gold);

            shake(startTime, 128652);
            shake(131066, 131411);
            shake(133825, 134169);

            shake(136583, 136928);
            shake(137273, 137618);
            shake(137963, 138307);
            shake(138652, 138997);

            shake(139342, 140031);
            shake(142100, 142790);
            shake(144859, 145549);

            shake(147618, 147963);
            shake(148307, 148652);
            shake(148997, 149342);
            shake(149687, 150031);

            ripple(128997, 131066, 10, beat/2, 2);
            ripple(131756, 133825, 10, beat/2, 2);
            ripple(134514, 136583, 10, beat/2, 2);

            rainEffect(140031, 142100);
            rainEffect(142790, 144859);
            rainEffect(145549, 147618);
        }

        public void shake(int startTime, int endTime)
        {   
            var bitmap = GetMapsetBitmap("sb/sqs.png");
            var scale = 8;
            var sprite = GetLayer("MainBackground").CreateSprite("sb/sqs.png", OsbOrigin.Centre, new Vector2(320, 254 + (480 - 254)/2));

            sprite.Scale(startTime, (854.0f / bitmap.Width)/scale);
            sprite.Fade(startTime, 1);
            
            int interval = 50;
            int verticalStrength = 3;
            int horizontalStength = 3;
            int iterations = 10;
            int speed = 100;

            var initialPos = sprite.PositionAt(startTime);
            
            sprite.Rotate(OsbEasing.InExpo, startTime, endTime, 0, MathHelper.DegreesToRadians(90));

            sprite.StartLoopGroup(startTime, (endTime - startTime) / speed);    
            for (int i = 0; i < iterations; i++)
            {
                int randomX = Random(-horizontalStength, horizontalStength);
                int randomY = Random(-verticalStrength, verticalStrength);

                sprite.MoveX(interval * i, initialPos.X + randomX);
                sprite.MoveY(interval * i, initialPos.Y + randomY);
            }
            sprite.EndGroup();
            sprite.Fade(endTime, 0);
        }

        public void ripple(int startTime, int endTime, int quantity, double beat, int endFrames)
        {
            var bitmap = GetMapsetBitmap("sb/circle1.png");

            var size = (854.0f/quantity)*0.75f;
            float posLeft = (320 + 854.0f/(quantity*2) - size*(quantity/2));
            var scale = (854.0f / bitmap.Width)/32;
            var end = startTime + quantity*beat;

            for (var step = 0; step<quantity; step++) 
            {      
                var start = startTime + step*beat;
                var sprite = GetLayer("MainBackground").CreateSprite("sb/circle1.png", OsbOrigin.Centre, new Vector2(posLeft + size*step, 254 + (480 - 254)/2));

                sprite.Fade(startTime, start, 0.5, 0.5); 
                sprite.Fade(start, endTime, 1, 1);
                sprite.Scale(start, scale);
                sprite.Scale(OsbEasing.InExpo, start, start+100, scale, scale*1.5f);

                var randomDistanceY = Random(-50, 50);
                for (var endStep = 0; endStep<endFrames; endStep++)
                {
                    sprite.MoveY(OsbEasing.InOutSine, end + (beat*endStep), end + 100 + (beat*endStep), sprite.PositionAt(end + (beat*endStep)).Y, sprite.PositionAt(end + (beat*endStep)).Y + randomDistanceY);
                    randomDistanceY *= -1;
                }
            }
        }

        public void rainEffect(int startTime, int endTime)
        {
            var starBitmap = GetMapsetBitmap("sb/star2.png");
            var star = GetLayer("MainBackground").CreateSprite("sb/star2.png", OsbOrigin.Centre, new Vector2(320, 254 + (480 - 254)/2));

            star.Scale(startTime, (854.0f / starBitmap.Width)/32);
            star.Fade(OsbEasing.OutExpo, startTime, endTime - 690, 0.1f, 1);
            star.Fade(OsbEasing.InOutSine, endTime - 690, endTime, 1, 0);

            var loopCount = 6;
            var loopDuration = (endTime - startTime) / loopCount;
            star.StartLoopGroup(startTime, loopCount);
            star.Rotate(0, loopDuration, 0, MathHelper.DegreesToRadians(360)*0.25);
            star.EndGroup();

            for (int i = 0; i < 60; i++)
            {
                var speed = Random(500, 2500);
                var fade = Random(0.1f, 0.8f);
                var extraScale = Random(2, 5);
                var scale = new Vector2((float)Random(0.2f, 0.5f), Random(100, 200));

                float startRadius = Random(0, 10);
                float endRadius = startRadius + 254+(480 - 254)/2;
                double angle = Random(0, Math.PI * 2);

                Vector2 startPos = new Vector2(
                    (float)(320 + Math.Cos(angle) * startRadius),
                    (float)(254+(480 - 254)/2 + Math.Sin(angle) * startRadius));

                Vector2 endPos_Rain = new Vector2(
                    (float)(320 + Math.Cos(angle) * endRadius),
                    (float)(254+(480 - 254)/2 + Math.Sin(angle) * endRadius));

                var endPosRain = new Vector2(endPos_Rain.X, endPos_Rain.Y);
                var rotationRain = Math.Atan2((endPosRain.Y - startPos.Y), (endPosRain.X - startPos.X)) + (Math.PI / 2);
                var rain = GetLayer("MainBackground").CreateSprite("sb/rain.png", OsbOrigin.TopLeft);
                rain.Color(startTime, Color4.Gold);
                
                rain.StartLoopGroup(startTime, (endTime - startTime) / speed);

                rain.Additive(0, speed);
                rain.Rotate(0, rotationRain);
                rain.Fade(0, speed / 1.5f, fade, fade);
                rain.MoveX(OsbEasing.In, 0, speed, startPos.X, endPosRain.X);
                rain.MoveY(OsbEasing.In, 0, speed, startPos.Y, endPosRain.Y);
                rain.ScaleVec(OsbEasing.In, 0, speed, scale.X, 0, scale.X + extraScale, scale.Y);
                rain.Fade(speed / 1.5f, speed, fade, 0);

                rain.EndGroup();
            }
        }
    }
}
