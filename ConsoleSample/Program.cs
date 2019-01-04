using System;
using System.Collections.Generic;
using Yandex.Maps.StaticAPI;
using Yandex.Maps.StaticAPI.PL;
using Yandex.Maps.StaticAPI.PT;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            L l = new L(true, false, false, true);
            LL ll = new LL(56.00848, 92.85302);
            int z = 15;
            Bbox bbox = new Bbox(56.01000, 92.85, 56.00580, 92.85778);
            Spn spn = new Spn(0.005, 0.005);
            Size size = new Size(450, 450);
            Lang lang = new Lang(Lang.Lang_reg.en_US);

            //Создание карты с слоем пробок
            StaticAPI map1 = new StaticAPI(l, ll, z, size, lang);
            Console.Write("Создание карты с слоем пробок.\n");
            Console.Write(map1.GetPictureURL()+ "\n\n");

            //Создание карты с различными метками
            Pm pm1 = new Pm(56.00922, 92.84895);
            Pm pm2 = new Pm(56.00956, 92.85569, Pm.Color.do_, Pm.Size.l, 2);
            Pm pm3 = new Pm(56.00891, 92.85581, Pm.Color.nt, Pm.Size.s, 3);
            Pm2 pm4 = new Pm2(56.00895, 92.85679);
            Pm2 pm5 = new Pm2(56.00702, 92.85713, Pm2.Color.gr, Pm2.Size.l, 5);
            Vk pm6 = new Vk(56.00690, 92.85552, Vk.Color.bk);
            Vector pm7 = new Vector(56.00613, 92.85574, Vector.Mark.comma);
            Vector pm8 = new Vector(56.00574, 92.85283, Vector.Mark.ya_ru);
            Vector pm9 = new Vector(56.00672, 92.85258, Vector.Mark.home);
            Flag pm10 = new Flag(56.00661, 92.84937);
            List<MarkBase> listMark = new List<MarkBase>() { pm1, pm2, pm3, pm4, pm5, pm6, pm7, pm8, pm9, pm10 };
            Pt pt = new Pt(listMark);
            StaticAPI map2 = new StaticAPI(new L(), bbox, pt: pt);
            Console.Write("Создание карты с различными метками.\n");
            Console.Write(map2.GetPictureURL() + "\n\n");

            //Создание спутниковой карты с полилиниями разного цвета
            Polyline polyline1 = new Polyline("0000FF99", 6, new List<Point>() {
                new Point(56.00976, 92.85251),
                new Point(56.00519, 92.85328),
                new Point(56.00518, 92.85359),
                new Point(56.00978, 92.85290)});
            Polyline polyline2 = new Polyline("FF0000FF", 10, new List<Point>() {
                new Point(56.00673, 92.84922),
                new Point(56.00719, 92.85721)});
            List<Polyline> listPol = new List<Polyline>() { polyline1, polyline2 };
            Pl pl = new Pl(listPol);
            StaticAPI map3 = new StaticAPI(
                new L(false, true, true, false),
                ll,
                spn,
                new Size(450, 300),
                scale: 4,
                pl: pl);
            Console.Write("Создание спутниковой карты с полилиниями разного цвета.\n");
            Console.Write(map3.GetPictureURL() + "\n\n");

            //Создание карты с двумя пересекающимися полигонами
            List<Point> listPolygonPoint = new List<Point>() {
                new Point(56.00922, 92.84895),
                new Point(56.00956, 92.85569),
                new Point(56.00891, 92.85581),
                new Point(56.00895, 92.85679),
                new Point(56.00702, 92.85713),
                new Point(56.00690, 92.85552),
                new Point(56.00613, 92.85574),
                new Point(56.00574, 92.85283),
                new Point(56.00672, 92.85258),
                new Point(56.00661, 92.84937)};
            List<Point> listPolygonPoint2 = new List<Point>(){
                new Point(56.00827, 92.85097),
                new Point(56.00819, 92.85516),
                new Point(56.00693, 92.85367),
                new Point(56.00758, 92.85076)};
            Polyline polygons = new Polygon("F473fFAF", "ec473fF2", 8, listPolygonPoint, listPolygonPoint2);
            List<Point> listPolygonPoint3 = new List<Point>(){
                new Point(56.00976, 92.85251),
                new Point(56.00978, 92.85290),
                new Point(56.00518, 92.85359),
                new Point(56.00519, 92.85328)};
            Polyline polygons2 = new Polygon(listPolygonPoint3);
            List<Polyline> listPolygon = new List<Polyline>() { polygons, polygons2 };
            Pl pl2 = new Pl(listPolygon);
            StaticAPI map4 = new StaticAPI(new L(), bbox, pl: pl2);
            Console.Write("Создание карты с двумя пересекающимися полигонами.\n");
            Console.Write(map4.GetPictureURL() + "\n\n");

            //Создание карты со всеми ранее созданными объектами
            List<Polyline> listPolygonPoint4 = new List<Polyline>() { polyline1, polyline2, polygons, polygons2 };
            Pl pl3 = new Pl(listPolygonPoint4);
            StaticAPI map5 = new StaticAPI(
                new L(true, false, true, true),
                bbox,
                new Size(450, 650),
                new Lang(Lang.Lang_reg.ru_RU),
                1.5,
                pt,
                pl3);
            Console.Write("Создание карты со всеми ранее созданными объектами.\n");
            Console.Write(map5.GetPictureURL() + "\n\n");

            Console.ReadLine();
        }
    }
}
