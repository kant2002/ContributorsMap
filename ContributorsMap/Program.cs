using Medallion.Shell;
using System.Text.RegularExpressions;

if (args.Length == 0)
{
    Console.WriteLine("Usage: <runtime-path>");
    return;
}

Dictionary<string, int> firstPartyDomains = new Dictionary<string, int>()
{
    // Well known company domains.
    { "arm.com", 10 },
    { "acm.org", 10 },
    { "github.com", 10 },
    { "gnome.org", 10 },
    { "google.com", 10 },
    { "us.ibm.com", 10 },
    { "linux.ibm.com", 10 },
    { "linux.vnet.ibm.com", 10 },
    { "intel.com", 10 },
    { "microsoft.com", 10 },
    { "micrsoft.com", 10 },
    { "ntdev.microsoft.com", 10 },
    { "microsoftonline.com", 10 },
    { "novell.com", 10 },
    { "redhat.com", 10 },
    { "samsung.com", 10 },
    { "samasung.com", 10 },
    { "smasung.com", 10 },
    { "partner.samsung.com", 10 },
    { "samsung.ru", 10 },
    { "stackoverflow.com", 10 },
    { "xamarin.com", 10 },
    { "ximian.com", 10 },
    { "mono-cvs.ximian.com", 10 },
    { "vmware.com", 10 },
    { "windows.com", 10 },
    { "dataart.com", 10 },
    { "jetbrains.com", 10 },
    { "unity3d.com", 10 },
    { "yandex.ua", 10 },
    { "yandex.ru", 10 },
    { "pulumi.com", 10 },
    { "emclient.com", 10 },
    { "loongson.cn", 10 },
    { "codeweavers.com", 10 },
    { "datadoghq.com", 10 },
    { "criteo.com", 10 },
    { "gmx.com", 10 },
    { "pacificbiosciences.com", 10 },
    { "platform.uno", 10 },

    { "uwaterloo.ca", 10 },
    { "cornell.edu", 10 },
    { "student.umass.edu", 10 },

    // Global OSS
    { "gentoo.org", 8 },
    { "gnu.org", 8 },
    { "users.sourceforge.net", 8 },

    // Personal websites
    { "lambdageek.org", 7 },
    { "lander.ca", 7 },
    { "tsirpanis.gr", 7 },
    { "me.com", 7 },
    { "filippov.me", 7 },
    { "evain.net", 7 },
    { "landwerth.net", 7 },
    
    // Public email domains
    { "outlook.com", 5 },
    { "hotmail.com", 5 },
    { "hotmail.se", 5 },
    { "hotmail.co.uk", 5 },
    { "live.com", 5 },
    { "live.com.au", 5 },
    { "gmail.com", 5 },
    { "gmal.com", 5 }, // Typo
    { "googlemail.com", 5 },
    { "yahoo.com", 5 },
    { "yahoo.fr", 5 },
    { "mail.ru", 5 },
    { "fastmail.com", 5 },   
    { "comcast.net", 5 },
    { "protonmail.com", 5 },
    { "pobox.com", 5 },
    { "post.cz", 5 },
    { "qq.com", 5 },
    { "icloud.com", 5 },

    // no reply
    { "users.noreply.github.com", 2 },
    { "guest.corp.microsoft.com", 2 },
};

var runtimePath = args[0];
//var command = await Command.Run("git.exe", ["-C", runtimePath, "--no-pager", "shortlog", "-sne"]).Task;
var symbolicLink = runtimePath + ".mailmap";
var fileName = Path.GetFullPath("mailmap");
var mailMap = ParseMailMap(fileName);

