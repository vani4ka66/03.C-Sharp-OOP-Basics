
    public class EarthBender : Bender
    {
        private double groundSaturation;

        public EarthBender(string name, int power, float groundSaturation)
            : base(name, power)
        {
            this.GroundSaturation = groundSaturation;
        }

        public double GroundSaturation { get; private set; }

        public override double GetTotalPower()
        {
            return this.GroundSaturation*base.Power;
        }

    public override string ToString()
    {
        return $"{base.ToString()} Ground Saturation: {GroundSaturation:f2}";
    }
}

