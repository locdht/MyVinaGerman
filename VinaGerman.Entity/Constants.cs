using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity
{
    public class Constants
    {
        public const string DATE_ONLY_FORMAT_STRING = "{0:yyyy-MM-dd}";
        public const string DATE_AND_TIME_FORMAT_STRING = "{0:yyyy-MM-dd HH:mm:ss}";
        public const string TIME_ONLY_FORMAT_STRING = "{0:HH:mm:ss}";
        public const string DATE_FORMAT = "{0:dd.MM.yyyy}";
        public const string DATE_FORMAT_STRING = "dd.MM.yyyy";
        public const int NEW_RECORD = NULL_INT;
        public const string SQL_INDENT = "   ";
        public static readonly System.DateTime BIG_DATE = Convert.ToDateTime("01-01-3000");
        public static readonly System.DateTime SMALL_DATE = Convert.ToDateTime("01-01-1753");
        //--For transporting empty values-------------

        public const int NULL_INT = -2147483647;
        public const int IGNORE_VALUE_INT = -2147483646;
        public const int NONE_EXISTING_VALUE_INT = -2147483645;

        public const double NULL_DOUBLE = -1.7975E+308;
        public const double IGNORE_VALUE_DOUBLE = -1.7974E+308;
        public const double NONE_EXISTING_VALUE_DOUBLE = -1.7973E+308;

        public const float NULL_FLOAT = (float)-3.399E+38;
        public const float IGNORE_VALUE_FLOAT = (float)-3.398E+38;
        public const float NONE_EXISTING_VALUE_FLOAT = (float)-3.397E+38;

        public const string NULL_STRING = "-1.7973E+308";
        public const string IGNORE_VALUE_STRING = "-1.7972E+308";
        public const string NONE_EXISTING_VALUE_STRING = "-1.7971E+308";

        public static readonly System.DateTime NULL_DATE = Convert.ToDateTime("0100-1-1");
        public static readonly System.DateTime IGNORE_VALUE_DATE = Convert.ToDateTime("0100-1-31");
        public static readonly System.DateTime NONE_EXISTING_VALUE_DATE = Convert.ToDateTime("0100-1-30");

        public static readonly bool? IGNORE_VALUE_BOOL = new bool?();

        public const string EMPTY_STRING = "";
        public const string DB_NULL = "NULL";

        public const string NULL_GUID = "00000000-0000-0000-0000-000000000000";
        public const string IGNORE_VALUE_GUID = "00000000-0000-0000-0000-000000000001";
        public const string NONE_EXISTING_VALUE_GUID = "00000000-0000-0000-0000-000000000002";
    }
}
