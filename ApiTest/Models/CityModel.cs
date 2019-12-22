namespace ApiTest.Models
{
    public class CityModel
    {
        public string Title { get; set; }
        public string Location_type { get; set; }
        public int Woeid { get; set; }
        public string Latt_long { get; set; }

        public override bool Equals(object o)
        {
            var compare = o as CityModel;
            if (compare == null)
                return false;
            return this.Title == compare.Title &&
                this.Location_type == compare.Location_type &&
                this.Woeid == compare.Woeid &&
                this.Latt_long == compare.Latt_long;
        }
    }
}