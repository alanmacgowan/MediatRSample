using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MediatRSample.Infrastructure
{
    public class EntityModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var original = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (original != ValueProviderResult.None)
            {
                var originalValue = original.FirstValue;
                int id;
                if (int.TryParse(originalValue, out id))
                {
                    var dbContext = bindingContext.HttpContext.RequestServices.GetService<OrderProcessingContext>();
                    var type = bindingContext.ModelType;
                    var entity = await dbContext.FindAsync(type, id);

                    bindingContext.Result = ModelBindingResult.Success(entity);
                }
            }
        }
    }
}