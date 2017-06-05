using SW1_ISO9126_FUZZY.Mvvm;
using System.Collections.ObjectModel;

namespace SW1_ISO9126_FUZZY.ViewModels {

    internal class ViewModelBase : BindableBase {

        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public ViewModelBase() {
        }

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;
    }
}