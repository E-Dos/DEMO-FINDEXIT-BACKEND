namespace TEMPLATE_ELDOS_BACKEND.App
{
    public enum EdsTypeEnum
    {
        //Подписание
        Signing = 1,
        //Утверждение
        Approving = 2,
    }
    public enum EdsSignGroupEnum
    {
        /// <summary>
        /// Принимающие
        /// </summary>
        Accept = 1,

        /// <summary>
        /// Сдающие работу
        /// </summary>
        Passer = 2,

        /// <summary>
        /// Утверждающие
        /// </summary>
        Approving = 3
    }
    public enum SecurityPermissionTypeEnum
    {
        //Просмотр
        View,
        //Создание/Редактирования
        Edit,
        //Удаление
        Delete,
        //Отправка email
        Send
    }
    public enum MessageLevelEnum
    {
        Info = 1,
        Error = 2,
        Warning = 3,
        DeviceMaxValWarning = 4
    }

}