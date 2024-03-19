using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Text;

namespace V0005
{
    partial class MainWindow
    {
        async Task AplicarVezDoGeniusAsync()
        {
            await TocarBeepAteNumeroEtapasAlcancadasMaisUmAsync();
            VezDoGenius = false;
            BarraMensagem.Text = "Vez do Jogador";
            PosicaoNoVetor = 0;
        }

        async Task TocarBeepAteNumeroEtapasAlcancadasMaisUmAsync()
        {
            Button? botao = null;

            for (int indice = 0; indice <= NumeroEtapasAlcancadas; indice += 1)
            {
                switch (Sequencia[indice])
                {
                    case 0:
                        botao = BotaoVermelho0;
                        break;
                    case 1:
                        botao = BotaoVerde1;
                        break;
                    case 2:
                        botao = BotaoAzul2;
                        break;
                    case 3:
                        botao = BotaoAmarelo3;
                        break;
                    default:
                        throw new NotSupportedException("Botão " + Sequencia[indice] + " desconhecido.");
                }

                botao.Tag = "ShowAnimation";
                await GerarBeepAsync(Sequencia[indice]);
                botao.Tag = "";
            }
        }

        async Task VerificarBotaoApertadoAsync(Button botaoApertado)
        {
            botaoApertado.IsEnabled = false;

            await Task.Delay(100);

            // 1. Dado a propriedade Name do botaoApertado,
            //    a. Caso seja "BotaoVermelho0" quando o índice PosicaoNoVetor de Sequencia for igual a 0;
            //    b. Caso seja "BotaoVerde1" quando o índice PosicaoNoVetor de Sequencia for igual a 1;
            //    c. Caso seja "BotaoAzul2" quando o índice PosicaoNoVetor de Sequencia for igual a 2;
            //    d. Caso seja "BotaoAmarelo3" quando o índice PosicaoNoVetor de Sequencia for igual a 3;
            //       I. Habilitar o botaoApertado
            //       II. await AcertouBotaoAsync();
            //       III. escapa do bloco.
            //    e. Por padrão,
            //       I. BotaoVermelho0, BotaoVerde1, BotaoAzul2 e BotaoAmarelo3 são todos desabilitados
            //       II. BarraMensagem contém a string "Você perdeu."
            //       III. escapa do bloco.
            //
            switch (botaoApertado.Name)
            {
                case "BotaoVermelho0" when Sequencia[PosicaoNoVetor] == 0:
                case "BotaoVerde1" when Sequencia[PosicaoNoVetor] == 1:
                case "BotaoAzul2" when Sequencia[PosicaoNoVetor] == 2:
                case "BotaoAmarelo3" when Sequencia[PosicaoNoVetor] == 3:
                    botaoApertado.IsEnabled = true;
                    await AcertouBotaoAsync();
                    break;
                default:
                    BotaoVermelho0.IsEnabled = BotaoVerde1.IsEnabled = BotaoAzul2.IsEnabled = BotaoAmarelo3.IsEnabled = false;
                    BarraMensagem.Text = "Você perdeu.";
                    break;
            }
        }

        async Task AcertouBotaoAsync()
        {
            PosicaoNoVetor += 1;
            (PosicaoNoVetor, NumeroEtapasAlcancadas, bool irParaVezDoGenius) = PosicaoNoVetor > NumeroEtapasAlcancadas
                ? (0, NumeroEtapasAlcancadas + 1, true)
                : (PosicaoNoVetor, NumeroEtapasAlcancadas, false);

            switch (NumeroEtapasAlcancadas)
            {
                case TotalEtapas:
                    BotaoVermelho0.IsEnabled = BotaoVerde1.IsEnabled = BotaoAzul2.IsEnabled = BotaoAmarelo3.IsEnabled = false;
                    BarraMensagem.Text = "Você venceu!";
                    return;
                default:
                    break;
            }

            switch (irParaVezDoGenius)
            {
                case true:
                    VezDoGenius = true;
                    BarraMensagem.Text = "Vez do Genius";
                    await AplicarVezDoGeniusAsync();
                    break;
                default:
                    break;
            }
        }
    }
}
