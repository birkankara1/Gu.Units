﻿// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Text;

    public static class ValueConverterGenerator
    {
        public static string Code(Quantity quantity)
        {
            return new StringBuilder()
                .AppendLine("#nullable enable")
                .AppendLine($"namespace Gu.Units.Wpf")
                .AppendLine($"{{")
                .AppendLine($"    using System;")
                .AppendLine($"    using System.ComponentModel;")
                .AppendLine($"    using System.Globalization;")
                .AppendLine($"    using System.Text;")
                .AppendLine($"    using System.Windows.Data;")
                .AppendLine($"    using System.Windows.Markup;")
                .AppendLine()
                .AppendLine($"    /// <summary>")
                .AppendLine($"    /// An <see cref=\"IValueConverter\"/> for quantities of type <see cref=\"{quantity.Name}\"/>")
                .AppendLine($"    /// </summary>")
                .AppendLine($"    [MarkupExtensionReturnType(typeof(IValueConverter))]")
                .AppendLine($"    public class {quantity.Name}Converter : MarkupExtension, IValueConverter")
                .AppendLine($"    {{")
                .AppendLine($"        private {quantity.UnitName}? unit;")
                .AppendLine($"        private Binding? binding;")
                .AppendLine($"        private QuantityFormat<{quantity.UnitName}>? quantityFormat;")
                .AppendLine($"        private QuantityFormat<{quantity.UnitName}>? bindingQuantityFormat;")
                .AppendLine($"        private string? valueFormat;")
                .AppendLine($"        private bool initialized;")
                .AppendLine($"        private StringBuilder errorText = new StringBuilder();")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Initializes a new instance of the <see cref=\"Gu.Units.Wpf.{quantity.Name}Converter\"/> class.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public {quantity.Name}Converter()")
                .AppendLine($"        {{")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Initializes a new instance of the <see cref=\"Gu.Units.Wpf.{quantity.Name}Converter\"/> class.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        /// <param name=\"unit\"><see cref=\"Gu.Units.{quantity.UnitName}\"/>.</param>")
                .AppendLine($"        public {quantity.Name}Converter({quantity.UnitName} unit)")
                .AppendLine($"        {{")
                .AppendLine($"            this.Unit = unit;")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets or sets the <see cref=\"{quantity.UnitName}\"/>")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        [ConstructorArgument(\"unit\")]")
                .AppendLine($"        [TypeConverter(typeof({quantity.UnitName}TypeConverter))]")
                .AppendLine($"        public {quantity.UnitName}? Unit")
                .AppendLine($"        {{")
                .AppendLine($"            get => this.unit;")
                .AppendLine($"            set")
                .AppendLine($"            {{")
                .AppendLine($"                if (value is null)")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"{{nameof(this.Unit)}} cannot be null\");")
                .AppendLine($"                    if (Is.DesignMode)")
                .AppendLine($"                    {{")
                .AppendLine($"                        throw new ArgumentException(this.errorText.ToString(), nameof(value));")
                .AppendLine($"                    }}")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                this.unit = value;")
                .AppendLine($"            }}")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets or sets the format to use when formatting the scalar part.")
                .AppendLine($"        /// Formats valid for formatting <see cref=\"double\"/> are valid")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public string? ValueFormat")
                .AppendLine($"        {{")
                .AppendLine($"            get => this.valueFormat;")
                .AppendLine($"            set")
                .AppendLine($"            {{")
                .AppendLine($"                if (!StringFormatParser<{quantity.UnitName}>.CanParseValueFormat(value))")
                .AppendLine($"                {{")
                .AppendLine($"                    if (Is.DesignMode)")
                .AppendLine($"                    {{")
                .AppendLine($"                        StringFormatParser<{quantity.UnitName}>.VerifyValueFormat(value);")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                    this.errorText.AppendLine(StringFormatParser<{quantity.UnitName}>.CreateFormatErrorString(value, typeof(double)));")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                this.valueFormat = value;")
                .AppendLine($"            }}")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets or sets the <see cref=\"SymbolFormat\"/> that is used when formatting the unit.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public SymbolFormat? SymbolFormat {{ get; set; }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets or sets the <see cref=\"Gu.Units.Wpf.UnitInput\"/> that specifies if unit is allowed or required for user input.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public UnitInput? UnitInput {{ get; set; }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets or sets the composite string format to use when formatting the quantity value.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public string? StringFormat")
                .AppendLine($"        {{")
                .AppendLine($"            get => this.quantityFormat?.CompositeFormat;")
                .AppendLine($"            set")
                .AppendLine($"            {{")
                .AppendLine($"                if (StringFormatParser<{quantity.UnitName}>.TryParse(value, out this.quantityFormat))")
                .AppendLine($"                {{")
                .AppendLine($"                    if (this.unit is {{ }} && this.unit != this.quantityFormat.Unit)")
                .AppendLine($"                    {{")
                .AppendLine($"                        var message = $\"Unit is set to '{{this.unit.Value.symbol}}' but StringFormat is '{{value}}'\";")
                .AppendLine($"                        if (Is.DesignMode)")
                .AppendLine($"                        {{")
                .AppendLine($"                            throw new InvalidOperationException(message);")
                .AppendLine($"                        }}")
                .AppendLine($"                    }}")
                .AppendLine($"                }}")
                .AppendLine($"                else")
                .AppendLine($"                {{")
                .AppendLine($"                    if (Is.DesignMode)")
                .AppendLine($"                    {{")
                .AppendLine($"                        StringFormatParser<{quantity.UnitName}>.VerifyQuantityFormat(value);")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                    this.errorText.AppendLine(StringFormatParser<{quantity.UnitName}>.CreateFormatErrorString(value, typeof({quantity.UnitName})));")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override object ProvideValue(IServiceProvider serviceProvider)")
                .AppendLine($"        {{")
                .AppendLine($"            // the binding does not have string format set at this point")
                .AppendLine($"            // caching the binding to resolve later.")
                .AppendLine($"            try")
                .AppendLine($"            {{")
                .AppendLine($"                var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));")
                .AppendLine($"                var targetObject = provideValueTarget?.TargetObject;")
                .AppendLine($"                this.binding = targetObject as Binding;")
                .AppendLine($"                if (this.binding is null && targetObject is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine(\"TargetObject is not a binding\");")
                .AppendLine($"                    if (Is.DesignMode)")
                .AppendLine($"                    {{")
                .AppendLine($"                        throw new InvalidOperationException(this.errorText.ToString());")
                .AppendLine($"                    }}")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine($"            catch (NullReferenceException)")
                .AppendLine($"            {{")
                .AppendLine($"                this.errorText.AppendLine(\"Touching provideValueTarget?.TargetObject threw\");")
                .AppendLine($"                if (Is.DesignMode)")
                .AppendLine($"                {{")
                .AppendLine($"                    throw new InvalidOperationException(this.errorText.ToString());")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return this;")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public object? Convert(object value, Type targetType, object? parameter, CultureInfo culture)")
                .AppendLine($"        {{")
                .AppendLine($"            if (!this.initialized)")
                .AppendLine($"            {{")
                .AppendLine($"                this.Initialize();")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            var message = this.errorText.ToString();")
                .AppendLine($"            if (!IsValidConvertTargetType(targetType))")
                .AppendLine($"            {{")
                .AppendLine($"                message += $\"{{this.GetType().Name}} does not support converting to {{targetType.Name}}\";")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (value is {{ }} && !(value is {quantity.Name}))")
                .AppendLine($"            {{")
                .AppendLine($"                message += $\"{{this.GetType().Name}} only supports converting from {{typeof({quantity.Name})}}\";")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (message != string.Empty)")
                .AppendLine($"            {{")
                .AppendLine($"                message = message.TrimEnd('\\r', '\\n');")
                .AppendLine($"                if (Is.DesignMode)")
                .AppendLine($"                {{")
                .AppendLine($"                    throw new InvalidOperationException(message);")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                return message;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (value is null)")
                .AppendLine($"            {{")
                .AppendLine($"                return targetType == typeof(string)")
                .AppendLine($"                    ? string.Empty")
                .AppendLine($"                    : null;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            var {quantity.ParameterName} = ({quantity.Name})value;")
                .AppendLine($"            if (this.bindingQuantityFormat is {{ }})")
                .AppendLine($"            {{")
                .AppendLine($"                if (string.IsNullOrEmpty(this.bindingQuantityFormat.SymbolFormat))")
                .AppendLine($"                {{")
                .AppendLine($"                    return {quantity.ParameterName}.GetValue(this.unit.Value);")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                return {quantity.ParameterName};")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (targetType == typeof(string) || targetType == typeof(object))")
                .AppendLine($"            {{")
                .AppendLine($"                if (this.UnitInput == Wpf.UnitInput.SymbolRequired)")
                .AppendLine($"                {{")
                .AppendLine($"                    return {quantity.ParameterName}.ToString(this.quantityFormat, culture);")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                if (this.ValueFormat is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    return {quantity.ParameterName}.GetValue(this.unit.Value).ToString(this.valueFormat, culture);")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                return {quantity.ParameterName}.GetValue(this.unit.Value);")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return {quantity.ParameterName}.GetValue(this.unit.Value);")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public object? ConvertBack(object value, Type targetType, object? parameter, CultureInfo culture)")
                .AppendLine($"        {{")
                .AppendLine($"            if (!this.initialized)")
                .AppendLine($"            {{")
                .AppendLine($"                this.Initialize();")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            var message = this.errorText.ToString();")
                .AppendLine($"            if (!(targetType == typeof({quantity.Name}) || targetType == typeof({quantity.Name}?)))")
                .AppendLine($"            {{")
                .AppendLine($"                message += $\"{{this.GetType().Name}} does not support converting to {{targetType.Name}}\";")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (message != string.Empty)")
                .AppendLine($"            {{")
                .AppendLine($"                message = message.TrimEnd('\\r', '\\n');")
                .AppendLine($"                if (Is.DesignMode)")
                .AppendLine($"                {{")
                .AppendLine($"                    throw new InvalidOperationException(message);")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                return message;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (value is null)")
                .AppendLine($"            {{")
                .AppendLine($"                return null;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (value is double)")
                .AppendLine($"            {{")
                .AppendLine($"                return new {quantity.Name}((double)value, this.unit.Value);")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            var text = value as string;")
                .AppendLine($"            if (string.IsNullOrEmpty(text))")
                .AppendLine($"            {{")
                .AppendLine($"                return null;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            var unitInput = this.UnitInput ?? Wpf.UnitInput.ScalarOnly;")
                .AppendLine($"            switch (unitInput)")
                .AppendLine($"            {{")
                .AppendLine($"                case Wpf.UnitInput.ScalarOnly:")
                .AppendLine($"                    {{")
                .AppendLine($"                        double d;")
                .AppendLine($"                        if (double.TryParse(text, NumberStyles.Float, culture, out d))")
                .AppendLine($"                        {{")
                .AppendLine($"                            return new {quantity.Name}(d, this.unit.Value);")
                .AppendLine($"                        }}")
                .AppendLine()
                .AppendLine($"                        {quantity.Name} result;")
                .AppendLine($"                        if ({quantity.Name}.TryParse(text, NumberStyles.Float, culture, out result))")
                .AppendLine($"                        {{")
                .AppendLine($"                            return $\"#{{text}}#\"; // returning modified text so that TypeConverter fails and we get an error")
                .AppendLine($"                        }}")
                .AppendLine()
                .AppendLine($"                        return text; // returning raw to trigger error")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                case Wpf.UnitInput.SymbolAllowed:")
                .AppendLine($"                    {{")
                .AppendLine($"                        double d;")
                .AppendLine($"                        int pos = 0;")
                .AppendLine($"                        WhiteSpaceReader.TryRead(text, ref pos);")
                .AppendLine($"                        if (DoubleReader.TryRead(text, ref pos, NumberStyles.Float, culture, out d))")
                .AppendLine($"                        {{")
                .AppendLine($"                            WhiteSpaceReader.TryRead(text, ref pos);")
                .AppendLine($"                            if (pos == text.Length)")
                .AppendLine($"                            {{")
                .AppendLine($"                                return new {quantity.Name}(d, this.unit.Value);")
                .AppendLine($"                            }}")
                .AppendLine($"                        }}")
                .AppendLine()
                .AppendLine($"                        goto case Wpf.UnitInput.SymbolRequired;")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                case Wpf.UnitInput.SymbolRequired:")
                .AppendLine($"                    {{")
                .AppendLine($"                        {quantity.Name} result;")
                .AppendLine($"                        if ({quantity.Name}.TryParse(text, NumberStyles.Float, culture, out result))")
                .AppendLine($"                        {{")
                .AppendLine($"                            return result;")
                .AppendLine($"                        }}")
                .AppendLine()
                .AppendLine($"                        return text;")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                default:")
                .AppendLine($"                    throw new ArgumentOutOfRangeException();")
                .AppendLine($"            }}")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        private static bool IsValidConvertTargetType(Type targetType)")
                .AppendLine($"        {{")
                .AppendLine($"            return targetType == typeof(string) ||")
                .AppendLine($"                   targetType == typeof(double) ||")
                .AppendLine($"                   targetType == typeof(double?) ||")
                .AppendLine($"                   targetType == typeof(object);")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        private void Initialize()")
                .AppendLine($"        {{")
                .AppendLine($"            this.initialized = true;")
                .AppendLine($"            BindingStringFormat.TryGet(this.binding, out this.bindingQuantityFormat);")
                .AppendLine($"            if (!string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))")
                .AppendLine($"            {{")
                .AppendLine($"                if (this.ValueFormat is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"ValueFormat cannot be set when Binding.StringFormat is a unit format.\");")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                if (this.StringFormat is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"ValueFormat cannot be set when Binding.StringFormat is a unit format.\");")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (this.quantityFormat is {{ }})")
                .AppendLine($"            {{")
                .AppendLine($"                if (this.ValueFormat is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"Both ValueFormat and StringFormat cannot be set.\");")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine($"            else")
                .AppendLine($"            {{")
                .AppendLine($"                if (this.unit is {{ }} && this.SymbolFormat is {{ }})")
                .AppendLine($"                {{")
                .AppendLine($"                    this.quantityFormat = FormatCache<{quantity.UnitName}>.GetOrCreate(this.ValueFormat, this.unit.Value, this.SymbolFormat.Value);")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (this.unit is null)")
                .AppendLine($"            {{")
                .AppendLine($"                var hasFmtUnit = !string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat);")
                .AppendLine($"                var hasBindingUnit = !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat);")
                .AppendLine($"                if (!hasFmtUnit && !hasBindingUnit)")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"Unit cannot be null.\");")
                .AppendLine($"                    this.errorText.AppendLine($\"Must be specified Explicitly or in StringFormat or in Binding.StringFormat.\");")
                .AppendLine($"                }}")
                .AppendLine($"                else if (hasFmtUnit && !hasBindingUnit)")
                .AppendLine($"                {{")
                .AppendLine($"                    this.unit = this.quantityFormat!.Unit;")
                .AppendLine($"                }}")
                .AppendLine($"                else if (!hasFmtUnit && hasBindingUnit)")
                .AppendLine($"                {{")
                .AppendLine($"                    this.unit = this.bindingQuantityFormat!.Unit;")
                .AppendLine($"                }}")
                .AppendLine($"                else")
                .AppendLine($"                {{")
                .AppendLine($"                    if (this.quantityFormat!.Unit != this.bindingQuantityFormat!.Unit)")
                .AppendLine($"                    {{")
                .AppendLine($"                        this.errorText.AppendLine($\"Ambiguous units StringFormat: {{this.quantityFormat.CompositeFormat}} Binding.StringFormat: {{this.bindingQuantityFormat.CompositeFormat}}\");")
                .AppendLine($"                    }}")
                .AppendLine()
                .AppendLine($"                    this.unit = this.quantityFormat.Unit;")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine($"            else")
                .AppendLine($"            {{")
                .AppendLine($"                if (!string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat) &&")
                .AppendLine($"                    this.unit != this.quantityFormat.Unit)")
                .AppendLine($"                {{")
                .AppendLine($"                    this.errorText.AppendLine($\"Unit is set to '{{this.unit}}' but StringFormat is '{{this.quantityFormat!.CompositeFormat.Replace(\"{{0:\", string.Empty).Replace(\"}}\", string.Empty)}}'\");")
                .AppendLine($"                }}")
                .AppendLine()
                .AppendLine($"                var hasBindingUnit = !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat);")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (this.UnitInput == Wpf.UnitInput.SymbolRequired)")
                .AppendLine($"            {{")
                .AppendLine($"                if (string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat))")
                .AppendLine($"                {{")
                .AppendLine($"                    if (string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))")
                .AppendLine($"                    {{")
                .AppendLine($"                        if (this.unit is null)")
                .AppendLine($"                        {{")
                .AppendLine($"                            this.errorText.AppendLine(\"UnitInput == SymbolRequired but no unit format is specified\");")
                .AppendLine($"                        }}")
                .AppendLine($"                        else if (this.SymbolFormat is {{ }})")
                .AppendLine($"                        {{")
                .AppendLine($"                            this.quantityFormat = FormatCache<{quantity.UnitName}>.GetOrCreate(this.ValueFormat, this.unit.Value, this.SymbolFormat.Value);")
                .AppendLine($"                            if (this.UnitInput is null)")
                .AppendLine($"                            {{")
                .AppendLine($"                                this.UnitInput = Wpf.UnitInput.SymbolRequired;")
                .AppendLine($"                            }}")
                .AppendLine($"                            else if (this.UnitInput == Wpf.UnitInput.ScalarOnly)")
                .AppendLine($"                            {{")
                .AppendLine($"                                this.errorText.AppendLine(\"Cannot have ScalarOnly and SymbolFormat specified\");")
                .AppendLine($"                            }}")
                .AppendLine($"                        }}")
                .AppendLine($"                        else")
                .AppendLine($"                        {{")
                .AppendLine($"                            this.quantityFormat = FormatCache<{quantity.UnitName}>.GetOrCreate(this.ValueFormat, this.unit.Value);")
                .AppendLine($"                            if (this.UnitInput is null)")
                .AppendLine($"                            {{")
                .AppendLine($"                                this.UnitInput = Wpf.UnitInput.ScalarOnly;")
                .AppendLine($"                            }}")
                .AppendLine($"                            else if (this.UnitInput == Wpf.UnitInput.ScalarOnly)")
                .AppendLine($"                            {{")
                .AppendLine($"                                this.errorText.AppendLine(\"Cannot have ScalarOnly and SymbolFormat specified\");")
                .AppendLine($"                            }}")
                .AppendLine($"                        }}")
                .AppendLine($"                    }}")
                .AppendLine($"                    else")
                .AppendLine($"                    {{")
                .AppendLine($"                        this.quantityFormat = this.bindingQuantityFormat;")
                .AppendLine($"                    }}")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            if (this.UnitInput is null)")
                .AppendLine($"            {{")
                .AppendLine($"                if (!string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat) ||")
                .AppendLine($"                    !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))")
                .AppendLine($"                {{")
                .AppendLine($"                    this.UnitInput = Wpf.UnitInput.SymbolRequired;")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine($"        }}")
                .AppendLine($"    }}")
                .AppendLine($"}}")
                .ToString();
        }
    }
}
