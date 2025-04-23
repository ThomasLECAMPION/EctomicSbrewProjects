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
    public class Maxwell : StoryboardObjectGenerator
    {   
        int midScreen = 254 + (480-254)/2;
        public override void Generate()
        {   
            
            //scene 1: zoom-ins
            double spinShadowScale = 1;
            var spinShadow = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spinShadow.Fade(224, 0.1); 
                    spinShadow.Scale(224, spinShadowScale); spinShadowScale*=1.25;
                    spinShadow.Scale(1314, spinShadowScale);spinShadowScale*=1.25;
                    spinShadow.Scale(2404, spinShadowScale);spinShadowScale*=1.25;
                spinShadow.Fade(3494, 0); 

            double spinScale = 0.5;
            var spin = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spin.Fade(224, 1); 
                    spin.Scale(224, spinScale); spinScale*=1.25;
                    spin.Scale(1314, spinScale);spinScale*=1.25;
                    spin.Scale(2404, spinScale);spinScale*=1.25;
                spin.Fade(3494, 0); 

            var faceShadow = GetLayer("Maxwell").CreateSprite("sb/maxwell-spinning/maxwell-spinning2.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                faceShadow.Fade(3494, 0.1); 
                    faceShadow.Scale(3494, spinShadowScale);
                faceShadow.Fade(4039, 0); 

            var face = GetLayer("Maxwell").CreateSprite("sb/maxwell-spinning/maxwell-spinning2.png", OsbOrigin.Centre, new Vector2(320, midScreen));
                face.Fade(3494, 1); 
                    face.Scale(3494, spinScale);
                face.Fade(4039, 0); 
            
            var eekShadow = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 17, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                eekShadow.Fade(4039, 0.1); 
                    eekShadow.Scale(OsbEasing.OutSine, 4039, 4584, spinShadowScale, 0.60);
                eekShadow.Fade(4584, 0); 

            var eek = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 17, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                eek.Fade(4039, 1); 
                    eek.Scale(OsbEasing.OutSine, 4039, 4584, spinScale, 0.10);
                eek.Fade(4584, 0); 


            //part1 & 2
            var runV = GetLayer("Maxwell").CreateAnimation("sb/maxwell-running/maxwell-running.png", 21, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(450, 380));
                runV.Scale(4584, 0.4);
                runV.Fade(4584, 1);
                runV.Fade(8945, 0);
                runV.FlipH(4584);
                runV.MoveX(4584, 8945, 540, 250);

            var runArc = GetLayer("Maxwell").CreateAnimation("sb/maxwell-running/maxwell-running.png", 21, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(450, 410));
                runArc.Scale(8945, 0.4);
                runArc.Fade(8945, 1);
                runArc.Fade(13305, 0);
                runArc.MoveX(8945, 13305, 180, 440);
            
            var spinFT = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spinFT.Fade(13305, 1); 
                    spinFT.Scale(13305, 0.4);
                    spinFT.FlipH(13305);
                    spinFT.MoveY(13305, 17666, 460, 420);
                spinFT.Fade(17666, 0); 

            var runP = GetLayer("Maxwell").CreateAnimation("sb/maxwell-running/maxwell-running.png", 21, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(450, 390));
                runP.Scale(19846, 0.4);
                runP.Fade(19846, 1);
                    runP.MoveX(19846, 22027, 180, 440);
                runP.Fade(22027, 0);

            var runW = GetLayer("Maxwell").CreateAnimation("sb/maxwell-running/maxwell-running.png", 21, 50, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(440, 390));
                runW.Scale(24207, 0.4);
                runW.Fade(24207, 1);
                    runW.FlipH(24207);
                    runW.MoveY(24207, 26387, 440, 400);
                runW.Fade(26387, 0);

            var spinR = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(170, midScreen));
                spinR.Fade(28568, 1); 
                    spinR.Scale(28568, 0.3);
                    spinR.FlipH(28568);
                    spinR.MoveY(28568, 30748, 280, 440);
                spinR.Fade(30748, 0); 

            //build up
            var spinB1 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(535+50, midScreen));
                spinB1.Fade(30748, 1); 
                    spinB1.Scale(30748, 0.7);
                spinB1.Fade(35109, 0); 
            
            var spinB2 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(105-50, midScreen));
                spinB2.Fade(30748, 0);
                spinB2.Fade(31838, 1); 
                    spinB2.Scale(30748, 0.7);
                    spinB2.FlipH(30748);
                spinB2.Fade(35109, 0); 

            var spinB3 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(260, midScreen));
                spinB3.Fade(30748, 0);
                spinB3.Fade(34019, 1); 
                    spinB3.Scale(30748, 0.7);
                spinB3.Fade(35109, 0); 

            var spinB4 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 64, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(380, midScreen));
                spinB4.Fade(30748, 0);
                spinB4.Fade(32928, 1); 
                    spinB4.Scale(30748, 0.7);
                    spinB4.FlipH(30748);
                spinB4.Fade(35109, 0); 


            spinShadowScale = 1;
            var spinShadowB = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spinShadowB.Fade(30748, 0.1); 
                    spinShadowB.Scale(30748, spinShadowScale); spinShadowScale*=1.25;
                    spinShadowB.Scale(31838, spinShadowScale);spinShadowScale*=1.25;
                    spinShadowB.Scale(32928, spinShadowScale);spinShadowScale*=1.25;
                    spinShadowB.Scale(34019, spinShadowScale);
                spinShadowB.Fade(35109, 0); 

            spinScale = 0.5;
            var spinB = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spinB.Fade(30748, 1); 
                    spinB.Scale(30748, spinScale); spinScale*=1.25;
                    spinB.Scale(31838, spinScale);spinScale*=1.25;
                    spinB.Scale(32928, spinScale);spinScale*=1.25;
                    spinB.Scale(34019, spinScale);
                spinB.Fade(35109, 0); 

            //part3
            var spinS1 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(360, midScreen));
                spinS1.Fade(35109, 1); 
                    spinS1.Scale(OsbEasing.InSine, 35109, 39469, 0.01, 0.5);
                    spinS1.MoveX(OsbEasing.InSine, 35109, 39469, 360, 500);
                    spinS1.MoveY(OsbEasing.OutSine, 35109, 39469, midScreen, 310);
                    spinS1.Rotate(35109, 39469, 0, MathHelper.DegreesToRadians(360));
                spinS1.Fade(39469, 0); 

            var spinS2 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(360, midScreen));
                spinS2.Fade(39469, 1); 
                    spinS2.Scale(39469, 0.5);
                    spinS2.MoveX(39469, 43830, 70, 620);
                    spinS2.Rotate(39469, 43830, 0, MathHelper.DegreesToRadians(360));
                spinS2.Fade(43830, 0); 

            var spinS3 = GetLayer("Maxwell").CreateAnimation("sb/maxwell-spinning/maxwell-spinning.png", 23, 46, OsbLoopType.LoopForever, OsbOrigin.Centre, new Vector2(320, midScreen));
                spinS3.Fade(43830, 1); 
                    spinS3.Scale(OsbEasing.OutSine, 43830, 47918, 0.9, 0.03);
                    spinS3.Rotate(43830, 47918, 0, MathHelper.DegreesToRadians(360));
                spinS3.Fade(47918, 0); 
        }
    }
}
