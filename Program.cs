/*
    ### 7. Определение и применение интерфейсов

* **Контекст:** Конфликт имен в универсальном контроллере устройства.
* **Задание:**
1. Создайте интерфейсы `IBluetoothDevice` (метод `void Reset()`) и `ISystemControl` (метод `void Reset()`).
2. Создайте класс `SmartSpeaker`, реализующий оба интерфейса через **явную реализацию** (`void IBluetoothDevice.Reset()` и `void ISystemControl.Reset()`).
3. В `Main` создайте объект `SmartSpeaker` и вызовите метод `Reset()` отдельно для Bluetooth и отдельно для системного сброса с помощью приведения типов.

*/

interface IBluetoothDevice
{
    void Reset();
}

interface ISystemControl
{
    void Reset();
}

class SmartSpeaker : IBluetoothDevice, ISystemControl
{
    void IBluetoothDevice.Reset() { Console.WriteLine("Bluetooth Reset"); }
    void ISystemControl.Reset() { Console.WriteLine("System reset"); }
}

class Program
{
    static void Main()
    {
        SmartSpeaker smartSpeaker = new SmartSpeaker();
        IBluetoothDevice smartSpeaker2 = new SmartSpeaker();
        ISystemControl smartSpeaker3 = new SmartSpeaker();

        smartSpeaker2.Reset();
        smartSpeaker3.Reset();
        Console.WriteLine();
        ((IBluetoothDevice)smartSpeaker).Reset();
        ((ISystemControl)smartSpeaker).Reset();
    }
}