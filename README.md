## Ön Yazı 
Merhaba,  
Bu projem bir araç kiralama web projesidir.  
Kullanıcılar, istedikleri lokasyona göre uygun araçları listeleyebilir ve seçtikleri araçlar için ön kayıt oluşturarak kiralama işlemlerini gerçekleştirebilirler.

Projem, ASP.NET Core 8.0 Web API ve MVC teknolojilerini kullanarak geliştirilmiştir. Tüm CRUD işlemleri API üzerinden gerçekleştirilmekte ve bu işlemler MVC tarafında consume edilmektedir. Dinamik veritabanı yönetimi için Entity Framework Core'un Code First yaklaşımı tercih edilmiştir.
Projede, yazılımın modülerliğini ve sürdürülebilirliğini artırmak amacıyla Onion Architecture mimarisi benimsenmiş ve CQRS, Mediator ile Repository Design Patterns kullanılarak yapılandırılmıştır. Bu sayede, uygulama hem esnek hem de bakımı kolay bir hale getirilmiştir.  

Bu projede kullanılan  tasarım desenleri hakkında sizleride kafanızı çok karıştırmayacak şekilde bilgilendirmek istiyorum.
##  Mimari nedir?
Yazılım geliştirme, karmaşık ve dinamik bir süreçtir. Özellikle büyük ölçekli projelerde, yazılımın işleyişi ve sürdürülebilirliği açısından sağlam bir temel oluşturmak kritik önem taşır. İşte bu noktada yazılım mimarisi (architectural) devreye girer. Yazılım mimarisi, bir yazılım sisteminin temel yapısını ve bileşenler arasındaki ilişkileri tanımlar. Bu, yalnızca yazılımın başlangıcında değil, geliştirilmesi ve bakımı sürecinde de önemli bir rol oynar. 

1. Karmaşıklığı Yönetmek
2. Değişim ve Gelişmeye Uyum Sağlamak
3. İletişimi Kolaylaştırmak
4. Performansı ve Ölçeklenebilirliği Artırmak
5. Maliyet ve Zaman Tasarrufu

## Tasarım Deseni Nedir?  

Tasarım desenleri, yazılım tasarımında sıklıkla karşılaşılan sorunlara yönelik tipik çözümlerdir. Kodunuzdaki tekrar eden bir tasarım sorununu çözmek için özelleştirebileceğiniz önceden hazırlanmış planlar gibidirler.

Sadece bir desen bulup onu programınıza kopyalayamazsınız, hazır fonksiyonlar veya kütüphanelerle yapabileceğiniz gibi. Desen belirli bir kod parçası değil, belirli bir problemi çözmek için genel bir kavramdır. Desen ayrıntılarını takip edebilir ve kendi programınızın gerçeklerine uyan bir çözüm uygulayabilirsiniz.

Desenler sıklıkla algoritmalarla karıştırılır, çünkü her iki kavram da bilinen bazı problemlere yönelik tipik çözümleri tanımlar. Bir algoritma her zaman bir hedefe ulaşabilecek net bir eylem kümesi tanımlarken, bir desen bir çözümün daha üst düzey bir tanımıdır. Aynı desenin iki farklı programa uygulanan kodu farklı olabilir.

Bir algoritmanın benzetmesi bir yemek tarifidir: her ikisinin de bir hedefe ulaşmak için net adımları vardır. Öte yandan, bir desen daha çok bir taslak gibidir: sonucun ve özelliklerinin ne olduğunu görebilirsiniz, ancak uygulamanın tam sırası size kalmıştır. 

## Tasarım Deseni ile Mimari arasında fark nelerdir? 
Aklınızı çok da karıştırmak istemiyorum, aslında konuyu şöyle özetleyecek olursam: Mimari, yapacağınız bir projenin iskeletini oluşturur. Tasarım deseni ise bu iskeletin üzerine, belirli bir sorunu çözmek için uygulayacağınız yapı taşlarını yerleştirir. Yani, mimari genel yapıyı ve temel yönelimleri belirlerken, tasarım desenleri bu yapıyı nasıl daha verimli, sürdürülebilir ve esnek hale getirebileceğinizi gösteren pratik çözümler sunar. Bir nevi mimari, büyük resmi çizerken, tasarım desenleri bu resmin içindeki detayları doğru şekilde yerleştirmenize yardımcı olur. 

