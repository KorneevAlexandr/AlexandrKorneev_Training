using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryBakery;
	 
namespace TestingBakery
{
	/// <summary>
	/// Class for testing methods class Bakery
	/// </summary>
	[TestClass]
	public class TestingBakeryObjectAndMethod
	{
		/// <summary>
		/// Testing a method that finds an ingredient that is greater 
		/// than a specified amount
		/// </summary>
		[TestMethod]
		public void TestingComparisonMethod()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			double volume, price, calorie;
			int numerous = 10;
			volume = 1.2;
			price = 3;
			calorie = 200;

			Bakery product = new Bread(line, volume, price, calorie, numerous);

			string name_ing = "Вода";
			double volume_2 = 0.7;

			bool expected = true;
			bool actual = product.ComparisonVolume(name_ing, volume_2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Testing a method that finds an ingredient that is greater 
		/// than a specified amount when method return false
		/// </summary>
		[TestMethod]
		public void TestingComparisonMethod_False()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			double volume, price, calorie;
			int numerous = 10;
			volume = 1.2;
			price = 3;
			calorie = 200;

			Bakery product = new Bread(line, volume, price, calorie, numerous);

			string name_ing = "Сахар";
			double volume_2 = 1;

			bool expected = false;
			bool actual = product.ComparisonVolume(name_ing, volume_2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Testing a method that finds products with more
		/// than a specified amount of ingredients when method return false
		/// </summary>
		[TestMethod]
		public void TestingCompareNumerousIngreidient_False()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			double volume, price, calorie;
			int numerous = 10;
			volume = 1.2;
			price = 3;
			calorie = 200;

			Bakery product = new Bread(line, volume, price, calorie, numerous);

			int numerous_user = 3;

			bool expected = false;
			bool actual = product.NumerousIngridients(numerous_user);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Testing a method that finds products with more
		/// than a specified amount of ingredients
		/// </summary>
		[TestMethod]
		public void TestingCompareNumerousIngreidient()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			double volume, price, calorie;
			int numerous = 10;
			volume = 1.2;
			price = 3;
			calorie = 200;

			Bakery product = new Bread(line, volume, price, calorie, numerous);

			int numerous_user = 1;

			bool expected = true;
			bool actual = product.NumerousIngridients(numerous_user);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Equals comparison of two objects
		/// </summary>
		[TestMethod]
		public void Check_Equals_Bakery_Ans_Null()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			Bakery product = new Bread(line, 1.2, 3, 200, 10);
			Bakery product_2 = null;

			bool expected = false;
			bool actual = product.Equals(product_2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Equals comparison of two objects
		/// </summary>
		[TestMethod]
		public void Check_Equals_Bread_And_Empty_Object()
		{
			string[] line = { "Вода", "1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };

			Bakery product = new Bread(line, 1.2, 3, 200, 10);
			var obj = new Object();
			bool expected = false;

			bool actual = product.Equals(obj);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Equals comparison of two objects
		/// </summary>
		[TestMethod]
		public void Check_Equals_Different_Bakery_Object()
		{
			string[] line = { "Вода", "0,1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			string[] two_line = { "Вода", "1кг", "2р", "0Дж", "Мука пшеничная", "0,8кг", "1р", "200Дж" };

			Bakery pr1 = new Bread(line, 0.3, 3, 200, 10);
			Bakery pr2 = new Baget(two_line, 1.8, 3, 200, 12);

			bool expected = false;
			bool actual = pr1.Equals(pr2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Equals comparison of two objects
		/// </summary>
		[TestMethod]
		public void Check_Equals_Same_Bakery_Object()
		{
			string[] line = { "Вода", "0,1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };

			Bakery pr1 = new Bread(line, 0.3, 3, 200, 10);
			Bakery pr2 = new Bread(line, 0.3, 3, 200, 10);

			bool expected = true;
			bool actual = pr1.Equals(pr2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Method testing GetHashCode
		/// </summary>
		[TestMethod]
		public void Testing_GetHashCode()
		{
			string[] line = { "Вода", "0,1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			Bakery L = new Lavash(line, 0.3, 3, 3, 10);
			
			int expected = 8;
			int actual = L.GetHashCode();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Comparison of strings, which should be in the output 
		/// and returned by the ToString method
		/// </summary>
		[TestMethod]
		public void Testing_False_ToString()
		{
			string[] line = { "Вода", "0,1кг", "2р", "0Дж", "Мука", "0,2кг", "1р", "200Дж" };
			Bakery L = new Lavash(line, 0.3, 3, 200, 10);

			string expected;
			expected = "Лаваш: 10 штук\nМасса: 0,3 кг\nЦена: 4,2 р" +
				"\nКалорийность: 200 Дж\nНаценка: 1,4\n";

			string actual = L.ToString();

			Assert.AreEqual(expected, actual);
		}

	}
}
