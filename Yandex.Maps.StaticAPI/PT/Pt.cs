using System.Collections.Generic;

namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание меток, которые требуется отобразить на карте. 
    /// </summary>
    public class Pt
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        MarkBase _mark;
        List<MarkBase> _listMark;

        /// <summary>
        /// Метка, которые требуется отобразить на карте
        /// </summary>
        /// <param name="mark">Метка</param>
        public Pt(MarkBase mark)
        {
            _mark = mark;
        }

        /// <summary>
        /// Метки, которые требуется отобразить на карте
        /// </summary>
        /// <param name="listMark">Коллекция меток</param>
        public Pt(List<MarkBase> listMark)
        {
            _listMark = listMark;
        }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Pt(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "pt=";

            if (_userString == "")
            {
                if (_mark != null)
                {
                    str += _mark.GetPartUrl();

                    return str;
                }

                if (_listMark != null)
                {
                    foreach (MarkBase mark in _listMark)
                    {
                        str += mark.GetPartUrl() + '~';
                    }
                    str = str.TrimEnd('~');

                    return str;
                }
            }
            else
                str += _userString;

            return str;
        }
    }
}
