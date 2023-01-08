FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ARG USER_NAME=build
ENV user_name=$USER_NAME
ARG PAT
ENV pat=$PAT
COPY NuGet.config /root/.nuget/NuGet/
WORKDIR /app
COPY . ./
WORKDIR /app
#RUN dotnet restore 
RUN dotnet publish "Domain/src/Worker/Worker.csproj" -c Release -o out
 
FROM grupoxp.azurecr.io/baseimages:alpine-net6.0-2.8.0 AS runtime
WORKDIR /app
ENV \
  LC_ALL=pt_BR.UTF-8 \
  LANG=pt_BR.UTF-8 \
  TZ=Etc/UTC
RUN apk add --no-cache icu-libs
RUN apk update && apk del gcc && apk add --update tzdata
RUN addgroup -S app && adduser -S app -G app
USER app
COPY --from=build-env /app/out .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT ["dotnet", "Worker.dll"]