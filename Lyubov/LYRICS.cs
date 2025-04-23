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
    public class LYRICS : StoryboardObjectGenerator
    {
        FontGenerator Font;

        FontGenerator Font_Credits;

        public override void Generate()
        {
		    Font = SetFont("Lyrics", "NotoSans-Bold.ttf");
            Font_Credits = SetFont("Credits", "Cinzel-Regular.ttf");

            int mode = getMode();
            int centerY = mode==1 ? 367 : 240; 

            Credits(7614, 10195, "PORNOFIL'MY", Font_Credits, 320, centerY, 0.5f, "LYRICS_DIFF");
            Credits(10195, 12775, "Lyubov'", Font_Credits, 320, centerY, 0.5f, "LYRICS_DIFF");
            Credits(12775, 15356, "[ " + Beatmap + " ]", Font_Credits, 320, centerY, 0.5f, "LYRICS_DIFF");
            Credits(15356, 17937, "Storyboard by Ectomic", Font_Credits, 320, centerY, 0.5f, "LYRICS_DIFF");

            Lyrics(28259, 32775, "По улицам шляемся, и ухмыляются улицы в наши глаза", Font);
            Lyrics(33098, 37937, "Живые, цветные и, самое главное, нам не смотреть назад", Font);
            Lyrics(38259, 43098, "Весна заразила нас оптимизмом серийных самоубийц", Font);
            Lyrics(43421, 48259, "Мы вышли наружу, и мы в грязных лужах танцуем под крики птиц", Font, 320, 395, 0.2f);

            Lyrics(48904, 53421, "Крики просветлённых птиц", Font, 320, centerY, 0.45f, "LYRICS_DIFF");

            Lyrics(54388, 59227, "Вот и всё, как-то так живём!", Font);
            Lyrics(59550, 64388, "Не везёт — значит, подождём!", Font);
            Lyrics(64711, 69550, "И любо-о-овь проливным дождём", Font);
            Lyrics(69872, 73421, "Нас накроет с головой!", Font);

            Lyrics(74953, 78582, "Нас накроет с головой!", Font, 320, centerY, 0.45f, "LYRICS_DIFF");


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

        public void Credits(int startTime, int endTime, string text, FontGenerator font, float LetterX = 320, float LetterY = 367, float scale = 0.25f, string layer="Lyrics", float space = 1f)
        {
            // Échelle des caractères
            float startY = LetterY - 15; // Position de départ pour l'animation du haut vers le bas
            float endY = LetterY + 15;   // Position de fin pour l'animation du bas
            int index = 0;
            int delay = 10; // Décalage entre chaque lettre
            int ghostDelay = 40; // Décalage de l'effet rémanent

            float lineWidth = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }
            LetterX -= lineWidth/2;      

            var gradbar = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320+1, LetterY+30));
                gradbar.Fade(startTime, startTime + 300, 0, 1); gradbar.Fade(OsbEasing.OutSine, endTime - 300, endTime, 1, 0);
                gradbar.ScaleVec(OsbEasing.OutSine, startTime, startTime + 300, 0, 2, lineWidth-70, 2);
                gradbar.ScaleVec(OsbEasing.InSine, endTime - 300, endTime, lineWidth-70, 2, 0, 2);
                gradbar.Color(startTime, new Color4(30, 0, 0, 1));

            var gradbar2 = GetLayer(layer).CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320+1, LetterY-35));
                gradbar2.Fade(startTime, startTime + 300, 0, 1); gradbar2.Fade(OsbEasing.OutSine, endTime - 300, endTime, 1, 0);
                gradbar2.ScaleVec(OsbEasing.OutSine, startTime, startTime + 300, 0, 2, lineWidth-70, 2);
                gradbar2.ScaleVec(OsbEasing.InSine, endTime - 300, endTime, lineWidth-70, 2, 0, 2);
                gradbar2.Color(startTime, new Color4(30, 0, 0, 1));

            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());

                if (!texture.IsEmpty)
                {
                    int letterDelay = 0; //index * delay; // Décalage spécifique pour chaque lettre
                    var startPosition = new Vector2(LetterX, startY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var finalPosition = new Vector2(LetterX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var exitPosition = new Vector2(LetterX, endY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, finalPosition);
                    
                    // Apparition en fondu et déplacement du haut vers le bas avec retard
                    sprite.Fade(startTime + letterDelay, startTime + 100 + letterDelay, 0, 1);
                    //sprite.MoveY(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, startY, LetterY);
                    
                    // Maintien du texte visible
                    sprite.Fade(startTime + 100 + letterDelay, endTime - 300 + letterDelay, 1, 1);
                    
                    // Disparition en déplacement vers le bas et en fondu avec retard
                    //sprite.MoveY(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, LetterY, endY);
                    sprite.Fade(endTime - 300 + letterDelay, endTime + letterDelay, 1, 0);
                    
                    sprite.Scale(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, scale*0.5f, scale);
                    sprite.Scale(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, scale, scale*0.5f);
                    sprite.Color(startTime + letterDelay, new Color4(30, 0, 0, 1));
                }
                
                // Déplacement vers la droite après chaque lettre
                LetterX += texture.BaseWidth * scale * space;
                index++;
            }
        }

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, float LetterX = 320, float LetterY = 395, float scale = 0.25f, string layer="Lyrics", float space = 1f)
        {
            // Échelle des caractères
            float startY = LetterY - 15; // Position de départ pour l'animation du haut vers le bas
            float endY = LetterY + 15;   // Position de fin pour l'animation du bas
            int index = 0;
            int delay = 10; // Décalage entre chaque lettre
            int ghostDelay = 40; // Décalage de l'effet rémanent

            float lineWidth = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }
            LetterX -= lineWidth/2;      

            if(scale<0.4f)
            {   
                var bg = GetLayer("Lyrics").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, LetterY+2));
                    bg.Color(startTime, text=="Крики просветлённых птиц" ? new Color4(30,0,0,1) : new Color4(0,0,0,1));
                    bg.Fade(OsbEasing.OutSine, startTime, startTime + 300, 0, 0.8);
                    bg.ScaleVec(OsbEasing.OutSine, startTime, startTime + 600, 0, 30, lineWidth + 10, 30);
                    bg.Fade(OsbEasing.OutSine, endTime - 300, endTime, 0.7, 0);
            }
            

            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());

                if (!texture.IsEmpty)
                {
                    int letterDelay = 0; //index * delay; // Décalage spécifique pour chaque lettre
                    var startPosition = new Vector2(LetterX, startY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var finalPosition = new Vector2(LetterX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var exitPosition = new Vector2(LetterX, endY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, finalPosition);
                    
                    // Apparition en fondu et déplacement du haut vers le bas avec retard
                    sprite.Fade(startTime + letterDelay, startTime + 100 + letterDelay, 0, 1);
                    //sprite.MoveY(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, startY, LetterY);
                    
                    // Maintien du texte visible
                    sprite.Fade(startTime + 100 + letterDelay, endTime - 300 + letterDelay, 1, 1);
                    
                    // Disparition en déplacement vers le bas et en fondu avec retard
                    //sprite.MoveY(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, LetterY, endY);
                    sprite.Fade(endTime - 300 + letterDelay, endTime + letterDelay, 1, 0);
                    
                    sprite.Scale(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, scale*0.5f, scale);
                    sprite.Scale(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, scale, scale*0.5f);
                    sprite.Color(startTime + letterDelay, (text=="Крики просветлённых птиц")||(startTime==74953) ? new Color4(30,0,0,1) : new Color4(246, 241, 238, 1));
                }
                
                // Déplacement vers la droite après chaque lettre
                LetterX += texture.BaseWidth * scale * space;
                index++;
            }
        }

        public void LyricsJP(int startTime, int endTime, string text, FontGenerator font, float LetterX = 320, float LetterY = 274, float scale = 0.18f, float space = 0.65f)
        {
            // Échelle des caractères
            float startX = LetterX + 15; // Position de départ pour l'animation de droite à gauche
            float endX = LetterX - 15;   // Position de fin pour l'animation de gauche
            int index = 0;
            int delay = 25; // Décalage entre chaque lettre
            int ghostDelay = 40; // Décalage de l'effet rémanent

            float lineHeight = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineHeight += texture.BaseHeight * scale * space;
            }

            if(scale<0.61f)
            {   
                var bg = GetLayer("Lyrics").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(LetterX, LetterY + (lineHeight / 2) - 10));
                    bg.Color(startTime, new Color4(0,0,0,1));
                    bg.Fade(OsbEasing.OutSine, startTime, startTime + 300, 0, 0.6);
                    bg.ScaleVec(OsbEasing.OutSine, startTime, startTime + 600, 25, 0, 25, lineHeight + 10);
                    bg.Fade(OsbEasing.OutSine, endTime - 300, endTime, 0.6, 0);
            }

            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());

                if (!texture.IsEmpty)
                {
                    int letterDelay = index * delay;
                    var startPosition = new Vector2(startX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var finalPosition = new Vector2(LetterX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var exitPosition = new Vector2(endX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                    string layer = "Lyrics";

                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, startPosition);
                    
                    // Apparition en fondu et déplacement de droite à gauche avec retard
                    sprite.Fade(startTime + letterDelay, startTime + 100 + letterDelay, 0, 1);
                    sprite.MoveX(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, startX, LetterX);
                    
                    // Maintien du texte visible
                    sprite.Fade(startTime + 100 + letterDelay, endTime - 300 + letterDelay, 1, 1);
                    
                    // Disparition en déplacement vers la gauche et en fondu avec retard
                    sprite.MoveX(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, LetterX, endX);
                    sprite.Fade(endTime - 300 + letterDelay, endTime + letterDelay, 1, 0);
                    
                    sprite.Scale(startTime + letterDelay, scale);
                    sprite.Color(startTime + letterDelay, new Color4(246, 241, 238, 1));
                }
                
                // Déplacement vers le bas après chaque lettre
                LetterY += texture.BaseHeight * scale * space;
                index++;
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
