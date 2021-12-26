using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая__9
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

        private StudentPerformance[] performance = new StudentPerformance[5];
        public int Counter;

        private void AddPerfomancePerMonth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                performance[Counter] = new StudentPerformance($"{subject.Text}", int.Parse(performancepermonth.Text));
                Counter++;
                dataGrid.ItemsSource = ToDataTable(performance).DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void AveragePerfomance_Click(object sender, RoutedEventArgs e)
        {
            List<int> result = new List<int> { };

            for (int i = 0; i < performance.Length; i++)
            {
                result.Add(performance[i].PerformancePerMonth);
            }

            resultPerfomance.Text = result.Average().ToString();
        }

        private static DataTable ToDataTable(StudentPerformance[] performance)
        {
            var result = new DataTable();

            result.Columns.Add("Дисциплина", typeof(string));
            result.Columns.Add("Успеваемость за месяц", typeof(int));

            for (int i = 0; i < performance.Length; i++)
            {
                var row = result.NewRow();
                row.ItemArray = new object[] { performance[i].Subject, performance[i].PerformancePerMonth };
                result.Rows.Add(row);
            }
            return result;
        }

        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу успеваемости студента по 5 дисциплинам с полями: дисциплина, успеваемость за месяц." +
                "Вывести результат на экран.Вывести среднюю успеваемость по всем дисциплинам.", "Задание");
        }

        private void DeveloperInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Харенко Кирилл  ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
