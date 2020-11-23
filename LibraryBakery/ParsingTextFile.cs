using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LibraryBakery
{
	/// <summary>
	///A class for reading a text file and splitting its lines into an array
	/// </summary>
	public class ParsingTextFile
	{

		/// <summary>
		/// 2D array processing and object creation(via factory method)
		/// </summary>
		/// <param name="general_mas">2D array consist words</param>
		/// <param name="count">Numerous object</param>
		/// <returns>Array bakery objects</returns>
		private Bakery[] CutStrok(string[][] general_mas, int count)
		{
			Fabrics fabric = new Fabrics();
			Bakery[] bakers = new Bakery[count];
			string[] mas;

			int start = 0;
			int end = 0;
			int x;
			for (int i = 0; i < count; i++)
			{
				if (end + 1 != general_mas.Length)
					end++;
				while (end < general_mas.Length && general_mas[end].Length != 2)
					end++;

				mas = new string[(end - start - 1) * 4];
				x = 0;

				string name = general_mas[start][0];
				int numerous = Convert.ToInt32(Regex.Replace(
					general_mas[start][1], @"[^\d]", ""));

				start++;
				while (start < end)
				{
					mas[x] = general_mas[start][0].Trim();
					mas[x + 1] = general_mas[start][1];
					mas[x + 2] = general_mas[start][2];
					mas[x + 3] = general_mas[start][3];
					x += 4;
					start++;
				}

				bakers[i] = fabric.MakeObject(mas, name, numerous);
			}
			return bakers;
		}

		/// <summary>
		/// Breaking strok by word in 2D array
		/// </summary>
		/// <returns>Array bakery objects</returns>
		public Bakery[] BreakingStrokInBakers()
		{
			string res = ReadFile();

			string[][] general_mas;
			// определение количества категорий путем нахождения количества слов "шт" 
			int count = (res.Length - res.Replace("шт", "").Length) / 2;

			string[] lines = res.Split(new string[] { "\n" },
				StringSplitOptions.RemoveEmptyEntries);

			general_mas = new string[lines.Length][];

			for (int i = 0; i < lines.Length; i++)
			{
				general_mas[i] = lines[i].Split(new string[] { "  " },
					StringSplitOptions.RemoveEmptyEntries);
			}

			return CutStrok(general_mas, count);
		}

		/// <summary>
		/// Checking for the existence of a file and reading 
		/// it into one string variable
		/// </summary>
		/// <returns>Text inside file</returns>
		private string ReadFile()
		{
			string path = @"D:\Учеба\Training\DeclaringAndCalling\LibraryBakery\TextFile.txt";
			string res;

			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					res = sr.ReadToEnd();
					return res;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();

			return "";
		}

	}
}
