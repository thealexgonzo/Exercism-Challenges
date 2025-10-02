static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        double rate = 100;
        
        if (speed != 0){
            
            if (speed >= 1 && speed <= 4){
                rate /= 100;
            }
            else if (speed >= 5 && speed <= 8){
                rate = 90 / rate;
            }
            else if (speed == 9){
                rate = 80 / rate;
            }
            else if (speed == 10){
                rate = 77 / rate;
            }
        }
        else{
            rate = 0;
        }

        return rate;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return (221 * speed) * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}
