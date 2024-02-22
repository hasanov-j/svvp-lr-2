using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace project_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student = new Student();
        public MainWindow()
        {
            InitializeComponent();
            foreach(UniversityCourse course in Enum.GetValues(typeof(UniversityCourse))) {
                comboBoxCourse.Items.Add(course);
            }
            comboBoxCourse.SelectedIndex = 0;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            student.FirstName = textBoxFirstName.Text;
            student.LastName = textBoxLastName.Text;

            string patternPassNumber = @"^Y-0200-0000([0-9]{6})$";
            bool isValidPassNumber = System.Text.RegularExpressions.Regex.IsMatch(textBoxPassNumber.Text, patternPassNumber);
            if (textBoxPassNumber.Text.Length>0 && isValidPassNumber)
            {
                student.PassNumber = textBoxPassNumber.Text;
            } else {
                MessageBox.Show("Заполните числами X.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            string patternGroup = @"^\w{2}-[0-9]{2}-[0-9]{2}$";
            bool isValidGroup = System.Text.RegularExpressions.Regex.IsMatch(textBoxGroup.Text, patternGroup);
            if (textBoxGroup.Text.Length>0 && isValidGroup)
            {
                student.GroupName = textBoxGroup.Text;
            } else {
                MessageBox.Show("Заполните как в примере", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(datePickerDoi.SelectedDate.HasValue)
            {
                student.Doi = datePickerDoi.SelectedDate.Value;
            }

            student.Scholarship = checkBoxScholarship.IsChecked.Value;

            student.Age = (int) sliderAge.Value;


            if(radioButtonMale.IsChecked == true)
            {
                student.Sex = Gender.male;
            }
            if(radioButtonFemale.IsChecked == true)
            {
                student.Sex = Gender.female;
            }
            if(radioButtonOther.IsChecked == true)
            {
                student.Sex = Gender.other;
            }


            if (comboBoxCourse.SelectedValue != null)
            {
                student.Course = (UniversityCourse)comboBoxCourse.SelectedValue;
            }


            MessageBox.Show(student.ToString());
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            student = new Student()
            {
                FirstName = "Harry",
                LastName = "Windsor",
                PassNumber = "Y-0200-0000108330",
                GroupName = "RN-20-06",
                Doi = new DateTime(2020,9,15),
                Scholarship = true,
                Age = 21,
                Sex = Gender.male,
                Course = UniversityCourse.third,
                ImagePath = "images/harry-windsor.jpg",

            };

            textBoxFirstName.Text = student.FirstName;
            textBoxLastName.Text = student.LastName;
            textBoxPassNumber.Text = student.PassNumber;
            textBoxGroup.Text = student.GroupName;
            datePickerDoi.SelectedDate = student.Doi;
            checkBoxScholarship.IsChecked = student.Scholarship;
            sliderAge.Value = student.Age;
            switch (student.Sex)
            {
                case Gender.male: radioButtonMale.IsChecked = true; break;
                case Gender.female: radioButtonFemale.IsChecked = true; break;
                case Gender.other: radioButtonOther.IsChecked = true;break;
            }
            comboBoxCourse.SelectedItem = student.Course;
            image.Source = new BitmapImage(new Uri(student.ImagePath, UriKind.RelativeOrAbsolute));

        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файлы (jpg)|*.jpg|Все файлы|*.*";
            if(dialog.ShowDialog() == true)
            {
                student.ImagePath = dialog.FileName;
                image.Source = new BitmapImage(new Uri(student.ImagePath, UriKind.RelativeOrAbsolute));
            }
            
        }

        private void ButtonCLear_Click(object sender, RoutedEventArgs e)
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPassNumber.Clear();
            textBoxGroup.Clear();
            datePickerDoi.SelectedDate = null;
            checkBoxScholarship.IsChecked = false;
            sliderAge.Value=18;
            radioButtonFemale.IsChecked=false;
            radioButtonOther.IsChecked=false;
            radioButtonMale.IsChecked=false;
            comboBoxCourse.SelectedItem = null;
            image.Source = new BitmapImage(new Uri("images/none.jpg",UriKind.RelativeOrAbsolute));
        }
    } 
}
