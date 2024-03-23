using System.Globalization;

Console.WriteLine("Programa calculador de média aritmética e de média geométrica");
Console.Write("Qual é o tamanho da amostra? ");
string? entrada = Console.ReadLine();
int n = 0;

/// Se *entrada* não for convertível a *int* ou se o valor convertido for menor que 1, sai do programa; 
///  caso contrário, guardar a conversão em *qtdeValores*.
/// Remover a linha de baixo.
throw new NotImplementedException();

int indice = n;
double mediaArit = 0.0, mediaGeom = 1.0;
double v = 0.0;
while (indice > 0)
{
    /// 1. Faça
    ///    a. Imprimir "Digite valor x", sendo x igual a *n - indice + 1*
    ///    b. Ler o que foi digitado e guardar em *entrada*
    /// Enquanto *entrada* não for convertível a double e, quando for, guardar a conversão em *v*;
    /// Remover a linha de baixo.
    throw new NotImplementedException();

    mediaArit += v;
    mediaGeom *= v;
    indice -= 1;
}

CultureInfo culture = CultureInfo.GetCultureInfo("pt-BR");
string fraseMediaArit = string.Format(culture, "A média aritmética é {0:#,##0.0000}", mediaArit / n);
string fraseMediaGeom = string.Format(culture, "A média geométrica é {0:#,##0.0000}", Math.Pow(mediaGeom, 1.0 / n));
string traco = new string('=', Math.Max(fraseMediaArit.Length, fraseMediaGeom.Length));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(traco);
Console.WriteLine(fraseMediaArit);
Console.WriteLine(fraseMediaGeom);
Console.WriteLine(traco);
Console.ForegroundColor = ConsoleColor.Gray;
