## Domain Models

## Menu

```csharp
class Menu
{
    Manu Create();
    void AddDiner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}

```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "menu name",
    "description": "menu description",
    "averageRating": 4.5,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "section name",
            "description": "section description",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "item name",
                    "description": "item description"
                }
            ]
        }
    ],
    "hostId": "00000000-0000-0000-0000-000000000000",
    "dinerIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
    "createdDateTime": "2026-01-01 00:00:00",
    "updatedDateTime": "2026-02-02 00:00:00"
}
```