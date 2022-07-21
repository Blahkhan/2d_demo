# 2d_demo
### By Mateusz "Blahkhan" Oleksa

Wersja Unity 2020.2.6f1

### Wymagania: 

- Wykorzystanie systemu GIT do stworzenia projektu

- Podstawowy ruch postaci - ruch lewo/prawo, skok, opadanie 

- Dodanie ataku bohatera po wciśnięciu przycisku na klawiaturze 

- Dodanie prostego systemu zbierania pieniędzy po wejściu w pieniążek. Informacja o zebranych pieniądzach powinna znajdować się na UI 

- Dodanie prostego systemu punktów życia dla gracza. Informacja o posiadanych punktach życia powinna znajdować się na UI (bazowo gracz posiada 3 punkty życia) 

- Implementacja prostego przeciwnika "grzyba" z punktami patrolowymi, który:  

    1) Jeżeli nie ma wyznaczonych punktów patrolu to stoi w miejscu.  

    2) Jeżeli posiada zdefiniowane punkty patrolu to porusza się między nimi. 

    3) Posiada 2 punkty życia. Jedno uderzenie gracza zabiera 1 punkty życia. Po utracie wszystkich punktów umiera 

    4) Jeżeli gracz wejdzie w przeciwnika to otrzymuje 1 punkty obrażeń i zostaje odepchnięty w przeciwnym kierunku do przeciwnika

- Po utraceniu wszystkich punktów życia gracz umiera i nie można nim kontrolować 

- Animacje zmieniają się w zależności od stanu postaci 


### Lista dodatkowych zadań: 

- Dodanie obsługi Gamepada 

- Skorzystanie z Input Systemu

- Wykorzystanie systemu Zenject/Extenject

- Dodanie nowego typu przeciwnika - Goblina, który potrafi zaatakować gracza, jeśli ten zbliży się na określoną odległość. Podobnie jak grzyb może stać w miejscu albo patrolować w zależności od ustawień w inspektorze. 

- Projekt posiada bardzo dużo możliwości rozwoju, dlatego wszelkie nowatorskie pomysły na urozmaicenie rozgrywki są mile widziane :) 