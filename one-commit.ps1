# Usuwa całą historię i zostawia tylko jeden commit z podaną wiadomością.
# Uruchom w katalogu repozytorium (devops-project-public).

$msgTitle = "Initial commit: API z katalogiem produktów i prognozą pogody."
$msgBody = @"
- ASP.NET Core 9 (Minimal API)
- Endpointy: /, /products, /weatherforecast
- Testy integracyjne (xUnit), Dockerfile, pipeline Azure DevOps
"@

git checkout --orphan temp-branch
git add -A
git commit -m $msgTitle -m $msgBody
git branch -D main 2>$null
git branch -m main

Write-Host "Gotowe. Masz teraz tylko jeden commit (main)." -ForegroundColor Green
