using Avalonia.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Ribki
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Создаём обработчик события ввода текста в наш Textbox чтобы в дальнейшем сделать поиск
            SearchBox.KeyUp += SearchBox_KeyUp;

            //Создаём обработчик события выбора элемента выпадающего списка чтобы в дальнейшем сделать сортировку
            SortBox.SelectionChanged += SortBox_SelectionChanged;

            //Вызываем метод в котором работаем с нашим листом
            UpdateList();
        }


        //Обработчик события ComboBox
        private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        //Обработчик события TextBox
        private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            UpdateList();
        }

        //Наш метод который мы создали для работы с листом
        public void UpdateList()
        {
            //Создание листа объектов People
            List<People> listPeoples = new List<People>();

            //Добавление данных в лист
            listPeoples.Add(new People()
            {
                id = 1,
                age = 21,
                bipol = true,
                birthday = new System.DateOnly(2003, 03, 03),
                gender = 'м',
                name = "Stephan"
            });

            listPeoples.Add(new People()
            {
                id = 2,
                age = 31,
                bipol = true,
                birthday = new System.DateOnly(2005, 03, 03),
                gender = 'м',
                name = "Alexandro"
            });

            listPeoples.Add(new People()
            {
                id = 3,
                age = 24,
                bipol = true,
                birthday = new System.DateOnly(2002, 03, 03),
                gender = 'м',
                name = "Mixa"
            });

            //Проверка Textbox на нулевое значение, а также Linq запрос для выполнения поиска
            if(SearchBox.Text != null)
            {
                listPeoples = listPeoples.Where(x=>x.name.Contains(SearchBox.Text)).ToList();
            }

            //Привязка к выбранному индексу ComboBox
            switch(SortBox.SelectedIndex)
            {
                //Linq для выборки по полу (гендеру)
                case 0:
                    listPeoples = listPeoples;
                    break;
                case 1:
                    listPeoples = listPeoples.Where(x => x.gender == 'м').ToList();
                    break;
                case 2:
                    listPeoples = listPeoples.Where(x => x.gender == 'ж').ToList();
                    break;
            }

            //Заполнение нашего ListBox
            Peopl.ItemsSource = listPeoples;
        }
    }
}