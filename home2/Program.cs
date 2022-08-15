
static Boolean isConvertable(long maxValue, long minValue, long Value)
{

    if (Value < maxValue && Value > minValue)
    {
        return true;
    }

    return false;

}


string? input = Console.ReadLine();

Type[] types = new[] {typeof(long), typeof(int), typeof(short),
typeof(byte), typeof(uint), typeof(ushort), typeof(sbyte)};

if (input == null)
{
    return;
}
long number = long.Parse(input);

foreach (Type type in types)
{

    var maxValueField = type.GetField("MaxValue");
    var minValueField = type.GetField("MinValue");

    if (maxValueField == null) return;
    if (minValueField == null) return;
    long maxValue = Convert.ToInt64(maxValueField.GetValue(type));
    long minValue = Convert.ToInt64(minValueField.GetValue(type));

    if (isConvertable(maxValue, minValue, number))
    {

        Console.WriteLine("Converted to {0}", type);
        Console.WriteLine("--------------------");
        var newVal = Convert.ChangeType(number, type);

        var newValueField = number.GetType().GetField("MaxValue");
        if (newValueField == null) return;

        Console.WriteLine("Converted value is: {0}", newVal);

        Console.WriteLine("====================");
        continue;
    }


    Console.WriteLine(
    "Для приведения числа {0} к типу {1} число не может быть больше {2} и меньше {3}",
    number, type, maxValue, minValue);

    Console.WriteLine("====================");

}
