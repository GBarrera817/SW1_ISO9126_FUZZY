using System;
using System.Collections.Generic;


namespace SW1_ISO9126_FUZZY.LogicaDifusa {

    /// <summary>
    /// Variable Linguistica 
    /// </summary>
    public class VariableDifusa : NamedVariableImpl
    {
        double _min = 0.0, _max = 10.0;
        List<TerminoDifuso> _terms = new List<TerminoDifuso>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        public VariableDifusa(string name, double min, double max) : base (name) {
            if (min > max) {
                throw new ArgumentException("El valor máximo debe ser más grande que el valor mínimo.");
            }

            _min = min;
            _max = max;
        }

        /// <summary>
        /// Terms
        /// </summary>
        public List<TerminoDifuso> Terminos
        {
            get { return _terminos; }
        }

        /// <summary>
        /// Named values
        /// </summary>
        public override List<INamedValue> Valores
        {
            get
            {
                List<INamedValue> result = new List<INamedValue>();
                foreach (TerminoDifuso term in _terms)
                {
                    result.Add(term);
                }
                return result;
            }
        }

        /// <summary>
        /// Get membership function (term) by name
        /// </summary>
        /// <param name="name">Term name</param>
        /// <returns></returns>
        public TerminoDifuso GetTermByName(string name)
        {
            foreach (TerminoDifuso term in _terms) {
                if (term.Name == name) {
                    return term;
                }
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Maximum value of the variable
        /// </summary>
        public double Max {
            get { return _max; }
            set { _max = value; }
        }

        /// <summary>
        /// Minimum value of the variable
        /// </summary>
        public double Min {
            get { return _min; }
            set { _min = value; }
        }
    }
}
