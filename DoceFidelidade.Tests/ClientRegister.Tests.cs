using Xunit;
using TestStack.BDDfy;
using DoceFidelidade.Models;
using DoceFidelidade.Services;
namespace DoceFidelidade.Tests;

[Story(
    AsA = "As a Doce Encanto customer",
    IWant = "I want to be able to register on DoceFidelidade",
    SoThat = "So that I can access the app's benefits"
)]

public class ClientRegister {
    // Atributos importantes para o teste, Model Client e Service Client
    private Client _client;
    private ClientService _clientService;

    [Given("the client has correctly filled in the data")]
    public void GivenCreateValidClient() {
        _client = new Client(1, "Jasmin", "jasmin@gmail.com", "(88) 99654-4536");
    }

    [When("the client submits the registration data")]
    public void WhenRegisterClient() {
        _clientService = new ClientService();
        _clientService.AddClient(_client);
    }

    [Then("the client should be successfully registered")]
    public void ThenVerifyClientRegistered() {
        List<Client> clientsList = _clientService.GetListClients();
        Assert.Contains(clientsList, clientItem => clientItem.Id == _client.Id);

    }

    [Fact]
    public void ExecutingScenarioRegister()
    {
        this.BDDfy();
    }
}

