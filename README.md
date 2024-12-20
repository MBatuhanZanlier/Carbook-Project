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


