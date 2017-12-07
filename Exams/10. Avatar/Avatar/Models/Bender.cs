
    public abstract class Bender
    {
        private string name;
        private int power;

        protected Bender(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public abstract double GetTotalPower();

        public override string ToString()
        {
            var name = this.GetType().Name;
            var index = name.IndexOf("Bender");
            name = name.Insert(index, " ");
            return $"###{name}: {this.Name}, Power: {this.Power},";
        }
    }

