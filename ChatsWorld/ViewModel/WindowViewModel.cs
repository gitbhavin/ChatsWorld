using System.Windows;
using System.Windows.Input;

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
        /// Windows Minimum Height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// Windows Minimum Width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        // public bool Borderless { get { return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// size of the reize border arround the window
        /// </summary>
        public int ResizeBorder { get; set; } = 0;

        /// <summary>
        /// size of the reize border arround the window,talking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }


        /// <summary>
        /// The Padding of the inner content of the main window
        /// </summary>
       // public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


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


        /// <summary>
        /// The Current Page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        #endregion

        #region Window Command

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
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


            //Create Command

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosistion()));

            //Fix Window resize issue
            var resizer = new WindowResizer(mWindow);
        }


        #endregion

        #region Private Helpers

        private Point GetMousePosistion()
        {
            //position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);


            if (mWindow.WindowState == WindowState.Maximized)
            {
                return new Point(position.X, position.Y);
            }
            else
            {
                // if Window is not in maximize state than add Left and top postion of the window
                return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
            }


        }
        #endregion
    }
}
