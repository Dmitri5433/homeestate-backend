# HomeEstate Backend API

ASP.NET Core 8 Web API — архитектура по образцу eUShop.

## Структура проекта

```
HomeEstate.sln
├── HomeEstate.Api           ← Controllers + Program.cs + Swagger
├── HomeEstate.BusinessLogic ← Interface + Core/Action + Functions/Flow
├── HomeEstate.DataAccess    ← DbContext (SQLite) + DbSession
└── HomeEstate.Domains       ← Entities + DTOs + Enums + Models
```

## Запуск

```bash
cd HomeEstate.Api
dotnet run
```

Swagger откроется на: http://localhost:5182/swagger

## API Endpoints

| Метод  | URL                       | Описание              |
|--------|---------------------------|-----------------------|
| GET    | /api/apartment/getAll     | Все квартиры          |
| GET    | /api/apartment/id?id=1    | Квартира по ID        |
| POST   | /api/apartment            | Создать квартиру      |
| PUT    | /api/apartment            | Обновить квартиру     |
| DELETE | /api/apartment/id?id=1    | Удалить квартиру      |
| GET    | /api/health               | Проверка работы API   |

## Пример POST /api/apartment

```json
{
  "name": "Современная студия",
  "city": "Кишинёв",
  "category": "Студия",
  "rooms": 1,
  "area": 35.5,
  "price": 45000,
  "imageUrl": "https://example.com/img.jpg"
}
```

## База данных

SQLite — файл `homeestate.db` создаётся автоматически при первом запуске.
