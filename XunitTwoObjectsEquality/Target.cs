namespace XunitTwoObjectsEquality
{
    public class Target
    {
        public Pair KeyValuePair { get; private set; }

        public void SetKeyValue(string key, string value)
        {
            KeyValuePair = new Pair()
            {
                Key = key,
                Value = value
            };
        }
    }

    public class Pair
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
