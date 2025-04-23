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

        FontGenerator Font;

        FontGenerator FontBold;

        public override void Generate()
        {
            var back1 = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                back1.ScaleVec(734893, 854.0f, 114.0f);
                back1.Color(734893, Color4.Black);
                back1.Fade(157, 1); back1.Fade(10591, 0); back1.Fade(1701048, 1); back1.Fade(1705548, 0);

		    var playfield = GetLayer("Playfield").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 140));
                playfield.ScaleVec(157, 854.0f, 114.0f);
                playfield.Color(157, colorBlack);
                playfield.Fade(157, 10591, 0, 0.9); playfield.Fade(10591, 1); playfield.Fade(1701048, 1705548, 1, 0);
            
            var back2 = GetLayer("TaikoTop").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                back2.ScaleVec(734893, 854.0f, 140.0f);
                back2.Color(734893, Color4.Black);
                back2.Fade(157, 1); back2.Fade(10591, 0); back2.Fade(1701048, 1); back2.Fade(1705548, 0);

            var top = GetLayer("TaikoTop").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                top.ScaleVec(157, 854.0f, 140.0f);
                top.Color(157, new Color4(14, 14, 23, 1));
                top.Fade(157, 10591, 0, 0.9); top.Fade(10591, 1);
                top.Fade(31461, 0); top.Fade(52330, 1);
                top.Fade(73200, 0); top.Fade(94070, 1);
                top.Fade(152127, 0); top.Fade(162233, 1);
                top.Fade(164759, 0); top.Fade(192864, 1);
                top.Fade(255282, 0); top.Fade(285518, 1);
                top.Fade(341471, 0); top.Fade(362552, 1);
                top.Fade(396173, 0); top.Fade(420947, 1);
                top.Fade(453123, 0); top.Fade(479976, 1);
                top.Fade(506829, 0); top.Fade(533682, 1);
                top.Fade(594469, 0); top.Fade(611969, 1);
                top.Fade(634469, 0); top.Fade(651969, 1);
                top.Fade(695956, 0); top.Fade(715648, 1);
                top.Fade(735341, 0); top.Fade(755033, 1);
                top.Fade(774725, 0); top.Fade(794418, 1);

                top.Fade(839887, 0); top.Fade(853800, 1);
                top.Fade(881626, 0); top.Fade(909452, 1);

                top.Fade(966515, 0); top.Fade(977678, 1);
                top.Fade(1000003, 0); top.Fade(1022329, 1);

                top.Fade(1094755, 0); top.Fade(1116698, 1);
                top.Fade(1138641, 0); top.Fade(1160584, 1);

                top.Fade(1221763, 0); top.Fade(1241974, 1);
                top.Fade(1272290, 0); top.Fade(1302132, 1);

                top.Fade(1353912, 0); top.Fade(1376368, 1);
                top.Fade(1410052, 0); top.Fade(1432508, 1);

                top.Fade(1544464, 0); top.Fade(1560874, 1);

                top.Fade(1623048, 0); top.Fade(1647048, 1);
                top.Fade(1677048, 0); top.Fade(1701048, 1);

                top.Fade(1701048, 1705548, 1, 0);

            var topRed = GetLayer("TaikoTopRed").CreateSprite("sb/pixel.png", OsbOrigin.TopCentre, new Vector2(320, 0));
                topRed.ScaleVec(31461, 854.0f, 140.0f);
                topRed.Color(31461, new Color4(42, 14, 23, 1));
                topRed.Fade(31461, 1); topRed.Fade(52330, 0);
                topRed.Fade(73200, 1); topRed.Fade(94070, 0);
                topRed.Fade(152127, 1); topRed.Fade(162233, 0);
                topRed.Fade(164759, 1); topRed.Fade(192864, 0);
                topRed.Fade(255282, 1); topRed.Fade(285518, 0);
                topRed.Fade(341471, 1); topRed.Fade(362552, 0);
                topRed.Fade(396173, 1); topRed.Fade(420947, 0);
                topRed.Fade(453123, 1); topRed.Fade(479976, 0);
                topRed.Fade(506829, 1); topRed.Fade(533682, 0);
                topRed.Fade(594469, 1); topRed.Fade(611969, 0);
                topRed.Fade(634469, 1); topRed.Fade(651969, 0);
                topRed.Fade(695956, 1); topRed.Fade(715648, 0);
                topRed.Fade(735341, 1); topRed.Fade(755033, 0);
                topRed.Fade(774725, 1); topRed.Fade(794418, 0);

                topRed.Fade(839887, 1); topRed.Fade(853800, 0);
                topRed.Fade(881626, 1); topRed.Fade(909452, 0);

                topRed.Fade(966515, 1); topRed.Fade(977678, 0);
                topRed.Fade(1000003, 1); topRed.Fade(1022329, 0);

                topRed.Fade(1094755, 1); topRed.Fade(1116698, 0);
                topRed.Fade(1138641, 1); topRed.Fade(1160584, 0);

                topRed.Fade(1221763, 1); topRed.Fade(1241974, 0);
                topRed.Fade(1272290, 1); topRed.Fade(1302132, 0);

                topRed.Fade(1353912, 1); topRed.Fade(1376368, 0);
                topRed.Fade(1410052, 1); topRed.Fade(1432508, 0);

                topRed.Fade(1544464, 1); topRed.Fade(1560874, 0);

                topRed.Fade(1623048, 1); topRed.Fade(1647048, 0);
                topRed.Fade(1677048, 1); topRed.Fade(1701048, 0);

            var bgPath = Beatmap.BackgroundPath;
            var bgBitmap = GetMapsetBitmap(bgPath);
            var bgScale = 854.0f / bgBitmap.Width;
            int bgYCenter = 77 + (480/2); 

		    var bg = GetLayer("Background").CreateSprite(bgPath, OsbOrigin.Centre, new Vector2(320, bgYCenter));
                bg.Scale(157, bgScale);
                bg.Fade(157, 10591, 0, 0.9); bg.Fade(10591, 1); bg.Fade(1701048, 1705548, 1, 0);
                revolve(157, 1705548, bg, 0, 128, 320, bgYCenter, 0, 10);

            var vignetteBitmap = GetMapsetBitmap("sb/masks/vignette.png");
            var vignette = GetLayer("Vignette").CreateSprite("sb/masks/vignette.png", OsbOrigin.TopCentre, new Vector2(320, 254));
                vignette.ScaleVec(157, 854.0f / vignetteBitmap.Width, (480 - 254.0f) / vignetteBitmap.Height);
                vignette.Fade(157, 10591, 0, 0.9); vignette.Fade(10591, 1); vignette.Fade(1701048, 1705548, 1, 0);
                vignette.Color(157, colorBlack);

            Font = SetFont("Lyrics", "Nunito-ExtraLight.ttf");
            FontBold = SetFont("Titles", "RubikMonoOne-Regular.ttf");

            int[] song1 = { 10873, 12341, 15112, 18699, 21308, 23754, 26363, 28971,
                            31417, 34026, 36634, 39243, 41852, 44460, 47069, 49678,
                            52612, 54243, 56526, 60276, 63047, 65656, 68265, 70547,
                            73156, 75765, 78373, 80982, 83591, 86199, 88808, 91417, 
                            94026, 96634 };
            for(int i=0; i<34; i++)
            {
                song1[i] += 8+36;
            }
            readLyrics(song1, "падик", 10591, 99075, (2765-157)/8);
            
            int[] song2 = { 121461, 124934, 127461, 129987, 132513, 135039, 137566, 140092,
                            142618, 145461, 147671, 150513, 152724, 155882, 157776, 160618,
                            162829, 165671, 167882, 169145, 171355, 176408, 181461, 186513, 
                            191566, 193145};
            for(int i=0; i<26; i++)
            {
                song2[i] += 36;
            }
            readLyrics(song2, "весна", 99075, 194337, (101602-99075)/8);

            int[] song3 = { 194302, 199262, 203041, 206585, 225482, 229498, 233277, 237057,
                            240600, 244380, 248159, 250049, 251939, 254773, 259734,
                            263514, 267057, 271073, 274852, 278632, 282175, 286427};
            for(int i=0; i<22; i++)
            {
                song3[i] += 36;
            }
            readLyrics(song3, "молчи", 194337, 289579, (198589-194809)/8);

            int[] song4 = { 296026, 297648, 299269, 300891, 315485, 316296, 319742, 322985,
                            326431, 328458, 332715, 335958, 337580, 341431, 344877, 347918,
                            351364, 354404, 357850, 360891, 364134};
            for(int i=0; i<21; i++)
            {
                song4[i] += 36;
            }
            readLyrics(song4, "тиндер", 289579, 364432, (292823-289579)/8);

            int[] song5 = { 371353, 374643, 377740, 380837, 384127, 390321, 395160, 398256,
                            401353, 407547, 410643, 413740, 420901};
            for(int i=0; i<13; i++)
            {
                song5[i] += 36;
            }
            readLyrics(song5, "девочка-мальчик", 364432, 426269, (367528-364432)/8);

            int[] song6 = { 426643, 430210, 433566, 436923, 440070, 442587, 445944, 449300,
                            452237, 455175, 458531, 462307, 465454, 468601, 471958, 474895,
                            480349, 483916, 487272, 490629, 493776, 496293, 499650, 503007,
                            505944, 508881, 512237, 516014, 518951, 522307, 525664, 529021,
                            532797};
            for(int i=0; i<33; i++)
            {
                song6[i] += 10+36;
            }
            readLyrics(song6, "когда я умру", 426269, 554156, (429626-426269)/8);

            int[] song7 = { 574746, 577246, 579746, 583184, 584746, 587246, 589746, 593652,
                            598184, 600684, 603809, 608184, 614746, 617246, 619746, 623496,
                            624746, 627246, 629746, 633809, 638184, 640684, 643809, 648184,
                            652246};
            for(int i=0; i<25; i++)
            {
                song7[i] += 36;
            }
            readLyrics(song7, "подруга", 554156, 654156, (556657-554156)/8);

            int[] song8 = { 675725, 678187, 680648, 683648, 685572, 688033, 690495, 692725, 
                            695648, 698110, 700572, 703033, 705495, 707956, 710418, 712879,
                            715110, 717572, 720033, 722187, 724956, 727418, 730110, 732879,
                            735033, 737495, 739956, 742418, 744879, 747341, 749802, 752264,
                            764572, 767341};
            readLyrics(song8, "не учи", 654156, 798148, (656572-654157)/8);

            int[] song9 = { 812387, 815756, 819234, 822713, 826191, 828800, 833148, 836626,
                            840213, 842930, 846408, 849887, 
                            854234, 857495, 860974, 864452, 867713, 871191, 874887, 878365,
                            882061, 884669, 888148, 891626, 895104, 898582, 902061, 905539,
                            909452};
            readLyrics(song9, "друзья", 798148, 916283, (801626-798148)/8);

            int[] song10 = {933724, 936341, 939306, 941922, 944364, 947503, 950294, 953085,
                            954655, 957969, 960236, 963550, 965817, 969131, 971399, 974713,
                            978376, 980992, 983957, 986573, 989364, 991980, 994771, 997736,
                            999306, 1002620, 1004887, 1008201, 1010469, 1013783, 1016050, 1019364,
                            1043957, 1047445};
            readLyrics(song10, "лбтд", 916283, 1050869, (919073-916283)/8); 

            int[] song11 = {1072812, 1075555, 1078298, 1081041, 1083784, 1086527, 1089270, 1092012,
                            1094755, 1098527, 1101270, 1104355, 1106755, 1109498, 1112241,
                            1117727, 1119441, 1122184, 1124927, 1127670, 1130412, 1133155, 1135898,
                            1138641, 1142412, 1145155, 1148241, 1150641, 1153384, 1156127, 
                            1161270};
            readLyrics(song11, "грязь", 1050869, 1176290, (1053612-1050869)/8);

            int[] song12 = {1191763, 1194290, 1196816, 1201868, 1204395, 1206921, 1211974, 1214500, 1217026, 1219553,
                            1221447, 1225553, 1228079, 1230605, 1231553, 1235658, 1238184, 1240711,
                            1242290, 1244816, 1247342, 1252395, 1254921, 1257447, 1262500, 1265026, 1267553, 1270079,
                            1271974, 1276079, 1278605, 1281132, 1282079, 1286184, 1288711, 1291237,
                            1292816, 1295342, 1297868, 1300395, 1302290, 1306395};
            readLyrics(song12, "игрушка", 1176290, 1309000, (1178816-1176290)/8); 

            int[] song13 = {1320929, 1323736, 1326543, 1329350, 1332157, 1334964, 1337596, 1340578,
                            1342684, 1345491, 1348298, 1351105,
                            1353912, 1355140, 1357947, 1360754, 1363561, 1365140, 1366368, 1369175, 1371982, 1374964,
                            1377070, 1379877, 1382684, 1385491, 1388298, 1391105, 1393912, 1396719,
                            1398824, 1401631, 1404438, 1407245,
                            1410052, 1411280, 1414087, 1416894, 1419701, 1421280, 1422508, 1425315, 1428122, 1431105,
                            1432508, 1442333, 
                            1454964, 1456192, 1459175};
            readLyrics(song13, "мелочь", 1309000, 1462412, (1311807-1309000)/8);

            int[] song14 = {1463951, 1465105, 1466259, 
                            1478823, 1480874, 1481900, 1487028, 1489079, 1490105, 1495233, 1497284, 1498310, 
                            1501002, 1503054, 1505105, 1509207, 1511259, 1513310,
                            1515746, 1517797, 1523951, 1526002, 1532156, 1534207,
                            1537925, 1539977, 1542028, 
                            1544464, 1547156, 1549207, 1551259, 1552669, 1555361, 1557412, 1559464,
                            1562156, 1563951};
            readLyrics(song14, "рэпер", 1462412, 1568052, (1464464-1462412)/8);

            int[] song15 = {1568052, 1571298, 1574298, 1576923, 1578798,
                            1593048, 1595861, 1598298, 1599798, 1601298, 1602236, 1605048, 1607861, 1609923, 1613298, 
                            1617048, 1618173, 1619673,
                            1622298, 1625298, 1628298, 1630923, 1632798, 1635048, 1637298, 1640298, 1642923, 1644798,
                            1647048, 1650048, 1652298, 1655673, 1659048, 1662048, 1664298, 1665798, 1667673, 
                            1671048, 1672173, 1673673,
                            1676298, 1679298, 1682298, 1684923, 1686798, 1689048, 1691298, 1694298, 1696923, 1698798,
                            1701048, 1703298};
            readLyrics(song15, "жиза", 1568052, 1701048, (1572048-1569048)/8);
        }

        public void readLyrics(int[] timings, string song, int startTime, int endTime, int beat)
        {     
            var bar = GetLayer("Loading").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(87, 120));
                bar.StartLoopGroup(startTime, (int)((endTime - startTime) / (beat*2)));
                    bar.MoveX(0, beat*2, 87, 60);
                    bar.ScaleVec(OsbEasing.InCubic, 0, beat*2, 0.6, 12, 0.6, 3);
                    bar.Color(OsbEasing.InCubic, 0, beat*2, Color4.White, new Color4(14, 14, 23, 1));
                    bar.Fade(0, beat*2, 1, 1);
                bar.EndGroup();

            var bar2 = GetLayer("Loading").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(553, 120));
                bar2.StartLoopGroup(startTime, (int)((endTime - startTime) / (beat*2)));
                    bar2.MoveX(0, beat*2, 553, 580);
                    bar2.ScaleVec(OsbEasing.InCubic, 0, beat*2, 0.6, 12, 0.6, 3);
                    bar2.Color(OsbEasing.InCubic, 0, beat*2, Color4.White, new Color4(14, 14, 23, 1));
                    bar2.Fade(0, beat*2, 1, 1);
                bar2.EndGroup();

            var outline = GetLayer("Loading").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 120));
                outline.ScaleVec(startTime, 468, 12);
                outline.Color(startTime, Color4.White);
                outline.Fade(startTime, startTime+150, 0, 1);
                outline.Fade(startTime+150, endTime-150, 1, 1);
                outline.Fade(endTime-150, endTime, 1, 0);

            var inline = GetLayer("Loading").CreateSprite("sb/pixel.png", OsbOrigin.Centre, new Vector2(320, 120));
                inline.ScaleVec(startTime, 466, 10);
                inline.Color(startTime, new Color4(14, 14, 23, 1));
                inline.Fade(startTime, startTime+150, 0, 1);
                inline.Fade(startTime+150, endTime-150, 1, 1);
                inline.Fade(endTime-150, endTime, 1, 0);

            var loading = GetLayer("Loading").CreateSprite("sb/pixel.png", OsbOrigin.BottomLeft, new Vector2(87, 125));
                loading.ScaleVec(startTime, endTime, 0, 10, 466, 10);
                loading.Color(startTime, Color4.Orange);
                loading.Fade(startTime, startTime+150, 0, 1);
                loading.Fade(startTime+150, endTime-150, 1, 1);
                loading.Fade(endTime-150, endTime, 1, 0);

                loading.StartLoopGroup(startTime, (int)((endTime - startTime) / (beat*8)));
                    loading.Color(OsbEasing.InSine, 0, beat*4, Color4.Orange, new Color4(240, 122, 18, 1));
                    loading.Color(OsbEasing.OutSine, beat*4, beat*8, new Color4(240, 122, 18, 1), Color4.Orange);
                loading.EndGroup();

            var cursorOutline = GetLayer("Loading").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, new Vector2(87, 120));
                cursorOutline.Scale(startTime, 0.03);
                cursorOutline.MoveX(startTime, endTime, 87, 553);
                cursorOutline.Rotate(startTime, endTime, 0, 48);
                cursorOutline.Color(startTime, Color4.White);
                cursorOutline.Fade(startTime, startTime+150, 0, 1);
                cursorOutline.Fade(startTime+150, endTime-150, 1, 1);
                cursorOutline.Fade(endTime-150, endTime, 1, 0);

                cursorOutline.StartLoopGroup(startTime, (int)((endTime - startTime) / beat));
                    cursorOutline.Scale(0, beat, 0.037, 0.03);
                cursorOutline.EndGroup();

            var cursor = GetLayer("Loading").CreateSprite("sb/geometry/hex.png", OsbOrigin.Centre, new Vector2(87, 120));
                cursor.Scale(startTime, 0.027);
                cursor.MoveX(startTime, endTime, 87, 553);
                cursor.Rotate(startTime, endTime, 0, 48);
                cursor.Color(startTime, new Color4(14, 14, 23, 1));
                cursor.Fade(startTime, startTime+150, 0, 1);
                cursor.Fade(startTime+150, endTime-150, 1, 1);
                cursor.Fade(endTime-150, endTime, 1, 0);

                cursor.StartLoopGroup(startTime, (int)((endTime - startTime) / beat));
                    cursor.Scale(0, beat, 0.034, 0.027);
                cursor.EndGroup();

            Lyrics(startTime, endTime, song, FontBold, true);
            using (var stream = OpenProjectFile(song + ".txt"))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                string line;
                int i=0;

                while (reader.Peek() >=0)
                {
                    line = reader.ReadLine();
                    FontGenerator font = Font;
                    if(timings[i+1] - timings[i] >= 13000)
                        Lyrics(timings[i], timings[i] + 4000, line, font, false);
                    else if(timings[i] == 608220)
                        Lyrics(timings[i], timings[i] + 4000, line, font, false);
                    else if(timings[i] == 1481900 || timings[i] == 1490105)
                        Lyrics(timings[i], timings[i] + 2000, line, font, false);
                    else if(timings[i+1] - timings[i] >= 5500)
                        Lyrics(timings[i], timings[i] + 2500, line, font, false);
                    else
                        Lyrics(timings[i], timings[i+1], line, font, false);

                    i++;
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

        public void Lyrics(int startTime, int endTime, string text, FontGenerator font, bool title)
        {
            float LetterY = title ? 88 : 430;

            //For each line we're gonna set a base position to X = PosX & Y = PosY
            //and also a scale that is set to 0.3 to not have stretched up sprites!
            float scale = title ? 0.35f : 0.22f;
            float lineWidth = 0;

            float LetterX = 320;
            //We center the line
            foreach(var letter in text)
            {   
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
            }
            LetterX -= lineWidth/2;
            
            if(!title)
            {
                int xOffset = 8;
                var box = GetLayer("LyricsBox").CreateSprite("sb/pixel.png", OsbOrigin.CentreLeft, new Vector2(LetterX - xOffset/2, LetterY + 1));
                    box.ScaleVec(startTime, lineWidth+xOffset, 28);
                    box.Color(startTime, colorBlack);
                    box.Fade(startTime, startTime+100, 0, 0.9);
                    box.Fade(startTime+100, endTime-100, 0.9, 0.9);
                    box.Fade(endTime-100, endTime, 0.9, 0);
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
                    string layer = title ? "Titles" : "Lyrics";
                    var sprite = GetLayer(layer).CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        if(title == false)
                        {
                            sprite.Fade(startTime, startTime+100, 0, 1);
                            sprite.Fade(startTime+100, endTime-100, 1, 1);
                            sprite.Fade(endTime-100, endTime, 1, 0);
                        }
                        else
                        {
                            sprite.MoveX(OsbEasing.OutSine, startTime, startTime + 500, 320, position.X);
                            sprite.Fade(startTime, startTime+500, 0, 1);
                            sprite.Fade(startTime+500, endTime-100, 1, 1);
                            sprite.MoveX(OsbEasing.InSine, endTime-250, endTime, position.X, 320);
                            sprite.Fade(endTime-100, endTime, 1, 0);
                        }

                        sprite.Scale(startTime, scale);
                        sprite.Color(startTime, new Color4(246,241,238,1));
                }
                //don't forget to move your letter position after each new letter!
                LetterX += texture.BaseWidth * scale;
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

                sprite.MoveX(Easings[m%2], startTime, endTime, XValues[m], XValues[n]);
                sprite.MoveY(Easings[n%2], startTime, endTime, YValues[m], YValues[n]);

                startTime = endTime;
            }
        }

        public long mod(long a, long b) 
        {
            return (a % b + b) % b;
        }

    }
}
