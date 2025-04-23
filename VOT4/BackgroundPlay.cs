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
    public class BackgroundPlay : StoryboardObjectGenerator
    {   
        Color4 Blue = new Color4(18, 51, 112, 1);

        Color4 Black = new Color4(12, 12, 12, 1);

        Color4 Gray = new Color4(48, 48, 48, 1);

        int midScreen = 254+(480-254)/2;

        public override void Generate()
        {
            int beat = 23709 - 23384;
            
            var bgBitmap = GetMapsetBitmap("sb/blur.png");
            var bgScale = (854.0f / bgBitmap.Width)*1.05;
            int bgYCenter = (480/2);

		    var blurGray = GetLayer("Background").CreateSprite("sb/blurgray.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                blurGray.Scale(85655, bgScale);

                blurGray.Fade(85655, 0);

            var blur = GetLayer("Background").CreateSprite("sb/blur.png", OsbOrigin.Centre, new Vector2(320, bgYCenter));
                blur.Scale(23384, bgScale);

                blur.Fade(OsbEasing.InSine, 23384, 23709, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 28573, 28898, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 33763, 34087, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 36357, 36682, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 38952, 39276, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 40249, 40573, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 41546, 41871, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 42195, 42519, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 42844, 43168, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 85655, 85979, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 88249, 88573, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 90844, 91168, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 93438, 93763, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 96033, 96357, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 97330, 97663, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 98663, 99005, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 100033, 100386, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 101444, 101808, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 102172, 102535, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 102899, 103263, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 103626, 103990, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 104353, 104635, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 104728, 105010, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 105103, 105385, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 105478, 105760, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 105853, 106228, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 205065, 205365, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 207466, 207766, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 209865, 210166, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 212266, 212565, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 214666, 214966, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 217065, 217365, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 219466, 219766, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 221865, 222166, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 262665, 262966, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 267466, 267765, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 272265, 272566, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 274665, 274958, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 277006, 277292, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 278149, 278435, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 279291, 279571, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 279850, 280129, 0.3, 0.0);
                blur.Fade(OsbEasing.InSine, 280408, 280687, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 213466, 213766, 0.3, 0.0);

                blur.Fade(OsbEasing.InSine, 329847, 330090, 0.3, 0.0);

            var uniBG = GetLayer("Background2").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                uniBG.ScaleVec(23384, 854.0f, 480.0f);
                uniBG.Additive(23384);
                uniBG.Color(23384, Black);
                uniBG.Fade(23384, 1);
                uniBG.Fade(44141, 0);
                uniBG.Fade(85655, 1);
                uniBG.Fade(107353, 110450, 1, 0);
                uniBG.Fade(183466, 1);
                uniBG.Fade(224266, 0);

                uniBG.Fade(325160, 1);
                uniBG.Fade(345240, 0);

                uniBG.Fade(262665, 1);
                uniBG.Fade(281524, 0);

                uniBG.Fade(110450, 1);
                uniBG.Fade(132128, 135224, 1, 0);

            var gray = GetLayer("Background").CreateSprite("sb/graybg.png");
                gray.Scale(44141, bgScale);

                gray.Fade(44141, 1);
                gray.Fade(64898, 0);

                gray.Fade(345240, 1); 
                gray.Fade(347462, 0); 
                gray.Fade(365239, 1);
                gray.Fade(367462, 0);

                gray.Fade(281524, 1);
                gray.Fade(290251, 0);

                gray.Fade(224266, 1);
                gray.Fade(243466, 0);

                gray.Fade(159999, 1);
                gray.Fade(183466, 0);

                gray.Fade(107353, 110450, 1, 0);

                revolve(44141, 383017, gray, 0, 64, 320, 240, 0, 10);

            var full = GetLayer("Background").CreateSprite(Beatmap.BackgroundPath);
                full.Scale(44141, bgScale);
                full.Additive(44141);

                full.Fade(44141, 0);
                full.Fade(64898, 1); full.Fade(85655, 0);
                full.Fade(325160, 0);
                full.Fade(347462, 1);
                full.Fade(365239, 0);
                full.Fade(367462, 1);
                full.Fade(383017, 0);
                full.Fade(135224, 1);
                full.Fade(159999, 0);
                full.Fade(243466, 1);
                full.Fade(262665, 0);
                full.Fade(290251, 1);

                revolve(44141, 383017, full, 0, 64, 320, 240, 0, 10);

                full.Fade(OsbEasing.InSine, 44141, 44465, 0.5, 0);
                full.Fade(OsbEasing.InSine, 49330, 49655, 0.5, 0);
                full.Fade(OsbEasing.InSine, 53222, 53546, 0.5, 0);
                full.Fade(OsbEasing.InSine, 53709, 53871, 0.5, 0);
                full.Fade(OsbEasing.InSine, 53871, 54114, 0.5, 0);
                full.Fade(OsbEasing.InSine, 54114, 54357, 0.5, 0);
                full.Fade(OsbEasing.InSine, 54357, 54519, 0.5, 0);
                full.Fade(OsbEasing.InSine, 54519, 54844, 0.5, 0);
                full.Fade(OsbEasing.InSine, 59709, 60033, 0.5, 0);
                full.Fade(OsbEasing.InSine, 61006, 61330, 0.5, 0);
                full.Fade(OsbEasing.InSine, 62303, 62627, 0.5, 0);
                full.Fade(OsbEasing.InSine, 62952, 63276, 0.5, 0);

                full.Fade(OsbEasing.InSine, 159999, 160386, 0.5, 0);
                full.Fade(OsbEasing.InSine, 163095, 163483, 0.5, 0);
                full.Fade(OsbEasing.InSine, 166192, 166579, 0.5, 0);
                full.Fade(OsbEasing.InSine, 169289, 169676, 0.5, 0);

                full.Fade(OsbEasing.InSine, 172386, 172773, 0.5, 0);
                full.Fade(OsbEasing.InSine, 173934, 174309, 0.5, 0);
                full.Fade(OsbEasing.InSine, 175434, 175797, 0.5, 0);
                full.Fade(OsbEasing.InSine, 176888, 177240, 0.5, 0);
                full.Fade(OsbEasing.InSine, 178298, 178641, 0.5, 0);
                full.Fade(OsbEasing.InSine, 179669, 180003, 0.5, 0);
                full.Fade(OsbEasing.InSine, 181003, 181318, 0.5, 0);
                full.Fade(OsbEasing.InSine, 182266, 182565, 0.5, 0);

                full.Fade(OsbEasing.InSine, 233865, 234166, 0.5, 0);
                full.Fade(OsbEasing.InSine, 236266, 236565, 0.5, 0);
                full.Fade(OsbEasing.InSine, 238666, 238966, 0.5, 0);
                full.Fade(OsbEasing.InSine, 239865, 240166, 0.5, 0);
                full.Fade(OsbEasing.InSine, 241065, 241365, 0.5, 0);
                full.Fade(OsbEasing.InSine, 241666, 241966, 0.5, 0);
                full.Fade(OsbEasing.InSine, 242266, 242565, 0.5, 0);

                full.StartLoopGroup(64898, 64);
                    full.Scale(OsbEasing.InSine, 0, (85655 - 64898)/64f, bgScale*1.01, bgScale);
                full.EndGroup();

                full.StartLoopGroup(135224, 64);
                    full.Scale(OsbEasing.InSine, 0, (159999 - 135224)/64f, bgScale*1.01, bgScale);
                full.EndGroup();

                full.StartLoopGroup(243466, 64);
                    full.Scale(OsbEasing.InSine, 0, (262665 - 243466)/64f, bgScale*1.01, bgScale);
                full.EndGroup();

                full.StartLoopGroup(290251, 128);
                    full.Scale(OsbEasing.InSine, 0, (325160 - 290251)/128f, bgScale*1.01, bgScale);
                full.EndGroup();

                full.StartLoopGroup(347462, 128);
                    full.Scale(OsbEasing.InSine, 0, (383017 - 347462)/128f, bgScale*1.01, bgScale);
                full.EndGroup();


            var noiseBitmap = GetMapsetBitmap("sb/noise/noise0.jpg");
            var noise = GetLayer("Noise").CreateAnimation("sb/noise/noise.jpg", 4, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 240));
                noise.Scale(0, 854.0f / noiseBitmap.Width);
                noise.Fade(0, 2628, 0, 0.3); 
                noise.Fade(2628, 23384, 0.1, 0.1);
                noise.Fade(23384, 0);
                noise.Fade(383017, 0.3);
                noise.Fade(OsbEasing.InSine, 387184, 387462, 0.3, 0);

                noise.Fade(110450, 0.3);
                noise.Fade(132128, 135224, 0.3, 0);

                noise.Fade(183466, 0.3);
                noise.Fade(185865, 0);





            var grayBanner = GetLayer("Background").CreateSprite("sb/graybanner.png", OsbOrigin.TopCentre, new Vector2(320,0));
                grayBanner.Scale(44141, bgScale);

                grayBanner.Fade(44141, 1);
                grayBanner.Fade(64898, 0);

                grayBanner.Fade(345240, 1); 
                grayBanner.Fade(347462, 0); 
                grayBanner.Fade(365239, 1);
                grayBanner.Fade(367462, 0);

                grayBanner.Fade(281524, 1);
                grayBanner.Fade(290251, 0);

                grayBanner.Fade(224266, 1);
                grayBanner.Fade(243466, 0);

                grayBanner.Fade(159999, 1);
                grayBanner.Fade(183466, 0);

                grayBanner.Fade(107353, 110450, 1, 0);

                revolve(44141, 383017, grayBanner, 0, 64, 320, -10, 0, 10);

            var Banner = GetLayer("Background").CreateSprite("sb/banner.png", OsbOrigin.TopCentre, new Vector2(320,0));
                Banner.Scale(44141, bgScale);
                Banner.Fade(44141, 0);
                Banner.Fade(64898, 1); Banner.Fade(85655, 0);
                Banner.Fade(325160, 0);
                Banner.Fade(347462, 1);
                Banner.Fade(365239, 0);
                Banner.Fade(367462, 1);
                Banner.Fade(383017, 0);
                Banner.Fade(135224, 1);
                Banner.Fade(159999, 0);
                Banner.Fade(243466, 1);
                Banner.Fade(262665, 0);
                Banner.Fade(290251, 1);

                revolve(44141, 383017, Banner, 0, 64, 320, -10, 0, 10);

                Banner.Fade(OsbEasing.InSine, 44141, 44465, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 49330, 49655, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 53222, 53546, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 53709, 53871, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 53871, 54114, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 54114, 54357, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 54357, 54519, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 54519, 54844, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 59709, 60033, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 61006, 61330, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 62303, 62627, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 62952, 63276, 0.5, 0);

                Banner.Fade(OsbEasing.InSine, 159999, 160386, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 163095, 163483, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 166192, 166579, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 169289, 169676, 0.5, 0);

                Banner.Fade(OsbEasing.InSine, 172386, 172773, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 173934, 174309, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 175434, 175797, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 176888, 177240, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 178298, 178641, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 179669, 180003, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 181003, 181318, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 182266, 182565, 0.5, 0);

                Banner.Fade(OsbEasing.InSine, 233865, 234166, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 236266, 236565, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 238666, 238966, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 239865, 240166, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 241065, 241365, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 241666, 241966, 0.5, 0);
                Banner.Fade(OsbEasing.InSine, 242266, 242565, 0.5, 0);

                Banner.StartLoopGroup(64898, 64);
                    Banner.Scale(OsbEasing.InSine, 0, (85655 - 64898)/64f, bgScale*1.01, bgScale);
                Banner.EndGroup();

                Banner.StartLoopGroup(135224, 64);
                    Banner.Scale(OsbEasing.InSine, 0, (159999 - 135224)/64f, bgScale*1.01, bgScale);
                Banner.EndGroup();

                Banner.StartLoopGroup(243466, 64);
                    Banner.Scale(OsbEasing.InSine, 0, (262665 - 243466)/64f, bgScale*1.01, bgScale);
                Banner.EndGroup();

                Banner.StartLoopGroup(290251, 128);
                    Banner.Scale(OsbEasing.InSine, 0, (325160 - 290251)/128f, bgScale*1.01, bgScale);
                Banner.EndGroup();

                Banner.StartLoopGroup(347462, 128);
                    Banner.Scale(OsbEasing.InSine, 0, (383017 - 347462)/128f, bgScale*1.01, bgScale);
                Banner.EndGroup();

                pulse(49330, 49655);
                pulse(53222, 53546);
                pulse(53709, 53871);
                pulse(53871, 54114);
                pulse(54114, 54357);
                pulse(54357, 54519);
                pulse(54519, 54844);
                pulse(59709, 60033);
                pulse(61006, 61330);
                pulse(62303, 62627);
                pulse(62952, 63276);

                pulse(70087, 70411);
                pulse(75276, 75600);
                pulse(77871, 78195);
                pulse(80465, 80790);
                pulse(81763, 82087);
                pulse(83060, 83384);
                pulse(83709, 84033);
                pulse(84357, 84682);

                pulse(141418, 141805);
                pulse(147612, 147999);
                pulse(150708, 151095);
                pulse(153805, 154192);
                pulse(155354, 155741);
                pulse(156902, 157289);
                pulse(157676, 158063);
                pulse(158450, 158837);

                pulse(233865, 234166);
                pulse(236266, 236565);
                pulse(238666, 238966);
                pulse(239865, 240166);
                pulse(241065, 241365);
                pulse(241666, 241966);
                pulse(242266, 242565);

                pulse(248266, 248565);
                pulse(253065, 253365);
                pulse(255466, 255766);
                pulse(257865, 258165);
                pulse(259066, 259365);
                pulse(260265, 260566);
                pulse(260865, 261165);
                pulse(261466, 261765);

                pulse(294614, 294887);
                pulse(298978, 299251);
                pulse(301160, 301433);
                pulse(303342, 303614);
                pulse(304433, 304705);
                pulse(305523, 305796);
                pulse(306069, 306342);
                pulse(306614, 306887);

                pulse(312069, 312342);
                pulse(316433, 316705);
                pulse(318614, 318887);
                pulse(320796, 321069);
                pulse(321887, 322160);
                pulse(322978, 323251);
                pulse(323523, 323796);
                pulse(324069, 324342);

                pulse(351906, 352184);
                pulse(356351, 356628);
                pulse(358573, 358851);
                pulse(360795, 361073);
                pulse(361906, 362184);
                pulse(363017, 363295);
                pulse(363573, 363851);
                pulse(364128, 364406);

                pulse(369684, 369962);
                pulse(374128, 374406);
                pulse(376351, 376628);
                pulse(378573, 378851);
                pulse(379684, 379962);
                pulse(380795, 381073);
                pulse(381351, 381628);
                pulse(381906, 382184);

                pulse(163095, 163483);
                pulse(166192, 166579);
                pulse(169289, 169676);

                pulse(172386, 172773);
                pulse(173934, 174309);
                pulse(175434, 175797);
                pulse(176888, 177240);
                pulse(178298, 178641);
                pulse(179669, 180003);
                pulse(181003, 181318);
                pulse(182266, 182565);

                

            tactical(159999, 171612, 161547 - 159999);
            tactical(172386, 173547, 173160 - 172386);
            tactical(173934, 175059, 174684 - 173934);
            tactical(175434, 176524, 176161 - 175434);

            tactical(176888, 177946, 177593 - 176888);
            tactical(178299, 179327, 178984 - 178299);
            tactical(179669, 180669, 180336 - 179669);
            tactical(181003, 182266, 181634 - 181003);
            

            tactical(44141, 52898, 44465 - 44141);
            tactical(54519, 59384, (44465 - 44141)*2);
            tactical(59709, 63600, 44465 - 44141);

            tactical(224266, 233565, (224565 - 224266)*2);
            tactical(233865, 242266, (224565 - 224266));

            tactical(281523, 290251, (281796 - 281523));
            tactical(345239, 347462, (345795 - 345239));
            
            ripples(64898, 85006, (85655-64898)/32);
            ripples(135224, 159224, (159999-135224)/64);
            ripples(243466, 262066, (262665-243466)/32);
            ripples(290251, 324614, (325160-290251)/64);
            ripples(347462, 382462, (383017-347462)/64);
        }

        public void ripples(int startTime, int endTime, int beat)
        {      
            for(int i=startTime; i<endTime; i+=beat)
            {
                int time = i;
                int randX = Random(-107, 747); int randY = Random(254, 480);

                var ripple = GetLayer("RipplesKiai").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(randX, randY));
                    ripple.Fade(time, time+800, 0.7, 0.7);
                    ripple.Scale(OsbEasing.OutSine, time, time + 800, 0.08, 0.30);
                    ripple.Color(time, 20/255f, 52/255f, 115/255f);

                var rippleIn = GetLayer("RipplesKiai").CreateSprite("sb/geometry/circle.png", OsbOrigin.Centre, new Vector2(randX, randY));
                    rippleIn.Fade(time, time+800, 1, 1);
                    rippleIn.Scale(OsbEasing.OutSine, time, time+800, 0.075, 0.30);
                    rippleIn.Color(time, Color4.Black);
            }           
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

                //sprite.MoveX(Easings[m%2], startTime, endTime, XValues[m], XValues[n]);
                sprite.MoveY(Easings[n%2], startTime, endTime, YValues[m], YValues[n]);

                startTime = endTime;
            }
        }

        public long mod(long a, long b) 
        {
            return (a % b + b) % b;
        }

        public void pulse(int startTime, int endTime)
        {
            var pulseBitmap = GetMapsetBitmap("sb/masks/pulse.png");
            var pulse = GetLayer("Pulse").CreateSprite("sb/masks/pulse.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            pulse.Scale(startTime, 854f / pulseBitmap.Width);
            pulse.Fade(startTime, endTime, 0.3, 0);
        }

        public void tactical(int startTime, int endTime, int beat)
        {
            double scaleX = 0.004; double scaleY = 0.5;
            for(int time=startTime; time<endTime; time+=beat)
            {
                var bar = GetLayer("BottomObjects").CreateSprite("sb/geometry/white.png", OsbOrigin.Centre, new Vector2(Random(320-300, 320+300), 240));
                bar.ScaleVec(time, time + beat, scaleX, scaleY, 0, scaleY);
                bar.Rotate(OsbEasing.InSine, time, time + beat, 0, MathHelper.DegreesToRadians(Random(-5, 5)));
                bar.Fade(time, time + beat, 0.8, 0.4);
            }
        }
    }
}
