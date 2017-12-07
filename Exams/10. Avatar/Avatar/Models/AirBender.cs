
    public class AirBender : Bender
    {
        private double aerialIntegrity;
      

        public AirBender(string name, int power, float aerialIntegrity)
            : base(name, power)
        {
            this.AerialIntegrity = aerialIntegrity;
        }

        public double AerialIntegrity { get; set; }

        public override double GetTotalPower()
        {
            return this.AerialIntegrity*base.Power;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Aerial Integrity: {AerialIntegrity:f2}";
        }
    }

