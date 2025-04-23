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
    //Beginning intro: Vietnam osu!taiko Tournament 4 presents
    //The Grand Finals Tiebreaker
    //Quote: be prepared to face the god of all machines 
    //Altermis - Deus Ex Machina

    public class Intro : StoryboardObjectGenerator
    {
        FontGenerator Font;

        FontGenerator FontBold;

        FontGenerator FontItalic;

        Color4 Blue = new Color4(162, 255, 255, 1);

        public override void Generate()
        {           
            var bgBitmap = GetMapsetBitmap("sb/blur.png");
            var bgScale = 854.0f / bgBitmap.Width;
            int bgYCenter = (480/2);

            var bgGray = GetLayer("Background").CreateSprite("sb/blurgray.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                bgGray.Fade(2628, 13006, 0.8, 0.8);
                bgGray.Scale(2628, bgScale);
                bgGray.Additive(2628);

            var bg = GetLayer("Background").CreateSprite("sb/blur.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                bg.Fade(12357, 13006, 0, 1); bg.Fade(13006, 23384, 1, 1);
                bg.Scale(12357, bgScale);
                bg.Additive(12357);


            Font = SetFont("Font", "Poppins-ExtraLight.ttf");
            FontBold = SetFont("FontBold", "Poppins-Medium.ttf");
            FontItalic = SetFont("FontItalic", "Poppins-ExtraLightItalic.ttf");


            pulse(1979, 2628);
            pulse(12357, 13006);
            pulse(22736, 23384);

            int[] violins = {   2628, 5222, 7817, 10411, 11709, 12357, 
                                13006, 15600, 18195, 20790, 22087, 22736};

            foreach(int start in violins)
            {
                int time = start - 100;
                var ripple = GetLayer("Geometry").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, 197));
                    ripple.Fade(time, time+800, 0.6, 0.6);
                    ripple.Scale(OsbEasing.OutSine, time, time + 800, 0.08, 0.30);

                var rippleIn = GetLayer("Geometry").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(320, 197));
                    rippleIn.Fade(time, time+800, 1, 1);
                    rippleIn.Scale(OsbEasing.OutSine, time, time+800, 0.07, 0.30);
                    rippleIn.Color(time, Color4.Black);

            }

            for(int i=0; i<20; i++)
            {   
                var position = new Vector2(320, Random(345, 390));
                var timing = Random(2628, 5628)-500;
                int x = i%2==0 ? 1500 : -1500;

                var ray = GetLayer("Geometry").CreateSprite("sb/particles/light.png", OsbOrigin.Centre, position);
                    ray.ScaleVec(timing, 0.01, 5);
                    ray.Additive(timing);
                    ray.Rotate(timing, MathHelper.DegreesToRadians(90));
                    ray.Color(timing, Blue);
                    ray.Fade(timing, 0.3);
                    ray.Fade(13006, 0);

                ray.StartLoopGroup(timing, 5);
                    ray.MoveX(0, 3000, x, -1*x);
                ray.EndGroup();                               
            }

            Lyrics(2628, 7817, "Vietnam osu!taiko Tournament 4", FontBold);
            Lyrics(3925, 7817, "presents", FontItalic, 40+254+(480-254)/2);

            Lyrics(7817, 13006, "The Grand Finals Tiebreaker", Font);


            int beat = 13330 - 13006;

            var timingStart = 13006;

            var star = GetLayer("Geometry").CreateSprite("sb/geometry/star.png", OsbOrigin.Centre, new Vector2(737, 480));
                star.Scale(timingStart, 0.25);
                star.Additive(timingStart);
                
                //star.Color(timingStart, Blue);
                star.Fade(timingStart, 0.1);
                star.Fade(23384, 0);          

            for(int angle=0; angle<10; angle++)
            {
                var rotation = star.RotationAt(timingStart);
                star.Rotate(OsbEasing.OutSine, timingStart, timingStart+beat/2, rotation, rotation + MathHelper.DegreesToRadians(45));

                timingStart+=beat*4;
            }            

            timingStart = 13006;

            var star2 = GetLayer("Geometry").CreateSprite("sb/geometry/star.png", OsbOrigin.Centre, new Vector2(-97, 480));
                star2.Scale(timingStart, 0.25);
                star2.Additive(timingStart);
                
                //star.Color(timingStart, Blue);
                star2.Fade(timingStart, 0.1);
                star2.Fade(23384, 0);         
                star2.FlipH(timingStart); 

            for(int angle=0; angle<10; angle++)
            {
                var rotation = star2.RotationAt(timingStart);
                star2.Rotate(OsbEasing.OutSine, timingStart, timingStart+beat/2, rotation, rotation + MathHelper.DegreesToRadians(-45));

                timingStart+=beat*4;
            }                   

            Lyrics(13006, 18195, "BE PREPARED", FontBold);
            Lyrics(14303, 18195, "To face the god of all machines", Font, 40+254+(480-254)/2);

            var altermis = GetLayer("IntroText").CreateSprite("sb/altermis.png", OsbOrigin.Centre, new Vector2(320, 254+(480-254)/2));
                altermis.ScaleVec(OsbEasing.OutSine, 18195, 18195+600, 0, 0.25, 0.25, 0.25);
                altermis.Fade(18195, 18195+600, 0, 0.82);
                altermis.Fade(23384, 0);       

            Lyrics(18195, 23384, "Deus Ex Machina", FontBold, 40+254+(480-254)/2, true);

            mappers(FontBold);
            bpm(Font);

            float yBold = 305;
            float xNow = 55;

            LyricsEnd(383017, 387462, "DESIGNERS", FontBold, 0.20f, xNow, yBold-15);
            LyricsEnd(383017, 387462, "TheFunk", Font, 0.18f, xNow, yBold + 30);
            LyricsEnd(383017, 387462, "[Zeth]", Font, 0.18f, xNow, yBold + 60);

            xNow+=170;
            LyricsEnd(383017, 387462, "MAPPERS", FontBold, 0.20f, xNow, yBold-15);
            LyricsEnd(383017, 387462, "JackTVN", Font, 0.18f, xNow, yBold + 30);
            LyricsEnd(383017, 387462, "davidminh0111", Font, 0.18f, xNow, yBold + 60);
            LyricsEnd(383017, 387462, "Creeperbrine303", Font, 0.18f, xNow, yBold + 90);
            LyricsEnd(383017, 387462, "Kurumiism", Font, 0.18f, xNow, yBold + 120);
            LyricsEnd(383017, 387462, "buttermiilk", Font, 0.18f, xNow, yBold + 150);

            xNow+=170;
            LyricsEnd(383017, 387462, "COMPOSER", FontBold, 0.20f, xNow, yBold-15);
            LyricsEnd(383017, 387462, "Altermis", Font, 0.18f, xNow, yBold + 30);

            xNow+=170;
            LyricsEnd(383017, 387462, "STORYBOARDER", FontBold, 0.20f, xNow, yBold-15);
            LyricsEnd(383017, 387462, "Ectomic", Font, 0.18f, xNow, yBold + 30);
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

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, float LetterY = 254+(480-254)/2, bool keepEnd = false)
        {
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
                    string layer = "IntroText";
                    int midTime = startTime + 600;
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.MoveX(OsbEasing.OutSine, startTime, midTime, 320, position.X);
                        sprite.Fade(startTime, startTime+600, 0, 1);
                        if(!keepEnd)
                        {
                            sprite.Fade(startTime+600, endTime-100, 1, 1);
                            sprite.MoveX(OsbEasing.InSine, endTime-300, endTime, position.X, 320);
                            sprite.Fade(endTime-100, endTime, 1, 0);
                        }
                        else
                        {
                            sprite.Fade(startTime+600, endTime, 1, 1);
                        }
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }

        public void LyricsEnd(int startTime, int endTime, string text, FontGenerator font, float scale, float LetterX, float LetterY)
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
                    string layer = "IntroText";
                    int midTime = startTime + 600;
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.MoveX(OsbEasing.OutSine, startTime, midTime, 320, position.X);
                        sprite.Fade(startTime, startTime+600, 0, 1);
                        sprite.Fade(startTime+600, endTime-100, 1, 1);
                        sprite.MoveX(OsbEasing.InSine, endTime-300, endTime, position.X, 320);
                        sprite.Fade(endTime-100, endTime, 1, 0);
                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }

        public void pulse(int startTime, int midTime)
        {   
            var pulse = GetLayer("Pulse").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            pulse.ScaleVec(startTime, 854, 480);
            pulse.Fade(startTime, midTime, 0, 0.3);
            pulse.Fade(midTime, midTime + 500, 0.4, 0);
            pulse.Additive(startTime);
        }

        public void mappers(FontGenerator font)
        {
            string[,] parts = {
                                    {"13006", "JackTVN"},
                                    {"23384", "davidminh0111"},
                                    {"44141", "Creeperbrine303"},
                                    {"64898", "Kurumiism"},
                                    {"107353", "davidminh0111"},
                                    {"135224", "Kurumiism"},
                                    {"159999", "davidminh0111"},
                                    {"183466", "JackTVN"},
                                    {"243466", "davidminh0111"},
                                    {"281524", "buttermiilk"},
                                    {"325160", "Creeperbrine303"},
                                    {"345240", "davidminh0111"},
                                    {"383017", ""}
                            };

            int yOffset = 30;
            int xCenter = 310;

            var pfpBitmap = GetMapsetBitmap("sb/profiles/JackTVN.jpg");
                var pfpScale = 55.0f / pfpBitmap.Width;
                float pfpY = 70 + yOffset;

            var bar = GetLayer("Info").CreateSprite("sb/particles/gradbar.png", OsbOrigin.Centre, new Vector2(xCenter, pfpY));
                bar.Fade(13006, 383017, 1, 1);
                bar.ScaleVec(OsbEasing.OutSine, 13006, 13006+600, 0.03, 0, 0.03, 0.05);
                bar.ScaleVec(OsbEasing.OutSine, 383017-300, 383017, 0.03, 0.05, 0.03, 0);

            for(int i=0; i<(parts.Length/2)-1; i++)
            {   
                int startTime = Convert.ToInt32(parts[i,0]);
                int endTime = Convert.ToInt32(parts[i+1, 0]);

                var pfp = GetLayer("Info").CreateSprite("sb/profiles/" + parts[i,1] + ".jpg", OsbOrigin.Centre, new Vector2(xCenter - 40, pfpY));
                    pfp.Fade(OsbEasing.OutSine, startTime, startTime+600, 0, 1);
                    pfp.Fade(startTime+600, endTime-300, 1, 1);
                    pfp.Fade(OsbEasing.OutSine, endTime-300, endTime, 1, 0);
                    pfp.Scale(startTime, pfpScale);

                float scale = 0.25f;
                float LetterY = 55 + yOffset;
                float LetterX = xCenter + 11;
                
                foreach(var letter in parts[i, 1])
                {
                    var texture = font.GetTexture(letter.ToString());
                    if(!texture.IsEmpty)
                    {
                        var position = new Vector2(LetterX, LetterY)
                            + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                        string layer = "Info";
                        var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.MoveX(OsbEasing.OutSine, startTime, startTime+600, xCenter + 11, position.X);
                            sprite.Fade(startTime, startTime+600, 0, 1);
                            sprite.Fade(startTime+600, endTime-100, 1, 1);
                            sprite.MoveX(OsbEasing.InSine, endTime-300, endTime, position.X, xCenter + 11);
                            sprite.Fade(endTime-100, endTime, 1, 0);
                            sprite.Scale(startTime, scale);
                            sprite.Color(startTime, new Color4(246,241,238,1));
                    }
                    LetterX += texture.BaseWidth * scale;
                }
            }
        }

        public void bpm(FontGenerator font)
        {
            int[,] bpms = {
                                {13006, 185},

                                {97330, 180},
                                {98663, 175},
                                {100033, 170},
                                {101445, 165},
                                {104353, 160},
                                {107353, 155},

                                {173934, 160},
                                {175434, 165},
                                {176888, 170},
                                {178298, 175},
                                {179669, 180},
                                {181003, 190},
                                {182266, 200},

                                {274665, 205},
                                {277006, 210},
                                {279291, 215},
                                {281523, 220},

                                {325160, 256},
                                {329847, 246},
                                {334725, 236},
                                {339808, 226},
                                {342463, 216},
                                {383017, 0}
                            };

            int yOffset = 30;

            for(int i=0; i<(bpms.Length/2)-1; i++)
            {   
                int xCenter = 310;
                float scale = 0.20f;
                float LetterY = 85 + yOffset;
                float LetterX = xCenter + 11;

                int startTime = bpms[i,0];
                int endTime = bpms[i+1, 0];

                foreach(var letter in bpms[i, 1].ToString() + " BPM")
                {
                    var texture = font.GetTexture(letter.ToString());
                    if(!texture.IsEmpty)
                    {
                        var position = new Vector2(LetterX, LetterY)
                            + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                        string layer = "Info";
                        var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Scale(startTime, scale);
                            sprite.Color(startTime, new Color4(246,241,238,1));
                            if(startTime == 13006)
                            {
                                sprite.MoveX(OsbEasing.OutSine, startTime, startTime+600, xCenter + 11, position.X);
                                sprite.Fade(startTime, startTime+600, 0, 1);
                                sprite.Fade(startTime+600, endTime, 1, 1);
                            }
                            else if (startTime == 342463)
                            {
                                sprite.Fade(startTime, endTime-300, 1, 1);
                                sprite.MoveX(OsbEasing.OutSine, endTime-300, endTime, position.X, xCenter + 11);
                                sprite.Fade(endTime-300, endTime, 1, 0);
                            }
                            else
                            {
                                sprite.Fade(startTime, endTime, 1, 1);
                            }
                    }
                    LetterX += texture.BaseWidth * scale;
                }
            }   
        }
    }
}
