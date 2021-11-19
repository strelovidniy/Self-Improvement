# SelfImprovement - стань кращою версією себе!

Посилання: self-improvement.azurewebsites.net
Посилання на бота: https://t.me/yours_improvement_bot

Даний веб-сервіс було розроблено щоб допомогти користувачам розвивати себе фізично, розумово та ментально, ставлячи перед собою цілі та відслідковуючи прогрес. А для того, щоб не опускати руки та іти до кінця, на сервісі завжди доступний чат-бот зі спеціалістом-психологом.

Отож, на головній сторінці, користувач має можливість поставити ціль. Для цього в модальному вікні потрібно вказати назву, опис цілі та початкову і кіневу дати для формування корисної звички.

На розділі Dashboard користувач має можливість переглянути всі свої цілі, відмітити ціль як досягнуту або ж видалити її. До речі, статус (очікує, активна, досягнута) цілі автоматично трекається за допомогою Hangfire jobs, отож на кінцеву дату кожної цілі її статус буде змінено на досягунту автоматично

Також на веб-сервісі реалізована авторизація за допомогою Google OAuth2.0. Адміністратор має змогу переглядати користувачів, змінювати їхні дані та видаляти їх.

Використані API: Google OAuth2.0, Telegram bot API
