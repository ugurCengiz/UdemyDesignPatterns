using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Command.Commands
{
    public class PdfFile<T>
    {
        public readonly List<T> _List;
        public readonly HttpContext _Context;
        public string FileName => $"{typeof(T).Name}.pdf";
        public string FileType => "application/octet-stream";

        public PdfFile(List<T> list, HttpContext context)
        {
            _List = list;
            _Context = context;
        }

        public MemoryStream Create()
        {
            var type = typeof(T);

            var sb = new StringBuilder();

            sb.Append($@"<html>
                        <head></head>
                        <body>
                        <div class='text-center'><h1></h1>{type.Name} tablo </div>
                        <table class='table table-striped'align='center'>");

            sb.Append("<tr>");
            type.GetProperties().ToList().ForEach(x =>
            {
                sb.Append($"<th>{x.Name}</th>");
            });
            sb.Append("</tr>");

            _List.ForEach(x =>
            {
                var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToList();

                sb.Append("<tr>");
                
                values.ForEach(values =>
                {
                    sb.Append($"<td>{values}</td>");
                });

                sb.Append("</tr>");


            });

            sb.Append("</table></body></html>");

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = sb.ToString() ,
                        WebSettings = { DefaultEncoding = "utf-8",UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(),"www.root/lib/bootstrap/dist/css/bootstrap.css")},
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            var converter = _Context.RequestServices.GetRequiredService<IConverter>();

             return new(converter.Convert(doc));
             
        }


    }
}
