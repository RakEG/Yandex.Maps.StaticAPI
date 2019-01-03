# Yandex.Maps.StaticAPI
Не официальная C# библиотека позволяющая формировать URL для получения статических изображений Yandex карт.
***
Ссылки на официальный ресурс Yandex.Maps.StaticAPI
-
[Общая информация](https://tech.yandex.ru/maps/staticapi/?from=mapsapi)

[Документация](https://tech.yandex.ru/maps/doc/staticapi/1.x/dg/concepts/input_params-docpage/)

Пример использования
=
*Все наименования объектов, свойств, полей совпадают с официальной документацией

Основные объекты которые будут использоваться далее
-
```C#
  L l = new L(true, false, false, true);
  LL ll = new LL(56.00848, 92.85302);
  int z = 15;
  Bbox bbox = new Bbox(56.01000, 92.85, 56.00580, 92.85778);
  Spn spn = new Spn(0.005, 0.005);
  Size size = new Size(450, 450);
  Lang lang = new Lang(Lang.Lang_reg.en_US);
```

Создание карты с слоем пробок
-
```C#
  StaticAPI map1 = new StaticAPI(l, ll, z, size, lang);
  string urlMap1 = map1.GetPictureURL();
```
urlMap1 =https://static-maps.yandex.ru/1.x/?l=map,trf&ll=92.85302,56.00848&z=15&size=450,450&lang=en_US

![screenshot of sample](https://static-maps.yandex.ru/1.x/?l=map,trf&ll=92.85302,56.00848&z=15&size=450,450&lang=en_US)

Создание карты с различными метками
-
```C#
  Pm pm1 = new Pm(56.00922, 92.84895);
  Pm pm2 = new Pm(56.00956, 92.85569, Pm.Color.do_, Pm.Size.l, 2);
  Pm pm3 = new Pm(56.00891, 92.85581, Pm.Color.nt, Pm.Size.s, 3);
  Pm2 pm4 = new Pm2(56.00895, 92.85679);
  Pm2 pm5 = new Pm2(56.00702, 92.85713, Pm2.Color.gr, Pm2.Size.l, 5);
  Vk pm6 = new Vk(56.00690, 92.85552, Vk.color.bk);
  Vector pm7 = new Vector(56.00613, 92.85574, Vector.mark.comma);
  Vector pm8 = new Vector(56.00574, 92.85283, Vector.mark.ya_ru);
  Vector pm9 = new Vector(56.00672, 92.85258, Vector.mark.home);
  Flag pm10 = new Flag(56.00661, 92.84937);
  List<MarkBase> listMark = new List<MarkBase>() { pm1, pm2, pm3, pm4, pm5, pm6, pm7, pm8, pm9, pm10 };
  Pt pt = new Pt(listMark);
  StaticAPI map2 = new StaticAPI(new L(), bbox, pt: pt);
  string urlMap2 = map2.GetPictureURL();
```
urlMap2 =https://static-maps.yandex.ru/1.x/?l=map&bbox=92.85,56.01~92.85778,56.0058&pt=92.84895,56.00922,pmwtm~92.85569,56.00956,pmdol2~92.85581,56.00891,pmnts3~92.85679,56.00895,pm2wtm~92.85713,56.00702,pm2grl5~92.85552,56.0069,vkbkm~92.85574,56.00613,comma~92.85283,56.00574,ya_ru~92.85258,56.00672,home~92.84937,56.00661,flag

![screenshot of sample](https://static-maps.yandex.ru/1.x/?l=map&bbox=92.85,56.01~92.85778,56.0058&pt=92.84895,56.00922,pmwtm~92.85569,56.00956,pmdol2~92.85581,56.00891,pmnts3~92.85679,56.00895,pm2wtm~92.85713,56.00702,pm2grl5~92.85552,56.0069,vkbkm~92.85574,56.00613,comma~92.85283,56.00574,ya_ru~92.85258,56.00672,home~92.84937,56.00661,flag)

Создание спутниковой карты с полилиниями разного цвета
-
```C#
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
  StaticAPI map3 = new StaticAPI(new L(false, true, true, false),
                                  ll,
                                  spn,
                                  new Size(450, 300),
                                  scale: 4,
                                  pl: pl);
  string urlMap3 = map3.GetPictureURL();
```
urlMap3 = https://static-maps.yandex.ru/1.x/?l=sat,skl&ll=92.85302,56.00848&spn=0.005,0.005&size=300,450&pl=c:0000FF99,w:6,92.85251,56.00976,92.85328,56.00519,92.85359,56.00518,92.8529,56.00978~c:FF0000FF,w:10,92.84922,56.00673,92.85721,56.00719

![screenshot of sample](https://static-maps.yandex.ru/1.x/?l=sat,skl&ll=92.85302,56.00848&spn=0.005,0.005&size=300,450&pl=c:0000FF99,w:6,92.85251,56.00976,92.85328,56.00519,92.85359,56.00518,92.8529,56.00978~c:FF0000FF,w:10,92.84922,56.00673,92.85721,56.00719)

Создание карты с двумя пересекающимися полигонами
-
```C#
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
  string urlMap4 = map4.GetPictureURL();
```
urlMap4 = https://static-maps.yandex.ru/1.x/?l=map&bbox=92.85,56.01~92.85778,56.0058&pl=c:F473fFAF,f:ec473fF2,w:8,92.84895,56.00922,92.85569,56.00956,92.85581,56.00891,92.85679,56.00895,92.85713,56.00702,92.85552,56.0069,92.85574,56.00613,92.85283,56.00574,92.85258,56.00672,92.84937,56.00661,92.84895,56.00922;92.85097,56.00827,92.85516,56.00819,92.85367,56.00693,92.85076,56.00758,92.85097,56.00827~c:8822DDC0,f:00FF00A0,w:5,92.85251,56.00976,92.8529,56.00978,92.85359,56.00518,92.85328,56.00519,92.85251,56.00976

![screenshot of sample](https://static-maps.yandex.ru/1.x/?l=map&bbox=92.85,56.01~92.85778,56.0058&pl=c:F473fFAF,f:ec473fF2,w:8,92.84895,56.00922,92.85569,56.00956,92.85581,56.00891,92.85679,56.00895,92.85713,56.00702,92.85552,56.0069,92.85574,56.00613,92.85283,56.00574,92.85258,56.00672,92.84937,56.00661,92.84895,56.00922;92.85097,56.00827,92.85516,56.00819,92.85367,56.00693,92.85076,56.00758,92.85097,56.00827~c:8822DDC0,f:00FF00A0,w:5,92.85251,56.00976,92.8529,56.00978,92.85359,56.00518,92.85328,56.00519,92.85251,56.00976)

Создание карты со всеми ранее созданными объектами
-
```C#
  List<Polyline> listPolygonPoint4 = new List<Polyline>() { polyline1, polyline2, polygons, polygons2 };
  Pl pl3 = new Pl(listPolygonPoint4);
  StaticAPI map5 = new StaticAPI(
      new L(true,false,true,true),
      bbox,
      new Size(450, 650),
      new Lang(Lang.Lang_reg.ru_RU),
      1.5, 
      pt, 
      pl3);
  string urlMap5 = map5.GetPictureURL();
```
urlMap5 = https://static-maps.yandex.ru/1.x/?l=map,trf,skl&bbox=92.85,56.01~92.85778,56.0058&size=650,450&scale=1.5&lang=ru_RU&pt=92.84895,56.00922,pmwtm~92.85569,56.00956,pmdol2~92.85581,56.00891,pmnts3~92.85679,56.00895,pm2wtm~92.85713,56.00702,pm2grl5~92.85552,56.0069,vkbkm~92.85574,56.00613,comma~92.85283,56.00574,ya_ru~92.85258,56.00672,home~92.84937,56.00661,flag&pl=c:0000FF99,w:6,92.85251,56.00976,92.85328,56.00519,92.85359,56.00518,92.8529,56.00978~c:FF0000FF,w:10,92.84922,56.00673,92.85721,56.00719~c:F473fFAF,f:ec473fF2,w:8,92.84895,56.00922,92.85569,56.00956,92.85581,56.00891,92.85679,56.00895,92.85713,56.00702,92.85552,56.0069,92.85574,56.00613,92.85283,56.00574,92.85258,56.00672,92.84937,56.00661,92.84895,56.00922;92.85097,56.00827,92.85516,56.00819,92.85367,56.00693,92.85076,56.00758,92.85097,56.00827~c:8822DDC0,f:00FF00A0,w:5,92.85251,56.00976,92.8529,56.00978,92.85359,56.00518,92.85328,56.00519,92.85251,56.00976

![screenshot of sample](https://static-maps.yandex.ru/1.x/?l=map,trf,skl&bbox=92.85,56.01~92.85778,56.0058&size=650,450&scale=1.5&lang=ru_RU&pt=92.84895,56.00922,pmwtm~92.85569,56.00956,pmdol2~92.85581,56.00891,pmnts3~92.85679,56.00895,pm2wtm~92.85713,56.00702,pm2grl5~92.85552,56.0069,vkbkm~92.85574,56.00613,comma~92.85283,56.00574,ya_ru~92.85258,56.00672,home~92.84937,56.00661,flag&pl=c:0000FF99,w:6,92.85251,56.00976,92.85328,56.00519,92.85359,56.00518,92.8529,56.00978~c:FF0000FF,w:10,92.84922,56.00673,92.85721,56.00719~c:F473fFAF,f:ec473fF2,w:8,92.84895,56.00922,92.85569,56.00956,92.85581,56.00891,92.85679,56.00895,92.85713,56.00702,92.85552,56.0069,92.85574,56.00613,92.85283,56.00574,92.85258,56.00672,92.84937,56.00661,92.84895,56.00922;92.85097,56.00827,92.85516,56.00819,92.85367,56.00693,92.85076,56.00758,92.85097,56.00827~c:8822DDC0,f:00FF00A0,w:5,92.85251,56.00976,92.8529,56.00978,92.85359,56.00518,92.85328,56.00519,92.85251,56.00976)
