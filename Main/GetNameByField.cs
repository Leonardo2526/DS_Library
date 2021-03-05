using System;
using System.IO;
using System.Collections;


namespace FilesRename
{
	class Program
	{

		static void Main(string[] args)
		{
			//Name of input file
			DirectoryInfo d = new DirectoryInfo(@Path.GetDirectoryName(@"D:\OneDrive\Рабочая папка ГЦМ\Тест\Координация\"));//Assuming Test is your Folder
				FileInfo[] Files = d.GetFiles("*.*"); //Getting files

			string [] str = new string[Files.Length];
			int FN = 0;

			try
			{
				//Through each file iterating
				foreach (FileInfo file in Files)
				{
					FN += 1;
					if (file.Extension == ".nwd" || file.Extension == ".nwf")
					{
						int i = 0;
						int indS = 0;
						int[] n = new int[10];
						int[] ind = new int[file.Name.Length];

						//Through each symbol in file name iterating
						foreach (char sign in file.Name)
                        {
							indS += 1;

							if (sign.ToString() == "_")
                            {
								i += 1;

								//Count of findings
								n[i] = i;

								//Index of findings
								ind[i] = indS;

								//Record of new string
								if (n[i] == 2)
                                {
									str[FN] += file.Name.Substring(ind[i-1], ind[i] - ind[i - 1]); 
								}
								else if (n[i] == 4 )
                                {
									str[FN] += file.Name.Substring(ind[i - 1], ind[i] - ind[i - 1] - 1);
								}
							}
						}
						 
					}
					Console.WriteLine(str[FN]);
				}
			}
			catch (Exception)
			{ }

			Console.ReadKey();
		}
	}
}
