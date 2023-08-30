using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Windows_10_Activator_CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Process oluşturuyoruz.
            Process cmdProcess = new Process();
            cmdProcess.StartInfo = psi;
            cmdProcess.OutputDataReceived += CmdOutputDataReceived;

            // Cmd'yi başlatıyoruz.
            cmdProcess.Start();

            // Gerekirse cmd'ye otomatik olarak girişler yapmak için aşağıdaki satırları kullanabilirsiniz.
            // Örnek olarak "dir" komutunu ve ardından "exit" komutunu gönderiyoruz.
            Thread.Sleep(2000);
            cmdProcess.StandardInput.WriteLine("slmgr /ipk NW6C2-QMPVW-D7KKK-3GKT6-VCFB2");
            Thread.Sleep(3000);
            cmdProcess.StandardInput.WriteLine("slmgr /skms kms8.msguide.com");
            Thread.Sleep(3000);
            cmdProcess.StandardInput.WriteLine("slmgr /ato");
            Thread.Sleep(2000);

            cmdProcess.StandardInput.WriteLine("exit");

            // Cmd çıkışını bekliyoruz.
            cmdProcess.WaitForExit();

            // Process kapatıyoruz.
            cmdProcess.Close();
        }

        // Cmd'den gelen çıktıları almak için bu metodu kullanıyoruz.
        private static void CmdOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
}
