function loadCommits() {
    const BASE_URL = "https://api.github.com/repos/";

    const inputUsername = document.getElementById('username');
    const inputRepo = document.getElementById('repo');
    const ulContainer = document.getElementById('commits');

    let username = inputUsername.value;
    let repo = inputRepo.value;

    ulContainer.innerHTML = '';

    fetch(`${BASE_URL}${username}/${repo}/commits`)
        .then((res) => res.json())
        .then((response) => {
            for (const item of response) {
                let authorName = item.commit.author.name;
                let commitMessage = item.commit.message;

                let newLi = document.createElement('li');
                newLi.textContent = `${authorName}: ${commitMessage}`;

                ulContainer.appendChild(newLi);
            }
        })
        .catch ((err) => {
            console.error(err);
        })
}

// async function loadCommits() {
//     const BASE_URL = "https://api.github.com/repos/";

//     const inputUsername = document.getElementById('username');
//     const inputRepo = document.getElementById('repo');
//     const ulContainer = document.getElementById('commits');

//     let username = inputUsername.value;
//     let repo = inputRepo.value;

//     ulContainer.innerHTML = '';

//     try {
//         let res = await fetch(`${BASE_URL}${username}/${repo}/commits`);
//         let response = await res.json();

//         for (const item of response) {
//             let authorName = item.commit.author.name;
//             let commitMessage = item.commit.message;

//             let newLi = document.createElement('li');
//             newLi.textContent = `${authorName}: ${commitMessage}`;

//             ulContainer.appendChild(newLi);
//         }
//     } catch (err) {
//         console.error(err);
//     }
// }