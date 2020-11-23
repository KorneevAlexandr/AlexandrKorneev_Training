using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBakery
{
	/// <summary>
	/// Abstract parent class of bakery products
	/// </summary>
	abstract public class Bakery
    {
		/// <summary>
		/// Product weight
		/// </summary>
		public double Weight { get; }
		/// <summary>
		/// Product price
		/// </summary>
		public double Price { get; }
		/// <summary>
		/// Product calorie
		/// </summary>
		public double Calorie { get; }
		/// <summary>
		/// Product numerous
		/// </summary>
		public int Numerous { get; }

		/// <summary>
		/// Constructor to initialize an object
		/// </summary>
		/// <param name="Weight">Product weight</param>
		/// <param name="Price">Product price</param>
		/// <param name="Calorie">Product calorie</param>
		/// <param name="Numerous">Product numerous</param>
		/// <param name="markup">Product markup (for price)</param>
		public Bakery(double Weight, double Price, double Calorie, int Numerous, double markup)
		{
			this.Weight = Weight;
			this.Price = Price * markup;
			this.Calorie = Calorie;
			this.Numerous = Numerous;
		}

		/// <summary>
		/// Finding products for which the use of an ingredient 
		/// is greater than the specified value
		/// </summary>
		/// <param name="name_ingridient">Name of the ingredient being searched for</param>
		/// <param name="volume">Ingredient amount</param>
		/// <returns>true - if there is more ingredient, false - if less or no ingredient</returns>
		abstract public bool ComparisonVolume(string name_ingridient, double volume);

		/// <summary>
		/// A method for finding the number of ingredients in a 
		/// product and comparing it with a given number
		/// </summary>
		/// <param name="numerous">Specified number</param>
		/// <returns>true - if the number of ingredients is less than the specified number,
		/// false - if less</returns>
		abstract public bool NumerousIngridients(int numerous);
	}
}
