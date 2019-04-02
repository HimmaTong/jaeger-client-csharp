using System;
using Jaeger.Util;
using Xunit;

namespace Jaeger.Tests
{
    public class SpanIdTests
    {
        private readonly long _spanIdValue;
        private readonly SpanId _spanId;

        public SpanIdTests()
        {
            _spanIdValue = 42;
            _spanId = new SpanId(_spanIdValue);
        }

        [Fact]
        public void Field_ShouldReturnHexString()
        {
            Assert.Equal("2a", _spanId.ToString());
        }

        [Fact]
        public void Field_ShouldBeCastableToInt64()
        {
            var longValue = (long)_spanId;
            Assert.Equal(longValue, Convert.ToInt64(_spanIdValue));
        }

        [Fact]
        public void Field_ShouldReturnBytes()
        {
            Assert.Collection(_spanId.ToByteArray(),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x00),
                b => Assert.Equal(b, (byte)0x2a));
        }
    }
}
