using System.Windows;

namespace ChatsWorld
{
    /// <summary>
    /// View Model for custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member 

        /// <summary>
        /// The Window this view model control
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin arround the window to allow drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public Member

        /// <summary>
        /// size of the reize border arround the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// size of the reize border arround the window,talking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The margin arround the window to allow drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }


        /// <summary>
        /// The margin arround the window to allow drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// Height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            this.mWindow = window;

            //Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));

            };
        }


        #endregion
    }
}
