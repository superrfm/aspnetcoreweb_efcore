using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rfmagalhaes.aspnetcoreweb_efcore.domain;
using rfmagalhaes.aspnetcoreweb_efcore.infra.data;

namespace rfmagalhaes.aspnetcoreweb_efcore.Pages
{
    public class IndexModel : PageModel
    {
        public List<CodigoPostal> CEPs { get; set; }

        private readonly TesteContext _testeContext;

        public IndexModel(TesteContext context)
        {
            _testeContext = context;
        }

        public void OnGet()
        {
            CEPs = _testeContext.CodigoPostal.ToList();


        }
    }
}
