using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Markup;
using VinaGerman.Entity;


namespace VinaGerman.DesktopApplication.Utilities
{    
    public class Object2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string result = "";
            if (value != null)
            {
                if (value is string)
                {
                    string sValue = value.ToString();
                    result = (sValue == Constants.IGNORE_VALUE_STRING || sValue.ToString() == Constants.NULL_STRING) ? "" : sValue;
                }
                else if (value is int)
                {
                    int iValue = Constants.IGNORE_VALUE_INT;
                    int.TryParse(value.ToString(), out iValue);
                    result = (iValue == Constants.IGNORE_VALUE_INT || iValue == Constants.NULL_INT) ? "" : iValue.ToString();
                }
                else if (value is float)
                {
                    float fValue = Constants.IGNORE_VALUE_FLOAT;
                    float.TryParse(value.ToString(), out fValue);
                    result = (fValue == Constants.IGNORE_VALUE_FLOAT || fValue == Constants.NULL_FLOAT) ? "" : fValue.ToString();
                }
                else if (value is DateTime)
                {
                    DateTime dValue = Constants.IGNORE_VALUE_DATE;
                    DateTime.TryParse(value.ToString(), out dValue);
                    result = (dValue == Constants.IGNORE_VALUE_DATE || dValue == Constants.NULL_DATE) ? "" : dValue.ToString("dd.MM.yyyy");
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = "";
            if (value != null)
            {
                if (value is string)
                {
                    string sValue = value.ToString();
                    result = (sValue == Constants.IGNORE_VALUE_STRING || sValue.ToString() == Constants.NULL_STRING) ? "" : sValue;
                }
            }
            return result;
        }
    }

    public class Object2StringWithoutNewlineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string result = "";
            if (value != null)
            {
                if (value is string)
                {
                    string sValue = value.ToString();
                    result = (sValue == Constants.IGNORE_VALUE_STRING || sValue.ToString() == Constants.NULL_STRING) ? "" : sValue.Replace(Environment.NewLine, " ").Replace("\n", " ");
                }
                else if (value is int)
                {
                    int iValue = Constants.IGNORE_VALUE_INT;
                    int.TryParse(value.ToString(), out iValue);
                    result = (iValue == Constants.IGNORE_VALUE_INT || iValue == Constants.NULL_INT) ? "" : iValue.ToString();
                }
                else if (value is float)
                {
                    float fValue = Constants.IGNORE_VALUE_FLOAT;
                    float.TryParse(value.ToString(), out fValue);
                    result = (fValue == Constants.IGNORE_VALUE_FLOAT || fValue == Constants.NULL_FLOAT) ? "" : fValue.ToString();
                }
                else if (value is DateTime)
                {
                    DateTime dValue = Constants.IGNORE_VALUE_DATE;
                    DateTime.TryParse(value.ToString(), out dValue);
                    result = (dValue == Constants.IGNORE_VALUE_DATE || dValue == Constants.NULL_DATE) ? "" : dValue.ToString("dd.MM.yyyy");
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = "";
            if (value != null)
            {
                if (value is string)
                {
                    string sValue = value.ToString();
                    result = (sValue == Constants.IGNORE_VALUE_STRING || sValue.ToString() == Constants.NULL_STRING) ? "" : sValue;
                }
            }
            return result;
        }
    }

    [ValueConversion(typeof(object), typeof(bool))]
    public class NotNullToBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return (value != null) ? true : false;            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;

            return val == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolNotToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;

            return val == false ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NotBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;

            return !val;
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;

