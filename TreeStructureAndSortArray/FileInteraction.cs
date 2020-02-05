using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TreeStructureAndSortArray
{
   public static class FileInteraction
    {
        public static string[][] GetDataFromCsv()
        {
            //Узнаем путь к файлу
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Стартовая локация - папка с приложением
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Фильтр отображаемых файлов
            openFileDialog.Filter = "text files(*.txt; *.csv)| *.txt; *.csv|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            List<string[]> arrayList = new List<string[]>();
            string[] lines;
            //Создаем поток чтения файла 
            using (StreamReader readfile = new StreamReader(openFileDialog.FileName,Encoding.Default))
            {
               
                //Записываем строки в массив
                lines = readfile.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < lines.Length; i++)
                {
                    arrayList.Add(lines[i].Split(';'));                  
                }
            }
            return arrayList.ToArray();
        }
    }
}
