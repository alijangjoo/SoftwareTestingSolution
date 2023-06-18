using TestingSolution.TestProject.Infra.Tools.Utils;
using Xunit;

namespace TestingSolution.TestProject.UnitTests.Utils
{
    public class DateUtilTests
    {
        [Fact]
        public void GetCurrentDate_ReturnsCorrectDate()
        {
            var currentDate = DateUtil.GetCurrentDate();

            Assert.True(currentDate.Year >= 2021);
        }
    }
}
