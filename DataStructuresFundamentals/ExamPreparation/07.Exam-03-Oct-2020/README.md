## PROBLEMS DESCRIPTION


### Problem 1.1	Inventory

You are given a skeleton with a class Inventory that implements the IHolder interface. The methods are not implemented your task is to implement them:

  +	int Capacity – returns the number of weapons that are inside the inventory.
  +	void Add(IWeapon weapon) – adds an awesome weapon inside the inventory.
  +	IEntity GetById(int id) – returns the weapon by the given id, if the weapon does NOT exist return null.
  +	bool Contains(IWeapon) – returns true if the weapon is stored and false otherwise.
  +	int Refill(IWeapon weapon int ammunition) – refills the weapon with the given ammunition. If the weapon does NOT exist throw an InvalidOperationException("Weapon does not exist in inventory!"). Keep in mind that the ammunition of a weapon should NOT overflow the given max capacity. Return the new ammunition.
  +	bool Fire(IWeapon weapon, int ammunition) – fires a weapon from the inventory with the given ammunition. If the weapon does NOT exist throw an InvalidOperationException("Weapon does not exist in inventory!"). The method returns if firing is possible, e.g the fire ammunition is NOT more than the one inside our weapon. 
  +	IWeapon RemoveById(int id) – removes the weapon with the given id from the inventory and returns it. If the id is NOT valid throw an InvalidOperationException("Weapon does not exist in inventory!").
  +	void Clear () – removes all the weapons stored inside the Inventory
  +	List\<IWeapon\> RetrieveAll() – returns all the weapons inside a List. If there are none – return an empty list.
  +	void Swap(IWeapon first, IWeapon second) – finds and swaps the position of the first weapon with the second weapon. If either of them DO NOT exist throw an InvalidOperationException("Weapon does not exist in inventory!"). Keep in mind that weapons can be swapped only if they are from the same category.
  +	List\<IWeapon\> RetrieveInRange(Category lowerBound, Category upperBound) – returns all the weapons with given category within the range (both are inclusive) if none are found return an empty List
  +	void EmptyArsenal(Category category) – empties the ammunition of all weapons from the given category.
  +	int RemoveHeavy() – removes all heavy weapons and returns their count.
  +	IEnumerator\<IWeapon\> GetEnumerator() – iterates through the collection in insertion order

### Problem 1.2	Inventory - Performance

For this task you will only be required to submit the code from the Inventory problem. If you are having problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

### Problem 2.1	Legion System

You are given a skeleton with a class Legion that implements the IArmy interface. The legion stores different types of enemies in hierarchical order. Each enemy has the following properties:

  +	int AttackSpeed
  +	int Health

The legion is based around the attack speed of its enemies (could be in increasing or decreasing order). Another thing to keep in mind is that it CANNOT contain enemies with the same attack speed. Your task is to implement the following methods:

  +	int Size – returns the number of enemies inside the legion system.
  +	void Create(IEnemy enemy) – adds an enemy inside the legion system. Should store only unique enemies, with a different attack speed.
  +	IEnemy GetByAttackSpeed (int attackSpeed) – returns the enemy with the given attack speed, otherwise returns null.
  +	bool Contains(IEnemy enemy) – returns if the enemy exists inside the legion.
  +	IEnemy GetFastest() – returns the fastest enemy with the largest attack speed. If the legion system is empty throw an InvalidOperationException("Legion has no enemies!").
  +	IEnemy GetSlowest() – returns the slowest enemy with the least attack speed. If the legion system is empty throw an InvalidOperationException("Legion has no enemies!").
  +	IEnemy ShootFastest() – removes the fastest enemy from the legion. If the legion system is empty throw an InvalidOperationException("Legion has no enemies!").
  +	IEnemy ShootSlowest() – removes the slowest enemy from the legion. If the legion system is empty throw an InvalidOperationException("Legion has no enemies!").
  +	IEnemy[] GetOrderedByHealth() – returns the whole legion as an array ordered by their health in descending. If the legion contains no enemies return an empty array.
  +	List\<IEnemy\> GetFaster(int speed) – retrieves all enemies that are faster than the given attack speed (not inclusive), otherwise returns an empty collection.
  +	List\<IEnemy\> GetSlower(int speed) – retrieves all enemies that are slower than the given attack speed (not inclusive), otherwise returns an empty collection.

### Problem 2.2	Legion System - Performance

For this task you will only be required to submit the code from the Legion problem. If you are having problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.