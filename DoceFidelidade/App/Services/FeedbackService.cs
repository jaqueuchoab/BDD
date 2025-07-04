using System;
using DoceFidelidade.Models;

public class FeedbackService {
  // Armazenamento de Feedbacks
  private List<Feedback> _feedbacks = new List<Feedback>();

  // Create/Adicionar Feedback à lista
  public string CreateFeedback(Client whoClient, string message, int grade = 0) {
    if (whoClient == null || string.IsNullOrWhiteSpace(message) || grade < 0 || grade > 5) {
      throw new ArgumentException("Invalid feedback parameters. Client cannot be null, message cannot be empty, and grade must be between 0 and 5.");
    }

    Feedback feedback = new Feedback(whoClient, message, grade);
    _feedbacks.Add(feedback);

    return $"Feedback created successfully with ID: {feedback.Id} at {feedback.CreatedAt}.";
  } 

  // Read/Ler a lista de Feedbacks
  public List<Feedback> GetListFeedbacks() {
    return _feedbacks;
  }

  // Delete/Remover Feedback da lista
  public void RemoveFeedback(Feedback feedback) {
    if (feedback == null) {
      throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
    }

    // Remova todos os itens da lista que possuem o mesmo CreatedAt do feedback a ser removido
    _feedbacks.RemoveAll(feedbackItem => (feedbackItem.Id == feedback.Id && 
                                          feedbackItem.CreatedAt == feedback.CreatedAt && 
                                          feedbackItem.Message == feedback.Message));
  }

  // Exibir todos os feedbacks
  public void DisplayFeedbacks() {
    if (_feedbacks.Count == 0) {
      Console.WriteLine("No feedbacks available.");
      return;
    }

    Console.WriteLine("---------Feedback Details---------");

    foreach (var feedback in _feedbacks) {
      Console.WriteLine($"ID: {feedback.Id}");
      Console.WriteLine($"Data de Criação: {feedback.CreatedAt}");
      Console.WriteLine($"Cliente: {feedback.WhoClient.Name}");
      Console.WriteLine($"Mensagem: {feedback.Message}");
      Console.WriteLine($"Nota: {feedback.Grade}");

      Console.WriteLine("----------------------------------");
    }
  }
}