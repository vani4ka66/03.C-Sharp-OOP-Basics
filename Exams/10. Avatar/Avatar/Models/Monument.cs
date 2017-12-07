
public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract double GetMonumentBonus();


    public override string ToString()
    {
        var nameM = this.GetType().Name;
        var index = nameM.IndexOf("Monument");
        nameM = nameM.Insert(index, " ");
        return $"###{nameM}: {this.Name},";
    }
}

