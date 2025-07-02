using System;
using DoceFidelidade.Models;
using DoceFidelidade.Services;

public class Program {
  public static void Main(string[] args) {
    Client client = null;
    ClientService clientService = new ClientService();
    int option = 0;

    do {
      Console.WriteLine("Bem-vindo ao Doce Fidelidade!");
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1. Cadastrar Cliente");
      Console.WriteLine("2. Listar Clientes");
      Console.WriteLine("3. Sair\n");

      Console.Write("Digite a opção desejada: ");
      option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          Console.WriteLine("Por favor, preencha os dados para o cadastro:");

          Console.Write("ID: ");
          int id = int.Parse(Console.ReadLine());

          Console.Write("Nome: ");
          string name = Console.ReadLine();

          Console.Write("Email: ");
          string email = Console.ReadLine();

          Console.Write("Telefone: ");
          string phone = Console.ReadLine();

          client = new Client(id, name, email, phone);
          clientService.AddClient(client);

          Console.WriteLine("Cadastro realizado com sucesso!");
          break;
        case 2:
          if (clientService == null || clientService.GetListClients().Count == 0) {
            Console.WriteLine("Nenhum cliente cadastrado.");
          } else {
            Console.WriteLine("Lista de Clientes:");
            foreach (var c in clientService.GetListClients()) {
              Console.WriteLine($"ID: {c.Id}, Nome: {c.Name}, Email: {c.Email}, Telefone: {c.Phone}");
            }
          }
          break;
        default:
          Console.WriteLine("Opção inválida. Por favor, tente novamente.");
          break;
      }
      
    } while (option != 3);
  }
}