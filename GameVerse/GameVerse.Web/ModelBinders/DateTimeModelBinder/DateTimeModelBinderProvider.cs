using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace GameVerse.Web.ModelBinders.DateTimeModelBinder
{
    /// <summary>
    /// A custom model binder provider that creates instances of <see cref="DateTimeModelBinder"/> 
    /// for binding <see cref="DateTime"/> and <see cref="Nullable{DateTime}"/> model types.
    /// </summary>
    /// <remarks>
    /// This provider checks the model type in the provided context and returns a new instance 
    /// of the <see cref="DateTimeModelBinder"/> if the model type is <see cref="DateTime"/> 
    /// or <see cref="Nullable{DateTime}"/>.
    /// </remarks>
    public class DateTimeModelBinderProvider(string[] dateFormats) : IModelBinderProvider
    {
        private readonly string[] _dateFormats = dateFormats;

        /// <summary>
        /// Gets the binder for the specified context.
        /// </summary>
        /// <param name="context">The context for the model binder provider, which contains metadata about the model type.</param>
        /// <returns>
        /// An <see cref="IModelBinder"/> instance if the model type is <see cref="DateTime"/> or <see cref="Nullable{DateTime}"/>; 
        /// otherwise, <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is <c>null</c>.</exception>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new BinderTypeModelBinder(typeof(DateTimeModelBinder));
            }

            return null;
        }
    }
}
