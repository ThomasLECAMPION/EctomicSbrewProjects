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
    public class BACKGROUND : StoryboardObjectGenerator
    {   
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        public override void Generate()
        {
            int mode = getMode();
            int yPos = mode==1 ? 254 : 0;

            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*1f;

            var blur = GetLayer("BACKGROUND").CreateSprite("sb/blur.jpg", OsbOrigin.TopCentre, new Vector2(320, mode==1 ? 230 : 0));
            blur.Scale(1162, bgScale);
            blur.Fade(1162, 0.4); blur.Fade(7614, 0);

            var fading = GetLayer("FADING").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            fading.ScaleVec(1162, 854, 480);
            fading.Fade(1162, 7614, 1, 0);
            fading.Color(1162, new Color4(0, 0, 0, 1));

            var bg = GetLayer("BACKGROUND").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 0));
            bg.Scale(28259, bgScale);
            bg.MoveY(28259, 38582, mode==1 ? 230 : 0, mode==1 ? 260 : 50);
            bg.Fade(28259, 1); bg.Fade(38582, 0);
            bg.FlipH(28259);

            var bg2 = GetLayer("BACKGROUND").CreateSprite(bgPath, OsbOrigin.TopCentre, new Vector2(320, 0));
            bg2.Scale(38582, bgScale);
            bg2.MoveY(38582, 48904, mode==1 ? 230 : 0, mode==1 ? 260 : 50);
            bg2.Fade(38582, 1); bg2.Fade(48904, 0);

            var vigPath = "sb/masks/vignette.png";
            var vigBitmap = GetMapsetBitmap(vigPath);
            var vigScale = (854.0f / vigBitmap.Width)*1f;

            var vig = GetLayer("VIGNETTE").CreateSprite(vigPath, OsbOrigin.TopCentre, new Vector2(320, yPos));
            if (mode==1)
            {
                vig.ScaleVec(0, 854.0f / vigBitmap.Width, (480 - 254.0f) / vigBitmap.Height);
            }
            else
            {
                vig.Scale(1162, vigScale);
            }
            vig.Color(1162, colorBlack);
            vig.Fade(1162, 7614, 0, 0.8); vig.Fade(OsbEasing.OutSine, 77292, 91485, 0.8, 0);

            Log(getMode());
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
