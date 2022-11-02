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

namespace jogo_da_forca
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MostrarFotos();

        }
        bool definePalavra = false;
        string palavraInformada = "";
        string acertosDaPalavra = "";
        int totalErros = 0;
        public void EsconderFotos()
        {
            bncCabeca.Visibility = Visibility.Hidden;
            bncCorpo.Visibility = Visibility.Hidden;
            bncBracoDireito.Visibility = Visibility.Hidden;
            bncBracoEsquerdo.Visibility = Visibility.Hidden;
            bncPernaDireita.Visibility = Visibility.Hidden;
            bncPernaEsquerda.Visibility = Visibility.Hidden;
        }
        public void MostrarFotos()
        {
            bncCabeca.Visibility = Visibility.Visible;
            bncCorpo.Visibility = Visibility.Visible;
            bncBracoDireito.Visibility = Visibility.Visible;
            bncBracoEsquerdo.Visibility = Visibility.Visible;
            bncPernaDireita.Visibility = Visibility.Visible;
            bncPernaEsquerda.Visibility = Visibility.Visible;
        }

        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
            if(definePalavra == false)
            {
                if(txtPalavra.Text != "" && txtPalavra.Text != " ")
                {
                    EsconderFotos();
                    foreach (char i in txtPalavra.Text.ToString())
                    {
                        palavraInformada += i;
                        acertosDaPalavra += "#";

                    }

                    txtPalavra.MaxLength = 1;

                    txtFrase.Text = acertosDaPalavra;
                    txtPalavra.Text = "";
                    definePalavra = true;
                }    
            }
            else
            {
                if (txtPalavra.Text != "" && txtPalavra.Text != " ")
                {
                    txtFrase.Text = "";
                    bool achouLetra = false;
                    string acertoTemporario = "";
                    for (int i = 0; i < palavraInformada.Length; i++)
                    {
                        if (txtPalavra.Text.ToUpper() == palavraInformada[i].ToString().ToUpper())
                        {
                            txtFrase.Text += $"{txtPalavra.Text.ToUpper()}";
                            acertoTemporario += txtPalavra.Text.ToUpper();
                            achouLetra = true;
                        }
                        else
                        {
                            txtFrase.Text += $"{acertosDaPalavra[i]}";
                            acertoTemporario += acertosDaPalavra[i];
                        }
                        

                    }                    
                    acertosDaPalavra = acertoTemporario;
                    if (achouLetra == false)
                    {

                        totalErros++;
                        txtLetrasErradas.Text += $"{txtPalavra.Text.ToUpper()}.";
                        CalculaErros();

                    }
                    else
                    {
                        VerificaVitoria();
                    }
                    
                    txtPalavra.Text = "";
                    
                }
            }
           
        }
        private void SairDaAplicacao(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CalculaErros()
        {

            if (totalErros == 1)
            {
                bncCabeca.Visibility = Visibility.Visible;
            }
            else if (totalErros == 2)
            {
                bncCorpo.Visibility = Visibility.Visible;
            }
            else if (totalErros == 3)
            {
                bncBracoDireito.Visibility = Visibility.Visible;
            }
            else if (totalErros == 4)
            {
                bncPernaDireita.Visibility = Visibility.Visible;
            }
            else if (totalErros == 5)
            {
                bncBracoEsquerdo.Visibility = Visibility.Visible;
            }
            else if(totalErros == 6)
            {
                bncPernaEsquerda.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Você Perdeu", "Péssimo", MessageBoxButton.OK, MessageBoxImage.Information);
                EstadosIniciaisJogo();
            }
        }

        private void VerificaVitoria()
        {
            if (acertosDaPalavra.ToUpper() == palavraInformada.ToUpper())
            {
                MessageBox.Show("Você Ganhou!", "Parabéns!", MessageBoxButton.OK, MessageBoxImage.Information);
                EstadosIniciaisJogo();
            }
        }

        private void EstadosIniciaisJogo()
        {
            definePalavra = false;
            btnJogar.Visibility = Visibility.Visible;
            txtPalavra.MaxLength = 200;
            MostrarFotos();
            txtLetrasErradas.Text = "";
            txtFrase.Text = "";
            acertosDaPalavra = "";
            palavraInformada = "";
            totalErros = 0;
        }
    }
}