            return val == true ? new GridLength(1,GridUnitType.Star) : new GridLength(0, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolNotToColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;

            return val == false ? new GridLength(1, GridUnitType.Star) : new GridLength(0, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class TreeViewItemExtensions
    {
        public static int GetDepth(this TreeViewItem item)
        {
            TreeViewItem parent;
            while ((parent = GetParent(item)) != null)
            {
                return GetDepth(parent) + 1;
            }
            return 0;
        }

        private static TreeViewItem GetParent(TreeViewItem item)
        {
            var parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as TreeViewItem;
        }
    }

    public class LeftMarginMultiplierConverter : IValueConverter
    {
        public double Length { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as TreeViewItem;
            if (item == null)
                return new Thickness(0);

            return new Thickness(Length * item.GetDepth(), 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }   

    public class DateAndTime2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string result = "";
            if (value != null)
            {
                DateTime dValue = Constants.IGNORE_VALUE_DATE;
                DateTime.TryParse(value.ToString(), out dValue);
                result = (dValue == Constants.IGNORE_VALUE_DATE || dValue == Constants.NULL_DATE) ? "" : dValue.ToString("dd.MM.yyyy HH:mm:ss");
            }
            return result;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = "";
            if (value is string)
            {
                string sValue = value.ToString();
                result = (sValue == Constants.IGNORE_VALUE_STRING || sValue.ToString() == Constants.NULL_STRING) ? "" : sValue;
            }
            return result;
        }
    }
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? selectedDate = value as DateTime?;

            if (selectedDate != null)
            {
                string dateTimeFormat = parameter as string;
                return selectedDate.Value.ToString(dateTimeFormat);
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var valor = value as string;
                if (!string.IsNullOrEmpty(valor))
                {
                    string dateTimeFormat = parameter as string;
                    var retorno = DateTime.ParseExact(valor, dateTimeFormat, provider);
                    //set current time
                    if (retorno.Date <= DateTime.Now.Date)
                    {
                        //set current time:
                        retorno = new DateTime(retorno.Year, retorno.Month, retorno.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        return retorno;
                    }
                    else
                    {
                        return null;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }    

    //#region Addresses

    //public class AddressesStringConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value != null)
    //        {
    //            if (value is CompanyBase)
    //            {
    //                CompanyBase company = (CompanyBase)value;

    //                string addresses = string.Empty;

    //                if (!MethodExtension.IsNullOrIgnore(company.Address1))
    //                {
    //                    addresses += company.Address1;
    //                }

    //                if (!MethodExtension.IsNullOrIgnore(company.Address2))
    //                {
    //                    if (addresses == string.Empty)
    //                    {
    //                        addresses += company.Address2;
    //                    }
    //                    else
    //                    {
    //                        addresses += Environment.NewLine + company.Address2;
    //                    }
    //                }

    //                return addresses;
    //            }
    //            else if (value is LocationBase)
    //            {
    //                LocationBase Location = (LocationBase)value;

    //                string addresses = string.Empty;

    //                if (!MethodExtension.IsNullOrIgnore(Location.Address1))
    //                {
    //                    addresses += Location.Address1;
    //                }

    //                if (!MethodExtension.IsNullOrIgnore(Location.Address2))
    //                {
    //                    if (addresses == string.Empty)
    //                    {
    //                        addresses += Location.Address2;
    //                    }
    //                    else
    //                    {
    //                        addresses += Environment.NewLine + Location.Address2;
    //                    }
    //                }

    //                return addresses;
    //            }
    //        }

    //        return "";
    //    }

    //    public object ConvertBack(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //#endregion

    //#region Descriptions
    //public class CategoryDescriptionsStringConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value != null)
    //        {
    //            if (value is ControlCategoryBase)
    //            {
    //                ControlCategoryBase obj = (ControlCategoryBase)value;

    //                if (obj.ControlCategoryId == Constants.NULL_INT || obj.ControlCategoryId == Constants.IGNORE_VALUE_INT)
    //                {
    //                    return obj.Comment;
    //                }
    //                else
    //                {
    //                    return obj.Description + " - " + obj.Comment;
    //                }                    
    //            }
    //        }

    //        return string.Empty;
    //    }

    //    public object ConvertBack(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class CompanyDescriptionsStringConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value != null)
    //        {
    //            if (value is CompanyBase)
    //            {
    //                CompanyBase company = (CompanyBase)value;

    //                return (MethodExtension.IsNullOrIgnore(company.ShortDescription) ? (MethodExtension.IsNullOrIgnore(company.Description) ? "" : company.Description) : (company.ShortDescription));
    //            }
    //        }

    //        return string.Empty;
    //    }

    //    public object ConvertBack(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public class DocumentTypeStringConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType,
    //     object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value is int)
    //        {
    //            switch ((int)value)
    //            {
    //                case (int)enumDocumentType.DOCUMENT_TYPE_CERTIFICATE:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_CERTIFICATE;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_INSTRUCTIONS:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_INSTRUCTIONS;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_CONTROL_DOCUMENTATION:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_CONTROL_DOCUMENTATION;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_DECLARATION_OF_CONFORMITY:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_DECLARATION_OF_CONFORMITY;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_JOB_REPORT:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_JOB_REPORT;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_JOB_REPORT_DEVATION_ONLY:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_JOB_REPORT_DEVATION_ONLY;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_OTHER:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_OTHER;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_PICTURE:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_PICTURE;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_PROJECTPAGE2:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_PROJECTPAGE2;
    //                    }
    //                case (int)enumDocumentType.DOCUMENT_TYPE_SERVICE_DOCUMENTATION:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_SERVICE_DOCUMENTATION;
    //                    }
    //                default:
    //                    {
    //                        return StringResources.DOCUMENT_TYPE_CONTROL_DOCUMENTATION;
    //                    }
    //            }
    //        }
    //        return string.Empty;
    //    }
    //    public object ConvertBack(object value, Type targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class DataValueStringConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] value, Type targetType,
    //     object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value[1] is int)
    //        {
    //            DataValueBase temp = (DataValueBase)value[1];
    //            switch (temp.DataType)
    //            {
    //                case (int)enumDataType.TYPE_STRING_SHORT:
    //                    {
    //                        return temp.DataStringShort;
    //                    }
    //                case (int)enumDataType.TYPE_STRING_LONG:
    //                    {
    //                        return temp.DataStringLong;
    //                    }
    //                case (int)enumDataType.TYPE_INT:
    //                    {
    //                        return temp.DataInteger;
    //                    }
    //                case (int)enumDataType.TYPE_FLOAT:
    //                    {
    //                        return temp.DataFloat;
    //                    }
    //                default:
    //                    {
    //                        return temp.DataStringShort;
    //                    }
    //            }                
    //        }
    //        return string.Empty;
    //    }
    //    public object[] ConvertBack(object value, Type[] targetType,
    //      object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        DataValueBase temp = (DataValueBase)parameter;
    //        switch (temp.DataType)
    //        {
    //            case (int)enumDataType.TYPE_INT:
    //                {
    //                    try
    //                    {
    //                        int.Parse(value.ToString());
    //                    }
    //                    catch
    //                    {
    //                        MessageBox.Show("Wrong value");
    //                    }
    //                    break;
    //                }
    //            case (int)enumDataType.TYPE_FLOAT:
    //                {
    //                    try
    //                    {
    //                        float.Parse(value.ToString());
    //                    }
    //                    catch
    //                    {
    //                        MessageBox.Show("Wrong value");
    //                    }
    //                    break;
    //                }
    //            default:
    //                {
    //                    break;
    //                }
    //        }
    //        string[] splitValues = ((string)value).Split(' ');
    //        return splitValues;
    //    }
    //}

    //public class Language2FirstDayOfWeek : IValueConverter
    //{

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value != null)
    //        {
    //            string sLanguage = "en-us";
    //            if (value.GetType() == typeof(XmlLanguage))
    //            {
    //               sLanguage = ((XmlLanguage)value).IetfLanguageTag.ToLower();
    //            }
    //            else if (value.GetType() == typeof(string))
    //            {
    //                sLanguage = value.ToString().ToLower();
    //            }
    //            else if (value.GetType() == typeof(CultureInfo))
    //            {
    //                sLanguage = ((CultureInfo)value).IetfLanguageTag.ToLower();
    //            }

    //            switch (sLanguage)
    //            {
    //                case "en-us": return DayOfWeek.Sunday;
    //                default: return DayOfWeek.Monday;
    //            }
    //        }
    //        return DayOfWeek.Monday;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Status2BooleanConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        int param = (int)parameter;
    //        return (int)value == (int)param;
    //    }

    //    public object ConvertBack(object value, Type targetTypes, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        int param = (int)parameter;
    //        if (value is bool)
    //        {
    //            if (((bool)value) == true)
    //            {
    //                return (int)param;
    //            }
    //        }
    //        return Constants.IGNORE_VALUE_INT;
    //    }
    //}

    //public class Status2SolidColorBrushConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        int status = (int)value;
    //        switch (status)
    //        {
    //            case (int)enumStatusValue.STATUSVALUE_OK: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusOK");
    //            case (int)enumStatusValue.STATUSVALUE_C: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusC");
    //            case (int)enumStatusValue.STATUSVALUE_M: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusM");
    //            case (int)enumStatusValue.STATUSVALUE_MO: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusMO");
    //            case (int)enumStatusValue.STATUSVALUE_RC: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusRC");
    //            case (int)enumStatusValue.STATUSVALUE_NC: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusNC");
    //            case (int)enumStatusValue.STATUSVALUE_NA: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusNA");
    //            case (int)enumStatusValue.STATUSVALUE_U: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusU");
    //            default: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusUnknow");
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetTypes, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        return value;
    //    }
    //}

    //public class Status2SolidColorBrushMultiConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
    //    {
    //        int Status = (int)values[0];
    //        bool Inactive = (bool)values[1];
    //        bool IsDiscarded = (bool)values[2];
    //        if (Inactive || IsDiscarded)
    //        {
    //            return new SolidColorBrush(Color.FromRgb(150, 150, 150));
    //        }
    //        else
    //        {
    //            switch (Status)
    //            {
    //                case (int)enumStatusValue.STATUSVALUE_OK: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusOK");
    //                case (int)enumStatusValue.STATUSVALUE_C: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusC");
    //                case (int)enumStatusValue.STATUSVALUE_M: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusM");
    //                case (int)enumStatusValue.STATUSVALUE_MO: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusMO");
    //                case (int)enumStatusValue.STATUSVALUE_RC: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusRC");
    //                case (int)enumStatusValue.STATUSVALUE_NC: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusNC");
    //                case (int)enumStatusValue.STATUSVALUE_NA: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusNA");
    //                case (int)enumStatusValue.STATUSVALUE_U: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusU");
    //                default: return (SolidColorBrush)System.Windows.Application.Current.FindResource("InspectionStatusUnknow");
    //            }
    //        }
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Status2TextConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        int status = (int)value;
    //        switch (status)
    //        {
    //            case (int)enumStatusValue.STATUSVALUE_OK: return "OK";
    //            case (int)enumStatusValue.STATUSVALUE_C: return "C";
    //            case (int)enumStatusValue.STATUSVALUE_M: return "M";
    //            case (int)enumStatusValue.STATUSVALUE_MO: return "MO";
    //            case (int)enumStatusValue.STATUSVALUE_RC: return "RC";
    //            case (int)enumStatusValue.STATUSVALUE_NC: return "NC";
    //            case (int)enumStatusValue.STATUSVALUE_NA: return "NA";
    //            case (int)enumStatusValue.STATUSVALUE_U: return "U";
    //            default: return "?";
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetTypes, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        return value;
    //    }
    //}
    //#endregion
}