try
{
    var command = await Command.Run("git.exe", ["-C", runtimePath, "log", "--mailmap", "--pretty=format:%aN|%ae", "v8.0.0..v9.0.0"]).Task;
    var lines = command.StandardOutput.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries).ToList();
    lines = lines.Select(_ => mailMap.TryGetValue(_, out var result) ? result : _).ToList();
    //Console.WriteLine($"Total count of commits {lines.Count}");
    //foreach (var (domain, count) in GetStats(lines).Select(_ => (_.name, _.domain)).Distinct().GroupBy(_ => _.domain).Select(_ => (_.Key, _.Count())).OrderByDescending(_ => _.Item2))
    //{
    //    Console.WriteLine($"{domain} {count}");
    //} 
    // Console.WriteLine("===================================");
    //PrintStatsPerPersonCommits(lines);
    //Console.WriteLine("===================================");
    PrintStatsPerCompanyCommits(lines);
    //Console.WriteLine("===================================");
    //PrintSameNames(lines);
    //PrintSameEmails(lines);
}
finally
{
    //File.Delete(symbolicLink);
}

string DomainToCompany(string domain)
{
    if (firstPartyDomains.TryGetValue(domain, out var score))
    {
        if (score < 6) return "no company";
    }

    if (domain == "mono-cvs.ximian.com") return "microsoft.com";
    if (domain == "ximian.com") return "microsoft.com";
    if (domain == "novell.com") return "microsoft.com";
    if (domain.EndsWith("microsoft.com")) return "microsoft.com";
    if (domain == "xamarin.com") return "microsoft.com";
    if (domain.EndsWith("ibm.com")) return "ibm.com";
    if (domain.EndsWith("samsung.com")) return "samsung.com";
    if (domain.EndsWith("vcsjones.com")) return "microsoft.com";   
    if (domain.EndsWith("newtonking.com")) return "microsoft.com";
    if (domain.EndsWith("roji.org")) return "microsoft.com";
    if (domain == "me.com") return "no company";

    return domain;
}
void PrintStatsPerCompanyCommits(List<string> lines)
{
    Console.WriteLine("Start per company commits");
    Console.WriteLine("| Company | Count | Percentage | ");
    Console.WriteLine("| ------- | ----: | ---------: |");
    var includeWithoutCompanies = true;
    var stats = GetStats(lines).Where(_ => includeWithoutCompanies || _.domain != "no company").ToList();
    var totalCount = stats.Sum(_ => _.count);
    foreach (var (domain, count) in stats.GroupBy(_ => _.domain).Select(_ => (_.Key, _.Sum(_ => _.count))).OrderByDescending(_ => _.Item2))
    {
        Console.WriteLine($"|{domain} | {count}| {(double)count/ totalCount:P}|");
    }
}
void PrintStatsPerPersonCommits(List<string> lines)
{
    Console.WriteLine("Start per person commits");
    Console.WriteLine("Name Company Count");
    foreach (var (name, domain, count) in GetStats(lines).OrderByDescending(_ => _.count))
    {
        Console.WriteLine($"{name} {domain} {count}");
    }
}

IEnumerable<(string name, string domain, int count)> GetStats(List<string> lines)
{
    foreach (var s in lines.Order().GroupBy(_ => _))
    {
        var parts = s.Key.Split('|');
        var email = parts[1];
        var (name, domain) = (parts[0], email.Split('@').LastOrDefault());
        yield return (name, DomainToCompany(domain?.ToLower() ?? email), s.Count());
    }
}

void PrintSameNames(List<string> lines)
{
    var sameName = lines.Select(NormalizeEmail)
        .Distinct()
        .Select(_ => _.Split("|")[0]).GroupBy(_ => _)
        .Where(_ => _.Count() > 1)
        .Select(_ => _.Key)
        .ToList();
    foreach (var s in sameName.Order())
    {
        var dupliates = lines.Where(_ => _.StartsWith(s + "|"))
            .Distinct()
            .Select(_ =>
            {
                var (name, score) = ScoreName(_);
                return (_, score, name);
            })
            .OrderByDescending(_ => _.Item2)
            //.Where(_ => _.Item2 > 0)
            .Select(_ => _.Item1).ToList();
        if (dupliates.Count < 2) continue;
        //if (dupliates.All(_ => ScoreName(_).score < 10)) continue;
        if (ScoreName(dupliates[1]).score == 10) continue;

        for (var i = 1; i < dupliates.Count; i++)
        {
            var canonical = dupliates[0].Split('|');
            var replacement = dupliates[i].Split('|');
            Console.WriteLine($"{canonical[0]} <{canonical[1]}> <{replacement[1]}>");
        }
    }
}

