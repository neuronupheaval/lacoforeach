using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace V0005
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        const int TotalEtapas = 10;

        Dictionary<int, int> frequenciasBeep = new Dictionary<int, int>
        {
            { 0, 330 },
            { 1, 352 },
            { 2, 396 },
            { 3, 495 }
        };

        public MainWindow()
        {
            InitializeComponent();
            InicializarSequencia();

            DataContext = this;
        }

        void InicializarSequencia()
        {
            Sequencia = new int[TotalEtapas];

            for (int indice = 0; indice < Sequencia.Length; indice += 1)
            {
                Sequencia[indice] = Random.Shared.Next(0, 4);
            }
        }

        int[] sequencia = Array.Empty<int>();
        public int[] Sequencia
        {
            get => sequencia;
            set
            {
                sequencia = value;
                OnPropertyChanged();
            }
        }

        int numeroEtapasAlcancadas = 0;
        public int NumeroEtapasAlcancadas
        {
            get => numeroEtapasAlcancadas;
            set
            {
                numeroEtapasAlcancadas = value;
                OnPropertyChanged();
            }
        }

        bool vezDoGenius = true;
        public bool VezDoGenius
        {
            get => vezDoGenius;
            set
            {
                vezDoGenius = value;
                OnPropertyChanged();
            }
        }

        int posicaoNoVetor = 0;
        public int PosicaoNoVetor
        {
            get => posicaoNoVetor;
            set
            {
                posicaoNoVetor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VezDoGenius = true;
            await AplicarVezDoGeniusAsync();
        }

        async Task GerarBeepAsync(int sequencia)
        {
            SignalGenerator gen = new SignalGenerator()
            {
                Gain = 0.3,
                Frequency = frequenciasBeep[sequencia],
                Type = SignalGeneratorType.Sin,
            };

            using (WaveOutEvent wo = new WaveOutEvent())
            {
                wo.Init(gen.Take(TimeSpan.FromSeconds(1.5)));
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    await Task.Delay(100);
                }
            }
        }

        private async void BotaoGenius_Click(object sender, RoutedEventArgs e)
        {
            switch (VezDoGenius)
            {
                case true: 
                    return;
                default:
                    break;
            }

            Button botao = (Button)sender;

            await VerificarBotaoApertadoAsync(botao);
        }
    }
}