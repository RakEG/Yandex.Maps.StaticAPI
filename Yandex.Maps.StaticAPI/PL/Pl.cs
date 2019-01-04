using System.Collections.Generic;

namespace Yandex.Maps.StaticAPI.PL
{
    /// <summary>
    /// Содержит набор описаний геометрических фигур (ломаных и многоугольников), которые требуется отобразить на карте. 
    /// </summary>
    public class Pl
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        List<Polyline> _listPolyline;

        /// <summary>
        /// Полилинии и (или) многоугольники, которые требуется отобразить на карте
        /// </summary>
        /// <param name="listPolyline">Колекция полилиний</param>
        public Pl(List<Polyline> listPolyline)
        {
            _listPolyline = listPolyline;
        }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Pl(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "pl=";

            if (_userString == "")
            {
                foreach (Polyline pol in _listPolyline)
                {
                    str += pol.GetPartUrl() + '~';
                }
                str = str.TrimEnd('~');
            }
            else
                str += _userString;

            return str;
        }
    }
}
