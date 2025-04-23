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
    public class PREKIAI : StoryboardObjectGenerator
    {
        public override void Generate()
        {   
            int mode = getMode();

		    var bg = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, mode==1 ? 254 : 0));
            bg.ScaleVec(48904, 854, mode==1 ? 480-254 : 480);
            bg.Fade(48904, 1); bg.Fade(54066, 0);
            bg.Color(48904, new Color4(110, 20, 30, 1));

            var bgBitmap = GetMapsetBitmap("sb/blur.jpg");
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            for(int i=0; i<4; i++)
            {
                var circle = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.TopLeft, new Vector2(-107 + i*(857/14)*2, mode==1 ? 254 : 0));
                circle.ScaleVec(48904, 54066, 854/14, 0, 854/14, mode==1 ? (480-254)/2 : 240);
                circle.Fade(48904, 0.4); circle.Fade(54066, 0);
                circle.Color(48904, new Color4(80, 15, 25, 1));
            }

            for(int i=0; i<4; i++)
            {
                var circle = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.BottomRight, new Vector2(747 - i*(857/14)*2, 480));
                circle.ScaleVec(48904, 54066, 854/14, 0, 854/14, mode==1 ? (480-254)/2 : 240);
                circle.Fade(48904, 0.4); circle.Fade(54066, 0);
                circle.Color(48904, new Color4(80, 15, 25, 1));
            }

            for(int i=0; i<(mode==1 ? 1 :2); i++)
            {
                var circle = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.BottomLeft, new Vector2(-107, 480 - i*(857/14)*2));
                circle.ScaleVec(48904, 54066, 0, 854/14, 854/2 - 61, 854/14);
                circle.Fade(48904, 0.4); circle.Fade(54066, 0);
                circle.Color(48904, new Color4(80, 15, 25, 1));
            }

            for(int i=0; i<(mode==1 ? 1 :2); i++)
            {
                var circle = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.TopRight, new Vector2(747, mode==1 ? 254 : i*(857/14)*2));
                circle.ScaleVec(48904, 54066, 0, 854/14, 854/2 - 61, 854/14);
                circle.Fade(48904, 0.4); circle.Fade(54066, 0);
                circle.Color(48904, new Color4(80, 15, 25, 1));
            }

            var chara = GetLayer("BACKGROUND").CreateSprite("sb/chara_mask2.png", OsbOrigin.Centre, new Vector2(320, mode==1 ? 510 : 300));
            chara.Scale(48904, 54066, bgScale, bgScale*0.8f);
            chara.Fade(48904, 1); chara.Fade(54066, 0);
            chara.Color(48904, new Color4(80, 15, 25, 1));
            chara.FlipH(48904);
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
