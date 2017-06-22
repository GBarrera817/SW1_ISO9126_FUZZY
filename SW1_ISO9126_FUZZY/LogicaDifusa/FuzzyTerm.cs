using System;
using System.Collections.Generic;


namespace SW1_ISO9126_FUZZY.LogicaDifusa { 

    /// <summary>
    /// Linguistic term
    /// </summary>
    public class TerminoDifuso : NamedValueImpl
    {
        IFuncionMembresia _mf;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Term name</param>
        /// <param name="mf">Membership function initially associated with the term</param>
        public TerminoDifuso(string name, IFuncionMembresia mf) : base(name) {
            _mf = mf;
        }

        /// <summary>
        /// Funcion de membresia inicialmente asociada con un término 
        /// </summary>
        public IFuncionMembresia MembershipFunction {
            get { return _mf; }
        }
    }
}
