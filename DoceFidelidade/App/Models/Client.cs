using System;
namespace DoceFidelidade.Models;

public class Client {
  private int _id = new Random().Next(1000, 9999);
  private string _name;
  private string _email;
  private string _phone;
  private int _points;
  private DateTime _createdAt;

  public Client(string name, string email, string phone) {
    this._name = name;
    this._email = email;
    this._phone = phone;
    this._points = 0;
    this._createdAt = DateTime.Now;
  }

  // Métodos de acesso

  public int Id {
    get => _id;
  }

  public string Name {
    get => _name;
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Name cannot be empty or whitespace.", nameof(value));
      }
      _name = value;
    }
  }

  public string Email {
    get => _email;
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Email cannot be empty or whitespace.", nameof(value));
      }
      _email = value;
    }
  }
  public string Phone {
    get => _phone;
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Phone cannot be empty or whitespace.", nameof(value));
      }
      _phone = value;
    }
  }

  public int Points {
    get => _points;
    set {
      if (value < 0) {
        throw new ArgumentException("Points cannot be negative.", nameof(value));
      }
      _points = value;
    }
  }

  public DateTime CreatedAt {
    get => _createdAt;
  }
}