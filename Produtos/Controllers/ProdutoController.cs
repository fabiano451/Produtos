using Microsoft.AspNetCore.Mvc;
using Produtos.Dominio;
using Produtos.Inteface;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvDownloadApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(IProdutoService produtoService, ILogger<ProdutoController> logger)
        {
            _produtoService = produtoService;
            _logger = logger;
        }

        [HttpGet("download-csv-produto-apple")]
        public async Task<IActionResult> DownloadCsv()
        {
            try
            {
                var produto = await _produtoService.GetProdutosAppleAsyync();
                var csv = GerarCsv(produto);

                var byteArray = Encoding.UTF8.GetBytes(csv);
                var stream = new MemoryStream(byteArray);

                return File(stream, "text/csv", "ProdutoApple.csv");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

        }

        private string GerarCsv(IEnumerable<Produto> data)
        {
            try
            {
                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("Produto; Preco");

                foreach (var item in data)
                {
                    if (item.name.Contains("Apple"))
                    {
                        var valor = item?.data?.price?.ToString().Length > 0 ? item.data.price.ToString() : "Atencao produto sem valor cadastrado";
                        csvBuilder.AppendLine($"{item.name}; {valor}");
                    }
                }

                return csvBuilder.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ex.Message;
            }

        }
    }
}
