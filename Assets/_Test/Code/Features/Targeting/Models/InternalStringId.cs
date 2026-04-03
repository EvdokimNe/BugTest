using System;
namespace Test.Code.Features.Targeting.Models
{
    public readonly struct InternalStringId : IEquatable<InternalStringId>
    {
        public string Value { get; }

        public InternalStringId(string value)
        {
            Value = value;
        }

        public bool Equals(InternalStringId other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is InternalStringId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(InternalStringId left, InternalStringId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InternalStringId left, InternalStringId right)
        {
            return !left.Equals(right);
        }
    }
}
