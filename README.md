# PhoneBook
Basit bir telefon defteri uygulaması
# Kullanılan teknolojiler
  - .NET Core
  - Git
  - PostgreSQL
  - Rabbit Message Queue sistemi
  
# Çalıştırma
- WebAPI katmanındaki appsettings.json dosyasını açıp. Alttaki resimde bulunan PhoneBookConnection ve RabbitMQService alanları düzenlenir. 
    - PhoneBookConnection bilgisi bilgisayarınızdaki kurulu olan postreSQL bilgileri girilebilir. 
    - RabbitMQService bilgisiyse RabbitMQ sunucunuz varsa bilgilerini girebilirsiniz kurulu değilse de şuanki yazan bilgi cloud RabbitMQ bağlıdır çalışacaktır.
![image](https://user-images.githubusercontent.com/18622751/226195367-90a59336-c264-40e4-9a9e-fbd14d6e134b.png)
- Migration işlemlerine başlanır. Package Manager Console açılarak.
    - Add-Migration Init komutu çalıştırılır. "Build succeeded" mesajı alındıysa başarıyla tamamlanmıştır.
    - Update-Database komutu çalıştırılır. "Build succeeded" mesajı alındıysa başarıyla tamamlanmıştır.
![image](https://user-images.githubusercontent.com/18622751/226203284-813c4e51-9ae7-4d0d-8af4-097f6f07eaa0.png)
- Projeyi çalıştırmadan önce WebAPI local port kontrol edilir. WebAPI/Properties/launchSettings.json içinde bulunan profiles/http/applicationUrl de WebAPI nin kullandığı port bilgisayarında kullanılıyor ise değiştirebilirsiniz. Bunu değiştirdiğiniz zaman WebApp projesi içinde bunun configuration dosyası(appsettings.json) içindeki "WebServiceURL" adresi değiştirilen WebAPI portu yazılır.
![image](https://user-images.githubusercontent.com/18622751/226203736-065a4083-75a9-44e5-8665-8a49b00c9f9d.png)
- Solution 'PhoneBook' ana solution'a sağ tıklanarak Properties açılır. Bu pencerede "Startup Project" olarak PhoneBook.WebAPI ve PhoneBook.WebApp' in Actiondan Start olarak seçilir.
![image](https://user-images.githubusercontent.com/18622751/226203978-2244420a-ea5d-4d1b-bdfd-4705a79d6f7c.png)
- Daha sonra proje çalıştırılır.
