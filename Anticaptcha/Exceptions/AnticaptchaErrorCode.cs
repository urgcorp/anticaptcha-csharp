namespace Anticaptcha.Exceptions
{
    public enum AnticaptchaErrorCode
    {
        /// <summary>
        /// No errors
        /// </summary>
        NONE = 0,
        /// <summary>
        /// <para>Авторизационный ключ не был найден в системе. </para>
        /// <para>Убедитесь, что ключ скопирован правильно, без пробелов и знаков табуляции.</para>
        /// </summary>
        KEY_DOES_NOT_EXIST = 1,
        /// <summary>
        /// <para>Нет свободных работников в данный момент.</para>
        /// </summary>
        NO_SLOT_AVALIABLE = 2,
        /// <summary>
        /// Размер загружаемой капчи меньше 100 байт.
        /// </summary>
        ZERO_CAPTCHA_FILESIZE = 3,
        /// <summary>
        /// Размер загружаемой капчи больше 500,000 байт.
        /// </summary>
        TOO_BIG_CAPTCHA_FILESIZE = 4,

        /// <summary>
        /// Баланс учетной записи равен нулю или отрицательный.
        /// </summary>
        ZERO_BALANCE = 10,
        /// <summary>
        /// <para>Запрос с данным ключом доступа не разрешен с вашего IP адреса.</para>
        /// <para>Проверьте свои настройках API в личном кабинете.</para>
        /// </summary>
        IP_NOT_ALLOWED = 11,
        /// <summary>
        /// 5 работников не смогли решить капчу. Клиенты платят за такие задачи, так как они потребляют время работников.
        /// </summary>
        CAPTCHA_UNSOLVABLE = 12,
        /// <summary>
        /// Функция 100% распознавания не сработала, так как закончились попытки распознавания.
        /// </summary>
        BAD_DUPLICATES = 13,
        /// <summary>
        /// Запров в API был сделан по несуществующему имени метода.
        /// </summary>
        NO_SUCH_METHOD = 14,
        /// <summary>
        /// <para>Не смогли определить тип картинки по заголовку EXIF, или такой формат не поддерживается.</para>
        /// <para>Поддерживаются только JPG, GIF, PNG. Картинки должны содержать заголовок EXIF.</para>
        /// </summary>
        IMAGE_TYPE_NOT_SUPPORTED = 15,
        /// <summary>
        /// <para>Запрашиваемая вами капча не была найдена в ваших активных капчах или устарела.</para>
        /// <para>Капчи удаляются из API через 60 секунд после завершения их решения работником.
        /// В течение этого периода нужно присылать все запросы на получение результата капчи,
        /// а также отчеты о правильном/неправильном результате.</para>
        /// </summary>
        NO_SUCH_CAPCHA_ID = 16,

        /// <summary>
        /// <para>Ваш IP был заблокирован из-за некорректного использования API.</para>
        /// <para>Узнать причину https://anti-captcha.com/ru/clients/tools/ipsearch</para>
        /// </summary>
        IP_BLOCKED = 21,
        /// <summary>
        /// Свойство "task" пустое или не указано в методе createTask.
        /// </summary>
        TASK_ABSENT = 22,
        /// <summary>
        /// Тип задачи не поддерживается или набран некорректно. Пожалуйста, проверьте свойство "type" в объекте задачи.
        /// </summary>
        TASK_NOT_SUPPORTED = 23,
        /// <summary>
        /// Некоторые требуемые значения для успешной эмуляции пользователя отсутствуют.
        /// Вывод API содержит информацию о том, чего не хватает.
        /// </summary>
        INCORRECT_SESSION_DATA = 24,
        /// <summary>
        /// Не смогли подсоединиться к прокси задаче, таймаут соединения.
        /// </summary>
        PROXY_CONNECT_REFUSED = 25,
        /// <summary>
        /// Не смогли подсоединиться к прокси задаче, таймаут чтения.
        /// </summary>
        PROXY_CONNECT_TIMEOUT = 26,
        /// <summary>
        /// Таймаут чтения прокси
        /// </summary>
        PROXY_READ_TIMEOUT = 27,
        /// <summary>
        /// IP прокси заблокирован в целевом сервисе.
        /// </summary>
        PROXY_BANNED = 28,
        /// <summary>
        /// <para>Задача отклонена на стадии проверки прокси. Он должен быть непрозрачным и прятать IP наших серверов.</para>
        /// <para>Для проверки можно использовать https://anti-captcha.com/ru/clients/tools/proxychecker</para>
        /// </summary>
        PROXY_TRANSPARENT = 29,

        /// <summary>
        /// Таймаут решения рекапчи, скорее всего из-за медленного прокси сервера или сервера Google.
        /// </summary>
        RECAPTCHA_TIMEOUT = 30,
        /// <summary>
        /// Провайдер капчи сообщил о неверном ключе капчи.
        /// </summary>
        RECAPTCHA_INVALID_SITEKEY = 31,
        /// <summary>
        /// Провайдер капчи сообщил, что домен не зарегистрирован на этом ключе капчи.
        /// </summary>
        RECAPTCHA_INVALID_DOMAIN  = 32,
        /// <summary>
        /// Провайдер капчи сообщил, что user-agent браузера не совместим с их скриптами.
        /// </summary>
        RECAPTCHA_OLD_BROWSER = 33,
        /// <summary>
        /// Провайдер капчи сообщил о том, что истек срок действия дополнительного токена.
        /// Пожалуйста, попробуйте снова с новым токеном.
        /// </summary>
        TOKEN_EXPIRED = 34,
        /// <summary>
        /// <para>Прокси не поддерживает передачу картинок от серверов Google.</para>
        /// <para>Для проверки можно использовать https://anti-captcha.com/ru/clients/tools/proxychecker</para>
        /// </summary>
        PROXY_HAS_NO_IMAGE_SUPPORT = 35,
        /// <summary>
        /// <para>Прокси не поддерживает длинные GET запросы больше 2000 байт и не поддерживает SSL подключения.</para>
        /// <para>Для проверки можно использовать https://anti-captcha.com/ru/clients/tools/proxychecker</para>
        /// </summary>
        PROXY_INCOMPATIBLE_HTTP_VERSION = 36,

        /// <summary>
        /// Логин и пароль прокси неправильные.
        /// </summary>
        PROXY_NOT_AUTHORISED = 49,
        /// <summary>
        /// Передан sitekey от другого типа рекапчи. Попробуйте решить ее как V2, V2-invisible или V3.
        /// </summary>
        INVALID_KEY_TYPE = 51,
        /// <summary>
        /// Не смогли отобразить виджет капчи в браузере работника.
        /// Попробуйте прислать новую задачу.
        /// </summary>
        FAILED_LOADING_WIDGET = 52,
        /// <summary>
        /// Попытка решить обычную рекапчу как невидимую. Уберите флаг 'isInvisible' из запроса к API.
        /// </summary>
        VISIBLE_RECAPTCHA = 53,
        /// <summary>
        /// Не осталось работников, которые не были бы отфильтрованы методом reportIncorrectRecaptcha.
        /// </summary>
        ALL_WORKERS_FILTERED = 54,
        /// <summary>
        /// <para>Система заблокировала ключ по серьезной причине.</para>
        /// <para>Свяжитесь с поддержкой https://anti-captcha.com/ru/clients/help/tickets</para>
        /// </summary>
        ACCOUNT_SUSPENDED = 55,
        /// <summary>
        /// Шаблон AntiGate не был найден во время создания задачи.
        /// </summary>
        TEMPLATE_NOT_FOUND = 56,
        /// <summary>
        /// Задача AntiGate была отменена работником.
        /// В поле "errorDescription" указана причина отмены.
        /// </summary>
        TASK_CANCELED = 57
    }
}