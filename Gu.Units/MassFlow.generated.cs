#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MassFlow"/>.
    /// </summary>
    [TypeConverter(typeof(MassFlowTypeConverter))]
    [Serializable]
    public partial struct MassFlow : IQuantity<MassFlowUnit>, IComparable<MassFlow>, IEquatable<MassFlow>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/>
        /// </summary>
        public static readonly MassFlow Zero = default(MassFlow);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/>.
        /// </summary>
        internal readonly double kilogramsPerSecond;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.MassFlow"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.MassFlowUnit"/>.</param>
        public MassFlow(double value, MassFlowUnit unit)
        {
            this.kilogramsPerSecond = unit.ToSiUnit(value);
        }

        private MassFlow(double kilogramsPerSecond)
        {
            this.kilogramsPerSecond = kilogramsPerSecond;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/>
        /// </summary>
        public double SiValue => this.kilogramsPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.MassFlowUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MassFlowUnit SiUnit => MassFlowUnit.KilogramsPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MassFlowUnit.KilogramsPerSecond;

        /// <summary>
        /// Gets the quantity in kilogramsPerSecond".
        /// </summary>
        public double KilogramsPerSecond => this.kilogramsPerSecond;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(MassFlow left, Mass right)
        {
            return Frequency.FromHertz(left.kilogramsPerSecond / right.kilograms);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(MassFlow left, Length right)
        {
            return Momentum.FromNewtonSecond(left.kilogramsPerSecond * right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(MassFlow left, Time right)
        {
            return Mass.FromKilograms(left.kilogramsPerSecond * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(MassFlow left, Time right)
        {
            return Stiffness.FromNewtonsPerMetre(left.kilogramsPerSecond / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the division.</returns>
        public static VolumetricFlow operator /(MassFlow left, Density right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.kilogramsPerSecond / right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(MassFlow left, Speed right)
        {
            return Force.FromNewtons(left.kilogramsPerSecond * right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(MassFlow left, Frequency right)
        {
            return Stiffness.FromNewtonsPerMetre(left.kilogramsPerSecond * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the division.</returns>
        public static Mass operator /(MassFlow left, Frequency right)
        {
            return Mass.FromKilograms(left.kilogramsPerSecond / right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(MassFlow left, Stiffness right)
        {
            return Time.FromSeconds(left.kilogramsPerSecond / right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Density"/> that is the result from the division.</returns>
        public static Density operator /(MassFlow left, VolumetricFlow right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilogramsPerSecond / right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(MassFlow left, SpecificEnergy right)
        {
            return Power.FromWatts(left.kilogramsPerSecond * right.joulesPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFieldStrength"/> that is the result from the division.</returns>
        public static MagneticFieldStrength operator /(MassFlow left, ElectricCharge right)
        {
            return MagneticFieldStrength.FromTeslas(left.kilogramsPerSecond / right.coulombs);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the multiplication.</returns>
        public static Time operator *(MassFlow left, Flexibility right)
        {
            return Time.FromSeconds(left.kilogramsPerSecond * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the division.</returns>
        public static ElectricCharge operator /(MassFlow left, MagneticFieldStrength right)
        {
            return ElectricCharge.FromCoulombs(left.kilogramsPerSecond / right.teslas);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MolarMass"/> that is the result from the division.</returns>
        public static MolarMass operator /(MassFlow left, CatalyticActivity right)
        {
            return MolarMass.FromKilogramsPerMole(left.kilogramsPerSecond / right.katals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(MassFlow left, Momentum right)
        {
            return Wavenumber.FromReciprocalMetres(left.kilogramsPerSecond / right.newtonSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the division.</returns>
        public static Momentum operator /(MassFlow left, Wavenumber right)
        {
            return Momentum.FromNewtonSecond(left.kilogramsPerSecond / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the division.</returns>
        public static KinematicViscosity operator /(MassFlow left, AreaDensity right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.kilogramsPerSecond / right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(MassFlow left, SpecificVolume right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.kilogramsPerSecond * right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(MassFlow left, KinematicViscosity right)
        {
            return Energy.FromJoules(left.kilogramsPerSecond * right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(MassFlow left, KinematicViscosity right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.kilogramsPerSecond / right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="CatalyticActivity"/> that is the result from the division.</returns>
        public static CatalyticActivity operator /(MassFlow left, MolarMass right)
        {
            return CatalyticActivity.FromKatals(left.kilogramsPerSecond / right.kilogramsPerMole);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond / right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlow"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator ==(MassFlow left, MassFlow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlow"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator !=(MassFlow left, MassFlow right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is less than another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator <(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond < right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is greater than another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator >(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond > right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is less than or equal to another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator <=(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond <= right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is greater than or equal to another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator >=(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond >= right.kilogramsPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.MassFlow"/> and returns the result.</returns>
        public static MassFlow operator *(double left, MassFlow right)
        {
            return new MassFlow(left * right.kilogramsPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static MassFlow operator *(MassFlow left, double right)
        {
            return new MassFlow(left.kilogramsPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MassFlow"/> by <paramref name="right"/> and returns the result.</returns>
        public static MassFlow operator /(MassFlow left, double right)
        {
            return new MassFlow(left.kilogramsPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MassFlow"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static MassFlow operator +(MassFlow left, MassFlow right)
        {
            return new MassFlow(left.kilogramsPerSecond + right.kilogramsPerSecond);
        }

        /// <summary>
        /// Subtracts an MassFlow from another MassFlow and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlow"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlow"/> (the subtrahend).</param>
        public static MassFlow operator -(MassFlow left, MassFlow right)
        {
            return new MassFlow(left.kilogramsPerSecond - right.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MassFlow"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="massFlow">An instance of <see cref="Gu.Units.MassFlow"/></param>
        public static MassFlow operator -(MassFlow massFlow)
        {
            return new MassFlow(-1 * massFlow.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="massFlow"/>.
        /// </returns>
        /// <param name="massFlow">An instance of <see cref="Gu.Units.MassFlow"/></param>
        public static MassFlow operator +(MassFlow massFlow)
        {
            return massFlow;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns>The <see cref="Gu.Units.MassFlow"/> parsed from <paramref name="text"/></returns>
        public static MassFlow Parse(string text)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MassFlow"/> parsed from <paramref name="text"/></returns>
        public static MassFlow Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.MassFlow"/> parsed from <paramref name="text"/></returns>
        public static MassFlow Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MassFlow"/> parsed from <paramref name="text"/></returns>
        public static MassFlow Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="result">The parsed <see cref="MassFlow"/></param>
        /// <returns>True if an instance of <see cref="MassFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MassFlow"/></param>
        /// <returns>True if an instance of <see cref="MassFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="MassFlow"/></param>
        /// <returns>True if an instance of <see cref="MassFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MassFlow"/></param>
        /// <returns>True if an instance of <see cref="MassFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MassFlow"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.MassFlow"/></returns>
        public static MassFlow ReadFrom(XmlReader reader)
        {
            var v = default(MassFlow);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.MassFlow"/></returns>
        public static MassFlow From(double value, MassFlowUnit unit)
        {
            return new MassFlow(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <param name="kilogramsPerSecond">The value in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/></param>
        /// <returns>An instance of <see cref="Gu.Units.MassFlow"/></returns>
        public static MassFlow FromKilogramsPerSecond(double kilogramsPerSecond)
        {
            return new MassFlow(kilogramsPerSecond);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MassFlowUnit unit)
        {
            return unit.FromSiUnit(this.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/s\"</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/s\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg/s</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg/s</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MassFlowUnit unit)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MassFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MassFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MassFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassFlowUnit unit)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MassFlow"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MassFlow"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantities of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.MassFlow"/> object to compare to this instance.</param>
        public int CompareTo(MassFlow quantity)
        {
            return this.kilogramsPerSecond.CompareTo(quantity.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlow"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MassFlow"/> object to compare with this instance.</param>
        public bool Equals(MassFlow other)
        {
            return this.kilogramsPerSecond.Equals(other.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlow"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MassFlow"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MassFlow other, MassFlow tolerance)
        {
            Ensure.GreaterThan(tolerance.kilogramsPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.kilogramsPerSecond - other.kilogramsPerSecond) < tolerance.kilogramsPerSecond;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlow"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.MassFlow"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is MassFlow other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.kilogramsPerSecond.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface,
        /// you should return null (Nothing in Visual Basic) from this method, and instead,
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/>
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema? GetSchema() => null;

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            var attribute = reader.GetAttribute("Value");
            if (attribute is null)
            {
                throw new XmlException($"Could not find attribute named: Value");
            }

            this  = new MassFlow(XmlConvert.ToDouble(attribute), MassFlowUnit.KilogramsPerSecond);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.kilogramsPerSecond);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<MassFlowUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
