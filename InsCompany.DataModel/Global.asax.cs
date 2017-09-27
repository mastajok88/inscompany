using InsCompany.DataModel.App_Start;

namespace InsCompany.DataModel
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
        }
    }
}
