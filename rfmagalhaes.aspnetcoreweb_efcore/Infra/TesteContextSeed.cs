using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using rfmagalhaes.aspnetcoreweb_efcore.domain;
using rfmagalhaes.aspnetcoreweb_efcore.infra.data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace rfmagalhaes.aspnetcoreweb_efcore.Infra
{
    public class TesteContextSeed
    {
        public async Task SeedAsync(TesteContext context, IHostingEnvironment env)
        {
            using (context) {

                context.Database.Migrate();

                if (!context.CodigoPostal.Any()) {
                    context.CodigoPostal.AddRange(CarregarCEPsPorArquivo(env.ContentRootPath));
                }

                await context.SaveChangesAsync();

            }
        }

        private IEnumerable<CodigoPostal> CarregarCEPsPorArquivo(string contentRootPath)
        {
            List<CodigoPostal> codigos = new List<CodigoPostal>();

            string csvFileCardTypes = Path.Combine(contentRootPath, "Infra", "Setup", "CodigosPostais.csv");

            StreamReader reader = new StreamReader(csvFileCardTypes);
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                string[] dados = linha.Split(',');
                codigos.Add(new CodigoPostal(dados[0], dados[1]));

            }

            return codigos;

        }

    }

}
