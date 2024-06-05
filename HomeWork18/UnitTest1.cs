using HomeWork18.WebElements;
using PageObjLib.Factories;
using PageObjLib.Page;

namespace HomeWork18
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            int a = AddRemoveElements.GetCountOfElements();

            Assert.Pass();
        }


    }
}