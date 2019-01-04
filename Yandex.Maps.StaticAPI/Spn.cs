namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Протяженность области задается двумя числами, первое из которых есть разница между максимальной и минимальной долготой, а второе — между максимальной и минимальной широтой данной области.
    /// </summary>
    public class Spn
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        double _dLat;
        double _dLat_max=90;
        double _dLon;
        double _dLon_max=180;

        /// <summary>
        /// Протяженность области показа
        /// </summary>
        /// <param name="dLat">Широта области показа (в градусах)</param>
        /// <param name="dLon">Долгота обасти показа (в градусах)</param>
        public Spn(double dLat, double dLon)
        {
            this.dLat = dLat;
            this.dLon = dLon;
        }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Spn(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "spn=";

            if (_userString == "")
            {
                str += dLon.ToString().Replace(',', '.') + ",";
                str += dLat.ToString().Replace(',', '.');
            }
            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Область показа по широте в градусах
        /// </summary>
        public double dLat
        {
            get { return _dLat; }
            set
            {
                if (value > 0 & value <= _dLat_max)
                {
                    _dLat = value;
                }
                else if (value > _dLat_max)
                {
                    _dLat = _dLat_max;
                }
                else if (value <= 0)
                {
                    _dLat = 0.01;
                }
            }
        }

        /// <summary>
        /// Область показа по долготе в градусах
        /// </summary>
        public double dLon
        {
            get { return _dLon; }
            set
            {
                if (value > 0 & value <= _dLon_max)
                {
                    _dLon = value;
                }
                else if (value > _dLon_max)
                {
                    _dLon = _dLon_max;
                }
                else if (value <= 0)
                {
                    _dLon = 0.01;
                }
            }
        }
    }

}
