Для запуска проекта необъодимо создать Таблицу следующим скриптом:

CREATE TABLE [dbo].[WeatherInfo](
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
Далее необходимо вписать свои параметры в файл appsettings.json, а именно: 
connectionString для БД, 
apiKey для яндекс.Погоды, 
интервал обновления погоды в миллисекундах,
Населенный пункт (Moscow, Kazan, Sochi)