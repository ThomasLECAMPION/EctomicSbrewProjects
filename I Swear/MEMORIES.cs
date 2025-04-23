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
using System.Threading;

namespace StorybrewScripts
{
    public class MEMORIES : StoryboardObjectGenerator
    {   
        Color4 WHITE = new Color4(246, 241, 238, 1);

        public override void Generate()
        {   
            var misere = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere.ScaleVec(99444, 854, 480-254);
                misere.Fade(99444, 1); misere.Fade(105148, 0);
                misere.Color(99444, new Color4(0, 0, 0, 1));

            var misere1 = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere1.ScaleVec(49424, 854, 480-254);
                misere1.Fade(49424, 1); misere1.Fade(60853, 0);
                misere1.Color(49424, new Color4(0, 0, 0, 1));

            var hl = GetLayer("Memories").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, 367));
                hl.Scale(49424, 1.5);
                hl.Fade(49424, 0.65); hl.Fade(60853, 0); 
                hl.Color(49424, new Color4(252, 130, 147, 1));            

            rain(48710, 61567, new Color4(252, 130, 147, 1));

            List<int> shuffled = GetShuffledNumbers();
            int delay = 3000;
            for(int i=0; i<4; i++)
            {
                int num = shuffled[i];

                var bgPath = "sb/characters/cards/CF_gray/"+num+".png";
                var bgBitmap = GetMapsetBitmap(bgPath);
                var bgScale = (854.0f / bgBitmap.Width)*0.25f;

                var bg = GetLayer("Memories").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                bg.Scale(49424 + i*delay, bgScale);
                bg.Fade(49424 + i*delay, 0.6); bg.Fade(49424 + i*delay + 4000, 0);
                bg.MoveY(49424 + i*delay, 49424 + i*delay + 4000, 650, 100);

                bg.MoveX(OsbEasing.InOutSine, 49424 + i*delay, 49424 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                bg.MoveX(OsbEasing.InOutSine, 49424 + i*delay + 3000, 49424 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                bg.Rotate(OsbEasing.InOutSine, 49424 + i*delay, 49424 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                bg.Rotate(OsbEasing.InOutSine, 49424 + i*delay + 3000, 49424 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                var cadre = GetLayer("Memories").CreateSprite("sb/bubble3.png", OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                cadre.Scale(49424 + i*delay, bgScale*2.3f);
                cadre.Fade(49424 + i*delay, 0.6); cadre.Fade(49424 + i*delay + 4000, 0);
                cadre.Color(49424 + i*delay, WHITE);
                cadre.MoveY(49424 + i*delay, 49424 + i*delay + 4000, 650, 100);

                cadre.MoveX(OsbEasing.InOutSine, 49424 + i*delay, 49424 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                cadre.MoveX(OsbEasing.InOutSine, 49424 + i*delay + 3000, 49424 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                cadre.Rotate(OsbEasing.InOutSine, 49424 + i*delay, 49424 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                cadre.Rotate(OsbEasing.InOutSine, 49424 + i*delay + 3000, 49424 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                if(Random(10)%3==0)
                {
                    cadre.FlipH(49424);
                }
            }

            var misere2 = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere2.ScaleVec(60853, 854, 480-254);
                misere2.Fade(60853, 1); misere2.Fade(63710, 0);
                misere2.Color(60853, new Color4(0, 0, 0, 1));

            var sq4 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq4.Scale(OsbEasing.OutSine, 62817, 62817+200, 0.50, 0.70); 
                sq4.Fade(62817, 62817+100, 0, 1); sq4.Fade(63710, 0); 
                sq4.Color(62817, new Color4(252, 130, 147, 1));   

            var sq3 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq3.Scale(OsbEasing.OutSine, 62638, 62638+200, 0.30, 0.50); 
                sq3.Fade(62638, 62638+100, 0, 1); sq3.Fade(63710, 0); 
                sq3.Color(62638, new Color4(252, 130, 147, 1));   

            var sq2 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq2.Scale(OsbEasing.OutSine, 62460, 62460+200, 0.1, 0.30); 
                sq2.Fade(62460, 62460+100, 0, 1); sq2.Fade(63710, 0); 
                sq2.Color(62460, new Color4(252, 130, 147, 1));   

            var sq1 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq1.Scale(OsbEasing.OutSine, 62281, 62281+200, 0, 0.1); 
                sq1.Fade(62281, 62281+100, 0, 1); sq1.Fade(63710, 0); 
                sq1.Color(62281, new Color4(252, 130, 147, 1));   




            //
            var misere3 = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere3.ScaleVec(128004, 854, 480-254);
                misere3.Fade(128004, 1); misere3.Fade(139432, 0);
                misere3.Color(128004, new Color4(0, 0, 0, 1));

            var hl2 = GetLayer("Memories").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, 367));
                hl2.Scale(128004, 1.5);
                hl2.Fade(128004, 0.65); hl2.Fade(139432, 0); 
                hl2.Color(128004, new Color4(252, 130, 147, 1));  

            rain(127294, 140146, new Color4(252, 130, 147, 1));
            
            for(int i=0; i<4; i++)
            {
                int num = shuffled[i+4];

                var bgPath = "sb/characters/cards/CF_gray/"+num+".png";
                var bgBitmap = GetMapsetBitmap(bgPath);
                var bgScale = (854.0f / bgBitmap.Width)*0.25f;

                var bg = GetLayer("Memories").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                bg.Scale(128004 + i*delay, bgScale);
                bg.Fade(128004 + i*delay, 0.6); bg.Fade(128004 + i*delay + 4000, 0);
                bg.MoveY(128004 + i*delay, 128004 + i*delay + 4000, 650, 100);

                bg.MoveX(OsbEasing.InOutSine, 128004 + i*delay, 128004 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                bg.MoveX(OsbEasing.InOutSine, 128004 + i*delay + 3000, 128004 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                bg.Rotate(OsbEasing.InOutSine, 128004 + i*delay, 128004 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                bg.Rotate(OsbEasing.InOutSine, 128004 + i*delay + 3000, 128004 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                var cadre = GetLayer("Memories").CreateSprite("sb/bubble3.png", OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                cadre.Scale(128004 + i*delay, bgScale*2.3f);
                cadre.Fade(128004 + i*delay, 0.6); cadre.Fade(128004 + i*delay + 4000, 0);
                cadre.Color(128004 + i*delay, WHITE);
                cadre.MoveY(128004 + i*delay, 128004 + i*delay + 4000, 650, 100);

                cadre.MoveX(OsbEasing.InOutSine, 128004 + i*delay, 128004 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                cadre.MoveX(OsbEasing.InOutSine, 128004 + i*delay + 3000, 128004 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                cadre.Rotate(OsbEasing.InOutSine, 128004 + i*delay, 128004 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                cadre.Rotate(OsbEasing.InOutSine, 128004 + i*delay + 3000, 128004 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                if(Random(10)%3==0)
                {
                    cadre.FlipH(128004);
                }
            }

            var misere4 = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere4.ScaleVec(139432, 854, 480-254);
                misere4.Fade(139432, 1); misere4.Fade(142289, 0);
                misere4.Color(139432, new Color4(0, 0, 0, 1));

            var sq8 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq8.Scale(OsbEasing.OutSine, 141396, 141396+200, 0.50, 0.70); 
                sq8.Fade(141396, 141396+100, 0, 1); sq8.Fade(142289, 0); 
                sq8.Color(141396, new Color4(252, 130, 147, 1));   

            var sq7 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq7.Scale(OsbEasing.OutSine, 141218, 141218+200, 0.30, 0.50); 
                sq7.Fade(141218, 141218+100, 0, 1); sq7.Fade(142289, 0); 
                sq7.Color(141218, new Color4(252, 130, 147, 1));   

            var sq6 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq6.Scale(OsbEasing.OutSine, 141039, 141039+200, 0.1, 0.30); 
                sq6.Fade(141039, 141039+100, 0, 1); sq6.Fade(142289, 0); 
                sq6.Color(141039, new Color4(252, 130, 147, 1));   

            var sq5 = GetLayer("Memories").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, 367));
                sq5.Scale(OsbEasing.OutSine, 140861, 140861+200, 0, 0.1); 
                sq5.Fade(140861, 140861+100, 0, 1); sq5.Fade(142289, 0); 
                sq5.Color(140861, new Color4(252, 130, 147, 1));   

            
            //

            var hl3 = GetLayer("Memories").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, 367));
                hl3.Scale(222285, 1.5);
                hl3.Fade(222285, 0.65); hl3.Fade(248010, 0); 
                hl3.Color(222285, new Color4(252, 130, 147, 1));  

            rain(221560, 248724, new Color4(252, 130, 147, 1));

            for(int i=0; i<9; i++)
            {
                int num = shuffled[i+8];

                var bg2Path = "sb/characters/cards/CF/"+num+".png";
                var bg2Bitmap = GetMapsetBitmap(bg2Path);
                var bg2Scale = (854.0f / bg2Bitmap.Width)*0.25f;

                var bg2 = GetLayer("Memories").CreateSprite(bg2Path, OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                bg2.Scale(222285 + i*delay, bg2Scale);
                bg2.Fade(222285 + i*delay,  0.6); bg2.Fade(222285 + i*delay + 4000, 0);
                bg2.MoveY(222285 + i*delay, 222285 + i*delay + 4000, 650, 100);

                bg2.MoveX(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                bg2.MoveX(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                bg2.Rotate(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                bg2.Rotate(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                var bgPath = "sb/characters/cards/CF_gray/"+num+".png";
                var bgBitmap = GetMapsetBitmap(bgPath);
                var bgScale = (854.0f / bgBitmap.Width)*0.25f;

                var bg = GetLayer("Memories").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                bg.Scale(222285 + i*delay, bgScale);
                bg.Fade(OsbEasing.InSine, 222285 + i*delay, 222285 + i*delay + 3000, 1, 0);
                bg.MoveY(222285 + i*delay, 222285 + i*delay + 4000, 650, 100);

                bg.MoveX(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                bg.MoveX(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                bg.Rotate(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                bg.Rotate(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                var cadre = GetLayer("Memories").CreateSprite("sb/bubble3.png", OsbOrigin.Centre, new Vector2(i%2==0 ? 100:550, 367));
                cadre.Scale(222285 + i*delay, bgScale*2.3f);
                cadre.Fade(222285 + i*delay, 0.6); cadre.Fade(222285 + i*delay + 4000, 0);
                cadre.Color(222285 + i*delay, WHITE);
                cadre.MoveY(222285 + i*delay, 222285 + i*delay + 4000, 650, 100);

                cadre.MoveX(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? 100:550, i%2==0 ? 50:600);
                cadre.MoveX(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? 50:600, i%2==0 ? 100:550);

                cadre.Rotate(OsbEasing.InOutSine, 222285 + i*delay, 222285 + i*delay + 3000, i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10), 
                                                                                           i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10));
                
                cadre.Rotate(OsbEasing.InOutSine, 222285 + i*delay + 3000, 222285 + i*delay + 6000, i%2==0 ? MathHelper.DegreesToRadians(-10):MathHelper.DegreesToRadians(10), 
                                                                                                  i%2==0 ? MathHelper.DegreesToRadians(10):MathHelper.DegreesToRadians(-10));

                if(Random(10)%3==0)
                {
                    cadre.FlipH(222285);
                }
            }

            var misere5 = GetLayer("Memories").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere5.ScaleVec(248010, 854, 480-254);
                misere5.Fade(248010, 1); misere5.Fade(259424, 0);
                misere5.Color(248010, new Color4(0, 0, 0, 1));

            var hl4 = GetLayer("Memories").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, 367));
                hl4.Scale(295138, 1.5);
                hl4.Fade(295138, 0.65); hl4.Fade(300851, 0); 
                hl4.Color(295138, new Color4(252, 130, 147, 1));  

            rainEND(292281, 305137, new Color4(252, 130, 147, 1));

        }

        public List<int> GetShuffledNumbers()
        {
            List<int> numbers = Enumerable.Range(1, 17).ToList(); // Génère [1, 2, ..., 21]
            //Random rng = new Random();
            
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int swapIndex = Random(i + 1); // Sélection aléatoire d'un index
                (numbers[i], numbers[swapIndex]) = (numbers[swapIndex], numbers[i]); // Échange
            }

            return numbers; // Liste mélangée unique
        }

        public void rain(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Memories").CreateSprite("sb/particles/rain.png");

                var rainStartTime = Random(startTime, startTime + 500);

                var randX = Random(-107, 747); var randY = Random(500, 600); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 1200 / randZ;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1000 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.ScaleVec(rainStartTime, randZ*2, randZ>0.75 ? 10 : 5);
                rain.Color(rainStartTime, color);
                rain.Fade(startTime, 0.4); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                rain.EndGroup();
            }
        }

        public void rainEND(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Memories").CreateSprite("sb/particles/rain.png");

                var rainStartTime = Random(startTime, startTime + 500);

                var randX = Random(-107, 747) + 40; var randY = Random(500, 600); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 1200 / randZ;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1000 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.ScaleVec(rainStartTime, randZ*2, randZ>0.75 ? 10 : 5);
                rain.Color(rainStartTime, color); rain.Color(300852, WHITE);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(0));
                rain.Fade(rainStartTime, 0.4); rain.Fade(304959, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                rain.EndGroup();
            }
        }
    }
}
