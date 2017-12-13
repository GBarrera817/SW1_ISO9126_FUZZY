using iTextSharp.text;
using iTextSharp.text.pdf;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.IO;
using System.Windows.Forms;
using SW1_ISO9126_FUZZY.Vistas;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Archivos {

    public class Reportes
	{
		private string imageURL;
		private Document doc;
		private FileStream fs;
		private PdfWriter writer;

		private Font titleFont;
		private Font subTitleFont;
		private Font boldTableFont;
		private Font bodyFont;

		private Evaluacion miEvaluacion;

		private List<string> datosPDF;

		public Reportes(string nombreArchivo, Evaluacion nueva, List<string> confPDF)
		{
			miEvaluacion = nueva;
			datosPDF = confPDF;

			imageURL = @"D:/Documentos/Visual Studio 2017/Projects/SW1_ISO9126_FUZZY/SW1_ISO9126_FUZZY/Imagenes/";
			//titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD);
			//subTitleFont = FontFactory.GetFont("Arial", 18, Font.BOLD | Font.UNDERLINE);
			//boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
			//endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);

			if (datosPDF[1].Equals("ARIAL"))
			{
				titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD);
				subTitleFont = FontFactory.GetFont("Arial", 18, Font.BOLD | Font.UNDERLINE);
				boldTableFont = FontFactory.GetFont("Arial", datosPDF[2], Font.BOLD);
				bodyFont = FontFactory.GetFont("Arial", datosPDF[2]);
			}

			if (datosPDF[1].Equals("HELVETICA"))
			{
				titleFont = FontFactory.GetFont("Helvetica", 24, Font.BOLD);
				subTitleFont = FontFactory.GetFont("Helvetica", 18, Font.BOLD | Font.UNDERLINE);
				boldTableFont = FontFactory.GetFont("Helvetica", datosPDF[2], Font.BOLD);
				bodyFont = FontFactory.GetFont("Helvetica", datosPDF[2]);
			}

			if (datosPDF[1].Equals("COURIER"))
			{
				titleFont = FontFactory.GetFont("Courier", 24, Font.BOLD);
				subTitleFont = FontFactory.GetFont("Courier", 18, Font.BOLD | Font.UNDERLINE);
				boldTableFont = FontFactory.GetFont("Courier", datosPDF[2], Font.BOLD);
				bodyFont = FontFactory.GetFont("Courier", datosPDF[2]);
			}

			/*
			if (datosPDF[1].Equals("TIMES NEW ROMAN"))
			{
				titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD);
				subTitleFont = FontFactory.GetFont("Arial", 18, Font.BOLD | Font.UNDERLINE);
				boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
			}*/

			try
			{
				doc = new Document();
				fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None);
				writer = PdfWriter.GetInstance(doc, fs);

				doc.Open();

				// ENCABEZADO
				Image logoISO = Image.GetInstance(imageURL + "/logoPDF.jpg");
				//logoISO.ScalePercent(0.2f * 100);
				logoISO.ScaleAbsoluteHeight(80);
				logoISO.ScaleAbsoluteWidth(80);
				logoISO.SetAbsolutePosition(460, 740);
				doc.Add(logoISO);

				Image logoULS = Image.GetInstance(imageURL + "/logoIngecomp.jpg");
				logoULS.ScaleAbsoluteHeight(80);
				logoULS.ScaleAbsoluteWidth(80);
				logoULS.SetAbsolutePosition(60, 740);
				doc.Add(logoULS);


				Paragraph tituloInforme = new Paragraph("Informe de evaluación ", titleFont);
				tituloInforme.Alignment = Element.ALIGN_CENTER;
				tituloInforme.SpacingBefore = 60;
				Paragraph fuzzisoft = new Paragraph("Fuzzisoft 9126", FontFactory.GetFont("Arial", 22, Font.BOLD));
				fuzzisoft.Alignment = Element.ALIGN_CENTER;
				doc.Add(tituloInforme);
				doc.Add(fuzzisoft);
				doc.Add(Chunk.NEWLINE);

				// REGISTROS DEL SOFTWARE
				doc.Add(new Paragraph("Datos del evaluador", subTitleFont));
				doc.Add(new Paragraph("\n"));

				PdfPTable tblDatosEv = new PdfPTable(2);

				tblDatosEv.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
				tblDatosEv.SpacingBefore = 4;
				tblDatosEv.SpacingAfter = 10;
				tblDatosEv.DefaultCell.Border = 0;
				tblDatosEv.SetWidths(new int[] { 2, 4 });

				tblDatosEv.AddCell(new Phrase("Nombre del evaluador: ", bodyFont));
				tblDatosEv.AddCell(new Phrase(miEvaluacion.Informacion.Evaluador, bodyFont)); //tblPrueba.AddCell("txtCampo.Text");
				tblDatosEv.AddCell("Tipo de usuario: ");
				tblDatosEv.AddCell(miEvaluacion.Informacion.Tipo);

				doc.Add(tblDatosEv);


				doc.Add(new Paragraph("Registro del software", subTitleFont));
				doc.Add(new Paragraph("\n"));

				PdfPTable tblRegSW = new PdfPTable(2);
				tblRegSW.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
				tblRegSW.SpacingBefore = 4;
				tblRegSW.SpacingAfter = 10;
				tblRegSW.DefaultCell.Border = 0;
				tblRegSW.SetWidths(new int[] { 2, 4 });

				tblRegSW.AddCell(new Phrase("Nombre del software: ", bodyFont));
				tblRegSW.AddCell(miEvaluacion.Informacion.Nombre);
				tblRegSW.AddCell(new Phrase("Desarrollador(es): "));
				for (int i = 0; i < miEvaluacion.Informacion.Desarrollador.Length; i++)
				{
					tblRegSW.AddCell(miEvaluacion.Informacion.Desarrollador[i]);
				}
				tblRegSW.AddCell(new Phrase("Manual de usuario: ", bodyFont));
				tblRegSW.AddCell(miEvaluacion.Informacion.Manual);
				tblRegSW.AddCell(new Phrase("Descripcìón del software: "));
				tblRegSW.AddCell(miEvaluacion.Informacion.Descripcion);

				doc.Add(tblRegSW);

				// RESULTADOS DE LA EVALUACIÓN
				doc.Add(new Paragraph("Resultados de la evaluación", subTitleFont));
				doc.Add(new Paragraph("\n"));

				PdfPTable tblCalidadCaracteristicaInt = new PdfPTable(4);
				tblCalidadCaracteristicaInt.SpacingBefore = 4;
				tblCalidadCaracteristicaInt.SpacingAfter = 10;
				tblCalidadCaracteristicaInt.DefaultCell.Border = 0;
				tblCalidadCaracteristicaInt.SetWidths(new int[] { 2, 2, 2, 2 });

				//TABLA CARACTERÍSTICAS INTERNAS
				doc.Add(new Paragraph("Nivel de calidad características interna", FontFactory.GetFont("Arial", 14, Font.BOLD)));
				doc.Add(new Paragraph("\n"));
				tblCalidadCaracteristicaInt.AddCell(new Phrase("Característica", boldTableFont));
				tblCalidadCaracteristicaInt.AddCell(new Phrase("Grado de importancia", boldTableFont));
				tblCalidadCaracteristicaInt.AddCell(new Phrase("Resultado", boldTableFont));
				tblCalidadCaracteristicaInt.AddCell(new Phrase("Etiqueta", boldTableFont));

				/******************** COMPLETAR *******************/
				//AGREGAR DATOS A LA TABLA
				for (int i = 0; i < 3; i++)
				{
					tblCalidadCaracteristicaInt.AddCell("Funcionalidad");
					tblCalidadCaracteristicaInt.AddCell("0.6");
					tblCalidadCaracteristicaInt.AddCell("60%");
					tblCalidadCaracteristicaInt.AddCell("buena");
				}

				doc.Add(tblCalidadCaracteristicaInt);


				/******************** COMPLETAR *******************/
				//TABLA CARACTERÍSTICAS EXTERNAS
				PdfPTable tblCalidadCaracteristicaExt = new PdfPTable(4);
				tblCalidadCaracteristicaExt.SpacingBefore = 4;
				tblCalidadCaracteristicaExt.SpacingAfter = 10;
				tblCalidadCaracteristicaExt.DefaultCell.Border = 0;
				tblCalidadCaracteristicaExt.SetWidths(new int[] { 2, 2, 2, 2 });

				doc.Add(new Paragraph("Nivel de calidad características externa", FontFactory.GetFont("Arial", 14, Font.BOLD)));
				doc.Add(new Paragraph("\n"));

				tblCalidadCaracteristicaExt.AddCell(new Phrase("Característica", boldTableFont));
				tblCalidadCaracteristicaExt.AddCell(new Phrase("Grado de importancia", boldTableFont));
				tblCalidadCaracteristicaExt.AddCell(new Phrase("Resultado", boldTableFont));
				tblCalidadCaracteristicaExt.AddCell(new Phrase("Etiqueta", boldTableFont));


				/******************** COMPLETAR *******************/
				//AGREGAR DATOS A LA TABLA
				for (int i = 0; i < 3; i++)
				{
					tblCalidadCaracteristicaExt.AddCell("Funcionalidad"); //Característica
					tblCalidadCaracteristicaExt.AddCell("0.6"); //Grado de importancia
					tblCalidadCaracteristicaExt.AddCell("60%"); //Resultado
					tblCalidadCaracteristicaExt.AddCell("buena"); //Etiqueta
				}

				doc.Add(tblCalidadCaracteristicaExt);


				//TABLA CALIDAD FINAL SOFTWARE
				PdfPTable tblCalidadFinal = new PdfPTable(3);
				tblCalidadFinal.SpacingBefore = 4;
				tblCalidadFinal.SpacingAfter = 10;
				tblCalidadFinal.DefaultCell.Border = 0;
				tblCalidadFinal.SetWidths(new int[] { 2, 2, 2 });

				doc.Add(new Paragraph("Nivel de calidad del software", FontFactory.GetFont("Arial", 14, Font.BOLD)));
				doc.Add(new Paragraph("\n"));

				tblCalidadFinal.AddCell(new Phrase("Atributo", boldTableFont));
				tblCalidadFinal.AddCell(new Phrase("Resultado", boldTableFont));
				tblCalidadFinal.AddCell(new Phrase("Etiqueta", boldTableFont));


				/******************** COMPLETAR *******************/
				//AGREGAR DATOS A LA TABLA
				for (int i = 0; i < 3; i++)
				{
					tblCalidadFinal.AddCell("Funcionalidad"); //Característica
					tblCalidadFinal.AddCell("60%"); //Resultado
					tblCalidadFinal.AddCell("buena"); //Etiqueta
				}

				doc.Add(tblCalidadFinal);

				//CAMPO DE OBSERVACIONES
				doc.Add(new Phrase("Objetivo de la evaluación", subTitleFont));
				string objetivo = confPDF[3];
				doc.Add(new Paragraph(objetivo));
				doc.Add(Chunk.NEWLINE);

				doc.Add(new Phrase("Observaciones", subTitleFont));
				string observaciones = confPDF[4];
				doc.Add(new Paragraph(observaciones));

				//FECHA DE LA EVALUACIÓN
				doc.Add(new Phrase("Fecha de la evaluación", subTitleFont));
				doc.Add(Chunk.NEWLINE);
				doc.Add(new Phrase(confPDF[5]));

				doc.Close();
				writer.Close();


			} catch (DocumentException de)
			{
				throw de;
			} catch (IOException ioe)
			{
				throw ioe;
      }
		}
	}
}
