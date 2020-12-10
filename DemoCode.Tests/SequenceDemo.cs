using System;
using AutoFixture;
using System.Collections.Generic;
using Xunit;

namespace DemoCode.Tests
{
    public class SequenceDemo
    {
        [Fact]
        public void SequenceOfStrings()
        {
            // arrange
            Fixture fixture = new Fixture();
            IEnumerable<string> message = fixture.CreateMany<string>(6);

        }

        [Fact]
        public void AddingToExistingList()
        {
            // arrange
            Fixture fixture = new Fixture();
            var sut = new DebugMessageBuffer();

             //default number for repeat count is 3
            fixture.AddManyTo(sut.Messages, 10);

            sut.WriteMessages();

            Assert.Equal(10, sut.MessagesWritten);

        }

        [Fact]
        public void AddingToExistingListWithCreatorFunction()
        {
            // arrange
            Fixture fixture = new Fixture();
            var sut = new DebugMessageBuffer();
            var rnd = new Random();

            //default number for repeat count is 3
            fixture.AddManyTo(sut.Messages, () => "hi");
            fixture.AddManyTo(sut.Messages, () => rnd.Next().ToString());
        }
    }
}
