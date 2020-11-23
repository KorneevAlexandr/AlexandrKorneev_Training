using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBakery
{
	/// <summary>
	/// Class for show menu
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
		/// Method Show menu and work with Bakery array
		/// </summary>
		public void ShowMenu()
		{
			ParsingTextFile pars = new ParsingTextFile();
			Bakery[] bakers = pars.BreakingStrokInBakers();

			Options options = new Options(bakers);

			string user = "";
			while (user != "7")
			{
				Console.WriteLine("\n\tМеню");
				Console.WriteLine("1 - Вывод всех изделий");
				Console.WriteLine("2 - Упорядочевание изделий по калорийности");
				Console.WriteLine("3 - Упорядочевание изделий по стоимости");
				Console.WriteLine("4 - Нахождение одинаковых изделий по заданной стоимости и калорийности");
				Console.WriteLine("5 - Нахождение изделий, у которых объем использования ингридиента" +
					" большего заданного значения");
				Console.WriteLine("6 - Нахождение изделий, у которых число ингридиентов " +
					"больше заданного значения");
				Console.WriteLine("7 - Выход");
				Console.WriteLine("\nВыберите пункт меню: \n> ");
				user = Console.ReadLine();

				switch (user)
				{
					case "1":
						Console.WriteLine("\nВсе изделия: \n");
						PrintMas(bakers);
						break;

					case "2":
						Console.WriteLine("\nКлонирование массива и его " +
							"сортировка по калорийности\n");
						PrintMas(options.CloneSortCalorie());
						break;

					case "3":
						Console.WriteLine("\nКопирование массива и его " +
							"сортировка по стоимости\n");
						PrintMas(options.CopySortPrice());
						break;

					case "4":
						double user_price, user_calorie;
						Console.WriteLine("Введите стоимость для поиска: ");
						user_price = Convert.ToDouble(Console.ReadLine());
						Console.WriteLine("Введите калорийность для поиска: ");
						user_calorie = Convert.ToDouble(Console.ReadLine());

						Console.WriteLine("\nВсе изделия, равные по стоимости и " +
							"калорийности заданному: \n");
						PrintMas(options.FindSamePriceCalorie(user_price, user_calorie));
						break;

					case "5":
						string name_ingridient;
						double volume;
						Console.WriteLine("Введите название ингридиента: ");
						name_ingridient = Console.ReadLine();
						Console.WriteLine("Введите количества ингиридиента '{0}': ", name_ingridient);
						volume = Convert.ToDouble(Console.ReadLine());

						Console.WriteLine("\nИзделия, у которых ингридиента '{0}' " +
							"больше {1}\n", name_ingridient, Convert.ToString(volume));
						PrintMas(options.FindBigVolume(name_ingridient, volume));
						break;

					case "6":
						int numerous;
						Console.WriteLine("Введите количество ингридиентов: ");
						numerous = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("\nИзделия, у которых количество " +
							"ингридиентов больше {0}\n", Convert.ToString(numerous));
						PrintMas(options.FindMoreIngridients(numerous));
						break;

					case "7":
						Console.WriteLine("До свидания!");
						break;

					default:
						Console.WriteLine("Такого пункта меню нету!");
						break;
				}

				Console.WriteLine("\nПонятно (Enter) ");
				Console.ReadKey();
			}

			Console.ReadKey();

		}
	}
}
