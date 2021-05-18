param (
  [Parameter(Mandatory=$True)]
  [string] $GithubAccessToken,

  [Parameter(Mandatory=$True)]
  [string] $Version
)

# Only tag builds on the master branch and not pull requests.
if (($env:APPVEYOR_REPO_BRANCH -ne "master") -or (Test-Path env:\APPVEYOR_PULL_REQUEST_NUMBER))
{
    return
}

git config --global credential.helper store
Set-Content "$env:USERPROFILE\.git-credentials" "https://$($GithubAccessToken):x-oauth-basic@github.com`n"

git tag -a v$Version -m "Build v$Version"
git push --quiet --tags origin HEAD:master
