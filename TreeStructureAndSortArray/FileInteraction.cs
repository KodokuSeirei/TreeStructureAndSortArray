using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructureAndSortArray
{
   public static class FileInteraction
    {
        public static string[][] GetDataFromCsv()
        {
            //Узнаем путь к файлу
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Фильтр отображаемых файлов
            openFileDialog.Filter = "text files(*.txt; *.csv)| *.txt; *.csv|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            List<string[]> arrayList = new List<string[]>();
            string[] line;
            //Создаем поток чтения файла 
            using (StreamReader readfile = new StreamReader(openFileDialog.FileName,Encoding.Default))
            {
               
                //Записываем строки в массив
                line = readfile.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i++)
                {
                    arrayList.Add(line[i].Split(';'));
                    //Т.к первая строка не нужна
                    if (i == 0)
                        arrayList.Clear();
                }
            }
            return arrayList.ToArray();
        }
    }
}
