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
    /// Логика взаимодействия для PageResult.xaml
    /// </summary>
    public partial class PageResult : Page
    {
        int A { get; set; }
        int B { get; set; }
        int C { get; set; }
        Frame mFrame;
        public PageResult(Frame frame, int A, int B, int C)
        {
            InitializeComponent();
            this.A = A;
            this.B = B;
            this.C = C;
            mFrame = frame;
            checkState();
        }

        void checkState()
        {
            if (A == B && B == C && A == C)
            {
                setState("Получен равносторонний треугольник");
            }
            else if (A != B && B != C && A != C)
            {
                setState("Получен разносторонний треугольник");
            }
            
            else
            {
                setState("Получен равнобедренный треугольник");
            }
        }

        void setState(string result)
        {
            lbResult.Content = result;
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new PageEnterData(mFrame));
        }
    }
}
