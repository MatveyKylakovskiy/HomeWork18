using HomeWork18.WebElements;
using PageObjLib.Factories;
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
        [Theory(DisplayName = "IsSelectedAll")]
        [TestCase(true)]
        public void DropDownAll(bool expected)
        {
            Assert.That(Dropdown.IsSelected(), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "IsSelected1")]
        [TestCase(true)]
        public void DropDown1(bool expected)
        {
            Assert.That(Dropdown.IsSelected(1), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "IsSelected2")]
        [TestCase(true)]
        public void DropDown2(bool expected)
        {
            Assert.That(Dropdown.IsSelected(2), Is.EqualTo(expected));
        }

        //Fourts Task
        [Theory(DisplayName = "InputDigitTest")]
        [TestCase(5, 2, 1)]
        public void InputDigit(int number, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.IsInputting(number, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputString1")]
        [TestCase("asdd", 0, 0)]
        public void InputString1(string str, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.IsInputting(str, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputString2")]
        [TestCase("asdd", 5, 1)]
        public void InputString2(string str, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.IsInputting(str, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputE")]
        [TestCase(1, 1, 0, 0)]
        public void InputE1(int number, int exponent, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.InputE(number, exponent, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputEAndArrow")]
        [TestCase(2, 2, 5, 2)]
        public void InputE2(int number, int exponent, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.InputE(number, exponent, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputMaxValue")]
        [TestCase("2e308", 2, 5)]
        public void InputMaxValue(string value, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.InputBoundaryValue(value, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputMinValue")]
        [TestCase("-2e308", 3, 7)]
        public void InputMinValue(string value, int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.InputBoundaryValue(value, arrowUpCount, arrouDownCount));
        }

        [Theory(DisplayName = "InputToLongValue")]
        [TestCase(4, 7)]
        public void InputToLongValue(int arrowUpCount, int arrouDownCount)
        {
            Assert.IsTrue(Inputs.InputToLongValue(arrowUpCount, arrouDownCount));
        }


        [TearDown]
        public void TreadDown()
        {
            Driver.QuitDriver();
            Driver.DisposeDriver();
        }
    }
}