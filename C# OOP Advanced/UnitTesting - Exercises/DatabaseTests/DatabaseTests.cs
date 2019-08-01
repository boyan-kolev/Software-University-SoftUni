using _01_Database;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int ArraySize = 16;
        private const int InitialArrayIndex = -1;

        private Database database;

        [Test]
        public void EmptyConstructorShouldInintData()
        {
            database = new Database();
            Type type = typeof(Database);
            int[] field = 
                (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "data")
                .GetValue(database);

            int expectedResult = ArraySize;
            int actualResult = field.Length;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EmptyConstructorShouldInintIndexToMinusOne()
        {
            database = new Database();
            Type type = typeof(Database);
            int field =
                (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "index")
                .GetValue(database);

            int expectedResult = InitialArrayIndex;
            int actualResult = field;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWithLargerArray()
        {
            int[] arr = new int[ArraySize + 1];

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 23})]
        [TestCase(new int[] { 1, 3, 10})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldSetIndexCorrectly(int[] values)
        {
            database = new Database(values);

            Type type = typeof(Database);
            int index = (int)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "index")
                .GetValue(database);

            int expectedResult = values.Length -1;
            int actualResult = index;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 23 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        public void AddShouldIncreaIndexCorrectly(int[] values)
        {
            database = new Database(values);
            Type type = typeof(Database);

            database.Add(21);

            int index = (int)type
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .First(x => x.Name == "index")
               .GetValue(database);


            int expectedResult = values.Length;
            int actualResult = index;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWithDatabaseIsFull()
        {
            database = new Database(new int[16]);

            Assert.That(() => database.Add(12), 
                Throws.InvalidOperationException.With.Message.EqualTo("Database is full !"));
        }

        [Test]
        public void RemoveShouldDecreaseIndexCorrectly()
        {
            int[] arr = new int[10];
            database = new Database(arr);
            Type type = typeof(Database);

            database.Remove();

            int index = (int)type
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .First(x => x.Name == "index")
               .GetValue(database);

            int expectedResult = arr.Length - 2;
            int actualResult = index;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWithEmptyDatabase()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}
