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
    public class Collab : StoryboardObjectGenerator
    {
        FontGenerator Font;

        public override void Generate()
        {
		    Font = SetFont("Collab", "RubikMonoOne-Regular.ttf");

            Credits(866, 5152, "sweet arms - i swear", Font);
            Credits(5152, 9438, "slyme x linkff001", Font);
            Credits(9438, 13724, "storyboard by ectomic", Font);

            Credits(300851, 305137, "thanks for playing !", Font);

            Lyrics(866, 866 + 5000, "part. LINKFF001", Font);
            Lyrics(15152, 15152 + 5000, "part. SLYME", Font);
            Lyrics(49424, 49424 + 5000, "part. LINKFF001", Font);
            Lyrics(63710, 63710 + 5000, "part. SLYME", Font);
            Lyrics(116576, 116576 + 5000, "part. LINKFF001", Font);
            Lyrics(142289, 142289 + 5000, "part. SLYME", Font);
            Lyrics(176394, 176394 + 5000, "part. LINKFF001", Font);
            Lyrics(270845, 270845 + 5000, "part. SLYME", Font);
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
                Color = Color4.White,
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


        public void Credits(int startTime, int endTime, string text, FontGenerator font)
        {
            float LetterY = 367;

            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float scale = 0.25f;

            float LetterX = 320;      

            float lineWidth = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }   
            LetterX -= lineWidth/2;

            string layer = "TopCollab";
            var gradbar = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320+1, LetterY+18));
                gradbar.Fade(startTime, startTime + 1000, 0, 1); gradbar.Fade(OsbEasing.OutSine, endTime - 1000, endTime, 1, 0);
                gradbar.ScaleVec(OsbEasing.OutSine, startTime, startTime + 1000, 0, 2, lineWidth, 2);
                gradbar.MoveY(OsbEasing.InSine, endTime - 1000, endTime, LetterY+18, LetterY+18+20);
                gradbar.Color(startTime, new Color4(246,241,238,1));

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
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Fade(startTime, startTime + 1000, 0, 1);
                        sprite.Fade(OsbEasing.OutSine, endTime - 1000, endTime, 1, 0);
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                        sprite.MoveY(OsbEasing.OutSine, startTime, startTime + 1000, position.Y-20, position.Y);
                        sprite.MoveY(OsbEasing.InSine, endTime - 1000, endTime, position.Y, position.Y+20);

                    //revolve(startTime, startTime+500, sprite, MathHelper.DegreesToRadians(90/4), MathHelper.DegreesToRadians(-90/4), 320, 367, 50, 50);
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }


        public void Lyrics(int startTime, int endTime, string text, FontGenerator font)
        {
            float LetterY = 420;

            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float scale = 0.18f;

            float LetterX = -80;      

            float lineWidth = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }   

            string layer = "TopCollab";
            var gradbar = GetLayer(layer).CreateSprite("sb/particles/gradbar2.png", OsbOrigin.BottomCentre, new Vector2(-107, LetterY-1));
                gradbar.Fade(startTime, startTime + 1000, 0, 0.7); gradbar.Fade(OsbEasing.OutSine, endTime - 1000, endTime, 0.7, 0);
                gradbar.Scale(startTime, 0.2);
                gradbar.Rotate(startTime, MathHelper.DegreesToRadians(90));
                gradbar.Color(startTime, new Color4(252, 130, 147, 1));

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
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Fade(startTime, startTime + 1000, 0, 1);
                        sprite.Fade(OsbEasing.OutSine, endTime - 1000, endTime, 1, 0);
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                        sprite.MoveX(OsbEasing.OutSine, startTime, startTime + 1000, position.X-lineWidth, position.X);
                        sprite.MoveX(OsbEasing.InSine, endTime - 1000, endTime, position.X, position.X-lineWidth);

                    //revolve(startTime, startTime+500, sprite, MathHelper.DegreesToRadians(90/4), MathHelper.DegreesToRadians(-90/4), 320, 367, 50, 50);
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }
    }
}
