using System.Globalization;

string? entrada = "";
int tamanhoAmostra = 0;
double mediaArit = 0.0, mediaGeom = 1.0;
double v = 0.0;
do
{
    /// 1. Faça
    ///    a. Imprimir "Digite valor x (vazio para sair)", sendo x igual a *tamanhoAmostra + 1*
    ///    b. Ler o que foi digitado e guardar em *entrada*
    /// Enquanto *entrada* não for vazio e não convertível a double e, quando for, guardar a conversão em *v*;
    /// Remover a linha de baixo.
    throw new NotImplementedException();

    /// Se *entrada* não for igual a "",
    /// if (...)
    /// {
        mediaArit += v;
        mediaGeom *= v;
        tamanhoAmostra += 1;
    /// }
} while (entrada != "");

// Se *tamanhoAmostra* for maior que 0,
// if (...)
// {
    CultureInfo culture = CultureInfo.GetCultureInfo("pt-BR");
    string fraseMediaArit = string.Format(culture, "A média aritmética é {0:#,##0.0000}", mediaArit / tamanhoAmostra);
    string fraseMediaGeom = string.Format(culture, "A média geométrica é {0:#,##0.0000}", Math.Pow(mediaGeom, 1.0 / tamanhoAmostra));
    string traco = new string('=', Math.Max(fraseMediaArit.Length, fraseMediaGeom.Length));

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(traco);
    Console.WriteLine(fraseMediaArit);
    Console.WriteLine(fraseMediaGeom);
    Console.WriteLine(traco);
    Console.ForegroundColor = ConsoleColor.Gray;
// }