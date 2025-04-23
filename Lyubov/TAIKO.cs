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
    public class TAIKO : StoryboardObjectGenerator
    {
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        public override void Generate()
        {
		    int mode = getMode();

            var topbg = GetLayer("TAIKOTOP").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                topbg.ScaleVec(7614, 854.0f, 140);
                topbg.Color(7614, new Color4(110, 20, 30, 1));
                topbg.Fade(7614, mode==1 ? 1 : 0); topbg.Fade(28259, 0); 
                topbg.Fade(48904, mode==1 ? 1 : 0);
                topbg.Color(54066, new Color4(0, 0, 0, 1)); topbg.Color(74711, new Color4(110, 20, 30, 1));
                topbg.Fade(91485, 0); 

            var playfield = GetLayer("TAIKOPLAYFIELD").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(1162, 854.0f, 114.0f);
                playfield.Color(1162, colorBlack);
                playfield.Fade(1162, mode==1 ? 1 : 0); playfield.Fade(91485, 0); 
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
