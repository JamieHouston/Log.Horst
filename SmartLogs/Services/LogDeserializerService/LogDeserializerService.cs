using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using SmartLogs.Model;

namespace SmartLogs.Services.LogDeserializerService
{
    public class LogDeserializerService
    {
        // the order of these matter, each parser will be processed sequentially
        private static readonly IMessageParser[] Parsers = { new ExceptionMessageParser(), new AppEventMessageParser()};
        public async Task<LogBase> DeserializeLineAsync(string line)
        {
            var matches = Regex.Matches(line, @"(?<=\[)(.*?)(?=\])");

            //Expected format [Level][Date][ThreadId][FileName,MethodName,LineNumber]([Group]:optional) - msg

            if (matches.Count < 4)
            {
                // log not in expected format
                return null;
            }

            if (matches.Count > 5)
            {
                // log not in expecte format
                return null;
            }

            var sum = 0;
            foreach (Match match in matches)
            {
                sum += (match.Length + 3);
            }

            var msg = line.Substring(Math.Min(sum + 2, line.Length));

            var metaData = new LogMetaData
            {
                Level = (LoggingLevel) Enum.Parse(typeof(LoggingLevel), matches[0].Value),
                DateTime = DateTime.Parse(matches[1].Value),
                ThreadId = int.Parse(matches[2].Value)
            };
            var methodInfo = matches[3].Value.Split(',');
            metaData.FileName = methodInfo[0].Trim(' ');
            metaData.MethodName = methodInfo[1].Trim(' ');
            metaData.LineNumber = int.Parse(methodInfo[2].Trim(' '));

            if (matches.Count >= 5)
            {
                metaData.Group = matches[4].Value;
            }

            foreach (var messageParser in Parsers)
            {
                if (await messageParser.TryParseMessage(metaData, msg, out var formattedLog))
                {
                    return formattedLog;
                }
            }

            return null;
        }

        public async Task<IEnumerable<LogBase>> ImportLogsFromFileAsync()
        {
            var picker =
                new Windows.Storage.Pickers.FileOpenPicker
                {
                    ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                    SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads
                };
            picker.FileTypeFilter.Add(".zip");

            var file = await picker.PickSingleFileAsync();
            var copied = await file.CopyAsync(ApplicationData.Current.LocalFolder);
            var tmpFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("tmp-logs", CreationCollisionOption.ReplaceExisting);
            await Task.Run(() => ZipFile.ExtractToDirectory(copied.Path, tmpFolder.Path));
            await copied.DeleteAsync();

            string allText = "";
            LogDeserializerService service = new LogDeserializerService();
            List<LogBase> logs = new List<LogBase>();
            foreach (var logFile in await tmpFolder.GetFilesAsync())
            {
                var text = File.ReadAllLines(logFile.Path);
                foreach (var line in text)
                {
                    var log = await service.DeserializeLineAsync(line);
                    if (log != null)
                    {
                        logs.Add(log);
                    }
                }
            }

            await tmpFolder.DeleteAsync();
            return logs;
        }
    }
}
