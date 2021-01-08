using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ChatsWorld
{
    /// <summary>
    /// The base value Converter that allow direct XML usage
    /// </summary>
    /// <typeparam name="T">The Type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Member

        /// <summary>
        /// A Single static instance of this value converter
        /// </summary>
        private static T mConverter = null;
        #endregion

        #region Markup Extenstion Method

        /// <summary>
        /// Provide static instance of the mConverter
        /// </summary>
        /// <param name="serviceProvider">The Service Provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if(mConverter== null)
            //{
            //    mConverter = new T();
            //}

            //return mConverter;

            //Or we can also write as 

            return mConverter ?? (mConverter = new T());
        }
        #endregion

        #region Value converter Method

        /// <summary>
        /// Method that convert one type to anothe type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Method that convert it's value back to the source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion

    }
}
