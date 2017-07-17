using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Calculos
{
	public class Normalizacion
	{
		//CORREGIR LAS VARIABLES
		private Dictionary<string, string> _funcionabilidadInterna;
		private Respuesta _usabilidadInterna;
		private Respuesta _mantenibilidadInterna;
		private Respuesta _funcionabilidadExterna;
		private Respuesta _usabilidadExterna;
		private Respuesta _mantenibilidadExterna;

		public Normalizacion()
		{
			_funcionabilidadInterna = new Dictionary<string, string>();
			_usabilidadInterna = new Respuesta();
			_mantenibilidadInterna = new Respuesta();
			_funcionabilidadExterna = new Respuesta();
			_usabilidadExterna = new Respuesta();
			_mantenibilidadExterna = new Respuesta();
		}

		public void calcularValoresNormalizadosFuncionalidad(double incidenciaAdecuacion, double incidenciaExactitud, double incidenciaInteroperabilidad, 
															 double incidenciaSeguridadAcceso, double incidenciaCumplimientoFuncional)
		{
			double[] normalizar = { incidenciaAdecuacion, incidenciaExactitud, incidenciaInteroperabilidad, incidenciaSeguridadAcceso, incidenciaCumplimientoFuncional};
			double maximo = normalizar.Max();

			if (maximo == 0)
			{
				//this.Adecuacion = 0;
				//this.Exactitud = 0;
				//this.Interoperabilidad = 0;
				//this.Seguridad = 0;
				//this.CumplimientoFuncional = 0;
			} else
			{
				double divAdecuacion = incidenciaAdecuacion / maximo;
				double divExactitud = incidenciaExactitud / maximo;
				double divInteroperabilidad = incidenciaInteroperabilidad / maximo;
				double divSeguridad= incidenciaSeguridadAcceso/ maximo;
				double divCumplimiento= incidenciaCumplimientoFuncional / maximo;

				//this.adecuacion = (divAdecuacion * this.adecuacion);
				//this.exactitud = (divExactitud * this.exactitud);
				//this.interoperabilidad = (divInteroperabilidad * this.interoperabilidad);
				//this.seguridad = (divSeguridad * this.seguridad);
				//this.cumplimientoFuncional = (divCumplimiento * this.cumplimientoFuncional);

				//if (this.adecuacion > 1.0)
				//{
				//	this.adecuacion = 1.0;
				//}
				//if (this.exactitud > 1.0)
				//{
				//	this.exactitud = 1.0;
				//}
				//if (this.interoperabilidad > 1.0)
				//{
				//	this.interoperabilidad = 1.0;
				//}
				//if (this.seguridad > 1.0)
				//{
				//	this.seguridad = 1.0;
				//}
				//if (this.cumplimientoFuncional > 1.0)
				//{
				//	this.cumplimientoFuncional = 1.0;
				//}
			}
		}


		public void calcularValoresNormalizadosUsabilidad(double incidenciaComprensibilidad, double incidenciaAprendizaje, double incidenciaOperabilidad,
														  double incidenciaAtractividad, double incidenciaCumplimientoUsabilidad)
		{
			double[] normalizar = { incidenciaComprensibilidad, incidenciaAprendizaje, incidenciaOperabilidad, incidenciaAtractividad, incidenciaCumplimientoUsabilidad };
			double maximo = normalizar.Max();

			if (maximo == 0)
			{
				//this.Comprensibilidad = 0;
				//this.Aprendizaje = 0;
				//this.Operabilidad = 0;
				//this.Atractividad = 0;
				//this.CumplimientoUsabilidad = 0;
			} else
			{
				double divAComprensibilidad = incidenciaComprensibilidad / maximo;
				double divAprendizaje = incidenciaAprendizaje / maximo;
				double divOperabilidad = incidenciaOperabilidad / maximo;
				double divAtractividad = incidenciaAtractividad / maximo;
				double divCumplimiento = incidenciaCumplimientoUsabilidad / maximo;

				//this.comprensibilidad = (divAdecuacion * this.comprensibilidad);
				//this.aprendizaje = (divExactitud * this.aprendizaje);
				//this.operabilidad = (divInteroperabilidad * this.operabilidad);
				//this.atractividad = (divSeguridad * this.atractividad);
				//this.cumplimientoUsabilidad = (divCumplimiento * this.cumplimientoUsabilidad);

				//if (this.comprensibilidad > 1.0)
				//{
				//	this.comprensibilidad = 1.0;
				//}
				//if (this.aprendizaje > 1.0)
				//{
				//	this.aprendizaje = 1.0;
				//}
				//if (this.operabilidad > 1.0)
				//{
				//	this.operabilidad = 1.0;
				//}
				//if (this.atractividad > 1.0)
				//{
				//	this.atractividad = 1.0;
				//}
				//if (this.cumplimientoUsabilidad > 1.0)
				//{
				//	this.cumplimientoUsabilidad = 1.0;
				//}
			}
		}

		public void calcularValoresNormalizadosMantenibilidad(double incidenciaAnalizabilidad, double incidenciaModificabilidad, double incidenciaEstabilidad,
															  double incidenciaTesteabilidad, double incidenciaCumplimientoMantenibilidad)
		{
			double[] normalizar = { incidenciaAnalizabilidad, incidenciaModificabilidad, incidenciaEstabilidad, incidenciaTesteabilidad, incidenciaCumplimientoMantenibilidad };
			double maximo = normalizar.Max();

			if (maximo == 0)
			{
				//this.Analizabilidad = 0;
				//this.Modificabilidad = 0;
				//this.Estabilidad = 0;
				//this.Testeabilidad = 0;
				//this.CumplimientoMantenibilidad = 0;
			} else
			{
				double divAAnalizabilidad = incidenciaAnalizabilidad / maximo;
				double divModificabilidad = incidenciaModificabilidad / maximo;
				double divEstabilidad = incidenciaEstabilidad / maximo;
				double divTesteabilidad = incidenciaTesteabilidad / maximo;
				double divCumplimiento = incidenciaCumplimientoMantenibilidad / maximo;

				//this.analizabilidad = (divAAnalizabilidad * this.analizabilidad);
				//this.modificabilidad = (divModificabilidad * this.modificabilidad);
				//this.estabilidad = (divEstabilidad * this.estabilidad);
				//this.testeabilidad = (divTesteabilidad * this.testeabilidad);
				//this.cumplimientoMantenibilidad = (divCumplimiento * this.cumplimientoMantenibilidad);

				//if (this.analizabilidad > 1.0)
				//{
				//	this.analizabilidad = 1.0;
				//}
				//if (this.modificabilidad > 1.0)
				//{
				//	this.modificabilidad = 1.0;
				//}
				//if (this.estabilidad > 1.0)
				//{
				//	this.estabilidad = 1.0;
				//}
				//if (this.testeabilidad > 1.0)
				//{
				//	this.testeabilidad = 1.0;
				//}
				//if (this.cumplimientoMantenibilidad > 1.0)
				//{
				//	this.cumplimientoMantenibilidad = 1.0;
				//}
			}
		}
	}
}
