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
    public class Top : StoryboardObjectGenerator
    {
        public override void Generate()
        {   
            int quantity = 30;
            OsbSprite[] squares = new OsbSprite[quantity];
            for(int i=0; i<quantity; i++)
            {
                var square = GetLayer("TopGeometry").CreateSprite("sb/geometry/st.png", OsbOrigin.Centre, new Vector2(Random(-127, 767), Random(-10, 150)));
                    square.Scale(23384, Random(0.1, 0.15));
                    square.Additive(23384);
                    square.Rotate(23384, MathHelper.DegreesToRadians(i%2==0 ? 45 : 0));

                    square.Fade(23384, 0.20);

                squares[i] = square;
            }  

            int[] rolls = { 23384, 28573, 33763, 36357, 38952, 40249, 41546, 42195, 42844};

            squareRoll(squares, rolls);
            squareRoll(squares, 44141, 64898, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(44141).BeatDuration)*2);
            squareRoll(squares, 64898, 85655, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(64898).BeatDuration));

            rolls = new int[] {85655, 88249, 90844, 93438, 96033, 97330, 98663, 100033, 101444, 102172, 102899, 103626, 104353, 104728, 105103, 105478, 105853};

            squareRoll(squares, rolls);

            squareRoll(squares, 135224, 159999, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(135224).BeatDuration));

            rolls = new int[] { 159999, 160579, 161160, 161547, 162128, 162708, 163095, 163676, 164257, 164644, 165224, 165805, 166192,
                                166773, 167354, 167741, 168321, 168902, 169289, 169870, 170450, 170837, 171418, 171999, 172386, 172966,
                                173547, 173934, 174496, 175059, 175434, 175979, 176524, 176888, 177417, 177946, 178298, 178813, 179327,
                                179669, 180169, 180669, 181003, 181476, 181950, 182266, 182716, 183166, 183466};

            squareRoll(squares, rolls);

            squareRoll(squares, 205065 , 224266, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(205065).BeatDuration*8));

            rolls = new int[] { 224266, 226666, 229065, 231466, 232666, 233266, 233565, 233865,
                                236266, 238666, 239865, 241065, 241666, 242266};

            squareRoll(squares, rolls);

            squareRoll(squares, 243466 , 262740, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(243466).BeatDuration));

            rolls = new int[] { 262665, 263115, 263566, 263865, 264316, 264765, 265066, 265515, 265966, 266265, 266716, 267165, 267466,
                                267915, 268365, 268665, 269115, 269566, 269865, 270316, 270765, 271066, 271515, 271966, 272265, 272716,
                                273165, 273466, 273915, 274365, 274665, 275105, 275544, 275836, 276275, 276714, 277007, 277435, 277864,
                                278149, 278578, 279006, 279292, 279710, 280129, 280408, 280826, 281245, 
                                281524, 283705, 285887, 288069};

            squareRoll(squares, rolls);

            squareRoll(squares, 290251 , 325218, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(290251).BeatDuration));

            rolls = new int[] { 334725, 335741, 336758, 337775, 338792, 339808, 340870, 341932, 343018, 344129, 345240};

            squareRoll(squares, rolls);

            squareRoll(squares, 347462 , 383295, Convert.ToInt32(GetBeatmap("Final Battle").GetTimingPointAt(347462).BeatDuration));

            
            
        }

        public void squareRoll(OsbSprite[] squares, int[] rolls)
        {
            for(int i=0; i<squares.Length; i++)
            {   
                int distanceX = Random(25, 100);

                for(int j=0; j<rolls.Length; j++)
                {   
                    int startTime = rolls[j];
                    double currentX = squares[i].PositionAt(startTime).X;
                    if(currentX <= -107)
                    {
                        currentX = Random(787, 827);
                    }
                    double currentRotation = squares[i].RotationAt(startTime);
                    squares[i].MoveX(OsbEasing.OutSine, startTime, startTime+250, currentX, currentX - distanceX);
                    squares[i].Rotate(OsbEasing.OutSine, startTime, startTime+250, currentRotation, currentRotation - MathHelper.DegreesToRadians(45));
                }
            }
        }

        public void squareRoll(OsbSprite[] squares, int start, int end, int step)
        {
            for(int i=0; i<squares.Length; i++)
            {   
                int distanceX = Random(25, 100);

                for(int j=0; j<(end - start)/step; j++)
                {   
                    int startTime = start + j*step;
                    float currentX = squares[i].PositionAt(startTime).X;
                    if(currentX <= -127)
                    {   
                        squares[i].Fade(startTime, 0);
                        currentX = Random(787, 827);

                        var square = GetLayer("TopGeometry").CreateSprite("sb/geometry/st.png", OsbOrigin.Centre, new Vector2(currentX, Random(-10, 150)));
                        square.Scale(startTime, Random(0.1, 0.15));
                        square.Additive(startTime);
                        square.Rotate(startTime, MathHelper.DegreesToRadians(i%2==0 ? 45 : 0));

                        square.Fade(startTime, 0.20);

                        squares[i] = square;
                    }
                    float currentRotation = squares[i].RotationAt(startTime);
                    squares[i].MoveX(OsbEasing.OutSine, startTime, startTime+250, currentX, currentX - distanceX);
                    squares[i].Rotate(OsbEasing.OutSine, startTime, startTime+250, currentRotation, currentRotation - MathHelper.DegreesToRadians(45));
                }
            }
        }
    }
}
