namespace SW1_ISO9126_FUZZY.Archivos {

    /// <summary>
    /// 
    /// </summary>
    public class EvaluacionSoftwareJSON {
        public EvaluacionSoftware EvaluacionSoftware { get; set; }
    }

    public class EvaluacionSoftware {
        public Datos_Sw Datos_sw { get; set; }
        public Metricas_Internas Metricas_internas { get; set; }
        public Metricas_Externas Metricas_externas { get; set; }
        public int[] Cantidad_respuestas { get; set; }
        public Estado_Modulos Estado_modulos { get; set; }
    }

    public class Datos_Sw {
        public string Nombre_sw { get; set; }
        public string[] Desarrolladores { get; set; }
        public string Descripcion_sw { get; set; }
        public bool Manual_usuario { get; set; }
    }

    public class Metricas_Internas {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
    }

    public class Metricas_Externas {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
    }

    public class Estado_Modulos {
        public int[] Funcionabilidad_interna { get; set; }
        public int[] Funcionabilidad_externa { get; set; }
        public int[] Usabilidad_interna { get; set; }
        public int[] Usabilidad_externa { get; set; }
        public int[] Mantenibilidad_interna { get; set; }
        public int[] Mantenibilidad_externa { get; set; }
    }
}
