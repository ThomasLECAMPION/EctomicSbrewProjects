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

namespace StorybrewScripts
{   
    public class Kiai1 : StoryboardObjectGenerator
    {
        FontGenerator Font;

        FontGenerator FontBold;

        public override void Generate()
        {   
            int tempo = 23006 - 22673;

            var flash = GetLayer("Flash").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
            flash.ScaleVec(22673, 854, 480-254);
            flash.Fade(22673, 22673 + 350, 1, 0);


            int bgYCenter = 480 - (480-254)/2;

		    var bgPath = "sb/bg_blur.jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = 854.0f / bgBitmap.Width;

            var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, 380));
            bg.Fade(22673, 33340, 0.7, 0.7);   

            bg.StartLoopGroup(22673, 32);
                bg.Scale(0, tempo/2, bgScale*1.10, bgScale);
                bg.Scale(tempo/2, tempo, bgScale, bgScale);
            bg.EndGroup();

            
            var pulseL = GetLayer("Flash").CreateSprite("sb/masks/pulse2.png", OsbOrigin.BottomCentre, new Vector2(-107, bgYCenter));
            pulseL.ScaleVec(22673, 2.3, 5);
            pulseL.Rotate(22673, MathHelper.DegreesToRadians(90));
            pulseL.StartLoopGroup(22673, 16);
                pulseL.Fade(0, tempo, 1, 0);
                pulseL.Fade(tempo, tempo*2, 0, 0);
            pulseL.EndGroup();

            var pulseR = GetLayer("Flash").CreateSprite("sb/masks/pulse2.png", OsbOrigin.BottomCentre, new Vector2(747, bgYCenter));
            pulseR.ScaleVec(23006, 2.3, 5);
            pulseR.Rotate(23006, MathHelper.DegreesToRadians(270));
            pulseR.StartLoopGroup(23006, 16);
                pulseR.Fade(0, tempo, 1, 0);
                pulseR.Fade(tempo, tempo*2, 0, 0);
            pulseR.EndGroup();
            
            
            
            int offsetX = -38;
            var cover = GetLayer("Background").CreateSprite("sb/cover.png", OsbOrigin.Centre, new Vector2(230 + offsetX, bgYCenter));
            cover.Scale(22673, 33340, 0.25, 0.25);
            cover.Fade(22673, 33340, 1, 1);

            Font = SetFont("Font", "Poppins-ExtraLight.ttf");
            FontBold = SetFont("FontBold", "Poppins-Medium.ttf");
            Lyrics(22673, 33340, "Lost Dream", FontBold, new Color4(54, 54, 124, 1), 419 + offsetX, bgYCenter + 6, 0.40f);
            Lyrics(22673, 33340, "Lost Dream", FontBold, new Color4(255, 255, 255, 1), 420 + offsetX, bgYCenter + 5, 0.40f);
            Lyrics(22673, 33340, "Tatsunoshin", Font, new Color4(54, 54, 124, 1), 388 + offsetX, bgYCenter + 41, 0.28f);
            Lyrics(22673, 33340, "Tatsunoshin", Font, new Color4(255, 255, 255, 1), 389 + offsetX, bgYCenter + 40, 0.28f);
            
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

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, Color4 color, float LetterX = 320, float LetterY = 254+(480-254)/2, float scale = 0.35f)
        {
            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float lineWidth = 0;

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
                    string layer = "Text";
                    int midTime = startTime + 600;
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        //sprite.MoveX(OsbEasing.OutSine, startTime, midTime, 320, position.X);
                        sprite.Fade(startTime, endTime, 1, 1);
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, color);
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }
    }
}
