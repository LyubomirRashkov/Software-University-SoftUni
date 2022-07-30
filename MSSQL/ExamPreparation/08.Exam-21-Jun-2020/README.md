## PROBLEMS DESCRIPTION - EXAM – 21 JUN 2020


### Section 1. DDL 

You are given an E/R Diagram of the Trip Service:

![изображение](https://user-images.githubusercontent.com/82647282/170972134-61597195-c188-459f-b47e-a16bbbbce1e0.png)

Crеate a database called TripService. You need to create 6 tables:
  +	Cities – contains information about cities and their countries.
  +	Hotels – contains information about the hotels in the system.
  +	Rooms – contains information about the rooms each hotel has.
  +	Trips – contains information about each trip.
  +	Accounts – contains information about the trip service users.
  +	AccountsTrips – contains information about all accounts and their trips.

Cities

| Column Name | Data Type | Constraints |
| --- | --- | --- |
| Id | Integer from 0 to 2,147,483,647 | Unique table identificator, Identity |
| Name | String up to 20 symbols, Unicode | NULL is not allowed |
| CountryCode | String with exactly 2 symbols | NULL is not allowed |

 Hotels
 
| Column Name | Data Type | Constraints |
| --- | --- | --- |
| Id | Integer from 0 to 2,147,483,647 | Unique table identificator, Identity |
| Name | String up to 30 symbols, Unicode | NULL is not allowed |
| CityId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Cities |
| EmployeeCount | Integer from 0 to 2,147,483,647 | NULL is not allowed |
| BaseRate | Decimal number with two-digit precision |  |

Rooms

| Column Name | Data Type | Constraints |
| --- | --- | --- |
| Id | Integer from 0 to 2,147,483,647 | Unique table identificator, Identity |
| Price | Decimal number with two-digit precision | NULL is not allowed |
| Type | String up to 20 symbols, Unicode | NULL is not allowed |
| Beds | Integer from 0 to 2,147,483,647 | NULL is not allowed |
| HotelId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Hotels |

Trips

| Column Name | Data Type | Constraints |
| --- | --- | --- |
| Id | Integer from 0 to 2,147,483,647 | Unique table identificator, Identity |
| RoomId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Rooms |
| BookDate | Date | NULL is not allowed, must be before ArrivalDate |
| ArrivalDate | Date | NULL is not allowed, must be before ReturnDate |
| ReturnDate | Date | NULL is not allowed |
| CancelDate | Date |  |

Accounts

| Column Name | Data Type | Constraints |
| --- | --- | --- |
| Id | Integer from 0 to 2,147,483,647 | Unique table identificator, Identity |
| FirstName | String up to 50 symbols, Unicode | NULL is not allowed |
| MiddleName | String up to 20 symbols, Unicode |  |
| LastName | String up to 50 symbols, Unicode | NULL is not allowed |
| CityId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Cities |
| BirthDate | Date | NULL is not allowed |
| Email | String up to 100 symbols | NULL is not allowed, Unique |

AccountsTrips

| Column Name | Data Type | Constraints |
| --- | --- | --- |
| AccountId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Accounts |
| TripId | Integer from 0 to 2,147,483,647 | NULL is not allowed, Relationship with table Trips |
| Luggage | Integer from 0 to 2,147,483,647 | NULL is not allowed, must be at least 0 |

#### Problem 1. Database design

Submit all of your create statements to Judge (only creation of tables).

### Section 2. DML 

Before you start, you must import “DataSet-TripService.sql”. If you have created the structure correctly, the data should be successfully inserted without any errors.

In this section, you must do some data manipulations.

#### Problem 2. Insert

Insert some sample data into the database. Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.

Accounts

| FirstName | MiddleName | LastName | CityId | BirthDate | Email |
| --- | --- | --- | --- | --- | --- |
| John | Smith | Smith | 34 | 1975-07-21 | j_smith@gmail.com |
| Gosho | NULL | Petrov | 11 | 1978-05-16 | g_petrov@gmail.com |
| Ivan | Petrovich | Pavlov | 59 | 1849-09-26 | i_pavlov@softuni.bg |
| Friedrich | Wilhelm | Nietzsche | 2 | 1844-10-15 | f_nietzsche@softuni.bg |

Trips

| RoomId | BookDate | ArrivalDate | ReturnDate | CancelDate |
| --- | --- | --- | --- | --- |
| 101 | 2015-04-12 | 2015-04-14 | 2015-04-20 | 2015-02-02 |
| 102 | 2015-07-07 | 2015-07-15 | 2015-07-22 | 2015-04-29 |
| 103 | 2013-07-17 | 2013-07-23 | 2013-07-24 | NULL |
| 104 | 2012-03-17 | 2012-03-31 | 2012-04-01 | 2012-01-10 |
| 109 | 2017-08-07 | 2017-08-28 | 2017-08-29 | NULL |

#### Problem 3. Update

Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.

#### Problem 4. Delete

Delete all of Account ID 47’s account’s trips from the mapping table.

### Section 3. Querying 

You need to start with a fresh dataset, so recreate your DB and import the sample data again (DataSet-TripService.sql).

#### Problem 5. EEE-Mails

Select accounts whose emails start with the letter “e”. Select their first and last name, their birthdate in the format "MM-dd-yyyy", their city name and their Email. Order them by city name (ascending).

Example:

| FirstName | LastName | BirthDate | Hometown | Email |
| --- | --- | --- | --- | --- |
| Edgardo | Slessar | 12-29-1983 | Glasgow | e_slessar@outlook.com |
| Eadith | Gull | 03-03-1983 | Haskovo | e_gull@outlook.com |
| Eward | Prigg | 12-10-1982 | Shumen | e_prigg@gmail.com |
| Evvie | Covolini | 01-11-1979 | Wolverhampton | e_covolini@softuni.bg |

#### Problem 6. City Statistics

Select all cities with the count of hotels in them. Order them by the hotel count (descending), then by city name. Do not include cities, which have no hotels in them.

Example:

| City | Hotels |
| --- | --- |
| Belfast | 11 |
| Cardiff | 11 |
| Chelyabinsk | 11 |
| Phoenix | 11 |
| San Francisco | 11 |
| Seattle | 11 |
| Veliko Tarnovo | 11 |
| Houston | 10 |
| ... | ... |

#### Problem 7. Longest and Shortest Trips

Find the longest and shortest trip for each account, in days. Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null). Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).

