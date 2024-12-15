## BlogSite Project

# About the Project

The BlogSite project is a blogging platform developed using C# and .NET. It follows a layered architecture to separate concerns and improve maintainability. The project provides functionalities such as user management, creating, editing, and deleting posts, and adding comments. It also implements JWT for authentication, global exception handling, and asynchronous operations to ensure scalability.

#Features

Layered Architecture: The project is structured with distinct layers (Controllers, Services, Repositories, etc.) for maintainability and scalability.
CRUD Operations: Users can perform Create, Read, Update, and Delete operations on blog posts and comments.
JWT Authentication: Secure authentication via JSON Web Tokens.
Validation: Data validation is applied using FluentValidation for input consistency and integrity.
Global Exception Handling: A middleware is used to handle exceptions globally.
DTO Usage: Data Transfer Objects (DTOs) are employed to separate internal data structures from API responses.
Asynchronous Operations: All endpoints are asynchronous to enhance performance and scalability.
NUnit Tests: Unit tests are implemented with NUnit to ensure that the business logic works as expected.

#Technologies Used

Language: C#
Framework: .NET
ORM: Entity Framework Core
Authentication: JWT
Validation: FluentValidation
Testing: NUnit
Middleware: Global exception handling


## BlogSite Projesi

# Proje Hakkında

BlogSite projesi, C# ve .NET kullanarak geliştirilmiş bir blog platformudur. Proje, katmanlı mimariyi takip ederek, yönetilebilirliği ve sürdürülebilirliği artırmak için ayrı katmanlar halinde tasarlanmıştır. Kullanıcı yönetimi, yazı oluşturma, düzenleme ve silme, yorum ekleme gibi işlevleri sunar. Ayrıca, JWT ile kimlik doğrulama, global exception handling (hata yönetimi) ve asenkron işlemler ile ölçeklenebilirlik sağlanmıştır.

# Özellikler

Katmanlı Mimari: Proje, yönetilebilirlik ve sürdürülebilirlik için farklı katmanlar (Controller, Service, Repository vb.) kullanılarak yapılandırılmıştır.
CRUD Operasyonları: Kullanıcılar, blog yazıları ve yorumlar üzerinde Ekleme, Okuma, Güncelleme ve Silme işlemleri yapabilirler.
JWT Kimlik Doğrulama: JSON Web Token ile güvenli kimlik doğrulama sağlanmıştır.
Validasyon: Verilerin doğruluğunu sağlamak için FluentValidation kullanılarak doğrulama kuralları uygulanmıştır.
Global Exception Handling (Hata Yönetimi): Middleware kullanılarak uygulama genelinde hata yönetimi yapılmıştır.
DTO Kullanımı: İç veri yapılarının dışarıya aktarılmasını ayırmak için DTO (Data Transfer Object) yapıları kullanılmıştır.
Asenkron İşlemler: Tüm endpoint’ler asenkron olarak tasarlanmıştır, böylece performans ve ölçeklenebilirlik artırılmıştır.
NUnit Testleri: İş mantığının doğru çalıştığından emin olmak için NUnit ile unit testler yazılmıştır.

# Kullanılan Teknolojiler

Dil: C#
Framework: .NET
ORM: Entity Framework Core
Kimlik Doğrulama: JWT
Validasyon: FluentValidation
Test: NUnit
Middleware: Global exception handling
