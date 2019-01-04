namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Ширина и высота запрашиваемого изображения карты (в пикселах). По умолчанию принимает значение 450x450.
    /// </summary>
    public class Size
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        int _height;
        int _width;

        /// <summary>
        /// Ширина и высота запрашиваемого изображения карты (в пикселах).
        /// Максимально допустимый размер изображения карты составляет 450x650 пикселов. 
        /// </summary>
        /// <param name="h">Высота запрашиваемого изображения карты (в пикселах)</param>
        /// <param name="w">Ширина запрашиваемого изображения карты (в пикселах)</param>
        public Size(int h, int w)
        {
            this.Height = h;
            this.Width = w;
        }

        /// <summary>
        /// Ширина и высота запрашиваемого изображения карты (в пикселах).
        /// По умолчанию принимает значение 450x450.
        /// </summary>
        public Size():this(450,450) {}

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Size(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "size=";

            if (_userString == "")
            {
                str += _width.ToString().Replace(',', '.') + ",";
                str += _height.ToString().Replace(',', '.');
            }
            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Высота изображения карты в пикселях
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if ((value > 0) & (value <= 450))
                {
                    _height = value;
                }
                else if (value > 450)
                {
                    _height = 450;
                }
                else if (value <0)
                {
                    _height = 450;
                }
            }
        }

        /// <summary>
        /// Ширина изображения карты в пикселях
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if ((value > 0) & (value <= 650))
                {
                    _width = value;
                }
                else if (value > 650)
                {
                    _width = 650;
                }
                else if (value <0)
                {
                    _width = 450;
                }
            }
        }
    }
}
