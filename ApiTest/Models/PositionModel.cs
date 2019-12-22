namespace ApiTest.Models
{
    public class PositionModel
    {
        public float Lattitude { get; set; }
        public float Longitude { get; set; }

        public override bool Equals(object o)
        {
            var compare = o as PositionModel;
            if (compare == null)
                return false;
            return this.Lattitude == compare.Lattitude &&
                this.Longitude == compare.Longitude;
        }
    }
}