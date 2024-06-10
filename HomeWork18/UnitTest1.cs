using HomeWork18.WebElements;
using PageObjLib.Factories;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace HomeWork18
{
    public class Tests
    {
        //First Task Add/Remove Elements
        [Theory(DisplayName = "AddRemoveTest")]
        [TestCase(1)]
        public void AddRemoveTest(int expected)
        {
            Assert.That(AddRemoveElements.GetCountOfElements(), Is.EqualTo(expected));
        }

        //Second Task Checkboxes
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

        //Third Task Dropdown
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

        //Fourts Task Inputs
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

        //Fifth Task Typos
        [Theory(DisplayName = "Typos")]
        [Test]
        public void TyposTest1()
        {
            Assert.IsTrue(Typos.SpellCheck());
        }

        //Sixth Task Table
        [Theory(DisplayName = "Table1_CorrectElement_Test1")]
        [TestCase("jsmith@gmail.com", 1, 1, 1, 3, true)]
       // [TestCase("$51.00", 1, 1, 2, 4, true)]
        public void Table1Test1(string value, int table, int body, int tr, int td, bool expected)
        {
            Assert.That(SortableDataTables.IsCorrectElement(value, table, body, tr, td), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "Table1_CorrectElement_Test2")]
        [TestCase("$51.00", 1, 1, 2, 4, true)]
        public void Table1Test2(string value, int table, int body, int tr, int td, bool expected)
        {
            Assert.That(SortableDataTables.IsCorrectElement(value, table, body, tr, td), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "Table2_CorrectElement_Test1")]
        [TestCase("http://www.jdoe.com", 2, 1, 3, 5, true)]
        public void Table2Test1(string value, int table, int body, int tr, int td, bool expected)
        {
            Assert.That(SortableDataTables.IsCorrectElement(value, table, body, tr, td), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "Table2_CorrectElement_Test2")]
        [TestCase("Tim", 2, 1, 4, 2, true)]
        public void Table2Test2(string value, int table, int body, int tr, int td, bool expected)
        {
            Assert.That(SortableDataTables.IsCorrectElement(value, table, body, tr, td), Is.EqualTo(expected));
        }

        [Theory(DisplayName = "SortableOrder")]
        [TestCase(1, 1)]
        public void SortableOrder(int tableNumber, int collumNumber)
        {
            var  d = SortableDataTables.IsSortableOrder(tableNumber, collumNumber);
            Assert.IsTrue(d);
        }

        [Theory(DisplayName = "SortableDescending")]
        [TestCase(2, 2)]
        public void SortableDescending(int tableNumber, int collumNumber)
        {
            var d = SortableDataTables.IsSortableDescending(tableNumber, collumNumber);
            Assert.IsTrue(d);
        }

        [Theory(DisplayName = "UnSortable")]
        [TestCase(2, 2)]
        public void UnSortable(int tableNumber, int collumNumber)
        {
            var d = SortableDataTables.IsUnSortable(tableNumber, collumNumber);
            Assert.IsTrue(d);
        }

        [Theory(DisplayName = "Edit")]
        [TestCase(true)]
        public void Edit(bool expected)
        {
            Assert.That(SortableDataTables.ClickEdit(), Is.EqualTo(expected));
        }

        //Seventh Task Hovers
        [Theory(DisplayName = "Hover")]
        [Test]
        public void Hover()
        {
            Hovers.FK();

            Assert.Pass();
        }


        [TearDown]
        public void TreadDown()
        {
           // Driver.QuitDriver();
            //Driver.DisposeDriver();
        }
    }
}