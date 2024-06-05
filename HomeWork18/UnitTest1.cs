using HomeWork18.WebElements;
using PageObjLib.Factories;
using PageObjLib.Page;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace HomeWork18
{
    public class Tests
    {
        //First Task
        [Theory(DisplayName = "AddRemoveTest")]
        [TestCase(1)]
        public void AddRemoveTest(int expected)
        {
            Assert.That(AddRemoveElements.GetCountOfElements(), Is.EqualTo(expected));
        }

        //Second Task
        [Theory(DisplayName = "FirstCheckBoxUnChecked")]
        [TestCase(false)]
        public void FirstCheckBoxUnChecked(bool expected)
        {
            Assert.That(Checkboxes.GetStatus(1), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "FirstCheckBoxChecked")]
        [TestCase(true)]
        public void FirstCheckBoxChecked(bool expected)
        {
            Assert.That(Checkboxes.GetSatusAfterClick(1), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "SecondCheckBoxChecked")]
        [TestCase(true)]
        public void SecondCheckBoxChecked(bool expected)
        {
            Assert.That(Checkboxes.GetStatus(2), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "SecondCheckBoxUnChecked")]
        [TestCase(false)]
        public void SecondCheckBoxUnChecked(bool expected)
        {
            Assert.That(Checkboxes.GetSatusAfterClick(2), Is.EqualTo(expected));
        }

        //Third Task


        [TearDown]
        public void TreadDown()
        {
            Driver.QuitDriver();
            Driver.DisposeDriver();
        }
    }
}