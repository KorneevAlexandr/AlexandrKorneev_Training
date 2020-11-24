using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBakery
{
	/// <summary>
	/// Class for outputting information to the console
	/// </summary>
	public class Menu
	{
		/// <summary>
		/// Console output of all objects
		/// </summary>
		/// <param name="bakers">Bakery array of file</param>
		private void PrintMas(Bakery[] bakers)
		{
			int j = 0;
			for (int i = 0; i < bakers.Length; i++)
			{
				if (bakers[i] != null)
				{
					Console.WriteLine(bakers[i].ToString());
					j = 1;
				}
			}
			if (j == 0)
				Console.WriteLine("Таких изделий нет!");
		}

		/// <summary>
		/// A method of displaying information about all products by various methods.
		/// </summary>
		public void ShowMenu()
		{
			ParsingTextFile pars = new ParsingTextFile();
			Bakery[] bakers = pars.BreakingStrokInBakers();

			Options options = new Options(bakers);

			Console.WriteLine("\nВсе изделия: \n");
			PrintMas(bakers);

			Console.WriteLine("\nКлонирование массива и его сортировка по калорийности\n");
			PrintMas(options.CloneSortCalorie());

			Console.WriteLine("\nКопирование массива и его сортировка по стоимости\n");
			PrintMas(options.CopySortPrice());

			Console.WriteLine("\nИзделия, у которых совпадают цена и калорийность\n");
			PrintMas(options.FindSamePriceCalorie());

			string water = "Вода";
			double weight_water = 0.12;
			Console.WriteLine("\nИзделия, у которых ингридиента '{0}' больше {1} кг:\n", 
				water, Convert.ToString(weight_water));
			PrintMas(options.FindBigVolume(water, weight_water));

			Console.WriteLine("\nИзделия, у которых в составе больше 3-х ингридиентов: \n");
			PrintMas(options.FindMoreIngridients(3));

			Console.ReadKey();
		}
	}
}
