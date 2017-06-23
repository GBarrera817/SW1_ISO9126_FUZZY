using System;
using System.Collections.Generic;


namespace SW1_ISO9126_FUZZY.LogicaDifusa {
    
    /// <summary>
    /// Tipos de composiciones funciones de membresía
    /// </summary>
    public enum TipoComposicionFM {
        /// <summary>
        /// Funciones de Minimos
        /// </summary>
        Min,
        /// <summary>
        /// Funciones de Maximos
        /// </summary>
        Max,
        /// <summary>
        /// Funciones de Producto
        /// </summary>
        Prod,
        /// <summary>
        /// Funciones de suma
        /// </summary>
        Sum
    }

    /// <summary>
    /// Interface of membership function
    /// </summary>
    
    public interface IFuncionMembresia {
        /// <summary>
        /// Evalúa el valor de una funcion de membresía 
        /// </summary>
        /// <param name="x">Argumento (Valor del eje x)</param>
        /// <returns></returns>
        double GetValue(double x);
    }

    /// <summary>
    /// Triangular membership function
    /// </summary>
    public class FuncionMembresiaTriangular : IFuncionMembresia {

        double _x1, _x2, _x3;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FuncionMembresiaTriangular() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x1">Point 1</param>
        /// <param name="x2">Point 2</param>
        /// <param name="x3">Point 3</param>
        public FuncionMembresiaTriangular(double x1, double x2, double x3) {

            if (!(x1 <= x2 && x2 <= x3)) {
                throw new ArgumentException();
            }

            _x1 = x1;
            _x2 = x2;
            _x3 = x3;
        }

        /// <summary>
        /// Punto 1
        /// </summary>
        public double X1 {
            get { return _x1; }
            set { _x1 = value; }
        }

        /// <summary>
        /// Punto 2
        /// </summary>
        public double X2 {
            get { return _x2; }
            set { _x2 = value; }
        }

        /// <summary>
        /// Punto 3
        /// </summary>
        public double X3 {
            get { return _x3; }
            set { _x3 = value; }
        }

        /// <summary>
        /// Evalua el valor de la funcion de membresia 
        /// </summary>
        /// <param name="x">Argumento (Valor del Eje x)</param>
        /// <returns></returns>
        
        public double GetValue(double x) {

            double resultado = 0;

            if (x == _x1 && x == _x2) {
                resultado = 1.0;
            } else if (x == _x2 && x == _x3) {
                resultado = 1.0;
            } else if (x <= _x1 || x >= _x3) {
                resultado = 0;
            } else if (x == _x2) {
                resultado = 1;
            } else if ((x > _x1) && (x < _x2)) {
                resultado = (x / (_x2 - _x1)) - (_x1 / (_x2 - _x1));
            } else {
                resultado = (-x / (_x3 - _x2)) + (_x3 / (_x3 - _x2));
            }

            return resultado;
        }

        /// <summary>
        /// Approximately converts to normal membership function
        /// </summary>
        /// <returns></returns>
        public NormalMembershipFunction ToNormalMF()
        {
            double b = _x2;
            double sigma25 = (_x3 - _x1) / 2.0;
            double sigma = sigma25 / 2.5;
            return new NormalMembershipFunction(b, sigma);
        }
    }


    /// <summary>
    /// Trapezoid membership function
    /// </summary>
    public class FuncionPertenenciaTrapezoidal : IFuncionMembresia {
        double _x1, _x2, _x3, _x4;


        /// <summary>
        /// Constructor
        /// </summary>
        public FuncionPertenenciaTrapezoidal() { }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x1">Punto 1</param>
        /// <param name="x2">Punto 2</param>
        /// <param name="x3">Punto 3</param>
        /// <param name="x4">Punto 4</param>

        public FuncionPertenenciaTrapezoidal(double x1, double x2, double x3, double x4) {

            if (!(x1 <= x2 && x2 <= x3 && x3 <= x4)) {
                throw new ArgumentException();
            }

            _x1 = x1;
            _x2 = x2;
            _x3 = x3;
            _x4 = x4;
        }

        /// <summary>
        /// Punto 1
        /// </summary>
        public double X1 {
            get { return _x1; }
            set { _x1 = value; }
        }

        /// <summary>
        /// Punto 2
        /// </summary>
        public double X2 {
            get { return _x2; }
            set { _x2 = value; }
        }

