using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryBakery
{
	/// <summary>
	/// Class for create object fabric method
	/// </summary>
	public class Fabrics
	{
		/// <summary>
		/// Find summa elements into massiv, consist of word one obect
		/// </summary>
		/// <param name="begin"> The index of the element 
		/// in the array from which to search for the sum</param>
		/// <param name="mas">An array containing the required data</param>
		/// <returns>Summa</returns>
		private double Total(int begin, string[] mas)
		{
			double sum = 0;
			for (int i = begin; i < mas.Length; i += 4)
			{
				sum += Convert.ToDouble(Regex.Replace(
					mas[i], @"[^\d\,]", ""));
			}
			return sum;
		}

		/// <summary>
		/// Creating an object of the required class
		/// </summary>
		/// <param name="mas">Array with data about object</param>
		/// <param name="name">Name object</param>
		/// <param name="numerous">Numerous object</param>
		/// <returns>Object type Bakery</returns>
		public Bakery MakeObject(string[] mas, string name, int numerous)
		{
			Bakery bakery = null;
			double volume, price, calorie;
			volume = Total(1, mas);
			price = Total(2, mas);
			calorie = Total(3, mas);

			switch (name)
			{
				case "Лаваш":
					bakery = new Lavash(mas, volume, price, calorie, numerous);
					break;
				case "Хлеб 'Бородинский'":
					bakery = new Bread(mas, volume, price, calorie, numerous);
					break;
				case "Булка":
					bakery = new Bun(mas, volume, price, calorie, numerous);
					break;
				case "Батон":
					bakery = new Loaf(mas, volume, price, calorie, numerous);
					break;
				case "Багет":
					bakery = new Baget(mas, volume, price, calorie, numerous);
					break;
				case "Бублик":
					bakery = new Bublic(mas, volume, price, calorie, numerous);
					break;
				case "Хлеб ржаной":
					bakery = new BreadRye(mas, volume, price, calorie, numerous);
					break;
				default:
					break;
			}
			return bakery;
		}

	}
}
