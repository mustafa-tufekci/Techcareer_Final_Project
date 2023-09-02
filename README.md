# EventHub

## Veri Tabanı Diyagramı
![Veritabanı Yapısı](https://i.hizliresim.com/99xn77v.png)

Projenin amacı, organizatörlerin etkinlik oluşturabildiği ve katılımcıların bu etkinlikleri görüp başvurabildiği bir **online etkinlik yönetim sistemi** oluşturmaktır.  Bu sistem, son kullanıcılara mobil ve web ortamında çalışan farklı arayüz yazılımları ile sunulacaktır. Ayrıca bilet satışının olduğu etkinlikler için farklı online satış kanallarıyla, ilgili etkinliklerin paylaşılması gerekmektedir. Bu sistem üzerinden bir bilet satış işlemi yapılmayacaktır.

## Temel Fonksiyonlar

- Kullanıcılar üye olmadan sistemin işlevselliklerini kullanamazlar.
- Kullanıcılar sistem üzerinde etkinlik oluşturabilirler ve oluşturulan etkinliklere katılım sağlayabilirler.
- Kullanıcılar düzenlemek istedikleri etkinlikleri gerekli bilgileri girerek tanımlarlar.
- Kullanıcılar sistemde tanımlı etkinlikleri görebilirler ve istedikleri etkinliğe katılabilirler.
- Farklı online bilet satış firmaları sistem üzerinde tanımlı ve bilet satışının olduğu etkinliklere erişebilirler.
- Katılımcılar biletli bir etkinliğe katılmak istediklerinde sisteme entegre olmuş bilet satış firmaları arasından istediklerini seçip onların sitesine yönlendirilirler.
- Etkinlik kategorileri, şehirler gibi bilgileri admin kullanıcısı düzenler.

## Kullanım Senaryoları

### Üye Olma

Sisteme üye olurken ad, soyad, mail adresi, şifre ve şifre tekrar bilgileri girilir. Şifre en az 8 karakter olur ve hem harf hem rakam içerir. Her mail adresine sadece bir üyelik tanımlıdır. Kullanıcılar daha sonra profil sayfalarından bu bilgileri görüntülerler. İsterlerse şifre değişikliği yaparlar. Oluşturulan yeni şifre de en az 8 karakter olur ve hem harf hem rakam içerir.

### Üye Girişi Yapma

Kullanıcılar kayıt esnasında verdikleri mail ve şifre bilgileriyle giriş yaparlar. Admin kullanıcısı ise sistem ayağa kaldırılırken oluşturulan mail ve şifre bilgisiyle giriş yapar.

### Admin Kullanıcısı Olma

Admin kullanıcısı, sistem üzerinden etkinlik oluşturulurken gerekli olan kategorileri ve lokasyon için şehir bilgilerini düzenler. Kategori ekleme, güncelleme ve kaldırma işlemlerini yapar. Kategorilerin sadece adı vardır ve bir ad sadece bir kategoriyi tanımlar. Aynı zamanda sistemde geçerli şehir bilgilerini girer. Admin kullanıcısı, kullanıcıların oluşturduğu etkinlikleri inceler. Onay verir veya reddeder. Reddettiği etkinlik sistem üzerinden kaldırılır.

### Etkinlik Düzenleme

Kullanıcılar sistem üzerinde etkinlik oluşturabilirler. Etkinliğin adını, gerçekleşeceği tarihi, katılım için başvurulara kapatılacağı tarihi, açıklamasını (tanıtım yazısı, detaylar vb. için), düzenlendiği şehri, adresini, kontenjanı, biletli olup olmadığını bilgisini ve kategorisini girerler. Kategoriyi sistemde tanımlı olan seçenekler arasından seçerler. Düzenlendiği şehri sistemde tanımlı olanlar içerisinden seçerler. Eğer biletli olarak seçtilerse etkinliğin ücretini de girerler. Organizatör, etkinliği oluşturduktan sonra başvurulara kapatacağı tarihe 5 gün kalana kadar iptal edebilir. Aynı şekilde 5 gün kalana kadar kontenjan ve etkinlik adresi bilgilerini güncelleyebilir. Oluşturulan etkinlik admin onayına gider. Admin onaylarsa sistem üzerinde aktifleşir. Eğer admin reddederse organizatöre bilgilendirme yapılır. Kullanıcılar organize ettikleri etkinlikleri listelerler.

### Etkinliğe Katılma

Kullanıcılar sistemde tanımlı etkinlikleri görüntülerler. İsterlerse kategori ve şehre göre filtreleyebilirler. İstedikleri etkinliği "Katılıyorum" seçeneği ile işaretlerler. Eğer etkinlik kontenjanı dolmuşsa buna yönelik uyarı verilir. Kullanıcılar katıldıkları etkinlikleri ve katılacağı etkinlikleri ayrı ayrı listelerler. Kullanıcı biletli bir etkinliğe katılmak isterse, bileti satın alabileceği firmaların adını görüntüler ve istediğine tıklayarak firmanın web sitesine yönlendirilir.

### Bilet Satış Entegrasyonu

Geliştirilecek sistemde etkinlikler için bilet satışı yapılmayacaktır ancak biletli etkinlik düzenlenebilecektir. Bu etkinlikler için bilet satışı, bu işlemi yapan firmalar üzerinden gerçekleşecektir. Katılımcının bilet satın alması, katılımcı ile satın alma işlemini yaptığı firma arasında bir süreçtir. Geliştirilecek sistemin bu süreçte bir dahli ve sorumluluğu yoktur. Sisteme entegre olmak isteyen bilet firmaları öncelikle kayıt olur. Kayıt esnasında firma adı, web sitesi alan adı, mail adresi ve şifre bilgilerini girer. Bu firmalar, sistem üzerinde tanımlı etkinlik bilgilerini çekebilirler. Bu firmalar farklı yapılara sahip olabileceğinden sistem bu verileri hem XML, hem de JSON formatında sunar.
