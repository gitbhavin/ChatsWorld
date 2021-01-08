
using System;
using System.Windows;

namespace ChatsWorld
{
    /// <summary>
    /// A base attached property to replace vanilla/convenstional wpf attached property 
    /// </summary>
    /// <typeparam name="Parent">the parent class to be the attched property</typeparam>
    /// <typeparam name="Property">type of the attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()

    {
       

       
        #region Public Properties

        /// <summary>
        /// A singleton instance of the parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Defination

        /// <summary>
        /// Attached Property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// the Callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d"> The UI element that had it's property changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call the parent function
            Instance.OnValueChanged(d, e);

            //call event listener
             Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attched property
        /// </summary>
        /// <param name="d">The element to get the value from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d)
        {
            return ((Property)d.GetValue(ValueProperty));
        }

        // Above function cal also be written using Lambda expression
        // public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);


        /// <summary>
        /// Sets the attched Property
        /// </summary>
        /// <param name="d">The element to get the value from </param>
        /// <param name="value">The Value to set to</param>
        //public static void SetValue(DependencyObject d, Property value)
        //{
        //    d.SetValue(ValueProperty, value);
        //}

        //Above function can be written using Lambda Expression
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        #endregion


        #region Event Methods

        /// <summary>
        /// The Method which is called when any property of this type Changed
        /// </summary>
        /// <param name="Sender">The Ui elemenmt that this property was changed for </param>
        /// <param name="e">the arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject Sender, DependencyPropertyChangedEventArgs e) { }
        #endregion
    }



}
