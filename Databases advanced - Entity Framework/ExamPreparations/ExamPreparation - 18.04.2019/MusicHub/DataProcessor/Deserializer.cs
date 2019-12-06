namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            List<ImportWriterDto> writersDtos = JsonConvert.DeserializeObject<List<ImportWriterDto>>(jsonString);

            List<Writer> writers = new List<Writer>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in writersDtos)
            {
                if (IsValid(dto))
                {
                    Writer writer = new Writer()
                    {
                        Name = dto.Name,
                        Pseudonym = dto.Pseudonym
                    };

                    writers.Add(writer);
                    sb.AppendLine($"Imported {writer.Name}");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(Object obj)
        {
            ValidationContext validator = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResults, true);

            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            List<ImportProducerAndAlbumDto> Dtos = JsonConvert.DeserializeObject<List<ImportProducerAndAlbumDto>>(jsonString);

            List<Producer> producers = new List<Producer>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in Dtos)
            {
                bool isValidAlbums = IsValidAlbums(dto.Albums);

                if (IsValid(dto) && isValidAlbums)
                {
                    List<Album> albums = new List<Album>();

                    foreach (var albumDto in dto.Albums)
                    {
                        Album album = new Album()
                        {
                            Name = albumDto.Name,
                            ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        };

                        albums.Add(album);
                    }

                    Producer producer = new Producer()
                    {
                        Name = dto.Name,
                        Pseudonym = dto.Pseudonym,
                        PhoneNumber = dto.PhoneNumber,
                        Albums = albums
                    };

                    producers.Add(producer);

                    if (dto.PhoneNumber != null)
                    {
                        sb.AppendLine($"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count} albums");
                    }
                    else
                    {
                        sb.AppendLine($"Imported {producer.Name} with no phone number produces {producer.Albums.Count} albums");
                    }
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValidAlbums(ICollection<ImportAlbumDto> albums)
        {
            bool isValid = true;

            foreach (var album in albums)
            {
                if (IsValid(album) == false)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]),
                new XmlRootAttribute("Songs"));

            ImportSongDto[] songsDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                songsDtos = (ImportSongDto[])xmlSerializer.Deserialize(reader);
            }

            List<Song> songs = new List<Song>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in songsDtos)
            {
                bool isExistAlbumId = context.Albums.Any(x => x.Id == dto.AlbumId);
                bool isExistWriterId = context.Writers.Any(x => x.Id == dto.WriterId);
                bool isValidGenre = Enum.TryParse(typeof(Genre), dto.Genre, out object genre);

                if (IsValid(dto) && isExistAlbumId && isExistWriterId && isValidGenre)
                {
                    Song song = new Song()
                    {
                        Name = dto.Name,
                        Duration = TimeSpan.ParseExact(dto.Duration.ToString(), "c", CultureInfo.InvariantCulture),
                        Genre = (Genre)genre,
                        CreatedOn = DateTime.ParseExact(dto.CreatedOn.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        AlbumId = dto.AlbumId,
                        WriterId = dto.WriterId,
                        Price = dto.Price
                    };

                    songs.Add(song);

                    sb.AppendLine($"Imported {song.Name} ({song.Genre} genre) with duration {song.Duration}");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]),
                new XmlRootAttribute("Performers"));

            ImportPerformerDto[] performersDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                performersDtos = (ImportPerformerDto[])xmlSerializer.Deserialize(reader);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var dto in performersDtos)
            {
                if (IsValid(dto) && IsExistsSongsIds(dto.PerformersSongs, context))
                {


                    Performer performer = new Performer()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Age = dto.Age,
                        NetWorth = dto.NetWorth
                    };

                    context.Performers.Add(performer);


                    foreach (var performerSongDto in dto.PerformersSongs)
                    {
                        SongPerformer songPerformer = new SongPerformer()
                        {
                            PerformerId = performer.Id,
                            SongId = performerSongDto.SongId
                        };

                        context.SongsPerformers.Add(songPerformer);
                        performer.PerformerSongs.Add(songPerformer);
                    }

                    context.Performers.Add(performer);

                    sb.AppendLine($"Imported {dto.FirstName} ({performer.PerformerSongs.Count} songs)");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsExistsSongsIds(ImportPerformerSongDto[] performersSongs, MusicHubDbContext context)
        {
            bool isExists = true;

            foreach (var songDto in performersSongs)
            {
                if (context.Songs.Any(x => x.Id == songDto.SongId) == false)
                {
                    isExists = false;
                    break;
                }
            }

            return isExists;
        }
    }
}