﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.ValidationAttributes
{
    public class FilesExtensionsAttribute : ValidationAttribute, IClientModelValidator
    {
        public string[] Extensions { get; set; } = new string[] { "png", "jpg" };

        private const string DefaultErrorMessage = "The file extension is not allowed. Allowed extensions: {0}";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var files = value as IEnumerable<IFormFile>;
            
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (!Extensions.Contains(file.FileName.Split('.').Last().ToLower()))
                    {
                        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, string.Join(", ", Extensions)));
                    }
                }

                return ValidationResult.Success;
            }

            return null;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-filesextensions", string.Format(ErrorMessage ?? DefaultErrorMessage, string.Join(", ", Extensions)));
            context.Attributes.Add("data-val-filesextensions-extensions", string.Join(",", Extensions));
        }
    }
}
