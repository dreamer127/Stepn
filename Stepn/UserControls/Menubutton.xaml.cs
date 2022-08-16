using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace Stepn.UserControls
{
    public partial class Menubutton : UserControl
    {
        public Menubutton()
        {
            InitializeComponent();
        }
        public PackIconMaterialKind Icon
        {
            get { return(PackIconMaterialKind) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = 
            DependencyProperty.Register("Icon", typeof(PackIconMaterialKind), typeof(Menubutton));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(Menubutton));
    }
}
