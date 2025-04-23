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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace StorybrewScripts
{
    public class KIAIS : StoryboardObjectGenerator
    {   
        Color4 WHITE = new Color4(246, 241, 238, 1);

        public override void Generate()
        {
		    
            string layer = "Kiai";

            /*
            var bar = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));

            bar.ScaleVec(63710, 10, 20);
            bar.Fade(63710, 1); bar.Fade(99444, 0);
            bar.Rotate(63710, MathHelper.DegreesToRadians(45));
            bar.Color(63710, WHITE);

            bar.MoveY(63710, 99444, 480, 140);
            */
        }
    }
}
