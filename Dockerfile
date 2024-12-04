# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем все файлы проекта в контейнер
COPY . .

# Восстанавливаем зависимости проекта
RUN dotnet restore WebAppbotbeer.sln

# Строим проект (публикуем)
RUN dotnet publish WebAppbotbeer.sln -c Release -o /app/publish

# Используем более легкий образ для запуска (используем только runtime, а не SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Устанавливаем рабочую директорию для запуска
WORKDIR /app

# Копируем результат сборки из контейнера "build"
COPY --from=build /app/publish .

# Указываем команду для старта приложения
ENTRYPOINT ["dotnet", "WebAppbotbeer.dll"]
