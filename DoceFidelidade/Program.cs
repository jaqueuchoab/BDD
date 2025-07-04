using System;
using DoceFidelidade.Models;
using DoceFidelidade.Services;

public class Program {
  public static void Main(string[] args) {
    Client client = null;
    Administrador admin = null;
    ClientService clientService = new ClientService();
    FeedbackService feedbackService = new FeedbackService();
    int option = 0;

    do {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("Bem-vindo ao Doce Fidelidade!");
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1. Cadastrar Cliente");
      Console.WriteLine("2. Listar Clientes (Apenas Administrador)");
      Console.WriteLine("3. Deixar Feedback");
      Console.WriteLine("4. Listar Feedback (Apenas Administrador)");
      Console.WriteLine("5. Sair\n");
      Console.WriteLine("----------------------------------------");

      Console.Write("Digite a opção desejada: ");
      option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          Console.WriteLine("\nPor favor, preencha os dados para o cadastro:");

          Console.Write("Nome: ");
          string name = Console.ReadLine();

          Console.Write("Email: ");
          string email = Console.ReadLine();

          Console.Write("Telefone: ");
          string phone = Console.ReadLine();

          client = new Client(name, email, phone);
          clientService.AddClient(client);

          Console.WriteLine("Cadastro realizado com sucesso!");
          Console.WriteLine("----------------------------------------");
          break;
        case 2:
          if (clientService.GetListClients().Count == 0) {
            Console.WriteLine("\nNenhum cliente cadastrado. Por favor, cadastre um cliente primeiro.");
          }  
          
          if(admin.IsAdmin){
            Console.WriteLine("\nLista de Clientes:");
            foreach (var c in clientService.GetListClients()) {
              Console.WriteLine($"ID: {c.Id}, Nome: {c.Name}, Email: {c.Email}, Telefone: {c.Phone}\n");
            }
          } else {
            Console.WriteLine("\nApenas administradores podem listar clientes")
          }
          break;
        case 3:
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
          Console.WriteLine(success);
          break;
        case 4:
          if(feedbackService.GetListFeedbacks().Count == 0) {
            Console.WriteLine("\nNenhum feedback disponível.");
          } 
          
          if(admin.IsAdmin) {
            Console.WriteLine("\nLista de Feedbacks:");
            feedbackService.DisplayFeedbacks();
          }
          break;
        default:
          Console.WriteLine("Opção inválida. Por favor, tente novamente.");
          break;
      }
    } while (option != 5);
  }
}