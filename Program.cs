using Octokit;
using System.Diagnostics;
using System.Net;

#pragma warning disable SYSLIB0014 // Type or member is obsolete
WebClient webClient = new();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
string latest = (new GitHubClient(new ProductHeaderValue("LatestRelease")).Repository.Release.GetLatest("BeamMP", "BeamMP-Server").Result.HtmlUrl + "/BeamMP-Server.exe").Replace("tag", "download");
string curdir = Environment.CurrentDirectory + "\\";
string serverexe = curdir + "BeamMP-Server.exe";

if (File.Exists(serverexe))
{
    Console.WriteLine(serverexe + " already exists, deleting...");
    File.Delete(serverexe);
    Console.WriteLine("Downloading the newest version of BeamMP-Server.");
    webClient.DownloadFile(latest, serverexe);
    Console.WriteLine("Starting BeamMP-Server.");
    _ = Process.Start(serverexe);
}
else
{
    Console.WriteLine("BeamMP-Server.exe doesn't exist.\n Downloading the newest version of BeamMP-Server.");
    webClient.DownloadFile(latest, serverexe);
    Console.WriteLine("Starting BeamMP-Server.");
    _ = Process.Start(serverexe);
}

Environment.Exit(0);