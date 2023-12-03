## PROBLEM DESCRIPTION - DATA STRUCTURES AUGMENTATION


### Problem

We are given a Visual Studio project skeleton (unfinished project) holding the unfinished classes Person, PersonCollection and PersonCollectionSlow and unit tests covering the functionality of the "person collection" data structure.

You need to support the following operations:

  +	bool Add(email, name, age, town)
    +	"email" is unique for each person
    +	Returns true if a new Person is created and false if the email already exists.
  +	Person Find(email) – returns the Person with that email or null.
  +	bool Delete(email) – returns true if the person is deleted, or false if it didn’t exist
  +	IEnumerable\<Person\> FindPeople(emailDomain) – returns a collection of matching people ordered by email ascending
  +	IEnumerable\<Person\> FindPeople(name, town) – returns a collection of matching people ordered by email ascending
  +	IEnumerable\<Person\> FindPeople(startAge, endAge) – returns a collection of matching people ordered by age ascending, then by email ascending. Borders are inclusive.
  +	IEnumerable\<Person\> FindPeople(startAge, endAge, town) – returns a collection of matching people ordered by age ascending, then by email ascending. Borders are inclusive.

Classes PeopleCollection and PeopleCollectionSlow hold unfinished implementations of the IPersonCollection interface. These classes should be used to implement the data structure in two different ways – with list of people (simple but slow implementation) and by several dictionaries (efficient implementation).

The project comes also with unit tests and performance tests covering the functionality of the “people collection”.