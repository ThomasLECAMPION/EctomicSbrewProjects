using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Animations;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StorybrewScripts
{
    public class CREDITS : StoryboardObjectGenerator
    {
        public override void Generate()
        {   
            int mode = getMode();
            int ySize = mode==1 ? 20 : 55;
            int yPos = mode==1 ? 254 : 0;

		    var bg = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, mode==1 ? 254 : 0));
            bg.ScaleVec(7614, 854, mode==1 ? 480-254 : 480);
            bg.Fade(7614, 1); bg.Fade(28259, 0);
            bg.Color(7614, new Color4(110, 20, 30, 1));
            
            var top = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, yPos));
            top.ScaleVec(OsbEasing.OutSine, 7614, 7614+400, 854, 0, 854, ySize);
            top.ScaleVec(OsbEasing.InCubic, 17453, 17937, 854, ySize, 854, mode==1 ? (480-254)/2 : 240);
            top.Fade(7614, 1); top.Fade(17937, 17937+150, 1, 0);
            top.Color(7614, new Color4(80, 15, 25, 1));

            var bot = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            bot.ScaleVec(OsbEasing.OutSine, 7614, 7614+400, 854, 0, 854, ySize);
            bot.ScaleVec(OsbEasing.InCubic, 17453, 17937, 854, ySize, 854, mode==1 ? (480-254)/2 : 240);
            bot.Fade(7614, 1); bot.Fade(17937, 17937+150, 1, 0);
            bot.Color(7614, new Color4(80, 15, 25, 1));


            var bgBitmap = GetMapsetBitmap("sb/blur.jpg");
            var bgScale = (854.0f / bgBitmap.Width)*0.7f;

            var chara = GetLayer("BACKGROUND").CreateSprite("sb/chara_mask2.png", OsbOrigin.Centre, new Vector2(100, mode==1 ? 460 : 260));
            chara.Scale(17937, 23098, bgScale, bgScale*1.1f);
            chara.MoveX(17937, 23098, 320+220-50, 320+220);
            chara.Fade(17937, 1); chara.Fade(23098, 0);
            chara.Color(17937, new Color4(80, 15, 25, 1));
            chara.FlipH(17937);

            var chara2 = GetLayer("BACKGROUND").CreateSprite("sb/chara_mask2.png", OsbOrigin.Centre, new Vector2(320+220, mode==1 ? 460 : 260));
            chara2.Scale(23098, 28259, bgScale, bgScale*1.1f);
            chara2.MoveX(23098, 28259, 150, 100);
            chara2.Fade(23098, 1); chara2.Fade(28259, 0);
            chara2.Color(23098, new Color4(80, 15, 25, 1));
            
            int step = 18259 - 17937;
            int start = 17937;

            string[] geos = {"hex", "circle", "f", "st"};

            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    var geo = GetLayer("BACKGROUND").CreateSprite("sb/geometry/"+geos[j]+".png", OsbOrigin.Centre, new Vector2(100, mode==1 ? 367 : 240));

                    float scale = 0.6f;
                    switch (geos[j])
                    {
                        case "hex":
                            scale=0.6f;
                            break;

                        case "circle":
                            scale=0.3f;
                            break;

                        case "f":
                            scale=0.23f;
                            break;
                        
                        case "st":
                            scale=0.8f;
                            break;
                    }
                    geo.Scale(start, mode == 1 ? scale-0.1 : scale);
                    geo.Fade(17937-1, 0); geo.Fade(start, 1); geo.Fade(start+step, 0);
                    geo.Color(start, new Color4(80, 15, 25, 1));
                    geo.Rotate(17937-1, 23098, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(360));
                    geo.MoveX(17937-1, 23098, 150, 100);

                    start+=step;
                }
            }

            start=23098;
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    var geo = GetLayer("BACKGROUND").CreateSprite("sb/geometry/"+geos[j]+".png", OsbOrigin.Centre, new Vector2(100, mode==1 ? 367 : 240));

                    float scale = 0.6f;
                    switch (geos[j])
                    {
                        case "hex":
                            scale=0.6f;
                            break;

                        case "circle":
                            scale=0.3f;
                            break;

                        case "f":
                            scale=0.23f;
                            break;
                        
                        case "st":
                            scale=0.8f;
                            break;
                    }
                    geo.Scale(start, mode == 1 ? scale-0.1 : scale);
                    geo.Fade(23098-1, 0); geo.Fade(start, 1); geo.Fade(start+step, 0);
                    geo.Color(start, new Color4(80, 15, 25, 1));
                    geo.Rotate(23098-1, 28259, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(-360));
                    geo.MoveX(23098-1, 28259, 320+220-50, 320+220);

                    start+=step;
                }
            }
        }

        public int getMode() 
        {
            using (var stream = OpenMapsetFile("PORNOFIL'MY - Lyubov' (Cut Ver.) (_linee1212) [" + Beatmap + "].osu"))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                string line;
                int i=0;

                while (reader.Peek() >=0)
                {
                    line = reader.ReadLine();
                    if(line.StartsWith("Mode:"))
                    {   
                        var modeValueStr = line.Substring("Mode:".Length).Trim();
                        int mode = int.Parse(modeValueStr);
                        
                        return mode;
                    }
                }
                
                return -1;
            }
        }
    }
}
