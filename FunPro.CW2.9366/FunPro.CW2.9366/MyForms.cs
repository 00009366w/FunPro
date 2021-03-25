using System.Linq;
using System.Windows.Forms;

namespace FunPro.CW2._9366
{
    class MyForms
    {
        public static T GetForm<T>() where T : class, new()
        {
            return Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
        }
    }
}
