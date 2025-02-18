# ContributorsMap

Application which generates a map of contributors to a GitHub repository.

This was created primary for .NET Foundation projects, but can be used for any GitHub repository.
I test this only on .NET runtime repository yet. No ASP.NET Core, SDK, WinForms, WPF, MAUI, yet.

## A bit about methodology behind this

I take all commits between two release using `git log --pretty=format:"%aN|%ae" v6.0.0..v7.0.0` command.
This gives me stream of pair author and email which represent single commit. 
I then apply mailmap rules to these list of contributors to clean data and normalize contributors.
Building of mailmap was semiautomatic, I verify each entry and then add it to mailmap file.

Then I mark all emails with public mail hosting company as `no company`. No-reply emails from GitHub I also count as associtated with persons without company.
Some emails from well known companies like Ximian, Xamarin, Novell people from then I consider to be Microsoft employees now.
Also some well known figures like Newton-King, roji, vcsjones also counted as contributions from Microsoft. If you think this is need refinement, I'm ready to improve counting.

And then it gives me following picture for .NET runtime repository.

## Start per company commits in .NET 9 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 3660| 53.38%|
|no company | 2612| 38.10%|
|emclient.com | 111| 1.62%|
|loongson.cn | 62| 0.90%|
|luminance.org | 59| 0.86%|
|samsung.com | 52| 0.76%|
|neptuo.com | 51| 0.74%|
|arm.com | 40| 0.58%|
|hompus.nl | 22| 0.32%|
|redhat.com | 16| 0.23%|
|google.com | 14| 0.20%|
|apebox.org | 14| 0.20%|
|vp.pl | 13| 0.19%|
|unity3d.com | 11| 0.16%|
|cincura.net | 10| 0.15%|
|intel.com | 9| 0.13%|
|hubse.com | 9| 0.13%|
|rozsival.com | 8| 0.12%|
|criteo.com | 5| 0.07%|
|asu.edu | 5| 0.07%|
|tsirpanis.gr | 5| 0.07%|
|abv.bg | 5| 0.07%|

## Start per company commits in .NET 8 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 5655| 57.11%|
|no company | 3323| 33.56%|
|unity3d.com | 297| 3.00%|
|luminance.org | 108| 1.09%|
|samsung.com | 56| 0.57%|
|neptuo.com | 56| 0.57%|
|emclient.com | 46| 0.46%|
|loongson.cn | 42| 0.42%|
|dotnet-maestro | 40| 0.40%|
|rozsival.com | 29| 0.29%|
|apebox.org | 25| 0.25%|
|intel.com | 24| 0.24%|
|google.com | 21| 0.21%|
|gnome.org | 19| 0.19%|
|cincura.net | 13| 0.13%|
|arm.com | 13| 0.13%|
|yandex.ru | 12| 0.12%|
|tsirpanis.gr | 9| 0.09%|
|hompus.nl | 8| 0.08%|
|korporal.at | 7| 0.07%|
|ibm.com | 7| 0.07%|
|redhat.com | 6| 0.06%|
|centeredgesoftware.com | 5| 0.05%|
|thinkcode.pl | 5| 0.05%|
|hubse.com | 5| 0.05%|

## Start per company commits in .NET 7 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 4406| 60.97%|
|no company | 2411| 33.37%|
|tsirpanis.gr | 44| 0.61%|
|emclient.com | 34| 0.47%|
|neptuo.com | 30| 0.42%|
|rozsival.com | 30| 0.42%|
|ibm.com | 29| 0.40%|
|apebox.org | 26| 0.36%|
|loongson.cn | 22| 0.30%|
|samsung.com | 19| 0.26%|
|deeprobin.de | 15| 0.21%|
|luminance.org | 14| 0.19%|
|dunnhq.com | 12| 0.17%|
|redhat.com | 10| 0.14%|
|intel.com | 7| 0.10%|
|unity3d.com | 6| 0.08%|
|ayakael.net | 5| 0.07%|
|korporal.at | 5| 0.07%|
|joniaromaa.fi | 5| 0.07%|