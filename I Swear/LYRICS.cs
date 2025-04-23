using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
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
    public class LYRICS : StoryboardObjectGenerator
    {
        FontGenerator Font;

        FontGenerator FontTitle;

        public override void Generate()
        {
		    Font = SetFont("Lyrics", "SawarabiMincho-Regular.ttf");
            FontTitle = SetFont("Title", "SawarabiGothic-Regular.ttf"); 


            //

            //

            //
            
            LyricsJP(26548, 37817, "少しぼやけた輪郭", Font, 130); LyricsJP(32093, 37817, "ピント合わせるみたいに", Font, 80);
            LyricsJP(37996, 48174, "隠し続けた不安も痛みも", Font, 540); LyricsJP(43531, 48174, "全部あなたに預けた", Font, 490);
            
            LyricsJP(48710, 51567, "迷わず行ける", Font, 390); LyricsJP(50138, 51567, "あなたとなら", Font, 250, 300);
            LyricsJP(51567, 54424, "捧げられる", Font, 390); LyricsJP(52996, 54424, "あなたになら", Font, 250, 300);
            LyricsJP(54424, 60496, "どんな時も側にいると", Font, 390); LyricsJP(57460, 60496, "感じてるから", Font, 250, 300);

            Lyrics(60853, 63710, "デート", FontTitle, 128, 367, 0.60f); Lyrics(61924, 63710, "・ア・ライブ", FontTitle, 416, 367, 0.60f);

            Lyrics(63710, 65853, "甘く口づけて once again", Font);
            Lyrics(65853, 69443, "瞼 そっと下ろした瞬間", Font);
            Lyrics(69443, 74970, "どこかで交わる視線 後に戻れなくなる", Font);
            Lyrics(74970, 77290, "似てるけど違う memory", Font);
            Lyrics(77290, 80683, "いつか I swear 描いた景色", Font);
            Lyrics(80683, 83898, "此処にある今と違う未来", Font);
            Lyrics(83898, 86559, "気付き始める", Font); 
            Lyrics(86559, 92268, "何度でも出会い 廻るこの世界で", Font);
            Lyrics(92268, 99075, "私たちの戦争始めましょう", Font);
    
            LyricsJP(105148, 116398, "少し不思議な感覚", Font, 130); LyricsJP(110683, 116398, "ふわり流れるみたいに", Font, 80);
            LyricsJP(116576, 126762, "溢れ出してしまいそうな気持ち", Font, 540, 274, 0.145f); LyricsJP(122112, 126762, "ひとり抱え込まないで", Font, 490);

            LyricsJP(127294, 130146, "越えて行ける", Font, 390); LyricsJP(128718, 130146, "あなたならば", Font, 250, 300);
            LyricsJP(130146, 133003, "見せてあげる", Font, 390); LyricsJP(131575, 133003, "あなただから", Font, 250, 300);
            LyricsJP(133003, 139075, "どんな声も届いてると", Font, 390); LyricsJP(136039, 139075, "信じられるの", Font, 250, 300);

            Lyrics(139432, 142289, "デート", FontTitle, 128, 367, 0.60f); Lyrics(140503, 142289, "・ア・ライブ", FontTitle, 416, 367, 0.60f);

            Lyrics(142289, 144432, "淡く色付いた once again", Font);
            Lyrics(144432, 148003, "心 やっと触れ合う瞬間", Font);
            Lyrics(148003, 150146, "どこかに紛れた真実", Font);
            Lyrics(150146, 153539, "触れる前にわかるの", Font);
            Lyrics(153539, 155861, "失いたくない memory", Font);
            Lyrics(155861, 159421, "いつか I swear 芽生えた決意", Font);
            Lyrics(159421, 161564, "上手く言葉に出来ない", Font); 
            Lyrics(161564, 165135, "だけど確実なもの", Font);
            Lyrics(165135, 170850, "あなたの温もり 決して諦めない", Font);
            Lyrics(170850, 176034, "私たちの戦争始めましょう", Font); 

            LyricsJP(176573, 182116, "見つめてる過去", Font, 390); LyricsJP(179259, 182116, "此処にある今", Font, 250, 300);
            LyricsJP(182116, 187830, "変わるかもしれない未来", Font, 320);
            LyricsJP(187830, 193187, "どんな絶望にも", Font, 390); LyricsJP(190687, 193187, "どんな希望にも", Font, 250, 300);
            LyricsJP(193187, 199259, "優しく笑うあなたのように", Font, 390, 274, 0.17f); LyricsJP(196044, 199259, "居られたら", Font, 250, 300);

            LyricsJP(199436, 204942, "今より少し", Font, 130); LyricsJP(202105, 204942, "ほんの少しだけ", Font, 80);
            LyricsJP(204942, 210663, "悲しみのない世界があって", Font, 130, 274, 0.17f);
            LyricsJP(210838, 216027, "消えない傷が", Font, 540); LyricsJP(213536, 216027, "癒えたとしても", Font, 490);
            LyricsJP(216027, 222096, "繋いだ手を離したりしないで", Font, 540, 274, 0.155f);

            LyricsJP(248010, 253546, "誰より大切な", Font, 390); LyricsJP(250689, 253546, "あなたを護りたい", Font, 250, 300);
            LyricsJP(253546, 259082, "あなたの側でずっと", Font, 390); LyricsJP(256403, 259082, "wanna feel alive", Font, 250, 274, 0.14f, 0.60f);
            
            
            Lyrics(259424, 261566, "甘く口づけて once again", Font);
            Lyrics(261566, 265138, "瞼 そっと下ろした瞬間", Font);
            Lyrics(265138, 267281, "どこかで交わる視線", Font);
            Lyrics(267281, 270683, "後に戻れなくなる", Font);

            Lyrics(270683, 272991, "似てるけど違う memory", Font);
            Lyrics(272991, 276400, "いつか I swear 描いた景色", Font);
            Lyrics(276400, 279611, "此処にある今と違う未来", Font); 
            Lyrics(279611, 282107, "気付き始める", Font);
            Lyrics(282107, 287816, "何度でも出会い 廻るこの世界で", Font);
            Lyrics(287816, 294781, "私たちの戦争始めましょう", Font); 
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

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, float LetterX = 320, float LetterY = 367, float scale = 0.34f, float space = 1f)
        {
            // Échelle des caractères
            float startY = LetterY - 15; // Position de départ pour l'animation du haut vers le bas
            float endY = LetterY + 15;   // Position de fin pour l'animation du bas
            int index = 0;
            int delay = 25; // Décalage entre chaque lettre
            int ghostDelay = 40; // Décalage de l'effet rémanent

            float lineWidth = 0;
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }
            LetterX -= lineWidth/2;      

            if(scale<0.6f)
            {   
                var bg = GetLayer("Lyrics").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 366));
                    bg.Color(startTime, new Color4(0,0,0,1));
                    bg.Fade(OsbEasing.OutSine, startTime, startTime + 300, 0, 0.6);
                    bg.ScaleVec(OsbEasing.OutSine, startTime, startTime + 600, 0, 50, lineWidth + 10, 50);
                    bg.Fade(OsbEasing.OutSine, endTime - 300, endTime, 0.6, 0);
            }
            

            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());

                if (!texture.IsEmpty)
                {
                    int letterDelay = index * delay; // Décalage spécifique pour chaque lettre
                    var startPosition = new Vector2(LetterX, startY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var finalPosition = new Vector2(LetterX, LetterY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;
                    var exitPosition = new Vector2(LetterX, endY)
                        + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                    string layer = "Lyrics";
                    
                    // Effet rémanent (sprite bleu en décalé)
                    var ghostSprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, startPosition);
                    
                    ghostSprite.Fade(startTime + letterDelay + ghostDelay, startTime + 100 + letterDelay + ghostDelay, 0, 0.5);
                    ghostSprite.MoveY(OsbEasing.OutSine, startTime + letterDelay + ghostDelay, startTime + 300 + letterDelay + ghostDelay, startY, LetterY);
                    
                    ghostSprite.Fade(startTime + 100 + letterDelay + ghostDelay, endTime - 300 + letterDelay + ghostDelay, 0.5, 0.5);
                    
                    ghostSprite.MoveY(OsbEasing.InSine, endTime - 300 + letterDelay + ghostDelay, endTime + letterDelay + ghostDelay, LetterY, endY);
                    ghostSprite.Fade(endTime - 300 + letterDelay + ghostDelay, endTime + letterDelay + ghostDelay, 0.5, 0);
                    
                    ghostSprite.Scale(startTime + letterDelay + ghostDelay, scale);
                    ghostSprite.Color(startTime + letterDelay + ghostDelay, new Color4(255, 0, 0, 1));

                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, startPosition);
                    
                    // Apparition en fondu et déplacement du haut vers le bas avec retard
                    sprite.Fade(startTime + letterDelay, startTime + 100 + letterDelay, 0, 1);
                    sprite.MoveY(OsbEasing.OutSine, startTime + letterDelay, startTime + 300 + letterDelay, startY, LetterY);
                    
                    // Maintien du texte visible
                    sprite.Fade(startTime + 100 + letterDelay, endTime - 300 + letterDelay, 1, 1);
                    
                    // Disparition en déplacement vers le bas et en fondu avec retard
                    sprite.MoveY(OsbEasing.InSine, endTime - 300 + letterDelay, endTime + letterDelay, LetterY, endY);
                    sprite.Fade(endTime - 300 + letterDelay, endTime + letterDelay, 1, 0);
                    
                    sprite.Scale(startTime + letterDelay, scale);
                    sprite.Color(startTime + letterDelay, new Color4(246, 241, 238, 1));
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

                    // Effet rémanent (sprite bleu en décalé)
                    var ghostSprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, startPosition);
                    
                    ghostSprite.Fade(startTime + letterDelay + ghostDelay, startTime + 100 + letterDelay + ghostDelay, 0, 0.5);
                    ghostSprite.MoveX(OsbEasing.OutSine, startTime + letterDelay + ghostDelay, startTime + 300 + letterDelay + ghostDelay, startX, LetterX);
                    
                    ghostSprite.Fade(startTime + 100 + letterDelay + ghostDelay, endTime - 300 + letterDelay + ghostDelay, 0.5, 0.5);
                    
                    ghostSprite.MoveX(OsbEasing.InSine, endTime - 300 + letterDelay + ghostDelay, endTime + letterDelay + ghostDelay, LetterX, endX);
                    ghostSprite.Fade(endTime - 300 + letterDelay + ghostDelay, endTime + letterDelay + ghostDelay, 0.5, 0);
                    
                    ghostSprite.Scale(startTime + letterDelay + ghostDelay, scale);
                    ghostSprite.Color(startTime + letterDelay + ghostDelay, new Color4(255, 0, 0, 1));

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
    }
}
