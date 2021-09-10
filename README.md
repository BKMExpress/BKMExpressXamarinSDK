# BKM EXPRESS XAMARIN PLUGIN

## NE İŞE YARAR?
> BKM Express Xamarin Plugin, kullanıcının BKMExpress ile yapacağı ödemeler için, işyeri uygulamasından çıkmadan, kart eşleme, kart değiştirme ve güvenli ödeme yapma seçeneklerini sunmaktadır.

## NASIL ÇALIŞIR?

BKM Express Xamarin paketinin kullanılabilmesi için işyerleri BKM Express entegrasyonlarını tamamlaması gerekmektedir. Daha sonra işyeri servis uygulamaları BKMExpress core servislerine bağlanarak kendilerine verilen **TOKEN**'ı SDK tarafından sunulan methodlara parametrik olarak ileterek kart eşleştirme, değiştirme ve güvenli ödeme akışını başlatabilirler.

## ORTAMLAR

Kart eşleme paketi iki farklı ortamda çalışmaktadır. 
* PROD
* PREPROD

**NOT:** Entegrasyon sırasında işyerlerine verilen anahtarların sorumluluğu, **işyerine** aittir.

### Xamarin Entegrasyonu

 BKM Express Xamarin Plugin kullanmak için sırası ile aşağıdaki adımlar izlenmelidir.
 
**NOT:** Plugine şu link üzerinden ulaşabilirsiniz. https://www.nuget.org/packages/BKMExpress.Xamarin/ 

* İlk olarak BKMExpress.Xamarin adlı pluginin son versiyonunu projenize ekleyiniz.

* Eğer Android projenizin Kotlin desteği bulunmuyorsa "Xamarin.Kotlin.StdLib" paketini Android projenize ekleyiniz.

* Projeye eklendikten sonra kullanılacak dosyaya aşağıdaki gibi import edilmelidir.

        using Bex.Xamarin;

* Paketi kullanmak için ilk olarak init fonksiyonunu çağırmanız gerekmektedir. PreProd ortama bağlanmak için init aşamasında isDebugEnabled true olarak setlenmelidir.

        BexSDK.Instance.Init(); // Prod
    
        BexSDK.Instance.Init(true); // PreProd
    
BKMExpress SDK arayüzlerinden geri haber alabilmek için **IBexPaymentListener** ve **IBexPairingListener** kullanılması gerekmektedir.

#### IBexPaymentListener
    void OnPaymentSuccess(BexPosResult posResult);
    void OnPaymentCancelled();
    void OnPaymentFailure(int errorId, string errorMsg);
    
#### IBexPairingListener
    void OnPairingSuccess(string first6, string last2);
    void OnPairingCancelled();
    void OnPairingFailure(int errorId, string errorMsg);
    
    
### Örnek Ödeme Akışı
    BexSDK.Instance.Payment("token", this);

### Örnek Eşleşme Akışı
    BexSDK.Instance.SubmitConsumer("token", this); // Kart Eşleştirme
    BexSDK.Instance.ResubmitConsumer("ticket", this); // Kart Güncelleme
