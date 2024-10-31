﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace GameVerse.Web.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        private readonly NumberStyles _numberStyles;
        private readonly CultureInfo _culture;

        public DecimalModelBinder(NumberStyles numberStyles = NumberStyles.Number, CultureInfo? culture = null)
        {
            _numberStyles = numberStyles;
            _culture = culture ?? CultureInfo.CurrentCulture;
        }

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
