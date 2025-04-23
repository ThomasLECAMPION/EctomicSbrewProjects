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
    public class ENDING : StoryboardObjectGenerator
    {
        public override void Generate()
        {   
            int mode = getMode();

		    var bg = GetLayer("BACKGROUND").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, mode==1 ? 254 : 0));
            bg.ScaleVec(74711, 854, mode==1 ? 480-254 : 480);
            bg.Fade(74711, 1); bg.Fade(91485, 0);
            bg.Color(74711, new Color4(110, 20, 30, 1));
            
            var bgBitmap = GetMapsetBitmap("sb/blur.jpg");
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            var chara = GetLayer("BACKGROUND").CreateSprite("sb/chara_mask2.png", OsbOrigin.Centre, new Vector2(320, mode==1 ? 530 : 300));
            chara.Scale(74711, bgScale);
            chara.Fade(74711, 1); chara.Fade(91485, 0);
            chara.Color(74711, new Color4(80, 15, 25, 1));
            chara.FlipH(74711);

            var fading = GetLayer("FADING").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            fading.ScaleVec(77292, 854, 480);
            fading.Fade(OsbEasing.OutSine, 77292, 91485, 0, 1);
            fading.Color(77292, new Color4(0, 0, 0, 1));
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
