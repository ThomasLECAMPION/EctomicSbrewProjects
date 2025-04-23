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
    public class Scroller : StoryboardObjectGenerator
    {   
        Color4 Gray = new Color4(202, 202, 202, 255);

        Color4 Dark = new Color4(181, 181, 181, 255);

        Color4 Green = new Color4(102, 255, 94, 255);

        Color4 Blue = new Color4(99, 146, 255, 255);

        Color4 Yellow = new Color4(230, 255, 99, 255);

        Color4 Pink = new Color4(243, 99, 255, 255);

        Color4 Cyan = new Color4(98, 255, 237, 255);

        Color4 Red = new Color4(255, 99, 99, 255);

        Color4 White = new Color4(215, 215, 215, 255);

        Color4 Black = new Color4(24, 24, 24, 255);

        int midScreen = 254+(480-254)/2;

        public override void Generate()
        {
		    var uniBG = GetLayer("TopBack").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                uniBG.ScaleVec(224, 854, 140);

                //intro zoom-ins
                uniBG.Fade(224, 1);
                    uniBG.Color(224, White);
                uniBG.Fade(47918, 0);

            var uniBG2 = GetLayer("TopFront").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                uniBG2.ScaleVec(224, 854, 140);

                //intro zoom-ins
                uniBG2.Fade(224, 1);
                    uniBG2.Color(224, Green);
                    uniBG2.Color(1314, Blue);
                    uniBG2.Color(2404, Yellow);
                    uniBG2.Color(3494, Pink);
                uniBG2.Fade(4584, 0);

                uniBG2.Fade(30748, 1);
                    uniBG2.Color(30748, Red);
                uniBG2.Fade(35109, 0);
            
            int quantity = 35;
            for(int i=0; i<quantity; i++)
            {
                int xpos = Random(-107, 747);
                var particle = GetLayer("TopParticles").CreateSprite("sb/geometry/circle.png", OsbOrigin.TopCentre, new Vector2(xpos, 70));
                    particle.Scale(224, i%2==0 ? 0.05 : 0.04);
                    particle.Color(224, i%3==0 ? Dark : Gray);
                    particle.Fade(224, 0.5);
                    particle.Fade(47918, 0);

                    int delay = 154; // 150
                    int start = 224 + i*delay; //224
                    particle.StartLoopGroup(start, 8);
                        particle.MoveY(0, quantity*delay, 160, -50);
                    particle.EndGroup();
            }

            var loadOutline = GetLayer("Cursor").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 70));
                loadOutline.ScaleVec(4584, 854, 20);
                loadOutline.Color(4584, Dark);
                loadOutline.Fade(4584, 1);
                loadOutline.Fade(47918, 0);

            var load = GetLayer("Cursor").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 70));
                load.ScaleVec(4584, 854, 17);
                load.Color(4584, White);
                load.Fade(4584, 1);
                load.Fade(47918, 0);
            
            var cursorOutline = GetLayer("Cursor").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, new Vector2(320, 70));
                cursorOutline.Scale(4584, 0.08);
                cursorOutline.Color(4584, Dark);
                cursorOutline.Fade(4584, 1);
                cursorOutline.Fade(47918, 0);
                cursorOutline.Rotate(4584, 47918, 0, MathHelper.DegreesToRadians(720));
                cursorOutline.MoveX(224, 47918, -107, 747);

            var cursor = GetLayer("Cursor").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, new Vector2(320, 70));
                cursor.Scale(4584, 0.075);
                cursor.Color(4584, Gray);
                cursor.Fade(4584, 1);
                cursor.Fade(47918, 0);
                cursor.Rotate(4584, 47918, 0, MathHelper.DegreesToRadians(720));
                cursor.MoveX(224, 47918, -107, 747);
        }
    }
}
