using Xunit;
using TestStack.BDDfy;
using DoceFidelidade.Models;
using DoceFidelidade.Services;
namespace DoceFidelidade.Tests;

[Story(
  Title = "Feedback submission",
  AsA = "As a Doce Encanto customer",
  IWant = "I want to be able to provide feedback on the app",
  SoThat = "So that I improve the bakery's products"
)]

public class FeedbackRegister {
  // Atributos importantes para o teste, Model Feedback e Service Feedback
  Client _client;
  FeedbackService _feedbackService;

  [Given("the client has registered on the app")]
  public void GivenClientRegistered() {
    // Instanciando um cliente de forma válida
    _client = new Client("Jaqueline", "jaque@gmail.com", "(88) 99654-4536");
  }

  [When("the client provides feedback with a message and grade")]
  public void WhenClientProvidesFeedback() {
    // Instanciando o serviço de feedback
    _feedbackService = new FeedbackService();
    _feedbackService.CreateFeedback(_client, "Ótimo atendimento e doces maravilhosos", 5);
  }

  [Then("the feedback should be successfully registered")]
  public void ThenVerifyFeedbackRegistered() {
    // Verificando se o feedback foi adicionado à lista de feedbacks
    List<Feedback> feedbackList = _feedbackService.GetListFeedbacks();
    Assert.Contains(feedbackList, feedbackItem => 
      feedbackItem.WhoClient.Id == _client.Id && 
      feedbackItem.Message == "Ótimo atendimento e doces maravilhosos" && 
      feedbackItem.Grade == 5);
  }

  [Fact]
  public void ExecutingScenarioFeedbackRegister()
  {
    this.BDDfy();
  }
}