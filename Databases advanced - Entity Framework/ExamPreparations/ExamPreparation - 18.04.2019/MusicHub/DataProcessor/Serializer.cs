namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            List<ExportAlbumDto> albumsDtos = context.Albums
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x => x.Price)
                .Select(x => new ExportAlbumDto()
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    AlbumPrice = x.Songs.Sum(p => p.Price).ToString("F2"),

                    Songs = x.Songs.Select(s => new ExportCustomSongDto()
                    {
                        SongName = s.Name,
                        Writer = s.Writer.Name,
                        Price = s.Price.ToString("F2")
                    })
                    .OrderByDescending(sn => sn.SongName)
                    .ThenBy(sw => sw.Writer)
                    .ToList()

                })
                .ToList();

            string jsonString = JsonConvert.SerializeObject(albumsDtos, Formatting.Indented);

            return jsonString;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            List<ExportSongDto> songsDtos = context.Songs
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongDto()
                {
                    Name = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers
                    .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                    .FirstOrDefault(),
                    Duration = x.Duration.ToString("c"),
                    AlbumProducer = x.Album.Producer.Name
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToList();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportSongDto>),
                new XmlRootAttribute("Songs"));

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, songsDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}