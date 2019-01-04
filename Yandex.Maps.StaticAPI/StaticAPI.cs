using Yandex.Maps.StaticAPI.PT;
using Yandex.Maps.StaticAPI.PL;

namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Static API формирует изображение карты в соответствии со значениями параметров, передаваемых сервису в URL
    /// </summary>
    public class StaticAPI
    {
        //https://static-maps.yandex.ru/1.x/?{параметры URL}
        //https://tech.yandex.ru/maps/doc/staticapi/1.x/dg/concepts/about-docpage/

        
        /// <summary>
        /// Основной URL адрес (подменить в случае смены)
        /// </summary>
        public string URL= "https://static-maps.yandex.ru/1.x/?";
        L _l;//Перечень слоев, определяющих тип карты: map (схема), sat (спутник) и sat,skl (гибрид). Подробнее см. 
        LL _ll;//Долгота и широта центра карты в градусах
        int _z=-1;//Уровень масштабирования карты (0-17) (-1 - дефолтное значение)
        Spn _spn;//Протяженность области задается двумя числами, первое из которых есть разница между максимальной и минимальной долготой, а второе — между максимальной и минимальной широтой данной области.
        Bbox _bbox;//В параметре bbox задаются географические координаты углов прямоугольника, ограничивающего область просмотра. Указываются координаты левого нижнего и правого верхнего углов
        Size _size;//Ширина и высота запрашиваемого изображения карты (в пикселах)
        double _scale=-1;//Коэффициент увеличения объектов на карте. Может принимать дробное значение от 1.0 до 4.0
        Lang _lang= new Lang(Lang.Lang_reg.none);
        Pt _pt;
        Pl _pl;

        /// <summary>
        /// Static API формирует изображение карты
        /// </summary>
        /// <param name="l">Перечень слоев, определяющих тип карты</param>
        /// <param name="ll">Долгота и широта центра карты в градусах</param>
        /// <param name="z">Уровень масштабирования карты (0-17)</param>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах)</param>
        /// <param name="lang">API позволяет отображать карты, локализованные на различных языках с учетом специфики отдельных стран. Например, можно показать карту с надписями на английском языке и обозначить на ней расстояния в милях (инструмент Линейка)</param>
        /// <param name="scale">Коэффициент увеличения объектов на карте. Может принимать дробное значение от 1.0 до 4.0</param>
        /// <param name="pt">Содержит описание одной или нескольких меток, которые требуется отобразить на карте</param>
        /// <param name="pl">Содержит набор описаний геометрических фигур (ломаных и многоугольников), которые требуется отобразить на карте</param>
        public StaticAPI(L l, LL ll,int z, Size size = null, Lang lang = null, double scale=0, Pt pt = null, Pl pl=null)
        {
            _l = l;
            _ll = ll;
            _z = z;
            _size = size;
            _lang = lang;
            Scale = scale;
            _pt = pt;
            _pl = pl;
        }

        /// <summary>
        /// Static API формирует изображение карты
        /// </summary>
        /// <param name="l">Перечень слоев, определяющих тип карты</param>
        /// <param name="ll">Долгота и широта центра карты в градусах</param>
        /// <param name="spn">Протяженность области показа карты по долготе и широте (в градусах)</param>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах)</param>
        /// <param name="lang">API позволяет отображать карты, локализованные на различных языках с учетом специфики отдельных стран. Например, можно показать карту с надписями на английском языке и обозначить на ней расстояния в милях (инструмент Линейка)</param>
        /// <param name="scale">Коэффициент увеличения объектов на карте. Может принимать дробное значение от 1.0 до 4.0</param>
        /// <param name="pt">Содержит описание одной или нескольких меток, которые требуется отобразить на карте</param>
        /// <param name="pl">Содержит набор описаний геометрических фигур (ломаных и многоугольников), которые требуется отобразить на карте</param>
        public StaticAPI(L l, LL ll, Spn spn, Size size = null, Lang lang = null, double scale=0,Pt pt = null, Pl pl = null)
        {
            _l = l;
            _ll = ll;
            _spn = spn;
            _size = size;
            _lang = lang;
            Scale = scale;
            _pt = pt;
            _pl = pl;
        }

        /// <summary>
        /// Static API формирует изображение карты
        /// </summary>
        /// <param name="l">Перечень слоев, определяющих тип карты</param>
        /// <param name="bbox">Географические координаты углов прямоугольника, ограничивающего область просмотра</param>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах)</param>
        /// <param name="lang">API позволяет отображать карты, локализованные на различных языках с учетом специфики отдельных стран. Например, можно показать карту с надписями на английском языке и обозначить на ней расстояния в милях (инструмент Линейка)</param>
        /// <param name="scale">Коэффициент увеличения объектов на карте. Может принимать дробное значение от 1.0 до 4.0</param>
        /// <param name="pt">Содержит описание одной или нескольких меток, которые требуется отобразить на карте</param>
        /// <param name="pl">Содержит набор описаний геометрических фигур (ломаных и многоугольников), которые требуется отобразить на карте</param>
        public StaticAPI(L l, Bbox bbox, Size size = null, Lang lang = null, double scale=0, Pt pt = null, Pl pl = null)
        {
            _l = l;
            _bbox = bbox;
            _size = size;
            _lang = lang;
            Scale = scale;
            _pt = pt;
            _pl = pl;
        }

        /// <summary>
        /// Получить URL на изображение
        /// </summary>
        /// <returns></returns>
        public string GetPictureURL()
        {
            string str="";
            str += URL;
            str += _l.GetPartUrl() + "&";
            if (_bbox == null)
            {
                if (_ll != null)
                    str += _ll.GetPartUrl() + "&";
                if (_spn != null)
                    str += _spn.GetPartUrl() + "&";
                if (_z >=0)
                    str += "z="+ _z + "&";
            }
            else
            {
                str += _bbox.GetPartUrl() + "&";
            }

            if (_size !=null)
                str += _size.GetPartUrl() + "&";

            if (_scale != -1)
            {
                if (_l.Sat==false)//Для спутника масштабирование запрещенно
                {
                    str += "scale=" + _scale.ToString().Replace(",",".") + "&";
                }
            }

            if ((_lang != null) && (_lang._language_region != Lang.Lang_reg.none))
                str += _lang.GetPartUrl() + "&";

            if (_pt != null)
                str+= _pt.GetPartUrl()+ "&";
            if (_pl != null)
                str += _pl.GetPartUrl() + "&";

            str = str.TrimEnd('&');

            return str;
        }

        /// <summary>
        /// Коэффициент увеличения объектов на карте. Может принимать дробное значение от 1.0 до 4.0.
        /// </summary>
        public double Scale
        {
            get { return _scale; }
            set
            {
                if ((value>=1) & (value <=4))
                {
                    _scale = value;
                }
            }
        }

        /// <summary>
        /// Уровень масштабирования карты (0-17)
        /// </summary>
        public int Z
        {
            get { return _z; }
            set
            {
                if ((value >= 0) & (value <= 17))
                {
                    _z = value;
                }
            }
        }
    }
}