using System;
using DoceFidelidade.Models;
namespace DoceFidelidade.Models;

public class Feedback {
  private Client _whoClient;
  private int _id = new Random().Next(1000, 9999);
  private string _message;
  private int _grade = 0;
  private DateTime _createdAt;
  
  public Feedback(Client whoClient, string message, int grade = 0) {
    this._whoClient = whoClient;
    this._message = message;
    this._grade = grade;
    this._createdAt = DateTime.Now;
  }

  // Métodos de acesso
  public Client WhoClient {
    get => this._whoClient;
    set {
      if (value == null) {
        throw new ArgumentNullException(nameof(value), "Client cannot be null");
      }
      this._whoClient = value;
    }
  }

  public string Message {
    get => this._message;
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Message cannot be empty or whitespace.", nameof(value));
      }
      this._message = value;
    }
  }

  public int Grade {
    get => this._grade;
    set {
      if (value < 0 || value > 5) {
        throw new ArgumentOutOfRangeException(nameof(value), "Grade must be between 0 and 5.");
      }
      this._grade = value;
    }
  }

  public int Id {
    get => this._id;
  }

  public DateTime CreatedAt {
    get => this._createdAt;
  }
}