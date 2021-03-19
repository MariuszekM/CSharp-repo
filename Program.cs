using System;
using System.IO;
namespace NaturalMerge
{
	public class SortFile
	{
		static void Main(string[] args)
		{
			bool isEmpty2 = false;
			while (!isEmpty2)
			{
				// Rozdzielanie pliku
				try
				{
					using (StreamReader sr = new StreamReader(args[0]))
					{
						string line = null;
						string prevline = null;

						using (StreamWriter sw1 = new StreamWriter(args[1]))
						{
							using (StreamWriter sw2 = new StreamWriter(args[2]))
							{
								isEmpty2 = true;
								bool swapFiles = true;
								if ((line = sr.ReadLine()) != null)
								{
									sw1.WriteLine(line);
									prevline = line;
								}
								while ((line = sr.ReadLine()) != null)
								{
									if (prevline.CompareTo(line) > 0)
										swapFiles = !swapFiles;
									if (swapFiles)
										sw1.WriteLine(line);
									else
									{
										sw2.WriteLine(line);
										isEmpty2 = false;
									}
									prevline = line;
								}
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("The file could not be read");
					Console.WriteLine(e.Message);
				}
				//Scalanie plików 
				string tmp1, tmp2;
				string prevTmp1 = null;
				string prevTmp2 = null;
				bool endOfRunTmp1, endOfRunTmp2;
				try
				{
					using (StreamReader sr1 = new StreamReader(args[1]))
					{
						try
						{
							using (StreamReader sr2 = new StreamReader(args[2]))
							{
								using (StreamWriter sw = new StreamWriter(args[0]))
								{
									tmp1 = sr1.ReadLine();
									tmp2 = sr2.ReadLine();
									endOfRunTmp1 = (tmp1 == null);
									endOfRunTmp2 = (tmp2 == null);
									while (tmp1 != null || tmp2 != null)
									{
										while (!endOfRunTmp1 && !endOfRunTmp2)
											if (tmp2.CompareTo(tmp1) > 0)
											{
												sw.WriteLine(tmp1);
												prevTmp1 = tmp1;
												tmp1 = sr1.ReadLine();
												if (tmp1 == null || prevTmp1.CompareTo(tmp1) > 0)
													endOfRunTmp1 = true;
											}
											else
											{

												sw.WriteLine(tmp2);
												prevTmp2 = tmp2;
												tmp2 = sr2.ReadLine();
												if (tmp2 == null || prevTmp2.CompareTo(tmp2) > 0)
													endOfRunTmp2 = true;
											}
										while (!endOfRunTmp1)
										{

											sw.WriteLine(tmp1);
											prevTmp1 = tmp1;
											tmp1 = sr1.ReadLine();
											if (tmp1 == null || prevTmp1.CompareTo(tmp1) > 0)
												endOfRunTmp1 = true;
										}
										while (!endOfRunTmp2)
										{
											sw.WriteLine(tmp2);
											prevTmp2 = tmp2;
											tmp2 = sr2.ReadLine();
											if (tmp2 == null || prevTmp2.CompareTo(tmp2) > 0)
												endOfRunTmp2 = true;
										}
										endOfRunTmp1 = (tmp1 == null);
										endOfRunTmp2 = (tmp2 == null);
										prevTmp1 = null;
										prevTmp2 = null;
									}
								}
							}
						}
						catch (Exception e)
						{
							Console.WriteLine("The file could not be read");
							Console.WriteLine(e.Message);
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("The file could not be read");
					Console.WriteLine(e.Message);
				}

			}
		}
	}
}
