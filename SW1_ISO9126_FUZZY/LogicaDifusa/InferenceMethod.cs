using System;
using System.Collections.Generic;


namespace SW1_ISO9126_FUZZY.LogicaDifusa {

    /// <summary>
    /// And evaluating method
    /// </summary>
    public enum MetodoAND {

        /// <summary>
        /// Minimum: min(a, b)
        /// </summary>
        Min,
        /// <summary>
        /// Production: a * b
        /// </summary>
        Production
    }

    /// <summary>
    /// Fuzzy implication method
    /// </summary>
    public enum MetodoImplicacion
    {
        /// <summary>
        /// Truncation of output fuzzy set
        /// </summary>
        Min,
        /// <summary>
        /// Scaling of output fuzzy set
        /// </summary>
        Production
    }

    /// <summary>
    /// Aggregation method for membership functions
    /// </summary>
    public enum MetodoAgregacion
    {
        /// <summary>
        /// Maximum of rule outpus
        /// </summary>
        Max,
        /// <summary>
        /// Sum of rule output
        /// </summary>
        Sum
    }

    /// <summary>
    /// Defuzzification method
    /// </summary>
    public enum MetodoDefuzzificacion {
        /// <summary>
        /// Centro del área del resultado de una Funcion de membresia difusa 
        /// </summary>
        Centroide,
    }
}
