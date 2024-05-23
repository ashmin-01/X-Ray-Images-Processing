using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;

namespace Segment_Color_Mappin
{
    public static class VoiceCompressor
    {
        public static byte[] CompressVoice(string inputFilePath)
        {
            try
            {
                using (var reader = new WaveFileReader(inputFilePath))
                {
                    using (var writerStream = new MemoryStream())
                    {
                        using (var writer = new LameMP3FileWriter(writerStream, reader.WaveFormat, LAMEPreset.VBR_90))
                        {
                            reader.CopyTo(writer);
                        }
                        return writerStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing voice: {ex.Message}");
                return null;
            }
        }
    }
}
