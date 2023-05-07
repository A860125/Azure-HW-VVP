namespace Azure_HW_VVP.Model
{
    public class VVP
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }

        public VVP()
        {
            Country = string.Empty;
        }
        public VVP(int id, string country, int year, double value)
        {
            Id = id;
            Country = country;
            Year = year;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Id} - {Country} - {Year} - {Value}";
        }

    }
}
