using McMotdParser.Deserializer;
using System;
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
            sectionSignDeserializer.deserialize();

            // Assert
            Assert.True(true);
        }
    }
}
