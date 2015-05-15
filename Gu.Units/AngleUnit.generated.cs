﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AngleUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AngleUnit : IUnit, IUnit<Angle>, IEquatable<AngleUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Radians"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AngleUnit Radians = new AngleUnit(1.0, "rad");
        /// <summary>
        /// The <see cref="T:Gu.Units.Radians"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngleUnit rad = Radians;

        /// <summary>
        /// The <see cref="T:Gu.Units.Degrees"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngleUnit Degrees = new AngleUnit(0.017453292519943295, "°");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AngleUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Radians"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Angle operator *(double left, AngleUnit right)
        {
            return Angle.From(left, right);
        }

        public static bool operator ==(AngleUnit left, AngleUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngleUnit left, AngleUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Radians"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Radians.
        /// </summary>
        /// <param name="value">The value in Radians</param>
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
        public Angle CreateQuantity(double value)
        {
            return new Angle(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Angle quantity)
        {
            return FromSiUnit(quantity.radians);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Radians.Symbol);
        }

        public bool Equals(AngleUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AngleUnit && Equals((AngleUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}