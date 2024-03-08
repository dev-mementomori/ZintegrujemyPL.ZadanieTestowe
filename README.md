# ZintegrujemyPL.ZadanieTestowe

Zbuduj cały projekt.
Zainstaluj i skonfiguruj serwer SQL - zalecana wersja: SqlServer2016.
Skonfiguruj plik appsettings.json. Ważne! Jeśli chcesz, aby pliki migracyjne były zapisane na dysku C, musisz uruchomić aplikację jako administrator.
Migracje:

Nowe migracje - Podczas uruchomienia projektu migracje są automatycznie wykonywane.


Cofanie migracji - migracje można cofnąć za pomocą polecenia:
dotnet fm rollback -p [server-version] --connection="Server=[server];Database=[database];User Id=[username];Password=[password];TrustServerCertificate=True" --assembly="[assembly-path]"
Ważne ! Nie można cofnąć migracji dopóki nie zbudujesz projektu, ponieważ do tego wymagany jest assembly ZintegrujemyPL.ZadanieTestowe.Infrastructure.dll

W moim przypadku [assembly-path] wygląda następująco:
C:\Users\Filip Kisielelwicz\source\repos\ZintegrujemyPL.ZadanieTestowe\ZintegrujemyPL.Infrastructure\bin\Debug\net6.0\ZintegrujemyPL.ZadanieTestowe.Infrastructure.dll


IntegrationService:
Task Integrate() - Rozpoczyna proces integracji.
Task DownloadAndStoreFiles() - Pobiera i zapisuje pliki do integracji.
Task ProcessData() - jest odpowiedzialy za przetwarzanie danych. Wywołuje metody do pobierania danych, usuwania starych danych i wstawiania nowych danych.
Task DeleteOldAllData() - jest odpowiedzialy za usuwanie starych danych ze wszystkich repozytoriów.
Task GetInventoriesShippedWithin24h() - jest odpowiedzialny za pobieranie listy inventories, które są wysłane w ciągu ostatnich 24 godzin.
Task GetProductsShippedWithin24h() - jest odpowiedzialny za pobieranie listy produktów, które są wysłane w ciągu ostatnich 24 godzin i nie są kablami, na podstawie listy inventories.
Task InsertNewData() - jest odpowiedzialy za wstawianie nowych danych do odpowiednich repozytoriów.


IntegrationSettingsValidator:
Metoda Validate() - Sprawdza plik konfiguracyjny appsettings dla modelu IntegrationSettings.

IntegrationDescValidator:
Metoda Validate() - Sprawdza plik konfiguracyjny appsettings dla modelu IntegrationDesc.

CsvConfigurationProvider:
Metoda GetConfiguration() - Zwraca konfigurację CSV dla pliku, który jest później wykorzystywany w wybranym serwisie, który jest odpowiedzialny za odczytywanie danych z plików CSV.

CsvMapperService:
Metoda Configure(CsvContext csvContext) - Pozwala na rejestrowanie mapperów dla serwisów odpowiedzialnych za odczytywanie danych z plików CSV.

FileWriterService:
Task WriteDataToFile(string data, string filePath) - Zapisuje dane tekstowe do pliku. Tworzy go, a jeśli istnieje, to zastępuje stary plik nowym plikiem.

DownloadService:
Task<string> DownloadText(string url) - Zwraca tekst odczytany z linku.

ProductsController:
Task GetProductInformation(string sku [wymagany]) Służy do pobierania informacji o produkcie na podstawie jego numeru SKU. 
Jeśli produkt nie istnieje w bazie danych zwraca NotFound.
Przykład: sku=0001-00000-23406
Zwraca:{
  "name": "Ścianka końcowa pomarańczowa 282-387",
  "ean": "4017332264907",
  "producerName": "WAGO",
  "category": "Osprzęt łączeniowy|Osprzęt łączeniowy/Złączki|Osprzęt łączeniowy/Złączki/Ścianki końcowe / przegrody do złączek szynowych",
  "defaultImageURL": "https://www.tim.pl/media/catalog/product/cache/1/image/1360x768/6c6569c07c2c92c72927f48425bdbd88/S/c/Scianka-koncowa-pomaranczowa-282-387-0001_00000_23406_2_m.jpg",
  "quantityInStock": 19,
  "unit": "szt.",
  "nettProductPriceAfterDiscountForProductLogisticUnit": 3.21,
  "shippingCost": 21.14
}



Odpowiedzi na pytania (jeśli takie przyjdą komuś do głowy)
Dlaczego usuwam produkty, ceny oraz zapasy z bazy danych w trakcie procesu integracji? To zależy od potrzeb. Kiedyś robiłem coś podobnego i usuwanie danych było wskazane.
Oczywiście można było np. aktualizować rekordy albo usuwać te, które nie istnieją w pliku, lub dodawać tylko te, które nie istnieją w bazie danych.
Dlaczego nie zapisywałem wszystkich kolumn danych w bazie danych? Nie ma sensu przechowywać informacji, które nie są obecnie używane, chyba że istnieje potrzeba ich wykorzystania w przyszłości.

Biblioteki użyte:
.NET 7 - Framework projektu.
Dapper - Został wykorzystany w repozytorium.
Microsoft.Data.SqlClient - Został wykorzystany w repozytorium.
System.Data - Został wykorzystany w repozytorium.
FluentMigrator - Został wykorzystany do tworzenia migracji.
System.Linq - Został wykorzystany do działań zapytań na kolekcjach.
AutoMapper - Został wykorzystany do mapowania danych.
CsvHelper - Został wykorzystany do odczytu pliku CSV.
