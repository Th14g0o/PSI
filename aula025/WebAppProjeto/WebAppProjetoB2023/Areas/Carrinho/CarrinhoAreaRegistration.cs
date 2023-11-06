using System.Web.Mvc;

namespace WebAppProjetoB2023.Areas.Carrinho
{
    public class CarrinhoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Carrinho";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Carrinho_default",
                "Carrinho/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}