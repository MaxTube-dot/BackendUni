# ВТБ Relations (Backend)
ВТБ Relations - это платформа геймификаци, направленная на повышение мотивации и вовлечённости сотрудников в корпоративные события банка ВТБ, а также на развитие софт- и хард- скиллов работников.

## Веб-адрес
Нашу платформу можно открыть, перейдя ао веб-адресу http://www.unimvp.ru:81/

### Параметры для входа
- Логины сотрудников - alex, andrey, ilya
- Логин администратора - ivan
- Пароли для всех пользоателей - 0000


## Разработка
### При разработке серверной части платформы были использованы такие технологии, как:
- C#
- ASP.NET
- EntityFramework Core

В качестве БД использовалась PostgreSQL.

### Стек фронтенд части:
- Vue.JS
- Bootstrap
- Scss
- Axios 

## Инструкция по запуску 
### Backend:
1. Развернуть базу данных PostgreSQL из файла [бэкапа](https://github.com/MaxTube-dot/BackendUni/blob/master/BackupDB) 
2. Открыть решение в среде VisualStudio, поддерживающей работу с проектами .NET 6
3. В файле конфигурации appsettings.json проекта BackendUni ввести корректную строку подключения к БД
```json
    "DefaultConnection": "Host=192.168.1.4;Port=5432;Database=GamificationDB;Username=postgres;Password=110011"
```
4. Запустить проект

## Краткая схема компонентов системы
![Alt-текст](https://sun9-72.userapi.com/impg/1MjRoaNewXpIa1tpNYLi3Rz_hSxF90C30w8eVA/V75AmSVQHVM.jpg?size=378x230&quality=95&sign=4c148294afedc0c232cdf360a1cfb9ce&type=album)
