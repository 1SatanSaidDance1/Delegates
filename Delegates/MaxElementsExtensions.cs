namespace Delegates
{
    /// <summary>
    /// Функция возврата максимального элемента коллекции
    /// </summary>
    public static class MaxElementsExtensions
    {
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
    }
}