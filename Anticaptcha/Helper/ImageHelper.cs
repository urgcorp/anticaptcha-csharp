using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Anticaptcha.Helper
{
    /// <summary>
    /// Оптимизирован для файлов небоьлшого размера
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Максимальный поддерживаемый сервисом размер изображениий в байтах
        /// </summary>
        public const long AnticaptchaMaxBytes = 500_000;

        public static string ImageStreamToBase64String(MemoryStream stream, long maxSizeInBytes = AnticaptchaMaxBytes)
        {
            if (stream == null || stream.Length == 0)
                return null;

            ThrowIfSizeExceededException(stream.Length, maxSizeInBytes);

            return Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length);
        }

        public static string ImageStreamToBase64String(Stream stream, long maxSizeInBytes = AnticaptchaMaxBytes)
        {
            if (stream == null || !stream.CanRead)
                return null;

            if (stream.CanSeek)
            {
                ThrowIfSizeExceededException(stream.Length, maxSizeInBytes);
                stream.Position = 0;
            }

            // Create with initial capacity
            using var memoryStream = new MemoryStream(stream.CanSeek ? (int)stream.Length : 1024);

            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (memoryStream.Length + bytesRead > maxSizeInBytes)
                    ThrowIfSizeExceededException(memoryStream.Length + bytesRead, maxSizeInBytes);

                memoryStream.Write(buffer, 0, bytesRead);
            }

            return ImageStreamToBase64String(memoryStream);
        }

        public static async Task<string> ImageStreamToBase64StringAsync(Stream stream, long maxSizeInBytes = AnticaptchaMaxBytes,
            CancellationToken cancellationToken = default)
        {
            if (stream == null || !stream.CanRead)
                return null;

            if (stream.CanSeek)
            {
                ThrowIfSizeExceededException(stream.Length, maxSizeInBytes);
                stream.Position = 0;
            }

            // Create with initial capacity
            using var memoryStream = new MemoryStream(stream.CanSeek ? (int)stream.Length : 1024);

            // Копируем поток по частям, проверяя размер в процессе (важно для сетевых потоков)
            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0)
            {
                if (memoryStream.Length + bytesRead > maxSizeInBytes)
                    ThrowIfSizeExceededException(memoryStream.Length + bytesRead, maxSizeInBytes);
        
                await memoryStream.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
            }

            if (memoryStream.Length == 0)
                return null;

            // Используем асинхронное копирование для сетевых потоков
            await stream.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
    
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string ImageFileToBase64String(string path, long maxSizeInBytes = AnticaptchaMaxBytes)
        {
            if (!File.Exists(path))
                return null;

            var fileInfo = new FileInfo(path);
            ThrowIfSizeExceededException(fileInfo.Length, maxSizeInBytes);

            if (fileInfo.Length == 0)
                return null;

            try
            {
                var imageBytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(imageBytes);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> ImageFileToBase64StringAsync(string path, long maxSizeInBytes = AnticaptchaMaxBytes,
            CancellationToken ct = default)
        {
            if (!File.Exists(path))
                return null;

            var fileInfo = new FileInfo(path);
            ThrowIfSizeExceededException(fileInfo.Length, maxSizeInBytes);

            if (fileInfo.Length == 0)
                return null;

            try
            {
                var imageBytes = await File.ReadAllBytesAsync(path, ct).ConfigureAwait(false);
                return Convert.ToBase64String(imageBytes);
            }
            catch
            {
                return null;
            }
        }

        private static void ThrowIfSizeExceededException(long size, long maxSize)
        {
            if (size > maxSize)
                throw new InvalidOperationException($"Size of stream ({size} bytes) exceeded limit of {maxSize} bytes.");
        }
    }
}