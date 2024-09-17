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
            //������ ���������� ������� ����� ������ � ��� Textbox ����� � ���������� ������� �����
            SearchBox.KeyUp += SearchBox_KeyUp;

            //������ ���������� ������� ������ �������� ����������� ������ ����� � ���������� ������� ����������
            SortBox.SelectionChanged += SortBox_SelectionChanged;

            //�������� ����� � ������� �������� � ����� ������
            UpdateList();
        }


        //���������� ������� ComboBox
        private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        //���������� ������� TextBox
        private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            UpdateList();
        }

        //��� ����� ������� �� ������� ��� ������ � ������
        public void UpdateList()
        {
            //�������� ����� �������� People
            List<People> listPeoples = new List<People>();

            //���������� ������ � ����
            listPeoples.Add(new People()
            {
                id = 1,
                age = 21,
                bipol = true,
                birthday = new System.DateOnly(2003, 03, 03),
                gender = '�',
                name = "Stephan"
            });

            listPeoples.Add(new People()
            {
                id = 2,
                age = 31,
                bipol = true,
                birthday = new System.DateOnly(2005, 03, 03),
                gender = '�',
                name = "Alexandro"
            });

            listPeoples.Add(new People()
            {
                id = 3,
                age = 24,
                bipol = true,
                birthday = new System.DateOnly(2002, 03, 03),
                gender = '�',
                name = "Mixa"
            });

            //�������� Textbox �� ������� ��������, � ����� Linq ������ ��� ���������� ������
            if(SearchBox.Text != null)
            {
                listPeoples = listPeoples.Where(x=>x.name.Contains(SearchBox.Text)).ToList();
            }

            //�������� � ���������� ������� ComboBox
            switch(SortBox.SelectedIndex)
            {
                //Linq ��� ������� �� ���� (�������)
                case 0:
                    listPeoples = listPeoples;
                    break;
                case 1:
                    listPeoples = listPeoples.Where(x => x.gender == '�').ToList();
                    break;
                case 2:
                    listPeoples = listPeoples.Where(x => x.gender == '�').ToList();
                    break;
            }

            //���������� ������ ListBox
            Peopl.ItemsSource = listPeoples;
        }
    }
}