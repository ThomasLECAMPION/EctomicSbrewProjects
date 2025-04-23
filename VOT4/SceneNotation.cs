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
    public class SceneNotation : StoryboardObjectGenerator
    {   
        FontGenerator Font;

        public override void Generate()
        {
		    Font = SetFont("SceneNumber", "Poppins");

            Lyrics(2628, 23384, "1 intro", Font); // intro: title artist quote

            Lyrics(23384, 44141, "2 build up", Font); // build up
            //black, minimum

            Lyrics(44141, 64898, "3 underground", Font); // underground
            //gray, few effects

            Lyrics(64898, 85655, "4 upperground", Font); // upperground
            //blue, bright effects

            Lyrics(85655, 107353, "5 chorus 1 (calm)", Font); // chorus 1 (calm)
            //gray to blue

            Lyrics(107353, 135224, "6 wub wub", Font); // wub wub
            //blue ?

            Lyrics(135224, 159999, "7 chorus 2 (pumped up)", Font); // chorus 2 (pumped up)
            //blue bright

            Lyrics(159999, 183466, "8 chorus 3 (semi calm)", Font); // chorus 3 (semi calm)
            //gray to blue

            Lyrics(183466, 224266, "9 sweet piano", Font); // sweet piano
            //black

            Lyrics(224266, 243466, "10 build up", Font); // build up 
            //gray

            Lyrics(243466, 281523, "11 verse + crazy piano", Font); // verse + crazy piano
            //blue

            Lyrics(281523, 307705, "12 first part kiai (verse)", Font); // first part kiai (verse)
            //gray to blue

            Lyrics(307705, 325160, "13 second part kiai (crazy piano)", Font); // second part kiai (crazy piano)
            //blue bright

            Lyrics(325160, 345239, "14 8bit", Font); // 8bit
            //black

            Lyrics(345239, 383017, "15 final part", Font); // final part
            //blue

        }

        public FontGenerator SetFont(string folder, string fontPath, Color4? color = null)
        {
            //these line create a FontGenerator object that have the font parameters you want to be generated
            //this load the fontName, style, color, size etc etc... everything you see in the sb/f folder stuff is stored in that object
            var font = LoadFont("sb/font/" + folder, new FontDescription()
            {
                FontPath = fontPath,
                FontSize = 80,
                Color = Color4.White,
                Padding = Vector2.Zero,
                //FontStyle = FontStyle.Bold,
                //TrimTransparency = true,
                EffectsOnly = false,
                Debug = false,
            },
            new FontGlow()
            {
                Radius = true ? 0 : 0,
                Color = Color4.Cyan,
            },
            new FontOutline()
            {
                Thickness = 0,
                Color = Color4.Black,
            },
            new FontShadow()
            {
                Thickness = color != null ? 0 : 1,
                Color = new Color4(80, 80, 80, 255),
            });

            //after setting the font we simply return it to the function! (this is why I can do Font = SetFont())
            return font;
        }

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font)
        {
            float LetterY = 200;

            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float scale = 0.35f;
            float lineWidth = 0;

            float LetterX = 320;
            //We center the line
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }
            LetterX -= lineWidth/2;            

            foreach(var letter in text)
            {
                //so for each letter we link a texture, which, is the thing that gonna use the Font object we've created earlier to generate our sprite!!
                var texture = font.GetTexture(letter.ToString());

                //We check if the texture isn't empty (white spaces)
                if(!texture.IsEmpty)
                {
                    //We set the position of each letter, and add an offset for them (to fix not aligned stuffs!)
                    var position = new Vector2(LetterX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                    //Now we're good! we can finally code our sprite methods! :)
                    string layer = "SceneNumber";
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Fade(startTime, startTime+100, 0, 1);
                        sprite.Fade(startTime+100, endTime-100, 1, 1);
                        sprite.Fade(endTime-100, endTime, 1, 0);
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }
    }
}
