namespace Produtos.Service
{
    using CsvDownloadApi.Controllers;
    using Produtos.Dominio;
    using Produtos.Inteface;
    using System.Collections.Generic;
    using System.Formats.Asn1;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    

    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAppleAsyync()
        {
            try
            {
                var uri = Environment.GetEnvironmentVariable("URI_PRODUTO_APPLE").Trim();
                var response = await _httpClient.GetStringAsync(uri);
                var produto = JsonSerializer.Deserialize<IEnumerable<Produto>>(response);
                return produto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
               throw;
            }
           
        }
    }
}
