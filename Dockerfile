FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ARG BUILDCONFIG=RELEASE


COPY TweetBook.csproj/build/

RUN dotnet restore ./build/TweetBook.csproj

COPY ../build/
WORKDIR /build/
RUN dotnet publish ./TweetBook.csproj -c $BUILDCONFIG -o out 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 -aspnetcore -runtime
WORKDIR /app

COPY --from = build /build/out

ENTRYPOINT["dotnet","TweetBook.dll"]
