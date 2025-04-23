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
    public class BuildUp1 : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            int bgYCenter = 480 - (480-254)/2;

            // 1st part
            var hl = GetLayer("Background").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                hl.Scale(12006, 22673, 1.5, 1.5);

                hl.Fade(12006, 0.5); 
                hl.Fade(OsbEasing.InSine, 12506, 12673, 0.5, 0.2);
                hl.Fade(13340, 0.5);
                hl.Fade(OsbEasing.InSine, 13840, 14006, 0.5, 0.2);
                hl.Fade(14673, 0.5);
                hl.Fade(OsbEasing.InSine, 15173, 15340, 0.5, 0.2);
                hl.Fade(16006, 0.5);
                hl.Fade(OsbEasing.InSine, 16506, 16673, 0.5, 0.2);
                hl.Fade(17340, 0.5);

                hl.Color(12006, new Color4(54,54,124,1));


            // 2nd part
            int interval = 17673 - 17340;
            for(int i=9; i>=0; i--)
            {
                var rngRotate = Random(360);
                var startTime = 17340 + (i*interval) - 100;
                
                var quantity = 4;
                var rota = 360/quantity;
                for(int j=0; j<quantity; j++)
                {   
                    Vector2 start = GetPointFromAngle(700, rngRotate + (j*rota));
                    Vector2 end = GetPointFromAngle(300 - (i*8), rngRotate + (j*rota));

                    var pl = GetLayer("Background").CreateSprite("sb/geometry/pl.png", OsbOrigin.Centre, new Vector2(320, 800));
                    pl.Scale(startTime, startTime + 2000, 1.5, 1.5);
                    pl.Fade(startTime, startTime + 2000, 1, 1);
                    pl.Move(OsbEasing.OutBack, startTime, startTime + 300, start, end);
                    pl.Move(startTime + 300, startTime + 2000, end, start);
                    pl.Rotate(startTime, MathHelper.DegreesToRadians(-90 + rngRotate + (j*rota)));
                }
            }

            // Closing curtains
            for(int i=0; i<80; i++)
            {   
                var startTime = 20006;
                var cu = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(-110 + i*11, bgYCenter));
                cu.ScaleVec(startTime + 10*i, startTime + 10*i + 300, 0, 240, 11, 240);
                cu.Fade(startTime, 22673, 1, 1);
                cu.Color(startTime, new Color4(0,0,0,1));
                cu.Rotate(startTime, MathHelper.DegreesToRadians(-5));
            }

            // 3rd part
            for(int i=0; i<43; i++)
            {
                for(int j=0; j<12; j++)
                {
                    var plus = GetLayer("Background").CreateSprite("sb/geometry/f.png", OsbOrigin.Centre, new Vector2(-100 + i*20, 257 + j*20));
                    plus.Fade(OsbEasing.InSine, 21340 - 1000 + i*10 + j*10, 21340, 0, 0.15);
                    plus.Fade(21340, 22673, 0.15, 0.15);
                    plus.Scale(21340, 0.005);
                    if((i+j)%2==0)
                    {
                        plus.Rotate(21340 - 1000 + i*10 + j*10, MathHelper.DegreesToRadians(45));
                    }
                    plus.Rotate(21340 - 1000 + i*10 + j*10, 22673, plus.RotationAt(21340 - 1000 + i*10 + j*10), plus.RotationAt(21340 - 1000 + i*10 + j*10) + MathHelper.DegreesToRadians(180));
                }
            }
            var f = GetLayer("Background").CreateSprite("sb/geometry/f.png", OsbOrigin.Centre, new Vector2(100, bgYCenter));

                f.Scale(21006, 22340, 0.08, 0.08);
                f.MoveY(OsbEasing.OutBack, 21340 - 300, 21340, 190, bgYCenter);
                f.Rotate(OsbEasing.OutSine, 21340, 21506, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(45));
                f.Rotate(OsbEasing.OutSine, 21673, 21840, MathHelper.DegreesToRadians(45), MathHelper.DegreesToRadians(90));
                f.Rotate(OsbEasing.OutSine, 22006, 22173, MathHelper.DegreesToRadians(90), MathHelper.DegreesToRadians(135));
                f.MoveX(OsbEasing.InBack, 22340-300, 22340, 100, 320);
                //f.Scale(22340, 22673, 0.08, 0.07);

            var f2 = GetLayer("Background").CreateSprite("sb/geometry/f.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                f2.Scale(21006, 22340, 0.08, 0.08);
                f2.MoveY(OsbEasing.OutBack, 21673 - 300, 21673, 190, bgYCenter);
                f2.Rotate(OsbEasing.OutSine, 21673, 21840, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(45));
                f2.Rotate(OsbEasing.OutSine, 22006, 22173, MathHelper.DegreesToRadians(45), MathHelper.DegreesToRadians(90));
                f2.Scale(22340, 22673, 0.08, 0.07);

            var f3 = GetLayer("Background").CreateSprite("sb/geometry/f.png", OsbOrigin.Centre, new Vector2(540, bgYCenter));
                f3.Scale(21006, 22340, 0.08, 0.08);
                f3.Additive(21006);
                f3.MoveY(OsbEasing.OutBack, 22006 - 300, 22006, 190, bgYCenter);
                f3.Rotate(OsbEasing.OutSine, 22006, 22173, MathHelper.DegreesToRadians(90), MathHelper.DegreesToRadians(135));
                f3.MoveX(OsbEasing.InBack, 22340-300, 22340, 540, 320);
                f3.Scale(22340, 22673, 0.08, 0.07);

            var circ = GetLayer("Background").CreateSprite("sb/geometry/circle1.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                circ.Scale(OsbEasing.OutSine, 22173 + 75, 22340, 0, 0.19);
                circ.Scale(22340, 22673, 0.19, 0.20);
        }   

        public static Vector2 GetPointFromAngle(float radius, float angleDegrees)
        {
            Vector2 center = new Vector2(320, 367);
            // Convertir l'angle de degrés à radians
            double angleRadians = angleDegrees * (Math.PI / 180);

            // Calculer les coordonnées du point
            float x = center.X + radius * (float)Math.Cos(angleRadians);
            float y = center.Y + radius * (float)Math.Sin(angleRadians);

            return new Vector2(x, y);
        }

        public void Flash(int startTime, int length)
        {
            var flash = GetLayer("Flash").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
            flash.ScaleVec(startTime, 854, 480-254);
            flash.Fade(startTime, startTime + length, 1, 0);
        }
    }
}
