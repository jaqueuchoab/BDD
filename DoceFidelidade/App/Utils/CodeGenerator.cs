using System;
namespace DoceFidelidade.Utils;

public class CodeGenerator {
  // Código será composto por 'DOCE' + 4 digitos aleatórios que somados resultam em um número par
  public static string GenerateCode() {
    Random random = new Random();
    int firtsDigit = random.Next(0, 10);
    int secondDigit = random.Next(0, 10);
    int thirdDigit = random.Next(0, 10);
    int fourthDigit = random.Next(0, 5) * 2;

    string code = $"DOCE{firtsDigit}{secondDigit}{thirdDigit}{fourthDigit}";

    // Validando o código gerado
    if (IsValidCode(code)) {
      return code;
    } else {
      // Se o código não for válido, gerar um novo código
      return GenerateCode();
    }

    return code;
  }

  // Valida o código de fidelidade
  public static bool IsValidCode(string code) {
    // Corta o código da posição em diante e guardar os próximos 4 digitos
    string digitos = code.Substring(4, 4);
    int sum = 0;

    // Somatório dos 4 dígitos
    for (int i = 0; i < digitos.Length; i++) {
      sum += int.Parse(digitos[i].ToString());
    }

    // Verifica se a soma é par, se o código começa com 'DOCE' e se tem 8 caracteres, caracterizando um código válido
    return sum % 2 == 0 && code.StartsWith("DOCE") && code.Length == 8;
  }
}