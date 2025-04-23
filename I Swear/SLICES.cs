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
    public class SLICES : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    slice(1, 99444, 100515, new Vector2(320, 220), 0.74f);
            slice(2, 100515, 101586, new Vector2(320, 190), 0.86f);
            slice(3, 101586, 102658, new Vector2(270, 250), 0.45f);
            slice(4, 102658, 103729, new Vector2(320, 210), 0.43f);
            slice(5, 103729, 105148, new Vector2(320, 230), 0.62f);

            var curtain1 = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(150, 1000));
                curtain1.Fade(99444, 1); curtain1.Fade(100515, 0);
                curtain1.Color(99444, new Color4(0, 0, 0, 1));
                curtain1.ScaleVec(OsbEasing.OutSine, 99444, 99801, 2000, 570, 2000, 500);
                curtain1.ScaleVec(99801, 100336, 2000, 500, 2000, 490);
                curtain1.ScaleVec(OsbEasing.OutSine, 100336, 100515, 2000, 490, 2000, 580);
                curtain1.Rotate(99444, MathHelper.DegreesToRadians(40));
            
            var curtain1t = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, -200));
                curtain1t.Fade(99444, 1); curtain1t.Fade(100515, 0);
                curtain1t.Color(99444, new Color4(0, 0, 0, 1));
                curtain1t.ScaleVec(OsbEasing.OutSine, 99444, 99801, 2000, 570, 2000, 500);
                curtain1t.ScaleVec(99801, 100336, 2000, 500, 2000, 490);
                curtain1t.ScaleVec(OsbEasing.OutSine, 100336, 100515, 2000, 490, 2000, 580);
                curtain1t.Rotate(99444, MathHelper.DegreesToRadians(25));

            var curtain2 = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(540, 1000));
                curtain2.Fade(100515, 1); curtain2.Fade(101586, 0);
                curtain2.Color(100515, new Color4(0, 0, 0, 1));
                curtain2.ScaleVec(OsbEasing.OutSine, 100515, 100872, 2000, 570, 2000, 500);
                curtain2.ScaleVec(100872, 101408, 2000, 500, 2000, 490);
                curtain2.ScaleVec(OsbEasing.OutSine, 101408, 101586, 2000, 490, 2000, 580);
                curtain2.Rotate(100515, MathHelper.DegreesToRadians(-40));
            
            var curtain2t = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(350, -200));
                curtain2t.Fade(100515, 1); curtain2t.Fade(101586, 0);
                curtain2t.Color(100515, new Color4(0, 0, 0, 1));
                curtain2t.ScaleVec(OsbEasing.OutSine, 100515, 100872, 2000, 570, 2000, 500);
                curtain2t.ScaleVec(100872, 101408, 2000, 500, 2000, 490);
                curtain2t.ScaleVec(OsbEasing.OutSine, 101408, 101586, 2000, 490, 2000, 580);
                curtain2t.Rotate(100515, MathHelper.DegreesToRadians(-25));

            var curtain3 = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(-35, 1000));
                curtain3.Fade(101586, 1); curtain3.Fade(102658, 0);
                curtain3.Color(101586, new Color4(0, 0, 0, 1));
                curtain3.ScaleVec(OsbEasing.OutSine, 101586, 101944, 2000, 570, 2000, 500);
                curtain3.ScaleVec(101944, 102479, 2000, 500, 2000, 490);
                curtain3.ScaleVec(OsbEasing.OutSine, 102479, 102658, 2000, 490, 2000, 580);
                curtain3.Rotate(101586, MathHelper.DegreesToRadians(68));
            
            var curtain3t = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(700, -200));
                curtain3t.Fade(101586, 1); curtain3t.Fade(102658, 0);
                curtain3t.Color(101586, new Color4(0, 0, 0, 1));
                curtain3t.ScaleVec(OsbEasing.OutSine, 101586, 101944, 2000, 570, 2000, 500);
                curtain3t.ScaleVec(101944, 102479, 2000, 500, 2000, 490);
                curtain3t.ScaleVec(OsbEasing.OutSine, 102479, 102658, 2000, 490, 2000, 580);
                curtain3t.Rotate(101586, MathHelper.DegreesToRadians(68));

            var curtain4 = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(-170, 1000));
                curtain4.Fade(102658, 1); curtain4.Fade(103729, 0);
                curtain4.Color(102658, new Color4(0, 0, 0, 1));
                curtain4.ScaleVec(OsbEasing.OutSine, 102658, 103015, 2000, 570, 2000, 500);
                curtain4.ScaleVec(103015, 103551, 2000, 500, 2000, 490);
                curtain4.ScaleVec(OsbEasing.OutSine, 103551, 103729, 2000, 490, 2000, 580);
                curtain4.Rotate(102658, MathHelper.DegreesToRadians(75));
            
            var curtain4t = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(970, -200));
                curtain4t.Fade(102658, 1); curtain4t.Fade(103729, 0);
                curtain4t.Color(102658, new Color4(0, 0, 0, 1));
                curtain4t.ScaleVec(OsbEasing.OutSine, 102658, 103015, 2000, 570, 2000, 500);
                curtain4t.ScaleVec(103015, 103551, 2000, 500, 2000, 490);
                curtain4t.ScaleVec(OsbEasing.OutSine, 103551, 103729, 2000, 490, 2000, 580);
                curtain4t.Rotate(102658, MathHelper.DegreesToRadians(105));

            var curtain5 = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.BottomCentre, new Vector2(590, 1000));
                curtain5.Fade(103729, 1); curtain5.Fade(105148, 0);
                curtain5.Color(103729, new Color4(0, 0, 0, 1));
                curtain5.ScaleVec(OsbEasing.OutSine, 103729, 104086, 2000, 570, 2000, 500);
                curtain5.ScaleVec(104086, 105148, 2000, 500, 2000, 490);
                curtain5.Rotate(103729, MathHelper.DegreesToRadians(-50));
            
            var curtain5t = GetLayer("SLICES_CURTAINS").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, -200));
                curtain5t.Fade(103729, 1); curtain5t.Fade(105148, 0);
                curtain5t.Color(103729, new Color4(0, 0, 0, 1));
                curtain5t.ScaleVec(OsbEasing.OutSine, 103729, 104086, 2000, 570, 2000, 500);
                curtain5t.ScaleVec(104086, 105148, 2000, 500, 2000, 490);
                curtain5t.Rotate(103729, MathHelper.DegreesToRadians(-25));
        }
        
        public void slice(int num, int startTime, int endTime, Vector2 position, float scale)
        {
            var bgPath = "sb/characters/fullart/slice"+num+".jpg";
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = (854.0f / bgBitmap.Width)*scale;

            var bg = GetLayer("SLICES").CreateSprite(bgPath, OsbOrigin.TopCentre, position);
            bg.Scale(startTime, endTime, bgScale, bgScale);
            bg.Fade(startTime, 1); bg.Fade(endTime, 0);
        }
    }
}
