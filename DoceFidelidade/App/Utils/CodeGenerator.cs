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

  public static bool IsValidCode(string code) {
    string digitos = code.Substring(4, 4);
    int sum = 0;

    for (int i = 0; i < digitos.Length; i++) {
      sum += int.Parse(digitos[i].ToString());
    }

    return sum % 2 == 0 && code.StartsWith("DOCE") && code.Length == 8;
  }
}