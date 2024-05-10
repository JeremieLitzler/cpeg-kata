# Coding test `cpeg-kata`

## Enoncé

L’exercice porte sur le développement d’une application simple de prise de rendez-vous avec les gestionnaires de la CPEG.

### L’application doit permettre de :

- Planifier un rendez-vous sur les créneaux disponibles
- Afficher la liste des rendez-vous pris
- Supprimer un rendez-vous planifié

### L’objectif de l’exercice est de montrer

- Votre approche de modélisation « restful » (url paths, status codes …)
- Votre maitrise de .NET (C#, WebApi ou MinimalApi)
- Les pratiques mises en oeuvre lorsque vous développez (IOC, Tests, etc …)

### L’objectif n’est pas

- De fournir un livrable abouti ou terminé, tant que l’approche de modélisation et vos pratiques ont été exprimées.

### Périmètre de l’exercice

- Il y a 2 salles pour accueillir les rendez-vous
- Il y a 10 créneaux par salle par jour
- Un créneau dure 30 minutes
- L’utilisateur doit choisir son créneau puis saisir son nom, son prénom, sa date de naissance et son adresse mail pour prendre le rendez-vous (pas de confirmation par mail)
- Pas d’authentification, pas de gestion de droits, pas de back-office
- Le choix du stockage n’a pas d’importance, faites au plus simple
- L’ergonomie et l’aspect graphique du front ne seront pas évalués
- Le temps alloué est libre, néanmoins il est conseillé de ne pas dépasser 8 heures

### Stack technique :

- Langage : C#
- Framework Back : API REST (avec Web API ou MinimalApi) et Swagger
- Framework Front : Angular (avec TypeScript) ou Blazor
- L’utilisation de librairies tierces est autorisée

### Livrables :

- Code source du Back et du Front
