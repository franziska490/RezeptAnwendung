# Dokumentation Rezept-Anwendung
## Team und Projektidee
    - Laura, Franziska
    - Rezeptanwendung
## Projekttagebuch
| Was wurde gemacht                  | Wann               | Wer    |
|------------------------------------|--------------------|--------|
| Projektidee/Umsetzung überlegen    | 24.04 - 8.5.2024   | Beide  |
| Rezept API themealdb Implementieren   | 08.05 - 09.05.2024 | Laura  |
| GUI Anfang                         | 08.05 - 09.05.2024 | Franziska |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |
| Inhalt                             | Inhalt             | Inhalt |

 
## Planungsphase

Idee: Rezeptanwendung mithilfe einer API

**Mindestanforderungen**

    - Benutzeroberfläche 
    - API mit Rezepten
    - Suchfunktion mit Filter
    - Detailansicht für Rezepte
    - Einkaufsliste
    - Bewertungen
**Nice-to-have**

    - Kochplaner

**Umsetzung**

    - Benutzeroberfläche:
    Startseite mit Sucheingabe für die Rezepte. Filter um nach bestimmenten Rezepten zu filtern. Optionen zum Anzeigen von gespeicherten Rezepten, Hinzufügen neuer Rezepte und Suchen nach Rezepten.
    Seiten für die Anzeige einzelner Rezepte mit Details wie Zutatenliste, Anleitung.

    - Datenbank: 
    Rezept: Enthält Informationen wie Titel, Zutatenliste, Anleitung, Schwierigkeitsgrad, Bewertungen usw.
    Zutat: Enthält Informationen über einzelne Zutaten, die in Rezepten verwendet werden.
    Kategorie: Ermöglicht die Kategorisierung von Rezepten (z.B. Vorspeisen, Hauptgerichte, Desserts).
    Backend-Logik:
     Funktionen zum Hinzufügen, Bearbeiten und Löschen von Rezepten.
    Suchfunktionen, um Rezepte basierend auf Titel, Zutaten oder Kategorien zu finden.
    Frontend-Implementierung:
    Verwendet WPF-Elemente wie Fenster, Seiten, Navigationsleisten, Textfelder, Listenansichten usw., um die Benutzeroberfläche zu erstellen.
    Datenbindung, um die Anzeige von Rezepten und anderen Informationen aus der Datenbank zu ermöglichen.
## AUFBAU

**Aufbau der GUI:**

    rgufhighdfaighia
    adijgoaidhgiu

**Aufbau des Programms:**

    Klassen:
        - KP (macht dies das annanas)
        - AHHHH (macht dies das annanas)
        - fhiweufhiuweh (macht dies das annanas)
    
Properties, Methoden, Konstruktoren
...
...
...
...
...
...
...
...
...
...
...
...
...




## Umsetzungsdetails
**Softwarevoraussetzungen:**
    - Edamam Recipe Search API `https://developer.edamam.com/admin/applications`
    - Microsoft Visual Studio Code 2022

**Funktionsblöcke bzw. Architektur**
    -
    -
    -   

**Beschreibung der Umsetzung**


**Probleme und deren Lösungen**

## Softwaretestung

## Bedienungsanleitung

## Quellen
- Edamam Recipe Search API `https://developer.edamam.com/admin/applications`



Chatgpt HEFTIG


### Erläuterung der Änderungen:

1. **Laden der Kategorien:**
   - Die Methode `LoadMealCategories` lädt die Kategorien beim Start und füllt die `ComboBox`.

2. **Suchfunktion anpassen:**
   - `SearchRecipes` wurde erweitert, um auch nach der Kategorie zu filtern.
   - `SearchButton_Click` berücksichtigt jetzt die ausgewählte Kategorie.

3. **Kategorieauswahl ändern:**
   - `CategoryComboBox_SelectionChanged` lädt die Rezepte basierend auf der ausgewählten Kategorie und dem Suchbegriff.

Diese Änderungen ermöglichen es dir, Rezepte nach Kategorie zu filtern und gleichzeitig einen Suchbegriff zu verwenden. Dadurch wird die Benutzerfreundlichkeit deiner Anwendung verbessert.
