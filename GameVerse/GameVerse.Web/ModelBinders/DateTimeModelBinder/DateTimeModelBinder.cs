using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GameVerse.Web.ModelBinders.DateTimeModelBinder
{
    /// <summary>
    /// A custom model binder for binding <see cref="DateTime"/> values from the request using specified date formats.
    /// </summary>
    /// <remarks>
    /// This model binder attempts to parse a date string from the request using an array of date formats.
    /// If successful, it binds the date value to the model. If parsing fails, it adds a model error to the model state.
    /// </remarks>
    public class DateTimeModelBinder(string[] dateFormats) : IModelBinder
    {
        private readonly string[] _dateFormats = dateFormats;
        //private readonly CultureInfo? _culture = culture;

        /// <summary>
        /// Binds the model asynchronously by parsing the date string from the request.
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

            // Try parsing the date with each format in the array
            foreach (var format in _dateFormats)
            {
                if (DateTime.TryParseExact(valueAsString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }

            // If parsing fails for all formats, add an error
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Invalid date format.");

            return Task.CompletedTask;
        }
    }
}
