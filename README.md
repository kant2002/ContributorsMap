# ContributorsMap

Application which generates a map of contributors to a GitHub repository.

This was created primary for .NET Foundation projects, but can be used for any GitHub repository.
I test this only on .NET runtime repository yet. No ASP.NET Core, SDK, WinForms, WPF, MAUI, yet.

## A bit about methodology behind this

I take all commits between two release using `git log --pretty=format:"%aN|%ae" v6.0.0..v7.0.0` command.
This gives me stream of pair author and email which represent single commit. 
I then apply mailmap rules to these list of contributors to clean data and normalize contributors.
Building of [mailmap](ContributorsMap/mailmap) was semiautomatic, I verify each entry and then add it to mailmap file.

Then I mark all emails with public mail hosting company as `no company`. No-reply emails from GitHub I also count as associtated with persons without company.
Some emails from well known companies like Ximian, Xamarin, Novell people from then I consider to be Microsoft employees now.
Also some well known figures like Newton-King, roji, vcsjones also counted as contributions from Microsoft. If you think this is need refinement, I'm ready to improve counting.

And then it gives me following picture for .NET runtime repository. I have another data which I consider measure of comapanies control. After next three tables, you will see description and data.

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

## Start per company commits in FSharp 12 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|no company | 2059| 80.59%|
|microsoft.com | 299| 11.70%|
|jetbrains.com | 70| 2.74%|
|xs4all.nl | 38| 1.49%|
|msu-solutions.de | 29| 1.14%|
|usa.net | 10| 0.39%|
|tsirpanis.gr | 10| 0.39%|
|yandex.ru | 7| 0.27%|
|efbnet.com | 6| 0.23%|

## Start per company commits in Rust in 2024 year releases

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|personal | 9275| 28.05%|
|rust-lang.org | 5552| 16.79%|
|famsik.de | 3627| 10.97%|
|no company | 2875| 8.69%|
|errs.io | 1526| 4.61%|
|ralfj.de | 1336| 4.04%|
|oli-obk.de | 615| 1.86%|
|huawei.com | 613| 1.85%|
|fmease.dev | 368| 1.11%|
|kuber.com.ar | 360| 1.09%|
|onurozkan.dev | 335| 1.01%|
|videotron.ca | 270| 0.82%|
|cron.bot | 270| 0.82%|
|dend.ro | 267| 0.81%|
|lcnr.de | 251| 0.76%|
|numericable.fr | 229| 0.69%|
|notriddle.com | 200| 0.60%|
|chrisdenton.dev | 199| 0.60%|
|philkrones.com | 169| 0.51%|
|umich.edu | 161| 0.49%|
|google.com | 150| 0.45%|
|pm.me | 143| 0.43%|
|redhat.com | 138| 0.42%|
|jhpratt.dev | 119| 0.36%|
|weihanglo.tw | 98| 0.30%|
|code.berlin | 96| 0.29%|
|zoho.com | 95| 0.29%|
|amazon.com | 93| 0.28%|
|microsoft.com | 92| 0.28%|
|hill-daniel.co.uk | 92| 0.28%|
|macleod.io | 91| 0.28%|
|ferrous-systems.com | 91| 0.28%|
|ya.ru | 87| 0.26%|
| | 82| 0.25%|
|dianqk.net | 80| 0.24%|
|marquart.dk | 79| 0.24%|
|folkertdev.nl | 77| 0.23%|
|vsb.cz | 68| 0.21%|
|apache.org | 68| 0.21%|
|m-ou.se | 66| 0.20%|
|huss.org | 65| 0.20%|
|codetale.se | 64| 0.19%|
|alexcrichton.com | 62| 0.19%|
|infinite-source.de | 62| 0.19%|
|quoi.xyz | 58| 0.18%|
|reitermark.us | 58| 0.18%|
|rfc1149.net | 56| 0.17%|
|beetr.ee | 54| 0.16%|
|davidsemakula.com | 53| 0.16%|
|envs.net | 47| 0.14%|
|foxmail.com | 45| 0.14%|
|meta.com | 44| 0.13%|
|dfirebird.dev | 43| 0.13%|
|e64.io | 43| 0.13%|
|davidbarsky.com | 42| 0.13%|
|garyguo.net | 42| 0.13%|
|alona.page | 37| 0.11%|
|proton.me | 35| 0.11%|
|switchb.org | 33| 0.10%|
|ibm.com | 30| 0.09%|
|posteo | 28| 0.08%|
|protonmail.ch | 26| 0.08%|
|snu.ac.kr | 26| 0.08%|
|geekhood.net | 26| 0.08%|
|arm.com | 25| 0.08%|
|chromium.org | 25| 0.08%|
|partiallytyped.dev | 25| 0.08%|
|xobs.io | 25| 0.08%|
|grayolson.com | 23| 0.07%|
|jyn.dev | 23| 0.07%|
|it.uu.se | 22| 0.07%|
|ocamlpro.com | 22| 0.07%|
|riseup.net | 22| 0.07%|
|cabrajac.com | 22| 0.07%|
|xiretza.xyz | 22| 0.07%|
|tasking.com | 21| 0.06%|
|boxyuwu.dev | 20| 0.06%|
|joshtriplett.org | 20| 0.06%|
|kernel.org | 20| 0.06%|
|loongson.cn | 20| 0.06%|
|pietroalbini.org | 18| 0.05%|
|uc.cl | 18| 0.05%|
|kylehuey.com | 17| 0.05%|
|fb.com | 16| 0.05%|
|bitcrafters.co | 16| 0.05%|
|ltdk.xyz | 16| 0.05%|
|hoverbear.org | 15| 0.05%|
|ethan.ws | 15| 0.05%|
|weiznich.de | 15| 0.05%|
|eonerc.rwth-aachen.de | 15| 0.05%|
|ieee.org | 15| 0.05%|
|alibaba-inc.com | 15| 0.05%|
|ethz.ch | 14| 0.04%|
|achernar.io | 13| 0.04%|
|wrenn.fyi | 13| 0.04%|
|muybridge.com | 13| 0.04%|
|fortanix.com | 13| 0.04%|
|agg.im | 12| 0.04%|
|pnkfx.org | 12| 0.04%|
|yahoo.co.jp | 12| 0.04%|
|anticentri.st | 11| 0.03%|
|ardis.dev | 11| 0.03%|
|moeli.us | 11| 0.03%|
|gmx.de | 10| 0.03%|
|cbspeir.dev | 10| 0.03%|
|sedlak.dev | 10| 0.03%|
|tweedegolf.com | 10| 0.03%|
|adacore.com | 10| 0.03%|
|github.com | 10| 0.03%|
|bitfieldconsulting.com | 10| 0.03%|

