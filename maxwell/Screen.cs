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
    public class Screen : StoryboardObjectGenerator
    {   
        Color4 Green = new Color4(102, 255, 94, 255);

        Color4 Blue = new Color4(99, 146, 255, 255);

        Color4 Yellow = new Color4(230, 255, 99, 255);

        Color4 Pink = new Color4(243, 99, 255, 255);

        Color4 Cyan = new Color4(98, 255, 237, 255);

        Color4 Red = new Color4(255, 99, 99, 255);

        Color4 White = new Color4(215, 215, 215, 255);

        Color4 Black = new Color4(24, 24, 24, 255);

        Color4 Gray = new Color4(202, 202, 202, 255);

        Color4 Dark = new Color4(181, 181, 181, 255);

        int midScreen = 254+(480-254)/2;

        public override void Generate()
        {   
            var textureBitmap = GetMapsetBitmap("sb/texture.jpg");
            var texture = GetLayer("Texture").CreateSprite("sb/texture.jpg", OsbOrigin.TopCentre, new Vector2(320, 254));
                texture.Scale(224, 854f/textureBitmap.Width);
                texture.Fade(224, 0.05);
                texture.Fade(4584, 0);

                texture.Fade(30748, 0.05);
                texture.Fade(35109, 0);


		    var uniBG = GetLayer("uniBG").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                uniBG.ScaleVec(224, 854, 480-254);
                uniBG.Additive(224);

                //intro zoom-ins
                uniBG.Fade(224, 1);
                    uniBG.Color(224, Green);
                    uniBG.Color(1314, Blue);
                    uniBG.Color(2404, Yellow);
                    uniBG.Color(3494, Pink);
                uniBG.Fade(4584, 0);
                
                int[] timings = {224, 1314, 2404, 3494, 4584};
                for(int j=0; j<timings.Length-1; j++)
                {
                    for(int i=0; i<8; i++)
                    {   
                        int xpos = -107 - 140 + i*140;
                        var slash = GetLayer("Slash").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(xpos, 240));
                            slash.ScaleVec(timings[j], 70, 520);
                            slash.Color(timings[j], Black);
                            slash.Fade(timings[j], 0.2);
                            slash.Fade(timings[j+1], 0);
                        if(j%2 == 0)
                        {
                            slash.Rotate(timings[j], MathHelper.DegreesToRadians(15));
                            slash.MoveX(timings[j], timings[j+1], xpos, xpos + 140);
                        }
                        else
                        {   
                            xpos = 747 + 140 - i*140;
                            slash.Rotate(timings[j], MathHelper.DegreesToRadians(-15));
                            slash.MoveX(timings[j], timings[j+1], xpos, xpos - 140);
                        }
                    }
                }
                                
                //part1
                var versaillesBitmap = GetMapsetBitmap("sb/photos/v.jpg");
                var versailles = GetLayer("uniBG").CreateSprite("sb/photos/v.jpg", OsbOrigin.TopCentre, new Vector2(300, 65));
                    versailles.Scale(4584, (854f/versaillesBitmap.Width)*1.1);
                    versailles.Fade(4584, 1);
                        versailles.MoveX(4584, 8945, 280, 320);
                    versailles.Fade(8945, 0);

                var arcBitmap = GetMapsetBitmap("sb/photos/arc.jpg");
                var arc = GetLayer("uniBG").CreateSprite("sb/photos/arc.jpg", OsbOrigin.TopCentre, new Vector2(320, -138));
                    arc.Scale(8945, (854f/arcBitmap.Width)*1.1);
                    arc.Fade(8945, 1);
                        arc.MoveX(8945, 13305, 320, 280);
                    arc.Fade(13305, 0);

                int xOffset=35;
                var arcM = GetLayer("Mask").CreateSprite("sb/photos/arcMask.png", OsbOrigin.TopCentre, new Vector2(320, 235));
                    arcM.Scale(8945, (854f/arcBitmap.Width)*1.1);
                    arcM.Fade(8945, 1);
                        arcM.MoveX(8945, 13305, 320+xOffset, 280+xOffset);
                    arcM.Fade(13305, 0);

                var ftBitmap = GetMapsetBitmap("sb/photos/ft.jpg");
                var ft = GetLayer("uniBG").CreateSprite("sb/photos/ft.jpg", OsbOrigin.TopCentre, new Vector2(320, 40));
                    ft.Scale(13305, (854f/ftBitmap.Width));
                    ft.Fade(13305, 1);
                        ft.MoveY(13305, 17666, 50, 10);
                    ft.Fade(17666, 0);


                //part2
                var mapBitmap = GetMapsetBitmap("sb/worldmap.png");
                var mapBG = GetLayer("uniBG").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                    mapBG.ScaleVec(17666, 854, 480-254);
                    mapBG.Color(17666, White);
                    mapBG.Fade(17666, 1);
                    mapBG.Fade(19846, 0);

                    mapBG.Fade(22027, 1);
                    mapBG.Fade(24207, 0);

                    mapBG.Fade(26387, 1);
                    mapBG.Fade(28568, 0);

                var map = GetLayer("uniBG").CreateSprite("sb/worldmap.png", OsbOrigin.TopCentre, new Vector2(320, 155));
                    map.Scale(17666, (854f/mapBitmap.Width)*1.2);
                    map.Color(17666, Dark);
                    map.Fade(17666, 1);
                        map.Move(OsbEasing.InOutSine, 17666, 19846, new Vector2(343, 198), new Vector2(270, 120));
                    map.Fade(19846, 0);

                    map.Fade(22027, 1);
                        map.Move(OsbEasing.InOutSine, 22027, 24207, new Vector2(270, 120), new Vector2(20, 175));
                    map.Fade(24207, 0);

                    map.Fade(26387, 1);
                        map.Move(OsbEasing.InOutSine, 26387, 28568, new Vector2(20, 175), new Vector2(580, 125));
                    map.Fade(28568, 0);

                var plus = GetLayer("uniBG").CreateSprite("sb/geometry/plus.png", OsbOrigin.TopCentre, new Vector2(320, midScreen));
                    plus.Scale(17666, 0.01);
                    plus.Fade(17666, 1);
                    plus.Fade(19846, 0);

                    plus.Fade(22027, 1);
                    plus.Fade(24207, 0);

                    plus.Fade(26387, 1);
                    plus.Fade(28568, 0);

                var pyramidsBitmap = GetMapsetBitmap("sb/photos/pyramids.jpg");
                var pyramids = GetLayer("uniBG").CreateSprite("sb/photos/pyramids.jpg", OsbOrigin.TopCentre, new Vector2(300, 65));
                    pyramids.Scale(19846, (854f/pyramidsBitmap.Width)*1.1);
                    pyramids.Fade(19846, 1);
                        pyramids.MoveX(19846, 22027, 280, 320);
                    pyramids.Fade(22027, 0);

                var wallBitmap = GetMapsetBitmap("sb/photos/wall.jpg");
                var wall = GetLayer("uniBG").CreateSprite("sb/photos/wall.jpg", OsbOrigin.TopCentre, new Vector2(320, 65));
                    wall.Scale(24207, (854f/wallBitmap.Width));
                    wall.Fade(24207, 1);
                        wall.MoveY(24207, 26387, 0, -40);
                    wall.Fade(26387, 0);

                var rocketBitmap = GetMapsetBitmap("sb/photos/rocket.jpg");
                var rocket = GetLayer("uniBG").CreateSprite("sb/photos/rocket.jpg", OsbOrigin.TopCentre, new Vector2(320, 120));
                    rocket.Scale(28568, (854f/rocketBitmap.Width));
                    rocket.Fade(28568, 1);
                        rocket.MoveY(28568, 30748, 0, 160);
                    rocket.Fade(30748, 0);

                //build up
                uniBG.Fade(30748, 1);
                    uniBG.Color(30748, Red);
                uniBG.Fade(35109, 0);

                int[] timings2 = {30748, 31838, 32928, 34019, 35109};
                for(int j=0; j<timings2.Length-1; j++)
                {
                    for(int i=0; i<8; i++)
                    {   
                        int xpos = -107 - 140 + i*140;
                        var slash = GetLayer("Slash").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(xpos, 240));
                            slash.ScaleVec(timings2[j], 70, 520);
                            slash.Color(timings2[j], Black);
                            slash.Fade(timings2[j], 0.2);
                            slash.Fade(timings2[j+1], 0);
                        if(j%2 == 0)
                        {
                            slash.Rotate(timings2[j], MathHelper.DegreesToRadians(15));
                            slash.MoveX(timings2[j], timings2[j+1], xpos, xpos + 140);
                        }
                        else
                        {   
                            xpos = 747 + 140 - i*140;
                            slash.Rotate(timings2[j], MathHelper.DegreesToRadians(-15));
                            slash.MoveX(timings2[j], timings2[j+1], xpos, xpos - 140);
                        }
                    }
                }

            //part3

            var solarBitmap = GetMapsetBitmap("sb/photos/earth.jpg");
                var solar = GetLayer("uniBG").CreateSprite("sb/photos/earth.jpg", OsbOrigin.Centre, new Vector2(320, midScreen));
                    solar.Scale(35109, 39469, ((480f-254f)/solarBitmap.Height), ((480f-254f)/solarBitmap.Height)*0.5);
                    solar.Fade(35109, 1);
                        solar.Additive(35109);
                    solar.Fade(39469, 0);
                    particlesPopUp(35109, 47918, 200);

            var neptuneBitmap = GetMapsetBitmap("sb/photos/neptune.jpg");
                var neptune = GetLayer("uniBG").CreateSprite("sb/photos/neptune.jpg", OsbOrigin.Centre, new Vector2(320, midScreen));
                    neptune.Scale(39469, ((480f-254f)/neptuneBitmap.Height)*1.8);
                    neptune.Fade(39469, 1);
                        neptune.MoveX(39469, 43830, 320+150, 320-150);
                        neptune.Additive(39469);
                    neptune.Fade(43830, 0);
        }

        public void particlesPopUp(int startTime, int endTime, int quantity)
        {
            for (int i=0; i<quantity; i++)
            {   
                var randomX = Random(320 + 10 -(854/2), 320 - 10 +(854/2)); var randomY = Random(254 + 5, 480 - 5);
                var particle = GetLayer("stars").CreateSprite("sb/particles/light.png", OsbOrigin.Centre, new Vector2(randomX, randomY));

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
    }
}
