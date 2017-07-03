using SW1_ISO9126_FUZZY.Mvvm;
using System.Collections.ObjectModel;

namespace SW1_ISO9126_FUZZY.ModelosVistas {

    internal class ModeloVistaBase : BindableBase {

        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public ModeloVistaBase() { }

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;
    }
}