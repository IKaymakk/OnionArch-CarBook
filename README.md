OnionArch-CarBook, .NET Web API ile geliştirilen, katmanlı mimari prensiplerine uygun bir araç kayıt ve yönetim sistemidir. Proje, sürdürülebilir, test edilebilir ve geliştirilebilir bir yazılım altyapısı sunmayı hedefler.
Gelişmiş filtreleme ile çok sayıda araç çeşitli şekilde incelenebilir, kiralanabilir.

Daha Detaylı İnceleme İçin : https://ikaymak.com.tr/MyProjects/ProjectDetails/4

📌 Proje Amacı
Bu proje, araçlara dair temel işlemlerin (kayıt, listeleme, güncelleme, silme) yapılabildiği, temiz bir yazılım mimarisi ile hazırlanmış bir örnek uygulamadır. Eğitim ve kurumsal projelerde temel iskelet olarak kullanılabilir.

 Katmanlar ve Yapı
Domain Katmanı:
Uygulamanın iş kuralları ve temel modelleri burada yer alır. Hiçbir dış bağımlılık içermez.

Application Katmanı:
Uygulama senaryolarının işlendiği katmandır. Servis arayüzleri ve işlemler bu katmanda toplanır.

Infrastructure Katmanı:
Veritabanı bağlantıları, repository implementasyonları ve veri erişim işlemleri bu katmanda yer alır.

API (Sunum) Katmanı:
Uygulamanın dış dünyaya açıldığı katmandır. Web API endpoint’leri bu katmanda tanımlanır.

Frontend:
Temel arayüz işlemleri jQuery ile sağlanmıştır. API ile etkileşimli şekilde çalışır.

🛠️ Kullanılan Teknolojiler
ASP.NET Core Web API

Entity Framework Core

MSSQL Server

jQuery

Onion Architecture

Repository & Unit of Work Pattern
