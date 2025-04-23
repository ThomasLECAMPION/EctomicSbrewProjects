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
    public class CINEMA : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            int mode = getMode();
            int ySize = mode==1 ? 20 : 55;
            int yPos = mode==1 ? 254 : 0;

		    var top = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, yPos));
            top.ScaleVec(OsbEasing.OutSine, 28259, 28259+400, 854, 0, 854, ySize);
            top.ScaleVec(OsbEasing.InCubic, 38259, 38582, 854, ySize, 854, mode==1 ? (480-254)/2 : 240);
            top.Fade(28259, 1); top.Fade(38582, 38582+150, 1, 0);
            top.Color(28259, new Color4(0, 0, 0, 0));

            var bot = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            bot.ScaleVec(OsbEasing.OutSine, 28259, 28259+400, 854, 0, 854, ySize);
            bot.ScaleVec(OsbEasing.InCubic, 38259, 38582, 854, ySize, 854, mode==1 ? (480-254)/2 : 240);
            bot.Fade(28259, 1); bot.Fade(38582, 38582+150, 1, 0);
            bot.Color(28259, new Color4(0, 0, 0, 0));
            
            var top2 = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, yPos));
            top2.ScaleVec(OsbEasing.OutSine, 38582, 38582+400, 854, 0, 854, ySize);
            top2.Fade(38582, 1); top2.Fade(48904, 0);
            top2.Color(38582, new Color4(0, 0, 0, 0));

            var bot2 = GetLayer("CINEMA").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            bot2.ScaleVec(OsbEasing.OutSine, 38582, 38582+400, 854, 0, 854, ySize);
            bot2.Fade(38582, 1); bot2.Fade(48904, 0);
            bot2.Color(38582, new Color4(0, 0, 0, 0));
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
