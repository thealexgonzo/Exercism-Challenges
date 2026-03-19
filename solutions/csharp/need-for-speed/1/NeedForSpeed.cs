class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private decimal _battery = 100m;
    private int _distanceDriven = 0;
    //private bool _batteryDrained = false;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery == 0 || _battery < _batteryDrain;
    
    public int DistanceDriven() => _distanceDriven;    

    public void Drive()
    {
        if (BatteryDrained()) return;

        _distanceDriven += _speed;
        _battery -= _batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        int nitroSpeed = 50;
        int nitroBatteryDrain = 4;

        return new RemoteControlCar(nitroSpeed, nitroBatteryDrain);
    }
}

class RaceTrack
{
    int _distance;
    
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained())
            car.Drive();

        return _distance <= car.DistanceDriven();
    }
}
