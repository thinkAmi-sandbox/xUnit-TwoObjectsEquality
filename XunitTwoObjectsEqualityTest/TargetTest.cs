using System;
using System.Collections.Generic;

namespace XunitTwoObjectsEqualityTest
{
    using Xunit;
    using XunitTwoObjectsEquality;
    public class TargetTest
    {
        const string HogeKey = "hoge";
        const string FugaValue = "fuga";
 
        [Fact]
        public void FailTest()
        {
            var expected = new Pair()
            {
                Key = HogeKey,
                Value = FugaValue
            };
 
            var actual = new Target();
            actual.SetKeyValue(HogeKey, FugaValue);
 
            Assert.Equal(expected, actual.KeyValuePair);
        }
 
        [Fact]
        public void SucessTest()
        {
            var expected = new Pair()
            {
                Key = HogeKey,
                Value = FugaValue
            };
 
            var actual = new Target();
            actual.SetKeyValue(HogeKey, FugaValue);
 
            // 比較方法を第三引数に渡す
            Assert.Equal(expected, actual.KeyValuePair, new PairComparer());
        }
    }
 
 
    public class PairComparer : IEqualityComparer<Pair>
    {
        public bool Equals(Pair x, Pair y)
        {
            // 2つのオブジェクトを等しいとみなす条件
            return x.Key.Equals(y.Key, StringComparison.Ordinal) &&
                x.Value.Equals(y.Value, StringComparison.Ordinal);
        }
 
        public int GetHashCode(Pair pair)
        {
            // Equals対象プロパティのHashでXORをとって、HashCodeとして返す
            return pair.Key.GetHashCode() ^ pair.Value.GetHashCode();
        }
    }
}
