namespace DigitasChallenge.BLL.Helpers
{
    public static class EnumHelper
    {
        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return System.Enum.TryParse(str, true, out T val) ? val : default;
        }

        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return (T)System.Enum.ToObject(enumType, intValue);
        }
    }
}
