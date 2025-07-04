using Xunit;
using TestStack.BDDfy;
using DoceFidelidade.Models;
using DoceFidelidade.Services;
namespace DoceFidelidade.Tests;

[Story(
  Title = "Validate a loyalty",
  AsA = "As a Doce Encanto customer",
  IWant = "I want to validate a loyalty code and",
  IWant = "I want to receive cumulative points for it",
  SoThat = "So that to ensure that the points are given to the customer"
)]

public class ValidateCode {
  // 
}