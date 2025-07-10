using System;
namespace DoceFidelidade.Models;

public class Administrator {
  private int _id = new Random().Next(1000, 9999);
  private string _name;
  private string _email;
  private string _phone;
  private string _password;
  private bool _isAdmin = true;
  private DateTime _createdAt;

  public Administrator(string name, string email, string phone, string password) {
    this._name = name;
    this._email = email;
    this._phone = phone;
    this._password = password;
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

  public string Password {
    get => _password;
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Password cannot be empty or whitespace.", nameof(value));
      }
      _password = value;
    }
  }

  public bool IsAdmin {
    get => _isAdmin;
  }

  public DateTime CreatedAt {
    get => _createdAt;
  }
}