Example:

| AccountId | FullName | LongestTrip | ShortestTrip |
| --- | --- | --- | --- |
| 40 | Winna Maisey | 7 | 1 |
| 56 | Tillie Windress | 7 | 1 |
| 57 | Eadith Gull | 7 | 1 |
| 66 | Sargent Rockhall | 7 | 1 |
| 69 | Jerome Flory | 7 | 2 |
| ... | ... | ... | ... |

#### Problem 8. Metropolis

Find the top 10 cities, which have the most registered accounts in them. Order them by the count of accounts (descending).

Example:

| Id | City | Country | Accounts |
| --- | --- | --- | --- |
| 76 | Tyumen | RU | 5 |
| 12 | Haskovo | BG | 4 |
| 33 | Belfast | UK | 4 |
| ... | ... | ... | ... |

#### Problem 9. Romantic Getaways

Find all accounts, which have had one or more trips to a hotel in their hometown. Order them by the trips count (descending), then by Account ID.

Example:

| Id | Email | City | Trips |
| --- | --- | --- | --- |
| 50 | t_joules@mail.com | New York | 2 |
| 19 | m_stango@yahoo.com | Burgas | 1 |
| 48 | n_revitt@softuni.bg | Bradford | 1 |
| ... | ... | ... | ... |

#### Problem 10. GDPR Violation

Retrieve the following information about each trip:
  +	Trip ID
  +	Account Full Name
  +	From – Account hometown
  +	To – Hotel city 
  +	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”

Order the results by full name, then by Trip ID.

Example:

| Id | Full Name | From | To | Duration |
| --- | --- | --- | --- | --- |
| 273 | Adah Douglass Lathaye | Stara Zagora | Cardiff | Canceled |
| 491 | Adah Douglass Lathaye | Stara Zagora | Houston | 4 days |
| 776 | Adah Douglass Lathaye | Stara Zagora | Chelyabinsk | 3 days |
| 133 | Allissa Rickey Gigg | Austin | Veliko Tarnovo | 6 days |
| ... | ... | ... | ... | ... |

### Section 4. Programmability 

#### Problem 11. Available Room

Create a user defined function, named udf_GetAvailableRoom(@HotelId, @Date, @People), that receives a hotel ID, a desired date and the count of people that are going to be signing up.

The total price of the room can be calculated by using this formula: (HotelBaseRate + RoomPrice) * PeopleCount

The function should find a suitable room in the provided hotel, based on these conditions:
  +	The room must not be already occupied. A room is occupied if the date the customers want to book is between the arrival and return dates of a trip to that room and the trip is not canceled.
  +	The room must be in the provided hotel.
  +	The room must have enough beds for all the people.

If any rooms in the desired hotel satisfy the customers’ conditions, find the highest priced room (by total price) of all of them and provide them with that room.

The function must return a message in the format:
  +	“Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}”

If no room could be found, the function should return “No rooms available”.

Example:

| Query | Output |
| --- | --- |
| SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2) | Room 211: First Class (5 beds) - $202.80 |
| SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3) | No rooms available |

#### Problem 12. Switch Room

Create a user defined stored procedure, named usp_SwitchRoom(@TripId, @TargetRoomId), that receives a trip and a target room and attempts to move the trip to the target room. A room will only be switched if all of these conditions are true:
  +	If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
  +	If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.

If all the above conditions pass, change the trip’s room ID to the target room ID.

Example:

| Query | Output |
| --- | --- |
| EXEC usp_SwitchRoom 10, 11 <br> SELECT RoomId FROM Trips WHERE Id = 10 | 11 |
| EXEC usp_SwitchRoom 10, 7 | Target room is in another hotel! |
| EXEC usp_SwitchRoom 10, 8 | Not enough beds in target room! |
