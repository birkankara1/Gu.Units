#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Frequency"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Frequency))]
    public class FrequencyExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.FrequencyExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Frequency"/>.</param>
        public FrequencyExtension(Frequency value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Frequency"/> value
        /// </summary>
        public Frequency Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
