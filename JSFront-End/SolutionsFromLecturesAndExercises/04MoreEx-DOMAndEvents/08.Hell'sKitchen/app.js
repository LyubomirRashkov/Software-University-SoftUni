function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const textarea = Array.from(document.getElementsByTagName('textarea'))[0];
      const [firstParagraph, secondParagraph] = Array.from(document.getElementsByTagName('p'));

      let inputRestaurants = JSON.parse(textarea.value);

      let restaurants = restaurantsFiller(inputRestaurants);

      let bestRestaurant = restaurants.shift();

      for (const restaurant of restaurants) {
         if (restaurant.avgSalary() > bestRestaurant.avgSalary()) {
            bestRestaurant = restaurant;
         }
      }

      let firstOutput = `Name: ${bestRestaurant.name} Average Salary: ${(bestRestaurant.avgSalary()).toFixed(2)} Best Salary: ${(bestRestaurant.bestSalary()).toFixed(2)}`;

      firstParagraph.textContent = firstOutput;

      let secondOutput = '';

      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      for (const worker of sortedWorkers) {
         secondOutput += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }

      secondParagraph.textContent = secondOutput;

      function restaurantsFiller(restaurantsAsObjs) {
         class Restaurant {
            constructor(name) {
               this.name = name;
               this.workers = [];
            }

            bestSalary () {
               let salaries = this.workers.map((w) => w.salary);

               return Math.max.apply(Math, salaries);
            }

            avgSalary() {
               let salaries = this.workers.map((w) => w.salary);
               let sumOfSalaries = salaries.reduce((prev, curr) => prev + curr, 0);

               return sumOfSalaries / salaries.length;
            }
         }

         let listOfRestaurants = [];

         for (const item of restaurantsAsObjs) {
            let [restaurantName, restaurantWorkers] = item.split(' - ');

            let restaurant = listOfRestaurants.find((r) => r.name === restaurantName);

            if (!restaurant) {
               restaurant = new Restaurant(restaurantName);

               listOfRestaurants.push(restaurant);
            }

            let listOfWorkers = restaurantWorkers.split(', ');

            for (const item of listOfWorkers) {
               let [workerName, salary] = item.split(' ');
               salary = Number(salary);

               let worker = {
                  name: workerName,
                  salary: salary,
               };

               restaurant.workers.push(worker);
            }
         }

         return listOfRestaurants;
      }
   }
}