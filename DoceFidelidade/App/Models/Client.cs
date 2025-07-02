namespace DoceFidelidade.Models;

public class Client {
  private int _id = 0;
  private string _name;
  private string _email;
  private string _phone;
  private DateTime _createdAt;

  public Client(int id, string name, string email, string phone) {
    this._id = id;
    this._name = name;
    this._email = email;
    this._phone = phone;
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
  public DateTime CreatedAt {
    get => _createdAt;
  }
}