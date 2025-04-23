using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;
using System.Drawing;
using System.Linq;

namespace StorybrewScripts
{
    public class Particles : StoryboardObjectGenerator
    {
        [Group("Timing")]
        [Configurable] public int StartTime;
        [Configurable] public int EndTime;

        [Group("Sprite")]
        [Configurable] public string Path = "sb/smoke/smoke";
        [Configurable] public OsbOrigin Origin = OsbOrigin.Centre;
        [Configurable] public Vector2 Scale = new Vector2(0.4f, 0.4f);
        [Description("Rotation of the sprite; does not influences particle motion direction.")]
        [Configurable] public float Rotation = 0;
        [Configurable] public Color4 Color = new Color4(0.4f, 0.1f, 0.1f, 0.32f);
        [Description("Varies the saturation and brightness of the selected Color for each particle.")]
        [Configurable] public float ColorVariance = 0.2f;
        [Configurable] public bool Additive = true;

        [Group("Spawn")]
        [Configurable] public int ParticleCount = 8;
        [Configurable] public float Lifetime = 1250;
        [Description("The point around which particles will be created.")]
        [Configurable] public Vector2 SpawnOrigin = new Vector2(-80, 140);
        [Description("The distance around the Spawn Origin point where particles will be created.")]
        [Configurable] public float SpawnSpread = 10;

        [Group("Motion")]
        [Description("The angle in degrees at which particles will be moving.\n0 is to the right, positive values rotate counterclockwise.")]
        [Configurable] public float Angle = 270;
        [Description("The spread in degrees around Angle.")]
        [Configurable] public float AngleSpread = 60;
        [Description("The speed at which particles move, in osupixels.")]
        [Configurable] public float Speed = 60;
        [Description("Eases the motion of particles.")]
        [Configurable] public OsbEasing Easing = OsbEasing.None;

        public override void Generate()
        {
            if (StartTime == EndTime && Beatmap.HitObjects.FirstOrDefault() != null)
            {
                StartTime = (int)Beatmap.HitObjects.First().StartTime;
                EndTime = (int)Beatmap.HitObjects.Last().EndTime;
            }
            EndTime = Math.Min(EndTime, (int)AudioDuration);
            StartTime = Math.Min(StartTime, EndTime);

            var bitmap = GetMapsetBitmap(Path+"0.png");

            var duration = (double)(EndTime - StartTime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            var layer = GetLayer("Smoke");
            for (var j = 0; j < 11; j++)
            {   
                for (var i = 0; i < ParticleCount; i++)
                {
                    var spawnAngle = Random(Math.PI * 2);
                    var spawnDistance = (float)(SpawnSpread * Math.Sqrt(Random(1f)));

                    var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                    var moveDistance = Speed * Lifetime * 0.001f;

                    var spriteRotation = moveAngle + MathHelper.DegreesToRadians(Rotation);

                    var startPosition = SpawnOrigin + new Vector2((float)Math.Cos(spawnAngle), (float)Math.Sin(spawnAngle)) * spawnDistance;
                    var endPosition = startPosition + new Vector2((float)Math.Cos(moveAngle), (float)Math.Sin(moveAngle)) * moveDistance;

                    var loopDuration = duration / loopCount;
                    var startTime = StartTime + (i * loopDuration) / ParticleCount;
                    var endTime = startTime + loopDuration * loopCount;

                    if (!isVisible(bitmap, startPosition, endPosition, (float)spriteRotation, (float)loopDuration))
                        continue;

                    var color = Color;
                    if (ColorVariance > 0)
                    {
                        ColorVariance = MathHelper.Clamp(ColorVariance, 0, 1);

                        var hsba = Color4.ToHsl(color);
                        var sMin = Math.Max(0, hsba.Y - ColorVariance * 0.5f);
                        var sMax = Math.Min(sMin + ColorVariance, 1);
                        var vMin = Math.Max(0, hsba.Z - ColorVariance * 0.5f);
                        var vMax = Math.Min(vMin + ColorVariance, 1);

                        color = Color4.FromHsl(new Vector4(
                            hsba.X,
                            (float)Random(sMin, sMax),
                            (float)Random(vMin, vMax),
                            hsba.W));
                    }

                    var particle = layer.CreateSprite(Path+Convert.ToString(Random(0,9))+".png", Origin);
                    if (spriteRotation != 0)
                        particle.Rotate(startTime, spriteRotation);
                    if (color.R != 1 || color.G != 1 || color.B != 1)
                        particle.Color(startTime, color);
                    if (Scale.X != 1 || Scale.Y != 1)
                    {
                        if (Scale.X != Scale.Y)
                            particle.ScaleVec(startTime, Scale.X, Scale.Y);
                        else particle.Scale(startTime, Scale.X);
                    }
                    if (Additive)
                        particle.Additive(startTime, endTime);

                    particle.StartLoopGroup(startTime, loopCount);
                    particle.Rotate(0, loopDuration, 0, moveAngle * 0.2);
                    particle.Fade(OsbEasing.Out, 0, loopDuration * 0.2, 0, color.A);
                    particle.Fade(OsbEasing.In, loopDuration * 0.8, loopDuration, color.A, 0);
                    particle.Move(Easing, 0, loopDuration, startPosition, endPosition);
                    particle.EndGroup();
                }
                SpawnOrigin[0] = SpawnOrigin[0] + 80;
            }
        }

        private bool isVisible(Bitmap bitmap, Vector2 startPosition, Vector2 endPosition, float rotation, float duration)
        {
            var spriteSize = new Vector2(bitmap.Width * Scale.X, bitmap.Height * Scale.Y);
            var originVector = OsbSprite.GetOriginVector(Origin, spriteSize.X, spriteSize.Y);

            for (var t = 0; t < duration; t += 200)
            {
                var position = Vector2.Lerp(startPosition, endPosition, t / duration);
                if (OsbSprite.InScreenBounds(position, spriteSize, rotation, originVector))
                    return true;
            }
            return false;
        }
    }
}
