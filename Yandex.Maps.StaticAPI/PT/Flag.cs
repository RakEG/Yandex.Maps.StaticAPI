namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание одной метки, которую требуется отобразить на карте. 
    /// </summary>
    public class Flag : MarkBase
    {
        /// <summary>
        /// Метка в виде красного флага
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        public Flag(double lat, double lon) : base(lat, lon) { }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public override string GetPartUrl()
        {
            string str = "";

            str += Lon.ToString().Replace(',', '.') + ",";
            str += Lat.ToString().Replace(',', '.') + ",";

            str += "flag";
            return str;
        }
    }
}
