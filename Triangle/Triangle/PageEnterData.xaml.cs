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

namespace Triangle
{
    /// <summary>
    /// Логика взаимодействия для PageEnterData.xaml
    /// </summary>
    public partial class PageEnterData : Page
    {
        Frame mFrame;
        public PageEnterData(Frame frame)
        {
            InitializeComponent();
            mFrame = frame;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (checkCorrectData(A.Text) && checkCorrectData(B.Text) && checkCorrectData(C.Text))
            {
                int firstSide, secondSide, thirdSide;
                firstSide = Convert.ToInt32(A.Text);
                secondSide = Convert.ToInt32(B.Text);
                thirdSide = Convert.ToInt32(C.Text);
                mFrame.Navigate(new PageResult(mFrame, firstSide, secondSide, thirdSide));
            }
        }

        bool checkCorrectData(string Data)
        {
            try
            {
                Convert.ToInt32(Data);
            }
            catch
            {
                MessageBox.Show("Введены некорректные данные! \n!(Есть пробел между числами или невозможно преобразование в число)!", "Ошибка!");
                A.Text = null;
                B.Text = null;
                C.Text = null;
                return false;
            }
            if (String.IsNullOrEmpty(Data) || String.IsNullOrWhiteSpace(Data))
            {
                MessageBox.Show("Введены некорректные данные!", "Ошибка!");
                A.Text = null;
                B.Text = null;
                C.Text = null;
                return false;
            }
            if(Convert.ToInt32(Data) == '0' || Convert.ToInt32(Data) <= 0 || Convert.ToInt32(Data) == 0)
            {
                MessageBox.Show("Введены некорректные данные! \n(Есть нулевая сторона или отрицательная", "Ошибка!");
                A.Text = null;
                B.Text = null;
                C.Text = null;
                return false;
            }
            else if (Convert.ToInt32(A.Text) + Convert.ToInt32(B.Text) < Convert.ToInt32(C.Text) || Convert.ToInt32(B.Text) + Convert.ToInt32(C.Text) < Convert.ToInt32(A.Text) || Convert.ToInt32(C.Text) + Convert.ToInt32(A.Text) < Convert.ToInt32(B.Text))
            {
                MessageBox.Show("Введены некорректные данные! \n(Получен невозможный треугольник, что, невозможно", "Ошибка!");
                A.Text = null;
                B.Text = null;
                C.Text = null;
                return false;
            }
            else return true;
        }

        private void A_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void B_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void C_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
