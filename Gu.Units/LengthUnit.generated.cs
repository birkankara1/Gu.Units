﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.LengthUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct LengthUnit : IUnit, IUnit<Length>, IEquatable<LengthUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Metres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Metres = new LengthUnit(1.0, "m");
        /// <summary>
        /// The <see cref="T:Gu.Units.Metres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit m = Metres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanometres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Nanometres = new LengthUnit(1E-09, "nm");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanometres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit nm = Nanometres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micrometres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Micrometres = new LengthUnit(1E-06, "µm");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micrometres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit µm = Micrometres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Millimetres = new LengthUnit(0.001, "mm");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit mm = Millimetres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Centimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Centimetres = new LengthUnit(0.01, "cm");
        /// <summary>
        /// The <see cref="T:Gu.Units.Centimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit cm = Centimetres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Decimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Decimetres = new LengthUnit(0.1, "dm");
        /// <summary>
        /// The <see cref="T:Gu.Units.Decimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit dm = Decimetres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilometres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Kilometres = new LengthUnit(1000, "km");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilometres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit km = Kilometres;

        /// <summary>
        /// The <see cref="T:Gu.Units.Inches"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Inches = new LengthUnit(0.0254, "in");

        /// <summary>
        /// The <see cref="T:Gu.Units.Mile"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Mile = new LengthUnit(1609.344, "mi");
        /// <summary>
        /// The <see cref="T:Gu.Units.Mile"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit mi = Mile;

        /// <summary>
        /// The <see cref="T:Gu.Units.Yard"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Yard = new LengthUnit(0.9144, "yd");
        /// <summary>
        /// The <see cref="T:Gu.Units.Yard"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit yd = Yard;

        /// <summary>
        /// The <see cref="T:Gu.Units.NauticalMile"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit NauticalMile = new LengthUnit(1852, "nmi");
        /// <summary>
        /// The <see cref="T:Gu.Units.NauticalMile"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit nmi = NauticalMile;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public LengthUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, LengthUnit right)
        {
            return Length.From(left, right);
        }

        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Metres.
        /// </summary>
        /// <param name="value">The value in Metres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Length CreateQuantity(double value)
        {
            return new Length(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Length quantity)
        {
            return FromSiUnit(quantity.metres);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Metres.Symbol);
        }

        public bool Equals(LengthUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LengthUnit && Equals((LengthUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}