using System;
using System.Web.Mvc;


namespace LearningMVC.Controllers
{
    public class CSharpSevenController : Controller
    {
        private int _dOne;
        private int _dTwo;
        private string _refType;

        public CSharpSevenController()
        {
            _dOne = 1;
            _dTwo = 2;
            _refType = "ref";
        }

        // GET: CSharpSeven
        public ActionResult Index()
        {
            (int, int) tuple = GetDeconstructionTuple();
            int one = tuple.Item1;
            int two = tuple.Item2;

            int separatedDigits = GetDigitSeparator();

            string interpolatedString = GetStringInterpolation();

            string expressionBodiedMember = GetExpressionBodiesMembers();

            int parsedInlineInt = GetInlineVariables();

            string _nameOf = GetNameOf(parsedInlineInt);

            string nestedFunction = GetNestedFunction();

            string nullableRefType = GetNullableRefTypes();

            string patternMatched = GetPatternMatching();

            Span<string> span = GetSpan();

            int length = span.Length;

            string refType = GetRefType();

            return View();
        }

        private (int,int) GetDeconstructionTuple()
        {
            var (one, two) = (_dOne, _dTwo);

            return (one, two);
        }

        private int GetDigitSeparator()
        {
            int digitSeparator = 10000_00;

            return digitSeparator;
        }

        private string GetStringInterpolation()
        {
            string interpolatedString = $"This string is {_dOne} interpolated {_dTwo}";

            return interpolatedString;
        }

        private string GetExpressionBodiesMembers() => "Only one line is needed here for the method";

        private int GetInlineVariables()
        {
            string sValue = "0";

            int.TryParse(sValue, out int iValue);
           
            return iValue;  
        }

        private string GetNameOf(int value)
        {
            return nameof(value);
        }

        private string GetNestedFunction()
        {
            string value = string.Empty;

            string setValue(string value2) => value2 = "Nested Function";

            return setValue(value);
        }

        private string GetNullableRefTypes()
        {
            var nuller = new NullClass { One = 1 };

            if (nuller.Two is null)
            {
                return "Null value";
            };

            return string.Empty;
        }

        private class NullClass
        {
            public int One;     
            public int? Two;
        }

        private string GetPatternMatching()
        {
            string empty = string.Empty;

            if(empty is string empty2) { return empty; }//Is assigns to new type.

            return "Pattern not matched";
        }

        private Span<string> GetSpan()
        {
            string[] items = { "a", "b", "c" };

            Span<string> span = items.AsSpan();

            return span;
        }

        private ref string GetRefType()
        {
            return ref _refType;
        }
        
    }
}