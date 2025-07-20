using System.ComponentModel;
using System.Reflection;

namespace SayaxTask.Business.Helper
{
    public class ReflectionHelper
    {

        public string GetDescriptionByProperty<T>(string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            var descAttr = prop?.GetCustomAttribute<DescriptionAttribute>();
            return descAttr?.Description;
        }
    }
}
