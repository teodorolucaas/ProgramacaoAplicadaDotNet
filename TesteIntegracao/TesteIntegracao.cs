using System.Net;
using System.Text.Json;
using ApiLivros.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TesteIntegracao
{
    public class TesteIntegracao : IClassFixture<WebApplicationFactory<LivrosController>>
    {
        // Armazena o cliente utilizado para enviar requisicoes a API.
        private readonly HttpClient _client;

        // Recebe a fabrica fornecida automaticamente pelo xUnit.
        public TesteIntegracao(
            WebApplicationFactory<LivrosController> factory)
        {
            // Cria o cliente e inicializa a API em um servidor de teste.
            // Nao e necessario executar a API manualmente.
            _client = factory.CreateClient();
        }

        // Identifica um metodo de teste sem parametros.
        [Fact]
        // Declara um teste assincrono para verificar o status da V1.
        public async Task Listar_RetornaOk()
        {
            // Envia uma requisicao GET para a V1 e aguarda a resposta.
            var resposta = await _client.GetAsync("/api/livros");

            // Compara o status esperado com o recebido.
            // Se a resposta nao for 200 OK, o teste falha.
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        // Identifica outro teste independente.
        [Fact]
        // Declara um teste assincrono para verificar o status da V2.
        public async Task ListarV2_RetornaOk()
        {
            // Envia uma requisicao GET para a V2 e aguarda a resposta.
            var resposta = await _client.GetAsync("/api/v2/livros");

            // Verifica se a API retornou o status 200 OK.
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        // Identifica o teste dos campos da V1.
        [Fact]
        // Declara um teste que verifica a estrutura basica da resposta.
        public async Task Listar_RetornaCamposEsperados()
        {
            // Solicita a lista de livros na V1.
            var resposta = await _client.GetAsync("/api/livros");

            // Confirma o sucesso antes de verificar o conteudo.
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            // Le o corpo da resposta como texto.
            var texto = await resposta.Content.ReadAsStringAsync();

            // Interpreta o texto como um documento JSON.
            // O using libera o documento ao finalizar o metodo.
            using var json = JsonDocument.Parse(texto);

            // Obtem o elemento principal do JSON recebido.
            var livros = json.RootElement;

            // Verifica se o elemento principal e um array.
            Assert.Equal(JsonValueKind.Array, livros.ValueKind);

            // Exige ao menos um livro para verificar seus campos.
            // Essa e uma necessidade deste teste, nao uma regra da API.
            Assert.True(livros.GetArrayLength() > 0);

            // Seleciona o primeiro livro do array.
            var livro = livros[0];

            // Verifica se o campo id existe.
            // TryGetProperty retorna true quando encontra o campo.
            // out _ descarta seu valor, pois aqui verificamos so a presenca.
            Assert.True(livro.TryGetProperty("id", out _));

            // Verifica se o campo titulo existe.
            Assert.True(livro.TryGetProperty("titulo", out _));

            // Verifica se o campo autor existe.
            Assert.True(livro.TryGetProperty("autor", out _));
        }

        // Identifica o teste dos campos da V2.
        [Fact]
        // Declara um teste que verifica a estrutura basica da nova versao.
        public async Task ListarV2_RetornaCamposEsperados()
        {
            // Solicita a lista de livros na V2.
            var resposta = await _client.GetAsync("/api/v2/livros");

            // Confirma que a resposta possui o status 200 OK.
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            // Le o corpo da resposta como texto.
            var texto = await resposta.Content.ReadAsStringAsync();

            // Converte o texto em um documento JSON para consultar os campos.
            using var json = JsonDocument.Parse(texto);

            // Obtem o elemento principal da resposta.
            var livros = json.RootElement;

            // Verifica se a resposta e um array.
            Assert.Equal(JsonValueKind.Array, livros.ValueKind);

            // Garante que existe um livro para verificar seus campos.
            Assert.True(livros.GetArrayLength() > 0);

            // Seleciona o primeiro livro da lista.
            var livro = livros[0];

            // Verifica a presenca do identificador.
            Assert.True(livro.TryGetProperty("id", out _));

            // Verifica a presenca do titulo.
            Assert.True(livro.TryGetProperty("titulo", out _));

            // Verifica a presenca do autor.
            Assert.True(livro.TryGetProperty("autor", out _));

            // Verifica a presenca do campo acrescentado na V2.
            Assert.True(livro.TryGetProperty("anoPublicacao", out _));
        }

        // Os testes de campos verificam apenas o primeiro livro.
        // Nao verificam os tipos, os valores ou todos os itens da lista.
    }
}
