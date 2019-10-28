# hardware-drm

Проект для демонстрации работы с идентификаторами устройств через c#.

## DeviceManager
Приложение DeviceManager отображает информацию о подключенных USB устройствах, включая DeviceId.

## SampleDrmApplication
Приложение SampleDrmApplication содержит логику проверки наличия hardware ключа с указанным deviceId.
На данный момент написано на .net Core 3.0, но поддерживает работу с Win OS, так как используется WMI.
