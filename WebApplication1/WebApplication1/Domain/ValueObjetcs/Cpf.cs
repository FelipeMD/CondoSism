using System;
using System.Text.RegularExpressions;

namespace WebApplication1.Domain.ValueObjetcs
{
    public struct Cpf
    {
        private readonly string _cleanedValue;
        private readonly string _originalValue;

        public Cpf(string value)
        {
            _cleanedValue = null;
            _originalValue = null;

            if (!string.IsNullOrEmpty(value))
            {
                _cleanedValue = value
                    .Replace(".", string.Empty)
                    .Replace("-", string.Empty);

                _originalValue = value;
            }
        }

        public Cpf(Cpf value)
        {
            _cleanedValue = value._cleanedValue;
            _originalValue = value._originalValue;
        }

        public override string ToString()
        {
            return _cleanedValue;
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj?.ToString();
        }

        public bool Equals(Cpf obj)
        {
            return _cleanedValue.Equals(obj._cleanedValue);
        }

        public override int GetHashCode()
        {
            return _cleanedValue.GetHashCode();
        }

        public bool IsValid()
        {
            var patternCpfComMascara = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

            try
            {
                if (patternCpfComMascara.IsMatch(_originalValue))
                    return true;

                if (_originalValue.Length == _cleanedValue.Length && _originalValue.Length == 11)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}