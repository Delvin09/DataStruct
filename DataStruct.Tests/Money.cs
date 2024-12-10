namespace DataStruct.Tests
{
    readonly struct Money : IComparable<Money>, IComparable<decimal>
    {
        private readonly int _notes;
        private readonly byte _coins;

        public Money(int notes, byte coins)
        {
            _coins = coins;
            _notes = notes;
        }

        public Money Add(Money money)
        {
            return new Money(this._notes + money._notes, (byte)(this._coins + money._coins));
        }

        public int CompareTo(Money other)
        {
            return (_notes * 100 + _coins) - (other._notes * 100 + other._coins);
        }

        public int CompareTo(decimal other)
        {
            throw new NotImplementedException();
        }

        public static Money operator +(Money money, Money other)
        {
            return money.Add(other);
        }

        public static bool operator ==(Money money, Money other)
        {
            return money._notes == other._notes && money._coins == other._coins;
        }

        public static bool operator !=(Money money, Money other)
        {
            return !(money == other);
        }

        public static bool operator >>(Money money, Money other)
        {
            return !(money == other);
        }

        public static implicit operator double(Money m) => (double)m._notes + (m._coins / 100.0);

        public static implicit operator Money(double d) => new Money((int)d, 0);
    }
}
