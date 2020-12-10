using System;

namespace DemoCode
{
    public class AirportCode
    {
        private readonly string _code;

        public AirportCode(string code)
        {
            if (code is null) throw new ArgumentException();

            if (!IsValidAirportCode(code))
                throw new ArgumentException("Airport code should be three uppercase letters", nameof(code));

            _code = code;
        }

        public override string ToString()
        {
            return _code;
        }

        private static bool IsValidAirportCode(string code)
        {
            var isWrongLength = code.Length != 3;
            var isWrongCase = code != code.ToUpperInvariant();

            return !isWrongLength && !isWrongCase;
        }
    }
}
