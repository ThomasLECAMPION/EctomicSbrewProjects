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
    public class Storyboard : StoryboardObjectGenerator
    {
        int beat = 2420 - 2149;

        Color4 colorBlack = new Color4(24, 24, 24, 1);

        FontGenerator FontCollab;

        FontGenerator FontCredit;

        FontGenerator FontCreditBold;

        FontGenerator FontCreditItalic;
        
        public override void Generate()
        {
		    var playfield = GetLayer("TaikoTop").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
            playfield.ScaleVec(0, 854.0f, 114.0f);
            playfield.Color(0, colorBlack);
            playfield.Fade(0, 445111, 1, 1);

            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = 854.0f / bgBitmap.Width;
            int bgYCenter = 35 + (480/2);

		    var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, bgYCenter));
                //bg.Fade(4311, 21609, 0, 0.6); 
                bg.Fade(21609, 1); bg.Fade(237544, 0.8); bg.Fade(246192, 0); bg.Fade(263489, 1);
                bg.Fade(OsbEasing.OutExpo, 408489, 417003, 1, 0.1);
                bg.Fade(417003, 445111, 0.1, 0.1);
                bg.Scale(21339, bgScale);
                bg.Fade(245652, 0); bg.Fade(245719, 0.8); bg.Fade(245787, 0); bg.Fade(245854, 0.8); bg.Fade(245922, 0); bg.Fade(245989, 0.8); bg.Fade(246057, 0); bg.Fade(246125, 0.8); bg.Fade(246192, 0);
                bg.Fade(263219, 0.8); bg.Fade(263287, 0); bg.Fade(263354, 0.8); bg.Fade(263422, 0); bg.Fade(263489, 0.8);
                bg.Fade(216803, 0); bg.Fade(219766, 1); bg.Fade(222729, 0); bg.Fade(225692, 1);
                bg.Fade(367273, 370516, 0, 1);
                revolve(21609, 408354, bg, 0, 32, 320, bgYCenter, 0, 5);
                bg.Fade(21339, 0.6); bg.Fade(21406, 0);bg.Fade(21474, 0.6); bg.Fade(21541, 0);
                bg.Fade(166474, 174582, 1, 0); bg.Fade(175322, 1);
                bg.Fade(352138, 0); bg.Fade(354300, 1); bg.Fade(357544, 0); bg.Fade(358895, 1);

            var grayBG = GetLayer("BackgroundNight").CreateSprite("sb/gray.jpg", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                grayBG.Fade(4311, 21609, 0, 0.6); grayBG.Fade(21609, 0); grayBG.Fade(166474, 1); grayBG.Fade(175322, 0);
                grayBG.Fade(216803, 1); grayBG.Fade(219766, 0); grayBG.Fade(222729, 1); grayBG.Fade(225692, 0); grayBG.Fade(367273, 1); grayBG.Fade(370516, 0);
                grayBG.Fade(352138, 1); grayBG.Fade(354300, 0); grayBG.Fade(357544, 1); grayBG.Fade(358895, 0); 
                grayBG.Scale(4311, bgScale);
            var bannerGray = GetLayer("BannerNight").CreateSprite("sb/banner_gray.jpg", OsbOrigin.TopCentre, new Vector2(320, 0));
                bannerGray.Fade(4311, 21609, 0, 0.6); bannerGray.Fade(21609, 0); bannerGray.Fade(166474, 1); bannerGray.Fade(175322, 0);
                bannerGray.Fade(216803, 1); bannerGray.Fade(219766, 0); bannerGray.Fade(222729, 1); bannerGray.Fade(225692, 0); bannerGray.Fade(367273, 1); bannerGray.Fade(370516, 0);
                bannerGray.Scale(216803, bgScale);
                bannerGray.Fade(352138, 1); bannerGray.Fade(354300, 0); bannerGray.Fade(357544, 1); bannerGray.Fade(358895, 0); 
                revolve(21609, 408354, grayBG, 0, 32, 320, bgYCenter, 0, 5);
                
                
            var banner = GetLayer("Banner").CreateSprite("sb/banner.jpg", OsbOrigin.TopCentre, new Vector2(320, 0));
                //banner.Fade(4311, 21609, 0, 0.6); 
                banner.Fade(21609, 1); banner.Fade(237544, 0.8); banner.Fade(246192, 0); banner.Fade(263489, 1);
                banner.Fade(OsbEasing.OutExpo, 408489, 417003, 1, 0.1);
                banner.Fade(417003, 445111, 0.1, 0.1);
                banner.Scale(21339, bgScale);
                banner.Fade(245652, 0); banner.Fade(245719, 0.8); banner.Fade(245787, 0); banner.Fade(245854, 0.8); banner.Fade(245922, 0); banner.Fade(245989, 0.8); banner.Fade(246057, 0); banner.Fade(246125, 0.8); banner.Fade(246192, 0);
                banner.Fade(263219, 0.8); banner.Fade(263287, 0); banner.Fade(263354, 0.8); banner.Fade(263422, 0); banner.Fade(263489, 0.8);
                banner.Fade(216803, 0); banner.Fade(219766, 1); banner.Fade(222729, 0); banner.Fade(225692, 1);
                banner.Fade(367273, 370516, 0, 1);
                banner.Fade(21339, 0.6); banner.Fade(21406, 0); banner.Fade(21474, 0.6); banner.Fade(21541, 0);
                banner.Fade(166474, 174582, 1, 0); banner.Fade(175322, 1);
                banner.Fade(352138, 0); banner.Fade(354300, 1); banner.Fade(357544, 0); banner.Fade(358895, 1);

            var nightBG = GetLayer("BackgroundNight").CreateSprite("sb/night.jpg", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                nightBG.Fade(245652, 1); nightBG.Fade(263489, 0);
                nightBG.Scale(245652, bgScale);
                rain(245111, 265652, Color4.White);
            var bannerNight = GetLayer("BannerNight").CreateSprite("sb/banner_night.jpg", OsbOrigin.TopCentre, new Vector2(320, 0));
                bannerNight.Fade(245652, 1); bannerNight.Fade(263489, 0);
                bannerNight.Scale(245652, bgScale);

            particlesUpward(213840, 230136, 350);

            FontCollab = SetFont("Collab", "TokyoGeishaDEMO-Regular.otf");
            FontCredit = SetFont("Credits", "Poppins-ExtraLight.ttf");
            FontCreditBold = SetFont("CreditsBold", "Poppins-Medium.ttf");
            FontCreditItalic = SetFont("CreditsItalic", "Poppins-ExtraLightItalic.ttf");

            GetLayer("Audio").CreateSample("sb/rainsound.ogg", 246192, 80);

            //collab names
            Lyrics(21609, 43230, "Briesmas", FontCollab, false);
            Lyrics(43230, 69176, "Chupalika", FontCollab, false);
            Lyrics(69176, 90798, "Rycy", FontCollab, false);
            Lyrics(90798, 114582, "Nozdormu", FontCollab, false);
            Lyrics(114582, 131879, "Maimaing", FontCollab, false);
            Lyrics(131879, 149176, "Eltigant", FontCollab, false);
            Lyrics(149176, 175322, "ndrrr", FontCollab, false);
            Lyrics(175322, 213840, "WTHBRO", FontCollab, false);
            Lyrics(213840, 237544, "Eriha", FontCollab, false);

            Lyrics(263489, 298084, "Alwaysyukaz", FontCollab, false);
            Lyrics(298084, 315381, "BlackBN", FontCollab, false);
            Lyrics(315381, 332949, "ler1211", FontCollab, false);
            Lyrics(332949, 349976, "Haypzeh", FontCollab, false);
            Lyrics(349976, 367273, "JarvisGaming", FontCollab, false);
            Lyrics(367273, 380246, "hexe", FontCollab, false);
            Lyrics(380246, 399706, "SolaEclipse", FontCollab, false);
            Lyrics(399706, 408354, "Haypzeh", FontCollab, false);

            var mask = GetLayer("mask").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                mask.ScaleVec(0, 854f, 140f);
                mask.Fade(0,445111, 1, 1);
                mask.Color(0, Color4.Black);

            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(4311, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Fade(4311, 21609, 0, 0.8); vignette.Fade(445111, 0);
                vignette.Color(4311, colorBlack);

            //flash
            float length = 3.0f;

            pulse3(21609, length);
            pulse3(43230, length);
            pulse3(69176, length);
            pulse3(90798, length);
            pulse3(114582, length);
            pulse3(131879, length);
            pulse3(149176, length);
            pulse3(165393, length);
            pulse3(175322, length);
            pulse3(213840, length);
            pulse3(237544, length);
            pulse3(263489, length);
            pulse3(298084, length);
            pulse3(315381, length);
            pulse3(332949, length);
            pulse3(349976);
            pulse3(367273, length);
            pulse3(380246, length);
            pulse3(399706, length);
            pulse3(408354, length);

            pulse3(216803, length);
            pulse3(219766, length);
            pulse3(222729, length);
            pulse3(225692, length);

            pulse3(370516, length);
            pulse3(375922, length);
            pulse3(123230, length);
            pulse3(140528, length);

            pulse3(37825, length);
            pulse3(38906, length);

            pulse3(51879, length);
            pulse3(54041, length);
            pulse3(56609, length);
            pulse3(56203, length);
            pulse3(60528, length);
            pulse3(63771, length);

            pulse3(73501);
            pulse3(75663);
            pulse3(77825);
            pulse3(79987);
            pulse3(82082);
            pulse3(84311);
            pulse3(86474);
            pulse3(88636);

            pulse3(95122);
            pulse3(96203);
            pulse3(97284, length);
            pulse3(101609, length);
            pulse3(105933, length);
            pulse3(110257, length);

            pulse3(118906, length);

            pulse3(180507);
            pulse3(181247);
            pulse3(182729);
            pulse3(183470);

            pulse3(187173, length);
            pulse3(190136, length);
            pulse3(193099);
            pulse3(196062, length);
            pulse3(199025);

            pulse3(200322);
            pulse3(200507);
            pulse3(201988);
            pulse3(201247);

            pulse3(204951);
            pulse3(207914);

            pulse3(209396);
            pulse3(208655);
            pulse3(210136);
            pulse3(210877);
            pulse3(212729);

            pulse3(211247);
            pulse3(211618);
            pulse3(211896);
            pulse3(212173);
            pulse3(212359);

            pulse3(185692);

            pulse3(136474);
            pulse3(144852);

            pulse3(153501, length);
            pulse3(157825, length);
            pulse3(162149, length);
            pulse3(163230, length);

            pulse3(164311);
            pulse3(164447);
            pulse3(164852);
            pulse3(164987);

            pulse3(297003, length);

            pulse3(305516);
            pulse3(305652, length);
            pulse3(308895, length);
            pulse3(311057, length);
            pulse3(311598, length);
            pulse3(312138, length);
            pulse3(312679, length);
            pulse3(313219, length);

            pulse3(319706);
            pulse3(324030);
            pulse3(328354);
            
            pulse3(330516);
            pulse3(331057);
            pulse3(331598, length);

            pulse3(337003);
            pulse3(342408);
            pulse3(342611);
            pulse3(342814);
            pulse3(343016);
            pulse3(343219);
            pulse3(345652, length);
            pulse3(346733, length);
            pulse3(348084);
            pulse3(348625);
            pulse3(348895, length);
            pulse3(350246, length);


            pulse3(341327);
            pulse3(343760);

            pulse3(352138);
            pulse3(354300, length);
            pulse3(356462);

            pulse3(357544);
            pulse3(358625);
            pulse3(358895, length);
            pulse3(358760);

            pulse3(362949, length);
            pulse3(364030, length);

            pulse3(353219);
            pulse3(353489);

            pulse3(374841, length);

            pulse3(371598, length);
            pulse3(372003);
            pulse3(372408);
            pulse3(372679, length);
            pulse3(373084);
            pulse3(373489);
            pulse3(373760);
            pulse3(374030);
            pulse3(374300);
            pulse3(374571);

            pulse3(378084);
            pulse3(378354);
            pulse3(378625);
            pulse3(378895);
            pulse3(379165, length);

            pulse3(382408, length);
            pulse3(384571, length);
            pulse3(386733, length);
            pulse3(388895, length);
            pulse3(391057, length);
            pulse3(393219, length);
            pulse3(395381, length);
            pulse3(397544, length);

            pulse3(400787);
            pulse3(401868);
            pulse3(402949);
            pulse3(404030);
            pulse3(405111);
            pulse3(406192);
            pulse3(406733);
            pulse3(407273, length);






            /* nice try
            pulse3(50798);
            pulse3(51203);
            pulse3(51474);
            pulse3(51879, length);
            pulse3(52960);
            pulse3(53366);
            pulse3(53771);
            pulse3(54041, length);
            pulse3(55122);
            pulse3(55528);
            pulse3(55933);
            pulse3(56203, length);
            pulse3(56609, length);
            pulse3(57284);
            pulse3(57825);

            pulse3(73501);
            pulse3(79987);
            pulse3(81609);
            pulse3(81811);
            pulse3(82014);
            pulse3(82149, length);
            */

            //credits
            using (var stream = OpenProjectFile("credits.txt"))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                int time = 411598; 
                string line;

                while (reader.Peek() >=0)
                {
                    line = reader.ReadLine();
                    FontGenerator font = FontCredit;

                    if(!string.IsNullOrWhiteSpace(line))
                    {
                        if(line[0] == '[')
                        {
                            line = line.Substring(1);
                            font = FontCreditBold;
                        }
                        else if(line.Contains("Thanks for playing !"))
                        {
                            font = FontCreditItalic;
                        }
                    }

                    Lyrics(time, time + 4500, line, font, true);

                    time+=286;
                }
            }
        }

        public FontGenerator SetFont(string folder, string fontPath, Color4? color = null)
        {
            //these line create a FontGenerator object that have the font parameters you want to be generated
            //this load the fontName, style, color, size etc etc... everything you see in the sb/f folder stuff is stored in that object
            var font = LoadFont("sb/font/" + folder, new FontDescription()
            {
                FontPath = fontPath,
                FontSize = 40,
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

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, bool credits)
        {
            float LetterY = 312;

            if(!credits)
            {
                var pfpBitmap = GetMapsetBitmap("sb/pfp/briesmas.png");
                var pfpScale = 55.0f / pfpBitmap.Width;
                float pfpY = 295;
                float loadY = 340;

                var pfp = GetLayer("pfp").CreateSprite("sb/pfp/" + text + ".png", OsbOrigin.Centre, new Vector2(107, pfpY));
                    pfp.Fade(startTime, endTime, 1, 1);
                    pfp.Scale(startTime, pfpScale);

                /*
                var pfpBox = GetLayer("pfp").CreateSprite("sb/geometry/square.png", OsbOrigin.Centre, new Vector2(110, pfpY));
                    pfpBox.Fade(startTime, endTime, 1, 1);
                    pfpBox.Scale(startTime, 0.132);
                */

                var load = GetLayer("pfp").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(80, loadY));
                    load.Fade(startTime, endTime, 1, 1);
                    load.ScaleVec(startTime, endTime, 2, 12, 225, 12);
                    load.Color(startTime, new Color4(249f/255, 252f/255, 101f/255, 1));

                var loadBox = GetLayer("pfp").CreateSprite("sb/geometry/loadbox.png", OsbOrigin.CentreLeft, new Vector2(79, loadY));
                    loadBox.Fade(startTime, endTime, 1, 1);
                    loadBox.Scale(startTime, 0.260);              
            }
            
            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float LetterX = 140;
            float scale = credits ? 0.3f : 0.4f;
            float lineWidth = 0;

            if(credits)
            {   
                LetterX = 320;
                //We center the line
                foreach(var letter in text)
                {   
                    var texture = font.GetTexture(letter.ToString());
                    lineWidth += texture.BaseWidth * scale;
                }
                LetterX -= lineWidth/2;
            }

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
                    string layer = credits ? "LyricsCredits" : "LyricsCollab";
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                    sprite.Fade(startTime, endTime, 1, 1);
                    sprite.Scale(startTime, scale);
                    if(credits)
                    {
                        sprite.MoveY(startTime, endTime, 500, 240);
                    }
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
            }
        }

        public void rain(int startTime, int endTime, Color4 color)
        {
            var quantity = 60;

            for (int i=0; i<quantity; i++)
            {
                var rain = GetLayer("Rain").CreateSprite("sb/particles/rain.png");

                var rainStartTime = Random(startTime, startTime + beat);

                var randX = Random(-107, 747); var randY = Random(140, 240); var randZ = Random(0.5f, 0.9f);
                var rainEndTime = 300 / randZ;

                double angle = -(Math.PI * 1.5);
                var radius = 500 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.ScaleVec(rainStartTime, randZ*1.2, randZ>0.75 ? 50 : 25);
                rain.Color(rainStartTime, color);
                //rain.Rotate(rainStartTime, -MathHelper.DegreesToRadians(angle));
                rain.Fade(rainStartTime, 0.1); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y);
                rain.EndGroup();
            }
        }

        public void pulse(int startTime)
        {   
            var pulse = GetLayer("Pulse").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            pulse.ScaleVec(startTime, 854, 480);
            pulse.Fade(startTime, startTime + beat, 0.2, 0);
        }

        public void pulse2(int startTime)
        {
            var pulseBitmap = GetMapsetBitmap("sb/masks/pulse2.png");
            var pulse = GetLayer("Pulse").CreateSprite("sb/masks/pulse2.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            pulse.Scale(startTime, 854f / pulseBitmap.Width);
            pulse.Fade(startTime, startTime + beat, 0.2, 0);
        }

        public void pulse3(int startTime, float length = 0.5f)
        {
            var pulseBitmap = GetMapsetBitmap("sb/masks/pulse.png");
            var pulse = GetLayer("Pulse").CreateSprite("sb/masks/pulse.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            pulse.Scale(startTime, 854f / pulseBitmap.Width);
            pulse.Fade(startTime, startTime + beat * length, 0.2, 0);
        }

        public void revolve(int StartTime, int EndTime, OsbSprite sprite, double startAngle, double endAngle, double centerX, double centerY, double radiusX, double radiusY)
        {   
            // Change from angles in a clock to angles in a unit circle;
            startAngle = 0.5 - startAngle;
            endAngle   = 0.5 - endAngle;

		    // Start and end angles to be used in moving animation; In terms of pi/2
            long RevStart = (long) Math.Floor(startAngle * 2);
            long RevEnd   = (long) Math.Floor(endAngle * 2);

            // Revolutions per millisecond
            double rpms = (endAngle - startAngle) / (EndTime - StartTime);

            // Start and end times of the moving animation
            int RevStartTime;
            int RevEndTime;

            if ((startAngle * 2) % 1 == 0) // If start angle is on an axis
                RevStartTime = StartTime;
            else
            {
                if (startAngle > endAngle)
                    RevStart++;
                    
                RevStartTime = (int) (Math.Round(StartTime - (startAngle*2 - RevStart) / 2 / rpms));
            }

            if ((endAngle * 2) % 1 == 0) // If end angle is on an axis
                RevEndTime = EndTime;
            else
            {
                if (endAngle > startAngle)
                    RevEnd++;

                RevEndTime = (int) (Math.Round(EndTime - (endAngle*2 - RevEnd) / 2 / rpms));
            }

            // Constants
            double[] XValues = new double[] 
            {
                centerX + radiusX, // 0
                centerX,          // 1/2 pi
                centerX - radiusX, // pi
                centerX           // 3/2 pi
            };

            double[] YValues = new double[] 
            {
                centerY,          // 0
                centerY - radiusY, // 1/2 pi
                centerY,          // pi
                centerY + radiusY  // 3/2 pi
            };

            OsbEasing[] Easings = new OsbEasing[] 
            {
                OsbEasing.InSine,
                OsbEasing.OutSine
            };

            // Move animations
            long k = RevStart < RevEnd ? 1 : -1;
            
            int startTime = RevStartTime;
            int endTime;

            long j = Math.Abs(RevEnd - RevStart);
            for (long i = 0; i < j; i++) 
            {
                endTime = (int) (Math.Round((double) (RevStartTime * (j-i-1) + RevEndTime * (i+1)) / j));
                long m = mod(RevStart + i*k, 4);
                long n = mod(m + k, 4);

                sprite.MoveX(Easings[m%2], startTime, endTime, XValues[m], XValues[n]);
                sprite.MoveY(Easings[n%2], startTime, endTime, YValues[m], YValues[n]);

                startTime = endTime;
            }
        }

        public long mod(long a, long b) 
        {
            return (a % b + b) % b;
        }

        public void particlesUpward(int startTime, int endTime, int quantity)
        {
            for(int i = 0; i < quantity; i ++)
            {
                int randomX = Random(-100, 740);

                var p = GetLayer("Particles").CreateSprite("sb/particles/light.png");

                int durationStart = Random(startTime - 10000, (endTime+2500) - 10000 / 2);
                int durationEnd = durationStart + Random(4000 / 2, 6000 / 2);
                if(durationEnd > endTime)
                    durationEnd = 94349;
                
                if((int)(i % 10) == 0)
                    p.Scale(0, Random(0.3 / 1.5, 0.6 / 1.5));
                else
                    p.Scale(0, Random(0.05 / 1.5, 0.25 / 1.5));

                var perDuration = beat*8;
                p.MoveY(durationStart, durationEnd, 500, Random(254, 294));

                p.StartLoopGroup(durationStart, (durationEnd - durationStart) / perDuration);
                var dir = Random(5, 10);
                p.MoveX(OsbEasing.InOutSine, 0, perDuration/2, randomX, randomX + dir);
                p.MoveX(OsbEasing.InOutSine, perDuration/2, perDuration, randomX + dir, randomX);
                p.EndGroup();
                
                p.Fade(durationStart, durationStart + 1000, 0, 0.8);

                if(durationEnd >= endTime)
                    p.Fade(endTime, 0);
                else
                    p.Fade(durationEnd - 1000, durationEnd, 0.9, 0);
                
                p.Color(durationStart, Color4.White);
                p.Additive(durationStart, durationEnd);
            }
        }
    }
}
