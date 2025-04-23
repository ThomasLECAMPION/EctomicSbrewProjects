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

/*
Mappers’ name for each mapping section (I will send this to you later)
BPM (bpm varies in this song, so would be nice to indicate them out)
Audio visualizer (could do this throughout the mapset)
Avatar for each mapper’s parts (lmk if you are unable to get our avatar)
Beginning intro: Vietnam osu!taiko Tournament 4 presents -> The Grand Finals Tiebreaker -> Quote: be prepared to face the god of all machines -> artist and song name: Altermis - Deus Ex Machina
Ending credits: Designers (TheFunk & Zeth) / Mappers’ name / Song Artist or Composer (Altermis) / SBer (Ectomic)
This is quite difficult to describe in details, but other elements such as particles, flashing gameplay, gameplay lighting for kiai, or any other elements you think it would be fitting are great additions to make the SB more engaging to watch.
*/

namespace StorybrewScripts
{
    public class Storyboard : StoryboardObjectGenerator
    {
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        public override void Generate()
        {
            var playfieldFade = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfieldFade.ScaleVec(0, 854.0f, 114.0f);
                playfieldFade.Color(0, Color4.Black);
                playfieldFade.Fade(0, 2628, 1, 1);
                playfieldFade.Fade(2628, 0);
                playfieldFade.Fade(383017, 387462, 1, 1);

            var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(0, 854.0f, 114.0f);
                playfield.Color(0, colorBlack);
                playfield.Fade(0, 2628, 0, 1); playfield.Fade(2628, 1); 
                playfield.Fade(383017, 1);
                playfield.Fade(OsbEasing.InSine, 387184, 387462, 1, 0);
            
            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(0, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Color(0, colorBlack);
                vignette.Fade(0, 2628, 0, 0.8); vignette.Fade(2628, 0.8); 
                vignette.Fade(OsbEasing.InSine, 387184, 387462, 0.8, 0);
        }
    }
}
