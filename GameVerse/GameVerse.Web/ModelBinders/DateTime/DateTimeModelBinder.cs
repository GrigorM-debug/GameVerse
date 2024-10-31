using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GameVerse.Web.ModelBinders.DateTime
{
    public class DateTimeModelBinder(string[] dateFormats, CultureInfo? culture = null) : IModelBinder
    {
        private readonly string[] _dateFormats = dateFormats;
        private readonly CultureInfo? _culture = culture;

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
                if (DateTime.TryParseExact(valueAsString, format, _culture, DateTimeStyles.None, out var result))
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