## Company control

I think that if we exclude contributors without company from the data, then we will have picture of the companies who directly invest in the .NET development.
That give us much more bleak picture.

# Companies contributions for .NET 9 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 3660| 86.24%|
|emclient.com | 111| 2.62%|
|loongson.cn | 62| 1.46%|
|luminance.org | 59| 1.39%|
|samsung.com | 52| 1.23%|
|neptuo.com | 51| 1.20%|
|arm.com | 40| 0.94%|
|hompus.nl | 22| 0.52%|
|redhat.com | 16| 0.38%|
|google.com | 14| 0.33%|
|apebox.org | 14| 0.33%|
|vp.pl | 13| 0.31%|
|unity3d.com | 11| 0.26%|
|cincura.net | 10| 0.24%|
|intel.com | 9| 0.21%|
|hubse.com | 9| 0.21%|
|rozsival.com | 8| 0.19%|
|criteo.com | 5| 0.12%|
|asu.edu | 5| 0.12%|
|tsirpanis.gr | 5| 0.12%|
|abv.bg | 5| 0.12%|

# Companies contributions for .NET 8 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 5655| 85.96%|
|unity3d.com | 297| 4.51%|
|luminance.org | 108| 1.64%|
|samsung.com | 56| 0.85%|
|neptuo.com | 56| 0.85%|
|emclient.com | 46| 0.70%|
|loongson.cn | 42| 0.64%|
|dotnet-maestro | 40| 0.61%|
|rozsival.com | 29| 0.44%|
|apebox.org | 25| 0.38%|
|intel.com | 24| 0.36%|
|google.com | 21| 0.32%|
|gnome.org | 19| 0.29%|
|cincura.net | 13| 0.20%|
|arm.com | 13| 0.20%|
|yandex.ru | 12| 0.18%|
|tsirpanis.gr | 9| 0.14%|
|hompus.nl | 8| 0.12%|
|korporal.at | 7| 0.11%|
|ibm.com | 7| 0.11%|
|redhat.com | 6| 0.09%|
|centeredgesoftware.com | 5| 0.08%|
|thinkcode.pl | 5| 0.08%|
|hubse.com | 5| 0.08%|