// Unity
// Alexandre Mutel <alexandre_mutel@live.com> <alexandre_mutel@yahoo.fr>

// Unknown
// N <71219152+SleepyDweams@users.noreply.github.com> <71219152+PokeCodec@users.noreply.github.com>
// Stefan <Tornhoof@users.noreply.github.com> <29021710+Saalvage@users.noreply.github.com>
// Alex <cod7alex@gmail.com> <alexbruceharley@gmail.com>
// Ilya <darpa@yandex.ru> <ilya.babentsov@gmail.com>

string NormalizeEmail(string nameAndEmail)
{
    var parts = nameAndEmail.Split("|");
    var name = parts[0];
    var email = parts[1];
    return $"{name}|{email.ToLowerInvariant()}";
}

(string name, int score) ScoreName(string nameAndEmail)
{
    var parts = nameAndEmail.Split("|");
    var name = parts[0];
    var email = parts[1];
    var emailParts = email.Split("@");
    if (emailParts.Length == 1) return (name, -1);
    var domain = emailParts[1].ToLower();
    if (domain.EndsWith("guest.corp.microsoft.com")) return (name, 1);
    if (domain.EndsWith(".compute.internal")) return (name, 1);
    if (domain.EndsWith(".local")) return (name, 1);
    if (domain.EndsWith(".name")) return (name, 7);
    if (firstPartyDomains.TryGetValue(emailParts[1], out var score))
    {
        return (name, score);
    }

    if (firstPartyDomains.TryGetValue(domain, out score))
    {
        return (name, score - 1);
    }
    return (name, 0);
}

Dictionary<string, string> ParseMailMap(string file)
{
    Dictionary<string, string> result = new(StringComparer.OrdinalIgnoreCase);
    foreach (var line in File.ReadAllLines(file))
    {
        if (line.StartsWith("#") || line == "")
            continue;

        var parts = line.Split(" ");
        if (parts.Length < 3)
            continue;

        var match = Regex.Match(line, @"(.*) <(.*)> ((.*) )?<(.*)>");
        if (match.Groups.Count < 3)
            continue;

        var canonicalMap = new MailMap { Name = match.Groups[1].Value, Email = match.Groups[2].Value };
        var map = match.Groups[3].Success
            ? new MailMap { Name = match.Groups[4].Value, Email = match.Groups[5].Value }
            : new MailMap { Name = match.Groups[1].Value, Email = match.Groups[5].Value };

        result.Add($"{map.Name}|{map.Email}", $"{canonicalMap.Name}|{canonicalMap.Email}");
    }
    return result;
}

static void PrintSameEmails(List<string> lines)
{
    var sameEmail = lines.Distinct().Select(_ => _.Split("|")[1]).GroupBy(_ => _).Where(_ => _.Count() > 1).Select(_ => _.Key).ToList();
    foreach (var s in sameEmail.Order())
    {
        var dupliates = lines.Where(_ => _.EndsWith("|" + s))
            .Distinct()
            .ToList();
        if (dupliates.Count < 2) continue;

        for (var i = 1; i < dupliates.Count; i++)
        {
            var canonical = dupliates[0].Split('|');
            var replacement = dupliates[i].Split('|');
            Console.WriteLine($"{canonical[0]} <{canonical[1]}> {replacement[0]} <{replacement[1]}>");
        }
        //Console.WriteLine(s.TrimEnd() + " " + string.Join(" ", dupliates));
    }
}

class MailMap
{
    public string Name { get; set; }
    public string Email { get; set; }
}