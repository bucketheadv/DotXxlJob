artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

mkdir -p $artifactsFolder

dotnet restore ./DotXxlJob.sln
dotnet build ./DotXxlJob.sln -c Release

dotnet pack ./src/DotXxlJob.Core/DotXxlJob.Core.csproj -c Release -o $artifactsFolder
dotnet new install $artifactsFolder/DotXxlJob.Core.*.nupkg

rm -rf ~/.nuget/packages/dotxxljob.core/2.3.4
# 在 Rider 的 NuGet 中，选择 Sources -> Feeds -> New feed + -> 加入本地包路径即可引用