using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBakery
{
	/// <summary>
	/// Class with the implementation of work with an array of products
	/// </summary>
	public class Options
	{
		/// <summary>
		/// Array type Bakery
		/// </summary>
		Bakery[] bakers;

		/// <summary>
		/// Constructor to initialize an array Bakery
		/// </summary>
		/// <param name="bakers">Bakery array</param>
		public Options(Bakery[] bakers)
		{
			this.bakers = new Bakery[bakers.Length];
			for (int i = 0; i < bakers.Length; i++)
			{
				this.bakers[i] = bakers[i]; 
			}
		}

		/// <summary>
		/// Clone Bakery array and it is sorted by calorie content(ascending)
		/// </summary>
		/// <returns>Sorted array</returns>
		public Bakery[] CloneSortCalorie()
		{
			Bakery[] CloneBakers = (Bakery[])bakers.Clone();

			Bakery tmp;
			int len = bakers.Length;
			for (int i = 0; i < CloneBakers.Length - 1; i++)
			{
				for (int j = 0; j < len - 1; j++)
				{
					if (CloneBakers[j].Calorie > CloneBakers[j + 1].Calorie)
					{
						tmp = CloneBakers[j];
						CloneBakers[j] = CloneBakers[j + 1];
						CloneBakers[j + 1] = tmp;
					}
				}
				len--;
			}

			return CloneBakers;
		}

		/// <summary>
		/// Copy Bakery array and it is sorted by price (ascending)
		/// </summary>
		/// <returns>Sorted array</returns>
		public Bakery[] CopySortPrice()
		{
			Bakery[] CopyBakery = new Bakery[bakers.Length];
			Array.Copy(bakers, 0, CopyBakery, 0, bakers.Length);

			Bakery tmp;
			int len = bakers.Length;
			for (int i = 0; i < CopyBakery.Length - 1; i++)
			{
				for (int j = 0; j < len - 1; j++)
				{
					if (CopyBakery[j].Price > CopyBakery[j + 1].Price)
					{
						tmp = CopyBakery[j];
						CopyBakery[j] = CopyBakery[j + 1];
						CopyBakery[j + 1] = tmp;
					}
				}
				len--;
			}

			return CopyBakery;
		}

		/// <summary>
		/// Finding products with the same specified value and calorie content
		/// </summary>
		/// <returns>Array Bakery with suitable products</returns>
		public Bakery[] FindSamePriceCalorie()
		{
			Bakery[] same_bakers = new Bakery[bakers.Length];

			int j = 0;
			for (int i = 0; i < bakers.Length - 1; i++)
			{
				for (int k = i + 1; k < bakers.Length - 1; k++)
				{
					if (bakers[i].Price == bakers[k].Price && bakers[i].Calorie == bakers[k].Calorie)
					{
						if (j == 0)
						{
							same_bakers[j] = bakers[i];
							j++;
						}
						same_bakers[j] = bakers[k];
						j++;
					}
				}
			}

			return same_bakers;
		}

		/// <summary>
		/// Finding products for which the use of ingredients is greater
		/// than the specified value
		/// </summary>
		/// <param name="name_ingridient">Name ingridients entered user</param>
		/// <param name="volume">Weight entered user</param>
		/// <returns>Array Bakery with suitable products</returns>
		public Bakery[] FindBigVolume(string name_ingridient, double volume)
		{
			Bakery[] need_bakers = new Bakery[bakers.Length];

			int j = 0;
			for (int i = 0; i < bakers.Length; i++)
			{
				if (bakers[i].ComparisonVolume(name_ingridient, volume))
				{
					need_bakers[j] = bakers[i];
					j++;
				}
			}

			return need_bakers;
		}

		/// <summary>
		/// Finding products with more ingredients than a given number
		/// </summary>
		/// <param name="numerous">Defined amount of ingredients</param>
		/// <returns>Array Bakery with suitable products</returns>
		public Bakery[] FindMoreIngridients(int numerous)
		{
			Bakery[] need_bakers = new Bakery[bakers.Length];

			int j = 0;
			for (int i = 0; i < bakers.Length; i++)
			{
				if (bakers[i].NumerousIngridients(numerous))
				{
					need_bakers[j] = bakers[i];
					j++;
				}
			}

			return need_bakers;
		}

	}
}
