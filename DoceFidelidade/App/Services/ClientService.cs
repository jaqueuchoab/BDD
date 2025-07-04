namespace DoceFidelidade.Services;
using DoceFidelidade.Models;
using DoceFidelidade.Utils;

public class ClientService {
  // Armazenamento de Clientes
  private List<Client> _clients = new List<Client>();

  // Create/Adicionar Cliente à lista
  public string AddClient(Client client) {
    if(client == null) {
      throw new ArgumentNullException(nameof (client), "Client cannot be null");
    }

    _clients.Add(client);

    return $"{client.Id} | Cadastrado com sucesso!";
  }  

  // Read/Ler a lista de Clientes
  public List<Client> GetListClients() {
    return _clients;
  }

  // Update/Atualizar Cliente na lista
  public void UpdateClient(Client client, string field, string value) {
    if(client == null) {
      throw new ArgumentNullException(nameof(client), "Client cannot be null");
    }
    
    foreach (var clientItem in _clients)
    {
      if(clientItem.Id.Equals(client.Id)) {
        switch (field.ToLower())
        {
          case "name":
            clientItem.Name = value;
            break;
          case "email":
            clientItem.Email = value;
            break;
          case "phone":
            clientItem.Phone = value;
            break;
          default:
            throw new ArgumentException($"Field '{field}' is not valid for update.", nameof(field));
        }
      }
    }

  }

  // Delete/Remover Cliente da lista
  public void RemoveClient(Client client) {
    if(client == null) {
      throw new ArgumentNullException(nameof(client), "Client cannot be null");
    }

    // Remova todos os itens da lista que possuem o mesmo Id do cliente a ser removido
    _clients.RemoveAll(clientItem => clientItem.Id == client.Id);

  }

  public bool ValidateCode(string code) {
    if (string.IsNullOrWhiteSpace(code)) {
      throw new ArgumentException("Code cannot be null or empty.", nameof(code));
    }

    if(!CodeGenerator.IsValidCode(code)) {
      throw new ArgumentException("Invalid code format.", nameof(code));
    } else {
      return CodeGenerator.IsValidCode(code);
    }
  }
}