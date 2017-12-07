﻿
public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    private int FireAffinity { get; }


    public override double GetMonumentBonus()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Fire Affinity: {this.FireAffinity}";
    }
}

