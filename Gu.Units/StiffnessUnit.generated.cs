﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.StiffnessUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct StiffnessUnit : IUnit, IUnit<Stiffness>, IEquatable<StiffnessUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.NewtonsPerMetre"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerMetre = new StiffnessUnit(1.0, "N/m");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public StiffnessUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.NewtonsPerMetre"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Stiffness operator *(double left, StiffnessUnit right)
        {
            return Stiffness.From(left, right);
        }

        public static bool operator ==(StiffnessUnit left, StiffnessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StiffnessUnit left, StiffnessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.NewtonsPerMetre"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from NewtonsPerMetre.
        /// </summary>
        /// <param name="value">The value in NewtonsPerMetre</param>
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
        public Stiffness CreateQuantity(double value)
        {
            return new Stiffness(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Stiffness quantity)
        {
            return FromSiUnit(quantity.newtonsPerMetre);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), NewtonsPerMetre.Symbol);
        }

        public bool Equals(StiffnessUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is StiffnessUnit && Equals((StiffnessUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}