using McMotdParser.Deserializer;
using System;
using System.Diagnostics;
using Xunit;

namespace McMotdParser.Test.Deserializer
{
    public class SectionSignDeserializerTests
    {
        [Fact]
        public void SectionDeserializer()
        {
            // Arrange
            var sectionSignDeserializer = new SectionSignDeserializer(@"                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY");

            // Act
            sectionSignDeserializer.deserialize();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void SectionDeserializerStartWithSign()
        {
            var sectionSignDeserializer = new SectionSignDeserializer(@"§aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY");

            // Act
            List<MotdContent> contents = sectionSignDeserializer.deserialize();

            contents.ForEach(x =>
            {
                Debug.WriteLine(x.content);
            });

            // Assert
            Assert.True(true);
        }
    }
}
