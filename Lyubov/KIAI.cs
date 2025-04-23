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
    public class KIAI : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            int mode = getMode();

            var bgBitmap = GetMapsetBitmap("sb/blur.jpg");
            var bgScale = (854.0f / bgBitmap.Width)*1.05f;

            var blur = GetLayer("BACKGROUND").CreateSprite("sb/blur.jpg", OsbOrigin.TopCentre, new Vector2(320, 0));
            blur.Scale(54066, bgScale);
            blur.Fade(54066, 0.8); blur.Fade(74711, 0);

            particles(48904, 80000);

            var chara = GetLayer("BACKGROUND").CreateSprite("sb/chara_mask2.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            chara.Scale(54066, bgScale);
            chara.Fade(54066, 1); chara.Fade(74711, 0);
            chara.Color(54066, new Color4(0, 0, 0, 0));

            var bg = GetLayer("BACKGROUND").CreateSprite(Beatmap.BackgroundPath, OsbOrigin.TopCentre, new Vector2(320, 0));
            bg.Scale(54066, bgScale);
            bg.Fade(54066, 1); bg.Fade(74711, 0);
            bg.Additive(54066);

            particles_front(48904, 88904);
            smoke(48904, 80000);

            OsbSprite[] sprites = {blur, chara, bg};
            WiggleScreen(54066, 74711, 10, mode==1 ? new Vector2(320, 210) : new Vector2(320, -20), 0, 20, sprites);
        }

        public void smoke(int startTime, int endTime)
        {
            var quantity = 20;
            Color4 color = new Color4(255, 255, 255, 1);

            for (int i=0; i<quantity; i++)
            {   
                var rain = GetLayer("BACKGROUND").CreateSprite("sb/smoke/s"+Random(0,9)+".png");

                var rainStartTime = Random(startTime, startTime + 6400);

                var randX = Random(747, 800) + 50; var randY = Random(350, 500);
                var rainEndTime = 6400;

                double angle = MathHelper.DegreesToRadians(180);
                var radius = 1400 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.Scale(rainStartTime, 0.6);
                rain.Color(rainStartTime, color);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(Random(0,360)));
                rain.Fade(rainStartTime, 0.2); rain.Fade(endTime, 0);
                rain.Additive(rainStartTime, endTime);  

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y - 25);
                    rain.Scale(OsbEasing.InSine, 0, rainEndTime, 0.6, 1);
                    rain.Fade(OsbEasing.InSine, 0, rainEndTime, 0.2, 0);
                rain.EndGroup();
            }
        }

        public void particles(int startTime, int endTime)
        {
            var quantity = 10;
            Color4 color = new Color4(0, 0, 0, 1);

            for (int i=0; i<quantity; i++)
            {   
                var rain = GetLayer("BACKGROUND").CreateSprite("sb/particles/o.png");

                var rainStartTime = Random(startTime, startTime + 6400);

                var randX = Random(-107, 747); var randY = Random(480, 520);
                var rainEndTime = 6400;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1400 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.Scale(rainStartTime, 0.25);
                rain.Color(rainStartTime, color);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(Random(0,360)));
                rain.Fade(rainStartTime, 0.8); rain.Fade(endTime, 0); 

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y - 25);
                    rain.Fade(OsbEasing.InSine, 0, rainEndTime, 0.8, 0);
                rain.EndGroup();
            }
        }

        public void particles_front(int startTime, int endTime)
        {
            var quantity = 20;
            Color4 color = new Color4(255, 255, 255, 1);

            for (int i=0; i<quantity; i++)
            {   
                var rain = GetLayer("BACKGROUND").CreateSprite("sb/particles/o.png");

                var rainStartTime = Random(startTime, startTime + 14000);

                var randX = Random(-107, 747); var randY = Random(480, 520);
                var rainEndTime = 12800;

                double angle = MathHelper.DegreesToRadians(-90);
                var radius = 1400 - randY;
                Vector2 endPos = new Vector2(
                    (float)(randX + Math.Cos(angle) * radius),
                    (float)(randY + Math.Sin(angle) * radius));

                rain.Scale(rainStartTime, 0.1);
                rain.Color(rainStartTime, color);
                rain.Rotate(rainStartTime, MathHelper.DegreesToRadians(Random(0,360)));
                rain.Fade(rainStartTime, 0.8); rain.Fade(endTime, 0);

                rain.StartLoopGroup(rainStartTime, (int)((endTime - rainStartTime) / rainEndTime));
                    rain.Move(0, rainEndTime, randX, randY, endPos.X, endPos.Y - 25);
                    rain.Fade(OsbEasing.InSine, 0, rainEndTime, 0.8, 0);
                rain.EndGroup();
            }
        }

        public void WiggleScreen(double startTime, double endTime, int rate, Vector2 InitPos, double InitRot, int wiggleAmount, params OsbSprite[] sprites){

            //Rate average around 20 to 100 (bigger number, more shakes)

            var loopTime = (endTime-startTime)/rate;

            var previousCord = new Vector2(InitPos.X,InitPos.Y);

            for(int i = 0; i < rate - 1; i++){

                var xCord = Random(InitPos.X-wiggleAmount,InitPos.X+wiggleAmount);

                var yCord = Random(InitPos.Y-wiggleAmount,InitPos.Y+wiggleAmount);

                var tempCord = new Vector2(xCord,yCord);
                
                foreach(var sprite in sprites){
                    sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
                }
            
                //Log($"{startTime+(loopTime*i)} until {startTime+(loopTime*(i+1))}");

                previousCord = tempCord;
                
            }

            double previousRotation = InitRot;

            for(int i = 0; i < (rate - 1)/2; i++){

                double[] rotate = new double[]{
                    0.01 // , 0.02, 0.03 // Add these for more rotations
                };

                var rotInd = Random(0,rotate.Length);

                var tempRot = rotate[rotInd];

                foreach(var sprite in sprites){
                sprite.Rotate(OsbEasing.InOutSine,startTime+((2*loopTime)*i),startTime+((2*loopTime)*(i+1)),previousRotation,tempRot);
                }

                previousRotation = tempRot;

            }

            foreach(var sprite in sprites){

                sprite.Rotate(OsbEasing.InOutSine, startTime + loopTime * (rate - 1), startTime +  loopTime * rate, previousRotation, 0);
                sprite.Move(OsbEasing.InOutSine,  startTime + loopTime * (rate - 1),  startTime + loopTime * rate , previousCord, InitPos);

            }
        }

        public int getMode() 
        {
            using (var stream = OpenMapsetFile("PORNOFIL'MY - Lyubov' (Cut Ver.) (_linee1212) [" + Beatmap + "].osu"))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                string line;
                int i=0;

                while (reader.Peek() >=0)
                {
                    line = reader.ReadLine();
                    if(line.StartsWith("Mode:"))
                    {   
                        var modeValueStr = line.Substring("Mode:".Length).Trim();
                        int mode = int.Parse(modeValueStr);
                        
                        return mode;
                    }
                }
                
                return -1;
            }
        }
    }
}
