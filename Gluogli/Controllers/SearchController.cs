using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Gluogli.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenNLP.Tools.Chunker;
using OpenNLP.Tools.Tokenize;

namespace Gluogli.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/search")]
    public class SearchController : Controller
    {
        public GlougliDbCOntext Context { get; }

        public SearchController(GlougliDbCOntext context)
        {
            Context = context;
        }

        [HttpGet()]
        [EnableCors("AllowAll")]
        public ActionResult Get([FromQuery]string query)
        {
            string tokensResponse;
            try
            {
                //var proc = Process.Start($"py process.py \"{query}\"");
                var proc = new Process();
                proc.StartInfo.FileName = "py";
                proc.StartInfo.Arguments = $"process.py \"{query}\"";
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                tokensResponse = proc.StandardOutput.ReadToEnd();
            }
            catch (System.Exception ex)
            {
                tokensResponse = "";
            }

            string[] tokens;

            if (string.IsNullOrWhiteSpace(tokensResponse))
            {
                // English tokenizer
                var tokenizer = new EnglishRuleBasedTokenizer(false);
                tokens = tokenizer.Tokenize(query);
            }
            else
            {
                tokens = tokensResponse.Split(",").Select(x => x.Trim()).ToArray();

                var split = new List<string>();
                foreach (string item in tokens)
                {
                    split.AddRange(item.Split(" "));
                }

                tokens = tokens.Concat(split).ToArray();
            }

            var consultaComPlavras = from consultas in Context.Conteudo select consultas;
           
            var consultaLike = new List<Conteudo>();

             foreach (var token in tokens)
            {
                consultaLike = consultaLike.Concat(
                    consultaComPlavras.Where( 
                        consulta => consulta.Palavra.Contains(token,System.StringComparison.InvariantCultureIgnoreCase))
                    ).ToList();
            }
            var paginasComConsulta = Context.Pagina.Where(pagina => consultaLike.Select(consulta => consulta.Id).Contains(pagina.Id));

            var response = new List<PaginaRank>();

            foreach (var pag in paginasComConsulta)
            {
                var consultas = consultaLike.Where(c => c.Id == pag.Id);
                response.Add(new PaginaRank
                {
                    Titulo = pag.Titulo,
                    Link = pag.Link,
                    Avaliacao = consultas.Count()
                });
            }

            response = response.OrderByDescending(x => x.Avaliacao).ToList(); // Ordena a Lista de Páginas pela quantidade de Avaliacoes

            return Ok(response);
        }
    }
}