        /// <summary>
        /// Punto 3
        /// </summary>
        public double X3 {
            get { return _x3; }
            set { _x3 = value; }
        }

        /// <summary>
        /// Punto 4
        /// </summary>
        public double X4 {
            get { return _x4; }
            set { _x4 = value; }
        }

        /// <summary>
        /// Evalua el valor de la funcion de membresia 
        /// </summary>
        /// <param name="x">Argumento (Valor del Eje x)</param>
        /// <returns></returns>
        public double GetValue(double x) {

            double result = 0;

            if (x == _x1 && x == _x2) {
                result = 1.0;
            } else if (x == _x3 && x == _x4) {
                result = 1.0;
            } else if (x <= _x1 || x >= _x4) {
                result = 0;
            } else if ((x >= _x2) && (x <= _x3)) {
                result = 1;
            } else if ((x > _x1) && (x < _x2)) {
                result = (x / (_x2 - _x1)) - (_x1 / (_x2 - _x1));
            } else {
                result = (-x / (_x4 - _x3)) + (_x4 / (_x4 - _x3));
            }

            return result;
        }
    }


    /// <summary>
    /// Funcion de membresia Constante
    /// </summary>
    public class FuncionMembresiaConstante : IFuncionMembresia {

        double _valorConst;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="constValue">Valor Constante</param>
        public FuncionMembresiaConstante(double valorConst)
        {
            if (valorConst < 0.0 || valorConst > 1.0)
            {
                throw new ArgumentException();
            }

            _valorConst = valorConst;
        }

        /// <summary>
        /// Evaluate value of the membership function
        /// </summary>
        /// <param name="x">Argument (x axis value)</param>
        /// <returns></returns>
        public double GetValue(double x)
        {
            return _valorConst;
        }
    }


    /// <summary>
    /// Composition of several membership functions represened as single membership function
    /// </summary>
    internal class CompositeMembershipFunction : IFuncionMembresia {
        List<IFuncionMembresia> _mfs = new List<IFuncionMembresia>();
        TipoComposicionFM _tipoCompos;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="composType">Membership functions composition type</param>
        public CompositeMembershipFunction(TipoComposicionFM composType)
        {
            _tipoCompos = composType;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="composType">Membership functions composition type</param>
        /// <param name="mf1">Funcion de Membresia 1</param>
        /// <param name="mf2">Funcion de Membresia 2</param>
        public CompositeMembershipFunction(TipoComposicionFM tipoCompos,
                                           IFuncionMembresia mf1,
                                           IFuncionMembresia mf2) : this(tipoCompos) {
            _mfs.Add(mf1);
            _mfs.Add(mf2);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="composType">Membership functions composition type</param>
        /// <param name="mfs">Membership functions</param>
        public CompositeMembershipFunction(
                TipoComposicionFM composType,
                List<IFuncionMembresia> mfs)
            : this(composType)
        {
            _mfs = mfs;
        }

        /// <summary>
        /// List of membership functions
        /// </summary>
        public List<IFuncionMembresia> MembershipFunctions
        {
            get { return _mfs; }
        }

        /// <summary>
        /// Membership functions composition type
        /// </summary>
        public TipoComposicionFM CompositionType
        {
            get { return _tipoCompos; }
            set { _tipoCompos = value; }
        }

        /// <summary>
        /// Evaluate value of the membership function
        /// </summary>
        /// <param name="x">Argument (x axis value)</param>
        /// <returns></returns>
        public double GetValue(double x)
        {
            if (_mfs.Count == 0) {
                return 0.0;
            } else if (_mfs.Count == 1) {
                return _mfs[0].GetValue(x);
            } else {
                double result = _mfs[0].GetValue(x);

                for (int i = 1; i < _mfs.Count; i++) {
                    result = Compose(result, _mfs[i].GetValue(x));
                }
                return result;
            }
        }

        double Compose(double val1, double val2) {

            switch (_tipoCompos) {

                case TipoComposicionFM.Max:
                    return Math.Max(val1, val2);
                case TipoComposicionFM.Min:
                    return Math.Min(val1, val2);
                case TipoComposicionFM.Prod:
                    return val1 * val2;
                case TipoComposicionFM.Sum:
                    return val1 + val2;
                default:
                    throw new Exception("Internal exception.");
            }
        }
    }
}
