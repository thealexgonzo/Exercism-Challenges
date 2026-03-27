public class SpaceAge
{
    private readonly double _earthOrbitalYearInSeconds = 365.25 * 24 * 60 * 60;
    private readonly int _seconds;
    private readonly Dictionary<string, double> _planetOrbitalPeriodInEarthYears = new()
    {
        { "Mercury", 0.2408467},
        { "Venus", 0.61519726},
        { "Mars", 1.8808158},
        { "Jupiter", 11.862615},
        { "Saturn", 29.447498},
        { "Uranus", 84.016846},
        { "Neptune", 164.79132}
    };

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    private double AgeInPlanetYears(double orbitalPeriodInEarthYears = 1.0) =>
        OnEarth() / orbitalPeriodInEarthYears;

    public double OnEarth() => _seconds / _earthOrbitalYearInSeconds;

    public double OnMercury() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Mercury"]);

    public double OnVenus() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Venus"]);

    public double OnMars() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Mars"]);

    public double OnJupiter() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Jupiter"]);

    public double OnSaturn() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Saturn"]);

    public double OnUranus() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Uranus"]);

    public double OnNeptune() => AgeInPlanetYears(_planetOrbitalPeriodInEarthYears["Neptune"]);
}