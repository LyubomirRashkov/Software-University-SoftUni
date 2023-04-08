function loadRepos() {
   const BASE_URL = "https://api.github.com/users/testnakov/repos";

   const divResult = document.getElementById('res');

   fetch(BASE_URL)
      .then((res) => res.text())
      .then((response) => {
         divResult.textContent = response
      })
      .catch((err) => {
         console.error(err);
      });
}

// async function loadRepos() {
//    const BASE_URL = "https://api.github.com/users/testnakov/repos";

//    const divResult = document.getElementById('res');

//    try {
//       const res = await fetch(BASE_URL);
//       const response = await res.text();

//       divResult.textContent = response;
//    } catch (err) {
//       console.error(err);
//    }
// }