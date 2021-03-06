﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using LibraryServicesWeb_AP2.DAL;
using LibraryServicesWeb_AP2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Pages.Reportes
{
    public class ReporteUsuarios
    {
        int maxColumn = 6;
        Document document;
        PdfPTable pdfPTable = new PdfPTable(6);
        Font fontStyle;
        PdfPCell pdfPCell;
        Font fontFecha;
        MemoryStream memoryStream = new MemoryStream();
        List<Usuarios> lista = new List<Usuarios>();

        public byte[] Report(List<Usuarios> usuarios)
        {
            lista = usuarios;
            document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] sizes = new float[maxColumn];

            for (int i = 0; i < maxColumn; i++)
            {
                if (i == 0) sizes[i] = 50;
                else sizes[i] = 100;

            }

            pdfPTable.SetWidths(sizes);


            this.ReportHeader();
            this.ReportBody();

            pdfPTable.HeaderRows = 1;
            document.Add(pdfPTable);
            document.Close();

            return memoryStream.ToArray();


        }

        private void ReportHeader()
        {
            pdfPCell = new PdfPCell(this.AddLogo());
            pdfPCell.Colspan = 1;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(this.SetPageTitle());
            pdfPCell.Colspan = maxColumn - 1;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);


            pdfPTable.CompleteRow();

        }
        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            string imgCombine = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Images\logo.png"}";
            Image img = Image.GetInstance(imgCombine);

            pdfPCell = new PdfPCell(img);
            pdfPCell.Colspan = maxColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPTable.CompleteRow();

            return pdfPTable;

        }

        private PdfPTable SetPageTitle()
        {
            int maxcolumn = 2;
            PdfPTable pdfPTable = new PdfPTable(maxcolumn);

            fontFecha = FontFactory.GetFont("Calibri", 10f, 1);
            fontStyle = FontFactory.GetFont("Calibri", 18f, 1);

            pdfPCell = new PdfPCell(new Phrase("Library Services", fontStyle));
            pdfPCell.Colspan = maxColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPTable.CompleteRow();

            pdfPCell = new PdfPCell(new Phrase("Reporte Libros", fontStyle));
            pdfPCell.Colspan = maxColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPTable.CompleteRow();


            pdfPCell = new PdfPCell(new Phrase(DateTime.Now.ToString("MM/dd/yyyy H:mm tt"), fontFecha));
            pdfPCell.Colspan = maxColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPTable.CompleteRow();

            pdfPCell = new PdfPCell(new Phrase("", fontStyle));
            pdfPCell.Colspan = maxColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);


            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private void ReportBody()
        {
            fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            var _fontstyle = FontFactory.GetFont("Calibri", 9f, 0);

          
            pdfPCell = new PdfPCell(new Phrase("Id", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Nombres", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Celular", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Email", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Nombre de Usuario", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);



            pdfPCell = new PdfPCell(new Phrase("Fecha Insercion", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.Gray;
            pdfPTable.AddCell(pdfPCell);

            

            Contexto contexto = new Contexto();
            pdfPTable.CompleteRow();
            int acum = 0;
            foreach (var item in lista)
            {
                acum++;
                pdfPCell = new PdfPCell(new Phrase(item.UsuarioId.ToString(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(item.Nombres, fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(item.Celular, fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(item.Email, fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfPCell);

               
                pdfPCell = new PdfPCell(new Phrase(item.NombreUsuario, fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
              
                pdfPCell = new PdfPCell(new Phrase(item.FechaInsercion.ToString(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfPCell);

                pdfPTable.CompleteRow();

            }
            pdfPCell = new PdfPCell(new Phrase(acum++.ToString(), fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.White;
            pdfPCell.Border = 0;

            pdfPTable.AddCell(pdfPCell);

            pdfPTable.CompleteRow();



        }

    }
}
