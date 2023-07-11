using System.Text.RegularExpressions;

namespace FieldValidatorAPI;

public delegate bool RequiredValidDel(string fieldValue);

public delegate bool StringLengthValidDelegate(string fieldValue, int min, int max);

public delegate bool DateValidDelegate(string fieldValue, out DateTime validDateTime);

public delegate bool PatternMatchValidDelegate(string fieldValue, string pattern);

public delegate bool CompareFieldsValidDelegate(string fieldValue, string fieldValueCompareTo);

public class CommonFieldValidatorFunctions
{
    private static RequiredValidDel _requiredValidDelegate = null;
    public static RequiredValidDel RequiredValidDelegate
    {
        get
        {
            if (_requiredValidDelegate == null)
            {
                _requiredValidDelegate = new RequiredValidDel(RequiredFieldValid);
            }

            return _requiredValidDelegate;
        }
    }
    private static StringLengthValidDelegate _stringLengthValidDelegate = null;

    public static StringLengthValidDelegate StringLengthValidDelegate
    {
        get
        {
            if (_stringLengthValidDelegate == null)
                _stringLengthValidDelegate = new StringLengthValidDelegate(StringLengthValid);

            return _stringLengthValidDelegate;
        }
    }
    private static DateValidDelegate _dateValidDelegate = null;
    public static DateValidDelegate DateValidDelegate
    {
        get
        {
            if (_dateValidDelegate == null)
                _dateValidDelegate = new DateValidDelegate(DateFieldValid);

            return _dateValidDelegate;
        }
    }
    private static PatternMatchValidDelegate _patternMatchValidDelegate = null;

    public static PatternMatchValidDelegate PatternMatchValidDelegate
    {
        get
        {
            if (_patternMatchValidDelegate == null)
                _patternMatchValidDelegate = FieldPatternValid;

            return _patternMatchValidDelegate;
        }
    }
    private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null;

    public static CompareFieldsValidDelegate CompareFieldsValidDelegate
    {
        get
        {
            if (_compareFieldsValidDelegate == null)
                _compareFieldsValidDelegate = CompareFieldValid;

            return _compareFieldsValidDelegate;
        }
    }

    private static bool RequiredFieldValid(string fieldValue)
    {
        if (!string.IsNullOrEmpty(fieldValue)) return true;

        return false;
    }

    private static bool StringLengthValid(string fieldValue, int min, int max)
    {
        if (fieldValue.Length < min || fieldValue.Length > max)
            return false;

        return true;
    }

    private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
    {
        if (DateTime.TryParse(dateTime, out validDateTime)) return true;

        return false;
    }

    private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
    {
        var regex = new Regex(regularExpressionPattern);

        if (!regex.Match(fieldVal).Success) return false;

        return true;
    }

    private static bool CompareFieldValid(string fieldVal, string compareTo)
    {
        return fieldVal.Equals(compareTo);
    }
}