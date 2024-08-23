namespace Delegates
{
    /// <summary>
    /// Функция возврата максимального элемента коллекции
    /// </summary>
    public static class MaxElements
    {
        interface IFloatValue
        {
            float Value { get; }
        }

        class FloatValue(float value) : IFloatValue
        {
            public float Value { get; } = value;
        }

        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            T? maxElement = null;
            float maxValue = float.MinValue;

            foreach (T element in collection)
            {
                float value = convertToNumber(element);

                if (value > maxValue)
                {
                    maxElement = element;
                    maxValue = value;
                }
            }

            return maxElement;
        }

        private static float GetParameter<T>(T param) where T : class => param switch
        {
            IFloatValue value => value.Value,

            float convertToFloat => convertToFloat,
            _ => throw new ArgumentException("Не удается преобразовать тип")
        };

        public static string Run()
        {
            List<IFloatValue> list = new()
            {
                new FloatValue(2f),
                new FloatValue(1313f),
                new FloatValue(-66.06f)
            };

            float maxElement = list.GetMax<IFloatValue>(GetParameter).Value;

            string console = "Задача 'Максимальное число'\n\r";
            console += "На вход даны числа 2, 1313, -66.06 ";
            console += $"Максимальное число: {maxElement}\n\r\n\r";

            return console;
        }
    }
}