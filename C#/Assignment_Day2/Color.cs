namespace Assignment_Day2;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = ClampValue(red);
        this.green = ClampValue(green);
        this.blue = ClampValue(blue);
        this.alpha = ClampValue(alpha);
    }

    
    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    
    public int Red
    {
        get => red;
        set => red = ClampValue(value);
    }

    public int Green
    {
        get => green;
        set => green = ClampValue(value);
    }

    public int Blue
    {
        get => blue;
        set => blue = ClampValue(value);
    }

    public int Alpha
    {
        get => alpha;
        set => alpha = ClampValue(value);
    }

    
    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }


    private int ClampValue(int value)
    {
        if (value < 0) return 0;
        if (value > 255) return 255;
        return value;
    }
}

public class Ball
{
    private int size;  
    private Color color;  
    private int throwCount;  

   
    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    
    public void Pop()
    {
        size = 0;  
    }

    
    public void Throw()
    {
        if (size > 0)  
        {
            throwCount++;
            Console.WriteLine($"Ball thrown! Size: {size}, Color: ({color.Red}, {color.Green}, {color.Blue})");
        }
        else
        {
            Console.WriteLine("Can't throw a popped ball.");
        }
    }

    
    public int GetThrowCount()
    {
        return throwCount;
    }
}