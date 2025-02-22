using System;

class WeatherData
{
    private double temperature;
    private int humidity;
    private char scale;

    public double Temperature
    {
        get { return temperature; }
        set
        {
            if (scale == 'C' && (value < -60 || value > 60))
                Console.WriteLine("Reading mistake: Temperature out of range (-60 to 60°C).");
            else if (scale == 'F' && (value < -76 || value > 140))
                Console.WriteLine("Reading mistake: Temperature out of range (-76 to 140°F).");
            else
                temperature = value;
        }
    }

    public int Humidity
    {
        get { return humidity; }
        set
        {
            if (value < 0 || value > 100)
                Console.WriteLine("Reading mistake: Humidity must be between 0% and 100%.");
            else
                humidity = value;
        }
    }

    public char Scale
    {
        get { return scale; }
        set
        {
            if (value == 'C' || value == 'F')
                scale = value;
            else
                Console.WriteLine("Invalid scale. Use 'C' for Celsius or 'F' for Fahrenheit.");
        }
    }

    public WeatherData(double temperature, int humidity, char scale)
    {
        Scale = scale;
        Temperature = temperature;
        Humidity = humidity;
    }

    public void Convert()
    {
        if (scale == 'C')
        {
            temperature = (temperature * 9 / 5) + 32;
            scale = 'F';
        }
        else
        {
            temperature = (temperature - 32) * 5 / 9;
            scale = 'C';
        }
    }

    public override string ToString()
    {
        return $"Temperature: {temperature}{scale}, Humidity: {humidity}%";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter temperature: ");
        double temp = double.Parse(Console.ReadLine());
        
        Console.Write("Enter humidity (0-100%): ");
        int hum = int.Parse(Console.ReadLine());
        
        Console.Write("Enter scale (C/F): ");
        char scale = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        
        WeatherData weather = new WeatherData(temp, hum, scale);
        Console.WriteLine(weather);
        
        Console.Write("Convert temperature scale? (y/n): ");
        if (Console.ReadKey().KeyChar == 'y')
        {
            Console.WriteLine();
            weather.Convert();
            Console.WriteLine(weather);
        }
    }
}