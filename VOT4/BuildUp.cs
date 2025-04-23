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
    public class BuildUp : StoryboardObjectGenerator
    {
        int midScreen = 254+(480-254)/2;

        Color4 Blue = new Color4(18, 51, 112, 1);

        Color4 Black = new Color4(12, 12, 12, 1);

        Color4 Gray = new Color4(48, 48, 48, 1);

        public override void Generate()
        {
            int beat = 23709 - 23384;
            for(int startTime=23384; startTime<42844; startTime+=beat*2)
            {
                ripple(startTime);
            }

            var dot = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                dot.ScaleVec(23384, 0.015, 0.015);
                dot.Fade(23384, 1); dot.Fade(44141, 0);
                dot.Color(23384, new Color4(200, 200, 200, 1));

            double scaleX = 0.09; double scaleY = 0.004;
            var bar1 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar1.ScaleVec(23384, scaleX, scaleY);
                bar1.Rotate(OsbEasing.InSine, 23384, 42844, 0, MathHelper.DegreesToRadians(360));
                bar1.Fade(23384, 1); bar1.Fade(44141, 0);


            var bar2 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar2.ScaleVec(23384, scaleX, scaleY);
                bar2.Rotate(OsbEasing.InSine, 23384, 42844, MathHelper.DegreesToRadians(45), MathHelper.DegreesToRadians(360));
                bar2.Fade(23384, 1); bar2.Fade(44141, 0);
            
            var bar3 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar3.ScaleVec(23384, scaleX, scaleY);
                bar3.Rotate(OsbEasing.InSine, 23384, 42844, MathHelper.DegreesToRadians(90), MathHelper.DegreesToRadians(360));
                bar3.Fade(23384, 1); bar3.Fade(44141, 0);

            var bar4 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar4.ScaleVec(23384, scaleX, scaleY);
                bar4.Rotate(OsbEasing.InSine, 23384, 42844, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(360));
                bar4.Fade(23384, 1); bar4.Fade(44141, 0);

            var bubble = GetLayer("BottomObjects").CreateSprite("sb/masks/BubbleGlow.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bubble.ScaleVec(23384, 1.2, 1.2);
                bubble.Rotate(OsbEasing.InSine, 23384, 42844, 0, MathHelper.DegreesToRadians(360));
                bubble.Fade(23384, 0.4); bubble.Fade(44141, 0);
            
            OsbSprite[] group1 = {dot, bubble};
            OsbSprite[] group2 = {bar1, bar2, bar3, bar4};

            shake(group2, 23384, 44141);

            int[] timings = {23384, 28573, 33763, 36357, 38952, 40249, 41546, 42195, 42844, 44141};

            foreach(OsbSprite sprite in group1)
            {   
                float scleX = sprite.ScaleAt(23384).X;
                float scleY = sprite.ScaleAt(23384).Y;
                sprite.ScaleVec(OsbEasing.InSine, 23384, 42844, scleX*0.1, scleY*0.1, 
                                                                scleX*3, scleY*3);
            }

            foreach(OsbSprite sprite in group2)
            {   
                float scleX = sprite.ScaleAt(23384).X;
                float scleY = sprite.ScaleAt(23384).Y;
                sprite.ScaleVec(OsbEasing.InSine, 23384, 42844, scleX*3*4, scleY*0, 
                                                                scleX*3*4, scleY*2);
                sprite.Color(23384, new Color4(200, 200, 200, 1));
            }

            timings = new int[] {42844, 43006, 43087, 43168, 43330, 43492, 43655, 43817};

            foreach(OsbSprite sprite in group1)
            {      
                float scleX = sprite.ScaleAt(42844).X;
                float scleY = sprite.ScaleAt(42844).Y;

                for(int i=0; i<timings.Length; i++)
                {
                    sprite.ScaleVec(OsbEasing.InSine, timings[i], timings[i] + 75, scleX*1.1, scleY*1.1, 
                                                                                scleX, scleY);
                }
            }

            chorus1(85655, 107353);

            wubwub(110450, 135224);

            crazypiano(262665, 281524);

            bit(325160, 334725, 345239);

            piano(185865, 224266);
        }

        public void shake(OsbSprite[] sprites, int startTime, int endTime)
        {            
            int interval = 50;
            float verticalStrength = 0.5f;
            float horizontalStength = 0.5f;
            int iterations = 10;
            int speed = 50;

            foreach(OsbSprite sprite in sprites)
            {
                var initialPos = sprite.PositionAt(startTime);

                sprite.StartLoopGroup(startTime, (endTime - startTime) / 500 );    
                for (int i = 0; i < iterations; i++)
                {
                    float randomX = Random(-horizontalStength, horizontalStength);
                    float randomY = Random(-verticalStrength, verticalStrength);

                    sprite.MoveX(interval * i, initialPos.X + randomX);
                    sprite.MoveY(interval * i, initialPos.Y + randomY);
                }
                sprite.EndGroup();
            }
        }

        public void ripple(int startTime)
        {   
            int time = startTime;
            int randX = Random(-107, 747); int randY = Random(140, 480);

            var ripple = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(randX, randY));
                ripple.Fade(time, time+800, 0.6, 0.6);
                ripple.Scale(OsbEasing.OutSine, time, time + 800, 0.08, 0.30);

            var rippleIn = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(randX, randY));
                rippleIn.Fade(time, time+800, 1, 1);
                rippleIn.Scale(OsbEasing.OutSine, time, time+800, 0.07, 0.30);
                rippleIn.Color(time, Color4.Black);
        }

        public void chorus1(int startTime, int endTime)
        {       
            int beat = 85979 - 85655;
            for(int time=85655; time<97330; time+=beat*2)
            {
                ripple(time);
            }

            int[] times = {97996, 98663, 99348, 100033, 100739, 101444, 102172, 102899, 103626, 104354, 105103};

            foreach(int tim in times)
            {
                ripple(tim);
            }

            var bubble = GetLayer("BottomObjects").CreateSprite("sb/masks/BubbleGlow.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bubble.ScaleVec(startTime, 1.2, 1.2);
                bubble.Rotate(OsbEasing.InSine, startTime, 107353, 0, MathHelper.DegreesToRadians(-360));
                bubble.Fade(startTime, 0.4); bubble.Fade(endTime, 0);

            var dot = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                dot.ScaleVec(startTime, 0.015, 0.015);
                dot.Fade(startTime, 1); dot.Fade(endTime, 0);
                dot.Color(startTime, new Color4(200, 200, 200, 1));

            float scleX = bubble.ScaleAt(85655).X;
            float scleY = bubble.ScaleAt(85655).Y;
            bubble.ScaleVec(OsbEasing.InSine, 85655, 107353, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);

            scleX = dot.ScaleAt(85655).X;
            scleY = dot.ScaleAt(85655).Y;
            dot.ScaleVec(OsbEasing.InSine, 85655, 107353, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);

            OsbSprite[] group1 = {dot, bubble};
            int[] timings = {105853, 106041, 106135, 106228, 106416, 106603, 106791, 106978};

            double scaleX = 1.2; double scaleY = 0.004;

            var bar1 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png");
                bar1.ScaleVec(OsbEasing.InSine, startTime, 107353, scaleX, 0,  scaleX, scaleY*1.5);
                bar1.Rotate(OsbEasing.InSine, startTime, 107353, MathHelper.DegreesToRadians(360), MathHelper.DegreesToRadians(360 - 360));
                bar1.Fade(startTime, 1); bar1.Fade(endTime, 0);
                bar1.Color(startTime, new Color4(200, 200, 200, 1));

            var bar2 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png");
                bar2.ScaleVec(OsbEasing.InSine, startTime, 107353, scaleX, 0, scaleX, scaleY*1.5);
                bar2.Rotate(OsbEasing.InSine, startTime, 107353, MathHelper.DegreesToRadians(-60), MathHelper.DegreesToRadians(-60 - 360));
                bar2.Fade(startTime, 1); bar2.Fade(endTime, 0);
                bar2.Color(startTime, new Color4(200, 200, 200, 1));

            var bar3 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png");
                bar3.ScaleVec(OsbEasing.InSine, startTime, 107353, scaleX, 0,  scaleX, scaleY*1.5);
                bar3.Rotate(OsbEasing.InSine, startTime, 107353, MathHelper.DegreesToRadians(60), MathHelper.DegreesToRadians(60 - 360));
                bar3.Fade(startTime, 1); bar3.Fade(endTime, 0);
                bar3.Color(startTime, new Color4(200, 200, 200, 1));

            OsbSprite[] bars = {bar1, bar2, bar3};

            swapTriangle(bars, 88249, 88573, true);
            swapTriangle(bars, 90844, 91168, false);
            swapTriangle(bars, 93438, 93763, true);
            swapTriangle(bars, 96033, 96357, false);
            swapTriangle(bars, 97330, 97663, true);
            swapTriangle(bars, 98663, 99005, false);
            swapTriangle(bars, 100033, 100386, true);
            swapTriangle(bars, 101445, 101808, false);
            swapTriangle(bars, 102172, 102535, true);
            swapTriangle(bars, 102899, 103263, false);

            swapTriangle(bars, 103626, 103990, true);
            swapTriangle(bars, 104354, 104728, false);
            swapTriangle(bars, 104728, 105103, true);
            swapTriangle(bars, 105103, 105478, false);
            swapTriangle(bars, 105478, 105853, true);
            swapTriangle(bars, 105853, 106228, false);
        }

        public void swapTriangle(OsbSprite[] tris, int startTime, int endTime, bool state)
        {   
            int radius = 20;
            Vector2 center = new Vector2(320, midScreen);

            Vector2 tri1Start; Vector2 tri2Start; Vector2 tri3Start;
            Vector2 tri1End; Vector2 tri2End; Vector2 tri3End;
            if(state)
            {   
                tri1Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90)) * -radius)
                );
                tri1End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 180)) * -radius)
                );

                tri2Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 120)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 120)) * -radius)
                );
                tri2End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 120 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 120 + 180)) * -radius)
                );

                tri3Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 240)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 240)) * -radius)
                );
                tri3End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 240 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 240 + 180)) * -radius)
                );
            }

            else
            {
                tri1Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 180)) * -radius)
                );
                tri1End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90)) * -radius)
                );

                tri2Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 120 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 120 + 180)) * -radius)
                );
                tri2End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 120)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 120)) * -radius)
                );

                tri3Start = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 240 + 180)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 240 + 180)) * -radius)
                );
                tri3End = new Vector2(
                    (float)(center.X + Math.Cos(MathHelper.DegreesToRadians(90 + 240)) * -radius),
                    (float)(center.Y + Math.Sin(MathHelper.DegreesToRadians(90 + 240)) * -radius)
                );
            }

            tris[0].Move(OsbEasing.OutSine, startTime, endTime, tri1Start, tri1End);
            tris[1].Move(OsbEasing.OutSine, startTime, endTime, tri2Start, tri2End);
            tris[2].Move(OsbEasing.OutSine, startTime, endTime, tri3Start, tri3End);
        }

        public void groupScale(OsbSprite[] sprites, int startTime, int endTime, float ratio, Vector2 center)
        {
            for(int i=0; i<sprites.Length; i++)
            {   
                OsbSprite sprite = sprites[i];

                Vector2 currentScale = sprite.ScaleAt(startTime);
                Vector2 currentPosition = sprite.PositionAt(startTime);
                
                var newScale = currentScale*ratio;
                var newPosition = center + (currentPosition-center)*ratio;
                
                sprite.Move(OsbEasing.InSine, startTime, endTime, currentPosition, newPosition);
                sprite.ScaleVec(OsbEasing.InSine, startTime, endTime, currentScale, newScale);
            }
        }

        public void wubwub(int startTime, int endTime)
        {
            Vector2 origin = new Vector2(320, midScreen);

            for(int j=0; j<3; j++)
            {
                for(int i=0; i<2; i++)
                {   
                    var hexScale = 0.88 - 0.2*j;
                    var hex = GetLayer("Hex").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, origin);
                        hex.ScaleVec(startTime, hexScale, hexScale);
                        hex.Fade(startTime, 0.4); hex.Fade(endTime, 0);
                        hex.Additive(startTime);

                        hex.StartLoopGroup(startTime, 3);
                            if(i%2 == 0)
                            {
                                hex.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(360));
                            }
                            else
                            {
                                hex.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(-360));
                            }
                        hex.EndGroup();

                    var hexInScale = 0.78 - 0.2*j;
                    var hexIn = GetLayer("Hex").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, origin);
                        hexIn.ScaleVec(startTime, hexInScale, hexInScale);
                        hexIn.Fade(startTime, 1); hexIn.Fade(endTime, 0);
                        hexIn.Color(startTime, Color4.Black);

                        hexIn.StartLoopGroup(startTime, 3);
                            if(i%2 == 0)
                            {
                                hexIn.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(-360));
                            }
                            else
                            {
                                hexIn.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(360));
                            }
                        hexIn.EndGroup();

                        int offset = 25;
                        hexIn.StartLoopGroup(startTime, 32);
                            hexIn.ScaleVec(0 + offset*Math.Abs(j-2), (135224 - 110450)/32 + offset*Math.Abs(j-2), hexInScale*1.05, hexInScale*1.05, hexInScale, hexInScale);
                        hexIn.EndGroup();

                        revolve(startTime, endTime, hex, 0, 50, origin.X, origin.Y, 3, 3);
                        revolve(startTime, endTime, hexIn, 0, 50, origin.X, origin.Y, 3, 3);
                }
            }

            for(int i=0; i<6; i++)
            {   
                int radius = 20;
                float angle = MathHelper.DegreesToRadians(60*i);
                Vector2 orign = new Vector2 (
                                            (float)(origin.X + Math.Cos(angle) * -radius),
                                            (float)(origin.Y + Math.Sin(angle) * -radius)
                                            );

                var ex = GetLayer("BottomObjects").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, orign);
                    ex.ScaleVec(startTime, 0.25, 0.25);
                    ex.Fade(startTime, 0.4); ex.Fade(endTime, 0);
                    if(i==0 || i==3)
                    {
                        ex.Color(startTime, new Color4(255, 0, 0, 1));
                    }
                    else if(i==1 || i==4)
                    {
                        ex.Color(startTime, new Color4(0, 255, 0, 1));
                    }
                    else
                    {
                        ex.Color(startTime, new Color4(0, 0, 255, 1));
                    }   
                    
                    ex.Additive(startTime);

                    ex.StartLoopGroup(startTime, 3);
                        if(i%2 == 0)
                        {
                            ex.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(-360));
                        }
                        else
                        {
                            ex.Rotate(0, 10000, 0, MathHelper.DegreesToRadians(360));
                        }
                        
                    ex.EndGroup();

                float sAngle = (i*60/360f)*2; float eAngle = 2 + sAngle; 
                revolve(startTime, endTime, ex,     sAngle, eAngle, origin.X, origin.Y, radius, radius);
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

                sprite.Fade(RevStartTime, 0);
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

        public void crazypiano(int startTime, int endTime)
        {
            
            int beat = 262966 - 262665;
            for(int time=262665; time<274665; time+=beat*2)
            {
                ripple(time);
            }

            int[] times = {274665, 275251, 275836, 276422, 277007, 277578, 278149, 278721, 279292, 279850, 280408};

            foreach(int tim in times)
            {
                ripple(tim);
            }

            var bubble = GetLayer("BottomObjects").CreateSprite("sb/masks/BubbleGlow.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bubble.ScaleVec(startTime, 1.2, 1.2);
                bubble.Rotate(OsbEasing.InSine, startTime, 281524, 0, MathHelper.DegreesToRadians(360));
                bubble.Fade(startTime, 0.4); bubble.Fade(endTime, 0);

            var dot = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                dot.ScaleVec(startTime, 0.015, 0.015);
                dot.Fade(startTime, 1); dot.Fade(endTime, 0);
                dot.Rotate(startTime, 281524, 0, MathHelper.DegreesToRadians(360));
                dot.Color(startTime, new Color4(200, 200, 200, 1));

            float scleX = bubble.ScaleAt(262665).X;
            float scleY = bubble.ScaleAt(262665).Y;
            bubble.ScaleVec(OsbEasing.InSine, 262665, 281524, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);

            scleX = dot.ScaleAt(262665).X;
            scleY = dot.ScaleAt(262665).Y;
            dot.ScaleVec(OsbEasing.InSine, 262665, 281524, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);  

            int timeDuration = 2000;
            float sX = 3; float sY = 9;
            for(int i=0; i<4; i++)
            {
                for(int time=262665; time<281524; time+=(262740 - 262665))
                {   
                    float pourcent = (time-262665)/(281524-262665f);
                    var rain = GetLayer("BottomObjects").CreateSprite("sb/particles/rain.png");
                        rain.ScaleVec(time, sX*pourcent, 1 + sY*pourcent);
                        rain.Fade(time, 1); 
                        if(time+timeDuration > endTime)
                        {
                            rain.Fade(endTime, 0);
                        }
                        else
                        {
                            rain.Fade(time+timeDuration, 0);
                        }
                        rain.Color(time, new Color4(200, 200, 200, 1));
                        float angle = dot.RotationAt(time) + MathHelper.DegreesToRadians(90)*i;
                        rain.Rotate(time, angle + MathHelper.DegreesToRadians(90));
                        rain.Move(OsbEasing.InSine, time, time+timeDuration, new Vector2(320, midScreen), new Vector2 (
                                                                                            (float)(320 + Math.Cos(angle) * -650),
                                                                                            (float)(midScreen + Math.Sin(angle) * -650)
                                                                                            ));
                }
            }

            for(int i=0; i<4; i++)
            {
                for(int time=262665; time<281524; time+=(262740 - 262665))
                {   
                    float pourcent = (time-262665)/(281524-262665f);
                    var rain = GetLayer("BottomObjects").CreateSprite("sb/particles/rain.png");
                        rain.ScaleVec(time, sX*pourcent, 1 + sY*pourcent);
                        rain.Fade(time, 1); 
                        if(time+timeDuration > endTime)
                        {
                            rain.Fade(endTime, 0);
                        }
                        else
                        {
                            rain.Fade(time+timeDuration, 0);
                        }
                        rain.Color(time, new Color4(200, 200, 200, 1));
                        float angle = -dot.RotationAt(time) + MathHelper.DegreesToRadians(90)*i;
                        rain.Rotate(time, angle + MathHelper.DegreesToRadians(90));
                        rain.Move(OsbEasing.InSine, time, time+timeDuration, new Vector2(320, midScreen), new Vector2 (
                                                                                            (float)(320 + Math.Cos(angle) * -650),
                                                                                            (float)(midScreen + Math.Sin(angle) * -650)
                                                                                            ));
                }
            }
        }

        public void bit(int preshow, int startTime, int endTime)
        {   
            int[] timings = {   325160, 
                                325511, 325863, 326097, 326331,
                                326683, 327035, 327269, 327503,
                                327855, 328206, 328441, 328675,
                                329027, 329378, 329613, 329847,
                                330212, 330578, 330822, 331066,
                                331432, 331798, 332042, 332286,
                                332651, 333017, 333261, 333505,
                                333871, 334237, 334481
                            };

            for(int j=0; j<3; j++)
            {
                int offsetX = j%2==0 ? 61 : 0;
                for(int i=0; i<(j%2==0 ? 7 : 8); i++)
                {   
                    int xpos = offsetX -107 + i*122;
                    int ypos = 254 + j*122;
                    OsbSprite st;

                    if(false)
                    {
                        st = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(xpos, ypos));
                    }
                    else
                    {
                        st = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(xpos, ypos));
                    }
                        st.Scale(preshow, 0.1);
                        st.Fade(preshow, 0.6); st.Fade(startTime, 0);
                        st.Rotate(preshow, MathHelper.DegreesToRadians(45));
                        st.Color(preshow, new Color4(200, 200, 200, 1));
                        st.MoveY(preshow, startTime, ypos, ypos - 50);

                    foreach(int t in timings)
                    {
                        st.Scale(t, t+200, 0.1*1.1, 0.1);
                    }
                }
            }

            int beat = 334979 - 334725;
            for(int time=334725; time<344407; time+=beat*2)
            {
                ripple(time);
            }

            var bubble = GetLayer("BottomObjects").CreateSprite("sb/masks/BubbleGlow.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bubble.ScaleVec(startTime, 1.2, 1.2);
                bubble.Rotate(OsbEasing.InSine, startTime, endTime, 0, MathHelper.DegreesToRadians(-360));
                bubble.Fade(startTime, 0.4); bubble.Fade(endTime, 0);

            var dot = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                dot.ScaleVec(startTime, 0.015, 0.015);
                dot.Fade(startTime, 1); dot.Fade(endTime, 0);
                dot.Rotate(startTime, endTime, 0, MathHelper.DegreesToRadians(-360));
                dot.Color(startTime, new Color4(200, 200, 200, 1));

            float scleX = bubble.ScaleAt(334725).X;
            float scleY = bubble.ScaleAt(334725).Y;
            bubble.ScaleVec(OsbEasing.InSine, 334725, endTime, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);

            scleX = dot.ScaleAt(334725).X;
            scleY = dot.ScaleAt(334725).Y;
            dot.ScaleVec(OsbEasing.InSine, 334725, endTime, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);  


            double scaleX = 1.2; double scaleY = 0.004;

            var bar1 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar1.ScaleVec(OsbEasing.InSine, startTime, endTime, scaleX, 0,  scaleX, scaleY*1.5);
                bar1.Rotate(OsbEasing.InSine, startTime, endTime, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-360));
                bar1.Fade(startTime, 1); bar1.Fade(endTime, 0);
                bar1.Color(startTime, new Color4(200, 200, 200, 1));

            var bar2 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar2.ScaleVec(OsbEasing.InSine, startTime, endTime, scaleX, 0, scaleX, scaleY*1.5);
                bar2.Rotate(OsbEasing.InSine, startTime, endTime, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(-360));
                bar2.Fade(startTime, 1); bar2.Fade(endTime, 0);
                bar2.Color(startTime, new Color4(200, 200, 200, 1));

            var bar3 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar3.ScaleVec(OsbEasing.InSine, startTime, endTime, scaleX, 0,  scaleX, scaleY*1.5);
                bar3.Rotate(OsbEasing.InSine, startTime, endTime, MathHelper.DegreesToRadians(45), MathHelper.DegreesToRadians(-360));
                bar3.Fade(startTime, 1); bar3.Fade(endTime, 0);
                bar3.Color(startTime, new Color4(200, 200, 200, 1));

            var bar4 = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bar4.ScaleVec(OsbEasing.InSine, startTime, endTime, scaleX, 0,  scaleX, scaleY*1.5);
                bar4.Rotate(OsbEasing.InSine, startTime, endTime, MathHelper.DegreesToRadians(90), MathHelper.DegreesToRadians(-360));
                bar4.Fade(startTime, 1); bar4.Fade(endTime, 0);
                bar4.Color(startTime, new Color4(200, 200, 200, 1));

            OsbSprite[] bars = {bar1, bar2, bar3, bar4};

            shake(bars, startTime, endTime);
        }

        public void particlesPopUp(int startTime, int endTime, int quantity)
        {
            for (int i=0; i<quantity; i++)
            {   
                var randomX = Random(320 + 10 -(854/2), 320 - 10 +(854/2)); var randomY = Random(254 + 5, 480 - 5);
                var particle = GetLayer("BottomObjects").CreateSprite("sb/particles/light.png", OsbOrigin.Centre, new Vector2(randomX, randomY));

                var duration = 2000;
                var start = Random(startTime, endTime-duration);
                var scale = 0.02f;
                if(i%10 == 0)
                    scale = 0.015f;
                else if(i%3 == 0)
                    scale = 0.035f;

                particle.Fade(start, start + duration/2, 0, 0.5);
                particle.Fade(start + duration/2, start + duration, 0.9, 0);
                particle.Scale(start, scale);
                particle.Move(start, start+duration, randomX, randomY, randomX + Random(-3, 3), randomY + Random(-3, 3));
            }
        }

        public void particlesDraw(int startTime, int endTime)
        {   
            int quantity = 100;

            for(int i=0; i<quantity; i++)
            {   
                int randAngle = Random(0, 360);
                int radius = Random(90,150);
                int randTime = Random(startTime, endTime-2000);
                float randFade = Random(0.05f, 0.2f);

                Vector2 spawn = new Vector2 (
                                                (float)(320 + Math.Cos(MathHelper.DegreesToRadians(randAngle)) * -Random(200,400)),
                                                (float)(midScreen + Math.Sin(MathHelper.DegreesToRadians(randAngle)) * -Random(90,150))
                                            );
                var centerParticle = GetLayer("BottomObjects").CreateSprite("sb/particles/c.png");
                    centerParticle.Fade(randTime, randTime + 500, 0, randFade); centerParticle.Fade(randTime+1500, randTime+2000, randFade, 0);
                    centerParticle.Scale(randTime, Random(0.3f, 0.7f));
                    centerParticle.Move(OsbEasing.InSine, randTime, randTime+1500, spawn, new Vector2(320, midScreen));
            }
        }

        public void piano(int startTime, int endTime)
        {
            int[] violins = {   185865, 188266, 190666, 193065, 194266, 194865, 
                                195166, 195466, 197865, 200266, 202666, 203865, 204466, 204766, 205065,
                                207466, 209865, 212266, 213466, 214065, 214365, 214666,
                                217065, 219466, 221865};

            foreach(int start in violins)
            {
                int time = start - 100;
                var ripple = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, 197));
                    ripple.Fade(time, time+800, 0.6, 0.6);
                    ripple.Scale(OsbEasing.OutSine, time, time + 800, 0.08, 0.30);

                var rippleIn = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, 197));
                    rippleIn.Fade(time, time+800, 1, 1);
                    rippleIn.Scale(OsbEasing.OutSine, time, time+800, 0.07, 0.30);
                    rippleIn.Color(time, Color4.Black);
            }

            particlesPopUp(startTime, endTime, 600);

            particlesDraw(205065, endTime);

            var bubble = GetLayer("BottomObjects").CreateSprite("sb/masks/BubbleGlow.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                bubble.ScaleVec(205065, 1.2, 1.2);
                bubble.Rotate(OsbEasing.InSine, 205065, endTime, 0, MathHelper.DegreesToRadians(-360));
                bubble.Fade(205065, 0.4); bubble.Fade(endTime, 0);

            var dot = GetLayer("BottomObjects").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                dot.ScaleVec(205065, 0.015, 0.015);
                dot.Fade(205065, 1); dot.Fade(endTime, 0);
                dot.Rotate(205065, endTime, 0, MathHelper.DegreesToRadians(-360));
                dot.Color(205065, new Color4(200, 200, 200, 1));

            float scleX = bubble.ScaleAt(205065).X;
            float scleY = bubble.ScaleAt(205065).Y;
            bubble.ScaleVec(OsbEasing.InSine, 205065, endTime, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);

            scleX = dot.ScaleAt(205065).X;
            scleY = dot.ScaleAt(205065).Y;
            dot.ScaleVec(OsbEasing.InSine, 205065, endTime, scleX*0.1, scleY*0.1, 
                                                            scleX*3, scleY*3);  
        }
    }
}
