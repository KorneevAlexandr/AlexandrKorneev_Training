using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryBakery
{
	/// <summary>
	/// Child class baget
	/// </summary>
	public class Baget : Bakery
	{
		/// <summary>
		/// Array with ingridient
		/// </summary>
		private string[] data_line;
		/// <summary>
		/// Markup for price
		/// </summary>
		private static double markup = 2;

		/// <summary>
		/// Constructor for product initialization
		/// </summary>
		/// <param name="data_line">Array with ingridient</param>
		/// <param name="Weight">Product weight</param>
		/// <param name="Price">Product price</param>
		/// <param name="Calorie">Product Calorie</param>
		/// <param name="Numerous">Product numerous</param>
		public Baget(string[] data_line, double Weight, double Price, double Calorie, int Numerous)
			: base(Weight, Price, Calorie, Numerous, markup)
		{
			this.data_line = new string[data_line.Length];
			for (int i = 0; i < data_line.Length; i++)
			{
				this.data_line[i] = data_line[i];
			}
		}

		/// <summary>
		/// Finding products for which the use of an ingredient 
		/// is greater than the specified value
		/// </summary>
		/// <param name="name_ingridient">Name of the ingredient being searched for</param>
		/// <param name="volume">Ingredient amount</param>
		/// <returns>true - if there is more ingredient, false - if less or no ingredient</returns>
		public override bool ComparisonVolume(string name_ingridient, double volume)
		{
			double mas_volume;
			bool have = data_line.Any(n => n == name_ingridient);
			bool result = false;
			if (have)
			{
				mas_volume = Convert.ToDouble(Regex.Replace(
					data_line[Array.IndexOf(data_line, name_ingridient) + 1], @"[^\d\,]", ""));
				if (mas_volume > volume) result = true;
			}
			return result;
		}

		/// <summary>
		/// Finding products for which the use of an ingredient 
		/// is greater than the specified value
		/// </summary>
		/// <param name="name_ingridient">Name of the ingredient being searched for</param>
		/// <param name="volume">Ingredient amount</param>
		/// <returns>true - if there is more ingredient, false - if less or no ingredient</returns>
		public override bool NumerousIngridients(int numerous)
		{
			bool result = false;
			if (data_line.Length / 4 > numerous) result = true;
			return result;
		}

		/// <summary>
		/// Overriding the ToString method
		/// </summary>
		/// <returns>Product information line</returns>
		public override string ToString()
		{
			return String.Format("Багет: {0} штук\nМасса: {1} кг\n" +
				"Цена: {2} р\nКалорийность: {3} Дж\nНаценка: {4}\n", Convert.ToString(Numerous),
				Convert.ToString(Weight), Convert.ToString(Price), Convert.ToString(Calorie),
				Convert.ToString(markup));
		}
		/// <summary>
		/// Overriding the Equals method
		/// </summary>
		/// <param name="obj">Compared object</param>
		/// <returns>True - if objects same, false - if objects different</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Baget B = obj as Baget;
			if (B as Baget == null)
				return false;

			for (int i = 0; data_line.Length == B.data_line.Length
				&& i < data_line.Length; i++)
			{
				if (data_line[i] != B.data_line[i])
					return false;
			}
			return true;
		}

		/// <summary>
		/// Hash function
		/// </summary>
		/// <returns>Hash code (length array)</returns>
		public override int GetHashCode()
		{
			return data_line.Length;
		}

	}
}
