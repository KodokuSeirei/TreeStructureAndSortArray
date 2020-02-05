using System.Collections.Generic;
using System.Linq;


namespace TreeStructureAndSortArray
{
    public class Category
    {
        public List<Category> Childrens { get; set; } = new List<Category>();
        public Category Parent { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Category(string name)
        {
            Name = name;
        }
        //Метод добавления Сhildrens
        public void AddChild(Category category)
        {
            category.Parent = this;
            Childrens.Add(category);
            Count++;
        }
        //Заполнение Childrens из массива массивов
        public void FillFromArray(string[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            AddChild(new Category(array[i][j]));
                            break;
                        case 1:
                            Childrens[i].AddChild(new Category(array[i][j]));
                            break;
                        case 2:
                            Childrens[i].Childrens[0].AddChild(new Category(array[i][j]));
                            break;
                        case 3:
                            Childrens[i].Childrens[0].Childrens[0].AddChild(new Category(array[i][j]));
                            break;
                        case 4:
                            Childrens[i].Childrens[0].Childrens[0].Childrens[0].AddChild(new Category(array[i][j]));
                            break;
                    }
                }
            }
        }
        //Статический метод сортировки Childrens
        public static void Sort(Category category)
        {
            //Сортировка Childrens по Category.Name
            if (category.Childrens.Count > 1)
            {
                category.Childrens = category.Childrens.OrderBy(o => o.Name).ToList();
                for (int i = 0; i < category.Childrens.Count; i++)
                {
                    //Если имя элемента коллекции схоже с именем элемента следующей(соседней) коллекции, передаем ей элемент из следующей коллекции
                    if (i != category.Childrens.Count - 1 && category.Childrens[i].Name.ToString() == category.Childrens[i + 1].Name.ToString())
                    {
                        category.Childrens[i].Childrens.Add(category.Childrens[i + 1].Childrens[0]);
                        category.Childrens.Remove(category.Childrens[i + 1]);
                        i--;
                    }
                }
            }
            else return;
        }
    }
}
