using System.ComponentModel;

namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Перечень слоев, определяющих тип карты: map (схема), sat (спутник) и sat,skl (гибрид), trf (пробки).
    /// </summary>
    public class L
    {
        /// <summary>
        /// Полностью пользовательская строка (все остальные объекты класса игнорируются)
        /// </summary>
        string _userString = "";
        bool _map = true;//Схема местности и названия географических объектов
        bool _sat = false;//Местность, сфотографированная со спутника
        /// <summary>
        /// Названия географических объектов
        /// </summary>
        public bool Skl = false;
        /// <summary>
        /// Слой пробок
        /// </summary>
        public bool Trf = false;
        /// <summary>
        /// Порядок слоев skl и trf (В случае true слой названий будет над слоем пробок)
        /// </summary>
        public bool SklOverTrf = true;

        /// <summary>
        /// Перечень слоев, определяющих тип карты: map (схема), sat (спутник) и sat,skl (гибрид), trf (пробки).
        /// </summary>
        /// <param name="Map">Схема местности и названия географических объектов</param>
        /// <param name="Sat">Местность, сфотографированная со спутника</param>
        /// <param name="Skl">Названия географических объектов</param>
        /// <param name="Trf">Слой пробок</param>
        /// <param name="SklOverTrf">Порядок слоев skl и trf</param>
        public L(bool Map, bool Sat, bool Skl, bool Trf, bool SklOverTrf=true)
        {
            this.Map = Map;
            this.Sat = Sat;
            this.Skl = Skl;
            this.Trf = Trf;
            this.SklOverTrf = SklOverTrf;
        }

        /// <summary>
        /// Инцилизатор без параметров устанавливает только слой "Map" - Схема местности и названия географических объектов
        /// </summary>
        public L() : this(true, false, false, false) { }
        
        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public L(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "l=";

            if (_userString == "")
            {
                if (_map)
                {
                    str += l.map.GetDescription() + ",";
                }

                if (_sat)
                {
                    str += l.sat.GetDescription() + ",";
                }

                if (Skl & Trf)
                {
                    if (SklOverTrf)
                    {
                        str += l.trf.GetDescription() + ",";
                        str += l.skl.GetDescription() + ",";
                    }
                    else
                    {
                        str += l.skl.GetDescription() + ",";
                        str += l.trf.GetDescription() + ",";
                    }
                }
                else
                {
                    if (Skl)
                    {
                        str += l.skl.GetDescription() + ",";
                    }

                    if (Trf)
                    {
                        str += l.trf.GetDescription() + ",";
                    }

                }

                str = str.TrimEnd(',');
            }
            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Отображать схему местности и названия географических объектов
        /// </summary>
        public bool Map
        {
            get { return _map; }
            set
            {
                if (value)
                {
                    _map = true;
                    _sat = false;
                }
                else
                {
                    _map = false;
                    //_sat = true;
                }
            }
        }

        /// <summary>
        /// Отображать местность, сфотографированную со спутника
        /// </summary>
        public bool Sat
        {
            get { return _sat; }
            set
            {
                if (value)
                {

                    _sat = true;
                    _map = false;
                }
                else
                {
                    _sat = false;
                    //_map = true;
                }
            }
        }

        /// <summary>
        /// Перечень слоев, определяющих тип карты: map (схема), sat (спутник) и sat,skl (гибрид).
        /// </summary>
        public enum l
        {
            [Description("map")]
            map,
            [Description("sat")]
            sat,
            [Description("skl")]
            skl,
            [Description("trf")]
            trf
        };
    }
}
