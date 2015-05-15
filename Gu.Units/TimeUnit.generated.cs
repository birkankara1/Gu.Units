﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TimeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TimeUnit : IUnit, IUnit<Time>, IEquatable<TimeUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Seconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Seconds = new TimeUnit(1.0, "s");
        /// <summary>
        /// The <see cref="T:Gu.Units.Seconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit s = Seconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanoseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Nanoseconds = new TimeUnit(1E-09, "ns");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanoseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit ns = Nanoseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Microseconds = new TimeUnit(1E-06, "µs");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit µs = Microseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milliseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Milliseconds = new TimeUnit(0.001, "ms");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milliseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit ms = Milliseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Hours"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Hours = new TimeUnit(3600, "h");
        /// <summary>
        /// The <see cref="T:Gu.Units.Hours"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit h = Hours;

        /// <summary>
        /// The <see cref="T:Gu.Units.Minutes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Minutes = new TimeUnit(60, "min");
        /// <summary>
        /// The <see cref="T:Gu.Units.Minutes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit min = Minutes;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public TimeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, TimeUnit right)
        {
            return Time.From(left, right);
        }

        public static bool operator ==(TimeUnit left, TimeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimeUnit left, TimeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Seconds.
        /// </summary>
        /// <param name="value">The value in Seconds</param>
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
        public Time CreateQuantity(double value)
        {
            return new Time(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Time quantity)
        {
            return FromSiUnit(quantity.seconds);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Seconds.Symbol);
        }

        public bool Equals(TimeUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TimeUnit && Equals((TimeUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}