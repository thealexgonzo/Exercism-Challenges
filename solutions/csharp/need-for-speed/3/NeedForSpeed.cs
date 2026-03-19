class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;
    private int _battery = 100;
    private int _distanceDriven = 0;
    public int MaxDrivingDistance => _speed * (100 / _batteryDrain);
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;
    
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

    public bool TryFinishTrack(RemoteControlCar car) => _distance <= car.MaxDrivingDistance;    
}
