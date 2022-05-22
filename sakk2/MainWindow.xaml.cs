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

namespace sakk2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Rectangle[,] cellak = new Rectangle[8, 8];
        public MainWindow()
        {
            InitializeComponent();
            TablaGeneralas();
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void TablaGeneralas()
        {
            //táblagenerálás
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle ujCella = new Rectangle();
                    if ((i + j) % 2 == 0)
                        ujCella.Fill = Brushes.Black;
                    else
                        ujCella.Fill = Brushes.White;
                    ujCella.Stroke = Brushes.Black;
                    ujCella.Width = 40;
                    ujCella.Height = 40;
                    ujCella.Margin = new Thickness(i * 40, j * 40, 0, 0);
                    ujCella.MouseUp += Click;
                    cellak[i, j] = ujCella;
                    sakktabla.Children.Add(cellak[i, j]);
                }
            }
            //betűk és számok generálása
            for (int i = 0; i < 8; i++)
            {
                Label szam = new Label();
                Label betu = new Label();
                szam.Content = i + 1;
                switch (i)
                {
                    case 0:
                        betu.Content = 'A';
                        break;
                    case 1:
                        betu.Content = 'B';
                        break;
                    case 2:
                        betu.Content = 'C';
                        break;
                    case 3:
                        betu.Content = 'D';
                        break;
                    case 4:
                        betu.Content = 'E';
                        break;
                    case 5:
                        betu.Content = 'F';
                        break;
                    case 6:
                        betu.Content = 'G';
                        break;
                    case 7:
                        betu.Content = 'H';
                        break;
                }
                szam.Margin = new Thickness(253 + 40 * i, 31, 0, 0);
                betu.Margin = new Thickness(217, 63 + 40 * i, 0, 0);
                scene.Children.Add(betu);
                scene.Children.Add(szam);
            }
            /*for (int i = 'A'; i < 'I'; i++)
            {
                Label betu = new Label();
                betu.Content = i;
                betu.Margin = new Thickness(217, 63 + 40 * i, 0, 0);
                scene.Children.Add(betu);
            }*/
        }
    }
}
