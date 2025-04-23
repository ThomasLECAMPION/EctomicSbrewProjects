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
    public class LyricsSimplified : StoryboardObjectGenerator
    {
        [Configurable] public string SubtitlesPath;
        [Configurable] public string FontName = "Verdana";
        [Configurable] public int PosY = 240;
        SubtitleSet Subtitles;
        FontGenerator Font;

        int beat = 750 - 270;

        //Palette
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        Color4 colorLightA = new Color4(240, 147, 228, 1);
        Color4 colorDarkA = new Color4(139, 131, 251, 1);

        Color4 colorLightB = new Color4(227, 252, 148, 1);
        Color4 colorDarkB = new Color4(94, 220, 233, 1);

        Color4 colorLightC = new Color4(219, 227, 211, 1);
        Color4 colorDarkC = new Color4(147, 202, 108, 1);

        public override void Generate()
        {
            //Set the private variable subtitle to the subtitlefile info
            Subtitles = LoadSubtitles(SubtitlesPath);

            //Set the Font variable to the right fontGenerator
            Font = SetFont();

            //This launch the function for rendering our lyrics!
            GenerateSubtitles();
        }
        private FontGenerator SetFont()
        {
            //these line create a FontGenerator object that have the font parameters you want to be generated
            //this load the fontName, style, color, size etc etc... everything you see in the sb/f folder stuff is stored in that object
            var font = LoadFont("sb/font", new FontDescription{
                FontPath = FontName,
                FontSize = 100,
                Color = Color4.White
            });

            //after setting the font we simply return it to the function! (this is why I can do Font = SetFont())
            return font;
        }
        private void GenerateSubtitles()
        {   
            int lineKiai = 0;

            //First we loop into every lines of our lyrics file!
            foreach(var line in Subtitles.Lines)
            {   
                //For each line we're gonna set a base position to X = PosX & Y = PosY
                //and also a scale that is set to 0.3 to not have stretched up sprites!
                float LetterY = PosY;
                float scale = 0.2f;
                float lineWidth = 0;
                float LetterX = 0f;

                if(line.StartTime < 46340) // calm
                {   
                    foreach(var letter in line.Text)
                    {   
                        var texture = Font.GetTexture(letter.ToString());
                        lineWidth += texture.BaseWidth * scale;
                    }

                    LetterX = 320 - lineWidth/2;

                    //Once we're done with setting up all this things we're gonna split our lines into letters (HELLO WORLDS => H, E, L, L, O... etc..)
                    foreach(var letter in line.Text)
                    {
                        //so for each letter we link a texture, which, is the thing that gonna use the Font object we've created earlier to generate our sprite!!
                        var texture = Font.GetTexture(letter.ToString());

                        //We check if the texture isn't empty (white spaces)
                        if(!texture.IsEmpty)
                        {
                            //We set the position of each letter, and add an offset for them (to fix not aligned stuffs!)
                            var position = new Vector2(LetterX, LetterY)
                                + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                            //Now we're good! we can finally code our sprite methods! :)
                            var shadow = GetLayer("Lyrics").CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2(-200, position.Y + 2));
                            shadow.Color(line.StartTime-100, colorBlack);
                            shadow.MoveX(OsbEasing.OutSine, line.StartTime-100, line.StartTime, position.X-854 + 2, position.X + 2);
                            shadow.MoveX(line.StartTime, line.EndTime, position.X + 2, position.X + 25 + 2);
                            shadow.Fade(line.StartTime-100, line.EndTime-100, 1, 1);
                            shadow.Fade(line.EndTime-100, line.EndTime, 1, 0);
                            shadow.Scale(line.StartTime-100, scale);

                            var sprite = GetLayer("Lyrics").CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2(-200, position.Y));
                            sprite.MoveX(OsbEasing.OutSine, line.StartTime-100, line.StartTime, position.X-854, position.X);
                            sprite.MoveX(line.StartTime, line.EndTime, position.X, position.X + 25);
                            sprite.Fade(line.StartTime-100, line.EndTime-100, 1, 1);
                            sprite.Fade(line.EndTime-100, line.EndTime, 1, 0);
                            sprite.Scale(line.StartTime-100, scale);
                        }
                        //don't forget to move your letter position after each new letter!
                        LetterX += texture.BaseWidth * scale;
                    }
                }

                else // kiai
                {   
                    lineKiai++;
                    Color4 letterColor = colorLightA;
                    scale = 0.25f;

                    switch (lineKiai) // x border for nice 4:3 = [50; 590]
                    {   
                        case 1: // I'm looking everywhere but 
                            LetterY = 300f;
                            letterColor = colorLightA;
                        break;

                        case 2: // I can't find you
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkA;
                        break;

                        case 3: // I'm getting closer like it's 
                            LetterY = 300f;
                            letterColor = colorLightB;
                        break;

                        case 4: // right in front of me
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkB;
                        break;

                        case 5: // I can feel you but I 
                            LetterY = 300f;
                            letterColor = colorLightC;
                        break;

                        case 6: // cannot see you
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkC;
                        break;
                            
                        case 7: // I'm reaching out
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorLightC;
                        break;

                        case 8: // Reaching out
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorLightB;
                        break;
                            
                        case 9: // I could be dreaming but I 
                            LetterY = 300f;
                            letterColor = colorLightA;
                        break;

                        case 10: // feel so wide awake
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkA;
                        break;

                        case 11: // A secret yearning that is 
                            LetterY = 300f;
                            letterColor = colorLightB;
                        break;

                        case 12: // deep inside of me
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkB;
                        break;
                            
                        case 13: // I can feel you but I 
                            LetterY = 300f;
                            letterColor = colorLightC;
                        break;

                        case 14: // cannot see you
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorDarkC;
                        break;

                        case 15: // I'm reaching out
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorLightA;
                        break;

                        case 16: // Reaching out
                            LetterY = 367f;
                            scale = 0.42f;
                            letterColor = colorLightB;
                        break;
                    }

                    foreach(var letter in line.Text)
                    {   
                        var texture = Font.GetTexture(letter.ToString());
                        lineWidth += texture.BaseWidth * scale;
                    }

                    LetterX = 320 - lineWidth/2;

                    foreach(var letter in line.Text)
                    {   
                        //so for each letter we link a texture, which, is the thing that gonna use the Font object we've created earlier to generate our sprite!!
                        var texture = Font.GetTexture(letter.ToString());

                        //We check if the texture isn't empty (white spaces)
                        if(!texture.IsEmpty)
                        {
                            //We set the position of each letter, and add an offset for them (to fix not aligned stuffs!)
                            var position = new Vector2(LetterX, LetterY)
                                + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                            //Now we're good! we can finally code our sprite methods! :)
                            var sprite = GetLayer("LyricsKiai").CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2(position.X, position.Y));
                            sprite.Color(line.StartTime, letterColor);
                            int dir = Random(0, 2);
                            sprite.Fade(line.StartTime, 1);
                            pulsate((int)line.StartTime, (int)line.EndTime, sprite, scale);
                            sprite.Fade(line.EndTime, 0);
                        }
                            
                        //don't forget to move your letter position after each new letter!
                        LetterX += texture.BaseWidth * scale;
                    }
                }
            }
        }

        public void pulsate(int startTime, int endTime, OsbSprite sprite, float scale)
        {
            sprite.StartLoopGroup(startTime, (endTime-startTime)/beat);
                sprite.ScaleVec(OsbEasing.OutBack, 0, beat, scale, scale*1.2f, scale, scale);
            sprite.EndGroup();
        }
    }
}