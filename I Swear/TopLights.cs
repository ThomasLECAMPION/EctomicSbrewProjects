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
    //endtime = 304959
    public class TopLights : StoryboardObjectGenerator
    {
        Color4 WHITE = new Color4(246, 241, 238, 1);
        Color4 ROSE = new Color4(252, 130, 147, 1);

        public override void Generate()
        {   
            var curtain0 = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                curtain0.ScaleVec(0, 854, 140);
                curtain0.Fade(0, 1); curtain0.Fade(304959, 0);
                curtain0.Color(0, new Color4(0, 0, 0, 1));

            var curtain = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                curtain.ScaleVec(15152, 854, 140);
                curtain.Fade(15152, 0.45); 
                curtain.Fade(26548, 0.25); 
                curtain.Fade(49424, 0.45); 
                curtain.Fade(63710, 0.65); 
                curtain.Fade(105148, 0.25); 
                curtain.Fade(128003, 0.45); 
                curtain.Fade(142289, 0.65); 
                curtain.Fade(199436, 0.25); 
                curtain.Fade(222285, 0.45); 
                curtain.Fade(259424, 0.25); 
                curtain.Fade(270845, 0.65); 
                curtain.Fade(295138, 0.45); 
                curtain.Fade(300851, 0);
                curtain.Color(15152, ROSE);

            var textureBitmap = GetMapsetBitmap("sb/texture.jpg");
            var texture = GetLayer("Top").CreateSprite("sb/texture.jpg", OsbOrigin.TopCentre, new Vector2(320, 0));
                texture.Scale(15152, (854.0f / textureBitmap.Width));
                texture.Fade(15152, 0.06); texture.Fade(300851, 0);
                texture.Color(15152, ROSE);

            var blackcurtain = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                blackcurtain.ScaleVec(60853, 854, 140);
                blackcurtain.Fade(60853, 1); blackcurtain.Fade(63710, 0);
                blackcurtain.Fade(99444, 1); blackcurtain.Fade(105148, 0);
                blackcurtain.Fade(139432, 1); blackcurtain.Fade(142289, 0);
                blackcurtain.Fade(176573, 1); blackcurtain.Fade(199436, 0);
                blackcurtain.Fade(248010, 1); blackcurtain.Fade(259424, 0);
                blackcurtain.Color(60853, new Color4(0, 0, 0, 1));

            wave(15152, 26548);
            wave(295138, 300851);
        }

        public void wave(int startTime, int endTime, string layer="Wave")
        {
            /*
            for(int i = 0; i<35; i++)
            {   
                int centerY = 158;
                for(int j = 0; j<4; j++)
                { 
                    int start = 9000 + i*delay;
                    centerY-=20;
                    var roam = GetLayer("TopWave").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(-111 + i*25 + j*5, centerY));
                        roam.ScaleVec(start, 10 - j*2, 4 - j*0.8);
                        roam.Fade(start, 0);
                        roam.Fade(63710, 0.4 - j*0.1); roam.Fade(99444, 0);
                        roam.Fade(142289, 0.4 - j*0.1); roam.Fade(176573, 0);
                        roam.Fade(270845, 0.4 - j*0.1); roam.Fade(295138, 0);
                        roam.Color(start, WHITE);
                        
                        roam.StartLoopGroup(start, 35);
                            roam.MoveY(OsbEasing.InOutQuad, 0, delay*10, centerY-rayon, centerY+rayon);
                            roam.MoveY(OsbEasing.InOutQuad, delay*10, delay*20, centerY+rayon, centerY-rayon);
                        roam.EndGroup();   
                }
            }
            */

            int delay = 200;
            int quantity = 35;

            for(int i = 0; i<quantity; i++)
            {   
                int centerY = 367;
                int ax = 6; int ay = 2;
                int bx = 10; int by = 4;
                float afade = 1f; float bfade = 0.1f;
                int arayon = 10; int brayon = -10; 
                int end = endTime + delay*20;
                int start = startTime - delay*quantity + i*delay;

                for(int j = 0; j<2; j++)
                { 
                    if(j==1) 
                    {
                        arayon = -10; brayon = 10;
                        ax = 10; ay = 4;
                        bx = 6; by = 2;

                        afade = 0.1f; bfade = 1f;
                    }

                    var roam = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(-105 + i*25, centerY));
                        roam.ScaleVec(start, 10, 4);
                        roam.Color(start, j==1?WHITE:WHITE);
                        roam.Fade(start, 0); roam.Fade(startTime, 1); roam.Fade(endTime, 0);
                        
                        roam.StartLoopGroup(start, (int)((end - start) / (delay*20)));
                            roam.MoveY(OsbEasing.InOutQuad, 0, delay*10, centerY-arayon, centerY+arayon);
                            roam.MoveY(OsbEasing.InOutQuad, delay*10, delay*20, centerY+arayon, centerY-arayon);

                            roam.ScaleVec(OsbEasing.InOutQuad, 0, delay*5, ax, ay, bx, by);
                            roam.ScaleVec(OsbEasing.InOutQuad, delay*5, delay*10, bx, by, ax, ay);
                            roam.ScaleVec(OsbEasing.InOutQuad, delay*10, delay*15, ax, ay, bx, by);
                            roam.ScaleVec(OsbEasing.InOutQuad, delay*15, delay*20, bx, by, ax, ay);
                            
                            /*
                            roam.Fade(OsbEasing.InOutQuad, 0, delay*5, bfade, afade);
                            roam.Fade(OsbEasing.InOutQuad, delay*5, delay*10, afade, bfade);
                            roam.Fade(OsbEasing.InOutQuad, delay*10, delay*15, bfade, afade);
                            roam.Fade(OsbEasing.InOutQuad, delay*15, delay*20, afade, bfade);
                            */
                        roam.EndGroup();   
                }
            }

            /*
            var misere = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                misere.ScaleVec(startTime - delay*quantity, 854, 140);
                misere.Fade(startTime - delay*quantity, 1); misere.Fade(startTime, 0);
                misere.Color(startTime - delay*quantity, new Color4(0, 0, 0, 1));
            */
        }
    }
}
