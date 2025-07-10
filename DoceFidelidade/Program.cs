using System;
using DoceFidelidade.Models;
using DoceFidelidade.Services;

public class Program {
  public static void Main(string[] args) {
    Client client = null;
    Administrator admin = null;
    ClientService clientService = new ClientService();
    FeedbackService feedbackService = new FeedbackService();
    AdministratorService adminService = new AdministratorService();
    int option = 0;

    do {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("Bem-vindo ao Doce Fidelidade!");
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1. Cadastrar Cliente");
      Console.WriteLine("2. Cadastrar Administrador");
      Console.WriteLine("3. Listar Clientes (Administrador)");
      Console.WriteLine("4. Listar Feedback (Administrador)");
      Console.WriteLine("5. Deixar Feedback (Cliente)");
      Console.WriteLine("6. Sair\n");
      Console.WriteLine("----------------------------------------");

      Console.Write("Digite a opção desejada: ");
      option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          Console.WriteLine("\nPor favor, preencha os dados para o cadastro:");

          Console.Write("Nome: ");
          string nameClient = Console.ReadLine();

          Console.Write("Email: ");
          string emailClient = Console.ReadLine();

          Console.Write("Telefone: ");
          string phoneClient = Console.ReadLine();

          client = new Client(nameClient, emailClient, phoneClient);
          clientService.AddClient(client);

          Console.WriteLine("Cadastro realizado com sucesso!");
          Console.WriteLine("----------------------------------------");
          break;
        case 2:
          Console.WriteLine("\nPor favor, preencha os dados para o cadastro:");

          Console.Write("Nome: ");
          string nameAdm = Console.ReadLine();

          Console.Write("Email: ");
          string emailAdm = Console.ReadLine();

          Console.Write("Telefone: ");
          string phoneAdm = Console.ReadLine();

          Console.Write("Senha: ");
          string senhaAdm = Console.ReadLine();

          admin = new Administrator(nameAdm, emailAdm, phoneAdm, senhaAdm);
          adminService.AddAdmin(admin);

          Console.WriteLine("Cadastro realizado com sucesso!");
          Console.WriteLine("----------------------------------------");
          break;
        case 3:
          if(admin.IsAdmin){
            Console.WriteLine("\nAdministrador, digite sua senha");
            string senha = Console.ReadLine();
            if(admin.Password != senha) {
              Console.WriteLine("\nSenha incorreta. Acesso negado.");
              break;
            }

            Console.WriteLine("\nLista de Clientes:");
              if (clientService.GetListClients().Count == 0) {
              Console.WriteLine("\nNenhum cliente cadastrado. Por favor, cadastre um cliente primeiro.");
              }  
            foreach (var c in clientService.GetListClients()) {
              Console.WriteLine($"ID: {c.Id}, Nome: {c.Name}, Email: {c.Email}, Telefone: {c.Phone}\n");
            }
          } else {
            Console.WriteLine("\nApenas administradores podem listar clientes");
          }
          break;
        case 4:
          if(admin.IsAdmin) {
            Console.WriteLine("\nAdministrador, digite sua senha");
            string senha = Console.ReadLine();
            if(admin.Password != senha) {
              Console.WriteLine("\nSenha incorreta. Acesso negado.");
              break;
            }

            if(feedbackService.GetListFeedbacks().Count == 0) {
              Console.WriteLine("\nNenhum feedback disponível.");
              break;
            } 

            Console.WriteLine("\nLista de Feedbacks:");
            feedbackService.DisplayFeedbacks();
          }
          break;
        case 5:
          if(client == null) {
            Console.WriteLine("\nNenhum cliente cadastrado. Por favor, cadastre um cliente primeiro.");
            break;
          }
          Console.WriteLine("\nPor favor, preencha os campos:");
          Console.Write("Mensagem: ");
          string mensagem = Console.ReadLine();
          Console.Write("Nota (1 a 5): ");
          int nota = int.Parse(Console.ReadLine());

          string success = feedbackService.CreateFeedback(client, mensagem, nota);
          Console.WriteLine("Feedback enviado com sucesso!");
          break;
        default:
          Console.WriteLine("Opção inválida. Por favor, tente novamente.");
          break;
      }
    } while (option != 5);
  }
}