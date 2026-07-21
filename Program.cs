/*
    ### 7. Определение и применение интерфейсов

* **Контекст:** Система сохранения файлов в разные хранилища.
* **Задание:**
1. Объявите интерфейс `IStorageSaver` с методом `void Save(string fileName, byte[] data)`.
2. Реализуйте его в классах `LocalStorage` (пишет в консоль *"Сохранение на диск"*) и `CloudStorage` (пишет в консоль *"Загрузка в облако"*).
3. Создайте класс `DocumentManager`, который принимает `IStorageSaver` через конструктор и имеет метод `SaveDocument(...)`. Продемонстрируйте подмену хранилища.

*/

interface IStorageSaver
{
    void Save(string fileName, byte[] data);
}

class LocalStorage : IStorageSaver
{
    public void Save(string fileName, byte[] data)
    {
        Console.WriteLine($"Local save '{fileName}', size: {data.Length}");
    }
}
class CloudStorage : IStorageSaver
{
    public void Save(string fileName, byte[] data)
    {
        Console.WriteLine($"Cloude save '{fileName}', size: {data.Length}");
    }
}

class DocumentManager
{
    private readonly IStorageSaver? storageSaver;
    public DocumentManager(IStorageSaver storageSaver)
    {
        this.storageSaver = storageSaver;
    }

    public void SaveDocument(string fileName, byte[] data)
    {
        storageSaver?.Save(fileName, data);
    }
}

class Program
{
    static void Main()
    {
        byte[] fileData = new byte[] { 4, 3, 5, 55, 3 };

        var localStorage = new LocalStorage();
        var cloudStorage = new CloudStorage();
        var documentManager = new DocumentManager(localStorage);
        documentManager.SaveDocument("L_Data", fileData);
    }
}