# Companies contributions for .NET 7 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 4406| 91.51%|
|tsirpanis.gr | 44| 0.91%|
|emclient.com | 34| 0.71%|
|neptuo.com | 30| 0.62%|
|rozsival.com | 30| 0.62%|
|ibm.com | 29| 0.60%|
|apebox.org | 26| 0.54%|
|loongson.cn | 22| 0.46%|
|samsung.com | 19| 0.39%|
|deeprobin.de | 15| 0.31%|
|luminance.org | 14| 0.29%|
|dunnhq.com | 12| 0.25%|
|redhat.com | 10| 0.21%|
|intel.com | 7| 0.15%|
|unity3d.com | 6| 0.12%|
|ayakael.net | 5| 0.10%|
|korporal.at | 5| 0.10%|
|joniaromaa.fi | 5| 0.10%|

## Companies contributions for FSharp 12 release

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|microsoft.com | 299| 60.28%|
|jetbrains.com | 70| 14.11%|
|xs4all.nl | 38| 7.66%|
|msu-solutions.de | 29| 5.85%|
|usa.net | 10| 2.02%|
|tsirpanis.gr | 10| 2.02%|
|yandex.ru | 7| 1.41%|
|efbnet.com | 6| 1.21%|

## Companies contributions for Rust in 2024 releases

| Company | Count | Percentage |
| ------- | ----: | ---------: |
|rust-lang.org | 5552| 26.54%|
|famsik.de | 3627| 17.34%|
|errs.io | 1526| 7.30%|
|ralfj.de | 1336| 6.39%|
|oli-obk.de | 615| 2.94%|
|huawei.com | 613| 2.93%|
|fmease.dev | 368| 1.76%|
|kuber.com.ar | 360| 1.72%|
|onurozkan.dev | 335| 1.60%|
|videotron.ca | 270| 1.29%|
|cron.bot | 270| 1.29%|
|dend.ro | 267| 1.28%|
|lcnr.de | 251| 1.20%|
|numericable.fr | 229| 1.09%|
|notriddle.com | 200| 0.96%|
|chrisdenton.dev | 199| 0.95%|
|philkrones.com | 169| 0.81%|
|umich.edu | 161| 0.77%|
|google.com | 150| 0.72%|
|pm.me | 143| 0.68%|
|redhat.com | 138| 0.66%|
|jhpratt.dev | 119| 0.57%|
|weihanglo.tw | 98| 0.47%|
|code.berlin | 96| 0.46%|
|zoho.com | 95| 0.45%|
|amazon.com | 93| 0.44%|
|microsoft.com | 92| 0.44%|
|hill-daniel.co.uk | 92| 0.44%|
|macleod.io | 91| 0.44%|
|ferrous-systems.com | 91| 0.44%|
|ya.ru | 87| 0.42%|
| | 82| 0.39%|
|dianqk.net | 80| 0.38%|
|marquart.dk | 79| 0.38%|
|folkertdev.nl | 77| 0.37%|
|vsb.cz | 68| 0.33%|
|apache.org | 68| 0.33%|
|m-ou.se | 66| 0.32%|
|huss.org | 65| 0.31%|
|codetale.se | 64| 0.31%|
|alexcrichton.com | 62| 0.30%|
|infinite-source.de | 62| 0.30%|
|quoi.xyz | 58| 0.28%|
|reitermark.us | 58| 0.28%|
|rfc1149.net | 56| 0.27%|
|beetr.ee | 54| 0.26%|
|davidsemakula.com | 53| 0.25%|
|envs.net | 47| 0.22%|
|foxmail.com | 45| 0.22%|
|meta.com | 44| 0.21%|
|dfirebird.dev | 43| 0.21%|
|e64.io | 43| 0.21%|
|davidbarsky.com | 42| 0.20%|
|garyguo.net | 42| 0.20%|
|alona.page | 37| 0.18%|
|proton.me | 35| 0.17%|
|switchb.org | 33| 0.16%|
|ibm.com | 30| 0.14%|
|posteo | 28| 0.13%|
|protonmail.ch | 26| 0.12%|
|snu.ac.kr | 26| 0.12%|
|geekhood.net | 26| 0.12%|
|arm.com | 25| 0.12%|
|chromium.org | 25| 0.12%|
|partiallytyped.dev | 25| 0.12%|
|xobs.io | 25| 0.12%|
|grayolson.com | 23| 0.11%|
|jyn.dev | 23| 0.11%|
|it.uu.se | 22| 0.11%|
|ocamlpro.com | 22| 0.11%|
|riseup.net | 22| 0.11%|
|cabrajac.com | 22| 0.11%|
|xiretza.xyz | 22| 0.11%|
|tasking.com | 21| 0.10%|
|boxyuwu.dev | 20| 0.10%|
|joshtriplett.org | 20| 0.10%|
|kernel.org | 20| 0.10%|
|loongson.cn | 20| 0.10%|