| **Özellik**             | **Mimari**                                              | **Tasarım Deseni**                                  |
|-------------------------|---------------------------------------------------------|-----------------------------------------------------|
| **Seviye**              | Yüksek seviye, sistemin genel yapısı                    | Düşük seviye, belirli problemleri çözmek için uygulanan çözümler |
| **Kapsam**              | Sistemin tüm yapısı ve bileşenleri                      | Belirli bir problem veya fonksiyon üzerine odaklanır |
| **Zaman Çerçevesi**     | Uzun vadeli, sistemin geleceği göz önünde bulundurulur | Kısa vadeli, anlık problemlere çözüm üretir         |
| **Esneklik**            | Soyut, geniş yapılar                                    | Spesifik, uygulamaya yönelik çözümler              |
| **Amaç**                | Yapıyı tanımlar                                         | Belirli bir problemi çözer                          |
| **Değişiklikler**       | Yapısal değişiklikler tüm sistemi etkiler               | Lokal değişiklikler genellikle küçük modifikasyonlarla yapılabilir | 


## Onion Architecture  
Bu projede Onion mimarası kullanıldığı için sizlere onion mimarasi hakkında bilgi vermek istedim. 

Onion Architecture, katmanlı bir yapı sunar ve bu yapı genellikle dört ana katmandan oluşur. Her katman, uygulamanın belirli bir sorumluluğunu taşır ve bir katmanın başka bir katmandan bağımlılığı bir yönlüdür (iç katmanlar dış katmanlardan bağımsızdır). Temel olarak, daha içteki katmanlar dış katmanlara bağımlıdır ancak tam tersi bir durum yoktur.

1. Core (Çekirdek) Katmanı:
İç Katman: Uygulamanın en temel iş mantığını barındırır. Burada iş kuralları, domain modelleri (entities), veri yapıları ve servisler yer alır.
- Bağımsızlık: Bu katman, dış katmanlardan bağımsızdır ve tüm diğer katmanlar bu katmana bağımlıdır.
- Amaç: İş mantığının dışarıdan etkilenmeden çalışabilmesi sağlanır.
2. Domain Services Katmanı:
- İç Katman: Çekirdek katmanı genişletir. Domain'e özel servisler, iş kuralları ve uygulama mantığı burada bulunur.
- Bağımsızlık: Bu katman, dış katmanlardan bağımsız olup sadece çekirdek katmanına bağımlıdır.
3. Application Services Katmanı:
- Dış Katman: Uygulamanın işlevselliğini sağlar. Veritabanı erişimi, kullanıcı etkileşimleri, dış API'ler gibi işlemler bu katmanda bulunur.
- Bağımlılık: Uygulama servisi, çekirdek katmandan (domain modelinden) ve domain servislerinden faydalanır.
- Amaç: Kullanıcı etkileşimleri ve dış veri kaynakları ile uygulama iş mantığı arasındaki köprü görevini görür.
4. Infrastructure Katmanı:
- Dış Katman: Veri erişimi, dış servislere entegrasyon, dosya işlemleri gibi dış sistemlerle ilişkili işlevler burada bulunur.
- Bağımlılık: Bu katman, uygulamanın geri kalan kısmına (özellikle domain katmanlarına) bağımlıdır ve yalnızca gerekli olduğunda dış kaynaklardan veri alır ya da dışa veri gönderir.

## CQRS Desing Patern  (Command Query Responsibility Segregation)

CQRS, temel olarak komut (command) ve sorgu (query) işlemlerini birbirinden ayıran bir yaklaşımı ifade eder. Bu desenin amacı, veri okuma (query) ve veri yazma (command) işlemlerini farklı modellerde ele alarak her birini daha verimli bir şekilde yönetmektir.

