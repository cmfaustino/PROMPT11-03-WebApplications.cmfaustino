// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperEnhancer.cs" company="Servisys Solutions, Lda - Quickipic">
//   Luís Falcão - 2009
// </copyright>
// <summary>
//  Extension methods to <see cref="HtmlHelper"/> to support sortable columns in grids, sorting
//  and other utility methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Mod03_ChelasMovies.WebApp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    /// <summary>
    /// Extension methods to <see cref="HtmlHelper"/> to support sortable columns in grids, sorting
    /// and other utility methods.
    /// </summary>
    public static class HtmlHelperEnhancer
    {

        public static MvcHtmlString DropDownListForEnum<TEnum>(this HtmlHelper helper, string name, object selectedItemValue)
            where TEnum : struct
        {
            return helper.DropDownListForEnum<TEnum>(name, selectedItemValue, null);
        }


        public static MvcHtmlString DropDownListForEnum<TEnum>(this HtmlHelper helper, string name, object selectedItemValue, object htmlAttributes)
            where TEnum : struct
        {
            return helper.DropDownListForEnum(typeof(TEnum), name, selectedItemValue, htmlAttributes);
        }

        public static MvcHtmlString DropDownListForEnum(this HtmlHelper helper, Type enumType, string name, object selectedItemValue)
        {
            return helper.DropDownListForEnum(enumType, name, selectedItemValue, null);
        }

        public static MvcHtmlString DropDownListForEnum(this HtmlHelper helper, Type enumType, string name, object selectedItemValue, object htmlAttributes)
        {
            IEnumerable<SelectListItem> itens = Enum.GetValues(enumType).Cast<object>().Select(v =>
            {
                int value = (int)v; 
                return new SelectListItem
                {
                    Value = value.ToString(),
                    Text = v.ToString(),
                    Selected = v.Equals(selectedItemValue)
                };
            });
            return helper.DropDownList(name, itens);//, htmlAttributes);
        }
    }
}
