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
    public class Storyboard : StoryboardObjectGenerator
    {   
        //storyboard dimension = 854, 480
        //pos centre = 320, 240
        //top section extends to Y = 140
        //mid section extends from Y = 140 to Y = 254
        //bottom section starts from Y = 254 | center is Y = 367

        int beat = 750 - 270;

        //Color palette
        Color4 colorBlack = new Color4(24, 24, 24, 1);

        Color4 colorLightA = new Color4(240, 147, 228, 1);
        Color4 colorDarkA = new Color4(139, 131, 251, 1);

        Color4 colorLightB = new Color4(227, 252, 148, 1);
        Color4 colorDarkB = new Color4(94, 220, 233, 1);

        Color4 colorLightC = new Color4(219, 227, 211, 1);
        Color4 colorDarkC = new Color4(147, 202, 108, 1);

        public override void Generate()
        {   
            introduction(0, 15630);
            calm(15630, 46349);
            kiai(46349, 77069);
            ending(77069, 92430);

            var top = GetLayer("Top").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 70));
                top.ScaleVec(0, 854, 140);
                top.Fade(0, 1);
                top.Fade(46349, 0);

                top.Color(0, colorBlack);
                top.Fade(77069, 1);
                top.Fade(92430, 94349, 1, 0);

            var vignetteBitmap = GetMapsetBitmap("sb/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));

            vignette.ScaleVec(0, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
            vignette.Fade(0, 1);
            vignette.Color(0, colorBlack);
            vignette.Fade(OsbEasing.InSine, 44430, 46349, 1, 0);
            vignette.Fade(77069, 92430, 0.5, 0.5);
            vignette.Color(77069, 1, 1, 1);

            //Playfield
            var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));

            playfield.ScaleVec(0, 854.0f, 254 - 140);
            playfield.Color(0, colorBlack);
            playfield.Fade(0, 1);
            playfield.Fade(92430, 94349, 1, 0);
        }   

        public void introduction(int startTime, int endTime)
        {   
            particlesPopUp(0, endTime, 1500);

            //First half
                var bg = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 367));
                    bg.ScaleVec(startTime, 854, 480-254);
                    bg.Fade(startTime, 7949, 1, 1);
                    bg.Color(startTime, colorBlack);

                var storyboardBy = GetLayer("Background").CreateAnimation("sb/sketches/storyboard.png", 3, 150, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 367));
                    storyboardBy.Scale(OsbEasing.InSine, 270, 1950 , 0.92, 1);
                    storyboardBy.Fade(270, 1950, 1, 1);

                var artist = GetLayer("Background").CreateAnimation("sb/sketches/artist.png", 3, 150, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 367));
                    artist.Scale(OsbEasing.InSine, 1950, 4110, 1, 0.9);
                    artist.Fade(1950, 4110, 1, 1);

                var title = GetLayer("Background").CreateAnimation("sb/sketches/title.png", 3, 150, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, 367));
                    title.Scale(4110, 7949, 0.9, 1);
                    title.Fade(OsbEasing.InSine, 4110, 7949, 1, 0);

            //Second half
                startTime = 7949;
                //characters
                    var chara0 = GetLayer("Background").CreateSprite("sb/gray/gray0.jpg", OsbOrigin.Centre, new Vector2(320 - 320*0.70f, 367));
                        chara0.Scale(7949, 0.45);
                        chara0.Fade(7949, 1);
                        revolve(7949, endTime, chara0, 0, 4, 320 - 320*0.70f, 367, 1, 3);
                        chara0.Fade(endTime, 0);

                    var chara1 = GetLayer("Background").CreateSprite("sb/gray/gray1.jpg", OsbOrigin.Centre, new Vector2(320, 367));
                        chara1.Scale(11789, 0.45);
                        chara1.Fade(11789, 1);
                        revolve(11789, endTime, chara1, 0, 1.75, 320, 367, 1, 3);
                        chara1.Fade(endTime, 0);

                    var chara2 = GetLayer("Background").CreateSprite("sb/gray/gray2.jpg", OsbOrigin.Centre, new Vector2(320 + 320*0.625f, 367));
                        chara2.Scale(9630, 0.45);
                        chara2.Fade(9630, 1);
                        revolve(9630, endTime, chara2, 0, 2.5, 320 + 320*0.625f, 367, 1, 3);
                        chara2.Fade(endTime, 0);

                //black curtains
                    var cinemaBar1 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                        cinemaBar1.ScaleVec(startTime, 854, 20);
                        cinemaBar1.Fade(startTime, endTime, 1, 1);
                        cinemaBar1.Color(startTime, colorBlack);

                    var cinemaBar2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
                        cinemaBar2.ScaleVec(startTime, 854, 20);
                        cinemaBar2.Fade(startTime, endTime, 1, 1);
                        cinemaBar2.Color(startTime, colorBlack);

                    var curtainLeft1 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 - 320/3, 367));
                        curtainLeft1.ScaleVec(startTime, 100, 230);
                        curtainLeft1.Rotate(startTime, MathHelper.DegreesToRadians(-15));
                        curtainLeft1.Fade(startTime, 13229, 1, 1);
                        curtainLeft1.Color(startTime, colorBlack);

                    var curtainLeft2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.CentreRight, new Vector2(320 - 157, 367));
                        curtainLeft2.ScaleVec(startTime, 400, 400);
                        curtainLeft2.Rotate(startTime, MathHelper.DegreesToRadians(-15));
                        curtainLeft2.Fade(startTime, endTime, 1, 1);
                        curtainLeft2.Color(startTime, colorBlack);

                    var curtainRight1 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 + 320/3, 367));
                        curtainRight1.ScaleVec(startTime, 100, 230);
                        curtainRight1.Rotate(startTime, MathHelper.DegreesToRadians(15));
                        curtainRight1.Fade(startTime, 13229, 1, 1);
                        curtainRight1.Color(startTime, colorBlack);

                    var curtainRight2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(320 + 157, 367));
                        curtainRight2.ScaleVec(startTime, 400, 400);
                        curtainRight2.Rotate(startTime, MathHelper.DegreesToRadians(15));
                        curtainRight2.Fade(startTime, endTime, 1, 1);
                        curtainRight2.Color(startTime, colorBlack);

                    var curtainMid1 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 - 3, 367));
                        curtainMid1.ScaleVec(startTime, 100, 230);
                        curtainMid1.Rotate(startTime, MathHelper.DegreesToRadians(-15));
                        curtainMid1.Fade(startTime, endTime, 1, 1);
                        curtainMid1.Color(startTime, colorBlack);

                    var curtainMid2 = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 + 3, 367));
                        curtainMid2.ScaleVec(startTime, 100, 230);
                        curtainMid2.Rotate(startTime, MathHelper.DegreesToRadians(15));
                        curtainMid2.Fade(startTime, endTime, 1, 1);
                        curtainMid2.Color(startTime, colorBlack);


                    curtainLeft2.MoveX(OsbEasing.OutSine, 7949, 9390, 320 - 157, 320 - 270);
                    curtainRight2.MoveX(OsbEasing.OutSine, 9630, 11069, 320 + 157, 320 + 270);
                    curtainMid1.MoveX(OsbEasing.OutSine, 11789, 13229, 320-3, 320 - 320/3);
                    curtainMid2.MoveX(OsbEasing.OutSine, 11789, 13229, 320+3, 320 + 320/3);
                
                //Transition
                var flash = GetLayer("Background").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                    flash.ScaleVec(15149, 854, 367);
                    flash.Fade(15149, endTime, 0, 0.9);
                    flash.Additive(15149, endTime);
        }

        public void calm(int startTime, int endTime)
        {   
            var cinemaBar1 = GetLayer("Cinema").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                cinemaBar1.ScaleVec(startTime, 16110, 854, 367 - 254, 854, 20);
                cinemaBar1.Fade(startTime, endTime, 1, 1);
                cinemaBar1.Color(startTime, colorBlack);
                cinemaBar1.ScaleVec(OsbEasing.InCubic, 29069, 30989, 854, 20, 854, 367 - 254);
                cinemaBar1.ScaleVec(30989, 31469, 854, 367 - 254, 854, 20);
                cinemaBar1.ScaleVec(OsbEasing.InCubic, 36750, 38669, 854, 20, 854, 367 - 254);
                cinemaBar1.ScaleVec(38669, 39150, 854, 367 - 254, 854, 20);
                cinemaBar1.ScaleVec(OsbEasing.InCubic, 44430, 46349, 854, 20, 854, 367 - 254);

            var cinemaBar2 = GetLayer("Cinema").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
                cinemaBar2.ScaleVec(startTime, 16110, 854, 367 - 254, 854, 20);
                cinemaBar2.Fade(startTime, endTime, 1, 1);
                cinemaBar2.Color(startTime, colorBlack);
                cinemaBar2.ScaleVec(OsbEasing.InCubic, 29069, 30989, 854, 20, 854, 367 - 254);
                cinemaBar2.ScaleVec(30989, 31469, 854, 367 - 254, 854, 20);
                cinemaBar2.ScaleVec(OsbEasing.InCubic, 36750, 38669, 854, 20, 854, 367 - 254);
                cinemaBar2.ScaleVec(38669, 39150, 854, 367 - 254, 854, 20);
                cinemaBar2.ScaleVec(OsbEasing.InCubic, 44430, 46349, 854, 20, 854, 367 - 254);

            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var scale = 854.0f / bgBitmap.Width;
            int bgCenter = 210 + (480/2);

		    var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, bgCenter));
                bg.Fade(startTime, 1);
                bg.Fade(endTime, 0);

                bg.Scale(startTime, scale*1.5);
                bg.Move(startTime, 23309, 400, bgCenter-340, 320, bgCenter-330);

                bg.Scale(23309, scale*5);
                bg.Move(23309, 30989, -1375, bgCenter+350, -1350, bgCenter+400);

                bg.Scale(30989, scale*2);
                bg.Move(30989, 38669, 50, bgCenter + 65, -25, bgCenter + 55);
                
                bg.Scale(38669, scale*2);
                bg.Move(38669, 46349, 735, bgCenter + 250, 745, bgCenter + 220);
            
            //Transitions
            var flash = GetLayer("Cinema").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                flash.ScaleVec(startTime, 854, 367);
                flash.Fade(startTime, 16110, 0.8, 0);
                flash.Fade(30989, 31469, 0.8, 0);
                flash.Additive(startTime, 46349);

            var blur = GetLayer("FlashBlur").CreateSprite("sb/blur.jpg", OsbOrigin.Centre, new Vector2(320, bgCenter));
                blur.Scale(startTime, (scale*1.5)*2);
                blur.Move(startTime, 23309, 400, bgCenter-340, 320, bgCenter-330);
                blur.Fade(startTime, 16110, 0.5, 0.1);
                blur.Fade(16110, 0);
                
                blur.Scale(30989, (scale*2)*2);
                blur.Move(30989, 38669, 50, bgCenter + 65, -25, bgCenter + 55);
                blur.Fade(30989, 31469, 0.5, 0.1);
                blur.Fade(31469, 0);         

                transitionKiai(45869, 46349, colorDarkA, colorLightA);

            //Occasional blur
            var blurCalm = GetLayer("BlurCalm").CreateSprite("sb/blur.jpg", OsbOrigin.Centre, new Vector2(320, bgCenter));
                blurCalm.Scale(startTime, (scale*1.5)*2);
                blurCalm.Move(startTime, 23309, 400, bgCenter-340, 320, bgCenter-330);
                blurCalm.Fade(startTime, 0);
                blurCalm.Fade(OsbEasing.InSine, 18989, 19469, 0, 0.92); blurCalm.Fade(OsbEasing.InSine, 19469, 19950, 0.92, 0);

                blurCalm.Scale(23309, (scale*5*2));
                blurCalm.Move(23309, 30989, -1375, bgCenter+350, -1350, bgCenter+400);
                blurCalm.Fade(23309, 0);
                blurCalm.Fade(OsbEasing.InSine, 26670, 27149, 0, 0.5); blurCalm.Fade(OsbEasing.InSine, 27149, 27629, 0.5, 0);
                blurCalm.Fade(OsbEasing.InSine, 29069, 30989, 0, 0.5);

                blurCalm.Scale(30989, (scale*2)*2);
                blurCalm.Move(30989, 38669, 50, bgCenter + 65, -25, bgCenter + 55);
                blurCalm.Fade(30989, 0);
                blurCalm.Fade(OsbEasing.InSine, 36750, 38669, 0, 0.92);

                blurCalm.Scale(38669, (scale*2)*2);
                blurCalm.Move(38669, 46349, 735, bgCenter + 250, 745, bgCenter + 220);
                blurCalm.Fade(38669, 0);
                blurCalm.Fade(OsbEasing.InSine, 44430, 46349, 0, 0.92);
        }

        public void transitionKiai(int startTime, int endTime, Color4 outerColor, Color4 innerColor)
        {
            var circle = GetLayer("kiaiStart").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(320, 254 + (480-254)/2));
                circle.Scale(startTime, startTime + beat/2, 0.06, 1.12);
                circle.Color(startTime, outerColor); circle.Fade(startTime, 1);    
                circle.Fade(endTime, 0);      
            var circle2 = GetLayer("kiaiStart").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(320, 254 + (480-254)/2));
                circle2.Scale(startTime+beat/4, startTime+beat/4 + beat/2, 0.06, 1.12);
                circle2.Color(startTime+beat/4, innerColor);
                circle2.Fade(startTime+beat/4, 1); circle2.Fade(endTime, 0);   
            var circle3 = GetLayer("kiaiStart").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(320, 254 + (480-254)/2));
                circle3.Scale(startTime+beat/2, startTime+beat/2 + beat/2, 0.06, 1.12);
                circle3.Color(startTime+beat/2, outerColor); circle3.Fade(startTime+beat/2, 1);    
                circle3.Fade(endTime, 0);   
        }

        public void kiai(int startTime, int endTime)
        {
            var bg = GetLayer("BackgroundKiai").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 240));
                bg.ScaleVec(startTime, 854, 480);
                bg.Fade(startTime, 1); bg.Fade(endTime+1, 0);
                
                bg.Color(startTime, colorDarkA);
                bg.Color(50190, colorDarkB);
                bg.Color(54030, colorDarkC);
                bg.Color(59790, colorDarkB);

                bg.Color(61710, colorDarkA);
                bg.Color(65550, colorDarkB);
                bg.Color(69390, colorDarkC);
                bg.Color(73230, colorDarkA);
                bg.Color(75150, colorDarkB);
            
            // I'm looking everywhere but
            grid(46349, 50189, colorLightA);

            // I can't find you
            cannotSeeYou(48270, 50189, colorLightA);

            // I'm getting close like it's
            grid(50189, 54029, colorLightB);

            // Right in front of me
            rightInFrontOfMe(52110, 54029, colorLightB);
            
            // I can feel you but I
            grid(54029, 57869, colorLightC);
            grid(69389, 73230, colorLightC);

            // Cannot see you
            cannotSeeYou(55950, 57869, colorLightC);
            cannotSeeYou(71309, 73230, colorLightC);

            // I could be dreaming but I 
            grid(61709, 65550, colorLightA);

            // Feel so wide awake
            rightInFrontOfMe(63630, 65550, colorLightA);

            // A secret yearning that is
            grid(65550, 69389, colorLightB);

            // Deep inside of me    
            rightInFrontOfMe(67470, 69389, colorLightB);        

            // I'm reaching out
            imReachingOut(57869, 59790, colorLightC, colorDarkC);
            imReachingOut(73230, 75150, colorLightA, colorDarkA);
            
            // Reaching out
            reachingOut(59790, 61709);
            reachingOut(75150, 77069);

            var flash = GetLayer("FlashKiai").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                flash.ScaleVec(76589, 854, 480);
                flash.Fade(76589, endTime, 0, 0.9);
                flash.Additive(76589, endTime);
        }
        
        public void grid(int startTime, int endTime, Color4 color)
        {
            for (int i=0; i<4; i++) 
            {
                var size = 3; var offset = 63;

                var bar = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 , 460 - i*offset));
                    bar.ScaleVec(startTime, startTime + beat*4, 0, size, 854, size);
                    bar.Fade(startTime, 1); bar.Fade(endTime, 0);
                    bar.Color(startTime, color);

                var bar0 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 460 - i*offset));
                    bar0.ScaleVec(OsbEasing.OutBack, startTime, startTime + beat/4, 3, 0 , 3, size*4);
                    bar0.Fade(startTime, 1); bar0.Fade(endTime, 0);
                    bar0.Color(startTime, color);

                for (int j=1; j<4; j++)
                {
                    var bar1 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 - j*107.4f, 460 - i*offset));
                    bar1.ScaleVec(OsbEasing.OutBack, startTime + j*beat, startTime + j*beat + beat/4, 3, 0 , 3, size*4);
                    bar1.Fade(startTime, 1); bar1.Fade(endTime, 0);
                    bar1.Color(startTime, color);

                    var bar2 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 + j*107.4f, 460 - i*offset));
                    bar2.ScaleVec(OsbEasing.OutBack, startTime + j*beat, startTime + j*beat + beat/4, 3, 0 , 3, size*4);
                    bar2.Fade(startTime, 1); bar2.Fade(endTime, 0);
                    bar2.Color(startTime, color);
                }
            }
        }

        public void rightInFrontOfMe(int startTime, int endTime, Color4 color)
        {
            var BarLeft = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(-107 , 367f));
                BarLeft.ScaleVec(startTime, startTime + 100, -16 + 854/3f, 0, -16 + 854/3f, 100);
                BarLeft.Fade(startTime , 1); BarLeft.Fade(endTime, 0);
                BarLeft.Color(startTime , color);

            var BarMid1 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320 - 104 , 0));
                BarMid1.ScaleVec(startTime + beat, startTime + beat + 100, 0, 480, 100, 480);
                BarMid1.Fade(startTime + beat , 1); BarMid1.Fade(endTime, 0);
                BarMid1.Color(startTime + beat , color);

            var BarMid2 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320 , 480));
                BarMid2.ScaleVec(startTime + beat*2, startTime + beat*2 + 100, 0, 480, 100, 480);
                BarMid2.Fade(startTime + beat*2 , 1); BarMid2.Fade(endTime, 0);
                BarMid2.Color(startTime + beat*2 , color);

            var BarMid3 = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320 + 104 , 0));
                BarMid3.ScaleVec(startTime + beat*2 + beat/2, startTime + beat*2 + beat/2 + 100, 0, 480, 100, 480);
                BarMid3.Fade(startTime + beat*2 + beat/2 , 1); BarMid3.Fade(endTime, 0);
                BarMid3.Color(startTime + beat*2 + beat/2 , color);

            var BarRight = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.CentreRight, new Vector2(747 , 367f));
                BarRight.ScaleVec(startTime + beat*3, startTime + beat*3 + 100, -16 + 854/3f, 0, -16 + 854/3f, 100);
                BarRight.Fade(startTime + beat*3 , 1); BarRight.Fade(endTime, 0);
                BarRight.Color(startTime + beat*3 , color);
        }

        public void cannotSeeYou(int startTime, int endTime, Color4 color)
        {
            for (int i=0; i<4; i++)
            {
                var size = 96; var offset = 4;

                var bar = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320 - (size*2 + offset*1.5f) + size/2 + (size+offset)*i, 240));
                    bar.ScaleVec(startTime + i*beat, startTime + i*beat + 100, 0, 480, size, 480);
                    bar.Fade(startTime + i*beat, 1); bar.Fade(endTime, 0);
                    bar.Color(startTime + i*beat, color);
            }  
        }

        public void imReachingOut(int startTime, int endTime, Color4 colorLight, Color4 colorDark)
        {
            var circle = GetLayer("KiaiEffect").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(320, 240));
                circle.Color(startTime, colorLight);
                circle.Fade(startTime, 1); circle.Fade(endTime, 0);
                circle.Scale(startTime, 0.55);
                pulsate(startTime, endTime, circle, 0.55f);

            for (int i=0; i<5; i++)
            {
                var rect = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(-45, (254 + (480-254)/2) - i*81));
                    rect.Color(startTime, colorDark);
                    rect.Fade(startTime, 1); rect.Fade(endTime, 0);
                    rect.ScaleVec(startTime, 700, 90/(i+1));
            }
        }

        public void reachingOut(int startTime, int endTime)
        {
            var circleO = GetLayer("KiaiEffect").CreateSprite("sb/circleO.png", OsbOrigin.Centre, new Vector2(320, 240));
                circleO.Color(startTime, colorLightB);
                circleO.Fade(startTime, 1); circleO.Fade(endTime, 0);
                circleO.Scale(startTime, 0.576f);
                pulsate(startTime, endTime+1, circleO, 0.576f);
            
            var circle2 = GetLayer("KiaiEffect").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(320, 240));
                circle2.Color(startTime, colorLightB);
                circle2.Fade(startTime, 1); circle2.Fade(endTime, 0);
                circle2.Scale(startTime, 0.4f);
                pulsate(startTime, endTime+1, circle2, 0.4f);

            for (int i=0; i<5; i++)
            {
                var rect = GetLayer("KiaiEffect").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(-45, (254 + (480-254)/2) - i*81));
                    rect.Color(startTime, colorDarkB);
                    rect.Fade(startTime, 1); rect.Fade(endTime, 0);
                    rect.ScaleVec(startTime, 700, 90/(i+1));
            }
        }

        public void pulsate(int startTime, int endTime, OsbSprite sprite, float scale)
        {
            sprite.StartLoopGroup(startTime, (endTime-startTime)/beat);
                sprite.Scale(OsbEasing.OutBack, 0, beat, scale*1.2f, scale);
            sprite.EndGroup();
        }

        public void ending(int startTime, int endTime)
        {
            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var scale = 854.0f / bgBitmap.Width;
            int bgCenter = 210 + (480/2);

		    var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, bgCenter));
                bg.Fade(startTime, 1);
                bg.Fade(endTime, 0);
                bg.Scale(startTime, scale*1.05f);
                bg.Rotate(OsbEasing.InOutSine, startTime, endTime, MathHelper.DegreesToRadians(-3), MathHelper.DegreesToRadians(3));
                revolve(startTime, endTime, bg, 0, 2 * (endTime - startTime)/(beat*12), 320, bgCenter, 1, 6);


            particlesUpward(startTime, endTime, 100);

            var cinemaBar1 = GetLayer("CinemaEnding").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                cinemaBar1.Fade(91949, 1);
                cinemaBar1.Color(91949, colorBlack);

            var cinemaBar2 = GetLayer("CinemaEnding").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
                cinemaBar2.Fade(91949, 1);
                cinemaBar2.Color(91949, colorBlack);

            var step = (367 - 254)/4f;
            for (int i=0; i<4; i++)
            {   
                cinemaBar1.ScaleVec(OsbEasing.OutExpo, 91949 + i*(beat/4), (91949 + beat/4) + i*(beat/4), 854, step*i, 854, step*(i+1));
                cinemaBar2.ScaleVec(OsbEasing.OutExpo, 91949 + i*(beat/4), (91949 + beat/4) + i*(beat/4), 854, step*i, 854, step*(i+1));
            }

            cinemaBar1.Fade(92430, 94349, 1, 0);
            cinemaBar2.Fade(92430, 94349, 1, 0);

            var flash = GetLayer("FlashKiai").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                flash.ScaleVec(startTime, 854, 367);
                flash.Fade(startTime, 77550, 0.8, 0);
                flash.Additive(startTime, endTime);
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

                var p = GetLayer("Particles").CreateSprite("sb/light.png");

                int durationStart = Random(startTime - 10000, (endTime+2500) - 10000 / 2);
                int durationEnd = durationStart + Random(10000 / 2, 20000 / 2);
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
                
                Color4[] colors = {colorLightA, colorDarkA, colorLightB, colorDarkB, colorLightC, colorDarkC};
                p.Color(durationStart, colors[Random(0, 6)]);
                p.Additive(durationStart, durationEnd);
            }
        }

        public void particlesPopUp(int startTime, int endTime, int quantity)
        {
            for (int i=0; i<quantity; i++)
            {   
                var randomX = Random(320 + 10 -(854/2), 320 - 10 +(854/2)); var randomY = Random(254 + 5, 480 - 5);
                var particle = GetLayer("Particles").CreateSprite("sb/light.png", OsbOrigin.Centre, new Vector2(randomX, randomY));

                var duration = 2000;
                var start = Random(startTime, endTime-duration);
                var scale = 0.02f;
                if(i%10 == 0)
                    scale = 0.015f;
                else if(i%3 == 0)
                    scale = 0.035f;

                particle.Fade(start, start + duration/2, 0, 0.5);
                particle.Fade(start + duration/2, start + duration, 0.9, 0);
                particle.Scale(start, scale);
                particle.Move(start, start+duration, randomX, randomY, randomX + Random(-3, 3), randomY + Random(-3, 3));
            }
        }
    }
}
