# Dossier de conception

## Frontend

## Ecrans

- Page "Liste des RDV" (URL = `/bookings`)
  - liste affichée sous forme de liste
  - chaque ligne permet de supprimer le RDV associé
- Page "Formulaire de prise de RDV" (URL = `/make-booking`)
  - deux boutons pour sélectionner la salle
  - une liste déroulante des créneaux disponibles pour la salle.
  - liste de champs de saisi pour :
    - un nom,
    - un prénom,
    - une date de naissance
    - une adresse mail

## Backend

### Les services

- `GET /api/v1.0/rooms` : liste les salles

  - entrée : aucune
  - sortie : liste d'objets `List<Room>`
  - status code :
    - 200 si OK
    - 500 si exception non gérée
  - métier : retourne toutes les salles.

- `GET /api/v1.0/rooms/{roomId}/avaibility?date={requestDate}` : liste les disponibilités de la salle pour un jour donné

  - entrées :
    - `roomId` : identifiant de la salle
    - `requestDate` : jour de réservation
  - sortie : liste d'objets `AvailableTimeSlot`
  - status code :
    - 200 si OK
    - 500 si exception non gérée
  - métier : retourne tous les créneaux disponibles pour la salle et le jour demandés.

- `GET /api/v1.0/rooms/{roomId}/bookings`: liste les RDV pris pour une salle

  - entrée : `roomId`, type `string`
  - sortie : liste d'objets `Booking`
  - status code :
    - 200 si OK
    - 500 si exception non gérée
  - métier : liste tous les RDV de la salle.

- `GET /api/v1.0/bookings`: liste tous les RDV pris

  - entrée : aucune
  - sortie : liste d'objets `Booking`
  - status code :
    - 200 si OK
    - 500 si exception non gérée
  - métier : liste tous les RDV, pas de filtre.

- `POST /api/v1.0/bookings`: ajoute un RDV

  - entrée : objet `BookingRequest`
  - sortie : `bool`
  - status code :
    - 200 si OK
    - 422 si données fournies incomplètes (ex: pas de nom) ou invalide (ex: créneau déjà pris)
    - 500 si exception non gérée
  - métier :
    - vérifie la complétude des entrées
    - ajoute le RDV à la liste des RDV

- `DELETE /api/v1.0/bookings/{id}`: supprime un RDV
  - entrée : `id` (type: string)
  - sortie : `bool`
  - status code :
    - 204 si le RDV est supprimé
    - 500 si exception non gérée
  - métier :
    - vérifie que le RDV existe
    - supprime le RDV

### Les entités

#### La classe `Room`

    - `Id`: de type String, contenant un UUID
    - `Name`: de type String

#### La classe `Booking`

- `Id` : de type String, contenant un UUID
- `Booker`: de tpye `Individual`
- `BookingTimeSlot` : de type `BookingTimeSlot`.

#### La classe `Individual`

- `LastName` : de type String
- `FirstName` : de type String
- `BirthDate` : de type DateTime, formaté en "YYYY-mm-dd".
- `Email` : de type String, et est un email valide

#### La classe `BookingRequest`

- `LastName` : de type String
- `FirstName` : de type String
- `BirthDate` : de type DateTime, formaté en "YYYY-mm-dd".
- `Email` : de type String, et est un email valide
- `AvailableTimeSlot` : de type `AvailableTimeSlot`.
- `RoomId` : de type String
- `IsBooked` : de type Boolean
- `Date` : de type DateTime

#### La classe `TimeSlot`

- `StartTime` : de type String, formaté en "HH:MM".
- `EndTime` : de type String, formaté en "HH:MM".

#### La classe `BookingTimeSlot`

- `RoomId` : de type String
- `Id`: de type String, contenant un UUID
- `Date` : de type DateTime
- `StartTime` : de type String, formaté en "HH:MM".
- `EndTime` : de type String, formaté en "HH:MM".
- `IsBooked` : de type Boolean

#### La classe `BookingTimeSlot`

- `RoomId` : de type String
- `Id`: de type String, contenant un UUID
- `Date` : de type DateTime
- `StartTime` : de type String, formaté en "HH:MM".
- `EndTime` : de type String, formaté en "HH:MM".
- `IsBooked` : de type Boolean
