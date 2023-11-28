## Запуск проекта
Для запуска проекта необходимо выполнить следующие действия:

### Файлы проекта
Необходимо создать файлы appsettings.json и nums.txt в папке с исполняемым файлом программы

### Настройка параметров
После создания таблицы необходимо внести параметры в файл appsettings.json. Параметры, которые требуется внести:
- connectionString для настройки соединения с базой данных.
- apiKey для идентификации с Яндекс Погода.
- updateInterval для установки интервала обновления погоды в миллисекундах.
- location для указания населенного пункта (Moscow, Kazan, Sochi) в котором будет осуществляться сбор информации о погоде.

### Создание таблицы
Необходимо создать таблицу в базе данных с использованием следующего скрипта SQL (Вместо WeatherInfo вписать название БД):

```sql
CREATE TABLE [WeatherInfo](
    [Location] [varchar](50) NULL,
    [Temp] [int] NULL,
    [FeelsLike] [int] NULL,
    [Condition] [varchar](50) NULL,
    [WindSpeed] [int] NULL,
    [WindGust] [int] NULL,
    [Humidity] [varchar](50) NULL,
    [PressureMm] [int] NULL,
    [PressurePa] [int] NULL,
    [PrecType] [int] NULL
);