Command (Komut): Veritabanı üzerinde değişiklik yapmak, veriyi eklemek, güncellemek veya silmek için kullanılan işlemleri temsil eder. 
- Yeni bir veri eklemek ya da var olan veri üzerinde güncelleme yapmak için kullanılır. Örnek vermek gerekirse; Insert, Update, Delete. Geriye veri döndürmez.

Query (Sorgu): Veritabanından veri okumak, sorgulamak ve görüntülemek için kullanılan işlemleri temsil eder.
Veritabanından veri almak için kullanılır. Geriye sadece belirtilen modeli döner ve veri üzerinde herhangi bir değişiklik yapmaz. Oluşturacağımız Query’lerimiz genellikle ‘Get’ ön eki ile isimlendirilir.

## Mediator Desing Patern
Mediatorü kullanmak için, MediatR kütüphanesini projemize eklememiz gerekmektedir. 
Mediator ile CQRS in arasındaki farkı daha iyi anlamak için  Presentation katmanındaki CarsController,Banners,Abouts(CQRS kullanılmıştır)  diğer controllerle karşılaştırarak bakabilirsiniz. 
Mediator'ü gerçek hayatda bir örnek verebilirsek bu örnekteki gibi olacaktır,
Havaalanı kontrol alanına yaklaşan veya oradan ayrılan uçakların pilotları birbirleriyle doğrudan iletişim kurmazlar. Bunun yerine, pistin yakınında bir yerdeki yüksek bir kulede oturan bir hava trafik kontrolörüyle konuşurlar. Hava trafik kontrolörü olmadan, pilotların havaalanının yakınındaki her uçağın farkında olması ve düzinelerce pilottan oluşan bir komiteyle iniş önceliklerini görüşmesi gerekirdi. Bu muhtemelen uçak kazası istatistiklerini fırlatırdı.

Kulenin tüm uçuşu kontrol etmesi gerekmez. Sadece terminal alanındaki kısıtlamaları uygulamak için vardır çünkü orada bulunan aktörlerin sayısı bir pilot için bunaltıcı olabilir.        

## Özetle (Mimari ve Tasarım kalıplarının önemini açıklamak istedim)
Elimden geldiğince sizlere Mimariyi ve tasarım kalıpların ne olduğunu anlatmaya çalıştım. Dahada iyi akılda kalması için şu senaryoyu size anlatmak istiyorum. 
Şimdi sizlere Mimarinin ve tasarım kalıbını önemini anlatacağım. 
Dünyada genelde bazı meslekler tarafından kullanılan bir alfabe ve ortak bir global bir yapı var. Yurt dışına gidildiğinde veya sizlerin projelerine yabancı bir insan geldiğinde veya  başka bir firmaya geçtiğinizde yada çalışma arkadaşınızla mimari ve desing paternsiz bir yapı kullandığınızı düşünün aşağ yukarı nelerin yanlış gideceğini  tahmin edebiliyorsunuzdur.Herkes kafasına göre bir yapı ve klasörlendirme yapacaktır proje  ve iş katmanları karışacak ve projenin yönetimi zorlaşmaya başlıyacaktır. Diyelim ki Onion Architecture ve Mediatör Desing paterini bilmediğinizi varsayalım  internetdeki kaynaklardan  öğrenme süreniz alışma süreniz çok sürmiyecektir.  
Mimari ve Tasarım kalıplarının önemini açıklamak istedim.

## Projede Kullanılan Teknolojiler 
1. ASP.NET Core 8.0 🚀
2. ASP.NET Web API 🔌
3. MSSQL (Microsoft SQL Server) 🗄️
4. Entity Framework Core (Code First) 🔄
5. JSON Web Token (JWT) 🔐
6. FluentValidation 🛠️
7. SignalR

## Öne Çıkan Özellikler
- Uygun lokasyona göre müsait araçları listeleme ve kiralama
- Araçların detaylarını görüntüleme
- Araçlara özellik atama
- MSSQL ilişkili tablolar
- Admin Panel
- SignalR ile canlı veri takibi
- Json Web Token ile Identity güvenliği
