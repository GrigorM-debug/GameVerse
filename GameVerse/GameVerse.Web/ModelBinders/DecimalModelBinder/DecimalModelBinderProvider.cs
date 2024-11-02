using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace GameVerse.Web.ModelBinders.DecimalModelBinder
{
    /// <summary>
    /// A custom model binder provider that creates instances of <see cref="DecimalModelBinder"/> 
    /// for binding <see cref="decimal"/> and <see cref="Nullable{decimal}"/> model types.
    /// </summary>
    /// <remarks>
    /// This provider checks the model type in the provided context and returns a new instance 
    /// of the <see cref="DecimalModelBinder"/> if the model type is <see cref="decimal"/> 
    /// or <see cref="Nullable{decimal}"/>.
    /// </remarks>
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Gets the binder for the specified context.
        /// </summary>
        /// <param name="context">The context for the model binder provider, which contains metadata about the model type.</param>
        /// <returns>
        /// An <see cref="IModelBinder"/> instance if the model type is <see cref="decimal"/> or <see cref="Nullable{decimal}"/>; 
        /// otherwise, <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is <c>null</c>.</exception>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new BinderTypeModelBinder(typeof(DecimalModelBinder));
            }

            return null;
        }
    }
}
