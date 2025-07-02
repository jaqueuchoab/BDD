### Configuração BDDfy

Considerando que no projeto já há:
1. Uma solution (MinhaSolucao.sln)
2. Um projeto principal (MeuProjeto)
3. Um projeto de testes (MeuProjeto.Tests) com xUnit
4. Referência do projeto principal no projeto de testes

Então:

5. Instalar o pacote NuGet do BDDfy dentro da pasta de testes
```
cd MeuProjeto.Tests
dotnet add package TestStack.BDDfy
```
Exemplo de teste:
```
using CadastroCliente;
using TestStack.BDDfy;
using Xunit;

public class CadastroClienteSteps
{
    private Cliente _cliente;
    private bool _resultado;

    [Given("que a dona preencheu o nome e e-mail do cliente corretamente")]
    public void DadoClienteValido()
    {
        _cliente = new Cliente("Júlia", "julia@email.com");
    }

    [When("ela confirmar o cadastro")]
    public void QuandoCadastrar()
    {
        var servico = new ServicoCadastroCliente();
        _resultado = servico.Cadastrar(_cliente);
    }

    [Then("o cliente deve ser salvo com sucesso no sistema")]
    public void EntaoCadastroBemSucedido()
    {
        Assert.True(_resultado);
    }

    [Then("deve receber pontos iniciais de fidelidade")]
    public void EntaoReceberPontos()
    {
        Assert.Equal(100, _cliente.Pontos);
    }

    [Fact]
    public void ExecutarCenario()
    {
        this.BDDfy("Cadastro de cliente com dados válidos");
    }
}

```

this.BDDfy, executa as funções na sequência Given-When-Then
