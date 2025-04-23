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
    //storyboard dimension = 854, 480
    //pos centre = 320, 240
    //top section extends to Y = 140
    //mid section extends from Y = 140 to Y = 254
    //bottom section starts from Y = 254 | center is Y = 367

    /* 
    607 - 43274 | RAIN 1
        rain (multi layer for 3d effect)
        black and white bg

        thunder = flandre darker and bg lighter
 
    43274 - 64607 | 
        first half = title E N T R A N C E turning on to the synth

    64607 - 107274 | TECHNO
        geometry climbing to the beat like a russian storyboarder does


    107274 - 128607 | 
        black and white bg that switch to color at half

    128607 - 139274 | BUILD UP

        

    139274 - 160603 | CHORUS
        bg slightly blurred going down
        tuTUTUtu

    160603 - 181936 | KIAI 1
        bg
        distortions
        spectrum?

    181936 - 203274 | RAIN 2
        

    203274 - 213940 | 


    213940 - 216607 | GLISSANDO


    219274 - 221940 | DISTORTION


    221940 - 243274 |


    243274 - 265941 | CHORUS 2


    265941 - 287274 | KIAI 2


    */

    public class Storyboard : StoryboardObjectGenerator
    {   
        int beat = 940 - 607;

        int bgOffset = 180;

        string bgPath = "entrance.jpg";

        public override void Generate()
        {   
            intro(607, 43274); rain(607, 43274, Color4.White);
            kiai(160603, 181936);

            //
            var top = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 70));
                top.Color(0, Color4.Black);
                top.ScaleVec(0, 854, 140);
                top.Fade(0, 1);
                top.Fade(287274, 0);                

            var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(0, 854.0f, 114.0f);
                playfield.Color(0, Color4.White);
                playfield.Fade(0, 1); playfield.Fade(287274, 0);

            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(0, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Fade(0, 1); vignette.Fade(287274, 0);
                vignette.Color(0, Color4.Black);
        }

        public void intro(int startTime, int endTime)
        {   
            pulse(startTime);

            var bgBitmap = GetMapsetBitmap("sb/gray.jpg");
            var scale = (854.0f / bgBitmap.Width);

            var bg = GetLayer("Background").CreateSprite("sb/gray.jpg", OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bg.Scale(startTime, scale);
            bg.Fade(startTime, 1); bg.Fade(endTime, 0);

            bg.Move(startTime, endTime, 320, 200 + bgOffset, 320, 315 + bgOffset);

            var maskBitmap = GetMapsetBitmap("sb/masks/flashlight.png");
            var mask = GetLayer("FlashLight").CreateSprite("sb/masks/flashlight.png", OsbOrigin.Centre, new Vector2(320, 367));
            mask.Scale(37941, endTime, (854.0f / maskBitmap.Width)*8, (854.0f / maskBitmap.Width)*4);
            mask.Fade(37941, endTime, 0, 1);
        }

        public void kiai(int startTime, int endTime)
        {   
            var bgBitmap = GetMapsetBitmap(bgPath);
            var scale = (854.0f / bgBitmap.Width);

            var bg = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bg.Scale(startTime, scale);
            bg.Fade(startTime, 1); bg.Fade(endTime, 0);
            bg.Additive(startTime, endTime);

            var maskBitmap = GetMapsetBitmap("sb/additive.png");
            var mask = GetLayer("Additive").CreateSprite("sb/additive.png", OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            mask.Scale(startTime, scale); mask.Rotate(startTime, MathHelper.DegreesToRadians(0));
            mask.Fade(startTime, 1); mask.Fade(endTime, 0);

            //start
            revolve(startTime, 165270, bg, 0, 2, 320, 240 + bgOffset, 0, 5);
            revolve(startTime, 165270, mask, 0, 2, 320, 240 + bgOffset, 0, 5);
            pulse(startTime);
            rain(startTime, endTime, Color4.Red);

            //d dd d 
            tuTUTUtu(165270, bg, scale, mask);
            revolve(165936, 170603, bg, 0, 2, 320, 240 + bgOffset, 0, 5);
            revolve(165936, 170603, mask, 0, 2, 320, 240 + bgOffset, 0, 5);

            //glitch
            bg.Fade(170603, 0);
                var glitch = GetLayer("BackgroundAdditive").CreateAnimation("sb/glitch/g.jpg", 8, 75, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
                glitch.Fade(170603, 1); glitch.Fade(171270, 0);             
                glitch.Scale(170603, scale);
                glitch.Additive(170603, 171270);
                pulse(171270);
            bg.Fade(171270, 1);
            revolve(171270, 175936, bg, 0, 2, 320, 240 + bgOffset, 0, 5);
            revolve(171270, 175936, mask, 0, 2, 320, 240 + bgOffset, 0, 5);

            //d dd d
            tuTUTUtu(175936, bg, scale, mask);
            revolve(176603, 181270, bg, 0, 2, 320, 240 + bgOffset, 0, 5);
            revolve(176603, 181270, mask, 0, 2, 320, 240 + bgOffset, 0, 5);

            //glitch
            bg.Fade(181270, 0);
                glitch.Fade(181270, 1); glitch.Fade(181936, 0);
                glitch.Scale(181270, scale);
                glitch.Additive(181270, 181936);
                pulse(181936);
        }
        
        public void tuTUTUtu (int startTime, OsbSprite bg, float scale, OsbSprite mask)
        {   
            var step = beat/3;
            bg.Fade(startTime, 0); 
                distortion(startTime, 2*step, 10, mask);     
                distortion(startTime + 2*step, step, 10, mask);      
                distortion(startTime + beat, 2*step, 10, mask);     
                distortion(startTime + beat + 2*step, step, 10, mask);       
                bg.Scale(startTime + beat*2, startTime + beat*2 + beat/4, scale*1.1, scale);
                mask.Scale(startTime + beat*2, startTime + beat*2 + beat/4, scale*1.1, scale);
                pulse(startTime + beat*2);
            bg.Fade(startTime + beat*2, 1);
        }

        public void distortion(int startTime, int length, int radius)
        {   
            var endTime = startTime + length;

            var bgBitmap = GetMapsetBitmap(bgPath);
            float scale = (854.0f / bgBitmap.Width);

            double angle = Random(0, Math.PI * 2);
            Vector2 endPos = new Vector2(
                (float)(320 + Math.Cos(angle) * radius),
                (float)(240 + bgOffset + Math.Sin(angle) * radius));

            var randBG = Random(0,3);            

		    var bgR = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgR.Scale(startTime, scale);
            bgR.Fade(startTime, 1); bgR.Fade(endTime, 0);
            bgR.Color(startTime, 1, 0, 0); bgR.Additive(startTime, endTime);

            var bgG = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgG.Scale(startTime, scale);
            bgG.Fade(startTime, 1); bgG.Fade(endTime, 0);
            bgG.Color(startTime, 0, 1, 0); bgG.Additive(startTime, endTime);

            var bgB = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgB.Scale(startTime, scale);
            bgB.Fade(startTime, 1); bgB.Fade(endTime, 0);
            bgB.Color(startTime, 0, 0, 1); bgB.Additive(startTime, endTime);

            OsbSprite[] bg = {bgR, bgG, bgB};
            bg[randBG].Move(startTime, endPos);

            bump(startTime, length, scale, bgR, bgG, bgB);
        }   

        public void distortion(int startTime, int length, int radius, OsbSprite mask)
        {   
            var endTime = startTime + length;

            var bgBitmap = GetMapsetBitmap(bgPath);
            float scale = (854.0f / bgBitmap.Width);

            double angle = Random(0, Math.PI * 2);
            Vector2 endPos = new Vector2(
                (float)(320 + Math.Cos(angle) * radius),
                (float)(240 + bgOffset + Math.Sin(angle) * radius));

            var randBG = Random(0,3);            

		    var bgR = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgR.Scale(startTime, scale);
            bgR.Fade(startTime, 1); bgR.Fade(endTime, 0);
            bgR.Color(startTime, 1, 0, 0); bgR.Additive(startTime, endTime);

            var bgG = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgG.Scale(startTime, scale);
            bgG.Fade(startTime, 1); bgG.Fade(endTime, 0);
            bgG.Color(startTime, 0, 1, 0); bgG.Additive(startTime, endTime);

            var bgB = GetLayer("BackgroundAdditive").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 240 + bgOffset));
            bgB.Scale(startTime, scale);
            bgB.Fade(startTime, 1); bgB.Fade(endTime, 0);
            bgB.Color(startTime, 0, 0, 1); bgB.Additive(startTime, endTime);

            OsbSprite[] bg = {bgR, bgG, bgB};
            bg[randBG].Move(startTime, endPos);

            bump(startTime, length, scale, mask, bgR, bgG, bgB);
        }

        public void bump(int startTime, int length, float scale, params OsbSprite[] sprites)
        {   
            int endTime = startTime + length;
            int[] angles = {-3, 3};
            var randAngle = Random(0, 2);

            foreach (OsbSprite sprite in sprites)
            {       
                sprite.Rotate(startTime, endTime, MathHelper.DegreesToRadians(angles[randAngle]), MathHelper.DegreesToRadians(0));
                sprite.Scale(startTime, endTime, scale*1.05, scale);
            }
        }

        public void bump(int startTime, int length, float scale, OsbSprite mask, params OsbSprite[] sprites)
        {   
            int endTime = startTime + length;
            int[] angles = {-3, 3};
            var randAngle = Random(0, 2);

            foreach (OsbSprite sprite in sprites)
            {       
                sprite.Rotate(startTime, endTime, MathHelper.DegreesToRadians(angles[randAngle]), MathHelper.DegreesToRadians(0));
                sprite.Scale(startTime, endTime, scale*1.05, scale);
            }

            mask.Rotate(startTime, endTime, MathHelper.DegreesToRadians(angles[randAngle]), MathHelper.DegreesToRadians(0));
            mask.Scale(startTime, endTime, scale*1.05, scale);         
        }

        public void pulse(int startTime)
        {   
            var pulse = GetLayer("Pulse").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
            pulse.ScaleVec(startTime, 854, 480 - 254);
            pulse.Fade(startTime, startTime + beat, 0.2, 0);
        }

        public void rain(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Rain").CreateSprite("sb/particles/rain.png");

                var rainStartTime = Random(startTime, startTime + beat);

                var randX = Random(-107, 747) + 40; var randY = Random(140, 240); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 600 / randZ;

                double angle = -(Math.PI * 1.5) * 0.95;
                var radius = 500 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.ScaleVec(rainStartTime, randZ*2, randZ>0.75 ? 10 : 5);
                rain.Color(rainStartTime, color);
                rain.Rotate(rainStartTime, -MathHelper.DegreesToRadians(angle));
                rain.Fade(rainStartTime, 0.5); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                rain.EndGroup();
            }
            
        }

        public void revolve(int StartTime, int EndTime, OsbSprite sprite, double startAngle, double endAngle, double centerX, double centerY, double radiusX, double radiusY)
        {   
            // Change from angles in a clock to angles in a unit circle;
            startAngle = 0.5 - startAngle;
            endAngle   = 0.5 - endAngle;

            // Start and end angles to be used in moving animation; In terms of pi/2
            long RevStart = (long) Math.Floor(startAngle * 2);
            long RevEnd   = (long) Math.Floor(endAngle * 2);

            // Revolutions per millisecond
            double rpms = (endAngle - startAngle) / (EndTime - StartTime);

            // Start and end times of the moving animation
            int RevStartTime;
            int RevEndTime;

            if ((startAngle * 2) % 1 == 0) // If start angle is on an axis
                RevStartTime = StartTime;
            else
            {
                if (startAngle > endAngle)
                    RevStart++;
                    
                RevStartTime = (int) (Math.Round(StartTime - (startAngle*2 - RevStart) / 2 / rpms));
            }

            if ((endAngle * 2) % 1 == 0) // If end angle is on an axis
                RevEndTime = EndTime;
            else
            {
                if (endAngle > startAngle)
                    RevEnd++;

                RevEndTime = (int) (Math.Round(EndTime - (endAngle*2 - RevEnd) / 2 / rpms));
            }

            // Constants
            double[] XValues = new double[] 
            {
                centerX + radiusX, // 0
                centerX,          // 1/2 pi
                centerX - radiusX, // pi
                centerX           // 3/2 pi
            };

            double[] YValues = new double[] 
            {
                centerY,          // 0
                centerY - radiusY, // 1/2 pi
                centerY,          // pi
                centerY + radiusY  // 3/2 pi
            };

            OsbEasing[] Easings = new OsbEasing[] 
            {
                OsbEasing.InSine,
                OsbEasing.OutSine
            };

            // Move animations
            long k = RevStart < RevEnd ? 1 : -1;
            
            int startTime = RevStartTime;
            int endTime;

            long j = Math.Abs(RevEnd - RevStart);
            for (long i = 0; i < j; i++) 
            {
                endTime = (int) (Math.Round((double) (RevStartTime * (j-i-1) + RevEndTime * (i+1)) / j));
                long m = mod(RevStart + i*k, 4);
                long n = mod(m + k, 4);

                sprite.MoveX(Easings[m%2], startTime, endTime, XValues[m], XValues[n]);
                sprite.MoveY(Easings[n%2], startTime, endTime, YValues[m], YValues[n]);

                startTime = endTime;
            }
        }

        public long mod(long a, long b) 
        {
            return (a % b + b) % b;
        }

        public void shake(int startTime, int endTime, params OsbSprite[] sprites)
        {             
            int interval = 50;
            int verticalStrength = 3;
            int horizontalStength = 3;
            int iterations = 10;
            int speed = 100;

            for (int s=0; s<sprites.Length; s++) 
            {
                var sprite = sprites[s];

                var initialPos = sprite.PositionAt(startTime);

                sprite.StartLoopGroup(startTime, (endTime - startTime) / speed);    
                for (int i=0; i < iterations; i++)
                {
                    int randomX = Random(-horizontalStength, horizontalStength);
                    int randomY = Random(-verticalStrength, verticalStrength);

                    sprite.MoveX(interval * i, initialPos.X + randomX);
                    sprite.MoveY(interval * i, initialPos.Y + randomY);
                }
                sprite.EndGroup();
            }
        }
    }
}
