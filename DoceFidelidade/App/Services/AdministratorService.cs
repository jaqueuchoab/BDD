using System;
using DoceFidelidade.Models;
using DoceFidelidade.Utils;
namespace DoceFidelidade.Services;

public class AdministratorService {
  List<Administrator> administrators = new List<Administrator>();

  // Create/Add novo administrador
  public void AddAdmin(Administrator admin) {
    if (admin == null) {
      throw new ArgumentNullException(nameof(admin), "Administrator cannot be null.");
    }

    administrators.Add(admin);

    Console.WriteLine($"Successfully created administrator.");
  }

  // Read/List todos os administradores
  public List<Administrator> GetAllAdministrators() {
    if (administrators.Count == 0) {
      Console.WriteLine("No administrators found.");
    }
    return administrators;
  }

  // Update um administrador
  public void UpdateClient(Administrator admin, string field, string value) {
    if(admin == null) {
      throw new ArgumentNullException(nameof(admin), "admin cannot be null");
    }
    
    foreach (var adminItem in administrators)
    {
      if(adminItem.Id.Equals(admin.Id)) {
        switch (field.ToLower())
        {
          case "name":
            adminItem.Name = value;
            break;
          case "email":
            adminItem.Email = value;
            break;
          case "phone":
            adminItem.Phone = value;
            break;
          default:
            throw new ArgumentException($"Field '{field}' is not valid for update.", nameof(field));
        }
      }
    }
  }

  // Delete/Remove um administrador
  public void RemoveAdmin(Administrator admin) {
    if(admin == null) {
      throw new ArgumentNullException(nameof(admin), "Administrator cannot be null");
    }

    // Remove todos os itens da lista que possuem o mesmo Id do administrador a ser removido
    administrators.RemoveAll(adminItem => adminItem.Id == admin.Id);
  }

  public string AdmGenerateCode() {
    string code = CodeGenerator.GenerateCode();
    return code;
  }
}