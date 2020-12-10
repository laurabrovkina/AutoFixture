using AutoFixture;
using System;
using Xunit;

namespace DemoCode.Tests
{
    public class DateAndTimeDemos
    {
        [Fact]
        public void DateTimes()
        {
            Fixture fixture = new Fixture();
            DateTime logTime = fixture.Create<DateTime>();

            var result = LogMessageCreator.Create("some log message", logTime);

            Assert.Equal(logTime.Year,result.Year);
        }
    }
}
