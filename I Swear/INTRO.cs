using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Commands;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class INTRO : StoryboardObjectGenerator
    { 
        Color4 WHITE = new Color4(246, 241, 238, 1);

        public override void Generate()
        {   
            var misere0 = GetLayer("MISERE_DE_FIN").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                misere0.ScaleVec(295138, 854, 480-254);
                misere0.Fade(295138, 1); misere0.Fade(304959, 0);
                misere0.Color(295138, new Color4(0, 0, 0, 1));

            var hl = GetLayer("INTRO").CreateSprite("sb/particles/hl2.png", OsbOrigin.Centre, new Vector2(320, 367));
                hl.Scale(15152, 1.5);
                hl.Fade(15152, 0.65); hl.Fade(26548, 0); 
                hl.Color(15152, new Color4(252, 130, 147, 1));  

            rain(0, 27619, new Color4(252, 130, 147, 1));

            
        }

        public void rain(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("INTRO").CreateSprite("sb/particles/rain.png");

                var rainStartTime = Random(startTime, startTime + 500);

                var randX = Random(-107, 747) + 40; var randY = Random(500, 600); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 1200 / randZ;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1000 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.ScaleVec(rainStartTime, randZ*2, randZ>0.75 ? 10 : 5);
                rain.Color(rainStartTime, WHITE); rain.Color(15152, color);
                rain.Fade(866, 866 + 1000, 0, 0.4); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                rain.EndGroup();
            }
        }
    }
}
