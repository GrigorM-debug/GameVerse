using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace GameVerse.Web.ModelBinders.DecimalModelBinder
{
    /// <summary>
    /// A custom model binder for binding <see cref="decimal"/> values from the request using specified number styles and culture.
    /// </summary>
    /// <remarks>
    /// This model binder attempts to parse a decimal string from the request using the provided <see cref="NumberStyles"/> 
    /// and <see cref="CultureInfo"/>. If successful, it binds the decimal value to the model. 
    /// If parsing fails, it adds a model error to the model state.
    /// </remarks>
    public class DecimalModelBinder(NumberStyles numberStyles = NumberStyles.Number, CultureInfo? culture = null) : IModelBinder
    {
        private readonly NumberStyles _numberStyles = numberStyles;
        private readonly CultureInfo _culture = culture ?? CultureInfo.CurrentCulture;

        /// <summary>
        /// Binds the model asynchronously by parsing the decimal string from the request.
        /// </summary>
        /// <param name="bindingContext">The context for model binding, containing the request data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="bindingContext"/> is <c>null</c>.</exception>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            var valueAsString = valueProviderResult.FirstValue;

            if (string.IsNullOrWhiteSpace(valueAsString))
            {
                return Task.CompletedTask;
            }

            if (decimal.TryParse(valueAsString, _numberStyles, _culture, out var result))
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Invalid decimal value.");
            }

            return Task.CompletedTask;
        }
    }
}
