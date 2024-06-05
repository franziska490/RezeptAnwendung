# Dokumentation Rezept-Anwendung
## Team und Projektidee
    - Laura, Franziska
    - Rezeptanwendung
## Projekttagebuch
| Was wurde gemacht                  | Wann               | Wer        |
|------------------------------------|--------------------|------------|
| Projektidee/Umsetzung überlegen    | 24.04 - 8.5.2024   | Beide      |
| Rezept API "themealdb" implementieren | 08.05 - 09.05.2024 | Laura      |
| GUI Anfang                         | 08.05 - 09.05.2024 | Franziska  |
| GUI Design| 09.05.2024             | Franziska     |
|Hauptmethoden Mainwindow| 10.05.2024|Laura|
| RecipeDetailsWindow| 15.05.2024| Franziska|
| API| 15.05.2024| Franziska     |
| Sorter| 28.05.2024             | Laura     |
|                            |         |   |
| API Änderung                             | 20.05 - 29.05.2024             | Franziska     |
| Recipe Sorter                             | 20.05 - 29.05.2024             | Laura    |
| Inhalt                             | Inhalt             | Inhalt     |

 
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
#### Backend-Logik
- Funktionen zum Hinzufügen, Bearbeiten und Löschen von Rezepten.
- Suchfunktionen, um Rezepte basierend auf Titel, Zutaten oder Kategorien zu finden.

#### Frontend-Implementierung
- Verwendet WPF-Elemente wie Fenster, Seiten, Navigationsleisten, Textfelder, Listenansichten usw., um die Benutzeroberfläche zu erstellen.
- Datenbindung, um die Anzeige von Rezepten und anderen Informationen aus der Datenbank zu ermöglichen.


#### Benutzeroberfläche
- **Startseite**: Sucheingabe für die Rezepte, Filter um nach bestimmten Rezepten zu filtern, Optionen zum Anzeigen von gespeicherten Rezepten, Hinzufügen neuer Rezepte und Suchen nach Rezepten.
- **Detailseiten**: Anzeigen einzelner Rezepte mit Details wie Zutatenliste und Anleitung.

#### Datenbank
Enthält Informationen wie Titel, Zutatenliste, Anleitung, Bewertungen usw.

- **Kategorie**: Ermöglicht die Kategorisierung von Rezepten (z.B. Vorspeisen, Hauptgerichte, Desserts).


## AUFBAU

**Aufbau der GUI:**

    Die GUI besteht aus mehreren Komponenten, die in einer Grid-Struktur angeordnet sind:
- Eine **Suchleiste** mit einem Textfeld und einem Suchbutton.
- Eine **ListBox**, die die Suchergebnisse anzeigt.
- Eine **ComboBox** für die Auswahl der Rezeptkategorie.
- Ein **Textfeld**, das den aktuellen Essensplan anzeigt.

**Aufbau des Programms:**
Das Programm besteht aus mehreren Klassen und Dateien:

- **MainWindow.xaml** und **MainWindow.xaml.cs**: Enthalten die Hauptlogik der Anwendung, einschließlich der Benutzeroberfläche und der Interaktionen.
- **Recipe.cs**: Modelliert die Datenstruktur eines Rezepts.
- **MealPlanner.cs**: Verwalten den Essensplan, inklusive Speichern und Laden.
- **RecipeDetailsWindow.xaml** und **RecipeDetailsWindow.xaml.cs**: Zeigen die Details eines ausgewählten Rezepts an.


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
    - Themealdb: `https://www.themealdb.com/api/`
    - Microsoft Visual Studio Code 2022

**Funktionsblöcke bzw. Architektur**
- **MainWindow**: Hauptfenster der Anwendung, das die Suchfunktion und die Anzeige der Rezepte ermöglicht.
- **RecipeDetailsWindow**: Fenster zur Anzeige der Details eines ausgewählten Rezepts.
- **MealPlanner**: Verwaltung des Essensplans, inklusive Speichern und Laden.

**Beschreibung der Umsetzung**
- **Laden der Kategorien**: Die Methode `LoadMealCategories` lädt die Kategorien beim Start und füllt die `ComboBox`.
- **Suchfunktion anpassen**: `SearchRecipes` wurde erweitert, um auch nach der Kategorie zu filtern. `SearchButton_Click` berücksichtigt jetzt die ausgewählte Kategorie.
- **Kategorieauswahl ändern**: `CategoryComboBox_SelectionChanged` lädt die Rezepte basierend auf der ausgewählten Kategorie und dem Suchbegriff.


**Probleme und deren Lösungen**
Merge Conflicts    Diem


## Softwaretestung

## Bedienungsanleitung

## Quellen
 Themealdb: `https://www.themealdb.com/api/json/v1/1/`

