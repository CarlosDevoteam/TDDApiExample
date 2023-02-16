namespace ApiTestBaseTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData (1, "Carlos")]
        [InlineData (1, "Jesus")]
        public void Test2(int id, string name) 
        {

        }
    }
}