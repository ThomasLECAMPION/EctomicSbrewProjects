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
    public class EasyTaikoTop : StoryboardObjectGenerator
    {   
        [Group("Timing")]
        [Description("Copy paste timings from storybrew\nIf both StartTime and Endtime equals 0, they will default to the first and last note of the map")]
        [Configurable] public int StartTime = 0;
        [Description("Copy paste timings from storybrew\nIf both StartTime and Endtime equals 0, they will default to the first and last note of the map")]
        [Configurable] public int EndTime = 0;

        [Description("Loop duration is in ms\n\nHigher values makes the loop slower\nLower values makes the loop faster\n\nOnly a set of values works, you'll find them in the logs of this effect (Leaf icon)\nAn incorrect value will make the final loop not end at the EndTime")]
        [Configurable] public int LoopDuration = 100000;
        

        [Group("Sprite")]
        [Description("Path to the sprite located in your mapset folder")]
        [Configurable] public string SpritePath = "sb/scroll.png";

        [Description("offsetY=0 places the bottom of the sprite to the bottom of the taiko playfield (Y=254)\nNegative values moves the sprite up\nPositive values moves the sprite down")]
        [Configurable] public int OffsetY = 0;

        [Description("Setting Alpha=0 allows to ignore the Color attribute")]
        [Configurable] public Color4 Color = new Color4(1, 1, 1, 0);

        [Group("Additional")]
        [Description("Scroll direction")]
        [Configurable] public bool RightToLeft = false;
        [Description("Displays a black bar under the taiko playfield\nUseful for hiding stuff under")]
        [Configurable] public bool TaikoPlayfield = false;

        public override void Generate() 
        {   
            if (StartTime == EndTime && Beatmap.HitObjects.FirstOrDefault() != null)
            {
                StartTime = (int)Beatmap.HitObjects.First().StartTime;
                EndTime = (int)Beatmap.HitObjects.Last().StartTime;
            }
            
            var spriteBitmap = GetMapsetBitmap(SpritePath);
            int totalTime = EndTime - StartTime;
            int nbOfLoops = totalTime / LoopDuration;

            showLoopDurations(totalTime);

            for(int i=0; i<2; i++)
            {
                var sprite = GetLayer("TaikoTop").CreateSprite(SpritePath, OsbOrigin.BottomCentre, new Vector2(320, 254 + OffsetY));

                sprite.Fade(StartTime, EndTime, 1, 1);
                sprite.Scale(StartTime, (854.0f / spriteBitmap.Width));
                if(Color.A != 0)
                    sprite.Color(StartTime, Color);

                sprite.StartLoopGroup(StartTime, nbOfLoops);
                    if(RightToLeft)
                        sprite.MoveX(0, LoopDuration, 320 + 854 - (i*854), 320 - (i*854));
                    else
                        sprite.MoveX(0, LoopDuration, 320 - 854 + (i*854), 320 + (i*854));
                sprite.EndGroup();
            }

            if (TaikoPlayfield)
            {
                var playfield = GetLayer("TaikoTop").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(StartTime, 854.0f, 114.0f);
                playfield.Color(StartTime, Color4.Black);
                playfield.Fade(StartTime, EndTime, 1, 1);
            }
        }

        public void showLoopDurations(int totalTime)
        {   
            Log("StartTime = " + StartTime + "\nEndTime = " + EndTime + "\n");
            for(int i=5000; i<=totalTime/2; i++) //5000 because loops faster than 5000ms are way too fast, but feel free to lower it if you need
            {
                double nbCycles = (double)totalTime/i;
                if(nbCycles == Math.Floor(nbCycles))
                {
                    Log("Loop Duration = " + i + "ms || " + nbCycles + " cycles");
                }
            }
        }
    }
}
