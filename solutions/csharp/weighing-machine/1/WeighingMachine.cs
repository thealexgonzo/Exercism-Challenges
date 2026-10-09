class WeighingMachine
{
    public int Precision { get; private set; }
    public double Weight
    {
        get;
        set 
        {
            field = value > 0 ? value : throw new ArgumentOutOfRangeException();
        } 
    }
    public double TareAdjustment { get; set; }
    public string DisplayWeight 
    {
        get 
        {
            return $"{(Weight - TareAdjustment).ToString("F" + Precision)} kg"; 
        } 
    }
    public WeighingMachine(int precision)
    {
        Precision = precision;
        TareAdjustment = 5.0;
    }
}
