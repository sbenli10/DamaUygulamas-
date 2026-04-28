# DamaUygulaması

ASP.NET MVC ile geliştirilmiş web tabanlı iki kişilik Dama (Checkers) oyunudur. Oyuncular sırayla hamle yaparak dama kurallarına uygun şekilde rakibini alt etmeye çalışır.

## Özellikler
- 8x8 dama tahtası üzerinde interaktif oyun
- Kullanıcı oturumu yönetimi
- Hamle geçmişi kaydı
- Vezir (dama) dönüşüm kuralları
- Zorunlu yeme kuralı desteği
- Veritabanı ile oyun durumunun saklanması (Entity Framework ile)

## Kurulum

### Gereksinimler
- Visual Studio 2019 veya üzeri
- .NET Framework 4.8.1
- SQL Server (LocalDB destekleniyor)
- NuGet paketleri otomatik olarak yüklenir

### Adımlar
1. `DamaUygulaması.sln` dosyasını Visual Studio ile açın.
2. Gerekirse NuGet üzerinden eksik paketleri yükleyin (`Tools > NuGet Package Manager > Restore NuGet Packages`).
3. `Update-Database` komutu ile veritabanını oluşturun (Package Manager Console üzerinden).
4. Projeyi `IIS Express` ile çalıştırın (F5).

## Proje Yapısı

- **Controllers/** – Oyun ve kullanıcı yönetimi denetleyicileri
- **Models/** – Oyun tahtası, kullanıcı ve hamle geçmişi sınıfları
- **Views/** – Razor tabanlı kullanıcı arayüzleri
- **Migrations/** – EF Code First geçişleri
- **App_Start/** – ASP.NET yapılandırma dosyaları (Route, Filter, Bundle)

Hazırlayan: Said Benli
Tarih: 2025

