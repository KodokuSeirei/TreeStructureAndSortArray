using System;
using System.Windows;


namespace TreeStructureAndSortArray
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Category category;
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (category == null)
                    category = new Category("Категории");
                else
                    category.Childrens.Clear();

                category.FillFromArray(FileInteraction.GetDataFromCsv());
                //За это мне стыдно
                Category.Sort(category);
                for (int i = 0; i < category.Childrens.Count; i++)
                {
                    Category.Sort(category.Childrens[i]);
                    for (int j = 0; j < category.Childrens[i].Childrens.Count; j++)
                    {
                        Category.Sort(category.Childrens[i].Childrens[j]);

                        for (int g = 0; g < category.Childrens[i].Childrens[j].Childrens.Count; g++)
                        {
                            Category.Sort(category.Childrens[i].Childrens[j].Childrens[g]);
                        }
                    }
                }
               
                TreeV.ItemsSource = category.Childrens;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
    }
}

