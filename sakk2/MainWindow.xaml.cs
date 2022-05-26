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
        static Label[,] cimkek = new Label[8, 8];
        static object figura = new object();
        public MainWindow()
        {
            InitializeComponent();
            TablaGeneralas();
        }
        private void Click(object sender, MouseEventArgs e)
        {
            try
            {
                Refresh();
                object kuldo = sender;
                figura = figurak.SelectedItem;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if(cimkek[i,j] == kuldo)
                        {
                            cimkek[i,j].Content = figura;
                            teszt1.Content = figura.ToString();
                            if(figura.ToString().Contains("♙"))
                            {
                                cellak[i, j + 1].Fill = Brushes.Red;
                                cellak[i, j + 2].Fill = Brushes.Red;
                            }
                            else if (figura.ToString().Contains("♟"))
                            {
                                cellak[i, j - 1].Fill = Brushes.Red;
                                cellak[i, j - 2].Fill = Brushes.Red;
                            }
                            else if (figura.ToString().Contains("♖"))
                            {
                                for (int k = 0; k < 8; k++)
                                {
                                    cellak[k, j].Fill = Brushes.Red;
                                    cellak[i, k].Fill = Brushes.Red;
                                }
                                if ((i + j) % 2 == 0)
                                    cellak[i, j].Fill = Brushes.Black;
                                else
                                    cellak[i, j].Fill = Brushes.White;
                            }
                            else if (figura.ToString().Contains("♗"))
                            {
                                for (int k = 0; k < 8; k++)
                                {
                                    if (validLepes(i + k, j + k))
                                        cellak[i + k, j + k].Fill = Brushes.Red;
                                    if (validLepes(i - k, j - k))
                                        cellak[i - k, j - k].Fill = Brushes.Red;
                                    if (validLepes(i + k + 1, j - k - 1))
                                        cellak[i + k + 1, j - k - 1].Fill = Brushes.Red;
                                    if (validLepes(i - k - 1, j + k + 1))
                                        cellak[i - k - 1, j + k + 1].Fill = Brushes.Red;
                                }
                                if ((i + j) % 2 == 0)
                                    cellak[i, j].Fill = Brushes.Black;
                                else
                                    cellak[i, j].Fill = Brushes.White;
                            }
                            else if (figura.ToString().Contains("♘"))
                            {
                                if(validLepes(i + 2, j + 1))
                                    cellak[i + 2, j + 1].Fill = Brushes.Red;
                                if (validLepes(i + 1, j + 2))
                                    cellak[i + 1, j + 2].Fill = Brushes.Red;
                                if (validLepes(i - 1, j + 2))
                                    cellak[i - 1, j + 2].Fill = Brushes.Red;
                                if (validLepes(i - 2, j + 1))
                                    cellak[i - 2, j + 1].Fill = Brushes.Red;
                                if (validLepes(i - 2, j - 1))
                                    cellak[i - 2, j - 1].Fill = Brushes.Red;
                                if (validLepes(i - 1, j - 2))
                                    cellak[i - 1, j - 2].Fill = Brushes.Red;
                                if (validLepes(i + 1, j - 2))
                                    cellak[i + 1, j - 2].Fill = Brushes.Red;
                                if (validLepes(i + 2, j - 1))
                                    cellak[i + 2, j - 1].Fill = Brushes.Red;
                            }
                            else if (figura.ToString().Contains("♕"))
                            {
                                for (int k = 0; k < 8; k++)
                                {
                                    if (validLepes(k, j))
                                        cellak[k, j].Fill = Brushes.Red;
                                    if (validLepes(i,k))
                                        cellak[i, k].Fill = Brushes.Red;
                                    if (validLepes(i + k, j + k))
                                        cellak[i + k, j + k].Fill = Brushes.Red;
                                    if (validLepes(i - k, j - k))
                                        cellak[i - k, j - k].Fill = Brushes.Red;
                                    if (validLepes(i + k + 1, j - k - 1))
                                        cellak[i + k + 1, j - k - 1].Fill = Brushes.Red;
                                    if (validLepes(i - k - 1, j + k + 1))
                                        cellak[i - k - 1, j + k + 1].Fill = Brushes.Red;
                                }
                                if ((i + j) % 2 == 0)
                                    cellak[i, j].Fill = Brushes.Black;
                                else
                                    cellak[i, j].Fill = Brushes.White;
                            }
                            else if (figura.ToString().Contains("♔"))
                            {
                                if (validLepes(i + 1, j))
                                    cellak[i + 1, j].Fill = Brushes.Red;
                                if (validLepes(i + 1, j+1))
                                    cellak[i + 1, j+1].Fill = Brushes.Red;
                                if (validLepes(i + 1, j-1))
                                    cellak[i + 1, j-1].Fill = Brushes.Red;
                                if (validLepes(i - 1, j))
                                    cellak[i - 1, j].Fill = Brushes.Red;
                                if (validLepes(i - 1, j+1))
                                    cellak[i - 1, j+1].Fill = Brushes.Red;
                                if (validLepes(i - 1, j-1))
                                    cellak[i - 1, j-1].Fill = Brushes.Red;
                                if (validLepes(i, j+1))
                                    cellak[i, j+1].Fill = Brushes.Red;
                                if (validLepes(i, j-1))
                                    cellak[i, j-1].Fill = Brushes.Red;
                            }
                        }
                    }
                }
            }
            catch(Exception hiba)
            {
                MessageBox.Show(hiba.ToString());
            }
        }
        private bool validLepes(int x, int y)
        {
            if (x >= 8 || x < 0 || y >= 8 || y < 0)
                return false;
            else
                return true;
        }
        private char Decode(int yPos)
        {
            char eredmeny = ' ';
            switch (yPos)
            {
                case 0:
                    eredmeny = 'A'; break;
                case 1:
                    eredmeny = 'B'; break;
                case 2:
                    eredmeny = 'C'; break;
                case 3:
                    eredmeny = 'D'; break;
                case 4:
                    eredmeny = 'E'; break;
                case 5:
                    eredmeny = 'F'; break;
                case 6:
                    eredmeny = 'G'; break;
                case 7:
                    eredmeny = 'H'; break;
            }
            return eredmeny;
        }
        private void Refresh()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        cellak[i, j].Fill = Brushes.Black;
                    else
                        cellak[i, j].Fill = Brushes.White;
                    cimkek[i, j].Content = "";
                }
            }
        }
        private void TablaGeneralas()
        {
            //táblagenerálás
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle ujCella = new Rectangle();
                    Label ujCimke = new Label();
                    if ((i + j) % 2 == 0)
                        ujCella.Fill = Brushes.Black;
                    else
                        ujCella.Fill = Brushes.White;
                    ujCella.Stroke = Brushes.Black;
                    ujCella.Width = 40;
                    ujCimke.VerticalAlignment = VerticalAlignment.Center;
                    ujCimke.HorizontalAlignment = HorizontalAlignment.Center;
                    ujCella.Height = 40;
                    ujCimke.Width = 40;
                    ujCimke.Height = 40;
                    ujCella.Margin = new Thickness(i * 40, j * 40, 0, 0);
                    ujCimke.Margin = new Thickness(i * 40, j * 40, 0, 0);
                    ujCimke.FontSize = 36;
                    ujCimke.MouseUp += Click;
                    cellak[i, j] = ujCella;
                    cimkek[i, j] = ujCimke;
                    sakktabla.Children.Add(cellak[i, j]);
                    sakktabla.Children.Add(cimkek[i, j]);
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
                betu.Width = 20;
                betu.Height = 25;
                szam.Width = 20;
                szam.Height = 25;
                szam.HorizontalAlignment = HorizontalAlignment.Left;
                szam.VerticalAlignment = VerticalAlignment.Top;
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                szam.Margin = new Thickness(253 + 40 * i, 31, 0, 0);
                betu.Margin = new Thickness(217, 63 + 40 * i, 0, 0);
                scene.Children.Add(betu);
                scene.Children.Add(szam);
            }
        }

        private void poziciokGomb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> poziciok = new List<string>();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (cellak[i, j].Fill == Brushes.Red)
                            poziciok.Add($"{Decode(j)}{i+1}");
                    }
                }
                string kiiratas = "Lépések kordinátái: ";
                for (int i = 0; i < poziciok.Count-1; i++)
                {
                    kiiratas += poziciok[i] + ", ";
                }
                kiiratas += poziciok.Last();
                MessageBox.Show(kiiratas);
            }
            catch(Exception hiba)
            {

            }
        }
    }
}
